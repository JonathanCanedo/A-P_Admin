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
    public partial class Justificar : Form{
        public int xClick = 0, yClick = 0, a = 0;
        string e = "09:00", s = "18:00", mac="";
        public Justificar(){
            InitializeComponent();
        }
        private void Justificar_Load(object sender, EventArgs e){
            lblFecha.Text = DateTime.Now.ToShortDateString();
            llenC();
            if (a==1){
                //Entrada
                label8.Text = "Modificar entrada de trabajador";
                gBjustificar.Visible = false;
                gBModificar.Visible = true;
            }else if (a==2){
                //Salida
                label8.Text = "Modificar salida de trabajador";
                gBjustificar.Visible = false;
                gBModificar.Visible = true;
            }else if (a==3){
                //Justificar
                label8.Text = "Justificar día del trabajador";
                gBjustificar.Visible = true;
                gBModificar.Visible = false;
            }
        }
        private void label8_MouseMove(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left){
                xClick = e.X; yClick = e.Y;
            }else{
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e){
            this.Dispose();
            Principal pr = new Principal();
            pr.label1.Text = label1.Text;
            pr.Show();
        }
        private void pictureBox6_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void button1_Click(object sender, EventArgs e){
            just();
        }
        private void pictureBox5_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Realmente desea cerrar la aplicación ?","Advertencia",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res==DialogResult.Yes){
                Application.Exit();
            }else {
            }
        }
        private void button2_Click(object sender, EventArgs e){
            if (a==1){
                Ent();
            }else if (a==2){
                Sal();
            }else {}
        }
        private void llenC(){
            using (MySqlConnection conn = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p")){
                string query = "SELECT id, nombre from trab";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                cmbUsr2.ValueMember = "id";
                cmbUsr2.DisplayMember = "nombre";
                cmbUsr2.DataSource = dt;

                cmbUsr1.ValueMember = "id";
                cmbUsr1.DisplayMember = "nombre";
                cmbUsr1.DataSource = dt;
            }
        }
        private void Ent(){
            try {
                MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
                if (exist(Obmac(),Calendario2.Text)){
                    string consu = "UPDATE registros SET entrada = '09:00' WHERE mac = '" + Obmac() + "' AND fecha = '" + Calendario2.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(consu, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Entrada del día: "+Calendario2.Text+" justificada", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Regresar();
                } else {
                    Regresar();
                }
            } catch{}
        }
        private void Sal(){
            try {
                MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
                if (exist(Obmac(),Calendario2.Text)){
                    string consu = "UPDATE registros SET salida = '18:00' WHERE mac = '" + Obmac() + "' AND fecha = '" + Calendario2.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(consu, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Salida del día: "+Calendario2.Text+" justificada", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Regresar();
                } else {
                    Regresar();
                }
            } catch{}
        }
        private void just(){
            try{
                MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
                if (existe(Omac(),Calendario1.Text)){
                    string consu = "UPDATE registros SET entrada = '09:00', salida = '18:00' WHERE mac = '" + Omac() + "' AND fecha = '" + Calendario1.Text + "'";
                    MySqlCommand cmd = new MySqlCommand(consu, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Falta del día: "+Calendario1.Text+" justificada", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Regresar();
                }else {
                    MessageBox.Show("El trabajador: " + cmbUsr1.Text + " no tiene faltas \nen la fecha: "+Calendario1.Text+"", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Regresar();
                }
            }catch{}
        }
        private bool existe(string mac, string fecha){
            MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            string query = "SELECT COUNT(*) FROM registros WHERE mac=@mac AND fecha=@fecha AND entrada = '0' AND salida = '0'";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("mac", mac);
            cmd.Parameters.AddWithValue("fecha", fecha);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0){
                return false;
            }else{
                return true;
            }
        }
        private bool exist(string mac, string fecha){
            MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            string query = "SELECT COUNT(*) FROM registros WHERE mac=@mac AND fecha=@fecha";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("mac", mac);
            cmd.Parameters.AddWithValue("fecha", fecha);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0){
                return false;
            }else{
                return true;
            }
        }
        private string Omac(){
            String connString = "datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p";
            using (MySqlConnection con = new MySqlConnection(connString)){
                using (MySqlCommand cmd = new MySqlCommand("select mac from trab WHERE nombre ='" + cmbUsr1.Text+"'")){
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    mac = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            return mac;
        }
        private string Obmac(){
            String connString = "datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p";
            using (MySqlConnection con = new MySqlConnection(connString)){
                using (MySqlCommand cmd = new MySqlCommand("select mac from trab WHERE nombre ='" + cmbUsr2.Text+"'")){
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    mac = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            return mac;
        }
        private void Regresar(){
            this.Dispose();
            Principal pr = new Principal();
            pr.label1.Text = label1.Text;
            pr.Show();
        }
    }
}
