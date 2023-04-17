﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TheatreBoxOffice
    {
        public List<Show> shows = new List<Show>();
        public List<Ticket> tickets = new List<Ticket>();
        DateTime nowdatetime = new DateTime();
        public TheatreBoxOffice(List<Show> lshows, List<Ticket> ltickets)
        {
            shows = lshows;
            tickets = ltickets;
        }
        public void AddShow(string name, string author, string genre, int countseats, DateTime dateTime, double price)
        {
            shows.Add(new Show(name, author, genre, countseats, dateTime, price));
        }
        public void DeleteShow(int numshow)
        {
            shows.RemoveAt(numshow);
        }
        public string BuyTicket(int countshow, string nameofowner)
        {
            tickets.Add(new Ticket(shows[countshow].Name, shows[countshow].Price, nameofowner, shows[countshow].Date));
            return tickets.Last().ToString();
        }
        public string ReturnTicket(int i)
        {
            TimeSpan difference = tickets[i].Date - nowdatetime;
            if (difference.TotalDays >= 2)
            {
                double price = tickets[i].Price * 0.8;
                tickets.RemoveAt(i);
                return "Your return: " + price.ToString();
            }
            else
                return "Too late to return tickets";
        }
    }
}
