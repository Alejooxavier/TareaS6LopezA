using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaS6LopezA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewEliminar : ContentPage
    {
        public viewEliminar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();
            lblCodigo.Text = codigo.ToString();
            lblNombre.Text = nombre;
            lblApellido.Text = apellido;
            lblEdad.Text = edad.ToString();

        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = client.DeleteAsync(String.Format("http://192.168.1.8/moviles/post.php?codigo={0}", lblCodigo.Text)).Result;
                Navigation.PushAsync(new MainPage());
                DisplayAlert("Mensaje", "Dato eliminado", "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "ERROR" + ex.Message, "OK");
            }
        }
    }
}



