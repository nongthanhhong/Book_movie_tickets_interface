using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Book_movie_tickets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetDayAndSeat : ContentPage
    {
        public SetDayAndSeat(Model.RapChieu rapchieu, Model.Movies movie)
        {
            InitializeComponent();
            this.BindingContext = movie;
            selected_ticket.selected_film = movie;
            selected_ticket.selected_rap = rapchieu;
        }

        public Model.Ticket selected_ticket = new Model.Ticket();

        private void Button_Clicked(object sender, EventArgs e)
        {
            string[] a = Seats.Text.Split(' ');
            int[] val = new int[a.Length];
            for(int i = 0; i < a.Length;i++)
                    val[i] = int.Parse(a[i]);

            selected_ticket.selected_seat = val;
            selected_ticket.selected_day = date_picker.Date;

            if (selected_ticket.selected_film != null)
            {
                Navigation.PushAsync(new Views.booking_ticket(selected_ticket));
            }

        }
    }
}