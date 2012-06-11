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
using System.Windows.Threading;

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

        string latitud;

        string longitud;

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
            int indexAux = 0;

            this.InitializeComponent();
            txt_nombre.Text = grupo.Nombre;
            txt_url.Text = grupo.Url;
            if(String.IsNullOrEmpty(grupo.Descripcion))
            {
                txt_descripcion.Text = grupo.Descripcion;
            }

            List<Layout> listaLayouts = sistemaUserProcess.ObtenerListadoLayouts();
            comboBox_layouts.ItemsSource = listaLayouts;

            for (int i = 0; i < listaLayouts.Count; i++)
            {
                if (listaLayouts[0].Id == grupo.Layout.Id)
                {
                    indexAux = i;
                    break;
                }
            }

            comboBox_layouts.SelectedIndex = indexAux;

            List<Tematica> listaTematica = sistemaUserProcess.ObtenerListadoTematicas();
            comboBox_temas.ItemsSource = listaTematica;
            
            for (int i = 0; i < listaTematica.Count; i++)
            {
                if (listaTematica[0].Id == grupo.Tematica.Id)
                {
                    indexAux = i;
                    break;
                }
            }

            comboBox_temas.SelectedIndex = indexAux;

            char[] delimiterChars = {','};

            string[] arrayCoordenadas = grupo.Coordenadas.Split(delimiterChars);

            longitud = arrayCoordenadas[0];
            latitud = arrayCoordenadas[1];

            coordenadas.Content = grupo.Coordenadas;

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
            else if (!editando && win.latitud == null)
            {
                mensaje = new MensajeError("La ubicación del grupo es obligatoria");
                mensaje.Show();
            }
            else
            {
                Grupo grupo = new Grupo();

                grupo.Nombre = txt_nombre.Text;

                grupo.Descripcion = txt_descripcion.Text;

                grupo.Coordenadas = longitud + "," + latitud;

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
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();

            win.Show();
        }

        private void btn_refrescarCoordenadas_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            coordenadas.Content = "(" + win.longitud + "," + win.latitud + ")";
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            coordenadas.Content = "(" + win.longitud + "," + win.latitud + ")";
            latitud = win.latitud;
            longitud = win.longitud;
        }
    }
}