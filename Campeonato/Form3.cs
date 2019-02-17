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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConsultTeam_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
            {
                var query = @"SELECT First_Name, Last_Name, Birth_Date, Age, Camiseta, Dni, Team_Name FROM persona p, Team t WHERE p.Id_Team = t.Id_Team AND Team_Name = @Team_Name";
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                DataTable table = new DataTable();
                command.Parameters.Add(new SqlParameter("@Team_Name", txtTeamName.Text));
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }               
        }
    }
}
