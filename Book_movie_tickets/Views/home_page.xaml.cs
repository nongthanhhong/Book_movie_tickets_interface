using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Book_movie_tickets.Model;

namespace Book_movie_tickets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class home_page : ContentPage
    {
        public home_page()
        {
            InitializeComponent();
            createMovieColection();
        }

        List<Movies> movieList = new List<Movies>();

        async void createMovieColection()
        {
            HttpClient client = new HttpClient();
            var chuoi = await client.GetStringAsync("http://bookticket.somee.com/api/MovieController/GetMovies");
            var movieList = JsonConvert.DeserializeObject<List<Movies>>(chuoi);

            collection_movie.ItemsSource = movieList;
        }

        private void collection_movie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var MyCollectionView = sender as CollectionView;

            var selectedMovie = MyCollectionView.SelectedItem as Movies;
            if (selectedMovie != null)
            {
                Navigation.PushAsync(new Views.MovieDetail(selectedMovie));

            }
            MyCollectionView.SelectedItem = null;
        }

    }
}