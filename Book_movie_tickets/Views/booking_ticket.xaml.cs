using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin.Forms;
using Book_movie_tickets.Model;
using Xamarin.Forms.Xaml;

namespace Book_movie_tickets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class booking_ticket : ContentPage
    {
        public booking_ticket()
        {
            InitializeComponent();
        }
        public booking_ticket(Model.Ticket ticket)
        {
            InitializeComponent();
            Init();
            Selected_ticket = ticket;
            this.BindingContext = ticket.selected_film;
        }
        public Model.Ticket Selected_ticket { get; set; }

        Dictionary<int, int> data = new Dictionary<int, int>();
        SKPaint availPaint = new SKPaint() { Style = SKPaintStyle.Stroke, Color = SKColor.Parse("#343352") };
        SKPaint resPaint = new SKPaint() { Style = SKPaintStyle.StrokeAndFill, Color = SKColor.Parse("#343352") };
        SKPaint yourPaint = new SKPaint() { Style = SKPaintStyle.StrokeAndFill, Color = SKColor.Parse("#9747ff") };
        SKPaint textPain = new SKPaint() { TextSize = 40, Color = SKColor.Parse("#343352") };

        private void Init()
        {
            var rand = new Random();
            for(int i = 0; i<120;i++)
            {
                data.Add(i, rand.Next(0, 2));
            }
        }

        private void canvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            var x = 60;
            var y = 60;
            var row = -1;
            var column = 14;
            var itemHeight = 40;
            var itemWight = 40;
            var magin = 20;
            var cornerRadius = 4;
            var item = 0;


            for(int i = 0; i < data.Count; i++)
            {
                if (item ==0)
                {
                    row += 1;
                    item = GetColumn(row );
                    var count = (column - item) / 2;
                    var offset = (count * itemWight) + (count * magin);
                    x = 60 + offset;
                    y = (itemWight + ((itemWight + magin) * row));
                }
                else
                {
                    x += itemHeight + magin;
                }
                var seatColorIndex = data[i];
                if (Selected_ticket.selected_seat.Any(z => z == i))
                    seatColorIndex = 2;

                canvas.DrawRoundRect(new SKRoundRect(new SKRect(x, y, x + itemHeight, y + itemWight), cornerRadius), GetColor(seatColorIndex));

                item -= 1;
                if (item==0)
                {
                    canvas.DrawText($"{row + 1}", 0, y + magin + (itemHeight / 2), textPain);
                }
            }

        }
        SKPaint GetColor(int seatColor)
        {
            switch(seatColor)
            {
                case 0:
                default:
                    return availPaint;
                case 1:
                    return resPaint;
                case 2:
                    return yourPaint;
            }
        }
        private int GetColumn(int row)
        {
            switch(row)
            {
                case 0:
                    return 8;
                case 1:
                case 9:
                    return 10;
                case 2:
                case 3:
                case 8:
                    return 12;
                default:
                    return 14;


            }
        }


        


        async private void Button_Clicked(object sender, EventArgs e)
        {
            String Seat = String.Empty;
            int[] lst = Selected_ticket.selected_seat;
            for (int i = 0; i< lst.Length; i++)
            {
                Seat += lst[i].ToString() + ", ";
            }
            Seat = Seat.Remove(Seat.Length - 2, 1);

            HttpClient client = new HttpClient();
            Bookings booking = new Bookings();
            booking.bookingMovie = Selected_ticket.selected_film.Title;
            booking.bookingTheater = Selected_ticket.selected_rap.theaterName;
            booking.bookingTime = Selected_ticket.selected_day.ToString();
            booking.bookingSeat = Seat;
            var json = JsonConvert.SerializeObject(booking);
            var nd = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync("http://bookticket.somee.com/api/MovieController/PostBookings", nd);

            await DisplayAlert("Mua thành công", "Tên phim " + Selected_ticket.selected_film.Title +
                "\nTại rap: " + Selected_ticket.selected_rap.theaterName +
                "\nThời gian: " + Selected_ticket.selected_day.ToString() +
                "\nCác ghế: " + Seat, "Yes", "No");
            await Navigation.PopAsync();
        }
    }
}