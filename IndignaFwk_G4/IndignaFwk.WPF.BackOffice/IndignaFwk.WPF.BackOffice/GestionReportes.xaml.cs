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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Forms;




namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for GestionReportes.xaml
	/// </summary>
	//RegistroTiempoReporte objRpt;
 
//CrystalReportViewer crystalReportViewer1;
    
    public partial class GestionReportes : Window
    {
        private SqlCommand command;   
        
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

        }
        
	}
}