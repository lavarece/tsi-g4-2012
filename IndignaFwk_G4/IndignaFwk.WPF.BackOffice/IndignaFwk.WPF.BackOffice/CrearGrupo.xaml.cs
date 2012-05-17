using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.UI.Process.GrupoReference;
using IndignaFwk.UI;
using IndignaFwk.Common.Entities;

namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for CrearGrupo.xaml
	/// </summary>
	public partial class CrearGrupo : Window
	{
        private IndignaFwk.UI.Process.IGrupoUserProcess _GrupoUserProcess = IndignaFwk.UI.Process.UserProcessFactory.Instance.GrupoUserProcess;
		
        public CrearGrupo()
		{
            this.InitializeComponent();
        }

        private void boton_guardar_Click(object sender, RoutedEventArgs e)
        {
            Grupo grupo = new Grupo();
            grupo.Nombre = textBox_nombreDeSitio.Text;
            _GrupoUserProcess.CrearGrupo(grupo);
        }

        private void boton_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

	}
}