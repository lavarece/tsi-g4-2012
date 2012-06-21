using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using IndignaFwk_WPA_WindowsPhone.ServiceReferenceUsuario;

namespace IndignaFwk_WPA_WindowsPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
   

        public MainPage()
        {
            
            InitializeComponent();
        }

        private void boton_login_Click(object sender, RoutedEventArgs e)
        {
            UsuarioServiceClient proxy = new UsuarioServiceClient();

            proxy.ObtenerUsuarioPorIdAsync(1);
            proxy.ObtenerUsuarioPorIdCompleted += new EventHandler<ObtenerUsuarioPorIdCompletedEventArgs>(proxy_ObtenerUsuarioPorIdCompleted);
        }
        private void proxy_ObtenerUsuarioPorIdCompleted(object sender, ObtenerUsuarioPorIdCompletedEventArgs e)
        {
            Usuario user = e.Result;
            MessageBox.Show("Hola!");
        }
    }
}
