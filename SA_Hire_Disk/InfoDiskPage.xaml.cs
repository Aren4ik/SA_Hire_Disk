using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для InfoDiskPage.xaml
    /// </summary>
    public partial class InfoDiskPage : Page
    {
        string encodedFile;
        public InfoDiskPage()
        {
            InitializeComponent();
        }
        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;

            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        public InfoDiskPage(Disks disks)
        {
            InitializeComponent();
            Tbname.Text = disks.Name;
            Tbtype.Text = disks.Type;
            Tbprice.Text = disks.Price.ToString() + " рублей";
            TbPublisher.Text = disks.Publisher;
            TbDeveloper.Text = disks.Developer;
            TbCateqory.Text = disks.Category;
            Tblanquaqe_Interface.Text = disks.Language_Interface;
            Tblanquaqe_voice.Text = disks.Language_Voice;
            TbYear_manufacture.Text = disks.Year_Manufacture;
            TbInfo.Text = disks.Info;
            encodedFile = disks.Image;
            try
            {
                ImageProduct.Source = LoadImage(Convert.FromBase64String(encodedFile));
            }
            catch
            {

            }
        }

        private void BtRent_Click(object sender, RoutedEventArgs e)
        {
            //AppData.disk = Tbname.Text;
            //AppData.MainFrame.Navigate(new Rent_Disk_Page());
            AppData.MainFrame.Navigate(new Rent_Disk_Page(AppData.Context.Disks.Where(p => p.Name==AppData.disk).FirstOrDefault()));

        }
    }
}
