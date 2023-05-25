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
    public partial class EditTickets : Page
    {
        private Tickets _currentTicket = new Tickets();
        bool _EditOrNot;
        public EditTickets(Tickets selectedTicket, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selectedTicket != null)
            {
                _currentTicket = selectedTicket;
            }
            DataContext = _currentTicket;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(FlightID.Text) || string.IsNullOrEmpty(Userlogin.Text) || string.IsNullOrEmpty(Row.Text) || string.IsNullOrEmpty(Seat.Text) || string.IsNullOrEmpty(Price.Text)|| string.IsNullOrEmpty(DepartureTime.Text))
                error.AppendLine("Ошибка ввода, данные не были введены");
            else if (!int.TryParse(FlightID.Text, out int n) ||!int.TryParse(Row.Text, out n)||!int.TryParse(Seat.Text, out n)|| !int.TryParse(Price.Text, out n))
                error.AppendLine("Ошибка ввода данных");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (_EditOrNot)
                    AirEntities.GetContext().Tickets.Add(_currentTicket);
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
