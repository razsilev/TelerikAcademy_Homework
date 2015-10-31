using System;
using System.Collections.Generic;
using System.IO;

namespace ToDoListModel
{
    public class MissionFileControler : IMissionFileControler
    {
        public const string MissionFilePath = "ToDoList.txt";

        public void AddMission(Mission mission)
        {
            FileStream fs = new FileStream(MissionFilePath, FileMode.Append, FileAccess.Write);

            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.WriteLine(mission.Serialize());
            }
        }

        public void DeleteMission(Mission mission)
        {
            string tempFile = "temp.txt";
            string serializedMissionForDeleting = mission.Serialize();
            FileStream fsRead = new FileStream(MissionFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream fsWrite = new FileStream(tempFile, FileMode.Create, FileAccess.ReadWrite);

            using (StreamReader reader = new StreamReader(fsRead))
            {
                using (StreamWriter writer = new StreamWriter(fsWrite))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();

                        if (!line.Equals(serializedMissionForDeleting))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }

            File.Delete(MissionFileControler.MissionFilePath);
            File.Move(tempFile, MissionFileControler.MissionFilePath);
        }

        /*
        public List<Mission> GetAllMisions()
        {
            var tasks = new List<Mission>();

            FileStream fs = new FileStream(MissionFilePath, FileMode.OpenOrCreate, FileAccess.Read);

            using (StreamReader reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    string serializedMission = reader.ReadLine();
                    var mission = Mission.Deserialize(serializedMission);
                    tasks.Add(mission);
                }
            }

            return tasks;
        }
        */
    }
}
