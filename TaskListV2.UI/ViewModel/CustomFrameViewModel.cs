using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Newtonsoft.Json;
using TaskListV2.UI.Command;
using Prism.Events;
using TaskListV2.UI.Event;

namespace TaskListV2.UI.ViewModel
{
    public class CustomFrameViewModel : ViewModelBase, ICustomFrameViewModel
    {
        private bool jsonSelected;
        private bool sQLiteSelected;
        private bool sqlServerSelected;
        private int dbSelected;
        private const string SettingsFile = "Settings.json";
        private IEventAggregator _eventAggregator;

        public CustomFrameViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
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

        public bool JsonSelected
        {
            get { return jsonSelected; }
            set
            {
                jsonSelected = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<NewDataBaseConnectionEvent>().Publish("");

            }
        }

        public bool SQLiteSelected
        {
            get { return sQLiteSelected; }
            set
            {
                sQLiteSelected = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<NewDataBaseConnectionEvent>().Publish("");
            }
        }

        public bool SqlServerSelected
        {
            get { return sqlServerSelected; }
            set
            {
                sqlServerSelected = value;
                OnPropertyChanged();
                _eventAggregator.GetEvent<NewDataBaseConnectionEvent>().Publish("");
            }
        }



        public ICommand CloseAppCommand { get { return new CloseAppCommand(); } }

        public ICommand AppSettingsCommand { get { return new AppSettingsCommand(); } }


        //  return JsonConvert.DeserializeObject<List<Task>>(json);

    }
}
