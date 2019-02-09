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
using GriauleFingerprintLibrary;
using GriauleFingerprintLibrary.DataTypes;
using GriauleFingerprintLibrary.Exceptions;

namespace Campeonato
{
    public partial class Form1 : Form
    {

        private FingerprintCore fingerPrint;
        private FingerprintRawImage rawImage; //img original
        private FingerprintTemplate _template; //template donde se guarda la img

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
        }

        //muestra la imagen --> template (ver ExtractTemplate)
        void fingerPrint_onImage(object source, GriauleFingerprintLibrary.Events.ImageEventArgs ie)
        {
            rawImage = ie.RawImage;
            SetImage(ie.RawImage.Image);

            ExtractTemplate();

            //rawImage = ie.RawImage;

            //fingerPrint.Extract(rawImage, ref _template);
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
            if (Empty_Field(txtFirstName.Text, txtLastName.Text, _template, mtxtAge.Text, mtxtDni.Text, lblTeamList.Text) == false)
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {

                    var query = @"INSERT INTO persona (First_Name, Last_Name, Birth_Date, Age, Dni, Id_Team, Template, Model_Quality) VALUES (@First_Name, @Last_Name, @Birth_Date, @Age, @Dni, @Id_Team, @Template, @Model_Quality)";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.Add(new SqlParameter("@First_Name", txtFirstName.Text));
                    command.Parameters.Add(new SqlParameter("@Last_Name", txtLastName.Text));
                    command.Parameters.Add(new SqlParameter("@Birth_Date", dateTimePicker1.Value.ToString("yyyy/MM/dd")));
                    command.Parameters.Add(new SqlParameter("@Age", mtxtAge.Text));
                    command.Parameters.Add(new SqlParameter("@Dni", mtxtDni.Text));
                    command.Parameters.Add(new SqlParameter("@Id_Team", lblTeamList.Text));
                    command.Parameters.Add(new SqlParameter("@Template", (Object)_template.Buffer));
                    command.Parameters.Add(new SqlParameter("@Model_Quality", _template.Quality.ToString()));
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                MessageBox.Show("Se registró con éxito!!", "Programa con Joako", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnConsult_Click(object sender, EventArgs e)
        {
            if (Empty_Field(txtFirstName.Text, txtLastName.Text, _template, mtxtAge.Text, mtxtDni.Text, lblTeamList.Text) == false)
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ToString()))
                {
                    var query = "select First_Name, Last_Name, Birth_Date, Age, Dni, Id_Team, Template, Model_Quality from persona";
                    byte[] dataTemplate; //nos permitirá almacenar temporalmente el template de la B.D.
                    FingerprintTemplate templateTemp;
                    int precision, calidad;
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    int flag = 0;


                    //debemos preparar la libreria para la identificacion de huellas

                    fingerPrint.IdentifyPrepare(_template);

                    while (reader.Read())
                    {

                        dataTemplate = (byte[])reader["template"];// Extraemos el template desde la B.D.
                        calidad = (int)reader["Model_Quality"]; //extraemos la calidad de ese template

                        /* Creamos un nuevo objeto del tipo temporal "FingerprintTemplate" y asignamos las propiedades del template que acabamos de extraer de la B.D.*/
                        templateTemp = new GriauleFingerprintLibrary.DataTypes.FingerprintTemplate();
                        templateTemp.Buffer = dataTemplate;
                        templateTemp.Size = dataTemplate.Length;
                        templateTemp.Quality = calidad;
                        if ((fingerPrint.Identify(templateTemp, out precision)) == 1) //si el template cumple con los requisitos de presición
                        {
                            //MessageBox.Show(reader["First_Name"].ToString());
                            MessageBox.Show("jugador encontrado");
                            txtFirstName.ResetText();
                            txtFirstName.AppendText(reader["First_Name"].ToString());
                            txtLastName.ResetText();
                            txtLastName.AppendText(reader["Last_Name"].ToString());
                            dateTimePicker1.ResetText();
                            dateTimePicker1.Value = Convert.ToDateTime((reader["Birth_Date"].ToString()));
                            mtxtAge.ResetText();
                            mtxtAge.AppendText(reader["Age"].ToString());
                            mtxtDni.ResetText();
                            mtxtDni.AppendText(reader["Dni"].ToString());
                            lblTeamList.ResetText();
                            lblTeamList.SelectedText = reader["Id_Team"].ToString();
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

        private bool Empty_Field(String First_Name, String Last_Name, FingerprintTemplate _template, String Age, String Dni, String Team_List)
        {
            ////Campo nombre
            ////recorremos el campo y verificamos que los caracteres escritos sean correctos
            //bool error = false;

            //foreach (char caracter in txtFirstName.Text)
            //{
            //    if (!char.IsLetter(caracter))
            //    {
            //        error = true;
            //        break;

            //    }
            //}

            ////Verificamos por la condicion de error
            //if (error)
            //{
            //    errorProvider1.SetError(txtFirstName, "Solamente letras en el nombre");
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //}

            //if (txtFirstName.Text == null) {

            //}
            ////recorremos el campo y verificamos que los caracteres escritos sean correctos

            //foreach (char caracter in txtLastName.Text)
            //{
            //    if (!char.IsLetter(caracter))
            //    {
            //        error = true;
            //        break;
            //    }
            //}


            ////Verificamos por la condicion de error
            //if (error)
            //{
            //    errorProvider1.SetError(txtLastName, "Solamente letras en el apellido");
            //}
            //else
            //{
            //    errorProvider1.Clear();
            //}
            if (_template == null)
            {
                MessageBox.Show("Ingrese huella");
                return true;
            }
            else
            {
                return false;
            }

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
            lblTeamList.ResetText(); ;
        }

        private void lblTeamList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void prgbQuality_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }


    }
}

