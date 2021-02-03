using ASSIGNMENT2_V1._0.Commands;
using ASSIGNMENT2_V1._0.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ASSIGNMENT2_V1._0.ViewModels
{
    /// <summary>
    /// Handle CustomerLoginSignup view
    /// </summary>
    class CustomerLoginSignupVM : BaseVM
    {

        public DelegateCommand HandleBackBtn { get; set; }
        public DelegateCommand HandleLoginBtn { get; set; }
        public DelegateCommand HandleSignupBtn { get; set; }
        private string loginUnameCheck, loginPswdCheck, signupUnameCheck, signupPswdCheck, signupPnoCheck;
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
        public string SignupUnameCheck
        {
            get
            {
                return signupUnameCheck;
            }
            set
            {
                signupUnameCheck = value;
                OnPropertyChanged("signupUnameCheck");
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
        public string SignupPswdCheck
        {
            get
            {
                return signupPswdCheck;
            }
            set
            {
                signupPswdCheck = value;
                OnPropertyChanged("signupPswdCheck");
            }
        }

        public string SignupPnoCheck
        {
            get
            {
                return signupPnoCheck;
            }
            set
            {
                signupPnoCheck = value;
                OnPropertyChanged("signupPnoCheck");
            }
        }

        public CustomerLoginSignupVM()
        {
            HandleLoginBtn = new DelegateCommand(Login, CanLogin);
            HandleSignupBtn = new DelegateCommand(Signup, CanSignup);
            HandleBackBtn = new DelegateCommand(GoBack, CanGoBack);
        }

        /// <summary>
        /// Validate username for signup
        /// </summary>
        /// <param name="uname"></param>
        /// <returns></returns>
        private bool CheckSignupUname(string uname)
        {
            if (string.IsNullOrEmpty(uname))
            {
                SignupUnameCheck = "";
                return false;
            }
            else
            {
                if (uname.Length < 5 || uname.Length > 8)
                {
                    SignupUnameCheck = "Can only be Alphanumeric\nand Min-Length=5\nand Max-Length = 8";
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
                        SignupUnameCheck = "Can only be Alphanumeric\nand Min-Length=5\nand Max-Length = 8";
                        return false;

                    }
                }
                SignupUnameCheck = "";
                return true;
            }
        }

        /// <summary>
        /// Validate username for login
        /// </summary>
        /// <param name="uname"></param>
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
        /// Validate password for signup
        /// </summary>
        /// <param name="pswd"></param>
        /// <returns></returns>
        private bool CheckSignupPswd(string pswd)
        {
            if (string.IsNullOrEmpty(pswd))
            {
                SignupPswdCheck = "";
                return false;
            }
            else
            {
                if (pswd.Length < 6 || pswd.Length > 10)
                {
                    SignupPswdCheck = "Can only be Alphanumeric\nand Min-Length=6\nand Max-Length = 10";
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
                        SignupPswdCheck = "Can only be Alphanumeric\nand Min-Length=6\nand Max-Length = 10";
                        return false;

                    }
                }
                SignupPswdCheck = "";
                return true;
            }
        }

        /// <summary>
        /// Validate password for login
        /// </summary>
        /// <param name="pswd"></param>
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
        /// Validate phone number for signup
        /// </summary>
        /// <param name="pno"></param>
        /// <returns></returns>
        private bool CheckSignupPno(string pno)
        {
            if (string.IsNullOrEmpty(pno))
            {
                SignupPnoCheck = "";
                return false;
            }
            else
            {
                if (pno.Length != 11)
                {
                    SignupPnoCheck = "Can only be Numeric\nand must be of 11-digits";
                    return false;
                }
                for (int i = 0; i < pno.Length; i++)
                {
                    if ((pno[i] >= '0' && pno[i] <= '9'))
                    {
                        continue;
                    }
                    else
                    {
                        SignupPnoCheck = "Can only be Numeric\nand must be of 11-digits";
                        return false;

                    }
                }
                SignupPnoCheck = "";
                return true;
            }
        }


        /// <summary>
        /// Check whether we can signup or not
        /// </summary>
        /// <param name="parameters">object</param>
        /// <returns></returns>
        public bool CanSignup(object parameters)
        {
            if (parameters != null)
            {
                object[] data = (object[])parameters;
                if (CheckSignupUname(data[0] as string) & CheckSignupPswd(data[1] as string) & CheckSignupPno(data[2] as string))
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
        /// Check whether we can login or not
        /// </summary>
        /// <param name="parameters">object</param>
        /// <returns></returns>
        public bool CanLogin(object parameters)
        {
            if (parameters != null)
            {
                object[] data = (object[])parameters;
                if (CheckLoginUname(data[0] as string) & CheckLoginPswd(data[1] as string))
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
        /// Execute when login command invoke
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public void Login(object parameter)
        {
            if (parameter != null)
            {
                object[] data = (object[])parameter;
                if (customerDB.IsCustomerExist(data[0] as string, data[1] as string))
                {
                    Window window;
                    window = new CustomerCart();
                    MessageBox.Show("Now, you will redirect to Customer's Cart", "Login Successful", MessageBoxButton.OK, MessageBoxImage.Information);
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
        /// Execute when signup command invoke
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
        public void Signup(object parameter)
        {

            if (parameter != null)
            {
                object[] data = (object[])parameter;
                if (customerDB.IsCustomerUsernameExist(data[0] as string))
                {
                    MessageBox.Show("Sorry, there is another Customer with same UserName\nTry another one", "Signup Unsuccessful", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show("Now, you can login", "Signup Successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    customerDB.AddCustomerToDB(data[0] as string, data[1] as string, data[2] as string);
                }
            }
        }

        /// <summary>
        /// Execute when go back command invoke
        /// </summary>
        /// <param name="parameter">object</param>
        /// <returns></returns>
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