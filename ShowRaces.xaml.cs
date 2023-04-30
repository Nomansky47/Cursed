using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для ShowRaces.xaml
    /// </summary>
    public partial class ShowRaces : Page
    {
        public ShowRaces()
        {
            InitializeComponent();

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {  
                AirEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                RaceGrid.ItemsSource = AirEntities.GetContext().Flights.ToList();
            }
        }

        private void Buy(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Не готово");
           // Navigator.MainFrame.Navigate(new TicketPage((sender as Button).DataContext as Aircrafts));
           Navigator.MainFrame.Navigate(new PlanePage((sender as Button).DataContext as Flights));  
        }
    }
}
