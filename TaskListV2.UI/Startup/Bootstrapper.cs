using System;
using System.IO;
using Autofac;
using Prism.Events;
using TaskListV2.DataAccessNew;
using TaskListV2.UI.Data;
using TaskListV2.UI.View;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI.Startup
{
  public class Bootstrapper
  {
    //ToDo: connect to the database settings 
    //private static int radioButtonDB;

    private const string SettingsFile = "Settings.json";
    private int radioButtonDB;

    public IContainer Bootstrap()
    {
      var builder = new ContainerBuilder();

      builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();


      builder.RegisterType<MainWindow>().AsSelf();
      builder.RegisterType<CustomFrame>().AsSelf();
      builder.RegisterType<MenuColumn>().AsSelf();
      builder.RegisterType<TaskColumn>().AsSelf();
      builder.RegisterType<MainViewModel>().AsSelf();
      builder.RegisterType<MenuColumnViewModel>().As<IMenuColumnViewModel>();
      builder.RegisterType<CustomFrameViewModel>().As<ICustomFrameViewModel>();
      builder.RegisterType<TaskColumnViewModel>().AsSelf();
      builder.RegisterType<TaskListV2DataService>().As<ITaskListV2DataService>();
      try
      {
        radioButtonDB = Int32.Parse(File.ReadAllText(SettingsFile));
      }
      catch (Exception e)
      {
        radioButtonDB = 0;
      }
      //if (radioButtonDB != 0 && radioButtonDB != 1 && radioButtonDB != 2) radioButtonDB = 0;
      if (radioButtonDB == 0)
      {
        builder.RegisterType<FileDataAccess>().As<IDataAccessV2>();
      }
      if (radioButtonDB == 1)
      {
        builder.RegisterType<DataAccessSQLite>().As<IDataAccessV2>();
      }
      if (radioButtonDB == 2)
      {
        builder.RegisterType<DataAccessV2>().As<IDataAccessV2>();
      }
      return builder.Build();
    }
  }
}
