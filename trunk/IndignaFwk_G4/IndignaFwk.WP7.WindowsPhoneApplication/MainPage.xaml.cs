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
using Microsoft.Phone.Controls.Maps;

using System.Windows.Navigation;
using IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceUsuario;
using Microsoft.Phone.Controls.Maps.Platform;
using IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceConvocatoria;
using System.Collections.ObjectModel;
using System.Device.Location;

namespace IndignaFwk_WP7_WindowsPhoneApplication
{
    public partial class MainPage : PhoneApplicationPage
    {
        PivotItem login;
        
        PivotItem convocatorias;
        
        PivotItem detalles;

        PivotItem mapa;
        
        IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceUsuario.Usuario user;
        
        Collection<IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceConvocatoria.Convocatoria> listaConvocatorias = new Collection<IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceConvocatoria.Convocatoria>();
        
        string latitud;

        string longitud;
        
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

            login = pivotLogin;

            convocatorias = pivotConvocatorias;
            contenedor.Items.Remove(pivotConvocatorias);
            
            detalles = pivotDetalles;
            contenedor.Items.Remove(pivotDetalles);

            mapa = pivotMapa;
            contenedor.Items.Remove(pivotMapa);

            ServiceReferenceConvocatoria.ConvocatoriaServiceClient proxy = new ServiceReferenceConvocatoria.ConvocatoriaServiceClient();
            proxy.ObtenerListadoConvocatoriasPorGrupoAsync(4);
            proxy.ObtenerListadoConvocatoriasPorGrupoCompleted += new EventHandler<ObtenerListadoConvocatoriasPorGrupoCompletedEventArgs>(proxy_ObtenerListadoConvocatoriasPorGrupoCompleted); 

        }

        private void FirstListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void boton_login_Click(object sender, RoutedEventArgs e)
        {
            ServiceReferenceUsuario.UsuarioServiceClient proxy = new ServiceReferenceUsuario.UsuarioServiceClient();

            proxy.ObtenerUsuarioPorEmailPassYGrupoAsync(textBox_email.Text, textBox_pass.Text, 4);
            proxy.ObtenerUsuarioPorEmailPassYGrupoCompleted += new EventHandler<ObtenerUsuarioPorEmailPassYGrupoCompletedEventArgs>(proxy_ObtenerUsuarioPorEmailYPassCompleted);
        }
        private void proxy_ObtenerUsuarioPorEmailYPassCompleted(object sender, ObtenerUsuarioPorEmailPassYGrupoCompletedEventArgs e)
        {
            user = e.Result;
            if (user == null)
            {
                contenedor.Items.Add(convocatorias);
                contenedor.Items.Add(detalles);
                contenedor.Items.Add(mapa);
                contenedor.Items.Remove(login);

                Collection<Pushpin> push = new Collection<Pushpin>();

                foreach (IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceConvocatoria.Convocatoria convocatoria in listaConvocatorias)
                {
                    // Update the map to show the current location
                    Location ppLoc = new Location();
                    MapLayer mapL = new MapLayer();

                    string cleanCoord = convocatoria.Coordenadas.Replace("(", "").Replace(")", "");

                    string[] array = cleanCoord.Split(',');

                    latitud = array[0];

                    cleanCoord = convocatoria.Coordenadas.Replace("(", "").Replace(")", "");

                    array = cleanCoord.Split(',');

                    longitud = array[1];

                    ppLoc.Latitude = long.Parse(longitud);
                    ppLoc.Longitude = long.Parse(latitud);

                    var mapLayer = new MapLayer();
                    var youPushpin = new Pushpin
                    {
                        Height = 70,
                        Width = 60,
                        Background = new SolidColorBrush(Colors.Red),
                    };

                    push.Add(youPushpin);
                    
                    mapLayer.AddChild(youPushpin, new GeoCoordinate(Convert.ToDouble(latitud), Convert.ToDouble(longitud)), PositionOrigin.BottomCenter);
                    mapLayer.Visibility = System.Windows.Visibility.Visible;
                    map1.Children.Add(mapLayer);
                    
                    
                    //map1.SetView(ppLoc, 10);

                    //////update pushpin location and show
                    //MapLayer.SetPosition(mapL, ppLoc);
                    //mapL.Visibility = System.Windows.Visibility.Visible;

                    //mapa = pivotMapa;
                    //contenedor.Items.Remove(pivotMapa);
                }
 
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

            mapa = pivotMapa;
            contenedor.Items.Remove(pivotMapa);
        }

        private void proxy_ObtenerListadoConvocatoriasPorGrupoCompleted(object sender, ObtenerListadoConvocatoriasPorGrupoCompletedEventArgs e)
        {
            listaConvocatorias = e.Result;
        }
    }
}