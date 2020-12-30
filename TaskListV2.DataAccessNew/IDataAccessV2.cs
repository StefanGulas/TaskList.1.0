using System;
using System.Collections.Generic;
using TaskListV2.Model;

namespace TaskListV2.DataAccessNew
{
    public interface IDataAccessV2
    {
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> Important();
        IEnumerable<Task> Planned();
        IEnumerable<Task> Today();
        void CreateTask(string name, bool Complete, bool Important, DateTime Due, Reminder Reminder, Category Category, Repetition Repetition);
        void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete);
        void TaskIsComplete(bool complete, int TaskId);
    }
}