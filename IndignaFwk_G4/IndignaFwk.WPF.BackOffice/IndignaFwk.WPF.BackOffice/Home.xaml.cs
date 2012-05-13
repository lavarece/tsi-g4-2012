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
			CrearGrupo crearGrupoWindow = new CrearGrupo();
			crearGrupoWindow.Show();
		}
	}
}