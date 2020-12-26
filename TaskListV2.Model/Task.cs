  using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskListV2.Model 
{
  public enum Category
  {
    Aufgaben = 0,
    Privat = 1,
    Arbeit = 2,
    Familie = 3,
    Fitness = 4
  }

  public enum Repetition
  {
    Keine,
    Täglich,
    Wochentage,
    Wöchentlich,
    Monatlich,
    Jährlich
  }

  public enum Reminder
  {
    Keine,
    Eine_Stunde,
    Zwei_Stunden,
    Ein_Tag,
    Zwei_Tage
  }


  public class Task
  {


    public int TaskId { get; set; }

    public string TaskName { get; set; }

    public bool TaskComplete
    {
      get => taskComplete;
      set
      {
        taskComplete = value;
        OnPropertyChanged();

      }
    }

    private bool _isImportant;
    public bool IsImportant
    {
      get { return _isImportant; }
      set { _isImportant = value; }
    }

    public Category TaskCategory { get; set; }

    private DateTime _dueDate;
    private bool taskComplete;

    public DateTime DueDate
    {
      get { return _dueDate.Date; }
      set { _dueDate = value.Date; }
    }

    public Reminder Reminder { get; set; }

    public Repetition TaskRepetition { get; set; }

    public string DueString
    {
      get { return _dueDate.Date.ToString("dd. MMM. yyyy"); }
      set {; }
    }

    public string ImportantStar { get; set; }


    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

  }
}
