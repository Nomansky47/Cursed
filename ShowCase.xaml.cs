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
using System.Windows.Shapes;

namespace Cursed
{
    public partial class ShowCase : Page
    {
        public ShowCase()
        {
            InitializeComponent();
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new EditPage((sender as Button).DataContext as Aircrafts));
        }
        public void AddClick(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new EditPage(null));
        }
        private void DelClick(object sender, RoutedEventArgs e) 
        {
            var Removing = MyGrid.SelectedItems.Cast<Aircrafts>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить {Removing.Count} элементов?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try 
                {
                    AirEntities.GetContext().Aircrafts.RemoveRange(Removing);
                    AirEntities.GetContext().SaveChanges();
                    MessageBox.Show("Успешно удалено");
                    MyGrid.ItemsSource = AirEntities.GetContext().Aircrafts.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility==Visibility.Visible) 
            {
                AirEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                MyGrid.ItemsSource = AirEntities.GetContext().Aircrafts.ToList();
            }
        }
    }
}
