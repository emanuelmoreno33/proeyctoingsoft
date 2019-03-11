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
using System.Threading;

namespace Proyecto
{
    public partial class From_Generar : Form
    {
      SqlConnection con = new SqlConnection("server=EMANUELMR-OMEN\\SQLEXPRESS;database=Creditos_Complementarios;integrated security = true");
      bool alumnoencontrado = false;
        public From_Generar()
        {
            InitializeComponent();
        }
        //boton para generar el pdf y guardar alumno
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                generarcredito();
            }
            catch(Exception)
            {
                MessageBox.Show(e.ToString());
            }
        }
       //metodo para generar creditos
        private void generarcredito()
        {
            int nocontrol = Convert.ToInt32(txtnocontrol.Text);
            string nombre = txtnombre.Text;
            string apepat = txtapepat.Text;
            string apemat = txtapemat.Text;
            string carrera = combocarrera.Text;
            string actividad = comboactividad.Text;
            string docente = combodocente.Text;
            string periodo = comboperiodomes.Text.ToString();
            int anioperiodo = Convert.ToInt32(txtperiodoanio.Text);
            string desempenio = combodes.Text;
            int credito = Convert.ToInt32(numcredito.Value);
            int calificacion = Convert.ToInt32(numcalificacion.Value);
            int dia = Convert.ToInt32(System.DateTime.Now.Day);
            int mes = Convert.ToInt32(System.DateTime.Now.Month);
            int anio = Convert.ToInt32(System.DateTime.Now.Year);
            CreditosInfo Info = new CreditosInfo(nocontrol, nombre, apepat, apemat,  carrera, actividad, docente, periodo,  anioperiodo,  desempenio,  credito, calificacion, dia, mes, anio);
            GeneradorPdf generador = new GeneradorPdf(Info);
            generador.GenerarPdf();
            generador.Hilo.Join();
            MessageBox.Show("El pdf fue creado");
            introduciralumno(nombre, apepat, apemat, docente, nocontrol, carrera, actividad, desempenio, calificacion, periodo, anioperiodo, credito);
            MessageBox.Show("Se ha registrado en la base de datos");
            limpiar();
        }
        //introducir al alumno a la base de datos
        private void introduciralumno(string nom, string appat, string apmat, string doc, int nocon, string carr, string act, string desem, int valnum, string peresc, int peranio, int valcur)
        {
            string nombre = nom;
            string apellidopat = appat;
            string apellidomat = apmat;
            string docente = doc;
            int numcontrol = nocon;
            string carrera = carr;
            string actividad = act;
            string desempenio = desem;
            int valornum = valnum;
            string periodo = peresc;
            int valorcurr = valcur;
            int anio = peranio;

            string idcarrera = "";
            int iddocente = 0;
            string idactividad = "";
            int iddesempenio = 0;
            DateTime fecha = DateTime.Now;
            string sqlfecha = fecha.ToString("yyyy-MM-dd hh:mm:ss");
            con.Open();
            idcarrera = buscarcarrera(carrera);
            con.Close();
            con.Open();
            iddesempenio = buscardesempenio(desempenio);
            con.Close();
            con.Open();
            idactividad = buscaractividades(actividad);
            con.Close();
            con.Open();
            iddocente = buscardocente(docente);
            con.Close();
            if (alumnoencontrado == false)
            {
                con.Open();
                string cadena5 = "insert into Alumnos(No_Control,Nombre,Ape_Pat,Ape_Mat,Id_Carrera) values(" + numcontrol + ",'" + nombre + "','" + apellidopat + "','" + apellidomat + "','" + idcarrera + "')";
                SqlCommand comando5 = new SqlCommand(cadena5, con);
                comando5.ExecuteNonQuery();
                con.Close();
            }
            con.Open();
            string cadena6 = "insert into Creditos(No_Control,Id_Actividad,Calificacion_Numerica,Cant_Creditos,Id_docente,Id_desempenio,Periodo_Escolar,Fecha_Creacion,anio_periodo) values("+numcontrol + ",'" + idactividad + "'," + valnum + "," + valorcurr + "," + iddocente + "," + iddesempenio + ",'" + peresc.ToString() + "','" +sqlfecha + "',"+anio+")";
            SqlCommand comando6 = new SqlCommand(cadena6, con);
            comando6.ExecuteNonQuery();
            con.Close();
        }
        //busca los tipos de desempeño
        private int buscardesempenio(string desempenio)
        {
            //desempeño
            string cadena4 = "select * from Desempenio where Desempenio_significado ='" + desempenio + "'";
            SqlCommand comando4 = new SqlCommand(cadena4, con);
            SqlDataReader registros4 = comando4.ExecuteReader();
            if (registros4.Read())
            {
                return Convert.ToInt32(registros4["Id_desempenio"]);
            }
            else
            {
                MessageBox.Show("error en desempeño");
                return 0;
            }
            
        }
        //busca las actividades
        private string  buscaractividades(string actividad)
        {
            //actividades complementarias
            string cadena3 = "select * from Actividades_Complementarias where Nombre_Actividad ='" + actividad + "'";
            SqlCommand comando3 = new SqlCommand(cadena3, con);
            SqlDataReader registros3 = comando3.ExecuteReader();
            if (registros3.Read())
            {
                return registros3["Id_Actividad"].ToString();
            }
            else
            {
                MessageBox.Show("error en actividad");
                return "nulo";
            }
            
        }
        //busca las carreras
        private string buscarcarrera(string carrera)
        {
            //carrera
            string cadena1 = "select * from Carrera where Nombre_Carrera ='" + carrera + "'";
            SqlCommand comando = new SqlCommand(cadena1, con);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                return registros["Id_Carrera"].ToString();
            }
            else
            {
                MessageBox.Show("error en carrera");
                return "nulo";
            }

        }
        //busca los docentes
        private int buscardocente(string docente)
        {
            //docente
            string cadena2 = "select Id_Docente,Nombre,Ape_Pat,Ape_Mat from Docente";
            SqlCommand comando2 = new SqlCommand(cadena2, con);
            SqlDataReader registros2 = comando2.ExecuteReader();
            bool bandera = false;
            int iddocente = 0;
            while (registros2.Read() && bandera == false)
            {
                if (registros2["Nombre"].ToString() + " " + registros2["Ape_Pat"].ToString() + " " + registros2["Ape_Mat"].ToString() == docente)
                {
                    iddocente = Convert.ToInt32(registros2["Id_docente"]);
                    bandera = true;
                }
            }
            if(bandera == true)
            {
                return iddocente;
            }
            else
            {
                return 0;
            }
        }

        //introduce los nombres de los docentes al checkbox
        private void introducircarreras()
        {
            con.Open();
            string cadena = "select Nombre_Carrera from Carrera";
            SqlCommand comando = new SqlCommand(cadena, con);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                combocarrera.Items.Add(registros["Nombre_Carrera"].ToString());
            }
            con.Close();
        }
        //introduce las actividades al checkbox
        private void introduciractividades()
        {
            con.Open();
            string cadena1 = "select Nombre_Actividad from Actividades_Complementarias";
            SqlCommand comando1 = new SqlCommand(cadena1, con);
            SqlDataReader registros1 = comando1.ExecuteReader();
            while (registros1.Read())
            {
                comboactividad.Items.Add(registros1["Nombre_Actividad"].ToString());
            }
            con.Close();
        }
        //introduce los docentes al checkbox
        private void introducirdocente()
        {
            con.Open();
            string cadena2 = "select Nombre,Ape_Pat,Ape_Mat from Docente";
            SqlCommand comando2 = new SqlCommand(cadena2, con);
            SqlDataReader registros2 = comando2.ExecuteReader();
            while (registros2.Read())
            {
                combodocente.Items.Add(registros2["Nombre"].ToString() + " " + registros2["Ape_Pat"].ToString() + " " + registros2["Ape_Mat"].ToString());
            }
            con.Close();
        }
        //metodo que corre con lo que debe iniciar la forma
        private void From_Generar_Load(object sender, EventArgs e)
        {
            introducircarreras();
            introduciractividades();
            introducirdocente();
        } 
        
        //metodo para buscar el alumno si existe
        private void buscaralumno()
        {
            con.Open();
            string nocontrol = txtnocontrol.Text;
            string cadena = "SELECT * FROM Alumnos inner join Carrera c on Alumnos.Id_Carrera = c.Id_Carrera Where No_Control ="+nocontrol;
            SqlCommand comando = new SqlCommand(cadena, con);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                txtnombre.Text = registros["Nombre"].ToString();
                txtapepat.Text = registros["Ape_Pat"].ToString();
                txtapemat.Text = registros["Ape_Mat"].ToString();
                combocarrera.Text = registros["Nombre_Carrera"].ToString();
                con.Close();
                txtnombre.ReadOnly = true;
                txtapepat.ReadOnly = true;
                txtnocontrol.ReadOnly = true;
                txtapepat.ReadOnly = true;
                combocarrera.Enabled = false;
                alumnoencontrado = true;
                comboactividad.Enabled = true;
                combodocente.Enabled = true;
                comboperiodomes.Enabled = true;
                txtperiodoanio.Enabled = true;
                combodes.Enabled = true;
                numcredito.Enabled = true;
                numcalificacion.Enabled = true;
                btngenerar.Visible = true;
                pictureBox2.Visible = true;
            }
            else
            {
                MessageBox.Show("No existe el alumno, ingrese los datos");
                txtnombre.Enabled = true;
                txtapepat.Enabled = true;
                txtapemat.Enabled = true;
                combocarrera.Enabled = true;
                comboactividad.Enabled = true;
                combodocente.Enabled = true;
                comboperiodomes.Enabled = true;
                txtperiodoanio.Enabled = true;
                combodes.Enabled = true;
                numcredito.Enabled = true;
                numcalificacion.Enabled = true;
                btngenerar.Visible = false;
                pictureBox2.Visible = false;
            }
            con.Close();
        }
        //busca el alumno
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                buscaralumno();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Alumno no encontrado");
            }
        }
        //cambia el valor numerico por la calificicacion
        private void combodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combodes.Text == "Excelente")
            {
                numcalificacion.Value = 4;
            }
            else if (combodes.Text == "Bueno")
            {
                numcalificacion.Value = 3;
            }
            else if (combodes.Text == "Regular")
            {
                numcalificacion.Value = 2;
            }
            else if(combodes.Text == "Insuficiente")
            {
                numcalificacion.Value = 1;
            }
            else
            {
                numcalificacion.Value = 0;
            }
        }
        //cambia del combo box si cambia calificacion
        private void numcalificacion_ValueChanged(object sender, EventArgs e)
        {
            if (numcalificacion.Value == 4)
            {
                combodes.Text = "Excelente";
            }
            else if (numcalificacion.Value == 3)
            {
                combodes.Text = "Bueno";
            }
            else if (numcalificacion.Value == 2)
            {
                combodes.Text = "Regular";
            }
            else if (numcalificacion.Value == 1)
            {
                combodes.Text = "Insuficiente";
            }
        }
        //limpia las casillas
        private void limpiar()
        {
            txtnocontrol.Clear();
            txtnombre.Clear();
            txtapemat.Clear();
            txtapepat.Clear();
            txtperiodoanio.Clear();
        }
        //verificacion de letras
        private void txtnocontrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtapepat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtapemat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void numcredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtperiodoanio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void numcalificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
    //clase para guardar la informacion de los creditos
    class CreditosInfo
    {
       public  int nocontrol;
       public string nombre;
       public string apepat;
       public string apemat;
       public string carrera;
       public string actividad;
       public string docente;
       public string periodo;
       public int anioperiodo;
       public string desempenio;
       public int credito;
       public int calificacion;
       public int dia;
       public int mes;
       public int anio;
       public CreditosInfo(int nocontrol, string nombre, string apepat, string apemat, string carrera, string actividad, string docente, string periodo, int anioperiodo, string desempenio, int credito, int calificacion, int dia, int mes, int anio)
        {
            
            this.nocontrol = nocontrol;
            this.nombre = nombre;
            this.apepat = apepat;
            this.apemat = apemat;
            this.carrera = carrera;
            this.actividad = actividad;
            this.docente = docente;
            this.periodo = periodo;
            this.anioperiodo = anioperiodo;
            this.desempenio = desempenio;
            this.credito = credito;
            this.calificacion = calificacion;
            this.dia = dia;
            this.mes = mes;
            this.anio = anio;
        }
    }
    //clase generadora de pdf
    class GeneradorPdf
    {
        public Thread Hilo;
        CreditosInfo Informacion;
       public GeneradorPdf(CreditosInfo informacion)
        {
            this.Informacion = informacion;
            Hilo = null;
        }
        //metodo para generar pdfs
        public void GenerarPdf()
        {
             Hilo = new Thread(GenerarconHiloPdf);
            Hilo.Start();
        }
        public void GenerarconHiloPdf()
        {
            pdf_crear.Class1 pdf = new Class1();
            pdf.creado(
                Informacion.nombre,
                Informacion.apepat,
                Informacion.apemat, 
                Informacion.docente, 
                Informacion.nocontrol, 
                Informacion.carrera, 
                Informacion.actividad,
                Informacion.desempenio, 
                Informacion.calificacion,
                Informacion.periodo,
                Informacion.anioperiodo, 
                Informacion.credito,
                Informacion.dia, 
                Informacion.mes, 
                Informacion.anio);
            
        }
        
    }
}
