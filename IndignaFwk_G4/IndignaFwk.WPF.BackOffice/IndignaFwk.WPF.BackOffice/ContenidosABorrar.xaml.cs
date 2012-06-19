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
        ConvocatoriaUserProcess convocatoriaUserProcess = UserProcessFactory.Instance.ConvocatoriaUserProcess;
        
        public ContenidosABorrar()
        {
           //this.InitializeComponent();
             //List<Contenido> lCont = convocatoriaUserProcess.ob

        }

        //private void boton_Salir_Click(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    this.Close();
        //}

      
    }
}
