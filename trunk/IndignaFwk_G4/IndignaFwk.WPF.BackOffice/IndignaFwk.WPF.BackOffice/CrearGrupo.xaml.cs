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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.UI.Process;

namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for CrearGrupo.xaml
	/// </summary>
	public partial class CrearGrupo : Window
	{
        IGrupoUserProcess interfazGrupo = null;

		public CrearGrupo(Login formLogin)
		{
            this.InitializeComponent();
        }
	}
}