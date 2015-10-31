using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public interface IDatabase<RecordType> where RecordType : ISerializable<RecordType>, new()
    {
        void LoadAllItemsFromFile();
        void SaveAllItemsToFile();
        void DeleteItem(RecordType recordToDelete);
        void AddItem(RecordType recordToAdd);
        // void ModifyItem(RecordType recordToModify);
    }
}
