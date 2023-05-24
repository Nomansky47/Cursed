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
    /// Логика взаимодействия для EditAirports.xaml
    /// </summary>
    public partial class EditAirports : Page
    {
        public EditAirports()
        {
            InitializeComponent();
        }
        private Airports _currentAirport = new Airports();
        bool _EditOrNot;
        public EditAirports(Airports selectedAirport, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selectedAirport != null)
            {
                Number.IsEnabled= false;
                _currentAirport = selectedAirport;
            }
            DataContext = _currentAirport;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Number.Text) || string.IsNullOrEmpty(AiportName.Text))
                error.AppendLine("Ошибка ввода, данные не были введены");
            else if (!int.TryParse(Number.Text, out int n))
                error.AppendLine("Ошибка ввода номера аэропорта");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (_EditOrNot)
                    AirEntities.GetContext().Airports.Add(_currentAirport);
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
