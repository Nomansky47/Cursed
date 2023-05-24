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
    public partial class EditPassengers : Page
    {
        public EditPassengers()
        {
            InitializeComponent();
        }
        private Passengers _currentPassenger = new Passengers();
        bool _EditOrNot;
        public EditPassengers(Passengers selectedPassenger, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selectedPassenger != null)
            {
                Login.IsEnabled = false;
                Password.IsEnabled = false;
                _currentPassenger = selectedPassenger;
            }
            DataContext = _currentPassenger;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Login.Text) || string.IsNullOrEmpty(Password.Text) || string.IsNullOrEmpty(UserType.Text)|| string.IsNullOrEmpty(Surname.Text)|| string.IsNullOrEmpty(Name.Text)|| string.IsNullOrEmpty(Patronymic.Text))
                error.AppendLine("Ошибка ввода, данные не были введены");
            else if (UserType.Text!="admin"|| UserType.Text != "user")
                error.AppendLine("Тип пользователя должен быть admin или user");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (_EditOrNot)
                    AirEntities.GetContext().Passengers.Add(_currentPassenger);
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
