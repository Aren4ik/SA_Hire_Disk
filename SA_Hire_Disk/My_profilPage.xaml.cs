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
    /// Логика взаимодействия для My_profilPage.xaml
    /// </summary>
    public partial class My_profilPage : Page
    {
        Users _users;
        bool _isEdit;
        public My_profilPage()
        {
            InitializeComponent();
        }
        public My_profilPage(Users users)
        {
            InitializeComponent();
            _users = users;
            _isEdit = true;
            Tblogin.Text = users.Login;
            TbPassword.Password = users.Password;
            TbPasswordCopy.Password = users.Password;
            Tbname.Text = users.Name;
            Tbsurname.Text = users.Surname;
            Tbpatr.Text = users.Patronymic;
            Tbmail.Text = users.Email;
            Tbphone.Text = users.Phone;
            
        }

        private void BtEdit_Click(object sender, RoutedEventArgs e)
        {
            if (Tbname.Text != "" && Tbsurname.Text != "" && Tbpatr.Text != "" && Tbphone.Text != "" )
            {
                if (_isEdit == true)
                {
                    _users.Login = Tblogin.Text;
                    _users.Password = TbPassword.Password;
                    _users.Password = TbPasswordCopy.Password;
                    _users.Name = Tbname.Text;
                    _users.Surname = Tbsurname.Text;
                    _users.Patronymic = Tbpatr.Text;
                    _users.Email = Tbmail.Text;
                    _users.Phone = Tbphone.Text;

                    AppData.Context.SaveChanges();
                    MessageBox.Show("Сохранено");
                    AppData.MainFrame.GoBack();
                }

            }
        }

        private void BtClear_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
