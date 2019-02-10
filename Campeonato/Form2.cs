using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Campeonato
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTeamName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Empty_Field(txtTeamName.Text) == false)
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {

                    var query = @"INSERT INTO team (Team_Name) VALUES (@Team_Name)";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.Add(new SqlParameter("@Team_Name", txtTeamName.Text));
                    conn.Open();
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Se registró equipo con éxito!!", "Programa con Joako", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTeamName.Clear();
            }
        }

        private bool Empty_Field(String Team_Name)
        {
            bool error = false;
            if (String.IsNullOrWhiteSpace(Team_Name))
            {
                MessageBox.Show("Ingrese Nombre");
                return error = true;
            }

            return error;
        }
    }
}
