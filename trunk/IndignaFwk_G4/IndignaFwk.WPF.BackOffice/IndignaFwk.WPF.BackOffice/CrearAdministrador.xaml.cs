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
            MensajeError mensaje;
            if (String.IsNullOrEmpty(textbox_nombreAdmin.Text))
            {
                mensaje = new MensajeError("El campo nombre es obligatorio");
                mensaje.Show();
            }
            else if (String.IsNullOrEmpty(textbox_emailAdmin.Text))
            {
                mensaje = new MensajeError("El campo email es obligatorio");
                mensaje.Show();
            }
            else if (String.IsNullOrEmpty(passwordbox_passAdmin.Password))
            {
                mensaje = new MensajeError("El campo contraseña es obligatorio");
                mensaje.Show();
            }
            else if (String.IsNullOrEmpty(passwordBox_repassAdmin.Password))
            {
                mensaje = new MensajeError("Debe repetir la contraseña");
                mensaje.Show();
            }
            else if (!passwordBox_repassAdmin.Password.Equals(passwordbox_passAdmin.Password))
            {
                mensaje = new MensajeError("Debe repetir la contraseña correctamente");
                mensaje.Show();
            }
            else
            {
                Administrador admin = new Administrador();

                admin.Nombre = textbox_nombreAdmin.Text;

                admin.Email = textbox_emailAdmin.Text;
                
                admin.Password = UtilesSeguridad.Encriptar(passwordbox_passAdmin.Password);

                adminUserProcess.CrearNuevoAdministrador(admin);

                MessageBox.Show("Administrador agregado satisfactoriamente!");

                this.Close();
            }
        }

        private void boton_cancelarRegistroAdmin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}