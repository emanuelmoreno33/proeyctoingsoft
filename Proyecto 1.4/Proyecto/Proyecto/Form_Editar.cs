using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proyecto
{
    public partial class Form_Editar : Form
    {
        SqlConnection con = new SqlConnection("server=EMANUELMR-OMEN\\SQLEXPRESS;database=Creditos_Complementarios;integrated security = true");
        //inicia la pantalla
        public Form_Editar()
        {
            InitializeComponent();
            //Por iniciar
            Todos();

            mostrar_panel(1);
            bntAlumno.BackColor = Color.LimeGreen;
            bntAlumno.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            bntAlumno.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
        }
        // Ponen los botones en color iguales
        public void Todos() {
            btnAC.BackColor = Color.FromArgb(56, 89, 120);
            btnCredito.BackColor = Color.FromArgb(56, 89, 120);
            btnDocente.BackColor = Color.FromArgb(56, 89, 120);
            bntAlumno.BackColor = Color.FromArgb(56, 89, 120);
            btnAC.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 89, 120);
            btnCredito.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 89, 120);
            btnDocente.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 89, 120);
            bntAlumno.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 89, 120);
            btnAC.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 89, 120);
            btnCredito.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 89, 120);
            btnDocente.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 89, 120);
            bntAlumno.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 89, 120);
        }
        //metodo para mostrar panel
        private void mostrar_panel(int panel)
        {
            switch (panel)
            {
                case 1:
                    panelact.Visible = false;
                    panelalumno.Visible = true;
                    panelcredito.Visible = false;
                    panelDocente.Visible = false;
                break;
                case 2:
                    panelact.Visible = false;
                    panelalumno.Visible = false;
                    panelcredito.Visible = false;
                    panelDocente.Visible = true;
                break;
                case 3:
                    panelact.Visible = false;
                    panelalumno.Visible = false;
                    panelcredito.Visible = true;
                    panelDocente.Visible = false;
                break;
                case 4:
                    panelact.Visible = true;
                    panelalumno.Visible = false;
                    panelcredito.Visible = false;
                    panelDocente.Visible = false;
                break;
                default:
                    panelact.Visible = false;
                    panelalumno.Visible = false;
                    panelcredito.Visible = false;
                    panelDocente.Visible = false;
                break;
            }

        }
        //busca la actividad
        private void buscaractividades()
        {
            con.Open();
            string cadena1 = "select  from Actividades_Complementarias where ";
            SqlCommand comando1 = new SqlCommand(cadena1, con);
            SqlDataReader registros1 = comando1.ExecuteReader();
            while (registros1.Read())
            {
                comboactividadmod.Items.Add(registros1["Nombre_Actividad"].ToString());
            }
            con.Close();
        }
        
        private string buscarcarrera(string carrera)
        {
            con.Open();
            string cadena1 = "select Id_Carrera from Carrera where Nombre_Carrera ='"+carrera+"'";
            SqlCommand comando1 = new SqlCommand(cadena1, con);
            SqlDataReader registros1 = comando1.ExecuteReader();
            if (registros1.Read())
            {
                string id = registros1["Id_Carrera"].ToString();
                con.Close();
                return id;
            }
            else
            {
                con.Close();
                return "ninguno";
            }
            
        }
        //busca los tipos de desempeño
        private int buscardesempenio(string desempenio)
        {
            //desempeño
            con.Open();
            string cadena4 = "select * from Desempenio where Desempenio_significado ='" + desempenio + "'";
            SqlCommand comando4 = new SqlCommand(cadena4, con);
            SqlDataReader registros4 = comando4.ExecuteReader();
            if (registros4.Read())
            {
                int id = Convert.ToInt32(registros4["Id_desempenio"]);
                con.Close();
                return id;
            }
            else
            {
                MessageBox.Show("error en desempeño");
                con.Close();
                return 0;
            }

        }
        //busca las actividades
        private string buscaractividades(string actividad)
        {
            //actividades complementarias
            con.Open();
            string cadena3 = "select * from Actividades_Complementarias where Nombre_Actividad ='" + actividad + "'";
            SqlCommand comando3 = new SqlCommand(cadena3, con);
            SqlDataReader registros3 = comando3.ExecuteReader();
            if (registros3.Read())
            {
                string id = registros3["Id_Actividad"].ToString();
                con.Close();
                return id;
            }
            else
            {
                MessageBox.Show("error en actividad");}
                con.Close();
                return "nulo";
            }
        private int buscardocentes(string docente)
        {
            //docente
            con.Open();
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
            con.Close();
            if (bandera == true)
            {
                return iddocente;
            }
            else
            {
                return 0;
            }
        }

        private bool buscardocentes2(int docente)
        {
            //docente
            con.Open();
            string cadena2 = "select Id_Docente,Nombre,Ape_Pat,Ape_Mat from Docente where Id_Docente ="+docente;
            SqlCommand comando2 = new SqlCommand(cadena2, con);
            SqlDataReader registros2 = comando2.ExecuteReader();
            if (registros2.Read())
            {
                txtiddocente.Text = registros2["Id_Docente"].ToString();
                txtnombremaestro.Text = registros2["Nombre"].ToString();
                txtapepatmaestro.Text = registros2["Ape_Pat"].ToString();
                txtapematmaestro.Text = registros2["Ape_Mat"].ToString();
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        private bool buscaractividades2(string actividad)
        {
            con.Open();
            string cadena1 = "select Id_Actividad,Nombre_Actividad,Fundamento_Actividad,Cant_Creditos from Actividades_Complementarias where Id_Actividad ='"+actividad+"'";
            SqlCommand act = new SqlCommand(cadena1, con);
            SqlDataReader registros1 = act.ExecuteReader();
            if (registros1.Read())
            {
                txtidact.Text = registros1["Id_Actividad"].ToString();
                txtnombreactmod.Text = registros1["Nombre_Actividad"].ToString();
                txtfundamentomod.Text = registros1["Fundamento_Actividad"].ToString();
                numericcreditosmod.Value = Convert.ToInt32(registros1["Cant_Creditos"]);
                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        private bool buscarcreditos(int credito)
        {
            con.Open();
            string cadena1 = "select Docente.Nombre as nombre,Docente.Ape_Pat as apepat, Docente.Ape_Mat as apemat, Creditos.Cant_Creditos as cantcreditos, Creditos.Id_desempenio as desempenio, Desempenio.Desempenio_significado as desemsig, Creditos.Periodo_Escolar as periodo,Creditos.anio_periodo as fecha,Actividades_Complementarias.Nombre_Actividad as actividad from Creditos inner join Docente on Creditos.Id_docente = Docente.Id_Docente inner join Desempenio on Desempenio.Id_desempenio = Creditos.Id_desempenio inner join Actividades_Complementarias on Creditos.Id_Actividad = Actividades_Complementarias.Id_Actividad where Creditos.Id_Creditos =" + credito;
            SqlCommand comando1 = new SqlCommand(cadena1, con);
            SqlDataReader registros1 = comando1.ExecuteReader();
            if (registros1.Read())
            {
                string nombredocente = registros1["nombre"]+" "+registros1["apepat"]+" "+registros1["apemat"];
                int cantcreditos = Convert.ToInt32(registros1["cantcreditos"].ToString());
                int desempenio = Convert.ToInt32(registros1["desempenio"].ToString());
                string desempenio_significado = registros1["desemsig"].ToString();
                string periodo = registros1["periodo"].ToString();
                string actividad = registros1["actividad"].ToString();
                string fecha = registros1["fecha"].ToString();
 

                combodocentemod.Text = nombredocente;
                numericcreditosmod.Value = cantcreditos;
                numericcalifmod.Value = desempenio;
                combodes.Text = desempenio_significado;
                txtperiodoanio.Text = fecha.ToString();
                comboactividadmod.Text = actividad.ToString();
                comboperiodomes.Text = periodo;


                con.Close();
                return true;
            }
            else
            {
                con.Close();
                return false;
            }
        }
        private bool buscaralumnos(int nocontrol)
        {
            con.Open();
            string cadena1 = "select No_control,nombre,ape_pat,ape_mat,Alumnos.id_carrera as id_carrera,Nombre_Carrera from  alumnos inner join Carrera on Alumnos.Id_Carrera = Carrera.Id_Carrera where No_Control ="+nocontrol;
            SqlCommand comando1 = new SqlCommand(cadena1, con);
            SqlDataReader registros1 = comando1.ExecuteReader();
            if (registros1.Read())
            {
               txtnocontrol.Text = registros1["No_control"].ToString();
               txtamodnom.Text = registros1["nombre"].ToString();
               txtamodapepat.Text = registros1["ape_pat"].ToString();
               txtamodapemat.Text = registros1["ape_mat"].ToString();
               combomodacarrera.Text = registros1["Nombre_Carrera"].ToString();
               con.Close();
               return true;
            }
            else
            {
                con.Close();
                return false;
            }
           
        }
        //introduce los nombres de los docentes al select
        
        private void introducircarreras()
        {
            con.Open();
            string cadena = "select Nombre_Carrera from Carrera";
            SqlCommand comando = new SqlCommand(cadena, con);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                combomodacarrera.Items.Add(registros["Nombre_Carrera"].ToString());
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
                combodocentemod.Items.Add(registros2["Nombre"].ToString() + " " + registros2["Ape_Pat"].ToString() + " " + registros2["Ape_Mat"].ToString());
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
                comboactividadmod.Items.Add(registros1["Nombre_Actividad"].ToString());
            }
            con.Close();
        }

        // Botones principales
        private void bntAlumno_Click(object sender, EventArgs e)
        {
            Todos();
            // Coordedanas para ver los partes del panel
            mostrar_panel(1);
            bntAlumno.BackColor = Color.LimeGreen;
            bntAlumno.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            bntAlumno.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
        }
        private void btnDocente_Click(object sender, EventArgs e)
        {
            Todos();
            // Coordedanas para ver los partes del panel
            mostrar_panel(2);
            btnDocente.BackColor = Color.LimeGreen;
            btnDocente.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            btnDocente.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
        }
        private void btnCredito_Click(object sender, EventArgs e)
        {
            Todos();
            // Coordedanas para ver los partes del panel
            mostrar_panel(3);
            btnCredito.BackColor = Color.LimeGreen;
            btnCredito.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            btnCredito.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
        }
        private void btnAC_Click(object sender, EventArgs e)
        {
            Todos();
            mostrar_panel(4);
            btnAC.BackColor = Color.LimeGreen;
            btnAC.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            btnAC.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
        }
        //seccion alumno
        //buscar el alumno
        private void buscar_alumno_Click(object sender, EventArgs e)
        {
            try
            {
                int nocontrol = Convert.ToInt32(txtnocontrol.Text);
                bool encontrado = buscaralumnos(nocontrol);
                if (encontrado == true)
                {
                    txtamodnom.Enabled = true;
                    txtamodapepat.Enabled = true;
                    txtamodapemat.Enabled = true;
                    combomodacarrera.Enabled = true;
                    limpiaralumno.Enabled = true;
                    buscaralumno.Enabled = false;
                    txtnocontrol.Enabled = false;
                    actualizaralumno.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Alumno no encontrado","Aviso");
                }
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Error en el número de control!");
            }

        }
        //limpia el alumno
        private void limpiaralumno_Click(object sender, EventArgs e)
        {
            txtamodapemat.Clear();
            txtamodapepat.Clear();
            txtnocontrol.Clear();
            txtamodnom.Clear();
            combomodacarrera.Text = "";
            txtnocontrol.Clear();

            txtamodnom.Enabled = false;
            txtamodapepat.Enabled = false;
            txtamodapemat.Enabled = false;
            combomodacarrera.Enabled = false;
            limpiaralumno.Enabled = false;
            buscaralumno.Enabled = true;
            txtnocontrol.Enabled = true;
            actualizaralumno.Enabled = false;
        }
        //actualizar alumno
        private void actualizaralumno_Click(object sender, EventArgs e)
        {
            try
            {
                int nocontrol = Convert.ToInt32(txtnocontrol.Text);
                string nombre = txtamodnom.Text;
                string apepat = txtamodapepat.Text;
                string apemat = txtamodapemat.Text;
                string idcarrera = buscarcarrera(combomodacarrera.Text);
                if (idcarrera != "ninguno")
                {
                    con.Open();
                    string cadena1 = "update Alumnos set Nombre = '"+nombre+"', ape_pat = '"+apepat+"', ape_mat = '"+apemat+"',id_carrera='"+idcarrera+"' where No_Control ="+nocontrol.ToString();
                    SqlCommand actualizaralumno = new SqlCommand(cadena1, con);
                    actualizaralumno.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Alumno actualizado");
                    txtamodnom.Enabled = false;
                    txtamodapepat.Enabled = false;
                    txtamodapemat.Enabled = false;
                    combomodacarrera.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No se encontro la carrera");
                }
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Un error inesperado");
            }

        }

        private void Form_Editar_Load(object sender, EventArgs e)
        {
            introducircarreras();
        }

        private void buscarcredito_Click(object sender, EventArgs e)
        {
            try
            {
                int credito = Convert.ToInt32(txtcredito.Text);
                bool encontrado = buscarcreditos(credito);
                if (encontrado == true)
                {
                    txtcredito.Enabled = false;
                    buscarcredito.Enabled = false;
                    limpiarcredito.Enabled = true;
                    combodocentemod.Enabled = true;
                    numericcreditomod.Enabled = true;
                    numericcalifmod.Enabled = true;
                    combodes.Enabled = true;
                    comboactividadmod.Enabled = true;
                    comboperiodomes.Enabled = true;
                    txtperiodoanio.Enabled = true;
                    actualizarcredito.Enabled = true;
                }
                else
                {
                    MessageBox.Show("El credito no existe");
                }
               

            }
            catch(System.FormatException)
            {
                MessageBox.Show("Error en el identificador del credito!");
            }
        }

        private void limpiarcredito_Click(object sender, EventArgs e)
        {
            txtcredito.Enabled = true;
            buscarcredito.Enabled = true;
            limpiarcredito.Enabled = false;
            combodocentemod.Enabled = false;
            numericcreditomod.Enabled = false;
            numericcalifmod.Enabled = false;
            combodes.Enabled = false;
            comboactividadmod.Enabled = false;
            comboperiodomes.Enabled = false;
            txtperiodoanio.Enabled = false;
            actualizarcredito.Enabled = false;

            txtcredito.Clear();
            combodocentemod.Text = "";
            numericcreditomod.Value = 1;
            numericcalifmod.Value = 1;
            combodes.Text = "";
            comboactividadmod.Text = "";
            comboperiodomes.Text = "";
            txtperiodoanio.Clear();
        }

        private void actualizarcredito_Click(object sender, EventArgs e)
        {
            try
            {
                int idcredito = Convert.ToInt32(txtcredito.Text);
                string docente = combodocentemod.Text;
                int iddocente = buscardocentes(docente);
                int cant_creditos = Convert.ToInt32(numericcreditomod.Value);
                int calif = Convert.ToInt32(numericcalifmod.Value);
                string actividad = comboactividadmod.Text;
                string idact = buscaractividades(actividad);
                string periodo = comboperiodomes.Text;
                int anio = Convert.ToInt32(txtperiodoanio.Text);

                con.Open();
                string cadena1 = "update creditos set Id_Docente = " + iddocente + ", Cant_Creditos = " + cant_creditos + ", Calificacion_Numerica = " + calif + ",id_actividad='" + idact + "',Periodo_Escolar='"+periodo+"',anio_periodo="+anio+" where Id_Creditos =" + idcredito.ToString();
                SqlCommand actualizaralumno = new SqlCommand(cadena1, con);
                actualizaralumno.ExecuteNonQuery();
                MessageBox.Show("Credito actualizado");
                con.Close();

                combodocentemod.Enabled = false;
                numericcreditomod.Enabled = false;
                numericcalifmod.Enabled = false;
                combodes.Enabled = false;
                comboactividadmod.Enabled = false;
                comboperiodomes.Enabled = false;
                txtperiodoanio.Enabled = false;
                actualizarcredito.Enabled = false;

            }
            catch(System.FormatException)
            {
                MessageBox.Show("Error al actualizar el credito");
            }

        }

        private void numericcreditomod_ValueChanged(object sender, EventArgs e)
        {
            if (numericcreditomod.Value == 4)
            {
                combodes.Text = "Excelente";
            }
            else if (numericcreditomod.Value == 3)
            {
                combodes.Text = "Bueno";
            }
            else if (numericcreditomod.Value == 2)
            {
                combodes.Text = "Regular";
            }
            else if (numericcreditomod.Value == 1)
            {
                combodes.Text = "Insuficiente";
            }
        }

        private void combodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (combodes.Text == "Excelente")
            {
                numericcreditomod.Value = 4;
            }
            else if (combodes.Text == "Bueno")
            {
                numericcreditomod.Value = 3;
            }
            else if (combodes.Text == "Regular")
            {
                numericcreditomod.Value = 2;
            }
            else if (combodes.Text == "Insuficiente")
            {
                numericcreditomod.Value = 1;
            }
            else
            {
                numericcreditomod.Value = 0;
            }
        }

        private void buscaractividad_Click(object sender, EventArgs e)
        {
            string id_actividad = txtidact.Text;
            bool actividad = buscaractividades2(id_actividad);
            if (actividad == true)
            {
                txtidact.Enabled = false;
                buscaractividad.Enabled = false;
                limpiaractividad.Enabled = true;
                txtnombreactmod.Enabled = true;
                txtfundamentomod.Enabled = true;
                numericcreditosmod.Enabled = true;
                btnagregaractividad.Enabled = true;
            }
            else
            {
                MessageBox.Show("La actividad no existe"+id_actividad);
            }
        }

        private void limpiaractividad_Click(object sender, EventArgs e)
        {
            txtidact.Enabled = true;
            buscaractividad.Enabled = true;
            limpiaractividad.Enabled = false;
            txtnombreactmod.Enabled = false;
            txtfundamentomod.Enabled = false;
            numericcreditosmod.Enabled = false;
            btnagregaractividad.Enabled = false;
            txtidact.Clear();
            txtnombreactmod.Clear();
            txtfundamentomod.Clear();
            numericcreditosmod.Value = 1;
            txtidact.Clear();

        }

        private void btnagregaractividad_Click(object sender, EventArgs e)
        {
            try
            {
                string idact = txtidact.Text;
                string nomact = txtnombreactmod.Text;
                string fundamento = txtfundamentomod.Text;
                int cant_creditos = Convert.ToInt32(numericcreditosmod.Value);

                con.Open();
                string cadena1 = "update Actividades_Complementarias set  Nombre_Actividad = '" + nomact + "', Fundamento_Actividad = '" + fundamento + "',Cant_Creditos =" + cant_creditos + " where Id_Actividad ='" + idact.ToString()+"'";
                SqlCommand actualizaract = new SqlCommand(cadena1, con);
                actualizaract.ExecuteNonQuery();
                MessageBox.Show("Actividad actualizada");
                con.Close();

                txtidact.Enabled = false;
                txtnombreactmod.Enabled = false;
                txtfundamentomod.Enabled = false;
                numericcreditosmod.Enabled = false;
            }
            catch(System.FormatException)
            {

            }
        }

        private void buscardocente_Click(object sender, EventArgs e)
        {
            try
            {
                int iddocente = Convert.ToInt32(txtiddocente.Text);
                bool docente = buscardocentes2(iddocente);
                if (docente == true)
                {
                    txtiddocente.Enabled = false;
                    buscardocente.Enabled = false;
                    limpiardocente.Enabled = true;
                    txtiddocente.Enabled = true;
                    txtnombremaestro.Enabled = true;
                    txtapepatmaestro.Enabled = true;
                    txtapematmaestro.Enabled = true;
                    btnagregardocente.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error al capturar datos");
                }
            }
            catch(System.FormatException)
            {

            }
        }

        private void limpiardocente_Click(object sender, EventArgs e)
        {
            txtiddocente.Enabled = true;
            buscardocente.Enabled = true;
            limpiardocente.Enabled = false;
            txtiddocente.Enabled = false;
            txtnombremaestro.Enabled = false;
            txtapepatmaestro.Enabled = false;
            txtapematmaestro.Enabled = false;
            btnagregardocente.Enabled = false;
            txtiddocente.Clear();
            txtiddocente.Clear();
            txtnombremaestro.Clear();
            txtapepatmaestro.Clear();
            txtapematmaestro.Clear();
            
        }

        private void btnagregardocente_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(txtiddocente.Text);
                string nombre = txtnombremaestro.Text;
                string apepat = txtapepatmaestro.Text;
                string apemat = txtapematmaestro.Text;

                con.Open();
                string cadena1 = "update Docente set Id_Docente =" + id + ",Nombre='" + nombre + "',Ape_Pat='" + apepat + "',Ape_Mat='" + apemat + "' where Id_Docente=" + id;
                SqlCommand actualizaract = new SqlCommand(cadena1, con);
                actualizaract.ExecuteNonQuery();
                MessageBox.Show("Docente actualizado");
                con.Close();

                txtiddocente.Enabled = false;
                txtnombremaestro.Enabled = false;
                txtapepatmaestro.Enabled = false;
                txtapematmaestro.Enabled = false;
                btnagregardocente.Enabled = false;
            }
            catch(SystemException)
            {
                MessageBox.Show("Un error ha surgido, verifique que este bien escrito y no haya otro maestro con ese mismo Id");
            }
           
        }
        //verificacion
        //docente
        private void txtiddocente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtnombremaestro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtapepatmaestro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtapematmaestro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        //alumno
        private void txtnocontrol_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtamodnom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtamodapepat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtamodapemat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        //credito
        private void numericcreditomod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void numericcalifmod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtcredito_KeyPress(object sender, KeyPressEventArgs e)
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
        //activdad complementaria
        private void txtidact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten letras y numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtnombreactmod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtfundamentomod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void numericcreditosmod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
