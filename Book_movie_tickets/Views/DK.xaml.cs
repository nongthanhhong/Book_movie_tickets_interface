using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using Book_movie_tickets.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Book_movie_tickets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DK : ContentPage
    {
       
        public DK()
        {
            InitializeComponent();
            
        }
    

        private async void btnSignup_Clicked(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            Users user = new Users();
            user.userFullName = fullname.Text;
            user.userPhone = phonenumber.Text;
            user.userMail = email.Text;
            user.userName = username.Text;
            user.userPassword = password.Text;
            if (repassword.Text == password.Text)
            {
                    var json = JsonConvert.SerializeObject(user);
                    var nd = new StringContent(json, Encoding.UTF8, "application/json");
                    await client.PostAsync("http://bookticket.somee.com/api/MovieController/PostUsers", nd);
                    await DisplayAlert("Thông báo", "Đăng kí thành công", "OK");
                    await Navigation.PushAsync(new DN());  
            }
            else
            {
                await DisplayAlert("Thông báo", "Đăng kí thất bại, vui lòng thử lại","OK");
            }
        }
    }
}