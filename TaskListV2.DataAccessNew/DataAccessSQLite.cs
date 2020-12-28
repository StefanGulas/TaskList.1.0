using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using TaskListV2.Model;

namespace TaskListV2.DataAccessNew
{
  public class DataAccessSQLite : IDataAccessV2
  {

    private SQLiteConnection con;

    private DataTable DT = new DataTable();
    string connectionString = "ConnectionToSQLite";


    //  IEnumerable<Task> taskList = new System.Collections.ObjectModel.ObservableCollection<Task>(con.Query<Task>(sqlQuery).ToList());

    //  con.Close();

    //  return taskList;

    //}


    public IEnumerable<Task> Connect(string sqlQuery)
    {
      using var con = HelperDataAccess.Conn(connectionString);

      con.Open();

      IEnumerable<Task> taskList = new System.Collections.ObjectModel.ObservableCollection<Task>(con.Query<Task>(sqlQuery).ToList());

      con.Close();

      return taskList;
    }
    public IEnumerable<Task> GetTasks()
    {
      //string getTasks = "SELECT * FROM Tasks WHERE TaskComplete = 'false' ORDER BY DueDate ASC";
      string getTasks = "SELECT TaskId, TaskName, Reminder, TaskRepetition,  cast(IsImportant as Boolean) FROM tasks ";
      return Connect(getTasks);
    } 



    public IEnumerable<Task> Important()
    {
      string getTasks = "SELECT * FROM Tasks WHERE IsImportant = 'true' ORDER BY DueDate ASC";

      return Connect(getTasks);
    }
    public IEnumerable<Task> Today()
    {
      string getTasks = "SELECT * FROM Tasks WHERE DueDate = CAST(CURRENT_TIMESTAMP AS DATE)";

      return Connect(getTasks);
    }

    public IEnumerable<Task> Planned()
    {
      DateTime nowTime = DateTime.Now.Date;
      string endTime = nowTime.ToString("dd.MM.yyyy");
      DateTime beforeTime = DateTime.Now.Date.AddDays(7);
      string startTime = beforeTime.ToString("dd.MM.yyyy");
      string getTasks = "SELECT * FROM Tasks WHERE DueDate BETWEEN '" + endTime + "' AND '" + startTime + "' ORDER BY DueDate ASC";

      return Connect(getTasks);
    }

    public void CreateTask(string name, bool Complete, bool Important, DateTime Due, Reminder Reminder, Category Category, Repetition Repetition, String DueString)
    {
      using var con = HelperDataAccess.Conn(connectionString);

      con.Open();

      string insertTask = "INSERT INTO Tasks (TaskName, TaskComplete, IsImportant, TaskCategory, DueString, Reminder, TaskRepetition) VALUES" +
          "(@TaskName, @TaskComplete, @IsImportant, @TaskCategory, @DueDate, @Reminder, @TaskRepetition)";

      var affectedRows = con.Execute(insertTask, new { TaskName = name, TaskComplete = Complete, IsImportant = Important, TaskCategory = Category, DueDate = DueString, Reminder, TaskRepetition = Repetition });

      con.Close();
    }
    public void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete)
    {
      using var con = HelperDataAccess.Conn(connectionString);

      con.Open();

      String dapperChecked = "UPDATE Tasks SET TaskName = '" + name + "', TaskCategory = '" + (int)category + "', DueDate = '" + due + "', Reminder = '" + (int)reminder + "', TaskRepetition = '" + (int)repetition + "', IsImportant = '" + Convert.ToInt32(important) + "' WHERE TaskId = '" + taskId + "'";

      var affectedRows = con.Execute(dapperChecked, new { TaskName = name, IsImportant = Convert.ToInt32(important), TaskCategory = (int)category, DueDate = due, Reminder = (int)reminder, TaskRepetition = (int)repetition });

    }
    public void TaskIsComplete(bool complete, int taskId)
    {
      using var con = HelperDataAccess.Conn(connectionString);

      con.Open();
      String dapperChecked = "UPDATE Tasks SET TaskComplete = '" + complete + "' WHERE TaskId = '" + taskId + "'";

      var affectedRows = con.Execute(dapperChecked, new { TaskComplete = complete });
    }
  }
}
