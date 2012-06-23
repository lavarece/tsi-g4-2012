using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Reflection;

namespace IndignaFwk_WPF_BackOffice
{
    /// <summary>
    /// Interaction logic for Home1.xaml
    /// </summary>
    public partial class Home1 : Window
    {
        public Home1(string nombreUsuario)
        {
            InitializeComponent();
            label_bienvenido.Content += nombreUsuario;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Click_Cerrar_Sesion(object sender, RoutedEventArgs e)
        {
            Login l1 = new Login();
            l1.Show();
            this.Close();
        }
        private void Click_Salir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Menu Altas
        private void Click_Alta_Administrador(object sender, RoutedEventArgs e)
        {
            //Llamar alta administradores
            CrearAdministrador crearAdminWindow = new CrearAdministrador();
            crearAdminWindow.Show();
        }

        private void Click_Alta_Grupo(object sender, RoutedEventArgs e)
        {
            //Llamar alta Grupo
            e.Handled = true;

            CrearGrupo crearGrupoWindow = new CrearGrupo();
            crearGrupoWindow.Show();
        }

        //Menu Listados
        private void Click_Listados_Usuarios(object sender, RoutedEventArgs e)
        {
            GestionUsuarios ge = new GestionUsuarios();
            ge.Show();
        }

        private void Click_Listados_Grupos(object sender, RoutedEventArgs e)
        {
            GestionGrupos gg = new GestionGrupos();
            gg.Show();
        }

        private void Click_Listados_Administradores(object sender, RoutedEventArgs e)
        {
            GestionAdministradores ga = new GestionAdministradores();
            ga.Show();
        }

        //Menu Otros
        private void Click_Reportes(object sender, RoutedEventArgs e)
        {
            GestionReportes gr = new GestionReportes();
            gr.Show();
        }
        private void Click_Variables(object sender, RoutedEventArgs e)
        {
            GestionVariables gv = new GestionVariables();
            gv.Show();
        }
        private void Click_Watchdog(object sender, RoutedEventArgs e)
        {
            WatchDog w = new WatchDog();
            w.Show();
        }


    }
}
