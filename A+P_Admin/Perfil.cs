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

namespace A_P_Admin{
    public partial class Perfil : Form{
        public int a=1,cont=0, xClick = 0, yClick = 0;
        string contra="",usr= "",correo="";
        public Perfil(){
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox2, "Prsione la imagen para regresar a la pantalla principal");
        }
        private void Perfil_Load(object sender, EventArgs e){
            if (a == 2 && label1.Text=="Admin"){
                label2.Text = "Bienvenido Administrador";
                label8.Text = "Actualizar contraseña";
                gBemail.Visible = false;
                gBContra.Visible = true;
            }else if (a == 3 && label1.Text == "Admin"){
                label2.Text = "Bienvenido Administrador";
                label8.Text = "Actualizar email";
                gBContra.Visible = false;
                gBemail.Visible = true;
            }else if (a == 2 && label1.Text == "SU"){
                label2.Text = " Bienvenido Ing. Javier";
                label8.Text = "Actualizar contraseña";
                gBemail.Visible = false;
                gBContra.Visible = true;
            }else if (a == 3 && label1.Text == "SU"){
                label2.Text = "Bienvenido Ing. Javier";
                label8.Text = "Actualizar email";
                gBContra.Visible = false;
                gBemail.Visible = true;
            }

        }
        private void pictureBox2_Click(object sender, EventArgs e){
            Regresar();
        }
        private void button2_Click(object sender, EventArgs e){
            txtC1.Text = "";
            txtC2.Text = "";
            gBContra.Enabled = false;
        }
        private void button3_Click(object sender, EventArgs e){
            txtEmail.Text = "";
            gBemail.Enabled = false;
        }
        private void button1_Click(object sender, EventArgs e){
            kpCont();
        }
        private void button4_Click(object sender, EventArgs e){
            NuCorr();
        }
        private void txtEmail_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyValue == (char)Keys.Enter){
                NuCorr();
            }else{
            }
        }
        private void txtC2_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyValue == (char)Keys.Enter){
                kpCont();
            }else{
            }
        }
        private void label8_MouseMove(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left){
                xClick = e.X; yClick = e.Y;
            }else{
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void pictureBox5_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Realmente desea cerrar la aplicación ?","Advertencia",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res==DialogResult.Yes){
                Application.Exit();
            }else {
            }
        }

        private string pass(){
            if (label1.Text == "Admin"){
                usr = "Administrador";
            }else if(label1.Text == "SU"){
                usr = "Javier";
            }

            String connString = "datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p";
                using (MySqlConnection con = new MySqlConnection(connString)){
                using (MySqlCommand cmd = new MySqlCommand("SELECT pass FROM usr WHERE usr ='"+usr+"'")){
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    contra = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            return contra;
        }
        private string corr(){
            if (label1.Text == "Admin"){
                usr = "Administrador";
            }else if(label1.Text == "SU"){
                usr = "Javier";
            }

            String connString = "datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p";
                using (MySqlConnection con = new MySqlConnection(connString)){
                using (MySqlCommand cmd = new MySqlCommand("SELECT correo FROM usr WHERE usr ='"+usr+"'")){
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    correo = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            return correo;
        }
        private void Not(){
            try{
                #region EnviarCorreo

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                msg.To.Add(corr());//Para quien
                msg.Subject = "Alerta de seguridad en el sistema NominaQr ";//Asunto
                msg.SubjectEncoding = System.Text.Encoding.UTF8;

                msg.Body = "ALguien trató de cambiar su contraseña, no olvide cerrar sesión por seguridad";//msj
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
                    MessageBox.Show("Notificación enviada");
                }catch (Exception ex){
                    MessageBox.Show("Error al enviar" + ex);
                }
                #endregion
            }catch (Exception ex){
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void NuC(){
            if (label1.Text == "Admin"){
                usr = "Administrador";
            }else if(label1.Text == "SU"){
                usr = "Javier";
            }

            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection connStr = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            try{
                connStr.Open();
                string consul = "UPDATE usr SET pass ='" + txtC2.Text + "' WHERE usr = '" +usr+"'";
                cmd = new MySqlCommand(consul, connStr);
                cmd.ExecuteNonQuery();
                connStr.Close();
                MessageBox.Show("Contraseña actualizada", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #region EnviarContraseña

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                msg.To.Add(corr());//Para quien
                msg.Subject = "Nueva contraseña del usuario: "+usr;//Asunto
                msg.SubjectEncoding = System.Text.Encoding.UTF8;

                msg.Body = "Su nueva contraseña es: "+txtC1.Text;//msj
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
                    MessageBox.Show("Se envio la nueva contraseña al usuario por correo electronico");
                }catch (Exception ex){
                    MessageBox.Show("Error al enviar" + ex);
                }
                #endregion
            }catch (Exception ex){
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void NuCorr(){
            if (label1.Text == "Admin"){
                usr = "Administrador";
            }else if(label1.Text == "SU"){
                usr = "Javier";
            }

            if (txtEmail.Text == ""){
                MessageBox.Show("Debe ingresar un email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else{
                MySqlCommand cmd = new MySqlCommand();
                MySqlConnection connStr = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
                try{
                    #region EnviarContraseña

                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

                msg.To.Add(corr());//Para quien
                msg.Subject = "Nuevo correo del usuario: "+usr;//Asunto
                msg.SubjectEncoding = System.Text.Encoding.UTF8;

                msg.Body = "Se solicitó cambiar el email actual por: "+txtEmail.Text+"\nSi no solicitó este cambio, por favor cambie el email por el que utilice desde la aplicación, para continuar recibiendo alertas.\nComo consejo no olvide cerrar sesion cada que no utilice la app, o cuando requiera dejar su sitio de trabajo";//msj
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
                    MessageBox.Show("Se envio el nuevo email al usuario");
                }catch (Exception ex){
                    MessageBox.Show("Error al enviar" + ex);
                }
                #endregion
                    connStr.Open();
                    string consul = "UPDATE usr SET correo ='" + txtEmail.Text + "' WHERE usr = '" +usr+"'";
                    cmd = new MySqlCommand(consul, connStr);
                    cmd.ExecuteNonQuery();
                    connStr.Close();
                    MessageBox.Show("Email actualizado", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                }catch (Exception ex){
                    MessageBox.Show("Error: " + ex.Message);
                }
                Regresar();
            }
        }
        private void Regresar(){
            this.Dispose();
            Principal pr = new Principal();
            pr.label1.Text = label1.Text;
            pr.Show();
        }
        private void kpCont(){
            if (txtC2.Text == "" || txtC1.Text == ""){
                MessageBox.Show("Por favor ingrese los datos solicitados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtC1.Focus();
            }else if (txtC1.Text!=pass()){
                MessageBox.Show("Contraseña incorrecta\n cuenta con un limite de 3 intentos, posteriormente se cerrará la app y se notificará al usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cont++;
                txtC1.Text = "";
                txtC1.Focus();
                if (cont == 3){
                    MessageBox.Show("Limite de Intentos excedido\nLa aplicación se cerrará y se notificará al usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Not();
                    gBContra.Enabled = false;
                    cont = 0;
                    Application.Exit();
                }
            }else{
                if (txtC1.Text == txtC2.Text){
                    MessageBox.Show("La nueva contraseña, no puede ser la contraseña anterior", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtC2.Text="";
                    txtC2.Focus();
                }else {
                    NuC();
                    Regresar();
                }
            }
        }
    }
}