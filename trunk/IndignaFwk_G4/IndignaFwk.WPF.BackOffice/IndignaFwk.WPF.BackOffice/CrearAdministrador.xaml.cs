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
using IndignaFwk.Common.Util;
using IndignaFwk.UI.Process;


namespace IndignaFwk_WPF_BackOffice
{
	public partial class CrearAdministrador : Window
	{
        private AdministradorUserProcess adminUserProcess = UserProcessFactory.Instance.AdministradorUserProcess;

		public CrearAdministrador()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void boton_guardarRegistroAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(textbox_nombreAdmin.Text))
            {
                MessageBox.Show("El campo nombre es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (String.IsNullOrEmpty(textbox_emailAdmin.Text))
            {
                MessageBox.Show("El campo email es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (String.IsNullOrEmpty(passwordbox_passAdmin.Password))
            {
                MessageBox.Show("El campo contraseña es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (String.IsNullOrEmpty(passwordBox_repassAdmin.Password))
            {
                MessageBox.Show("Debe repetir la contraseña", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!passwordBox_repassAdmin.Password.Equals(passwordbox_passAdmin.Password))
            {
                MessageBox.Show("Debe repetir la contraseña correctamente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                Administrador adminAux = adminUserProcess.ObtenerAdministradorPorEmailYPass(textbox_emailAdmin.Text, null);
                if (adminAux != null)
                {
                    MessageBox.Show("El email esta siendo usado por otro administrador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    Administrador admin = new Administrador();

                    admin.Nombre = textbox_nombreAdmin.Text;

                    admin.Email = textbox_emailAdmin.Text;

                    admin.Password = UtilesSeguridad.Encriptar(passwordbox_passAdmin.Password);

                    adminUserProcess.CrearNuevoAdministrador(admin);

                    MessageBox.Show("Administrador agregado satisfactoriamente", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);

                    this.Close();
                }
            }
            
        }

        private void boton_cancelarRegistroAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}