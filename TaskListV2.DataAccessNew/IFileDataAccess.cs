using System;
using System.Collections.Generic;
using TaskListV2.Model;

namespace TaskListV2.DataAccessNew
{
    public interface IFileDataAccess
    {
        void CreateTask(string name, bool complete, bool important, DateTime due, Reminder reminder, Category category, Repetition repetition);
        void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete);
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> Important();
        IEnumerable<Task> Planned();
        void TaskIsComplete(bool complete, int Id);
    }
}