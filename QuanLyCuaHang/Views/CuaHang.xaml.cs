using System.Windows;

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
