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
      RadioButtonStandardMode.IsChecked = true;
      SettingsArea.Height = 0;
    }

    private void SettingsButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      if (SettingsArea.Height == 0)
      {
        SettingsArea.Height = 600;
      }
      else SettingsArea.Height = 0;
    }

    private void EditTaskButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {

    }
  }
}
