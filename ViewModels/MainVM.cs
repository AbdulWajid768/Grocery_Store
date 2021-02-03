using ASSIGNMENT2_V1._0.Commands;
using ASSIGNMENT2_V1._0.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace ASSIGNMENT2_V1._0.ViewModels
{
    /// <summary>
    /// Handle MainWindow view
    /// </summary>
    class MainVM: BaseVM
    {

        public ICommand SelectedType { get; set; }

        public MainVM()
        {
            SelectedType = new DelegateCommand(Execute, CanExecute);
        }
        /// <summary>
        /// Check whether we can go forward or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Redirect to Admin/Customer login/signup
        /// </summary>
        /// <param name="parameter">object</param> 
        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                Window window;
                object[] data = (object[])parameter;
                if ((data[0] as string).Equals("Admin"))
                {
                    window = new AdminLoginSignup();
                }
                else
                {
                    window = new CustomerLoginSignup();
                }
                (data[1] as Window).Close();
                window.Show();
            }
        }
    }
}
