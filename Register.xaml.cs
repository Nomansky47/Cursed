using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Cursed
{
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
                _currentUser.Surname= SecondName.Text.ToString();
                _currentUser.Name = Nname.Text.ToString();
                _currentUser.Patronymic=ThirdName.Text.ToString();
                var login= Login.Text.ToString();
                _currentUser.Userlogin = login;
                if (login == "admin")
                    _currentUser.UserType = "admin";
                else
                    _currentUser.UserType = usertype;
                var crypt = System.Security.Cryptography.SHA256.Create();
                var final = crypt.ComputeHash(Encoding.UTF8.GetBytes(Password.Text.ToString()));
                _currentUser.password = Convert.ToBase64String(final);
                AirEntities.GetContext().Passengers.Add(_currentUser);
                AirEntities.GetContext().SaveChanges();
                Navigator.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " " + ex.GetType() + " " + ex.StackTrace);
            }
          
        }
    }
}
