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
    public partial class MovieDetail : ContentPage
    {
        List<Model.Movies> selecMovie = new List<Model.Movies>();
        public MovieDetail()
        {
            InitializeComponent();
        }
        public MovieDetail(Model.Movies movie)
        {
            InitializeComponent();
            this.BindingContext = movie;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new buy_ticket());
        }
    }
}