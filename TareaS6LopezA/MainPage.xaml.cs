using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TareaS6LopezA
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.1.8/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<TareaS6LopezA.WS.Datos> _post;

        public MainPage()
        {
            InitializeComponent();
            get();
            
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<TareaS6LopezA.WS.Datos> posts = JsonConvert.DeserializeObject<List<TareaS6LopezA.WS.Datos>>(content);
                _post = new ObservableCollection<TareaS6LopezA.WS.Datos>(posts);

                MyListView.ItemsSource = _post;
            }
            catch (Exception ex){
                await DisplayAlert("Error", "ERROR" + ex.Message, "OK");
            }
        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viewInsertarA());

        }
    }
}
