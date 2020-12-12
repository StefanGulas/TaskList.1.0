using System;
using System.Collections.Generic;
using TaskListV2.Model;

namespace TaskListV2.UI.Data
{
    public interface ITaskListV2DataService
    {
        IEnumerable<Task> GetAll();
        IEnumerable<Task> Planned();
        IEnumerable<Task> Today();
        IEnumerable<Task> Important();
        void CreateTask(string name, bool complete, bool important, DateTime due, Reminder reminder, Category category, Repetition repetition);
        void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete);
        void TaskIsComplete(bool complete, int TaksId);
  }
}