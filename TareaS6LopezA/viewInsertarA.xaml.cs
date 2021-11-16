using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TareaS6LopezA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewInsertarA : ContentPage
    {
        public viewInsertarA()
        {
            InitializeComponent();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues("http://192.168.1.8/moviles/post.php", "POST", parametros);
                DisplayAlert("Mensaje", "Dato ingresado", "ok");
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", "ERROR" + ex.Message, "OK");
            }
            

        }

    }
}