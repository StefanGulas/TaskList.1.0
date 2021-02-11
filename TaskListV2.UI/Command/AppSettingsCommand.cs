using System;
using System.IO;
using System.Windows.Input;
using Newtonsoft.Json;
using TaskListV2.UI.ViewModel;

namespace TaskListV2.UI.Command
{
    public class AppSettingsCommand : ICommand
    {
        private int dbSelected;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is CustomFrameViewModel viewModel)
            {
                if (viewModel.JsonSelected) dbSelected = 0;
                else if (viewModel.SQLiteSelected) dbSelected = 1;
                else if (viewModel.SqlServerSelected) dbSelected = 2;
            }
            SaveToFile(dbSelected);
        }
        private const string SettingsFile = "Settings.json";


        private void SaveToFile(int dbSelected)
        {
            string json = JsonConvert.SerializeObject(dbSelected, Formatting.Indented);
            File.WriteAllText(SettingsFile, json);

        }
    }
}

