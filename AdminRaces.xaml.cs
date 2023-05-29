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
    /// Логика взаимодействия для AdminRaces.xaml
    /// </summary>
    public partial class AdminRaces : Page
    {
        public AdminRaces()
        {
            InitializeComponent();
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new EditRaces((sender as Button).DataContext as Flights, false));
        }
        public void AddClick(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new EditRaces(null, true));
        }
        private void DelClick(object sender, RoutedEventArgs e)
        {
            var Removing = MyGrid.SelectedItems.Cast<Flights>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {Removing.Count} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AirEntities.GetContext().Flights.RemoveRange(Removing);
                    AirEntities.GetContext().SaveChanges();
                    MessageBox.Show("Успешно удалено");
                    MyGrid.ItemsSource = AirEntities.GetContext().Flights.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
     
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AirEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MyGrid.ItemsSource = AirEntities.GetContext().Flights.ToList();
            }
        }
    }
}
