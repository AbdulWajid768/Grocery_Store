using ASSIGNMENT2_V1._0.Commands;
using ASSIGNMENT2_V1._0.Models;
using ASSIGNMENT2_V1._0.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace ASSIGNMENT2_V1._0.ViewModels
{
    /// <summary>
    /// Handle DisplayAllProducts view
    /// </summary>
    class DisplayAllProductsVM : BaseVM
    {

        public DelegateCommand HandleBackBtn { get; set; }
        public DelegateCommand HandleLogoutBtn { get; set; }

        private ObservableCollection<Product> productList;
        public ObservableCollection<Product> ProductList
        {
            get { return productList; }
            set { productList = value; OnPropertyChanged("productList"); }
        }
    public DisplayAllProductsVM()
        {
            HandleBackBtn = new DelegateCommand(GoBack, CanGoBack);
            HandleLogoutBtn = new DelegateCommand(Logout, CanLogout);
            ProductList = productDB.GetAllProductsFromDB();
        }

        /// <summary>
        /// Execute when logout command invoke
        /// </summary>
        /// <param name="parameter">object</param> 
        public void Logout(object parameter)
        {
            if (parameter != null)
            {
                Window window;
                object[] data = (object[])parameter;
                window = new MainWindow();
                (data[1] as Window).Close();
                window.Show();
            }
        }


        /// <summary>
        /// Check whether we can logout or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanLogout(object parameter)
        {
            return true;
        }
        /// <summary>
        /// Execute when go back command invoke
        /// </summary>
        /// <param name="parameter">object</param> 
        public void GoBack(object parameter)
        {
            if (parameter != null)
            {
                Window window;
                object[] data = (object[])parameter;
                window = new AdminDashBoard();
                (data[1] as Window).Close();
                window.Show();
            }
        }

        /// <summary>
        /// Check whether we can go back or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanGoBack(object parameter)
        {
            return true;
        }

    }
}
