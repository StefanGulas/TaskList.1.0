using System.Windows.Controls;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI.View
{
  /// <summary>
  /// Interaktionslogik für CustomFrame.xaml
  /// </summary>
  public partial class CustomFrame : UserControl
  {
    public CustomFrame(CustomFrameViewModel customFrameViewModel)
    {
      InitializeComponent();
      DataContext = customFrameViewModel;
    }
    public CustomFrame()
    {
      InitializeComponent();
    }



    private void ButtonFechar_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }
  }
}
