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
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class ShowCase : Page
    {
        public ShowCase()
        {
            InitializeComponent();
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("i forgor -_-");
        }
        public void AddClick(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.Navigate(new EditPage());
        }
        private void DelClick(object sender, RoutedEventArgs e) 
        {
            MessageBox.Show("i forgor -_-");
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
