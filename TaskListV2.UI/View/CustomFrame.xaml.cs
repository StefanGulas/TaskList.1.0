using System.Windows.Controls;
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
      // ToDo: Dependency Injection umsetzen
      DataContext = new CustomFrameViewModel();
    }



  }
}
