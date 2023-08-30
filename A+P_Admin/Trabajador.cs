using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QRCoder.PayloadGenerator;
using MySql.Data.MySqlClient;

namespace A_P_Admin{    
    public partial class Trabajador : Form{
        public int xClick = 0, yClick = 0, a = 0;
        string Sqr = "",id="";
        public Trabajador(){
            InitializeComponent();
        }
        private void Trabajador_Load(object sender, EventArgs e){
            llenC();
            cmbUsr.SelectedIndex = 0;
            lblFecha.Text = DateTime.Now.ToShortDateString();
            gBact.Visible = false;
            label6.Visible = false;
            if (a==1){
                label3.Text = "Registrar trabajador";
                Sqr = "RCañedo";
                qr();
                pbQr.Visible = false;
                gBReg.Visible = true;
            }else if (a == 2){
                label3.Text = "Modificar trabajador";
                gBact.Visible = true;
                pbQr.Visible = false;
                btnEl.Visible = false;
                gBReg.Visible = false;
                label6.Text = "Escane el codigo Qr para \n   Modificar el trabajador";
            }else if (a == 3){
                label3.Text = "Eliminar trabajador";
                pbQr.Visible = false;
                gBact.Visible = true;
                gBReg.Visible = false;
                btnEl.Visible = true;
                button1.Visible = false;
            }
        }
        private void iconCerrar_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Realmente desea cerrar la aplicación ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                Environment.Exit(0);
            }else { }
        }
        private void iconMin_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void button1_Click(object sender, EventArgs e){
            gBact.Visible = false;
            pbQr.Visible = true;
            qr();
            label6.Visible=true;
        }
        private void label3_MouseMove(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left){
                xClick = e.X; yClick = e.Y;
            }else{
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }
        }
        private void btnEl_Click(object sender, EventArgs e){
            eliminar();
        }
        private void pictureBox2_Click(object sender, EventArgs e){
            Regresar();
        }        
        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsNumber(e.KeyChar)){
                e.Handled = false;
            }else if(char.IsControl(e.KeyChar)){
                e.Handled = false;
            }else {
                MessageBox.Show("Solo se permiten ingresar números", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e){
            if (char.IsLetter(e.KeyChar)) {
                e.Handled = false;
            } else if (char.IsControl(e.KeyChar)) {
                e.Handled = false;
            } else if (char.IsSeparator(e.KeyChar)) {
                e.Handled = false;
            }else{
                MessageBox.Show("Solo se permiten ingresar Letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e){
            if (txtNombre.Text == "" || txtSalario.Text == ""){
                if (txtNombre.Text == "" && txtSalario.Text != ""){
                    MessageBox.Show("Debe ingresar un nombre","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtNombre.Focus();
                }else if (txtNombre.Text != "" && txtSalario.Text == ""){
                    MessageBox.Show("Debe ingresar un salario","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtSalario.Focus();
                }else{
                    MessageBox.Show("No puede dejar campos vacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }else{
                try{
                    MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
                    string consu = "INSERT INTO trab (mac,nombre,salario) VALUES (@mac,@nombre, @salario)";
                    MySqlCommand cmd = new MySqlCommand(consu, con);
                    #region Datos
                cmd.Parameters.AddWithValue("@mac", "0");
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@salario", txtSalario.Text);
                    #endregion
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    pbQr.Visible = true;
                    gBReg.Visible = false;
                    label6.Visible = true;
                }catch(Exception f){}
            }
            
        }
        private void qr(){
            if (a==1){
                Sqr = "RCañedo";
            }else if (a == 2){
                up();
                Sqr = "UCañedo";
            }
            QRCodeGenerator qrGenerador = new QRCodeGenerator();
            QRCodeData qrdat = qrGenerador.CreateQrCode(Sqr, QRCodeGenerator.ECCLevel.H);
            QRCode codigo = new QRCode(qrdat);

            Bitmap qrI = codigo.GetGraphic(9, Color.Blue, Color.Empty, true);
            pbQr.Image = qrI;
        }
        private string idT(){
            String connString = "datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p";
                using (MySqlConnection con = new MySqlConnection(connString)){
                using (MySqlCommand cmd = new MySqlCommand("SELECT id FROM trab WHERE nombre ='"+cmbUsr.Text+"'")){
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    id = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            return id;
        }
        private void llenC(){
            using (MySqlConnection conn = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p")){
                string query = "SELECT id, nombre from trab";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                cmbUsr.ValueMember = "id";
                cmbUsr.DisplayMember = "nombre";
                cmbUsr.DataSource = dt;
            }
        }
        private void eliminar(){
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection connStr = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            try {
                DialogResult r = MessageBox.Show("¿Realmente desea dar de baja al trabajador "+cmbUsr.Text+" ?","Advertecia",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (r == DialogResult.Yes){
                    connStr.Open();
                    string consul = "DELETE from trab WHERE nombre = '" +cmbUsr.Text+"'";
                    cmd = new MySqlCommand(consul, connStr);
                    cmd.ExecuteNonQuery();
                    connStr.Close();
                    MessageBox.Show("El trabajador se ha dado de baja", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Regresar();
                }else{

                }
            }catch (Exception ex){
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void Regresar(){
            this.Dispose();
            Principal pr = new Principal();
            pr.label1.Text = label1.Text;
            pr.Show();
        }
        private void up(){
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection connStr = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            try{
                connStr.Open();
                string consul = "UPDATE temp SET idt ='" + idT() + "' WHERE id = '0'";
                cmd = new MySqlCommand(consul, connStr);
                cmd.ExecuteNonQuery();
                connStr.Close();
            }catch (Exception ex){
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}