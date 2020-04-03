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
    /// Логика взаимодействия для RegizstrationPage.xaml
    /// </summary>
    public partial class RegizstrationPage : Page
    {
        public RegizstrationPage()
        {
            InitializeComponent();
        }
        private void BtReg_Click(object sender, RoutedEventArgs e)
        {
                if (Tblogin.Text.Length > 0) // проверяем логин
                {

                    if (Tbpassword.Password.Length > 0) // проверяем пароль
                    {

                        if (TbpasswordCopy.Password.Length > 0) // проверяем второй пароль
                        {
                            if (Tbpassword.Password == TbpasswordCopy.Password)
                            {

                                if (Tbpassword.Password.Length >= 6 && Tbpassword.Password.Length <= 12)
                                {

                                    bool tn = false; // Строчная буква
                                    bool mn = false; // Прописная буква
                                    bool symbol = false; // символ
                                    bool number = false; // цифра

                                    for (int i = 0; i < Tbpassword.Password.Length; i++) // перебираем символы
                                    {

                                        if (Tbpassword.Password[i] >= 'A' && Tbpassword.Password[i] <= 'Z') tn = true; // Прописаня буква
                                        if (Tbpassword.Password[i] >= 'a' && Tbpassword.Password[i] <= 'z') mn = true; // Строчная буква
                                        if (Tbpassword.Password[i] >= '0' && Tbpassword.Password[i] <= '9') number = true; // если цифры
                                        if (Tbpassword.Password[i] == '!' || Tbpassword.Password[i] == '?' || Tbpassword.Password[i] == '&' || Tbpassword.Password[i] == '&' || Tbpassword.Password[i] == '@' || Tbpassword.Password[i] == ';') symbol = true; // если символ
                                    }

                                    if (!tn)
                                        MessageBox.Show("Пароль должен содержать прописную букву"); // выводим сообщение
                                    if (!mn)
                                        MessageBox.Show("Пароль должен содержать строчную букву"); // выводим сообщение
                                    else if (!symbol)
                                        MessageBox.Show("Добавьте один из следующих символов: !?&@;"); // выводим сообщение
                                    else if (!number)
                                        MessageBox.Show("Добавьте хотя бы одну цифру"); // выводим сообщение
                                    if (tn && mn && symbol && number) // проверяем соответствие
                                    {

                                        AppData.Context.Users.Add(new Users
                                        {
                                            Login = Tblogin.Text,
                                            Password = TbpasswordCopy.Password,
                                            Role = 2,
                                            Name= Tbname.Text,
                                            Surname= Tbsurname.Text,
                                            Patronymic= Tbpatr.Text,
                                            Phone= Tbphone.Text,
                                            Email= Tbmail.Text

                                        });
                                        AppData.Context.SaveChanges();
                                        MessageBox.Show("Регистрация прошла успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                                        AppData.MainFrame.GoBack();
                                    }
                                }
                                else MessageBox.Show("Пароль слишком короткий, минимум от 6 до 12 символов", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);



                            }
                            else MessageBox.Show("Пароли не совподают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);



                        }
                        else MessageBox.Show("Повторите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);


                    }
                    else MessageBox.Show("Укажите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);


                }
                else MessageBox.Show("Укажите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);


        }
        

        private void BtClear_Click(object sender, RoutedEventArgs e)
        {
            Tblogin.Clear();
            Tbpassword.Clear();
            TbpasswordCopy.Clear();
            Tbname.Clear();
            Tbsurname.Clear();
            Tbpatr.Clear();
            Tblogin.Clear();
            Tbmail.Clear();
            Tbphone.Clear();
        }
    }
    
}
