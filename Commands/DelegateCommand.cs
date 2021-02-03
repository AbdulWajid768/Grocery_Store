using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace ASSIGNMENT2_V1._0.Commands
{
    /// <summary>
    /// Class which inherit ICommand to handle all the Commands In project
    /// </summary>
    class DelegateCommand : ICommand
    {
        //public event EventHandler CanExecuteChanged;
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        private Action<object> _execute;
        private Predicate<object> _canExecute;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="e">Action<object></param>
        /// <param name="c">Predicate<object></param>
        public DelegateCommand(Action<object> e, Predicate<object> c)
        {
            this._execute = e;
            this._canExecute = c;
        }
        /// <summary>
        /// Check whether the command can execute or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return this._canExecute(parameter);
        }

        /// <summary>
        /// Function that will be execute when the command invoke
        /// </summary>
        /// <param name="parameter">object</param>
        public void Execute(object parameter)
        {
            this._execute(parameter);
        }

    }
}