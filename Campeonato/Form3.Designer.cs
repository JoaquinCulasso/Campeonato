namespace Campeonato
{
    partial class Form3
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.btnConsultTeam = new System.Windows.Forms.Button();
            this.campeonatoDataSet = new Campeonato.CampeonatoDataSet();
            this.campeonatoDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.campeonatoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.campeonatoDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 273);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtTeamName
            // 
            this.txtTeamName.Location = new System.Drawing.Point(104, 15);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(108, 20);
            this.txtTeamName.TabIndex = 1;
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Location = new System.Drawing.Point(12, 18);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(80, 13);
            this.lblTeamName.TabIndex = 2;
            this.lblTeamName.Text = "Nombre Equipo";
            // 
            // btnConsultTeam
            // 
            this.btnConsultTeam.Location = new System.Drawing.Point(228, 13);
            this.btnConsultTeam.Name = "btnConsultTeam";
            this.btnConsultTeam.Size = new System.Drawing.Size(91, 22);
            this.btnConsultTeam.TabIndex = 3;
            this.btnConsultTeam.Text = "Consultar";
            this.btnConsultTeam.UseVisualStyleBackColor = true;
            this.btnConsultTeam.Click += new System.EventHandler(this.btnConsultTeam_Click);
            // 
            // campeonatoDataSet
            // 
            this.campeonatoDataSet.DataSetName = "CampeonatoDataSet";
            this.campeonatoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // campeonatoDataSetBindingSource
            // 
            this.campeonatoDataSetBindingSource.DataSource = this.campeonatoDataSet;
            this.campeonatoDataSetBindingSource.Position = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 326);
            this.Controls.Add(this.btnConsultTeam);
            this.Controls.Add(this.lblTeamName);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.campeonatoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.campeonatoDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.Button btnConsultTeam;
        private CampeonatoDataSet campeonatoDataSet;
        private System.Windows.Forms.BindingSource campeonatoDataSetBindingSource;
    }
}