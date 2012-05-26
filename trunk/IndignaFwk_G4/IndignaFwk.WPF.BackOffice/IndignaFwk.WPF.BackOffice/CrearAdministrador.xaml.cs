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
            if (UtilesGenerales.isNullOrEmpty(textbox_nombreAdmin.Text))
            {
                MessageBox.Show("El campo nombre es obligatorio");
            }
            //else if (UtilesGenerales.isNullOrEmpty(textBox_apellidoAdmin.Text))
            //{
            //    MessageBox.Show("El campo apellido es obligatorio");
            //}
            else if (UtilesGenerales.isNullOrEmpty(textbox_emailAdmin.Text))
            {
                MessageBox.Show("El campo email es obligatorio");
            }
            else if (UtilesGenerales.isNullOrEmpty(passwordbox_passAdmin.Password))
            {
                MessageBox.Show("El campo contraseña es obligatorio");
            }
            else if (UtilesGenerales.isNullOrEmpty(passwordBox_repassAdmin.Password))
            {
                MessageBox.Show("Debe repetir la contraseña");
            }
            else if (passwordBox_repassAdmin.Password.Equals(passwordbox_passAdmin.Password))
            {
                MessageBox.Show("Debe repetir la contraseña correctamente");
            }
            else
            {
                Administrador admin = new Administrador();

                admin.Nombre = textbox_nombreAdmin.Text;

                admin.Email = textbox_emailAdmin.Text;
                
                admin.Password = passwordbox_passAdmin.Password;

                adminUserProcess.CrearNuevoAdministrador(admin);

                MessageBox.Show("Administrador agregado satisfactoriamente!");

                this.Close();
            }
        }
	}
}