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
		}

        private void btn_iniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            Home homeWindow = new Home(txt_usuario.Text);

            homeWindow.Show();

            this.Close();
        }
	}
}