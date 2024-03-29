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
using IndignaFwk.Common.Entities;
using IndignaFwk.UI.Process;
using IndignaFwk.Common.Util;

namespace IndignaFwk_WPF_BackOffice
{
	/// <summary>
	/// Interaction logic for GestionVariables.xaml
	/// </summary>
	public partial class GestionVariables : Window
	{
        private SistemaUserProcess sistemaUserProcess = UserProcessFactory.Instance.SistemaUserProcess;

        public GestionVariables()
        {
            this.InitializeComponent();

            //Cargar valores de la variables
            
            VariableSistema vsistema = sistemaUserProcess.ObtenerVariablePorId(1);
            if (vsistema.Valor != null)
                Recursos_mas_rankeados.Text = vsistema.Valor;
           
            vsistema = sistemaUserProcess.ObtenerVariablePorId(2);
            if (vsistema.Valor != null)
                Recursos_compartidos.Text = vsistema.Valor;
              
            vsistema = sistemaUserProcess.ObtenerVariablePorId(3);
            if (vsistema.Valor != null)
                Dar_de_baja_contenido.Text = vsistema.Valor;
                    
            vsistema = sistemaUserProcess.ObtenerVariablePorId(4);
            if (vsistema.Valor != null)
                Dar_de_baja_usuario.Text = vsistema.Valor;
        }
        
        public void EditarVariables(VariableSistema variable)
		{
			this.InitializeComponent();

            sistemaUserProcess.EditarVariable(variable);

        }

        private void boton_cancelarRegistroVariables_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void boton_guardarRegistroVariables_Click(object sender, RoutedEventArgs e)
        {
           
            //Valido campos en blanco
            if (String.IsNullOrEmpty(Recursos_mas_rankeados.Text) || String.IsNullOrEmpty(Recursos_compartidos.Text) ||
                String.IsNullOrEmpty(Dar_de_baja_contenido.Text) || String.IsNullOrEmpty(Dar_de_baja_usuario.Text))
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            { 
                //Validar campos numericos
                int Value;
                if (!int.TryParse(Recursos_mas_rankeados.Text, out Value) || !int.TryParse(Recursos_compartidos.Text, out Value)
                    || !int.TryParse(Dar_de_baja_contenido.Text, out Value) || !int.TryParse(Dar_de_baja_usuario.Text, out Value))
                {
                    MessageBox.Show("Los campos deben ser enteros","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Recursos_mas_rankeados.Focus();
                    return;
                }
                else
                {
                    VariableSistema vsistema1 = sistemaUserProcess.ObtenerVariablePorId(1);
                    vsistema1.Valor = Recursos_mas_rankeados.Text;
                    EditarVariables(vsistema1);
                    VariableSistema vsistema2 = sistemaUserProcess.ObtenerVariablePorId(2);
                    vsistema2.Valor = Recursos_compartidos.Text;
                    EditarVariables(vsistema2);
                    VariableSistema vsistema3 = sistemaUserProcess.ObtenerVariablePorId(3);
                    vsistema3.Valor = Dar_de_baja_contenido.Text;
                    EditarVariables(vsistema3);
                    VariableSistema vsistema4 = sistemaUserProcess.ObtenerVariablePorId(4);
                    vsistema4.Valor = Dar_de_baja_usuario.Text;
                    EditarVariables(vsistema4);

                    MessageBox.Show("Los valores han sido guardados satisfactoriamente", "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    this.Close();
                
                }
            }          
        }
	}
}