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
    /// Interaction logic for ReporteUsuariosRegistradosTiempo.xaml
    /// </summary>
    public partial class ReporteUsuariosRegistradosTiempo : Window
    {
        UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;
        GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;

        public ReporteUsuariosRegistradosTiempo()
		{
			this.InitializeComponent();

           // List<Usuario> listaUsuarios = usuarioUserProcess.ObtenerListadoUsuarios();
            //datagrid_usuariosR.ItemsSource = listaUsuarios;
            foreach(Grupo grupo in grupoUserProcess.ObtenerListadoGrupos())
            {
                comboBox_SitiosR.Items.Add(grupo.Url);
            }
            
            Desplegar_Calendario.SelectedDate = DateTime.Today;

        }

        private void comboBox_Sitios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if (comboBox_SitiosR.SelectedItem != null)
            {
                Grupo grupo = grupoUserProcess.ObtenerGrupoPorUrl(comboBox_SitiosR.SelectedItem.ToString());

                List<Usuario> lus = usuarioUserProcess.ObtenerUsuariosPorIdGrupo(grupo.Id);
                List<Usuario> lusex = new List<Usuario>();
                foreach (Usuario u in lus)
                {
                    DateTime Dselect = Desplegar_Calendario.DisplayDate;
                    int m = Dselect.Month;

                    DateTime st = u.FechaRegistro;
                    int month = st.Month;

                    if (m == month)
                    {
                        lusex.Add(u);

                    }
                }
                datagrid_usuariosR.ItemsSource = lusex;
            }
            else
            {
                datagrid_usuariosR.ItemsSource = usuarioUserProcess.ObtenerListadoUsuarios();
            }      
        }

        
        private void boton_Salir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void Desplegar_Calendario_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
      

            if (Desplegar_Calendario.SelectedDate != DateTime.Today )
            {
                Grupo grupo = grupoUserProcess.ObtenerGrupoPorUrl(comboBox_SitiosR.SelectedItem.ToString());

                List<Usuario> lus = usuarioUserProcess.ObtenerUsuariosPorIdGrupo(grupo.Id);
                List<Usuario> lusex = new List<Usuario>();
                foreach (Usuario u in lus)
                {
                    DateTime Dselect = Desplegar_Calendario.DisplayDate;
                    int m = Dselect.Month;

                    DateTime st = u.FechaRegistro;
                    int month = st.Month;

                    if (m == month)
                    {
                        lusex.Add(u);
                       
                    }
                }
                datagrid_usuariosR.ItemsSource = lusex;
            }
           
        }       
    }
}
