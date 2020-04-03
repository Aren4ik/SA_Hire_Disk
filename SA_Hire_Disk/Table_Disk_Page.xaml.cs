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
    /// Логика взаимодействия для Table_Disk_Page.xaml
    /// </summary>
    public partial class Table_Disk_Page : Page
    {

        public Table_Disk_Page()
        {
            InitializeComponent();
            DataGridDisk.ItemsSource = AppData.Context.Disks.ToList();
            CbType.Items.Add("Нет фильтра");
            CbType.SelectedIndex = 0;
            foreach (Disks Type in AppData.Context.Disks)
            {
                CbType.Items.Add(Type.Type);
            }
        }
        private void Btclear_Click(object sender, RoutedEventArgs e)
        {
            CbType.SelectedIndex = -1;
        }
        private void Filter()
        {
            var fil = AppData.Context.Disks.ToList();
            if (CbType.SelectedIndex > 0)
            {
                fil = fil.Where(p => p.Type == CbType.SelectedItem.ToString()).ToList();
            }

            if (tbname.Text != "")
            {
                fil = fil.Where(p => p.Name.ToLower().Contains(tbname.Text.ToLower())).ToList();
            }
            DataGridDisk.ItemsSource = fil.ToList();
        }

        private void RentDisk_Click(object sender, RoutedEventArgs e)
        {
            var rowIndex = DataGridDisk.SelectedIndex;
            var dataR = (Disks)DataGridDisk.SelectedItems[0];

            AppData.MainFrame.Navigate(new Rent_Disk_Page(AppData.Context.Disks.Where(p => p.Id_Disk == dataR.Id_Disk).FirstOrDefault()));
        }

        private void Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Tbname_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void BtAddDisk_Click(object sender, RoutedEventArgs e)
        {
            AppData.MainFrame.Navigate(new Add_Disk_Page());
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DataGridDisk.ItemsSource = AppData.Context.Disks.ToList();
        }

        private void BtEdit_Click(object sender, RoutedEventArgs e)
        {
            var rowIndex = DataGridDisk.SelectedIndex;
            var dataR = (Disks)DataGridDisk.SelectedItems[0];

            AppData.MainFrame.Navigate(new Add_Disk_Page(AppData.Context.Disks.Where(p => p.Id_Disk == dataR.Id_Disk).FirstOrDefault()));
        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            AppData.Context.Disks.Remove(DataGridDisk.SelectedItem as Disks);
            AppData.Context.SaveChanges();
            DataGridDisk.ItemsSource = AppData.Context.Disks.ToList();
        }

        private void BtSelect_Click(object sender, RoutedEventArgs e)
        {
            var rowIndex = DataGridDisk.SelectedIndex;
            var dataR = (Disks)DataGridDisk.SelectedItems[0];

            AppData.MainFrame.Navigate(new InfoDiskPage(AppData.Context.Disks.Where(p => p.Id_Disk == dataR.Id_Disk).FirstOrDefault()));
        }
    }
}
