using System.Windows;
using System.Windows.Controls;
using TaskListV2.UI;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI.View
{
  /// <summary>
  /// Interaktionslogik für CustomFrame.xaml
  /// </summary>
  public partial class CustomFrame : UserControl
  {
    CustomFrameViewModel _viewModel;
    
    public CustomFrame()
    {
      InitializeComponent();
      //_viewModel = new CustomFrameViewModel();
      //DataContext = _viewModel;
      RadioButtonDeutsch.IsChecked = true;

      RadioButtonStandardMode.IsChecked = true;
      SettingsArea.Height = 0;
    }

    private void SettingsButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
      if (SettingsArea.Height == 0)
      {
        SettingsArea.Height = 600;
      }
      else
      {
        MessageBoxResult result = MessageBox.Show("Vergessen Sie nicht Ihre Änderungen zu speichern", "My App", MessageBoxButton.OK);
            SettingsArea.Height = 0;
        }

        }


        private void SettingsSave_Click(object sender, RoutedEventArgs e)
        {
            SettingsArea.Height = 0;
            
        }
  }


  
}
