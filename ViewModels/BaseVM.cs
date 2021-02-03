using ASSIGNMENT2_V1._0.DBHandler;
using System.ComponentModel;
using System.Windows;

namespace ASSIGNMENT2_V1._0.ViewModels
{

    /// <summary>
    /// Base class for View Models
    /// </summary>
    class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected ProductDBHandler productDB;
        protected CustomerDBHandler customerDB;
        public BaseVM()
        {
            productDB = new ProductDBHandler();
            customerDB = new CustomerDBHandler();
        }

        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
