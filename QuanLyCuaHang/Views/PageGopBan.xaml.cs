﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QLCuaHang.Views
{
    /// <summary>
    /// Interaction logic for PageGopBan.xaml
    /// </summary>
    public partial class PageGopBan : Window
    {
        public PageGopBan()
        {
            InitializeComponent();
        }

        private void btnthoat_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
