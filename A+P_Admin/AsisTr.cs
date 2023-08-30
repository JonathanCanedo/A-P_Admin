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
    public partial class AsisTr : Form{
        public int xClick = 0, yClick = 0;
        DataSet ds;
        public AsisTr(){
            InitializeComponent();
            this.toolTip1.SetToolTip(this.pictureBox2, "Prsione la imagen para regresar a la pantalla principal");
        }
        private void AsisTr_Load(object sender, EventArgs e){
            lblFecha.Text = DateTime.Now.ToShortDateString();
            consulta();
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
        private void label3_MouseMove(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left){
                xClick = e.X; yClick = e.Y;
            }else{
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }
        }
        private void timer1_Tick(object sender, EventArgs e){
            consulta();
        }
        private void pictureBox2_Click(object sender, EventArgs e){
            this.Dispose();
            Principal pr = new Principal();
            pr.label1.Text = label1.Text;
            pr.Show();
        }
        private void consulta() {
            MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select nombre, entrada from trab inner join registros on trab.mac = registros.mac WHERE fecha ='" + lblFecha.Text + "'", con);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            adap.Fill(ds);
            dGvAsis.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}