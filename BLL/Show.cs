﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Show
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int CountSeats { get; set; }
        public DateTime Date { get; set; }
        public double Price { get; set; }
        public Show(string name, string author, string genre, int countseats, DateTime date, double price)
        {
            Name = name;
            Author = author;
            Genre = genre;
            CountSeats = countseats;
            Date = date;
            Price = price;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}