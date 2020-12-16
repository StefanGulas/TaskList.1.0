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
  /// Interaktionslogik für CustomFrame.xaml
  /// </summary>
  public partial class CustomFrame : UserControl
  {
    public CustomFrame()
    {
      InitializeComponent();
      DataContext = new CustomFrameViewModel();
    }




    private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      base.OnMouseLeftButtonDown(e);
      
    }

  }
}
