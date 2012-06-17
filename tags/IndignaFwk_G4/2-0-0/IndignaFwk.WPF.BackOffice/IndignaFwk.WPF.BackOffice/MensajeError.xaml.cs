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
	/// Interaction logic for MensajeError.xaml
	/// </summary>
	public partial class MensajeError : Window
	{
		public MensajeError(String mensaje)
		{
			this.InitializeComponent();
            label_mensajeError.Content = mensaje;
		}

		private void boton_aceptar_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Close();
		}
	}
}