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
	/// Interaction logic for GestionGrupos.xaml
	/// </summary>
	public partial class GestionGrupos : Window
	{
		public GestionGrupos()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

		private void boton_nuevoGrupo_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			e.Handled = true;
			
			CrearGrupo crearGrupoWindow = new CrearGrupo();
			crearGrupoWindow.Show();
		}
	}
}