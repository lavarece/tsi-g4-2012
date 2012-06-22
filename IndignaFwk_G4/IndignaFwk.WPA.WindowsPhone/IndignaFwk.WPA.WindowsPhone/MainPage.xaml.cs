﻿using System;
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

            proxy.ObtenerUsuarioPorEmailYPassAsync(textBox_email.Text, textBox_pass.Text);
            proxy.ObtenerUsuarioPorEmailYPassCompleted += new EventHandler<ObtenerUsuarioPorEmailYPassCompletedEventArgs>(proxy_ObtenerUsuarioPorEmailYPassCompleted);
        }
        private void proxy_ObtenerUsuarioPorEmailYPassCompleted(object sender, ObtenerUsuarioPorEmailYPassCompletedEventArgs e)
        {
            Usuario user = e.Result;
            if (user == null)
            {

            }
            else
            {
                Page1 convPivot = new Page1();

                
               
                
            }
            MessageBox.Show("Hola!");
        }
    }
}
