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
    public partial class From_Agregar : Form
    {
        SqlConnection conex = new SqlConnection("server=EMANUELMR-OMEN\\SQLEXPRESS;database=Creditos_Complementarios;integrated security = true");

        public From_Agregar()
        {
            InitializeComponent();
        }

        private void introducircarreras()
        {
            conex.Open();
            string cadena = "select Nombre_Carrera from Carrera";
            SqlCommand comando = new SqlCommand(cadena, conex);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                combocarrera.Items.Add(registros["Nombre_Carrera"].ToString());
            }
            conex.Close();
        }

        private void introducirdocente()
        {
            conex.Open();
            string cadena2 = "select Nombre,Ape_Pat,Ape_Mat from Docente";
            SqlCommand comando2 = new SqlCommand(cadena2, conex);
            SqlDataReader registros2 = comando2.ExecuteReader();
            while (registros2.Read())
            {
                combodocente.Items.Add(registros2["Nombre"].ToString() + " " + registros2["Ape_Pat"].ToString() + " " + registros2["Ape_Mat"].ToString());
            }
            conex.Close();
        }

        private int buscardocente(string docente)
        {
            //docente
            conex.Open();
            string cadena2 = "select Id_Docente,Nombre,Ape_Pat,Ape_Mat from Docente";
            SqlCommand comando2 = new SqlCommand(cadena2, conex);
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
            conex.Close();
            if (bandera == true)
            {
                return iddocente;
            }
            else
            {
                return 0;
            }
        }

        private string buscarcarrera(string carrera)
        {
            //carrera
            string idcarrera = "";
            conex.Open();
            string cadena1 = "select * from Carrera where Nombre_Carrera ='" + carrera + "'";
            SqlCommand comando = new SqlCommand(cadena1, conex);
            SqlDataReader registros = comando.ExecuteReader();
            if (registros.Read())
            {
                idcarrera = registros["Id_Carrera"].ToString();
            }
            else
            {
                MessageBox.Show("error en carrera");
                idcarrera = "nulo";
            }
            conex.Close();
            return idcarrera;        
        }

        public void todos()
        {
            btnalumno.BackColor = Color.FromArgb(56, 89, 120);
            btnactividad.BackColor = Color.FromArgb(56, 89, 120);
            btndocente.BackColor = Color.FromArgb(56, 89, 120);
            btnalumno.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 89, 120);
            btnactividad.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 89, 120);
            btndocente.FlatAppearance.MouseDownBackColor = Color.FromArgb(56, 89, 120);
            btnalumno.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 89, 120);
            btnactividad.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 89, 120);
            btndocente.FlatAppearance.MouseOverBackColor = Color.FromArgb(56, 89, 120);
        }

        private void btnagregar1_Click(object sender, EventArgs e)
        {
            try
            {
                int nocontrol = Convert.ToInt32(txtnocontrol.Text);
                string nombre = txtnombre.Text;
                string apepat = txtapepat.Text;
                string apemat = txtapemat.Text;
                string idcarrera = buscarcarrera(combocarrera.Text);
                conex.Open();
                string cadena5 = "insert into Alumnos (No_Control,Nombre,Ape_Pat,Ape_Mat,Id_Carrera) values ("+nocontrol+",'"+nombre+"','"+apepat+"','"+apemat+"','"+idcarrera +"')";
                SqlCommand comando5 = new SqlCommand(cadena5, conex);
                comando5.ExecuteNonQuery();
                conex.Close();
                MessageBox.Show("El alumno fue agregado","Agregado exitosamente");
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Introduzca los valores correctos", "Advertencia");
            }
        }

        private void btnalumno_Click(object sender, EventArgs e)
        {
            todos();
            btnalumno.BackColor= Color.LimeGreen;
            btnalumno.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
            btnalumno.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            panelAlumno.Visible = true;
            panelDocente.Visible = false;
            panelAct.Visible = false;
        }

        private void btndocente_Click(object sender, EventArgs e)
        {
            todos();
            btndocente.BackColor = Color.LimeGreen;
            btndocente.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
            btndocente.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            panelDocente.Visible = true;
            panelAlumno.Visible = false;
            panelAct.Visible = false;
        }

        private void btnactividad_Click(object sender, EventArgs e)
        {
            todos();
            btnactividad.BackColor = Color.LimeGreen;
            btnactividad.FlatAppearance.MouseDownBackColor = Color.LimeGreen;
            btnactividad.FlatAppearance.MouseOverBackColor = Color.LimeGreen;
            panelAct.Visible = true;
            panelAlumno.Visible = false;
            panelDocente.Visible = false;
        }

        //se agregan los datos correspondientes
        //actividad
        private void btnagregaractividad_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtidactividad.Text;
                string actividad = txtnombreact.Text;
                string fundamento = txtfundamento.Text;
                int credito = Convert.ToInt32(creditos.Value);
                int docente = buscardocente(combodocente.Text);
                conex.Open();
                string cadena5 = "insert into Actividades_Complementarias (Id_Actividad,Nombre_Actividad,Fundamento_Actividad,Cant_Creditos) values('"+id+"','"+actividad+"','"+fundamento+"',"+credito+")";
                SqlCommand comando5 = new SqlCommand(cadena5, conex);
                comando5.ExecuteNonQuery();
                conex.Close();
                conex.Open();
                string cadena4 = "insert into Docente_Actividades (Id_Docente,Id_Actividad) values(" + docente + ",'"+id+"')";
                SqlCommand comando4 = new SqlCommand(cadena4, conex);
                comando4.ExecuteNonQuery();
                conex.Close();
                MessageBox.Show("La actividad fue agregada", "Agregado exitosamente");

            }
            catch (System.FormatException)
            {
                MessageBox.Show("Revise los datos", "Advertencia");
            }
        }
        //docente
        private void btnagregardocente_Click(object sender, EventArgs e)
        {
            try
            {
                int idmaestro = Convert.ToInt32(txtidmaestro.Text);
                string nombre = txtnombremaestro.Text;
                string ape_pat = txtapepatmaestro.Text;
                string ape_mat = txtapematmaestro.Text;
                    conex.Open();
                    string cadena5 = "insert into Docente (Id_Docente,Nombre,Ape_Pat,Ape_Mat) values (" + idmaestro + ",'" + nombre + "','" + ape_pat + "','" + ape_mat + "')";
                    SqlCommand comando5 = new SqlCommand(cadena5, conex);
                    comando5.ExecuteNonQuery();
                    conex.Close();
                MessageBox.Show("El docente fue agregado", "Agregado exitosamente");
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Revise los datos", "Advertencia");
            }
        }

        private void From_Agregar_Load(object sender, EventArgs e)
        {
            introducircarreras();
            introducirdocente();
        }

        //verificacion
        //docente
        private void txtidmaestro_KeyPress(object sender, KeyPressEventArgs e)
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
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtapepatmaestro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtapematmaestro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        //actividades complementarias
        private void txtidactividad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtnombreact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtfundamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (!(char.IsNumber(e.KeyChar))) && (e.KeyChar != (char)Keys.Space))
            {
                MessageBox.Show("Solo se permiten letras y números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void creditos_KeyPress(object sender, KeyPressEventArgs e)
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
