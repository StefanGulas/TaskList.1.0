using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using TaskListV2.Model;

namespace TaskListV2.DataAccessNew
{
  public class FileDataAccess : IDataAccessV2
  {
    private const string StorageFile = "Task.json";


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
      return ReadFromFile();
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
    private List<Task> ReadFromFile()
    {
      if (!File.Exists(StorageFile))
      {
        return new List<Task>
                {
                    new Task{TaskId=1,TaskName = "Buch kaufen",TaskCategory=0,
                        IsImportant = true},
                     new Task{TaskId=2,TaskName = "Shoppen",TaskCategory=0,
                        IsImportant = false}
                };
      }

      string json = File.ReadAllText(StorageFile);
      return JsonConvert.DeserializeObject<List<Task>>(json);
    }
  }
}
