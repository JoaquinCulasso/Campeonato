using System;

namespace Campeonato
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarEquipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteEquipoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acercaDeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblTeam = new System.Windows.Forms.Label();
            this.lblTeamList = new System.Windows.Forms.ComboBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.mtxtAge = new System.Windows.Forms.MaskedTextBox();
            this.mtxtDni = new System.Windows.Forms.MaskedTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.prgbQuality = new System.Windows.Forms.ProgressBar();
            this.radioButtonEliminar = new System.Windows.Forms.RadioButton();
            this.btnConsult = new System.Windows.Forms.Button();
            this.radioButtonModificar = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(111, 35);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 20);
            this.txtFirstName.TabIndex = 0;
            this.txtFirstName.TextChanged += new System.EventHandler(this.Empty_Field_Form);
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(12, 42);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(44, 13);
            this.lblFirstName.TabIndex = 2;
            this.lblFirstName.Text = "Nombre";
            this.lblFirstName.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(111, 71);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(12, 78);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(44, 13);
            this.lblLastName.TabIndex = 4;
            this.lblLastName.Text = "Apellido";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(374, 268);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(456, 268);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 7;
            this.btnClean.Text = "Limpiar";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.operacionesToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(564, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // operacionesToolStripMenuItem
            // 
            this.operacionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarEquipoToolStripMenuItem,
            this.reporteEquipoToolStripMenuItem});
            this.operacionesToolStripMenuItem.Name = "operacionesToolStripMenuItem";
            this.operacionesToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.operacionesToolStripMenuItem.Text = "Operaciones";
            // 
            // agregarEquipoToolStripMenuItem
            // 
            this.agregarEquipoToolStripMenuItem.Name = "agregarEquipoToolStripMenuItem";
            this.agregarEquipoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.agregarEquipoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.agregarEquipoToolStripMenuItem.Text = "Agregar Equipo";
            this.agregarEquipoToolStripMenuItem.Click += new System.EventHandler(this.agregarEquipoToolStripMenuItem_Click);
            // 
            // reporteEquipoToolStripMenuItem
            // 
            this.reporteEquipoToolStripMenuItem.Name = "reporteEquipoToolStripMenuItem";
            this.reporteEquipoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.reporteEquipoToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.reporteEquipoToolStripMenuItem.Text = "Reporte Equipo";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acercaDeToolStripMenuItem});
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // acercaDeToolStripMenuItem
            // 
            this.acercaDeToolStripMenuItem.Name = "acercaDeToolStripMenuItem";
            this.acercaDeToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.acercaDeToolStripMenuItem.Text = "Acerca de...";
            this.acercaDeToolStripMenuItem.Click += new System.EventHandler(this.acercaDeToolStripMenuItem_Click);
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.AutoSize = true;
            this.lblBirthDate.Location = new System.Drawing.Point(12, 111);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(93, 13);
            this.lblBirthDate.TabIndex = 8;
            this.lblBirthDate.Text = "Fecha Nacimiento";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(12, 147);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(32, 13);
            this.lblAge.TabIndex = 9;
            this.lblAge.Text = "Edad";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd - MM - yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 105);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(104, 20);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblTeam
            // 
            this.lblTeam.AutoSize = true;
            this.lblTeam.Location = new System.Drawing.Point(12, 225);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(40, 13);
            this.lblTeam.TabIndex = 12;
            this.lblTeam.Text = "Equipo";
            // 
            // lblTeamList
            // 
            this.lblTeamList.FormattingEnabled = true;
            this.lblTeamList.Location = new System.Drawing.Point(111, 217);
            this.lblTeamList.Name = "lblTeamList";
            this.lblTeamList.Size = new System.Drawing.Size(121, 21);
            this.lblTeamList.TabIndex = 5;
            this.lblTeamList.Text = "Seleccione equipo";
            this.lblTeamList.SelectedIndexChanged += new System.EventHandler(this.lblTeamList_SelectedIndexChanged);
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(12, 185);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(26, 13);
            this.lblDni.TabIndex = 14;
            this.lblDni.Text = "DNI";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // mtxtAge
            // 
            this.mtxtAge.Location = new System.Drawing.Point(111, 140);
            this.mtxtAge.Mask = "99";
            this.mtxtAge.Name = "mtxtAge";
            this.mtxtAge.Size = new System.Drawing.Size(24, 20);
            this.mtxtAge.TabIndex = 3;
            this.mtxtAge.ValidatingType = typeof(int);
            this.mtxtAge.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtAge_MaskInputRejected);
            // 
            // mtxtDni
            // 
            this.mtxtDni.Location = new System.Drawing.Point(111, 178);
            this.mtxtDni.Mask = "99999999";
            this.mtxtDni.Name = "mtxtDni";
            this.mtxtDni.Size = new System.Drawing.Size(60, 20);
            this.mtxtDni.TabIndex = 4;
            this.mtxtDni.ValidatingType = typeof(int);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(374, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 163);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // prgbQuality
            // 
            this.prgbQuality.Location = new System.Drawing.Point(374, 204);
            this.prgbQuality.Name = "prgbQuality";
            this.prgbQuality.Size = new System.Drawing.Size(157, 23);
            this.prgbQuality.TabIndex = 16;
            this.prgbQuality.Click += new System.EventHandler(this.prgbQuality_Click);
            // 
            // radioButtonEliminar
            // 
            this.radioButtonEliminar.AutoSize = true;
            this.radioButtonEliminar.Location = new System.Drawing.Point(456, 233);
            this.radioButtonEliminar.Name = "radioButtonEliminar";
            this.radioButtonEliminar.Size = new System.Drawing.Size(61, 17);
            this.radioButtonEliminar.TabIndex = 18;
            this.radioButtonEliminar.TabStop = true;
            this.radioButtonEliminar.Text = "Eliminar";
            this.radioButtonEliminar.UseVisualStyleBackColor = true;
            this.radioButtonEliminar.CheckedChanged += new System.EventHandler(this.radioButtonEliminar_CheckedChanged);
            // 
            // btnConsult
            // 
            this.btnConsult.Location = new System.Drawing.Point(12, 268);
            this.btnConsult.Name = "btnConsult";
            this.btnConsult.Size = new System.Drawing.Size(75, 23);
            this.btnConsult.TabIndex = 19;
            this.btnConsult.Text = "Consultar";
            this.btnConsult.UseVisualStyleBackColor = true;
            this.btnConsult.Click += new System.EventHandler(this.btnConsult_Click);
            // 
            // radioButtonModificar
            // 
            this.radioButtonModificar.AutoSize = true;
            this.radioButtonModificar.Location = new System.Drawing.Point(374, 234);
            this.radioButtonModificar.Name = "radioButtonModificar";
            this.radioButtonModificar.Size = new System.Drawing.Size(68, 17);
            this.radioButtonModificar.TabIndex = 20;
            this.radioButtonModificar.TabStop = true;
            this.radioButtonModificar.Text = "Modificar";
            this.radioButtonModificar.UseVisualStyleBackColor = true;
            this.radioButtonModificar.CheckedChanged += new System.EventHandler(this.radioButtonModificar_CheckedChanged_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 303);
            this.Controls.Add(this.radioButtonModificar);
            this.Controls.Add(this.btnConsult);
            this.Controls.Add(this.radioButtonEliminar);
            this.Controls.Add(this.prgbQuality);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mtxtDni);
            this.Controls.Add(this.mtxtAge);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.lblTeam);
            this.Controls.Add(this.lblTeamList);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblBirthDate);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reporteEquipoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acercaDeToolStripMenuItem;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.ComboBox lblTeamList;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.MaskedTextBox mtxtDni;
        private System.Windows.Forms.MaskedTextBox mtxtAge;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar prgbQuality;
        private System.Windows.Forms.RadioButton radioButtonEliminar;
        private System.Windows.Forms.Button btnConsult;
        private System.Windows.Forms.RadioButton radioButtonModificar;
        private System.Windows.Forms.ToolStripMenuItem agregarEquipoToolStripMenuItem;
    }
}

