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
using System.Data.SqlClient;
using System.Windows.Forms.Integration;
using System.Windows.Forms;




namespace IndignaFwk_WPF_BackOffice
{

    
    public partial class GestionReportes : Window
    {
       
        
        public GestionReportes()
		{
			this.InitializeComponent();
            
		}

		private void boton_Salir_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.Close();
		}

        private void boton_generarReporte_Click(object sender, RoutedEventArgs e)
        {
            if (listboxItem_registroTiempo.IsSelected)
            {
                ReporteUsuariosRegistradosTiempo ventanaReporte = new ReporteUsuariosRegistradosTiempo();
                ventanaReporte.Show();
            }
            else 
            {
                if (listboxItem_contenidoInadecuado.IsSelected)
                {
                    ReporteContenidoInadecuado ventanaReporte = new ReporteContenidoInadecuado();
                    ventanaReporte.Show();
                }

            }
        }
        
	}
}