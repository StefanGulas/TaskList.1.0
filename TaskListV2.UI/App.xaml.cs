using System.Windows;
using Autofac;
using TaskListV2.UI.Startup;

namespace TaskListV2.UI
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var bootstrapper = new Bootstrapper();
            var container = bootstrapper.Bootstrap();

            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}
