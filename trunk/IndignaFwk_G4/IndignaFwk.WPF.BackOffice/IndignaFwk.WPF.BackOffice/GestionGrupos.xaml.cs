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
	/// <summary>
	/// Interaction logic for GestionGrupos.xaml
	/// </summary>
	public partial class GestionGrupos : Window
	{
        private GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;

		public GestionGrupos()
		{
			this.InitializeComponent();
            dataGrid_listaGrupos.ItemsSource = grupoUserProcess.ObtenerListadoGrupos();
		}

		private void boton_nuevoGrupo_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			e.Handled = true;
			
			CrearGrupo crearGrupoWindow = new CrearGrupo();
			crearGrupoWindow.Show();
		}

        private void OnHyperlinkClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Grupo grupoSeleccionado = grupoUserProcess.ObtenerGrupoPorId(((Grupo)this.dataGrid_listaGrupos.SelectedItem).Id);

            CrearGrupo crearGrupoWindow = new CrearGrupo(grupoSeleccionado);

            crearGrupoWindow.Show();
        }
	}
}