﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModelBase.Commands.AsyncCommands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
