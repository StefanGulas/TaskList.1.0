using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TaskListV2.UI.Data;
using TaskListV2.Model;
using TaskListV2.UI.ViewModel;
using Prism.Events;

namespace TaskListV2.UITests.ViewModel
{
  public class MainViewModelTests
  {
    [Fact]
    public void ShouldLoadTasks()
    {
    //private readonly ITaskListV2DataService taskDataService;
    //private readonly IEventAggregator eventAggregator;
    //private readonly ICustomFrameViewModel customFrameViewModel;
    //private readonly IMenuColumnViewModel menuColumnViewModel;

    //Assert.Equals(1,2);
    //var viewModel = new MainViewModel(ITaskListV2DataService taskDataService, Prism.Events.IEventAggregator eventAggregator, IMenuColumnViewModel menuColumnViewModel, ICustomFrameViewModel customFrameViewModel);
    //  string expected = "1,2";
    //  string actual = "1,2";

    //  Assert.Equal(expected, actual);
    }
  }
  public class TaskListV2DataServiceMock : ITaskListV2DataService
  {
    public void CreateTask(string name, bool complete, bool important, DateTime due, Reminder reminder, Category category, Repetition repetition)
    {
      throw new NotImplementedException();
    }

    public void EditTask(int taskId, string name, Category category, DateTime due, Reminder reminder, Repetition repetition, bool important, bool complete)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Task> GetAll()
    {
      yield return new Task { TaskId = 1, TaskName = "Adler füttern", IsImportant = true };
      yield return new Task { TaskId = 2, TaskName = "Buch kaufen", IsImportant = false };
      yield return new Task { TaskId = 3, TaskName = "Tennis spielen", IsImportant = false };
    }

    public IEnumerable<Task> Important()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Task> Planned()
    {
      throw new NotImplementedException();
    }

    public void TaskIsComplete(bool complete, int TaksId)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Task> Today()
    {
      throw new NotImplementedException();
    }
  }
}
