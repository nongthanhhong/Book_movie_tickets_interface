using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Book_movie_tickets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class user_page : ContentPage
    {
        public user_page()
        {
            InitializeComponent();
        }

        private void DK_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DK());
        }

        private void DN_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DN());
        }
    }
}