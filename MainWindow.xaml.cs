﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;


namespace Cursed
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigator.MainFrame = MyFrame;
            MyFrame.Navigate(new Authorization());
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
            if (MyFrame.Content is ShowRaces || MyFrame.Content is PlanePage) TicketButton.Visibility = Visibility.Visible;
            else TicketButton.Visibility = Visibility.Hidden;
        }

        private void TicketToFile(object sender, RoutedEventArgs e)
        {
            
                if (AirEntities.GetContext().Tickets.ToList().Exists(p => p.Userlogin == Navigator.login))
                {
                    List<Tickets> tickets = AirEntities.GetContext().Tickets.Where(p => p.Userlogin == Navigator.login).ToList();
                    StringBuilder all = new StringBuilder();
                    foreach (var ticket in tickets)
                    {
                        all.AppendLine("Номер билета: " + ticket.TicketID.ToString());
                        all.AppendLine("Номер рейса: " + ticket.FlightID.ToString());
                        all.AppendLine("Логин: " + ticket.Userlogin);
                        all.AppendLine("Фамилия: " + AirEntities.GetContext().Passengers.Where(p => p.Userlogin == ticket.Userlogin).FirstOrDefault().Surname);
                        all.AppendLine("Имя: " + AirEntities.GetContext().Passengers.Where(p => p.Userlogin == ticket.Userlogin).FirstOrDefault().Name);
                        all.AppendLine("Отчество: " + AirEntities.GetContext().Passengers.Where(p => p.Userlogin == ticket.Userlogin).FirstOrDefault().Patronymic);
                        all.AppendLine("Ряд: " + ticket.Row.ToString());
                        all.AppendLine("Место: " + ticket.Seat.ToString());
                        all.AppendLine("Цена: " + ticket.Price.ToString() + 'р');
                        all.AppendLine("Время прибытия: " + ticket.Departure_Time.ToString());
                        all.AppendLine();
                    }
                    using (FileStream stream = new FileStream("C:\\Users\\NikitaPortable\\Desktop\\Ticket.txt", FileMode.Create))
                    {
                        byte[] buffer = Encoding.Default.GetBytes(all.ToString());
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
                else MessageBox.Show("Билеты отсутсвуют");
        }
    }
}
