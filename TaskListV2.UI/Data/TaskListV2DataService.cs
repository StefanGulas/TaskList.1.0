using System;
using System.Collections.Generic;
using TaskListV2.DataAccessNew;
using TaskListV2.Model;

namespace TaskListV2.UI.Data
{
  class TaskListV2DataService : ITaskListV2DataService
  {
    private readonly IDataAccessV2 _dataAccessV2;

    public TaskListV2DataService(IDataAccessV2 dataAccessV2)
    {
      _dataAccessV2 = dataAccessV2;
    }

    public IEnumerable<Task> GetAll()
    {
      return _dataAccessV2.GetTasks();
    }

    public static List<string> LeftMenuItems = new List<string>
        {
            "Mein Tag",
            "Wichtig",
            "Geplant",
            "Aufgaben"
        };

    public IEnumerable<Task> Aufgaben()
    {
      return _dataAccessV2.GetTasks();
    }

    public IEnumerable<Task> Important()
    {
      return _dataAccessV2.Important();
    }
    public IEnumerable<Task> Today()
    {
      return _dataAccessV2.Today();
    }
    public IEnumerable<Task> Planned()
    {
      return _dataAccessV2.Planned();
    }
    public void CreateTask(string name, bool Complete, bool Important, DateTime Due, Reminder Reminder, Category Category, Repetition Repetition)
    {
      _dataAccessV2.CreateTask(name, Complete, Important, Due, Reminder, Category, Repetition);
    }
    public void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete)
    {
      _dataAccessV2.EditTask(taskId, name, category, due, reminder, repetition, important, complete);
    }
    public void TaskIsComplete(bool complete, int taskId)
    {
      _dataAccessV2.TaskIsComplete(complete, taskId);
    }



  }
}
