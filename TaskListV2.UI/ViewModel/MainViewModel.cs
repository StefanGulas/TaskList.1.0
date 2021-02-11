using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Prism.Events;
using TaskListV2.Model;
using TaskListV2.UI.Command;
using TaskListV2.UI.Data;
using TaskListV2.UI.Event;

namespace TaskListV2.UI.ViewModel
{
  public class MainViewModel : ViewModelBase
  {
    private readonly ITaskListV2DataService _taskDataService;
    private readonly IEventAggregator _eventAggregator;
    private Task _selectedTask;
    private string _selectedItem;
    private string _name;
    private ObservableCollection<Task> _tasks;
    private Reminder _reminder = 0;
    private Task _myTask;
    private DateTime _due = DateTime.Now;
    private Repetition _repetition = 0;
    private Category _category = 0;
    private bool _complete;
    private bool _important;


    public MainViewModel(ITaskListV2DataService taskDataService, IEventAggregator eventAggregator, IMenuColumnViewModel menuColumnViewModel, ICustomFrameViewModel customFrameViewModel)
    {
      Tasks = new ObservableCollection<Task>();
      MenuColumnViewModel = menuColumnViewModel;
      CustomFrameViewModel = customFrameViewModel;
      NewTasks = new ObservableCollection<Task>();
      _taskDataService = taskDataService;
      _eventAggregator = eventAggregator;
      _eventAggregator.GetEvent<SelectedMenuItemEvent>().Subscribe(OnSelectedMenuItemView);
            _eventAggregator.GetEvent<NewDataBaseConnectionEvent>().Subscribe(OnNewDataBaseConnection);
    }

        private void OnNewDataBaseConnection(string obj)
        {
            Tasks.Clear();
            Load();
        }

        private void OnSelectedMenuItemView(string selectedItem)
    {
      _selectedItem = selectedItem;
      RefreshTasks();
    }

    public void Load()
    {
      var tasks = _taskDataService.GetAll();
      Tasks.Clear();
      tasks = tasks.OrderBy(task => task.DueDate);
      foreach (var task in tasks)
      {
        if (task.DueDate == DateTime.MinValue)
        {
          task.DueDate = DateTime.Parse(task.DueString).Date;
          task.DueString = task.DueDate.ToString("dd. MMM yyyy");
        }
        else
        {
          task.DueString = task.DueDate.ToString("dd. MMM yyyy");
          task.DueDate = DateTime.Parse(task.DueString).Date;
        }
        if (!task.TaskComplete) Tasks.Add(task);
        if (task.IsImportant) task.ImportantStar = "Visible";
        else task.ImportantStar = "Hidden";
      }

    }

    public Task MyTask
    {
      get { return _myTask; }
      set { _myTask = value; }
    }

    public string SelectedItem
    {
      get { return _selectedItem; }
      set
      {
        _selectedItem = value;
        OnPropertyChanged();
        RefreshTasks();
      }
    }
    public void RefreshTasks()
    {
      IEnumerable<Task> tasks = SelectedItem switch
      {
        "Wichtig" => _taskDataService.Important(),
        "Aufgaben" => _taskDataService.GetAll(),
        "Mein Tag" => _taskDataService.Today(),
        "Geplant" => _taskDataService.Planned(),
        _ => _taskDataService.GetAll(),
      };
      Tasks.Clear();
      tasks = tasks.OrderBy(task => task.DueDate);
      foreach (var task in tasks)
      {
        if (task.DueDate == DateTime.MinValue)
        {
          task.DueDate = DateTime.Parse(task.DueString).Date;
          task.DueString = task.DueDate.ToString("dd. MMM yyyy");
        }
        else
        {
          task.DueString = task.DueDate.ToString("dd. MMM yyyy");
          task.DueDate = DateTime.Parse(task.DueString).Date;
        }


        if (!task.TaskComplete) Tasks.Add(task);
        if (task.IsImportant) task.ImportantStar = "Visible";
        else task.ImportantStar = "Hidden";
      }
    }

    public void RefreshTasksAfterComplete()
    {
      foreach (var task in this.Tasks)
      {

        if (task.TaskComplete) _taskDataService.TaskIsComplete(task.TaskComplete, task.TaskId);
      }
      RefreshTasks();
    }

    public ObservableCollection<Task> Tasks
    {
      get { return _tasks; }
      set
      {
        _tasks = value;
        OnPropertyChanged();

      }
    }

    public IMenuColumnViewModel MenuColumnViewModel { get; }
    public ICustomFrameViewModel CustomFrameViewModel { get; }
    public ObservableCollection<Task> NewTasks { get; private set; }

    public Task SelectedTask
    {
      get { return _selectedTask; }
      set
      {
        _selectedTask = value;
        OnPropertyChanged();
        if (_selectedTask != null) LoadTaskEdit();
      }
    }

    void LoadTaskEdit()
    {
      Name = _selectedTask.TaskName;
      Category = _selectedTask.TaskCategory;
      Due = DateTime.Parse(_selectedTask.DueString);
      Reminder = _selectedTask.Reminder;
      Repetition = _selectedTask.TaskRepetition;
      Important = _selectedTask.IsImportant;
      //SlideGridAddTask.Width = 400;
      TaskId = _selectedTask.TaskId;
    }

    public IList<Category> TaskCategories
    {
      get
      {
        return Enum.GetValues(typeof(Category)).Cast<Category>().ToList<Category>();
      }
      set { }
    }
    public int TaskId { get; set; }
    public Category Category
    {
      get { return _category; }
      set
      {
        _category = value;
        OnPropertyChanged();
      }

    }

    public IList<Reminder> ReminderList
    {
      get
      {
        return Enum.GetValues(typeof(Reminder)).Cast<Reminder>().ToList<Reminder>();
      }
      set { }
    }

    public Reminder Reminder
    {
      get { return _reminder; }
      set
      {
        _reminder = value;
        OnPropertyChanged();
      }

    }

    public IList<Repetition> RepetitionList
    {
      get
      {
        return Enum.GetValues(typeof(Repetition)).Cast<Repetition>().ToList<Repetition>();
      }
      set { }
    }

    public Repetition Repetition
    {
      get { return _repetition; }
      set
      {
        _repetition = value;
        OnPropertyChanged();
      }

    }


    public string Name
    {
      get { return _name; }
      set
      {
        _name = value;
        OnPropertyChanged();
      }
    }


    public bool Complete
    {
      get { return _complete; }
      set
      {
        _complete = value;
        OnPropertyChanged();
        //_taskDataService.TaskIsComplete(_complete, TaskId);
      }
    }


    public bool Important
    {
      get { return _important; }
      set
      {
        _important = value;
        OnPropertyChanged();
      }
    }


    public DateTime Due
    {
      get { return _due; }
      set
      {
        _due = value;
        OnPropertyChanged();

      }
    }

    private string _isVisible;

    public string IsVisible
    {
      get { return _isVisible; }
      set { _isVisible = "Hidden"; }
    }

    public ICommand CreateTaskCommand { get { return new CreateTaskCommand(_taskDataService); } }
    public ICommand EditTaskCommand { get { return new EditTaskCommand(_taskDataService); } }
    public ICommand TaskCompleteCommand { get { return new TaskCompleteCommand(_taskDataService); } }
  }



}
