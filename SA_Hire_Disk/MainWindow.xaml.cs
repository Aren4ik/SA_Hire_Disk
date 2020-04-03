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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            AppData.MainFrame = MainFrame;
            AppData.MainFrame.Navigate(new AuthorizationPage());
        }

        private void Btback_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            if (Title == "AuthorizationPage" )
            {
                Btback.Visibility = Visibility.Collapsed;
                Bt_Settings.Visibility = Visibility.Collapsed;
                TittleName.Visibility = Visibility.Collapsed;
                
            }
            else
            {
                Btback.Visibility = Visibility.Visible;
                Bt_Settings.Visibility = Visibility.Visible;
                TittleName.Visibility = Visibility.Visible;
                TittleName.Text = "Ваш аккаунт, " + AppData.username;
            }
            
        }

        private void Bt_Settings_Click(object sender, RoutedEventArgs e)
        {
            Bt_Settings.ContextMenu.DataContext = Bt_Settings.DataContext;
            Bt_Settings.ContextMenu.IsOpen = true;
        }

    

        private void My_Profil_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new My_profilPage(AppData.Context.Users.Where(p => p.Login == AppData.username).FirstOrDefault()));
        }

        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.DialogResult rsl = System.Windows.Forms.MessageBox.Show("Вы действительно хотите выйти ?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
          
            // если пользователь нажал кнопку да 
            if (rsl == System.Windows.Forms.DialogResult.Yes)
            {
                // выходим из приложения 
                AppData.MainFrame.Navigate(new AuthorizationPage());
            }
            
        }
    }
}
