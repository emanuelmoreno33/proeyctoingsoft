using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pdf_crear;
using System.Data.SqlClient;

namespace Proyecto
{
    public partial class Form_Buscar : Form
    {
        SqlConnection conex = new SqlConnection("server=EMANUELMR-OMEN\\SQLEXPRESS;database=Creditos_Complementarios;integrated security = true");
        pdf_crear.Class1 pdf = new pdf_crear.Class1();
        

        public Form_Buscar()
        {
            InitializeComponent();
        }
        //busca por numero de control
        private void buscar_nocontrol(int nocontrol)
        {
            conex.Open();
            string cadena = "select Nombre,Ape_pat,Ape_mat,Id_Creditos from Alumnos inner Join Creditos on Alumnos.No_Control = Creditos.No_Control where Alumnos.No_Control ="+nocontrol;
            SqlCommand comando = new SqlCommand(cadena, conex);
            SqlDataReader registros = comando.ExecuteReader();
            while(registros.Read())
            {
                string id = registros["Id_creditos"]+"-"+registros["Nombre"].ToString() + " " + registros["Ape_pat"] + " " + registros["Ape_mat"];
                listBox1.Items.Add(id);
            }
            conex.Close();

        }
        //busca por carrera
        private void buscar_carrera(string carrera)
        {
            conex.Open();
            string cadena = "select Nombre,Ape_pat,Ape_mat,Id_Creditos from Alumnos inner Join Creditos on Alumnos.No_Control = Creditos.No_Control inner join Carrera on Alumnos.Id_Carrera = Carrera.Id_Carrera where Carrera.nombre_carrera ='" + carrera+"'";
            SqlCommand comando = new SqlCommand(cadena, conex);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                string id = registros["Id_creditos"] + "-" + registros["Nombre"].ToString() + " " + registros["Ape_pat"] + " " + registros["Ape_mat"];
                listBox1.Items.Add(id);
            }
            conex.Close();
        }
        //busca por actividad
        private void buscar_actividad(string actividad)
        {
            conex.Open();
            string cadena = "select Nombre,Ape_pat,Ape_mat,Id_Creditos from Alumnos inner Join Creditos on Alumnos.No_Control = Creditos.No_Control inner join Actividades_Complementarias on Creditos.Id_Actividad = Actividades_Complementarias.Id_Actividad where Nombre_Actividad = '" + actividad + "'";
            SqlCommand comando = new SqlCommand(cadena, conex);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                string id = registros["Id_creditos"] + "-" + registros["Nombre"].ToString() + " " + registros["Ape_pat"] + " " + registros["Ape_mat"];
                listBox1.Items.Add(id);
            }
            conex.Close();
        }
        //busca por docente
        private void buscar_docente(string docente)
        {
            int docenteid =0;
            conex.Open();
            string cadena = "select Id_Docente,Nombre,Ape_Pat,Ape_Mat from Docente";
            SqlCommand comando = new SqlCommand(cadena, conex);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                if(registros["Nombre"].ToString()+" "+registros["Ape_Pat"].ToString()+" "+registros["Ape_Mat"].ToString()==docente)
                {
                    docenteid = Convert.ToInt32(registros["Id_Docente"].ToString());
                }
            }
            conex.Close();

            conex.Open();
            string cadena2 = "select Nombre,Ape_pat,Ape_mat,Id_Creditos from Alumnos inner Join Creditos on Alumnos.No_Control = Creditos.No_Control where Id_Docente="+docenteid;
            SqlCommand comando2 = new SqlCommand(cadena2, conex);
            SqlDataReader registros2 = comando2.ExecuteReader();
            while (registros2.Read())
            {
                string id = registros2["Id_Creditos"].ToString() + "-" + registros2["Nombre"].ToString() + " " + registros2["Ape_pat"].ToString() + " " + registros2["Ape_mat"].ToString();
                listBox1.Items.Add(id);
            }
            conex.Close();
        }
        //buscar el credito
        private void buscar_credito()
        {
            string creditoactual = listBox1.SelectedItem.ToString();
            string[] valdividido = creditoactual.Split('-');
            int nocredito = Convert.ToInt32(valdividido[0]);
            conex.Open();
            
            string cadena1 = "select no_control from Creditos where Id_Creditos ="+nocredito;
            SqlCommand comando1 = new SqlCommand(cadena1, conex);
            SqlDataReader registros1 = comando1.ExecuteReader();
            if (registros1.Read())
            {
                string item = "No. control: " + registros1["no_control"].ToString();
                listBox2.Items.Add(item);
            }
            conex.Close();
            conex.Open();
            string cadena2 = "select Nombre,Ape_Pat,Ape_Mat,Nombre_Actividad,Periodo_Escolar,anio_periodo,Fecha_Creacion,Nombre_Carrera from Alumnos inner join Creditos on Alumnos.No_Control = Creditos.No_Control inner join Actividades_Complementarias on Creditos.Id_Actividad = Actividades_Complementarias.Id_Actividad inner join Carrera on Alumnos.Id_Carrera =Carrera.Id_Carrera where Creditos.Id_Creditos =" + nocredito;
            SqlCommand comando2 = new SqlCommand(cadena2, conex);
            SqlDataReader registros2 = comando2.ExecuteReader();
            if (registros2.Read())
            {
                try
                {
                    listBox2.Items.Add("Nombre: " + registros2["Nombre"] + " " + registros2["Ape_Pat"].ToString() + " " + registros2["Ape_Mat"].ToString());
                    listBox2.Items.Add("Carrera:" + registros2["Nombre_Carrera"].ToString());
                    listBox2.Items.Add("Actividad: " + registros2["Nombre_Actividad"]);
                    listBox2.Items.Add("Período Escolar: " + registros2["Periodo_Escolar"] +" "+registros2["anio_periodo"]);
                    listBox2.Items.Add("Fecha de creación: " + registros2["Fecha_Creacion"]);
                }
                catch(SystemException)
                {
                    MessageBox.Show("un error inesperado ha sucedido");
                }
            }
            conex.Close();
            conex.Open();
            string cadena3 = "select Nombre,Ape_Pat,Ape_Mat from Docente inner join Creditos on Docente.Id_Docente = Creditos.Id_docente where Creditos.Id_Creditos =" + nocredito;
            SqlCommand comando3 = new SqlCommand(cadena3, conex);
            SqlDataReader registros3 = comando3.ExecuteReader();
            if (registros3.Read())
            {
                string item = "Docente: " + registros3["Nombre"].ToString()+" "+registros3["Ape_Pat"].ToString()+" "+registros3["Ape_mat"].ToString();
                listBox2.Items.Add(item);
            }
            else
            {
                MessageBox.Show("no se encontro");
            }
            conex.Close();
        }
        
        
        //acceder a la busqueda
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (radNocontrol.Checked)
            {
                try
                {
                    int nocontrol = Convert.ToInt32(txtBuscar.Text);
                    buscar_nocontrol(nocontrol);
                }
                catch (System.FormatException)
                {
                    MessageBox.Show("Ingrese un numero de control valido");
                }
            }
            else if(radcarrera.Checked)
            {
                string carrera = combobuscado.Text;
                buscar_carrera(carrera);
            }
            else if(raddocente.Checked)
            {
                string docente = combobuscado.Text;
                buscar_docente(docente);
            }
            else if(radactividad.Checked)
            {
                string actividad = combobuscado.Text;
                buscar_actividad(actividad);
            }
        }
     
        //radiobuttons
        //carrera
        private void radcarrera_CheckedChanged(object sender, EventArgs e)
        {
            combobuscado.Items.Clear();
            if (radcarrera.Checked == true)
            {
                txtBuscar.Visible = false;
                combobuscado.Visible = true;
               
            conex.Open();
            string cadena = "select Nombre_Carrera from Carrera";
            SqlCommand comando = new SqlCommand(cadena, conex);
            SqlDataReader registros = comando.ExecuteReader();
            while(registros.Read())
            {
                string id = registros["Nombre_Carrera"].ToString();
                combobuscado.Items.Add(id);
            }
            conex.Close();
        }
            
        }
        //alumno
        private void radNocontrol_CheckedChanged(object sender, EventArgs e)
        {
            if (radNocontrol.Checked == true)
            {
                txtBuscar.Visible = true;
                combobuscado.Visible = false;
            }
        }
        //actividad
        private void radactividad_CheckedChanged(object sender, EventArgs e)
        {
            combobuscado.Items.Clear();
            if (radactividad.Checked == true)
            {
                txtBuscar.Visible = false;
                combobuscado.Visible = true;
                conex.Open();
                string cadena = "select Nombre_Actividad from Actividades_Complementarias";
                SqlCommand comando = new SqlCommand(cadena, conex);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {
                    string id = registros["Nombre_Actividad"].ToString();
                    combobuscado.Items.Add(id);
                }
                conex.Close();
            }
        }
        //docente
        private void raddocente_CheckedChanged(object sender, EventArgs e)
        {
            if(raddocente.Checked == true)
            {
                txtBuscar.Visible = false;
                combobuscado.Visible = true;
                conex.Open();
                string cadena = "select Nombre,Ape_Pat,Ape_Mat from Docente";
                SqlCommand comando = new SqlCommand(cadena, conex);
                SqlDataReader registros = comando.ExecuteReader();
                while (registros.Read())
                {
                    string id = registros["Nombre"].ToString() + " " + registros["Ape_pat"] + " " + registros["Ape_mat"];
                    combobuscado.Items.Add(id);
                }
                conex.Close();
            }
        }

        //list box 1 muestra que tiene el credito seleccionado
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                buscar_credito();
                button2.Enabled = true;
            }
            catch(Exception)
            {

            }
        }
        //boton para generar el pdf
        private void button2_Click(object sender, EventArgs e)
        {
            string nombre="";
            string apeliidopat="";
            string apellidomat="";
            string docente="";
            int numero_control=0;
            string carrera="";
            string actividad="";
            string desempenio="";
            int val_numerico=1;
            string periodo_escolar="";
            int periodo_anio=0;
            int valor_curricular=0;
            int dia=0;
            int mes=0;
            int anio=0;

            string creditoactual = listBox1.SelectedItem.ToString();
            string[] valdividido = creditoactual.Split('-');
            int nocredito = Convert.ToInt32(valdividido[0]);
            conex.Open();
            //añade el numero de control
            string cadena1 = "select no_control from Creditos where Id_Creditos =" + nocredito;
            SqlCommand comando1 = new SqlCommand(cadena1, conex);
            SqlDataReader registros1 = comando1.ExecuteReader();
            if (registros1.Read())
            {
                numero_control =Convert.ToInt32(registros1["no_control"]);
            }
            conex.Close();
            conex.Open();
            //añade nombre, apellidos, nombre de la actividad,periodo escolar,carrera, valor numerico, valor curricular
            string cadena2 = "select Nombre,Ape_Pat,Ape_Mat,Nombre_Actividad,Periodo_Escolar,Nombre_Carrera,Id_desempenio,anio_periodo,Creditos.Cant_Creditos as creditos from Alumnos inner join Creditos on Alumnos.No_Control = Creditos.No_Control inner join Actividades_Complementarias on Creditos.Id_Actividad = Actividades_Complementarias.Id_Actividad inner join Carrera on Alumnos.Id_Carrera =Carrera.Id_Carrera where Creditos.Id_Creditos=" + nocredito;
            SqlCommand comando2 = new SqlCommand(cadena2, conex);
            SqlDataReader registros2 = comando2.ExecuteReader();
            if (registros2.Read())
            {
                try
                {
                    nombre = registros2["Nombre"].ToString();
                    apeliidopat = registros2["Ape_Pat"].ToString();
                    apellidomat = registros2["Ape_Mat"].ToString();
                    actividad = registros2["Nombre_Actividad"].ToString();
                    periodo_escolar = registros2["Periodo_Escolar"].ToString();
                    carrera = registros2["Nombre_Carrera"].ToString();
                    val_numerico = Convert.ToInt32(registros2["Id_desempenio"]);
                    valor_curricular = Convert.ToInt32(registros2["creditos"]);
                    periodo_anio =Convert.ToInt32(registros2["anio_periodo"]);
                }
                catch (SystemException)
                {
                    MessageBox.Show("un error inesperado ha sucedido");
                }
            }
            conex.Close();
            conex.Open();
            //añade datos de docente
            string cadena3 = "select Nombre,Ape_Pat,Ape_Mat from Docente inner join Creditos on Docente.Id_Docente = Creditos.Id_docente where Creditos.Id_Creditos =" + nocredito;
            SqlCommand comando3 = new SqlCommand(cadena3, conex);
            SqlDataReader registros3 = comando3.ExecuteReader();
            if (registros3.Read())
            {
                docente = registros3["Nombre"].ToString() + " " + registros3["Ape_Pat"].ToString() + " " + registros3["Ape_Mat"].ToString();
            }
            else
            {
                MessageBox.Show("no se encontro");
            }
            conex.Close();
            conex.Open();
            //añade desempeño
            string cadena4 = "select Desempenio_significado from Desempenio where Id_desempenio =" + val_numerico.ToString();
            SqlCommand comando4 = new SqlCommand(cadena4, conex);
            SqlDataReader registros4 = comando4.ExecuteReader();
            if (registros4.Read())
            {
                desempenio = registros4["Desempenio_significado"].ToString();
            }
            else
            {
                MessageBox.Show("no se encontro");
            }
            conex.Close();
            dia = DateTime.Now.Day;
            mes = DateTime.Now.Month;
            anio = DateTime.Now.Year;
            pdf.creado(nombre,apeliidopat,apellidomat,docente,numero_control,carrera,actividad,desempenio,val_numerico,periodo_escolar,periodo_anio,valor_curricular,dia,mes,anio);
            MessageBox.Show("el pdf fue creado");
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {               
                if (radNocontrol.Checked)
                {
                    listBox1.Items.Clear();
                    try
                    {
                        int nocontrol = Convert.ToInt32(txtBuscar.Text);
                        buscar_nocontrol(nocontrol);
                    }
                    catch (System.FormatException)
                    {
                        MessageBox.Show("Ingrese un numero de control valido");
                    }
                }
            }
            else if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }

        }
    }
}
