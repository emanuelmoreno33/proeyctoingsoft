using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class From_Inicio : Form
    {
        public From_Inicio()
        {
            InitializeComponent();
        }

        DateTime Actual;
        string mes, apm, minuto, segundo;

        int hora;

        //Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            Actual = DateTime.Now;
            hora = Actual.Hour;

            //Condición para la hora
            if (hora > 12)
            {
                hora = hora - 12;
                apm = "pm";
            }
            else
                apm = "am";

            //Condición para el minuto
            if (Actual.Minute < 10)
            {
                minuto = "0" + Actual.Minute.ToString();
            }
            else
                minuto = Actual.Minute.ToString();

            //Condición para el segundo
            if (Actual.Second < 10)
            {
                segundo = "0" + Actual.Second.ToString();
            }
            else
                segundo = Actual.Second.ToString();

            //Condicion para el mes
            switch (Actual.Month)
            {
                case 1:
                    mes = "Enero";
                    break;
                case 2:
                    mes = "Febrero";
                    break;
                case 3:
                    mes = "Marzo";
                    break;
                case 4:
                    mes = "Abril";
                    break;
                case 5:
                    mes = "Mayo";
                    break;
                case 6:
                    mes = "Junio";
                    break;
                case 7:
                    mes = "Julio";
                    break;
                case 8:
                    mes = "Agosto";
                    break;
                case 9:
                    mes = "Septiembre";
                    break;
                case 10:
                    mes = "Octubre";
                    break;
                case 11:
                    mes = "Noviembre";
                    break;
                case 12:
                    mes = "Diciembre";
                    break;
            }

            //Condición para el ciclo y días restantes
            if (Actual.Month >= 8 && Actual.Month <= 12)
            {
                lblCiclo.Text = "Ciclo escolar Agosto - Diciembre " + Convert.ToString(DateTime.Now.Year);
            }
            else if (Actual.Month == 7)
            {
                lblCiclo.Text = "Periodo vacacional de " + Convert.ToString(DateTime.Now.Year);
            }
            else
            {
                lblCiclo.Text = "Ciclo escolar Enero - Junio " + Convert.ToString(DateTime.Now.Year);
            }

            //Salida de la fecha
            lblfecha.Text = Actual.Day + " de " + mes + " del " + Actual.Year + " a las " + hora + ":" + minuto + ":" + segundo + " " + apm;
        }

       
        
    }
}
