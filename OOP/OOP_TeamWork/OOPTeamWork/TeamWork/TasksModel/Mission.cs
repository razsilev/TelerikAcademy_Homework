using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoListModel
{
    public class Mission : DatabaseModel.ISerializable<Mission>
    {
        private string name;
        private string description;
        private PriorityLevel priority;
        private DateTime date;

        public Mission()
        {
        }

        public Mission(string name, string description, PriorityLevel priority, DateTime date)
        {
            this.Name = name;
            this.Description = description;
            this.Priority = priority;
            this.date = date;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public PriorityLevel Priority
        {
            get
            {
                return this.priority;
            }
            set
            {
                this.priority = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
            set
            {
                this.date = value;
            }
        }

        public string Serialize()
        {
            StringBuilder str = new StringBuilder();

            str.Append(this.Name);
            str.Append('|');
            str.Append(this.Description);
            str.Append('|');
            str.Append(this.Priority);
            str.Append('|');
            str.Append(this.date.Day + "." + this.date.Month + "." + this.date.Year);

            return str.ToString();
        }

        //public static Mission Deserialize(string missionObjectSerialized)
        public Mission Deserialize(string missionObjectSerialized)
        {
            var tokens = missionObjectSerialized.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

            string nameTask = tokens[0];
            string descriptionTask = tokens[1];
            PriorityLevel prioriryTask;
            var dataTokens = tokens[3].Split('.');

            DateTime selectedDate = new DateTime(int.Parse(dataTokens[2]), int.Parse(dataTokens[1]), int.Parse(dataTokens[0]));
            
            switch (tokens[2].Trim())
            {
                case "Low": prioriryTask = PriorityLevel.Low;
                    break;
                case "Medium": prioriryTask = PriorityLevel.Medium;
                    break;
                case "Urgent": prioriryTask = PriorityLevel.Urgent;
                    break;
                default: throw new ArgumentException("Deserialize, invalid prioriry");
            }

            return new Mission(nameTask, descriptionTask, prioriryTask, selectedDate);
        }
    }
}
