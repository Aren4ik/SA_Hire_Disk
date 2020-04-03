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
    /// Логика взаимодействия для LustUserPage.xaml
    /// </summary>
    public partial class LustUserPage : Page
    {
        public LustUserPage()
        {
            InitializeComponent();
            DataGridUser.ItemsSource = AppData.Context.Users.ToList();
            CbType.Items.Add("Нет фильтра");
            CbType.SelectedIndex = 0;
            foreach (Users Type in AppData.Context.Users)
            {
                CbType.Items.Add(Type.Role);
            }
        }
        private void Filter()
        {
            var fil = AppData.Context.Users.ToList();
            if (CbType.SelectedIndex > 0)
            {
                fil = fil.Where(p => p.Role == Int32.Parse( CbType.SelectedItem.ToString())).ToList();
            }

            if (Tbsurname.Text != "")
            {
                fil = fil.Where(p => p.Surname.ToLower().Contains(Tbsurname.Text.ToLower())).ToList();
            }
            DataGridUser.ItemsSource = fil.ToList();
        }
        private void CbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void tbname_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void BtEdit_Click(object sender, RoutedEventArgs e)
        {
            //var rowIndex = DataGridDisk.SelectedIndex;
            //var dataR = (Disks)DataGridDisk.SelectedItems[0];

            //AppData.MainFrame.Navigate(new Add_Disk_Page(AppData.Context.Disks.Where(p => p.Id_Disk == dataR.Id_Disk).FirstOrDefault()));
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.Users.Remove(DataGridUser.SelectedItem as Users);
            AppData.Context.SaveChanges();
            DataGridUser.ItemsSource = AppData.Context.Users.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridUser.ItemsSource = AppData.Context.Users.ToList();
        }
    }
}
