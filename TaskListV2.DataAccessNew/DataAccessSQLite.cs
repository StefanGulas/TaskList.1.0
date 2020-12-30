using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


    public IEnumerable<Task> Connect(string sqlQuery)
    {
      using var con = HelperDataAccess.Conn(connectionString);

      con.Open();

      IEnumerable<Task> taskList = new ObservableCollection<Task>(con.Query<Task>(sqlQuery).ToList());

      con.Close();

      return taskList;
    }
    public IEnumerable<Task> GetTasks()
    {

      string getTasks = "SELECT * FROM tasks Where TaskComplete = 0 ORDER BY DueString DESC";
      return Connect(getTasks);
    }

    public IEnumerable<Task> Important()
    {
      string getTasks = "SELECT * FROM Tasks WHERE IsImportant = 1 AND TaskComplete = 0 ORDER BY DueString";

      return Connect(getTasks);
    }
    public IEnumerable<Task> Today()
    {
      string toDay = DateTime.Now.ToString("yyyy.MM.dd");
      string getTasks = "SELECT * FROM Tasks WHERE DueString = '" + toDay + "'";

      return Connect(getTasks);
    }

    public IEnumerable<Task> Planned()
    {
      DateTime nowTime = DateTime.Now.Date;
      string endTime = nowTime.ToString("yyyy.MM.dd");
      DateTime beforeTime = DateTime.Now.Date.AddDays(7);
      string startTime = beforeTime.ToString("yyyy.MM.dd");
      string getTasks = "SELECT * FROM Tasks WHERE DueString BETWEEN '" + endTime + "' AND '" + startTime + "' ORDER BY DueString";

      return Connect(getTasks);
    }

    public void CreateTask(string name, bool complete, bool important, DateTime due, Reminder reminder, Category category, Repetition repetition)
    {
      string dueString = due.Date.ToString("yyyy.MM.dd");
      using var con = HelperDataAccess.Conn(connectionString);

      con.Open();

      string insertTask = "INSERT INTO Tasks (TaskName, TaskComplete, IsImportant, TaskCategory, DueString, Reminder, TaskRepetition) VALUES" +
    "(@TaskName, @TaskComplete, @Isimportant, @TaskCategory, @DueString, @Reminder, @TaskRepetition)";

      var affectedRows = con.Execute(insertTask, new
      {
        TaskName = name,
        TaskComplete = complete,
        IsImportant = important,
        TaskCategory = category,
        DueString = dueString,
        Reminder = reminder,
        TaskRepetition = repetition
      });

      con.Close();
    }
    public void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete)
    {
      using var con = HelperDataAccess.Conn(connectionString);

      con.Open();

      String dapperChecked = "UPDATE Tasks SET TaskName = '" + name + "', TaskCategory = '" + (int)category + "', DueString = '" + due.Date.ToString("yyyy.MM.dd") + "', Reminder = '" + (int)reminder + "', TaskRepetition = '" + (int)repetition + "', IsImportant = '" + Convert.ToInt32(important).ToString() + "' WHERE TaskId = '" + taskId + "'";
      var affectedRows = con.Execute(dapperChecked, new { TaskName = name, IsImportant = important, TaskCategory = (int)category, DueString = due, Reminder = (int)reminder, TaskRepetition = (int)repetition });

    }
    public void TaskIsComplete(bool complete, int taskId)
    {
      using var con = HelperDataAccess.Conn(connectionString);

      con.Open();
      String dapperChecked = "UPDATE Tasks SET TaskComplete = '" + complete + "' WHERE TaskId = '" + taskId + "'";

      var affectedRows = con.Execute(dapperChecked, new { TaskComplete = "complete" });
    }
  }
}
