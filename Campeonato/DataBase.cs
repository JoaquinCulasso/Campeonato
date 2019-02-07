using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using GriauleFingerprintLibrary.DataTypes;
using System.Data;

namespace Campeonato
{
    class DataBase
    {

        public SqlConnection conn;

        private AccessDataAccessLayer()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString());
        }

        public void SaveTemplate(FingerprintTemplate fingerprintTemplate, String FirstName, String LastName, DateTime BirthDate, int Age, int Dni, int IdTeam)
        {

            using (conn)
            {
                conn.Open();

                var query = @"INSERT INTO persona (First_Name, Last_Name, Birth_Date, Age, Dni, Id_Team, Finger_Print) VALUES (@First_Name, @Last_Name, @Birth_Date, @Age, @Dni, @Id_Team, @template)";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.Add(new SqlParameter("@First_Name", FirstName));
                command.Parameters.Add(new SqlParameter("@Last_Name", LastName));
                command.Parameters.Add(new SqlParameter("@Birth_Date", BirthDate));
                command.Parameters.Add(new SqlParameter("@Age", Age));
                command.Parameters.Add(new SqlParameter("@Dni", Dni));
                command.Parameters.Add(new SqlParameter("@Id_Team", IdTeam));
                command.Parameters.Add(new SqlParameter("@template", System.Data.SqlDbType.VarBinary, fingerprintTemplate.Size, System.Data.ParameterDirection.Input, false, 0, 0, "Dni", System.Data.DataRowVersion.Current, fingerprintTemplate.Buffer));

                command.ExecuteNonQuery();
                conn.Close();

                //string strCommand = "INSERT INTO ENROLL(template,quality) VALUES (?,?)";
                //OleDbCommand oleCommand = new OleDbCommand(strCommand, dbConection);
                //oleCommand.Parameters.Add(new OleDbParameter("@template", OleDbType.VarBinary, fingerprintTemplate.Size, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Current, fingerprintTemplate.Buffer));
                //oleCommand.Parameters.Add(new OleDbParameter("@quality", OleDbType.Integer));
                //oleCommand.Parameters["@quality"].Value = fingerprintTemplate.Quality;

            }


        }

        public IDataReader GetTemplates()
        {


            conn.Open();

            string query = "SELECT First_Name, Last_Name, Birth_Date, Age, Dni, Id_Team, Finger_Print FROM persona";

            SqlCommand command = new SqlCommand(query, conn);

            return command.ExecuteReader();

        }
    }
}


