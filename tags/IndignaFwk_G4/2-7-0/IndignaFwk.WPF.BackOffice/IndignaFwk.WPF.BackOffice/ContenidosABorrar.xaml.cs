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
    /// Interaction logic for ContenidosABorrar.xaml
    /// </summary>
    public partial class ContenidosABorrar : Window
    {
        UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;
        GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;
        ContenidoUserProcess contenidoUserProcess = UserProcessFactory.Instance.ContenidoUserProcess;
        SistemaUserProcess sistemaUserProcess = UserProcessFactory.Instance.SistemaUserProcess;
        
        public ContenidosABorrar()
        {
            this.InitializeComponent();

            List<Grupo> lGrup = grupoUserProcess.ObtenerListadoGrupos();
            List<Contenido> lContAux = new List<Contenido>();
            foreach (Grupo g in lGrup)
            {
                List<Contenido> lCont = contenidoUserProcess.ObtenerListadoPorGrupoNoEliminado(g.Id);
                
                foreach (Contenido c in lCont)
                { 
                    if (c.CantidadInadecuado >= Convert.ToInt32(sistemaUserProcess.ObtenerVariablePorNombre("Dar de baja contenido").Valor))
                    {
                        lContAux.Add(c);
                    }
                }
                
            }
            datagrid_contenidoBorrar.ItemsSource = lContAux;
        }

        private void boton_Salir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void eliminar_Contenido(object sender, RoutedEventArgs e)
        {
            List<Grupo> lGrup = grupoUserProcess.ObtenerListadoGrupos();
            List<Contenido> lContAux = new List<Contenido>();
            foreach (Grupo g in lGrup)
            {
                List<Contenido> lCont = contenidoUserProcess.ObtenerListadoPorGrupoNoEliminado(g.Id);

                foreach (Contenido c in lCont)
                {
                    if (c.CantidadInadecuado >= Convert.ToInt32(sistemaUserProcess.ObtenerVariablePorNombre("Dar de baja contenido").Valor))
                    {
                        lContAux.Add(c);
                    }
                }
            }
            
            foreach (Contenido c in lContAux)
            {
                contenidoUserProcess.EliminarListaContenido(c.Id);
                MessageBox.Show("Se eliminaron los contenidos exitosamente");
            }
            
            lContAux = null;
            datagrid_contenidoBorrar.ItemsSource = lContAux;
            
        }
      
    }
}
