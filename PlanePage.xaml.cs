using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
namespace Cursed
{
    public partial class PlanePage : Page
    {
        Flights _flight=new Flights();
        Aircrafts _aircrafts= new Aircrafts();
        private void ButtonsAdd(int j,Panel panel, List<Tickets> tickets) //на вход подаются параметры: ряд, панель для добавления на экран
                                                                                   // и таблица с билетами для проверки
        {
            for (int i = 1; i < 6; i++)
            {
                Button button = new Button();
                button.Name = "b" + j.ToString() + i.ToString(); //наименование для кнопки, чтобы в будущем определять ряд и номер места
                button.Content = j.ToString() + " "+ i.ToString(); //отображение ряда и места
                if (tickets.Exists(p => p.FlightID==_flight.FlightID&&p.Row ==j && p.Seat == i))
                {
                    button.Background = Brushes.Red; //если в базе данных уже куплен билет, то повторно купить не получится
                }
                else button.Click += ButtonOnClick; //иначе можно купить
                button.Width = 40;
                button.Height = 40;
                panel.Children.Add(button); // добавление кнопки на панель
            }
        }
        public PlanePage(Flights _selectedFlight)
        {
            InitializeComponent(); 
            _flight=_selectedFlight;
            DataContext = _selectedFlight;
            List<Tickets> tickets= AirEntities.GetContext().Tickets.ToList();
            _aircrafts= AirEntities.GetContext().Aircrafts.FirstOrDefault(p => p.AircraftID == _flight.AircraftID);
            Panel[] panels = new Panel[15] {Panel1,Panel2, Panel3, Panel4, Panel5, Panel6, Panel7, Panel8, Panel9,
            Panel10, Panel11, Panel12, Panel13, Panel14, Panel15};
            for (int i = 0;i< _aircrafts.NumberOfSeats / 5; i++)
            {
                ButtonsAdd(i+1, panels[i], tickets);
            }
        }
        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            Button button = (Button)sender;
            button.Click -= ButtonOnClick;
            button.Background = Brushes.Red;
            Tickets ticket = new Tickets();
            switch (_aircrafts.PlaneType)
            {
                case "эконом":
                    ticket.Price = 2000;
                    break;
                case "комфорт":
                    ticket.Price = 3000;
                    break;
                case "бизнес":
                    ticket.Price = 5000;
                    break;
            }
            ticket.FlightID = _flight.FlightID;
            if (button.Name.Length==3)
            {
                ticket.Row = int.Parse(button.Name[1].ToString());
                ticket.Seat = int.Parse(button.Name[2].ToString());
            
            }
            else
            {
                ticket.Row = int.Parse(button.Name[1].ToString() + button.Name[2]);
                ticket.Seat = int.Parse(button.Name[3].ToString());
            }
            ticket.Departure_Time = _flight.Departure_Time;
            ticket.Userlogin = Navigator.login;
            AirEntities.GetContext().Tickets.Add(ticket);
            AirEntities.GetContext().SaveChanges();
        }
    }
}
