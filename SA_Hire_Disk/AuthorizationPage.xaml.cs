using System;
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

namespace SA_Hire_Disk
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            CheckBx.IsChecked = true;
            Sev();
        }

        private void Btauth_Click(object sender, RoutedEventArgs e)
        {
            if (Tblogin.Text != "" && Tbpassword.Password != "")
            {
                var currenUser = AppData.Context.Users.
                    Where(p => p.Login == Tblogin.Text).FirstOrDefault();

                if (currenUser != null)
                {
                    if (currenUser == AppData.Context.Users.Where(p => p.Login == Tblogin.Text && p.Password == Tbpassword.Password).FirstOrDefault())
                    {
                        switch (currenUser.Role)
                        {
                            case 1:
                                if (CheckBx.IsChecked == true)
                                {
                                    Properties.Settings.Default.Login = Tblogin.Text;
                                    Properties.Settings.Default.Password = Tbpassword.Password.ToString();
                                    Properties.Settings.Default.Save();
                                }
                                if (CheckBx.IsChecked == false)
                                {
                                    Properties.Settings.Default.Login = Tblogin.Text;
                                    Properties.Settings.Default.Password = "";
                                    Properties.Settings.Default.Save();
                                }
                                MessageBox.Show($"Добро пожаловать в систему Администратора, {Tblogin.Text}");
                                    AppData.username = Tblogin.Text.Trim();
                                    AppData.MainFrame.Navigate(new MenuAdminPage());
                                
                                break;
                            case 2:
                                if (CheckBx.IsChecked == true)
                                {
                                    Properties.Settings.Default.Login = Tblogin.Text;
                                    Properties.Settings.Default.Password = Tbpassword.Password.ToString();
                                    Properties.Settings.Default.Save();
                                }
                                if (CheckBx.IsChecked == false)
                                {
                                    Properties.Settings.Default.Login = Tblogin.Text;
                                    Properties.Settings.Default.Password = "";
                                    Properties.Settings.Default.Save();
                                }
                                MessageBox.Show($"Добро пожаловать в систему Клиента, {Tblogin.Text}");
                                AppData.username = Tblogin.Text.Trim();
                                AppData.MainFrame.Navigate(new Table_Disk_Page());
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Пароль указан неверно", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Указанного пользователя не существует.","Ошибка" , MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Все поля обязательны для заполнения", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void Sev()
        {
            if (Properties.Settings.Default.Password != string.Empty)
            {
                Tblogin.Text = Properties.Settings.Default.Login;
                Tbpassword.Password = Properties.Settings.Default.Password;

            }
        }

        private void Btregiz_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new RegizstrationPage());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Sev();
        }
    }
}

