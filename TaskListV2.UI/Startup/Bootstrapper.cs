using Autofac;
using TaskListV2.DataAccessNew;
using TaskListV2.UI.Data;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<TaskListV2DataService>().As<ITaskListV2DataService>();
            builder.RegisterType<DataAccessV2>().As<IDataAccessV2>();
            return builder.Build();
        }
    }
}
