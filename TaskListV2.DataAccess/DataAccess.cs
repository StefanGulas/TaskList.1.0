using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TaskListV2.Model;


namespace TaskListV2.DataAccess
{
    public class DataAccess
    {
        public ObservableCollection<Task> GetTasks(bool showAllTasks)
        {
            using var con = Helper.Conn();

            con.Open();

            string getTasks;

            if (showAllTasks)
            {
                getTasks = "SELECT * FROM Tasks ORDER BY Complete, TaskId DESC";
            }
            else if (!showAllTasks)
            {
                getTasks = "SELECT * from Tasks WHERE Complete = 'false' ORDER BY TaskId DESC";
            }
            else getTasks = "";

            ObservableCollection<Task> taskList = new ObservableCollection<Task>(con.Query<Task>(getTasks).ToList());

            con.Close();

            return taskList;
        }
    }
}
