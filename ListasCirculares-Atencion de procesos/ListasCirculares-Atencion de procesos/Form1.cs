﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListasCirculares_Atencion_de_procesos
{
    public partial class Form1 : Form
    {
        static Random procesos = new Random();
        Procesador procesador = new Procesador();

        public Form1()
        {
            InitializeComponent();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            int pLibres = 0;
            int contadorP = 0;
            int ciclosAtencion = 0;
            txtResultados.Clear();
            txtResultados.Clear();

            for (int i = 1; i <= 200; i++)
            {
                if (procesos.Next(0, 101) <= 25)
                {
                    contadorP++;
                    Proceso nuevoP = new Proceso();
                    procesador.push(nuevoP);
                    txtResultados.Text += "Proceso No." + contadorP + " con " + nuevoP._ciclosProceso + " ciclos." + Environment.NewLine;
                    ciclosAtencion = nuevoP._ciclosProceso;
                }

                if (procesador.inicio == null)
                    pLibres++;
                else
                    procesador.pop(procesador.procesar());
            }

            txtResultados.Text = "Procesadores libres: " + pLibres + Environment.NewLine + "Número máximo de procesos: " + contadorP + Environment.NewLine + "Procesos pendientes: " + procesador._totalProcesos + Environment.NewLine + "Ciclos necesarios: " + procesador._ciclosNecesarios + Environment.NewLine + "Ciclos atendidos: " + procesador._atendidos + Environment.NewLine;
        }
    }
}
