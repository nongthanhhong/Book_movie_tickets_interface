using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Book_movie_tickets.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Book_movie_tickets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class buy_ticket : ContentPage
    {

        public buy_ticket()
        {
            InitializeComponent();
            createRapChieu();
        }

        List<Model.RapChieu> lst_rapchieu = new List<Model.RapChieu>();
        async void createRapChieu()
        {
            HttpClient client = new HttpClient();
            var chuoi = await client.GetStringAsync("http://bookticket.somee.com/api/MovieController/GetTheaters");
            var lst_rapchieu = JsonConvert.DeserializeObject<List<RapChieu>>(chuoi);

            Coll_rapchieu.ItemsSource = lst_rapchieu;
        }

        private void Coll_rapchieu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var MyCollectionView = sender as CollectionView;
            var selectedRap = MyCollectionView.SelectedItem as Model.RapChieu;
            if (selectedRap != null)
            {
                Navigation.PushAsync(new Views.ListFilm(selectedRap));

            }
            MyCollectionView.SelectedItem = null;
        }
    }
}