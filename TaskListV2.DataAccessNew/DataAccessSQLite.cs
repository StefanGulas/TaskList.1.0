using System;
using System.Collections.Generic;
using System.Text;
using TaskListV2.Model;

namespace TaskListV2.DataAccessNew
{
  public class DataAccessSQLite : IDataAccessV2
  {
    public void CreateTask(string name, bool Complete, bool Important, DateTime Due, Reminder Reminder, Category Category, Repetition Repetition)
    {
      throw new NotImplementedException();
    }

    public void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Task> GetTasks()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Task> Important()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Task> Planned()
    {
      throw new NotImplementedException();
    }

    public void TaskIsComplete(bool complete, int TaskId)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Task> Today()
    {
      throw new NotImplementedException();
    }
  }
}
