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
using GoogleMapsFlashInWpf;
using GoogleMapsFlashInWpf.Properties;

namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for CrearGrupo.xaml
	/// </summary>
    public partial class CrearGrupo : Window
    {
        private GrupoUserProcess grupoUserProcess = UserProcessFactory.Instance.GrupoUserProcess;

        private SistemaUserProcess sistemaUserProcess = UserProcessFactory.Instance.SistemaUserProcess;

        private Boolean editando;

        private Grupo grupoEditando;

        Window1 win = new Window1();

        public CrearGrupo()
        {
            this.InitializeComponent();
            editando = false;

            List<Layout> listaLayouts = sistemaUserProcess.ObtenerListadoLayouts();
            comboBox_layouts.ItemsSource = listaLayouts;
            
            List<Tematica> listaTematica = sistemaUserProcess.ObtenerListadoTematicas();
            comboBox_temas.ItemsSource = listaTematica;
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

            List<Layout> listaLayouts = sistemaUserProcess.ObtenerListadoLayouts();
            comboBox_layouts.ItemsSource = listaLayouts;
            comboBox_layouts.SelectedItem = grupo.Layout;

            List<Tematica> listaTematica = sistemaUserProcess.ObtenerListadoTematicas();
            comboBox_temas.ItemsSource = listaTematica;
            comboBox_temas.SelectedItem = grupo.Tematica;

            grupoEditando = grupo;

            editando = true;
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            MensajeError mensaje;

            if (String.IsNullOrEmpty(txt_nombre.Text))
            {
                mensaje= new MensajeError("El campo nombre es obligatorio");
                mensaje.Show();
            }
            else if (String.IsNullOrEmpty(txt_url.Text))
            {
                mensaje = new MensajeError("El campo URL es obligatorio");
                mensaje.Show();
            }
            else if (comboBox_layouts.SelectedItem == null)
            {
                mensaje = new MensajeError("El campo Layouts es obligatorio");
                mensaje.Show();
            }
            else if (comboBox_temas.SelectedItem == null)
            {
                mensaje = new MensajeError("El campo Temas es obligatorio");
                mensaje.Show();
            }
            else
            {
                Grupo grupo = new Grupo();

                grupo.Nombre = txt_nombre.Text;

                grupo.Descripcion = txt_descripcion.Text;

                grupo.Url = txt_url.Text;

                grupo.Layout = (Layout)comboBox_layouts.SelectedItem;

                grupo.Tematica = (Tematica)comboBox_temas.SelectedItem;

                if (editando)
                {
                    grupo.Id = grupoEditando.Id;
                    grupoUserProcess.EditarGrupo(grupo);
                }
                else 
                {
                    grupoUserProcess.CrearNuevoGrupo(grupo);
                }

                mensaje = new MensajeError("Operacion completada exitosamente!");
                mensaje.Show();
                this.Close();
            }
        }

        private void btn_cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_abrirMapa_Click(object sender, System.Windows.RoutedEventArgs e)
        {           
            win.Show();
        }

        private void btn_refrescarCoordenadas_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            longitud.Content ="Longitud: " + win.longitud;
            latitud.Content = "Latitud: " + win.latitud;
        }
    }
}