namespace Proyecto
{
    partial class Form_Buscar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.combobuscado = new System.Windows.Forms.ComboBox();
            this.raddocente = new System.Windows.Forms.RadioButton();
            this.radactividad = new System.Windows.Forms.RadioButton();
            this.radcarrera = new System.Windows.Forms.RadioButton();
            this.radNocontrol = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Info_Buscar = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.combobuscado);
            this.panel1.Controls.Add(this.raddocente);
            this.panel1.Controls.Add(this.radactividad);
            this.panel1.Controls.Add(this.radcarrera);
            this.panel1.Controls.Add(this.radNocontrol);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtBuscar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(16, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 585);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Proyecto.Properties.Resources.infos;
            this.pictureBox3.Location = new System.Drawing.Point(544, 514);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 52);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 35;
            this.pictureBox3.TabStop = false;
            this.Info_Buscar.SetToolTip(this.pictureBox3, "Oprima el botón para generar el reporte del credito solicitado.");
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Proyecto.Properties.Resources.infos;
            this.pictureBox2.Location = new System.Drawing.Point(1009, 102);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 52);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            this.Info_Buscar.SetToolTip(this.pictureBox2, "Seleccione con el boton el tipo de elemento que desea encontrar, escriba su busqu" +
        "eda y oprima el boton Buscar.");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Proyecto.Properties.Resources.infos;
            this.pictureBox1.Location = new System.Drawing.Point(1009, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            this.Info_Buscar.SetToolTip(this.pictureBox1, "En esta pestaña podrá buscar alumnos, carreras, actividades complementarias y doc" +
        "entes que se encuentran almacenados en la base de datos.");
            // 
            // combobuscado
            // 
            this.combobuscado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combobuscado.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combobuscado.FormattingEnabled = true;
            this.combobuscado.Location = new System.Drawing.Point(32, 52);
            this.combobuscado.Margin = new System.Windows.Forms.Padding(4);
            this.combobuscado.Name = "combobuscado";
            this.combobuscado.Size = new System.Drawing.Size(457, 31);
            this.combobuscado.TabIndex = 29;
            this.combobuscado.Visible = false;
            // 
            // raddocente
            // 
            this.raddocente.AutoSize = true;
            this.raddocente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.raddocente.ForeColor = System.Drawing.Color.White;
            this.raddocente.Location = new System.Drawing.Point(741, 112);
            this.raddocente.Margin = new System.Windows.Forms.Padding(4);
            this.raddocente.Name = "raddocente";
            this.raddocente.Size = new System.Drawing.Size(239, 27);
            this.raddocente.TabIndex = 28;
            this.raddocente.TabStop = true;
            this.raddocente.Text = "Docente que autoriza";
            this.raddocente.UseVisualStyleBackColor = true;
            this.raddocente.CheckedChanged += new System.EventHandler(this.raddocente_CheckedChanged);
            // 
            // radactividad
            // 
            this.radactividad.AutoSize = true;
            this.radactividad.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radactividad.ForeColor = System.Drawing.Color.White;
            this.radactividad.Location = new System.Drawing.Point(393, 112);
            this.radactividad.Margin = new System.Windows.Forms.Padding(4);
            this.radactividad.Name = "radactividad";
            this.radactividad.Size = new System.Drawing.Size(290, 27);
            this.radactividad.TabIndex = 27;
            this.radactividad.TabStop = true;
            this.radactividad.Text = "Actividad Complementaria";
            this.radactividad.UseVisualStyleBackColor = true;
            this.radactividad.CheckedChanged += new System.EventHandler(this.radactividad_CheckedChanged);
            // 
            // radcarrera
            // 
            this.radcarrera.AutoSize = true;
            this.radcarrera.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radcarrera.ForeColor = System.Drawing.Color.White;
            this.radcarrera.Location = new System.Drawing.Point(229, 112);
            this.radcarrera.Margin = new System.Windows.Forms.Padding(4);
            this.radcarrera.Name = "radcarrera";
            this.radcarrera.Size = new System.Drawing.Size(109, 27);
            this.radcarrera.TabIndex = 26;
            this.radcarrera.TabStop = true;
            this.radcarrera.Text = "Carrera";
            this.radcarrera.UseVisualStyleBackColor = true;
            this.radcarrera.CheckedChanged += new System.EventHandler(this.radcarrera_CheckedChanged);
            // 
            // radNocontrol
            // 
            this.radNocontrol.AutoSize = true;
            this.radNocontrol.Checked = true;
            this.radNocontrol.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNocontrol.ForeColor = System.Drawing.Color.White;
            this.radNocontrol.Location = new System.Drawing.Point(32, 112);
            this.radNocontrol.Margin = new System.Windows.Forms.Padding(4);
            this.radNocontrol.Name = "radNocontrol";
            this.radNocontrol.Size = new System.Drawing.Size(141, 27);
            this.radNocontrol.TabIndex = 25;
            this.radNocontrol.TabStop = true;
            this.radNocontrol.Text = "No. Control";
            this.radNocontrol.UseVisualStyleBackColor = true;
            this.radNocontrol.CheckedChanged += new System.EventHandler(this.radNocontrol_CheckedChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(89)))), ((int)(((byte)(120)))));
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::Proyecto.Properties.Resources.file_pdf___1754_;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(327, 514);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(209, 52);
            this.button2.TabIndex = 24;
            this.button2.Text = "Generar Reporte";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(89)))), ((int)(((byte)(120)))));
            this.listBox2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.listBox2.ForeColor = System.Drawing.Color.White;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 23;
            this.listBox2.Location = new System.Drawing.Point(505, 181);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(551, 280);
            this.listBox2.TabIndex = 23;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(89)))), ((int)(((byte)(120)))));
            this.listBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 23;
            this.listBox1.Location = new System.Drawing.Point(17, 181);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(472, 280);
            this.listBox1.TabIndex = 22;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(32, 85);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 1);
            this.panel2.TabIndex = 17;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(89)))), ((int)(((byte)(120)))));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.txtBuscar.ForeColor = System.Drawing.Color.White;
            this.txtBuscar.Location = new System.Drawing.Point(32, 63);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(459, 24);
            this.txtBuscar.TabIndex = 15;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(28, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Consultar por Alumno, Carrera, AC o Docente que autoriza. ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(89)))), ((int)(((byte)(120)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(66)))), ((int)(((byte)(97)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::Proyecto.Properties.Resources.search_right___1507_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(515, 58);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "Buscar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Info_Buscar
            // 
            this.Info_Buscar.AutomaticDelay = 1000;
            this.Info_Buscar.AutoPopDelay = 20000;
            this.Info_Buscar.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.Info_Buscar.InitialDelay = 1000;
            this.Info_Buscar.ReshowDelay = 200;
            this.Info_Buscar.ToolTipTitle = "Pestaña Buscar";
            // 
            // Form_Buscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(89)))), ((int)(((byte)(120)))));
            this.ClientSize = new System.Drawing.Size(1089, 609);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Buscar";
            this.Text = "Form_Buscar";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton raddocente;
        private System.Windows.Forms.RadioButton radactividad;
        private System.Windows.Forms.RadioButton radcarrera;
        private System.Windows.Forms.RadioButton radNocontrol;
        private System.Windows.Forms.ComboBox combobuscado;
        private System.Windows.Forms.ToolTip Info_Buscar;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}