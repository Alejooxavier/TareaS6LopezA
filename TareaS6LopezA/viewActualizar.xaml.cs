using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaS6LopezA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewActualizar : ContentPage
    {
        public viewActualizar(int codigo, string nombre, string apellido, int edad)
        {
            InitializeComponent();

            txtCodigo.Text = codigo.ToString();
            txtNombre.Text = nombre;
            txtApellido.Text = apellido;
            txtEdad.Text = edad.ToString();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = client.PutAsync(String.Format("http://192.168.1.8/moviles/post.php?codigo={0}&nombre={1}&apellido={2}&edad={3}", txtCodigo.Text, txtNombre.Text, txtApellido.Text, txtEdad.Text), null).Result;
                Navigation.PushAsync(new MainPage());
                DisplayAlert("Mensaje", "Dato actualizado", "ok");

            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "ERROR" + ex.Message, "OK");
            }
        }
    }
}