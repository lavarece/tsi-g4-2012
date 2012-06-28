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

namespace IndignaFwk_WPF_BackOffice
{
    /// <summary>
    /// Interaction logic for ReporteContenidoInadecuado.xaml
    /// </summary>
    public partial class ReporteContenidoInadecuado : Window
    {
        
        UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;
        GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;
        ContenidoUserProcess contenidoUserProcess = UserProcessFactory.Instance.ContenidoUserProcess;

        public ReporteContenidoInadecuado()
		{
			this.InitializeComponent();

            foreach(Grupo grupo in grupoUserProcess.ObtenerListadoGrupos())
            {
                comboBox_SitiosR.Items.Add(grupo.Url);
            }
            
        }

        private void comboBox_Sitios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (comboBox_SitiosR.SelectedItem != null)
            {
                Grupo grupo = grupoUserProcess.ObtenerGrupoPorUrl(comboBox_SitiosR.SelectedItem.ToString());

                List<Contenido> contGrupo = contenidoUserProcess.ObtenerListadoPorGrupo(grupo.Id);

                

                List<Contenido> lconaux = new List<Contenido>();
               
                foreach (Contenido c in contGrupo)
                {
                    Contenido cont = contenidoUserProcess.ObtenerContenidoConMarcas(c.Id);
                    //int cantMarcas = convocatoriaUserProcess.ObtenerCantidadMarcasInadecuadoDeContenido(c.Id);
                    lconaux.Add(cont);     
                }
                datagrid_contenido.ItemsSource = lconaux;
            }
            else
            {
               // datagrid_contenido.ItemsSource = usuarioUserProcess.ObtenerListadoUsuarios();
            }      
        }

        private void boton_Salir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

     

    }
}
