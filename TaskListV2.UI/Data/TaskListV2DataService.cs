using System;
using System.Collections.Generic;
using System.IO;
using TaskListV2.DataAccessNew;
using TaskListV2.Model;

namespace TaskListV2.UI.Data
{
    class TaskListV2DataService : ITaskListV2DataService
    {
        private const string SettingsFile = "Settings.json";
        private int radioButtonDB;
        public IDataAccessV2 DataAccessV2 { get; set; }
        public IDataAccessV2 DataAccess { get; set; }
        public IDataAccessSQLite DataAccessSQLite { get; set; }
        public IFileDataAccess FileDataAccess { get; set; }

        public TaskListV2DataService(IDataAccessV2 dataAccessSQL, IDataAccessSQLite dataAccessSQLite, IFileDataAccess fileDataAccess)
        {
            DataAccess = dataAccessSQL;
            DataAccessSQLite = dataAccessSQLite;
            FileDataAccess = fileDataAccess;
            DataAccessV2 = GetDataBase();
        }

        IDataAccessV2 GetDataBase()
        {
            try
            {
                radioButtonDB = Int32.Parse(File.ReadAllText(SettingsFile));
            }
            catch (Exception)
            {
                radioButtonDB = 0;
            }

            switch (radioButtonDB)
            {
                case 0:
                    DataAccessV2 = (IDataAccessV2)FileDataAccess;
                    break;
                case 1:
                    DataAccessV2 = (IDataAccessV2)DataAccessSQLite;
                    break;
                case 2:
                    DataAccessV2 = DataAccess;
                    break;
                default:
                    break;
            }
            return DataAccessV2;
        }
        public IEnumerable<Task> GetAll()
        {
            GetDataBase();
            return DataAccessV2.GetTasks();
        }


        //ToDo: keine statische Methode!
        public static List<string> LeftMenuItems = new List<string>
        {
            "Mein Tag",
            "Wichtig",
            "Geplant",
            "Aufgaben"
        };


        public IEnumerable<Task> Aufgaben()
        {
            GetDataBase();
            return DataAccessV2.GetTasks();
        }

        public IEnumerable<Task> Important()
        {
            GetDataBase();
            return DataAccessV2.Important();
        }
        public IEnumerable<Task> Today()
        {
            GetDataBase();
            return DataAccessV2.Today();
        }
        public IEnumerable<Task> Planned()
        {
            GetDataBase();
            return DataAccessV2.Planned();
        }
        public void CreateTask(string name, bool Complete, bool Important, DateTime Due, Reminder Reminder, Category Category, Repetition Repetition)
        {
            GetDataBase();
            DataAccessV2.CreateTask(name, Complete, Important, Due, Reminder, Category, Repetition);
        }
        public void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete)
        {
            GetDataBase();
            DataAccessV2.EditTask(taskId, name, category, due, reminder, repetition, important, complete);
        }
        public void TaskIsComplete(bool complete, int taskId)
        {
            GetDataBase();
            DataAccessV2.TaskIsComplete(complete, taskId);
        }



    }
}
