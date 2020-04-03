using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using Path = System.IO.Path;

namespace SA_Hire_Disk
{
    /// <summary>
    /// Логика взаимодействия для Add_Disk_Page.xaml
    /// </summary>
    public partial class Add_Disk_Page : Page
    {
        string encodedFile;
        Disks _disks;
        bool _isEdit;
                    
        public Add_Disk_Page()
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
        public Add_Disk_Page(Disks disks)
        {
            InitializeComponent();
            _disks = disks;
            _isEdit = true;
            TbTittle.Text =  "Редактирование диска";
            Btadd.Content = "Редактировать";
            Tbname.Text = disks.Name;
            Tbtype.Text = disks.Type;
            Tbprice.Text = disks.Price.ToString();
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


        private void Btadd_Click(object sender, RoutedEventArgs e)
        {
            if(Tbname.Text != "" && Tbprice.Text != "" && Tbtype.Text != "" && TbPublisher.Text != "" && TbDeveloper.Text != "" && TbCateqory.Text != "" && Tblanquaqe_Interface.Text != "" && Tblanquaqe_voice.Text != "" && TbYear_manufacture.Text != "" && TbInfo.Text != "")
            {
                if (_isEdit == true)
                {
                    _disks.Name = Tbname.Text;
                    _disks.Type = Tbtype.Text;
                    _disks.Price = Convert.ToDecimal(Tbprice.Text);
                    _disks.Publisher = TbPublisher.Text;
                    _disks.Developer = TbDeveloper.Text;
                    _disks.Category = TbCateqory.Text;
                    _disks.Language_Interface = Tblanquaqe_Interface.Text;
                    _disks.Language_Voice = Tblanquaqe_voice.Text;
                    _disks.Year_Manufacture = TbYear_manufacture.Text;
                    _disks.Info = TbInfo.Text;
                    _disks.Image = encodedFile;

                    AppData.Context.SaveChanges();
                    System.Windows.MessageBox.Show("Успешно сохранен");
                    AppData.MainFrame.GoBack();
                }
                else
                {
                    AppData.Context.Disks.Add(new Disks()
                    {
                        Name = Tbname.Text,
                        Type = Tbtype.Text,
                        Price = Convert.ToDecimal(Tbprice.Text),
                        Publisher = TbPublisher.Text,
                        Developer = TbDeveloper.Text,
                        Category = TbCateqory.Text,
                        Language_Interface = Tblanquaqe_Interface.Text,
                        Language_Voice = Tblanquaqe_voice.Text,
                        Year_Manufacture = TbYear_manufacture.Text,
                        Info = TbInfo.Text,
                        Image = encodedFile,

                    });
                     AppData.Context.SaveChanges();
                    System.Windows.MessageBox.Show("Успешно добавлено");
                    AppData.MainFrame.GoBack();
                }
                   
            }
            else
            {
                System.Windows.MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Btclear_Click(object sender, RoutedEventArgs e)
        {
            Tbname.Clear();
            Tbprice.Clear();
            Tbtype.Clear();
        }

        private void BtAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

           
            openFileDialog1.Filter = "Image files (*.BMP, *.JPG, *.PNG)|*.bmp;*.jpg; *.png;";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                var fB = File.ReadAllBytes(path);
                 encodedFile= Convert.ToBase64String(fB);
                ImageProduct.Source = new BitmapImage(new Uri(path));
            }
        }
    }
}
