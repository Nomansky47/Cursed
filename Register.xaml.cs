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
    /// Логика взаимодействия для Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        private Passengers _currentUser = new Passengers();
        private string usertype;
        public Register(string userttype)
        {
            usertype = userttype;
            InitializeComponent();
        }

        private void Registration(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();

            if (string.IsNullOrEmpty(Nname.ToString()) || string.IsNullOrEmpty(SecondName.ToString())|| string.IsNullOrEmpty(ThirdName.ToString())|| string.IsNullOrEmpty(Password.ToString())|| string.IsNullOrEmpty(Login.ToString()))
                error.AppendLine("Ошибка ввода, данные не были введены");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                _currentUser.UserType = usertype;
                _currentUser.Surname= SecondName.Text.ToString();
                _currentUser.Name = Nname.Text.ToString();
                _currentUser.Patronymic=ThirdName.Text.ToString();
                _currentUser.password= Password.Text.ToString();
                _currentUser.Userlogin=Login.Text.ToString();
                AirEntities.GetContext().Passengers.Add(_currentUser);
                AirEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                Navigator.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.GetType() + " " + ex.StackTrace);
            }
          
        }
    }
}
