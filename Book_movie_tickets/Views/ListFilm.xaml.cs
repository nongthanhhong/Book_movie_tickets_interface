using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using Book_movie_tickets.Model;

using Xamarin.Forms.Xaml;

namespace Book_movie_tickets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFilm : ContentPage
    {
        RapChieu selected_rap = new RapChieu();
        public ListFilm(RapChieu rapchieu)
        {
            InitializeComponent();
            create_collec_movie();
            selected_rap = rapchieu;
            this.BindingContext = rapchieu;
        }

        List<Movies> movieList = new List<Movies>();
        async void create_collec_movie()
        {
            HttpClient client = new HttpClient();
            var chuoi = await client.GetStringAsync("http://bookticket.somee.com/api/MovieController/GetMovies");
            var movieList = JsonConvert.DeserializeObject<List<Movies>>(chuoi);

            Coll_film.ItemsSource = movieList;
        }

        private void Coll_film_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var MyCollectionView = sender as CollectionView;
            var selected_film = MyCollectionView.SelectedItem as Model.Movies;

            if (selected_film != null)
            {
                Navigation.PushAsync(new Views.SetDayAndSeat(selected_rap, selected_film));
            }

            MyCollectionView.SelectedItem = null;
        }
    }
}