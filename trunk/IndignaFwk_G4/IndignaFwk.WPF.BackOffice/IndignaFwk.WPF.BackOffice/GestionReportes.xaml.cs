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
using System.Data.SqlClient;
using IndignaFwk_WPF_BackOffice.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Forms;
using IndignaFwk.WPF.BackOffice;



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

        //Metodo Para poblar el reporte
        public RegistroTiempoReporte PoblarReporteRegistroTiempo()
        {
            
            //Definimos las sentencias las cuales seleccionan todo los datos
            string SqlUsuario = "Select * from Usuario";
          
            RegistroTiempo dataSetTiempo = new RegistroTiempo();

            CrystalReportViewer crystalReportViewer1 = new CrystalReportViewer();

            //creamos los data adapters
            SqlConnection Conne = new SqlConnection("Data Source=.;Initial Catalog=IndignadoFDb;Persist Security Info=True;User ID=indigna_usr;Password=indigna_usr");

            try
            {
                
                Conne.Open();

                command = Conne.CreateCommand();

                command.Connection = Conne;

                command.CommandText = "Select * from Sitio";


                //SqlDataAdapter SqlDaUsuario = new SqlDataAdapter(SqlUsuario, Conne);
                SqlDataAdapter SqlDaSitio = new SqlDataAdapter("Select * from Sitio", Conne);

                // empezamos a poblar las tablas del Data Set Tipado
                SqlDaSitio.Fill(dataSetTiempo, "Sitio");
                //SqlDaUsuario.Fill(dataSetTiempo, "Usuario");

                //Ahora Poblamos el informe y lo mostramos 
                RegistroTiempoReporte Informe = new RegistroTiempoReporte();
                Informe.SetDataSource(dataSetTiempo);
                crystalReportViewer1.ReportSource = Informe;

                return Informe;
                
            }
            catch (Exception e)
            {

                System.Windows.MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                Conne.Close();
            }
           
        }

        private void boton_generarReporte_Click(object sender, RoutedEventArgs e)
        {
            if (listboxItem_registroTiempo.IsSelected)
            {
                Form1 ventana = new Form1();
                ventana.Show();                              
            }
            else 
            {
            
            }
        }


        
	}
}