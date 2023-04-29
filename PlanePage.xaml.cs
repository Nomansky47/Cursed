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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Cursed
{
    /// <summary>
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class PlanePage : Page
    {
        Flights flight=new Flights();
        private void ButtonsAdd(int j,Panel panel, List<Tickets> flights)
        {
            int width = 50;
            int height = 50;
            Button[] button = new Button[4];
            //ПОДПИСАТЬ МЕСТА ПО ТИПУ 11 21 и тд
            for (int i = 1; i < 4; i++)
            {
                button[i] = new Button();
                button[i].Name = "b" + j.ToString() + i.ToString();
                if (flights.Exists(p => p.FlightID==flight.FlightID&&p.Row == int.Parse(button[i].Name[1].ToString()) && p.Seat == int.Parse(button[i].Name[2].ToString())))
                {
                    button[i].Background = Brushes.Red;
                }
                else button[i].Click += ButtonOnClick;
                button[i].Width = width;
                button[i].Height = height;
                panel.Children.Add(button[i]);
                //КОмментарии для кода
                //ПОЯСНТИЛЕЛЬНАЯ ЗАПИСКА
            }
        }
        public PlanePage(Flights _selectedFlight)
        {
            InitializeComponent();
            flight=_selectedFlight;
            DataContext = _selectedFlight;
            List<Tickets> flights= AirEntities.GetContext().Tickets.ToList();
            ButtonsAdd(1,Panel1,flights);
            ButtonsAdd(2, Panel2, flights);
            ButtonsAdd(3, Panel3, flights);
            ButtonsAdd(4, Panel4, flights);
            ButtonsAdd(5, Panel5, flights);
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;
            button.Click -= ButtonOnClick;
            Tickets ticket = new Tickets();
            // if (тип самолета ==бизнес) цена= 300
            ticket.Price = 1000;
            ticket.FlightID = flight.FlightID;
            ticket.Row = int.Parse(button.Name[1].ToString());
            ticket.Seat = int.Parse(button.Name[2].ToString());
            ticket.Departure_Time = flight.Departure_Time;
            ticket.Userlogin = Navigator.login;
            AirEntities.GetContext().Tickets.Add(ticket);
            AirEntities.GetContext().SaveChanges();
           
            button.Background = Brushes.Red;
            
        }

    }
}
