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
using System.Windows.Navigation;
using IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceUsuario;

namespace IndignaFwk_WP7_WindowsPhoneApplication
{
    public partial class MainPage : PhoneApplicationPage
    {
        PivotItem convocatorias;
        PivotItem detalles;
        Usuario user;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            user = null;
            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);                 
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }

            convocatorias = pivotConvocatorias;
            contenedor.Items.Remove(pivotConvocatorias);

            detalles = pivotDetalles;
            contenedor.Items.Remove(pivotDetalles);
        }

        private void FirstListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void boton_login_Click(object sender, RoutedEventArgs e)
        {
            ServiceReferenceUsuario.UsuarioServiceClient proxy = new ServiceReferenceUsuario.UsuarioServiceClient();

            proxy.ObtenerUsuarioPorEmailYPassAsync(textBox_email.Text, textBox_pass.Text);
            proxy.ObtenerUsuarioPorEmailYPassCompleted += new EventHandler<ObtenerUsuarioPorEmailYPassCompletedEventArgs>(proxy_ObtenerUsuarioPorEmailYPassCompleted);
        }
        private void proxy_ObtenerUsuarioPorEmailYPassCompleted(object sender, ObtenerUsuarioPorEmailYPassCompletedEventArgs e)
        {
            user = e.Result;
            if (user != null)
            {
                contenedor.Items.Add(convocatorias);
                contenedor.Items.Add(detalles);
            }
            else
            {
                MessageBox.Show("Error! Email y/o Contraseña incorrecto/s");
            }
            
        }

        private void boton_cerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            user = null;

            convocatorias = pivotConvocatorias;
            contenedor.Items.Remove(pivotConvocatorias);

            detalles = pivotDetalles;
            contenedor.Items.Remove(pivotDetalles);
        }
    }
}