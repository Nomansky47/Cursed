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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        public AdminPage()
        {
            InitializeComponent();
        }
        private void PlanesShow(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new AdminPlanes());
        }

        private void AirportsShow(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new AdminAirports());
        }

        private void PassengersShow(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new AdminPassengers());
        }

        private void TicketsShow(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new AdminTickets());
        }

        private void RacesShow(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new AdminRaces());
        }
    }
}
