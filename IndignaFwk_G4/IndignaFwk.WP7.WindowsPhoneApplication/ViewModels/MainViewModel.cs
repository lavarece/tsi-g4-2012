﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceUsuario;
using IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceConvocatoria;
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps.Platform;


namespace IndignaFwk_WP7_WindowsPhoneApplication
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Grupo1 = new ObservableCollection<ItemViewModel>();
            this.Grupo2 = new ObservableCollection<ItemViewModel>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Grupo1 { get; private set; }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Grupo2 { get; private set; }

        private string _sampleProperty = "Sample Runtime Property Value";
        /// <summary>
        /// Sample ViewModel property; this property is used in the view to display its value using a Binding
        /// </summary>
        /// <returns></returns>
        public string SampleProperty
        { 
            get
            {
                return _sampleProperty;
            }
            set
            {
                _sampleProperty = value;
                NotifyPropertyChanged("SampleProperty");
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            ServiceReferenceConvocatoria.ConvocatoriaServiceClient proxy = new ServiceReferenceConvocatoria.ConvocatoriaServiceClient();

            proxy.ObtenerListadoConvocatoriasPorGrupoAsync(1);
            proxy.ObtenerListadoConvocatoriasPorGrupoCompleted +=new EventHandler<ObtenerListadoConvocatoriasPorGrupoCompletedEventArgs>(proxy_ObtenerListadoConvocatoriasPorGrupoCompleted); 

            // Sample data; replace with real data
           
           
            this.IsDataLoaded = true;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void proxy_ObtenerListadoConvocatoriasPorGrupoCompleted(object sender, ObtenerListadoConvocatoriasPorGrupoCompletedEventArgs e)
        {
            Collection<IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceConvocatoria.Convocatoria> listaConvocatorias = e.Result;

            foreach(IndignaFwk_WP7_WindowsPhoneApplication.ServiceReferenceConvocatoria.Convocatoria convocatoria in listaConvocatorias)
            {

                Map mapMain = new Map();
                // Update the map to show the current location
                Location ppLoc = new Location();
                ppLoc.Latitude = 7.62;
                ppLoc.Longitude = 19.68;
                mapMain.SetView(ppLoc, 10);          

                this.Grupo1.Add(new ItemViewModel() { LineOne = convocatoria.Titulo, LineTwo = convocatoria.Descripcion});
                this.Grupo2.Add(new ItemViewModel() { LineOne = convocatoria.Titulo, LineTwo = "Descripcion: " + convocatoria.Descripcion, LineThree = "Fecha Inicio: " + convocatoria.FechaInicio,
                                                      LineFour = "Fecha Fin: " + convocatoria.FechaInicio, LineFive = "Localización: " + convocatoria.Coordenadas,
                                                      LineSix = mapMain});

            
            }
        }
    }
}