using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SQLite;
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
      con = new SQLiteConnection("Data Source=TaskListSQLLite.db;Version=3;New=False;Compress=True;");


      //using SqliteConnection con = new SqliteConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);

      con.Open();

      IEnumerable<Task> taskList = new System.Collections.ObjectModel.ObservableCollection<Task>(con.Query<Task>(sqlQuery).ToList());

      con.Close();

      return taskList;

    }

    private object LoadConnectionSting()
    {
      throw new NotImplementedException();
    }

    //public IEnumerable<Task> Connect(string sqlQuery)
    //{
    //  using var con = HelperDataAccess.Conn(connectionString);

    //  con.Open();

    //  IEnumerable<Task> taskList = new System.Collections.ObjectModel.ObservableCollection<Task>(con.Query<Task>(sqlQuery).ToList());

    //  con.Close();

    //  return taskList;
    //}
    public IEnumerable<Task> GetTasks()
    {
      string getTasks = "SELECT * FROM Tasks WHERE TaskComplete = 'false' ORDER BY DueDate ASC";

      return Connect(getTasks);
    }

    public void CreateTask(string name, bool Complete, bool Important, DateTime Due, Reminder Reminder, Category Category, Repetition Repetition)
    {
      throw new NotImplementedException();
    }

    public void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete)
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
