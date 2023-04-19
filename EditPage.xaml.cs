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
    public partial class EditPage : Page
    {
        private Aircrafts _currentAircraft = new Aircrafts();
        public EditPage(Aircrafts selectedAircraft)
        {
            InitializeComponent();
            if (selectedAircraft != null) 
                _currentAircraft = selectedAircraft; 
            DataContext = _currentAircraft;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            StringBuilder error=new StringBuilder();

            if (int.TryParse(Number.ToString(), out int n))
                error.AppendLine("Ошибка ввода номера самолета");
            if (string.IsNullOrEmpty(Seats.ToString()) || _currentAircraft.PlaneType == null)
                error.AppendLine("Ошибка ввода, данные не были введены");
            if (error.Length > 0 ) 
            {
                MessageBox.Show(error.ToString());
                return;
            }
            try
            {
                AirEntities.GetContext().Aircrafts.Add(_currentAircraft);
                AirEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                Navigator.MainFrame.GoBack();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString() +" "+ex.GetType()+" "+ ex.StackTrace);
            }

            
        }
    }
}
