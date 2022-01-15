using System;
using System.Collections.Generic;
using System.Text;

namespace Book_movie_tickets.Model
{
    public class Ticket
    {
        public Model.Movies selected_film { get; set; }
        public Model.RapChieu selected_rap { get; set; }

        public int[] selected_seat { get; set; }
        public DateTime selected_day { get; set; }
        public int total_cost { get; set; }

    }
}
