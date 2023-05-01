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
        private void ButtonsAdd(int j,Panel panel, List<Tickets> tickets, int max) //на вход подаются параметры: ряд, панель для добавления на экран,
                                                                                   //таблица с билетами для проверки, и кол-во рядов в самолете
        {
            int width =40 ,height = 40;
            for (int i = 1; i < max+1; i++)
            {
                Button button = new Button();
                button.Name = "b" + j.ToString() + i.ToString(); //наименование для кнопки, чтобы в будущем определять ряд и номер места
                button.Content = j.ToString() + " "+ i.ToString(); //отображение ряда и места
                if (tickets.Exists(p => p.FlightID==_flight.FlightID&&p.Row ==j && p.Seat == i&&p.Userlogin==Navigator.login))
                {
                    button.Background = Brushes.Red; //если в базе данных уже куплен билет, то повторно купить не получится
                }
                else button.Click += ButtonOnClick; //иначе можно купить
                button.Width = width;
                button.Height = height;
                panel.Children.Add(button); // добавление кнопки на панель
                //ПОЯСНИТЕЛЬНАЯ ЗАПИСКА 
            }
        }
        public PlanePage(Flights _selectedFlight)
        {
            InitializeComponent();
            _flight=_selectedFlight;
            DataContext = _selectedFlight;
            List<Tickets> tickets= AirEntities.GetContext().Tickets.ToList();
            _aircrafts= AirEntities.GetContext().Aircrafts.FirstOrDefault(p => p.AircraftID == _flight.AircraftID);
            int max = _aircrafts.NumberOfSeats/10;
            ButtonsAdd(1, Panel3, tickets,max);
            ButtonsAdd(2, Panel4, tickets, max);
            ButtonsAdd(3, Panel5, tickets, max);
            ButtonsAdd(4, Panel6, tickets, max); 
            ButtonsAdd(5, Panel7, tickets, max);
            ButtonsAdd(6, Panel8, tickets, max);
            ButtonsAdd(7, Panel9, tickets, max);
            ButtonsAdd(8, Panel10, tickets, max);
            ButtonsAdd(9, Panel11, tickets, max);
            ButtonsAdd(10, Panel12, tickets, max);
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
