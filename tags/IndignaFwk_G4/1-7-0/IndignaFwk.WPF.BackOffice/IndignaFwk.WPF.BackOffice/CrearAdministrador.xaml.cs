﻿using System;
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
            if (String.IsNullOrEmpty(textbox_nombreAdmin.Text))
            {
                MessageBox.Show("El campo nombre es obligatorio");
            }
            //else if (String.IsNullOrEmpty(textBox_apellidoAdmin.Text))
            //{
            //    MessageBox.Show("El campo apellido es obligatorio");
            //}
            else if (String.IsNullOrEmpty(textbox_emailAdmin.Text))
            {
                MessageBox.Show("El campo email es obligatorio");
            }
            else if (String.IsNullOrEmpty(passwordbox_passAdmin.Password))
            {
                MessageBox.Show("El campo contraseña es obligatorio");
            }
            else if (String.IsNullOrEmpty(passwordBox_repassAdmin.Password))
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