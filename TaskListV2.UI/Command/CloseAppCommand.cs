﻿using System;
using System.Windows;
using System.Windows.Input;

namespace TaskListV2.UI.Command
{
    public class CloseAppCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
