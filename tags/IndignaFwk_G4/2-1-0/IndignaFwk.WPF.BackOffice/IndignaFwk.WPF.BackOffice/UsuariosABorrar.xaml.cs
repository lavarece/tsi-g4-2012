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
    /// Interaction logic for UsuariosABorrar.xaml
    /// </summary>
    public partial class UsuariosABorrar : Window
    {
        UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;
        GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;
        ContenidoUserProcess contenidoUserProcess = UserProcessFactory.Instance.ContenidoUserProcess;
        SistemaUserProcess sistemaUserProcess = UserProcessFactory.Instance.SistemaUserProcess;
        
        public UsuariosABorrar()
        {
            this.InitializeComponent();

            List<Usuario> lUsuario = usuarioUserProcess.ObtenerListadoUsuarios();

            List<Usuario> lUsuarioAux = new List<Usuario>();
            
            foreach (Usuario u in lUsuario)
            {
                List<Contenido> lCont = contenidoUserProcess.ObtenerContenidoEliminadoPorUsuario(u.Id);
                int i = 0;
                foreach (Contenido c in lCont)
                {
                    i++;
                }
                if (i >= Convert.ToInt32(sistemaUserProcess.ObtenerVariablePorNombre("Dar de baja usuario").Valor))
                {
                    lUsuarioAux.Add(u);
                }
            }
            datagrid_usuariosBorrar.ItemsSource = lUsuarioAux;
        }
        
        private void boton_Salir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }

        private void eliminar_Usuario(object sender, RoutedEventArgs e)
        {
            List<Usuario> lUsuario = usuarioUserProcess.ObtenerListadoUsuarios();

            List<Usuario> lUsuarioAux = new List<Usuario>();
            
            foreach (Usuario u in lUsuario)
            {
                List<Contenido> lCont = contenidoUserProcess.ObtenerContenidoEliminadoPorUsuario(u.Id);
                int i = 0;
                foreach (Contenido c in lCont)
                {
                    i++;
                }
                if (i >= Convert.ToInt32(sistemaUserProcess.ObtenerVariablePorNombre("Dar de baja usuario").Valor))
                {
                    lUsuarioAux.Add(u);
                }
            }
            
            foreach (Usuario u in lUsuarioAux)
            {
                usuarioUserProcess.EliminarUsuario(u.Id);
            }
            MessageBox.Show("Se eliminaron los usuarios exitosamente");
            lUsuarioAux = null;
            datagrid_usuariosBorrar.ItemsSource = lUsuarioAux;
            
        }
       
    }
}
