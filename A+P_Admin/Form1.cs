using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;
using System.IO.Ports;

namespace A_P_Admin{
    public partial class Form1 : Form{
        public int xClick = 0, yClick = 0;
        int c = 0;
        string tipo = "Type",correo="Email";
        public Form1(){
            InitializeComponent();
            this.tTMsj.SetToolTip(this.cmbUsr, "Seleccione el usuario con el que iniciará sesión");
            this.tTMsj.SetToolTip(this.txtContraseña, "Ingrese la contraseña del usuario: " + cmbUsr.Text.ToString());
            this.tTMsj.SetToolTip(this.btnEntrar, "Presione el botón para iniciar sesión");
        }
        private void Form1_Load(object sender, EventArgs e){
            txtContraseña.Focus();
            llenC();
            cmbUsr.SelectedIndex = 0;
            String connString = "datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p";
            using (MySqlConnection con = new MySqlConnection(connString)){
                using (MySqlCommand cmd1 = new MySqlCommand("SELECT correo FROM usr WHERE usr ='" + cmbUsr.Text + "'")){
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Connection = con;
                    con.Open();
                    correo = cmd1.ExecuteScalar().ToString();
                    con.Close();
                    }
            }
        }
        private void iconMin_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void iconCerrar_Click(object sender, EventArgs e){
            const string message = "¿Desea cerrar el sistema?";
            const string caption = "Cerrar Sistema";
            var result = MessageBox.Show(message, caption,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes){
                Application.Exit();
            }else { }
        }
        private void label3_MouseMove(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left){
                xClick = e.X; yClick = e.Y;
            } else{
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }
        }
        private void btnEntrar_Click(object sender, EventArgs e){
            acceder();
        }
        private void txtContraseña_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyValue == (char)Keys.Enter){
                acceder();
            }else{
            }
        }

        private void acceder(){
            MySqlConnection connStr = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            connStr.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection con = new MySqlConnection();
            cmd.Connection = connStr;
            cmd.CommandText = "SELECT pass FROM usr WHERE pass = '" + txtContraseña.Text + "' AND usr ='" + cmbUsr.Text + "'";
            MySqlDataReader leer = cmd.ExecuteReader();
            if (leer.Read()){
                connStr.Close();
                Cons();
            }else{
                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                c++;
                txtContraseña.Text = "";
                txtContraseña.Focus();
                if (c == 3){
                    MessageBox.Show("Limite de Intentos excedido\nLa contraseña se cambiará y se enviará por correo al administrador\nPor favor pongase en contacto con él", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    NuC();
                    inhab();                    
                    c = 0;
                    Application.Exit();
                }
            }
        }
        private void NuC(){
            string n = "!#$12345%&/()=?¡\'+*{}[]-aABbCcKkLlMmNnOoPpQqRrSsDdEeFfGgHhIiJj06789TtUuVvWwXxYyZz_.;:,<>";
            Random r = new Random();
            int a = r.Next(0, n.Length);
            string cadena = n.Substring(a, 10);
            string nu = cadena;
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection connStr = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            try{
                connStr.Open();
                string consul = "UPDATE usr SET pass ='" + nu + "' WHERE usr = '" +cmbUsr.Text+"'";
                cmd = new MySqlCommand(consul, connStr);
                cmd.ExecuteNonQuery();
                connStr.Close();
                #region EnviarContraseña

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                msg.To.Add(correo);//Para quien
                msg.Subject = "Nueva contraseña del usuario: "+cmbUsr.Text;//Asunto
                msg.SubjectEncoding = System.Text.Encoding.UTF8;

                msg.Body = nu;//msj
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.From = new System.Net.Mail.MailAddress("agenciaap001@gmail.com");//Quien lo envia

                System.Net.Mail.SmtpClient cl = new System.Net.Mail.SmtpClient();
                cl.Credentials = new System.Net.NetworkCredential("agenciaap001@gmail.com", "Agencia1234"); //usuario y contraseña

                cl.Port = 587;
                cl.EnableSsl = true;

                cl.Host = "smtp.gmail.com"; //Dominio

                try{
                    cl.Send(msg);
                    MessageBox.Show("Se envio la nueva contraseña al administrador por correo electronico");
                }catch (Exception ex){
                    MessageBox.Show("Error al enviar" + ex);
                }
                #endregion
            }catch (Exception ex){
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void inhab(){
            txtContraseña.Enabled = false;
            btnEntrar.Enabled = false;
        }
        private void llenC(){
            using (MySqlConnection conn = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p")){
                string query = "SELECT id, usr from usr";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                cmbUsr.ValueMember = "id";
                cmbUsr.DisplayMember = "usr";
                cmbUsr.DataSource = dt;

            }
        }
        private void Cons(){            
            String connString = "datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p";
            using (MySqlConnection con = new MySqlConnection(connString)){
                using (MySqlCommand cmd = new MySqlCommand("SELECT type FROM usr WHERE pass = '" + txtContraseña.Text + "' AND usr ='" + cmbUsr.Text + "'")){
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    tipo = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            this.Hide();
            Principal pr = new Principal();
            pr.label1.Text = tipo;
            pr.Show();
        }
    }
}