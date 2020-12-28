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
    private static int radioButtonDB = 1;

    
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
      if (radioButtonDB == 0)
      {
        builder.RegisterType<FileDataAccess>().As<IDataAccessV2>();
      }
      if(radioButtonDB == 1)
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
