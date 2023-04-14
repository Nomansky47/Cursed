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
    public partial class ShowCase : Window
    {
        public ShowCase()
        {
            InitializeComponent();
            Dgrid.ItemsSource=AirEntities.GetContext().Passengers.ToList();
        }
        private void EditClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("i forgor -_-");
        }
    }
}
