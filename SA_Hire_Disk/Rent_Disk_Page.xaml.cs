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
    /// Логика взаимодействия для Rent_Disk_Page.xaml
    /// </summary>
    public partial class Rent_Disk_Page : Page
    {
        Disks _disks;
        Users _users;
        public Rent_Disk_Page()
        {
            InitializeComponent();
        }
        public Rent_Disk_Page(Disks disks)
        {
            InitializeComponent();
            _disks = disks;
            Tbdisk_name.Text = disks.Name;
            var client = AppData.Context.Users.Where(p => p.Login == AppData.username).FirstOrDefault();
            Tbname.Text = client.Name;
            Tbsurname.Text = client.Surname;
            Tbpatr.Text = client.Patronymic;
            Tbmail.Text = client.Email;
            Tbphone.Text = client.Phone;

        }

        private void Btclear_Click(object sender, RoutedEventArgs e)
        {
          

        }

        private void Btadd_Click(object sender, RoutedEventArgs e)
        {
            if (Tbsurname.Text != "" && Tbname.Text != "" && Tbpatr.Text != "" && Tbmail.Text != "" && Tbphone.Text != "" && Tbnumber.Text != "" && Tbnum1.Text != "" && Tbnum2.Text != "" && Tbnum3.Text != "")

            {
                AppData.Context.HireDisks.Add(new HireDisks()
                {
                    DiskName = Tbdisk_name.Text,
                    Surname= Tbsurname.Text,
                    Name = Tbname.Text,
                    Patronymic = Tbpatr.Text,
                    Email = Tbmail.Text,
                    Phone = Tbphone.Text,
                    NumberCode1 = Tbnum1.Text,
                    NumberCode2 = Tbnum2.Text,
                    NumberCode3 = Tbnum3.Text

                });
                AppData.Context.SaveChanges();
                MessageBox.Show("Успешно арендован.");
                AppData.MainFrame.GoBack();

            }
            else
            {
                MessageBox.Show("Не все поля заполнены", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}
