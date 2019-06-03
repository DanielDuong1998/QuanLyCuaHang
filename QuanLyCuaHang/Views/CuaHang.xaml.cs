
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using WpfPageTransitions;

namespace QLCuaHang.Views
{
    public partial class CuaHang : Window
    {
 
        public CuaHang()
        {
            InitializeComponent();           
         
        }

        private void Btnphucvu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("click roi nè");
            PageHome phucvu = new PageHome();
            pageTransitionControl.ShowPage(phucvu);

        }
    }
}
