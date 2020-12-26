using Autofac;
using TaskListV2.DataAccessNew;
using TaskListV2.UI.Data;
using TaskListV2.UI.ViewModel;
using TaskListV2.UI.View;
using Prism.Events;

namespace TaskListV2.UI.Startup
{
    public class Bootstrapper
    {
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
            builder.RegisterType<FileDataAccess>().As<IDataAccessV2>();
            return builder.Build();
        }
    }
}
