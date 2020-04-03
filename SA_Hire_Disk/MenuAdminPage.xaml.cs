using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SA_Hire_Disk
{
    /// <summary>
    /// Interaction logic for MenuAdminPage.xaml
    /// </summary>
    public partial class MenuAdminPage : Page
    {
        public MenuAdminPage()
        {
            InitializeComponent();
          
        }

        //private void Btexit_Click(object sender, RoutedEventArgs e)
        //{
           
        //}

        //private void Btmy_profil_Click(object sender, RoutedEventArgs e)
        //{
            
        //}


        //private void Bt_Settings_Click(object sender, RoutedEventArgs e)
        //{
        //    Bt_Settings.ContextMenu.DataContext = Bt_Settings.DataContext;
        //    Bt_Settings.ContextMenu.IsOpen = true;
        //}

        //private void Close_Click(object sender, RoutedEventArgs e)
        //{
        //    DialogResult rsl = System.Windows.Forms.MessageBox.Show("Вы действительно хотите выйти ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //    // если пользователь нажал кнопку да 
        //    if (rsl == DialogResult.Yes)
        //    {
        //        // выходим из приложения 
        //        AppData.MainFrame.Navigate(new AuthorizationPage());
        //    }
        //}

        private void My_Profil_Click(object sender, RoutedEventArgs e)
        {
            //AppData.MainFrame.Navigate(new My_profilPage(AppData.Context.Users.Where(p => p.Login == AppData.username).FirstOrDefault()));
        }

        private void Btproduct_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new Table_Disk_Page());
        }

        private void BtListRentDisk_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtListUser_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new LustUserPage());
        }
    }
}
