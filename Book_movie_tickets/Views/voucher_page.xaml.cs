using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book_movie_tickets.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
namespace Book_movie_tickets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class voucher_page : ContentPage
    {
        List<Voucher> voucherList;
        async void voucherInit()
        {
            HttpClient client = new HttpClient();
            var chuoi = await client.GetStringAsync("http://bookticket.somee.com/api/MovieController/GetVouchers");
            var voucherList = JsonConvert.DeserializeObject<List<Voucher>>(chuoi);
            lstVoucher.ItemsSource = voucherList;

        }
        public voucher_page()
        {
            InitializeComponent();
            voucherInit();
        }
    }
}