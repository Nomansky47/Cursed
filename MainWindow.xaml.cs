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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Enter(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("i forgor -_-");
        }
        private void Registration(object sender, RoutedEventArgs e)
        {
            
            ShowCase show = new ShowCase();
            show.Show();
        }
        }
}
