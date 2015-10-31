using System;
using System.Collections.Generic;

namespace ToDoListModel
{
    public interface IMissionFileControler
    {
        void AddMission(Mission mission);

        void DeleteMission(Mission mission);

        //List<Mission> GetAllMisions();
    }
}
