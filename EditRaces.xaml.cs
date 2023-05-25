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
    /// Логика взаимодействия для EditRaces.xaml
    /// </summary>
    public partial class EditRaces : Page
    {
        private Flights _currentFlight = new Flights();
        bool _EditOrNot;
        public EditRaces(Flights selectedFlight, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selectedFlight != null)
            {
                _currentFlight = selectedFlight;
            }
            DataContext = _currentFlight;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Date.Text) || string.IsNullOrEmpty(AirportID.Text) || string.IsNullOrEmpty(AircraftID.Text) || string.IsNullOrEmpty(Destination.Text) || string.IsNullOrEmpty(Departure_Time.Text) || string.IsNullOrEmpty(Arrival_Time.Text))
                error.AppendLine("Ошибка ввода, данные не были введены");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (_EditOrNot)
                    AirEntities.GetContext().Flights.Add(_currentFlight);
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
