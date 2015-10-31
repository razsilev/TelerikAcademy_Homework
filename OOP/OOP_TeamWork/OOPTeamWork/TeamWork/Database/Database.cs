using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public class Database<RecordType> : IDatabase<RecordType> where RecordType : ISerializable<RecordType>, new()
    {
        private string dataFilePath;
        public List<RecordType> ListOfItems { get; protected set; }

        private static Database<RecordType> database;

        public static Database<RecordType> GetDatabase(string dataFilePath)
        {
            if (database == null)
            {
                database = new Database<RecordType>(dataFilePath);
            }
            return database;
        }

        private Database()
        {
            this.ListOfItems = new List<RecordType>();
        }

        private Database(string dataFilePath)
            : this()
        {
            this.DataFilePath = dataFilePath;
            this.LoadAllItemsFromFile();
        }

        public string DataFilePath
        {
            get
            {
                return dataFilePath;
            }
            protected set
            {
                dataFilePath =
                    String.IsNullOrWhiteSpace(value) ?
                    (typeof(RecordType).Name + "List.txt") :
                    value;
            }
        }

        public void LoadAllItemsFromFile()
        {
            FileStream fs = new FileStream(this.DataFilePath, FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader reader = new StreamReader(fs))
            {
                var item = (RecordType)Activator.CreateInstance(typeof(RecordType), new object[] { });

                while (!reader.EndOfStream)
                {
                    try
                    {
                        string serializedItem = reader.ReadLine();
                        //RecordType item = new RecordType();//(RecordType)(new object());//ISerializable<RecordType>.Deserialize(serializedItem);

                        var newItem = item.Deserialize(serializedItem);
                        this.ListOfItems.Add(newItem);
                    }
                    catch (Exception)
                    {
                        //TODO: throw corect exception.
                    }
                    
                }
            }
        }

        public void SaveAllItemsToFile()
        {
            string tempFileName = "temp.txt";
            FileStream fsWrite = new FileStream(tempFileName, FileMode.Create, FileAccess.ReadWrite);
            using (StreamWriter writer = new StreamWriter(fsWrite))
            {
                foreach (var item in this.ListOfItems)
                {
                    writer.WriteLine(item.Serialize());
                }
            }

            File.Delete(this.DataFilePath);
            File.Move(tempFileName, this.DataFilePath);
        }

        public void AddItem(RecordType item)
        {
            this.ListOfItems.Add(item);

            // We could use this.SaveAllItemsToFile() here insted
            // This way however we save a lot of write operations
            // We will need to use this.SaveAllItemsToFile() if we switch to ordered list.
            FileStream fs = new FileStream(this.DataFilePath, FileMode.Append, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(item.Serialize());
            }
        }

        public void DeleteItem(RecordType item)
        {
            this.ListOfItems.RemoveAll(x => x.Serialize() == item.Serialize());
            this.SaveAllItemsToFile();
        }
    }
}
