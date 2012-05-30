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
using IndignaFwk.UI;
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Util;

namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for CrearGrupo.xaml
	/// </summary>
    public partial class CrearGrupo : Window
    {
        private GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;
        private Boolean editando;
        private Grupo grupoEditando;


        public CrearGrupo()
        {
            this.InitializeComponent();
            editando = false;
        }

        public CrearGrupo(Grupo grupo)
        {
            this.InitializeComponent();
            txt_nombre.Text = grupo.Nombre;
            txt_url.Text = grupo.Url;
            if(String.IsNullOrEmpty(grupo.Descripcion))
            {
                txt_descripcion.Text = grupo.Descripcion;
            }

            grupoEditando = grupo;

            editando = true;
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txt_nombre.Text))
            {
                MessageBox.Show("El campo nombre es obligatorio");
            }
            else if (String.IsNullOrEmpty(txt_url.Text))
            {
                MessageBox.Show("El campo URL es obligatorio");
            }
            else
            {
                Grupo grupo = new Grupo();

                grupo.Nombre = txt_nombre.Text;

                grupo.Descripcion = txt_descripcion.Text;

                grupo.Url = txt_url.Text;

                if (editando)
                {
                    grupo.Id = grupoEditando.Id;
                    grupoUserProcess.EditarGrupo(grupo);
                }
                else 
                {
                    grupoUserProcess.CrearNuevoGrupo(grupo);
                }                
            }
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}