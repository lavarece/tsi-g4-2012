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
	/// Interaction logic for GestionAdministradores.xaml
	/// </summary>
	public partial class GestionAdministradores : Window
	{
        private AdministradorUserProcess adminUserProcess = UserProcessFactory.Instance.AdministradorUserProcess;

		public GestionAdministradores()
		{
			this.InitializeComponent();
            datagrid_administradores.ItemsSource = adminUserProcess.ObtenerListadoAdministradores();
		}

		private void boton_nuevoAdministrador_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			CrearAdministrador crearAdminWindow = new CrearAdministrador();
			crearAdminWindow.Show();
		}
	}
}