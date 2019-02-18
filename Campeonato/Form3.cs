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
                var query = @"SELECT First_Name, Last_Name, Birth_Date, Age, Camiseta, Dni, Team_Name FROM persona p, team t WHERE p.Id_Team = t.Id_Team AND p.Id_Team = @Id_Team";
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
               
                DataTable table = new DataTable();
                command.Parameters.Add(new SqlParameter("@Id_Team", comboBoxTeam.SelectedValue));
              
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void comboBoxTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            fillCombo("SELECT Id_Team, Team_Name FROM team", "Team_Name", "Id_Team", comboBoxTeam, ConfigurationManager.ConnectionStrings["conexion"].ToString());
        }

        public static void fillCombo(string query, string displayMember, string valueMember, ComboBox comboBoxTeam, string connectionString)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                DataTable dataTable = new DataTable();
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection))
                {
                    sqlDataAdapter.Fill(dataTable);
                    comboBoxTeam.DataSource = dataTable;
                    comboBoxTeam.DisplayMember = displayMember;
                    comboBoxTeam.ValueMember = valueMember; //identificador
                    comboBoxTeam.SelectedIndex = -1;//opcional
                }
            }
        }
    }
}
