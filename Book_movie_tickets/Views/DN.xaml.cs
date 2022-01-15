using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Book_movie_tickets.Model;
using Newtonsoft.Json;
namespace Book_movie_tickets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DN : ContentPage
    {
        public DN()
        {
            InitializeComponent();
        }

      

        private void DK_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DK());
        }


        private async void Login_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            var chuoi = await client.GetStringAsync("http://bookticket.somee.com/api/MovieController/GetUsers?userName=" + Username.Text + "&userPassword=" + Password.Text);
            var userList = JsonConvert.DeserializeObject<List<Logins>>(chuoi);
            if (userList != null)
            {
                await DisplayAlert("Thông báo", "Đăng nhập thành công", "OK");
                await Navigation.PushAsync(new Main_Tabbed());
            }
            else
            {
                await DisplayAlert("Thông báo", "Đăng nhập thất bại", "OK");
            }
        }
    }
}