using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using Book_movie_tickets.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Book_movie_tickets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class new_page : ContentPage
    {
        public new_page()
        {
            InitializeComponent();
            createNews();
        }

        List<News> newsList = new List<News>();

        async void createNews()
        {
            HttpClient client = new HttpClient();
            var chuoi = await client.GetStringAsync("http://bookticket.somee.com/api/MovieController/GetNews");
            var lst_news = JsonConvert.DeserializeObject<List<News>>(chuoi);

            Coll_news.ItemsSource = lst_news;
        }
        private void Coll_news_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var MyCollectionView = sender as CollectionView;

            var selectedNews = MyCollectionView.SelectedItem as News;
            if (selectedNews != null)
            {
                Navigation.PushAsync(new Views.NewsDetail(selectedNews));

            }
            MyCollectionView.SelectedItem = null;
        }
    }
}