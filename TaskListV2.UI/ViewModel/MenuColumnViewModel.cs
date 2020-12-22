using System.Collections.Generic;
using TaskListV2.UI.Data;

namespace TaskListV2.UI.ViewModel
{
  public class MenuColumnViewModel : ViewModelBase
  {
    private string _selectedItem;


    public MenuColumnViewModel()
    {
      MenuItems = TaskListV2DataService.LeftMenuItems;
      //var mainViewModel = new MainViewModel(ITaskListV2DataService taskDataService);
    }

    public IEnumerable<string> MenuItems { get; set; }

    public string SelectedItem
    {
      get { return _selectedItem; }
      set
      {
        _selectedItem = value;
        OnPropertyChanged();
        //RefreshTasks();
      }
    }
  }
}
