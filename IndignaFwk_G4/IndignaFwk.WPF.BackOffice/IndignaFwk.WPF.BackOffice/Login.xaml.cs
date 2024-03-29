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
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Util;

namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for Login.xaml
	/// </summary>
	public partial class Login : Window
	{
        AdministradorUserProcess adminUserProcess = UserProcessFactory.Instance.AdministradorUserProcess;

		public Login()
		{
			this.InitializeComponent();
		}

        private void btn_iniciarSesion_Click(object sender, RoutedEventArgs e)
        {

            //Encriptando password para compararlo en la base de datos
            string passEncriptado = UtilesSeguridad.Encriptar(txt_password.Password);

            Administrador admin = adminUserProcess.ObtenerAdministradorPorEmailYPass(txt_usuario.Text, passEncriptado);

           if (admin != null)
           {
                Home1 homeWindow = new Home1(txt_usuario.Text);

                homeWindow.Show();

                this.Close();
           }
           else
           {
               MessageBox.Show("Email y Contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);               
           }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
	}
}