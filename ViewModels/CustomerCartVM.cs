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
    /// Handle CustomerCart view
    /// </summary>
    class CustomerCartVM : BaseVM
    {
        public DelegateCommand HandleAddBtn { get; set; }
        public DelegateCommand HandleFinishBtn { get; set; }
        public DelegateCommand HandleLogoutBtn { get; set; }

        private ObservableCollection<Product> availableProductList;
        public ObservableCollection<Product> AvailableProductList
        {
            get { return availableProductList; }
            set { availableProductList = value; OnPropertyChanged("availableProductList"); }
        }
        private ObservableCollection<Product> selectedProductList;
        public ObservableCollection<Product> SelectedProductList
        {
            get { return selectedProductList; }
            set { selectedProductList = value; OnPropertyChanged("selectedProductList"); }
        }

        private string productIDCheck, productQuantityCheck;
        public string ProductIDCheck
        {
            get
            {
                return productIDCheck;
            }
            set
            {
                productIDCheck = value;
                OnPropertyChanged("productIDCheck");
            }
        }

        public string ProductQuantityCheck
        {
            get
            {
                return productQuantityCheck;
            }
            set
            {
                productQuantityCheck = value;
                OnPropertyChanged("productQuantityCheck");
            }
        }
        private List<int> quantities;

        public CustomerCartVM()
        {
            HandleAddBtn = new DelegateCommand(Add, CanAdd);
            HandleFinishBtn = new DelegateCommand(Finish, CanFinish);
            HandleLogoutBtn = new DelegateCommand(Logout, CanLogout);
            availableProductList = productDB.GetAllProductsFromDB();
            selectedProductList = new ObservableCollection<Product>();
            quantities = new List<int>();
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
        /// Update the quantities of purchased products
        /// </summary>
        /// <param name="product">Product</param>
        private void UpdateProductInAvailableProducts(Product product)
        {
            for (int i = 0; i < availableProductList.Count; i++)
            {
                if(availableProductList[i].ID == product.ID)
                {
                    availableProductList[i] = product;
                }
            }
        }
        /// <summary>
        /// Add product to selected list
        /// </summary>
        /// <param name="parameter"></param>
        public void Add(object parameter)
        {
            object[] data = (object[])parameter;
            Product product = productDB.GetProductFromDB(data[0] as string);
            if (product != null)
            {
                if (int.Parse(data[1] as string) <= product.Quantity) 
                {
                    quantities.Add(product.Quantity - int.Parse(data[1] as string));
                    UpdateProductInAvailableProducts(new Product { ID=product.ID,Name=product.Name,Price=product.Price,Quantity= product.Quantity - int.Parse(data[1] as string) });
                    product.Quantity = int.Parse(data[1] as string);
                    selectedProductList.Add(product);
                }
                else
                {
                    MessageBox.Show("Not enough quantity available", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Product ID does not exist", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        /// <summary>
        /// Update product quantities in Database
        /// </summary>
        private void UpdateProductsInDB()
        {
            for (int i = 0; i < selectedProductList.Count; i++)
            {
                productDB.UpdateProductQuantityInDB(selectedProductList[i].ID, quantities[i]);
            }
        }

        /// <summary>
        /// Execute when finish command execute
        /// </summary>
        /// <param name="parameter">object</param>
        public void Finish(object parameter)
        {
            if (parameter != null)
            {
                object[] data = (object[])parameter;
                UpdateProductsInDB();
                _ = new CustomerReceiptVM(SelectedProductList);
                (data[1] as Window).Close();
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
        /// Check whether we can Add product or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanAdd(object parameter)
        {
            if (parameter != null)
            {
                object[] data = (object[])parameter;
                if (CheckProductID(data[0] as string) & CheckQuantity(data[1] as string))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Check whether customer can finish purchase or not 
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanFinish(object parameter)
        {
            if (selectedProductList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Validate product ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool CheckProductID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                ProductIDCheck = "";
                return false;
            }
            else
            {
                if (id.Length < 3 || id.Length > 10)
                {
                    ProductIDCheck = "Can only be Alphanumeric\nand Min-Length=3\nand Max-Length = 10";
                    return false;
                }
                for (int i = 0; i < id.Length; i++)
                {
                    if ((id[i] >= 'A' && id[i] <= 'Z') || (id[i] >= 'a' && id[i] <= 'z') || (id[i] >= '0' && id[i] <= '9'))
                    {
                        continue;
                    }
                    else
                    {
                        ProductIDCheck = "Can only be Alphanumeric\nand Min-Length=3\nand Max-Length = 10";
                        return false;

                    }
                }
                ProductIDCheck = "";
                return true;
            }
        }

        /// <summary>
        /// Validate product quantity
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        private bool CheckQuantity(string quantity)
        {
            if (string.IsNullOrEmpty(quantity))
            {
                ProductQuantityCheck = "";
                return false;
            }
            else
            {
                if (quantity.Length > 3)
                {
                    ProductQuantityCheck = "Can only be Numeric\nand Max 3-digits";
                    return false;
                }
                for (int i = 0; i < quantity.Length; i++)
                {
                    if ((quantity[i] >= '0' && quantity[i] <= '9'))
                    {
                        continue;
                    }
                    else
                    {
                        ProductQuantityCheck = "Can only be Numeric\nand Max 3-digits";
                        return false;
                    }
                }
                ProductQuantityCheck = "";
                return true;
            }
        }
  
    }
}