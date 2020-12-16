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
    }

    private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      base.OnMouseLeftButtonDown(e);
      
    }

    private void ButtonFechar_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
