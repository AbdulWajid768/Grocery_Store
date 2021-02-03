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
    /// Handle CustomerReceipt view
    /// </summary>
    class CustomerReceiptVM : BaseVM
    {
        public DelegateCommand HandleLogoutBtn { get; set; }
        private ObservableCollection<Product> purchasedProductList;
        public ObservableCollection<Product> PurchasedProductList
        {
            get { return purchasedProductList; }
            set { purchasedProductList = value; OnPropertyChanged("purchasedProductList"); }
        }
        private string totalAmount;
        public string TotalAmount
        {
            get
            {
                return totalAmount;
            }
            set
            {
                totalAmount = value;
                OnPropertyChanged("totalAmount");
            }
        }
      
        public CustomerReceiptVM(ObservableCollection<Product> products)
        {
            Window window = new CustomerReceipt();
            window.Show();
            window.DataContext = this;
            HandleLogoutBtn = new DelegateCommand(Logout, CanLogout);
            purchasedProductList = products;
            TotalAmount = "Total Amount = " + GetTotalAmount();
        }

        /// <summary>
        /// Calculate the total amount of purchased products
        /// </summary>
        /// <returns></returns>
        private int GetTotalAmount()
        {
            int amount = 0;
            for (int i = 0; i < PurchasedProductList.Count; i++)
            {
                amount += PurchasedProductList[i].Price * PurchasedProductList[i].Quantity;
            }
            return amount;
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
    }
}