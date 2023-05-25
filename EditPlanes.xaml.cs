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
    public partial class EditPlanes : Page
    {
        private Aircrafts _currentAircraft = new Aircrafts();
        bool _EditOrNot;
        public EditPlanes(Aircrafts selectedAircraft, bool EditOrNot)
        {
            InitializeComponent();
            _EditOrNot = EditOrNot;
            if (selectedAircraft != null)
            {
                Number.IsEnabled = false;
                _currentAircraft = selectedAircraft;
            }
            DataContext = _currentAircraft;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (string.IsNullOrEmpty(Number.Text) || string.IsNullOrEmpty(_currentAircraft.PlaneType))
                error.AppendLine("Ошибка ввода, данные не были введены");
            else if (!int.TryParse(Seats.Text, out int n) || n % 10 != 0 || !int.TryParse(Number.Text, out n))
                error.AppendLine("Ошибка ввода количества мест");
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                if (_EditOrNot)
                    AirEntities.GetContext().Aircrafts.Add(_currentAircraft);
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
