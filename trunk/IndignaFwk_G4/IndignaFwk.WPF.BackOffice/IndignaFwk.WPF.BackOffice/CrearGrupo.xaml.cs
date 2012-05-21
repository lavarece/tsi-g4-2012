using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.UI;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process;

namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for CrearGrupo.xaml
	/// </summary>
	public partial class CrearGrupo : Window
	{
        private GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;
		
        public CrearGrupo()
		{
            this.InitializeComponent();
        }

        private void boton_guardar_Click(object sender, RoutedEventArgs e)
        {
            Grupo grupo = new Grupo();
            grupo.Nombre = textBox_nombreDeSitio.Text;
            grupo.Descripcion = "NO CORRESPONDE";
            grupo.LogoUrl = "NO CORRESPONDE";
            grupo.Url = "localhost";
            //grupo.ListaContenido = "123";
            //grupo.ListaImagen = "123";

            grupoUserProcess.CrearGrupo(grupo);
        }

        private void boton_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

	}
}