using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Club_Party
{
    class Hall
    {
        public Hall(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Reservations = new List<int>();
        }
        public string Name { get; private set; }

        public int Capacity { get; set; }
        public List<int> Reservations { get; private set; }

        public void AddReservation(int reservation)
        {
            this.Reservations.Add(reservation);
        }
    }
}
