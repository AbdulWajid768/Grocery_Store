using ASSIGNMENT2_V1._0.Commands;
using ASSIGNMENT2_V1._0.DBHandler;
using ASSIGNMENT2_V1._0.Models;
using ASSIGNMENT2_V1._0.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ASSIGNMENT2_V1._0.ViewModels
{
    /// <summary>
    /// Handle AdminDashBoard View
    /// </summary>
    class AdminDashBoardVM : BaseVM
    {
        public DelegateCommand HandleAddProductBtn { get; set; }
        public DelegateCommand HandleDeleteProductBtn { get; set; }
        public DelegateCommand HandleSeeAllProductsBtn { get; set; }
        public DelegateCommand HandleLogoutBtn { get; set; }


        private string productIDCheck, productNameCheck, priceCheck, quantityCheck, idCheck;

        public AdminDashBoardVM()
        {
            HandleAddProductBtn = new DelegateCommand(AddProduct, CanAddProduct);
            HandleDeleteProductBtn = new DelegateCommand(DeleteProduct, CanDeleteProduct);
            HandleSeeAllProductsBtn = new DelegateCommand(SeeAllProducts, CanSeeAllProducts);
            HandleLogoutBtn = new DelegateCommand(Logout, CanLogout);

        }

        /// <summary>
        /// Add product to Available products
        /// </summary>
        /// <param name="parameter">object</param>
        public void AddProduct(object parameter)
        {
            if (parameter != null)
            {
                object[] data = (object[])parameter;
                if (productDB.AddProductToDB(new Product
                {
                    ID = (data[0] as string),
                    Name = (data[1] as string),
                    Price = (int.Parse(data[2] as string)),
                    Quantity = (int.Parse(data[3] as string))
                }))
                {
                    MessageBox.Show("New Product has been Added Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Sorry, Another product with same Product ID already exist", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Redirect to DisplayAllProducts
        /// </summary>
        /// <param name="parameter">object</param>
        public void SeeAllProducts(object parameter)
        {
            if (parameter != null)
            {
                Window window;
                object[] data = (object[])parameter;
                window = new DisplayAllProducts();
                (data[1] as Window).Close();
                window.Show();
            }

        }
        /// <summary>
        /// Logout the admin
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
        /// Delete product from available products 
        /// </summary>
        /// <param name="parameter">objects</param>
        public void DeleteProduct(object parameter)
        {
            object[] data = (object[])parameter;
            if (productDB.DeleteProductFromDB(data[0] as string))
            {
                MessageBox.Show("Product has been Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Product ID does not exist", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Check whether we can add product or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanAddProduct(object parameter)
        {
            if (parameter != null)
            {
                object[] data = (object[])parameter;
                if (CheckProductID(data[0] as string) & CheckProductName(data[1] as string) & CheckPrice(data[2] as string) & CheckQuantity(data[3] as string))
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
        /// Check whether we can redirect to DisplayAllProducts view or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanSeeAllProducts(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Check whether admin can logout or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanLogout(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Check whether we can delete product or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanDeleteProduct(object parameter)
        {
            if (parameter != null)
            {
                object[] data = (object[])parameter;
                if (CheckID(data[0] as string))
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
        public string IDCheck
        {
            get
            {
                return idCheck;
            }
            set
            {
                idCheck = value;
                OnPropertyChanged("idCheck");
            }
        }
        public string QuantityCheck
        {
            get
            {
                return quantityCheck;
            }
            set
            {
                quantityCheck = value;
                OnPropertyChanged("quantityCheck");
            }
        }
        public string PriceCheck
        {
            get
            {
                return priceCheck;
            }
            set
            {
                priceCheck = value;
                OnPropertyChanged("priceCheck");
            }
        }
        public string ProductNameCheck
        {
            get
            {
                return productNameCheck;
            }
            set
            {
                productNameCheck = value;
                OnPropertyChanged("productNameCheck");
            }
        }
    
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

        /// <summary>
        /// Validate the Product ID to Add
        /// </summary>
        /// <param name="id">string</param>
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
        /// Validate the Product ID to Delete
        /// </summary>
        /// <param name="id">string</param>
        /// <returns></returns>
        private bool CheckID(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                IDCheck = "";
                return false;
            }
            else
            {
                if (id.Length < 3 || id.Length > 10)
                {
                    IDCheck = "Can only be Alphanumeric\nand Min-Length=3\nand Max-Length = 10";
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
                        IDCheck = "Can only be Alphanumeric\nand Min-Length=3\nand Max-Length = 10";
                        return false;

                    }
                }
                IDCheck = "";
                return true;
            }
        }

        /// <summary>
        /// Validate the Price
        /// </summary>
        /// <param name="price">string</param>
        /// <returns></returns>
        private bool CheckPrice(string price)
        {
            if (string.IsNullOrEmpty(price))
            {
                PriceCheck = "";
                return false;
            }
            else
            {
                if (price.Length > 9)
                {
                    PriceCheck = "Can only be Numeric\nand Max 9-digits";
                    return false;
                }
                for (int i = 0; i < price.Length; i++)
                {
                    if ((price[i] >= '0' && price[i] <= '9'))
                    {
                        continue;
                    }
                    else
                    {
                        PriceCheck = "Can only be Numeric\nand Max 9-digits";
                        return false;
                    }
                }
                PriceCheck = "";
                return true;
            }
        }

        /// <summary>
        /// Validate the Quantity
        /// </summary>
        /// <param name="quantity">string</param>
        /// <returns></returns>
        private bool CheckQuantity(string quantity)
        {
            if (string.IsNullOrEmpty(quantity))
            {
                QuantityCheck = "";
                return false;
            }
            else
            {
                if (quantity.Length > 5)
                {
                    QuantityCheck = "Can only be Numeric\nand Max 5-digits";
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
                        QuantityCheck = "Can only be Numeric\nand Max 5-digits";
                        return false;
                    }
                }
                QuantityCheck = "";
                return true;
            }
        }

        /// <summary>
        /// Validate the Product Name
        /// </summary>
        /// <param name="pname">string</param>
        /// <returns></returns>
        private bool CheckProductName(string pname)
        {
            if (string.IsNullOrEmpty(pname))
            {
                ProductNameCheck = "";
                return false;
            }
            else
            {
                if (pname.Length < 3 || pname.Length > 20)
                {
                    ProductNameCheck = "Can only be Alphanumeric\nand Min-Length=3\nand Max-Length = 20";
                    return false;
                }
                for (int i = 0; i < pname.Length; i++)
                {
                    if ((pname[i] >= 'A' && pname[i] <= 'Z') || (pname[i] >= 'a' && pname[i] <= 'z') || (pname[i] >= '0' && pname[i] <= '9'))
                    {
                        continue;
                    }
                    else
                    {
                        ProductNameCheck = "Can only be Alphanumeric\nand Min-Length=3\nand Max-Length = 10";
                        return false;

                    }
                }
                ProductNameCheck = "";
                return true;
            }
        }
    }
}
