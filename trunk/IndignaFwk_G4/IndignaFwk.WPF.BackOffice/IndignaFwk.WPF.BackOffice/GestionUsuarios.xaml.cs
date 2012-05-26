using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IndignaFwk.UI;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Util;

namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for GestionUsuarios.xaml
	/// </summary>
	public partial class GestionUsuarios : Window
	{
        UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;
        GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;

		public GestionUsuarios()
		{
			this.InitializeComponent();

            datagrid_usuarios.ItemsSource = usuarioUserProcess.ObtenerListadoUsuarios();
            foreach(Grupo grupo in grupoUserProcess.ObtenerListadoGrupos())
            {
                comboBox_Sitios.Items.Add(grupo.Url);
            }
        }

        private void comboBox_Sitios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usuarioUserProcess.
        }
	}
}