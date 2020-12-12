using System;
using System.Windows;
using System.Windows.Input;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI
{
  public partial class MainWindow : Window
  {
    private readonly MainViewModel _viewModel;

    public MainWindow(MainViewModel viewModel)
    {
      InitializeComponent();
      _viewModel = viewModel;
      DataContext = _viewModel;
      Loaded += MainWindow_Loaded;
      SlideGridAddTask.Width = 0;
      SlideGridEditTask.Width = 0;
      RefreshAddNewTaskFields();

    }

    private void RefreshAddNewTaskFields()
    {
      ToDoTextBox.Text = "";
      TaskCategoryComboBox.SelectedIndex = 0;
      ReminderComboBox.SelectedIndex = 0;
      RepetitionComboBox.SelectedIndex = 0;
      ImportantCheckBoxCreate.IsChecked = false;
      dt_StartDateFrom.SelectedDate = DateTime.Today;
      PopUpOpenButton.IsDefault = true;


    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
      _viewModel.Load();
    }
    private void ButtonFechar_Click(object sender, RoutedEventArgs e)
    {
      Application.Current.Shutdown();
    }


    private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {

    }

    private void PackIcon_ColorChanged(object sender, RoutedPropertyChangedEventArgs<System.Windows.Media.Color> e)
    {

    }

    private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
    {
      base.OnMouseLeftButtonDown(e);
      this.DragMove();
    }

    private void PopUpOpenButton_Click(object sender, RoutedEventArgs e)
    {
      SlideGridAddTask.Width = 1100;
      PopUpOpenButton.Visibility = Visibility.Hidden;
      PopUpOpenButton.IsDefault = false;
      ToDoTextBox.Focus();
      ListViewTaskList.SelectedValue = null;
      CreateTaskButton.IsDefault = true;
      EditTaskButton.IsDefault = false;
      RefreshAddNewTaskFields();
    }

    private void CreateTaskButton_Click(object sender, RoutedEventArgs e)

    {
      SlideGridAddTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      PopUpOpenButton.IsDefault = true;
      CreateTaskButton.IsDefault = false;
      EditTaskButton.IsDefault = false;

    }

    private void SlideGridBackButton_Click(object sender, RoutedEventArgs e)
    {
      CreateTaskButton.IsDefault = false;
      SlideGridAddTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      ListViewTaskList.SelectedValue = null;
      PopUpOpenButton.IsDefault = true;
      EditTaskButton.IsDefault = false;
      SlideGridBackButton.IsDefault = false;
      PopUpOpenButton.Focus();


    }


    private void ListViewTaskList_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      SlideGridEditTask.Width = 1100;
      PopUpOpenButton.Visibility = Visibility.Hidden;
      EditTaskButton.IsDefault = true;
      CreateTaskButton.IsDefault = false;
      PopUpOpenButton.IsDefault = false;

    }

    private void SlideGridEditBackButton_Click(object sender, RoutedEventArgs e)
    {
      SlideGridEditTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      PopUpOpenButton.IsDefault = true;
      ListViewTaskList.SelectedValue = null;
      CreateTaskButton.IsDefault = false;
      EditTaskButton.IsDefault = false;
      PopUpOpenButton.Focus();

    }

    private void EditTaskButton_Click(object sender, RoutedEventArgs e)
    {
      SlideGridEditTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      PopUpOpenButton.IsDefault = true;
      CreateTaskButton.IsDefault = false;
      EditTaskButton.IsDefault = false;
      PopUpOpenButton.Focus();




    }

    private void GrayEditArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      SlideGridEditTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      ListViewTaskList.SelectedValue = null;
      PopUpOpenButton.IsDefault = true;
      CreateTaskButton.IsDefault = false;
      EditTaskButton.IsDefault = false;



    }

    private void GrayCreateArea_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      SlideGridAddTask.Width = 0;
      PopUpOpenButton.Visibility = Visibility.Visible;
      ListViewTaskList.SelectedValue = null;
      PopUpOpenButton.IsDefault = true;
      EditTaskButton.IsDefault = false;
      CreateTaskButton.IsDefault = false;

    }



    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {
      _viewModel.RefreshTasksAfterComplete();

    }

    private void CreateTaskButton_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Return)
      {
        SlideGridAddTask.Width = 0;
        PopUpOpenButton.Visibility = Visibility.Visible;

      }
    }

    private void EditTaskButton_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Return)
      {
        SlideGridEditTask.Width = 0;
        PopUpOpenButton.Visibility = Visibility.Visible;
      }


    }

    private void PopUpOpenButton_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Return)
      {
        SlideGridAddTask.Width = 1100;

        PopUpOpenButton.Visibility = Visibility.Hidden;
        ListViewTaskList.SelectedValue = null;
        ToDoTextBox.Focus();
        CreateTaskButton.IsDefault = true;
        EditTaskButton.IsDefault = false;
        PopUpOpenButton.IsDefault = false;
      }

    }
  }
}
