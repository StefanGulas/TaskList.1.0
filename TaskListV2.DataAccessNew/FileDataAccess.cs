﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using TaskListV2.Model;

namespace TaskListV2.DataAccessNew
{
  public class FileDataAccess : IDataAccessV2
  {
    private const string StorageFile = "tasks.json";


    public void CreateTask(string name, bool complete, bool important, DateTime due, Reminder reminder, Category category, Repetition repetition)
    {
      var task = new Task
      {
        TaskName = name,
        TaskComplete = complete,
        IsImportant = important,
        DueDate = due,
        Reminder = reminder,
        TaskCategory = category,
        TaskRepetition = repetition,
      };

      var tasks = ReadFromFile();
      var maxFriendId = tasks.Count == 0 ? 0 : tasks.Max(f => f.TaskId);
      task.TaskId = maxFriendId + 1;
      tasks.Add(task);
      SaveToFile(tasks);
    }

    private void SaveToFile(List<Task> taskList)
    {
      string json = JsonConvert.SerializeObject(taskList, Formatting.Indented);
      File.WriteAllText(StorageFile, json);
    }

    public void TaskIsComplete(bool complete, int Id)
    {
      var tasks = ReadFromFile();
      foreach (var task in tasks)
      {
        if (task.TaskId == Id) task.TaskComplete = true;
      }
      SaveToFile(tasks);
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
