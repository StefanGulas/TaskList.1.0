using System;
using System.Windows.Input;
using TaskListV2.Model;
using TaskListV2.UI.Data;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI.Command
{
  public class CreateTaskCommand : ICommand
  {
    private readonly ITaskListV2DataService _taskDataService;


    public CreateTaskCommand(ITaskListV2DataService taskDataService)
    {
      _taskDataService = taskDataService;
    }


    public event EventHandler CanExecuteChanged;
    public bool CanExecute(object parameter)
    {
      return true;
    }

    public void Execute(object parameter)
    {
      if (parameter is MainViewModel mainViewModel && mainViewModel.Name != null && mainViewModel.Name != "")
      {

        mainViewModel.Tasks.Add(new Task() { TaskName = mainViewModel.Name, TaskComplete = mainViewModel.Complete, IsImportant = mainViewModel.Important, DueDate = mainViewModel.Due, Reminder = mainViewModel.Reminder, TaskCategory = mainViewModel.Category, TaskRepetition = mainViewModel.Repetition });
        _taskDataService.CreateTask(mainViewModel.Name, mainViewModel.Complete, mainViewModel.Important, mainViewModel.Due, mainViewModel.Reminder, mainViewModel.Category, mainViewModel.Repetition);
        mainViewModel.Name = "";
        mainViewModel.Category = 0;
        mainViewModel.RefreshTasks();


      }
    }
  }
}
