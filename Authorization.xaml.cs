using System;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;


namespace Cursed
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Authorization()
        {
            InitializeComponent();
        }
        private void Enter(object sender, RoutedEventArgs e)
        {
            if (Login.Text == null || TextPassword.Text == null)
            { Console.WriteLine("Данные не были введены"); }
            else
            {
                
                var crypt = System.Security.Cryptography.SHA256.Create();
                var notfinal = crypt.ComputeHash(Encoding.UTF8.GetBytes(Password.Password));
                var final = Convert.ToBase64String(notfinal);
                Passengers user = AirEntities.GetContext().Passengers.FirstOrDefault(p => p.Userlogin == Login.Text&&p.password==final);
                if (user == null)
                {
                    MessageBox.Show("Неправильно введены данные или пользователя не существует");
                }
                else
                { 
                if (user.UserType=="admin")
                {
                        Password.Password = "";
                        Login.Text = "";
                        Navigator.MainFrame.Navigate(new ShowCase());
                }
                if(user.UserType=="user")
                {
                    Navigator.login=Login.Text;
                        Password.Password = "";
                        Login.Text = "";
                    Navigator.MainFrame.Navigate(new ShowRaces());
                }
                }
            }
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            if (Login.Text==null||TextPassword.Text==null)
            { Console.WriteLine("Данные не были введены"); }
            else
            {
                Navigator.MainFrame.Navigate(new Register("user"));
            }

        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.IsChecked == true)
            {
                Password.Visibility = Visibility.Hidden;
                TextPassword.Text = Password.Password;
                TextPassword.Visibility = Visibility.Visible;
            }
            else
            {
                TextPassword.Visibility = Visibility.Hidden;
                Password.Visibility = Visibility.Visible;
            }
        }
    }
}
