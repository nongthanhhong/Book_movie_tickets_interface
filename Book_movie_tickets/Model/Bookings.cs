using System;
using System.Collections.Generic;
using System.Text;

namespace Book_movie_tickets.Model
{
    public class Bookings
    {
        public int bookingId { get; set; }
        public string bookingMovie { get; set; }
        public string bookingTheater { get; set; }
        public string bookingTime { get; set; }
        public string bookingSeat { get; set; }
    }
}
