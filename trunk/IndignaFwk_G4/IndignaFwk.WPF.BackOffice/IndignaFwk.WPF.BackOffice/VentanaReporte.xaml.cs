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
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Entities;
using System.Data;

namespace IndignaFwk_WPF_BackOffice
{
    /// <summary>
    /// Interaction logic for VentanaReporte.xaml
    /// </summary>
    public partial class VentanaReporte : Window
    {
        private GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;
        private UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;

        public VentanaReporte()
        {
            this.InitializeComponent();
            

            List<Grupo> listaGr = grupoUserProcess.ObtenerListadoGrupos();


            foreach (var sitio in listaGr)
            {
               // dataGrid_listadoSitio.ItemsSource = sitio.Nombre;
                DataGridTextColumn dgrid = new DataGridTextColumn();
                dgrid.Header = sitio.Nombre;
                dataGrid_listadoSitio.Columns.Add(dgrid); 
            }
            List<Usuario> listUs = usuarioUserProcess.ObtenerListadoUsuarios();

            foreach (var us in listUs)
            {
 
               dataGrid_listadoSitio.ItemsSource = us.FechaRegistro.ToString();
              
            }

           
        }

        private void boton_Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

   }
}
