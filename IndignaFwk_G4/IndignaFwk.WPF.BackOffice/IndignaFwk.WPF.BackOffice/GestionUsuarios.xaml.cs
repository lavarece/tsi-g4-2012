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
	/// <summary>
	/// Interaction logic for GestionUsuarios.xaml
	/// </summary>
	public partial class GestionUsuarios : Window
	{
        UsuarioUserProcess usuarioUserProcess = UserProcessFactory.Instance.UsuarioUserProcess;
        GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;

		public GestionUsuarios()
		{
			this.InitializeComponent();

            List<Usuario> listaUsuarios = usuarioUserProcess.ObtenerListadoUsuarios();
            datagrid_usuarios.ItemsSource = listaUsuarios;
            foreach(Grupo grupo in grupoUserProcess.ObtenerListadoGrupos())
            {
                comboBox_Sitios.Items.Add(grupo.Url);
            }
        }

        private void comboBox_Sitios_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Grupo grupo = grupoUserProcess.ObtenerGrupoPorUrl(comboBox_Sitios.SelectedItem.ToString());

            datagrid_usuarios.ItemsSource = usuarioUserProcess.ObtenerUsuariosPorIdGrupo(grupo.Id);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            if (this.datagrid_usuarios.SelectedItem != null)
            {
                int i = ((Usuario)this.datagrid_usuarios.SelectedItem).Id;

                usuarioUserProcess.EliminarUsuario(i);
                
                MessageBox.Show("Usuario eliminado correctamente", "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No ha seleccionado ningún usuario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
            
            if (comboBox_Sitios.SelectedItem != null)
            {
                Grupo grupo = grupoUserProcess.ObtenerGrupoPorUrl(comboBox_Sitios.SelectedItem.ToString());
                datagrid_usuarios.ItemsSource = usuarioUserProcess.ObtenerUsuariosPorIdGrupo(grupo.Id);
            }
            else
            {
                datagrid_usuarios.ItemsSource = usuarioUserProcess.ObtenerListadoUsuarios();
            }
        }

        private void boton_Salir_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }
	}
}