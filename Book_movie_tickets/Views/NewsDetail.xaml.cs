using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_movie_tickets.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Book_movie_tickets.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsDetail : ContentPage
    {
        List<News> selectedNews = new List<News>();
        public NewsDetail()
        {
            InitializeComponent();
        }
        public NewsDetail(News news)
        {
            InitializeComponent();
            this.BindingContext = news;
        }

    }
}