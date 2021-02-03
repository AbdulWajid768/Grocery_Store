using ASSIGNMENT2_V1._0.Commands;
using ASSIGNMENT2_V1._0.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ASSIGNMENT2_V1._0.ViewModels
{
    /// <summary>
    /// Handle AdminLoginSignup view
    /// </summary>
    class AdminLoginSignupVM : BaseVM
    {
        public DelegateCommand HandleBackBtn { get; set; }
        public DelegateCommand HandleLoginBtn { get; set; }
        private string loginUnameCheck, loginPswdCheck;
        public string LoginUnameCheck
        {
            get
            {
                return loginUnameCheck;
            }
            set
            {
                loginUnameCheck = value;
                OnPropertyChanged("loginUnameCheck");
            }
        }
       
        public string LoginPswdCheck
        {
            get
            {
                return loginPswdCheck;
            }
            set
            {
                loginPswdCheck = value;
                OnPropertyChanged("loginPswdCheck");
            }
        }
     
       

        public AdminLoginSignupVM()
        {
            HandleLoginBtn = new DelegateCommand(Login, CanLogin);
            HandleBackBtn = new DelegateCommand(GoBack, CanGoBack);
        }


        /// <summary>
        /// Validate the Username for Login
        /// </summary>
        /// <param name="uname">string</param>
        /// <returns></returns>
        private bool CheckLoginUname(string uname)
        {
            if (string.IsNullOrEmpty(uname))
            {
                LoginUnameCheck = "";
                return false;
            }
            else
            {
                if (uname.Length < 5 || uname.Length > 8)
                {
                    LoginUnameCheck = "Can only be Alphanumeric\nand Min-Length=5\nand Max-Length = 8";
                    return false;
                }
                for (int i = 0; i < uname.Length; i++)
                {
                    if ((uname[i] >= 'A' && uname[i] <= 'Z') || (uname[i] >= 'a' && uname[i] <= 'z') || (uname[i] >= '0' && uname[i] <= '9'))
                    {
                        continue;
                    }
                    else
                    {
                        LoginUnameCheck = "Can only be Alphanumeric\nand Min-Length=5\nand Max-Length = 8";
                        return false;

                    }
                }
                LoginUnameCheck = "";
                return true;
            }
        }

        /// <summary>
        /// Validate the Password for Login
        /// </summary>
        /// <param name="pswd">string</param>
        /// <returns></returns>
        private bool CheckLoginPswd(string pswd)
        {
            if (string.IsNullOrEmpty(pswd))
            {
                LoginPswdCheck = "";
                return false;
            }
            else
            {
                if (pswd.Length < 6 || pswd.Length > 10)
                {
                    LoginPswdCheck = "Can only be Alphanumeric\nand Min-Length=6\nand Max-Length = 10";
                    return false;
                }
                for (int i = 0; i < pswd.Length; i++)
                {
                    if ((pswd[i] >= 'A' && pswd[i] <= 'Z') || (pswd[i] >= 'a' && pswd[i] <= 'z') || (pswd[i] >= '0' && pswd[i] <= '9'))
                    {
                        continue;
                    }
                    else
                    {
                        LoginPswdCheck = "Can only be Alphanumeric\nand Min-Length=6\nand Max-Length = 10";
                        return false;

                    }
                }
                LoginPswdCheck = "";
                return true;
            }
        }

        /// <summary>
        /// Check whether we can login or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanLogin(object parameters)
        {
            if (parameters != null)
            {
                object[] data = (object[])parameters;
                if(CheckLoginUname(data[0] as string) & CheckLoginPswd(data[1] as string))
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
        /// Execute when login command execute
        /// </summary>
        /// <param name="parameter">object</param>
        public void Login(object parameter)
        {
            if (parameter != null)
            {
                object[] data = (object[])parameter;
                if((data[0] as string).Equals("admin123") && (data[1] as string).Equals("123456"))
                {
                    Window window;
                    window = new AdminDashBoard();
                    MessageBox.Show("Now, you will have access to Admin's Dashboard", "Login Successful",MessageBoxButton.OK,MessageBoxImage.Information);
                    (data[2] as Window).Close();
                    window.Show();
                }
                else
                {
                    MessageBox.Show("Wrong UserName or Password", "Login Unsuccessful", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

        /// <summary>
        /// Execute when go back command execute
        /// </summary>
        /// <param name="parameter">object</param>
        public void GoBack(object parameter)
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
        /// Check whether we can go to previous page or not
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public bool CanGoBack(object parameter)
        {
            return true;
        }
    }
}
