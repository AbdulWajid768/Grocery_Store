﻿using ASSIGNMENT2_V1._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ASSIGNMENT2_V1._0.Views
{
    /// <summary>
    /// Interaction logic for DisplayAllProducts.xaml
    /// </summary>
    public partial class DisplayAllProducts : Window
    {
        public DisplayAllProducts()
        {
            InitializeComponent();
            this.DataContext = new DisplayAllProductsVM();
        }
    }
}
