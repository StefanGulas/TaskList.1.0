using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Newtonsoft.Json;
using TaskListV2.UI.Command;

namespace TaskListV2.UI.ViewModel
{
  public class CustomFrameViewModel : ViewModelBase, ICustomFrameViewModel
  {
    private bool jsonSelected;
    private bool sQLiteSelected;
    private bool sqlServerSelected;
    private int dbSelected;
    private const string SettingsFile = "Settings.json";


    public bool JsonSelected
    {
      get { return jsonSelected; }
      set
      {
        jsonSelected = value;
        OnPropertyChanged();
      }
    }

    public bool SQLiteSelected
    {
      get { return sQLiteSelected; }
      set
      {
        sQLiteSelected = value;
        OnPropertyChanged();
      }
    }


    public bool SqlServerSelected
    {
      get { return sqlServerSelected; }
      set
      {
        sqlServerSelected = value;
        OnPropertyChanged();
      }
    }



    public ICommand CloseAppCommand { get { return new CloseAppCommand(); } }

    public ICommand AppSettingsCommand { get { return new AppSettingsCommand(); } }


    public CustomFrameViewModel()
    {
      try
      {
      dbSelected = Convert.ToInt32(File.ReadAllText(SettingsFile));

      }
      catch (Exception)
      {
        dbSelected = 0;
      }
      if (dbSelected == 0) JsonSelected = true;
      if (dbSelected == 1) SQLiteSelected = true;
      if (dbSelected == 2) SqlServerSelected = true;
    }
    //  return JsonConvert.DeserializeObject<List<Task>>(json);

  }
}
