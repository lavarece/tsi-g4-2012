using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using IndignaFwk_WPF_BackOffice.Reportes;
using IndignaFwk_WPF_BackOffice;

namespace IndignaFwk.WPF.BackOffice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PoblarReporte();
        }



        //Metodo Para poblar el reporte
        private void PoblarReporte()
        {
            try
            {
                RegistroTiempoReporte Informe = new RegistroTiempoReporte();
                GestionReportes gr = new GestionReportes();
                Informe = gr.PoblarReporteRegistroTiempo();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
