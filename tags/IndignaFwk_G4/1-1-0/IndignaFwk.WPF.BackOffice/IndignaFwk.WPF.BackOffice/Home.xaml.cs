using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for Home.xaml
	/// </summary>
	public partial class Home : Window
	{
		public Home(string nombreUsuario)
		{
			this.InitializeComponent();
			label_bienvenido.Content = label_bienvenido.Content + nombreUsuario;
		}

		private void boton_gestionGrupo_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GestionGrupos gestionGruposWindow = new GestionGrupos();
			gestionGruposWindow.Show();
		}

		private void boton_gestionRep_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GestionReportes gestionReportesWindow = new GestionReportes();
			gestionReportesWindow.Show();
		}

		private void boton_gestionAdmin_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GestionAdministradores gestionAdminWindow = new GestionAdministradores();
			gestionAdminWindow.Show();
		}

		private void boton_gestionUsu_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GestionUsuarios gestionUsuariosWindow = new GestionUsuarios();
			gestionUsuariosWindow.Show();
		}

		private void boton_gestionVar_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			GestionVariables gestionVarWindow = new GestionVariables();
			gestionVarWindow.Show();
		}
	}
}