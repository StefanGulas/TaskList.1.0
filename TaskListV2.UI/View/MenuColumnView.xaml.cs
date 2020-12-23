using System.Windows.Controls;
using Prism.Events;
using TaskListV2.UI.ViewModel;


namespace TaskListV2.UI.View
{
  /// <summary>
  /// Interaktionslogik für MenuColumn.xaml
  /// </summary>
  public partial class MenuColumn : UserControl
  {
    //public MenuColumn(MenuColumnViewModel menuColumnViewModel)
    //{
    //  InitializeComponent();
    //  DataContext = menuColumnViewModel;
    //}
    //private MenuColumnViewModel _menuColumnViewModel;
    public MenuColumn()
    {

      InitializeComponent();
      
    }
    //public MenuColumn(MenuColumnViewModel viewModel)
    //{
    //  InitializeComponent();
    //  _menuColumnViewModel = viewModel;
    //  DataContext = _menuColumnViewModel;
    //  //Loaded += MenuColumnWindow_Loaded;

    //}

    //private void MenuColumnWindow_Loaded(object sender, RoutedEventArgs e)
    //{
    //  _menuColumnViewModel.Load();
    //}

    //private void MenuColumnWindow_Loaded(object sender, RoutedEventArgs e)
    //{
    //  _menuColumnViewModel.Load();
    //}
  }
}
