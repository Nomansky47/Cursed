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
            if (Login.Text == null || Password.Text == null)
            { Console.WriteLine("Данные не были введены"); }
            else
            {
                Passengers user = AirEntities.GetContext().Passengers.FirstOrDefault(p => p.Userlogin == Login.Text && p.password == Password.Text);
                if (user == null)
                {
                    MessageBox.Show("Неправильно введены данные или пользователя не существует");
                }
                else
                { 
                if (user.UserType=="admin")
                { 
                    Navigator.MainFrame.Navigate(new ShowCase());
                }
                if(user.UserType=="user")
                {
                    Navigator.login=Login.Text;
                    Navigator.MainFrame.Navigate(new ShowRaces());
                }
                }
            }
        }
        private void Register(object sender, RoutedEventArgs e)
        {
            if (Login.Text==null||Password.Text==null)
            { Console.WriteLine("Данные не были введены"); }
            else
            {
                Navigator.MainFrame.Navigate(new Register("user"));
            }

        }
    }
}
