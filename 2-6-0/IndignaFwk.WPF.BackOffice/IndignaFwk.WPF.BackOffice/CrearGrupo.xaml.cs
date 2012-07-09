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
using IndignaFwk.Common.Enumeration;

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

        Window1 winGoogleMaps;

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
            if(!String.IsNullOrEmpty(grupo.Descripcion))
            {
                txt_descripcion.Text = grupo.Descripcion;
            }

            List<Layout> listaLayouts = sistemaUserProcess.ObtenerListadoLayouts();
            comboBox_layouts.ItemsSource = listaLayouts;

            for (int i = 0; i < listaLayouts.Count; i++)
            {
                if (listaLayouts[i].Id == grupo.Layout.Id)
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
                if (listaTematica[i].Id == grupo.Tematica.Id)
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
            List<FuenteExternaGrupo> lf = grupo.FuentesExternas; 

            foreach (FuenteExternaGrupo f in lf)
            {
                if (f.FuenteExterna == "YOU_TUBE")
                {
                    chk_fuente_youtube.IsChecked = true;

                    txt_keywords_youtube.Text = f.QueryString;

                    txt_resultados_youtube.Text = f.CantidadResultados.ToString();

                }
                else
                {
                    if (f.FuenteExterna == "WIKIPEDIA")
                    {
                        chk_fuente_wikipedia.IsChecked = true;

                        txt_keywords_wikipedia.Text = f.QueryString;

                        txt_resultados_wikipedia.Text = f.CantidadResultados.ToString();
                    }
                }
            }

            text_facebook.Text = grupo.AppIDFacebook.ToString();

            grupoEditando = grupo;

            editando = true;
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            if (validarCreacionGrupo())
            {
                Grupo grupo = new Grupo();

                grupo.Nombre = txt_nombre.Text;

                grupo.Descripcion = txt_descripcion.Text;

                grupo.Coordenadas = longitud + "," + latitud;

                grupo.Url = txt_url.Text;

                grupo.Layout = (Layout)comboBox_layouts.SelectedItem;

                grupo.Tematica = (Tematica)comboBox_temas.SelectedItem;

                grupo.FuentesExternas = new List<FuenteExternaGrupo>();

                if (chk_fuente_youtube.IsChecked == true)
                {
                    FuenteExternaGrupo fuenteExternaGrupo = new FuenteExternaGrupo();

                    fuenteExternaGrupo.FuenteExterna = FuenteExternaEnum.YOU_TUBE.Valor;

                    fuenteExternaGrupo.QueryString = txt_keywords_youtube.Text;

                    fuenteExternaGrupo.CantidadResultados = Int32.Parse(txt_resultados_youtube.Text);

                    grupo.FuentesExternas.Add(fuenteExternaGrupo);
                }

                if (chk_fuente_wikipedia.IsChecked == true)
                {
                    FuenteExternaGrupo fuenteExternaGrupo = new FuenteExternaGrupo();

                    fuenteExternaGrupo.FuenteExterna = FuenteExternaEnum.WIKIPEDIA.Valor;

                    fuenteExternaGrupo.QueryString = txt_keywords_wikipedia.Text;

                    fuenteExternaGrupo.CantidadResultados = Int32.Parse(txt_resultados_wikipedia.Text);

                    grupo.FuentesExternas.Add(fuenteExternaGrupo);
                }
                grupo.AppIDFacebook = text_facebook.Text;


                if (editando)
                {
                    grupo.Id = grupoEditando.Id;
                    grupoUserProcess.EditarGrupo(grupo);
                }
                else
                {
                    grupoUserProcess.CrearNuevoGrupo(grupo);
                }

                MessageBox.Show("Operación completada exitosamente", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }            
        }

        private bool validarCreacionGrupo()
        {            
            if (String.IsNullOrEmpty(txt_nombre.Text))
            {
                MessageBox.Show("El campo nombre es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (String.IsNullOrEmpty(txt_url.Text))
            {
                MessageBox.Show("El campo URL es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (comboBox_layouts.SelectedItem == null)
            {
                MessageBox.Show("El campo Layouts es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (comboBox_temas.SelectedItem == null)
            {
                MessageBox.Show("El campo Temas es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!editando && winGoogleMaps.latitud == null)
            {
                MessageBox.Show("La ubicación del grupo es obligatoria", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }            
            if (chk_fuente_youtube.IsChecked == true)
            {
                if (String.IsNullOrEmpty(txt_keywords_youtube.Text))
                {
                    MessageBox.Show("El campo palabras claves you tube es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (String.IsNullOrEmpty(txt_resultados_youtube.Text))
                {
                    MessageBox.Show("El campo resultados you tube es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (!String.IsNullOrEmpty(txt_resultados_youtube.Text))
                {
                    try
                    {
                        Int32.Parse(txt_resultados_youtube.Text);
                    }
                    catch (Exception e2)
                    {
                        MessageBox.Show("El campo resultados you tube debe contener un número", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
            if (chk_fuente_wikipedia.IsChecked == true)
            {
                if (String.IsNullOrEmpty(txt_keywords_wikipedia.Text))
                {
                    MessageBox.Show("El campo palabras claves wikipedia es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (String.IsNullOrEmpty(txt_resultados_wikipedia.Text))
                {
                    MessageBox.Show("El campo resultados wikipedia es obligatorio", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (!String.IsNullOrEmpty(txt_resultados_wikipedia.Text))
                {
                    try
                    {
                        Int32.Parse(txt_resultados_wikipedia.Text);
                    }
                    catch (Exception e2)
                    {
                        MessageBox.Show("El campo resultados wikipedia debe contener un número", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }

            return true;
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

            winGoogleMaps = new Window1();
            winGoogleMaps.Show();
        }

        private void btn_refrescarCoordenadas_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            coordenadas.Content = "(" + winGoogleMaps.longitud + "," + winGoogleMaps.latitud + ")";
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            coordenadas.Content = "(" + winGoogleMaps.longitud + "," + winGoogleMaps.latitud + ")";
            latitud = winGoogleMaps.latitud;
            longitud = winGoogleMaps.longitud;
        }        
    }
}