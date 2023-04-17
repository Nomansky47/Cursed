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
            Navigator.MainFrame = MyFrame;
            MyFrame.Navigate(new Registration());
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            Navigator.MainFrame.GoBack();
        }

        private void MyFrame_ContentRendered(object sender, EventArgs e)
        {
            if (MyFrame.CanGoBack) 
            {
                BackButton.Visibility = Visibility.Visible;
            }
            else
            {
                BackButton.Visibility = Visibility.Hidden;
            }    
        }
    }
}
