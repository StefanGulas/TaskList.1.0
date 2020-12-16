using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
    private MainViewModel _mainViewModel;
    public MenuColumn()
    {
        
      InitializeComponent();
    }
    public MenuColumn(MainViewModel mainViewModel)
    {
      InitializeComponent();
      _mainViewModel = mainViewModel;
      DataContext = _mainViewModel;
    }
  }
}
