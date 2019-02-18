using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GriauleFingerprintLibrary;
using GriauleFingerprintLibrary.DataTypes;

namespace Campeonato
{
    public partial class Form1 : Form
    {

        private FingerprintCore fingerPrint;
        private FingerprintRawImage rawImage; //img original
        private FingerprintTemplate _template; //template donde se guarda la img
        private int Id_Person;


        public Form1()
        {
            InitializeComponent();
            fingerPrint = new FingerprintCore();
            fingerPrint.onStatus += new StatusEventHandler(fingerPrint_onStatus);//se dispara cada vez que un lector de huellas es conectado o desconectado
            //fingerPrint.onFinger += new FingerEventHandler(fingerPrint_onFinger);
            fingerPrint.onImage += new ImageEventHandler(fingerPrint_onImage);//se dispara cada vez que una imagen es adquirida por algún lector
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            fingerPrint.Initialize();
            fingerPrint.CaptureInitialize();
            fillCombo("SELECT Id_Team, Team_Name FROM team", "Team_Name", "Id_Team", lblTeamList, ConfigurationManager.ConnectionStrings["conexion"].ToString());
        }

        //muestra la imagen --> template (ver ExtractTemplate)
        void fingerPrint_onImage(object source, GriauleFingerprintLibrary.Events.ImageEventArgs ie)
        {
            rawImage = ie.RawImage;
            SetImage(ie.RawImage.Image);

            ExtractTemplate();
        }

        private delegate void delSetImage(Image img);
        void SetImage(Image img)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new delSetImage(SetImage), new object[] { img });
            }
            else
            {
                Bitmap bmp = new Bitmap(img, pictureBox1.Width, pictureBox1.Height);
                pictureBox1.Image = bmp;
            }
        }

        private void ExtractTemplate()
        {
            if (rawImage != null)
            {
                try
                {
                    _template = null;
                    fingerPrint.Extract(rawImage, ref _template);

                    SetQualityBar(_template.Quality);

                    DisplayImage(_template, false);
                }
                catch
                {
                    SetQualityBar(-1);
                }
            }
        }

        private FingerprintTemplate ExtractFingerprint()
        {
            _template = null;
            fingerPrint.Extract(rawImage, ref _template);
            return _template;

        }

        delegate void delsetQuality(int quality);
        private void SetQualityBar(int quality)
        {
            if (prgbQuality.InvokeRequired == true)
            {
                this.Invoke(new delsetQuality(SetQualityBar), new object[] { quality });
            }
            else
            {
                switch (quality)
                {
                    case 0:
                        {
                            //prgbQuality.ProgressBarColor = System.Drawing.Color.LightCoral;
                            prgbQuality.Value = prgbQuality.Maximum / 3;
                        }
                        break;
                    case 1:
                        {
                            //prgbQuality.ProgressBarColor = System.Drawing.Color.YellowGreen;
                            prgbQuality.Value = (prgbQuality.Maximum / 3) * 2;
                        }
                        break;
                    case 2:
                        {
                            //prgbQuality.ProgressBarColor = System.Drawing.Color.MediumSeaGreen;
                            prgbQuality.Value = prgbQuality.Maximum;
                        }
                        break;
                    default:
                        {
                            //prgbQuality.ProgressBarColor = System.Drawing.Color.Gray;
                            prgbQuality.Value = 0;
                        }
                        break;
                }
            }
        }

        private void DisplayImage(GriauleFingerprintLibrary.DataTypes.FingerprintTemplate template, bool identify)
        {
            IntPtr hdc = FingerprintCore.GetDC();
            IntPtr image = new IntPtr();

            if (identify)
            {
                fingerPrint.GetBiometricDisplay(template, rawImage, hdc, ref image, FingerprintConstants.GR_DEFAULT_CONTEXT);
                //button4.Enabled = true;
            }
            else
            {
                fingerPrint.GetBiometricDisplay(template, rawImage, hdc, ref image, FingerprintConstants.GR_NO_CONTEXT);
                //button2.Enabled = true;
            }

            SetImage(Bitmap.FromHbitmap(image));
            FingerprintCore.ReleaseDC(hdc);
        }

        void fingerPrint_onStatus(object source, GriauleFingerprintLibrary.Events.StatusEventArgs se)
        {
            if (se.StatusEventType == GriauleFingerprintLibrary.Events.StatusEventType.SENSOR_PLUG)
            {
                fingerPrint.StartCapture(source);//tostring()
            }
            else
            {
                fingerPrint.StartCapture(source);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            {
                if (Empty_Field(txtFirstName.Text, txtLastName.Text, _template, mtxtCamiseta.Text, mtxtDni.Text, lblTeamList.Text) == false)
                {
                    if (radioButtonModificar.Checked)
                    {
                        //ACA CUANDO PRESIONO MODIFICAR
                        using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                        {
                            var query = @"UPDATE persona SET First_Name = @First_Name, Last_Name = @Last_Name, Birth_Date = @Birth_Date, Age = @Age, Dni = @Dni, Camiseta = @Camiseta, Id_Team = @Id_Team, Model_Quality = @Model_Quality WHERE Id_Person = @Id_Person";

                            SqlCommand command = new SqlCommand(query, conn);
                            command.Parameters.Add(new SqlParameter("@First_Name", txtFirstName.Text));
                            command.Parameters.Add(new SqlParameter("@Last_Name", txtLastName.Text));
                            command.Parameters.Add(new SqlParameter("@Birth_Date", dateTimePicker1.Value.ToString("yyyy/MM/dd")));
                            command.Parameters.Add(new SqlParameter("@Age", mtxtAge.Text));
                            command.Parameters.Add(new SqlParameter("@Dni", mtxtDni.Text));
                            command.Parameters.Add(new SqlParameter("@Camiseta", mtxtCamiseta.Text));
                            command.Parameters.Add(new SqlParameter("@Id_Team", lblTeamList.SelectedValue));
                            command.Parameters.Add(new SqlParameter("@Template", (Object)_template.Buffer));
                            command.Parameters.Add(new SqlParameter("@Model_Quality", _template.Quality.ToString()));
                            command.Parameters.Add(new SqlParameter("@Id_Person", Id_Person));
                            DialogResult result =  MessageBox.Show("Desea confirmar la modificación?", "Confirmar", MessageBoxButtons.OKCancel);
                            if (result == DialogResult.OK)
                            {
                                conn.Open();
                                command.ExecuteNonQuery();
                                MessageBox.Show("Se actualizaron los datos", "Zona Argentino", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }                           
                        }
                    }
                    else
                    {
                        if (radioButtonEliminar.Checked)
                        {
                            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                            {
                                var query = @"DELETE from persona WHERE Id_Person = @Id_Person";

                                SqlCommand command = new SqlCommand(query, conn);
                                command.Parameters.Add(new SqlParameter("@Id_Person", Id_Person));

                                DialogResult result = MessageBox.Show("Desea eliminar el registro?", "Eliminar", MessageBoxButtons.OKCancel);
                                if (result == DialogResult.OK)
                                {
                                    conn.Open();
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Se eliminó con éxito!", "Zona Argentino", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnClean.PerformClick();
                                }
                               
                            }
                        }
                        else
                        {
                            //POR DEFECTO SI NO HAY NINGUN RADIOBUTTON ACTIVO, GUARDA EL REGISTRO.
                            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                            {

                                var query = @"INSERT INTO persona (First_Name, Last_Name, Birth_Date, Age, Dni, Camiseta, Id_Team, Template, Model_Quality) VALUES (@First_Name, @Last_Name, @Birth_Date, @Age, @Dni, @Camiseta, @Id_Team, @Template, @Model_Quality)";
                                SqlCommand command = new SqlCommand(query, conn);
                                command.Parameters.Add(new SqlParameter("@First_Name", txtFirstName.Text));
                                command.Parameters.Add(new SqlParameter("@Last_Name", txtLastName.Text));
                                command.Parameters.Add(new SqlParameter("@Birth_Date", dateTimePicker1.Value.ToString("yyyy/MM/dd")));
                                command.Parameters.Add(new SqlParameter("@Age", mtxtAge.Text));
                                command.Parameters.Add(new SqlParameter("@Dni", mtxtDni.Text));
                                command.Parameters.Add(new SqlParameter("@Camiseta", mtxtCamiseta.Text));
                                command.Parameters.Add(new SqlParameter("@Id_Team", lblTeamList.SelectedValue));
                                command.Parameters.Add(new SqlParameter("@Template", (Object)_template.Buffer));
                                command.Parameters.Add(new SqlParameter("@Model_Quality", _template.Quality.ToString()));
                                conn.Open();
                                command.ExecuteNonQuery();
                                MessageBox.Show("Se registró con éxito!", "Zona Argentino", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnClean.PerformClick();
                            }
                        }
                    }                   
                }
            }
        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            if (Empty_Field(_template) == false)
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    var query = "select Id_Person, First_Name, Last_Name, Birth_Date, Age, Dni, Camiseta, p.Id_Team, Team_Name, Template, Model_Quality from persona p, team t where p.Id_Team = t.Id_Team";
                    byte[] dataTemplate; //nos permitirá almacenar temporalmente el template de la B.D.
                    FingerprintTemplate templateTemp;
                    int precision, quality;
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    int flag = 0;

                    //debemos preparar la libreria para la identificacion de huellas

                    fingerPrint.IdentifyPrepare(_template);

                    while (reader.Read())
                    {
                        dataTemplate = (byte[])reader["template"];// Extraemos el template desde la B.D.
                        quality = (int)reader["Model_Quality"]; //extraemos la calidad de ese template

                        /* Creamos un nuevo objeto del tipo temporal "FingerprintTemplate" y asignamos las propiedades del template que acabamos de extraer de la B.D.*/
                        templateTemp = new GriauleFingerprintLibrary.DataTypes.FingerprintTemplate();
                        templateTemp.Buffer = dataTemplate;
                        templateTemp.Size = dataTemplate.Length;
                        templateTemp.Quality = quality;
                        if ((fingerPrint.Identify(templateTemp, out precision)) == 1) //si el template cumple con los requisitos de presición
                        {
                            MessageBox.Show("Jugador encontrado");
                            txtFirstName.ResetText();
                            txtFirstName.AppendText(reader["First_Name"].ToString());
                            txtLastName.ResetText();
                            txtLastName.AppendText(reader["Last_Name"].ToString());
                            dateTimePicker1.ResetText();
                            dateTimePicker1.Value = Convert.ToDateTime((reader["Birth_Date"].ToString()));
                            mtxtAge.ResetText();
                            mtxtAge.AppendText(reader["Age"].ToString());
                            mtxtCamiseta.ResetText();
                            mtxtCamiseta.AppendText(reader["Camiseta"].ToString());
                            mtxtDni.ResetText();
                            mtxtDni.AppendText(reader["Dni"].ToString());
                            lblTeamList.ResetText();
                            lblTeamList.SelectedText = reader["Team_Name"].ToString();
                            lblTeamList.SelectedValue = reader["Id_Team"].ToString();
                            Id_Person = (int)reader["Id_Person"];
                            flag = 1;
                            break;
                        }
                    }
                    if (flag < 1)
                    {
                        MessageBox.Show("no encontrado");
                    }
                }
            }
        }

        private bool Empty_Field(FingerprintTemplate template)
        {
            bool error = false;

            if (_template == null)
            {
                MessageBox.Show("Ingrese huella");
                return error = true;
            }
            return error;
        }

        private bool Empty_Field(String First_Name, String Last_Name, FingerprintTemplate _template, String Camiseta, String Dni, String Team_List)
        {
            bool error = false;

            if (_template == null)
            {
                MessageBox.Show("Ingrese huella");
                return error = true;
            }

            if (String.IsNullOrWhiteSpace(First_Name))
            {
                MessageBox.Show("Ingrese Nombre");
                return error = true;
            }
            if (String.IsNullOrWhiteSpace(Last_Name))
            {
                MessageBox.Show("Ingrese Apellido");
                return error = true;
            }

            if (String.IsNullOrWhiteSpace(Camiseta))
            {
                MessageBox.Show("Ingrese Camiseta");
                return error = true;
            }
            if (String.IsNullOrWhiteSpace(Dni))
            {
                MessageBox.Show("Ingrese DNI");
                return error = true;
            }
            if (Team_List.Equals("Seleccione equipo") || String.IsNullOrWhiteSpace(Team_List))
            {
                MessageBox.Show("Seleccione equipo");
                return error = true;
            }
            return error;
        }


        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {


        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("App Campeonato v1.0", "Programa Joako", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            mtxtAge.ResetText();
            SendKeys.Send("{Right}");
            mtxtAge.AppendText(getPlayerAge());

        }

        private void txtAge_TextChanged(object sender, EventArgs e)
        {

        }

        private void mtxtAge_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {


        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            dateTimePicker1.ResetText();
            mtxtAge.Clear();
            mtxtDni.Clear();
            mtxtCamiseta.Clear();
            lblTeamList.ResetText();
            pictureBox1.Image = null;
            prgbQuality.Value = 0;
            Id_Person = 0;
            _template = null;
        }

        public void lblTeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void prgbQuality_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonEliminar_CheckedChanged(object sender, EventArgs e)
        {
            isChecked = radioButtonEliminar.Checked;
        }

        private void radioButtonEliminar_Click(object sender, EventArgs e)
        {
            if (radioButtonEliminar.Checked && !isChecked)
                radioButtonEliminar.Checked = false;
            else
            {
                radioButtonEliminar.Checked = true;
                isChecked = false;
            }
        }

        public void RefreshForm1()
        {
            fillCombo("SELECT Id_Team, Team_Name FROM team", "Team_Name", "Id_Team", lblTeamList, ConfigurationManager.ConnectionStrings["conexion"].ToString());

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

        bool isChecked = false;
        private void radioButtonModificar_CheckedChanged_1(object sender, EventArgs e)
        {
            isChecked = radioButtonModificar.Checked;
        }

        private void radioButtonModificar_Click(object sender, EventArgs e)
        {
            if (radioButtonModificar.Checked && !isChecked)
                radioButtonModificar.Checked = false;
            else
            {
                radioButtonModificar.Checked = true;
                isChecked = false;
            }
        }

        private void agregarEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(this);
            frm2.Show();

        }

        private void mtxtCamiseta_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private String getPlayerAge()
        {
            //Tomo el año, mes y dia del Picker y los de fecha actual. Los transformo a int para poder calcular

            int birthDay = dateTimePicker1.Value.Day;
            int birthMonth = dateTimePicker1.Value.Month;
            int birthYear = dateTimePicker1.Value.Year;
            int currentDay = DateTime.Today.Day;
            int currentMonth = DateTime.Today.Month;
            int currentYear = DateTime.Today.Year;
            int yearsOld;

            //Inicio calculo edad
            yearsOld = currentYear - birthYear;

            //Si el mes actual es mayor al de nacimiento, directamente queda la edad calculada previamente.
            //Si el mes actual es menor al de nacimiento, hay que restar 1 a la edad calculada ya que aun no cumplio	
            if (currentMonth < birthMonth)
            {
                yearsOld--;
            }
            //Si el mes coincide, se comparan los dias. Si el dia actual es menor al de cumpleaños, se resta 1 ya que aun no cumplio
            else if (currentMonth == birthMonth)
            {

                if (currentDay < birthDay)
                {
                    yearsOld--;
                }
            }

            //Control en caso de que quede numero negativo o edad mayor a 100
            if (yearsOld < 0)
            {
                yearsOld = 0;
            }
            else if (yearsOld > 99)
            {
                yearsOld = 99;
            }

            string yearsOldCalculated = yearsOld.ToString();

            return yearsOldCalculated;
        }

        private void reporteEquipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        private void txtFirstName_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}



