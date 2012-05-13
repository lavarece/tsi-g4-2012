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

namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window
	{
		public Login()
		{
			this.InitializeComponent();

			// Insert code required on object creation below this point.
		}

		private void botonLogin_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Add event handler implementation here.
			e.Handled = true;
			
			//Si las Credenciales son Correcas entonces Accedera
			//al Menú principal
			
			Home homeWindow = new Home(textBox_Usuario.Text);
			homeWindow.Show();
			this.Hide();		
		}
	}
}