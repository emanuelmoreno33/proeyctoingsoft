using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircularProgressBar;
using System.Threading;
using System.Windows.Shapes;


// DLL que permite los ajustes de la Form
using System.Runtime.InteropServices;
namespace Proyecto
{
    public partial class Froma : Form
    {
        // Variables y componentes locales
        private CircularProgressBar.CircularProgressBar CPB = new CircularProgressBar.CircularProgressBar();
        public Thread hilo;
        public bool llave = true;
        private Form froma;
        private int procentaje = 0;


        public Froma()
        {
            InitializeComponent();
            PanelP.Visible = false;
            PanelBar.Visible = false;
            Generar_CPB();
        }

        // Para Arastrar el from
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hund, int wmsg, int wparam, int lparam);

        // Metodo que genera un CircularProgressBar 
        public void Generar_CPB() {
            CPB.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            CPB.AnimationSpeed = 100;
            CPB.BackColor = System.Drawing.Color.Transparent;
            CPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CPB.ForeColor = System.Drawing.Color.White;
            CPB.InnerColor = System.Drawing.Color.Transparent;
            CPB.InnerMargin = 2;
            CPB.InnerWidth = -1;
            CPB.Location = new System.Drawing.Point(311, 116);
            CPB.MarqueeAnimationSpeed = 2000;
            CPB.Name = "CPB";
            CPB.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            CPB.OuterMargin = -25;
            CPB.OuterWidth = 25;
            CPB.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            CPB.ProgressWidth = 15;
            CPB.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            CPB.Size = new System.Drawing.Size(373, 364);
            CPB.StartAngle = 270;
            CPB.SubscriptColor = System.Drawing.Color.White;
            CPB.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            CPB.SubscriptText = "";
            CPB.SuperscriptColor = System.Drawing.Color.White;
            CPB.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            CPB.SuperscriptText = "%";
            CPB.TabIndex = 0;
            CPB.Text = "0";
            CPB.TextMargin = new System.Windows.Forms.Padding(8, 8, 0, 0);
            CPB.Value = 0;
            Controls.Add(CPB);
        }

        
        // Metodo donde inica 
        public void Inciar() {
            froma = new From_Inicio
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            PanelP.Controls.Add(froma);
            btnIniciar.BackColor = Color.FromArgb(86, 89,120);
            froma.Show();

        }

        // Metodo donde se cambia el color los botones
        public void Cambio_botones(){
            btnEditar.BackColor = Color.Transparent;
            bntBuscar.BackColor = Color.Transparent;
            btnAgregar.BackColor = Color.Transparent;
            btnIniciar.BackColor = Color.Transparent;
            btnGenerar.BackColor = Color.Transparent;
            bntBuscar.BackColor = Color.Transparent;
    }
        // Donde podemos mover la ventana 
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        
        
       // Cierra la aplicacion
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Minizar la aplicacion
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        
        // Boton de Generar
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            lbltitulo.Text = "Creditos Complementarios - Generar";
            Type t = froma.GetType();
            if (!(t.Equals(typeof(From_Generar))))
            {
                Cambio_botones();
                froma.Close();
                froma = new From_Generar
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                PanelP.Controls.Add(froma);
                btnGenerar.BackColor = Color.FromArgb(86, 89, 120);
                froma.Show();
            }
        }
        // Boton de Inicio
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Cambio_botones();
            froma.Close();
            Inciar();
            lbltitulo.Text = "Creditos complementarios - Inicio";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CPB.Value = procentaje;
            CPB.Text = CPB.Value.ToString();
            if (procentaje == 100) {
                CPB.Visible = false;
                PanelMV.Visible = true;
                PanelP.Visible = true;
                PanelBar.Visible = true;
                timer1.Enabled = false;
                Inciar();
            }
            procentaje += 5;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            lbltitulo.Text = "Creditos complementarios - Editar";
            Type t = froma.GetType();
            if (!(t.Equals(typeof(Form_Editar)))) {
                Cambio_botones();
                froma.Close();
                froma = new Form_Editar
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                PanelP.Controls.Add(froma);
                btnEditar.BackColor = Color.FromArgb(86, 89, 120);
                froma.Show();
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            lbltitulo.Text = "Creditos complementarios - Agregar";
            Type t = froma.GetType();
            if (!(t.Equals(typeof(From_Agregar))))
            {
                Cambio_botones();
                froma.Close();
                froma = new From_Agregar
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                PanelP.Controls.Add(froma);
                btnAgregar.BackColor = Color.FromArgb(86, 89, 120);
                froma.Show();
            }
        }

        private void bntBuscar_Click(object sender, EventArgs e)
        {
            lbltitulo.Text = "Creditos complementarios - Buscar";
            Type t = froma.GetType();
            if (!(t.Equals(typeof(Form_Buscar))))
            {
                Cambio_botones();
                froma.Close();
                froma = new Form_Buscar
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                    Dock = DockStyle.Fill
                };
                PanelP.Controls.Add(froma);
                bntBuscar.BackColor = Color.FromArgb(86, 89, 120);
                froma.Show();
            }

        }

        private void lbltitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
