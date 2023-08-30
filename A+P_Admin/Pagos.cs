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
    public partial class Pagos : Form{
        public int xClick = 0, yClick = 0,sa=0;
        public double desc = 0,des=0;
        public string mac="";
        //pendientes
        public int[] entrada = new int[5], salida = new int[5], tiempo = new int[5];
        List<string> ent = new List<string>();
        List<string> sali = new List<string>();
        public double[] descuento = new double[5];
        public string[] fechas = new string[5];

        public Pagos(){
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e){
            Regresar();
        }
        private void button1_Click(object sender, EventArgs e){
            cmbTra.Enabled = false;
            descu();
        }
        private void Pagos_Load(object sender, EventArgs e){
            lblFecha.Text = DateTime.Now.ToShortDateString();
            llenC();
        }
        private void label3_MouseMove(object sender, MouseEventArgs e){
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
            DialogResult res = MessageBox.Show("¿ Realmente desea cerrar la aplicación ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                Application.Exit();
            }else { }
        }

        private void Regresar(){
            this.Dispose();
            Principal pr = new Principal();
            pr.label1.Text = label1.Text;
            pr.Show();
        }
        private void descu(){
            MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            fechas[0] = F1.Text;
            fechas[1] = F2.Text;
            fechas[2] = F3.Text;
            fechas[3] = F4.Text;
            fechas[4] = F5.Text;

            sa = salario(Obmac());
            desc = (Convert.ToDouble(sa) / 2350);

            des = Math.Truncate((Convert.ToDouble(sa) / 2400) * 10000) / 10000;

            for (int j = 0; j < 5; j++) {
                //Entradas
                con.Open();
                string Query1 = ("select entrada from registros where mac = '" + Obmac() + "' and fecha = '" + fechas[j] +"'");
                MySqlCommand cmd1 = new MySqlCommand(Query1, con);
                MySqlDataReader rd = cmd1.ExecuteReader();
                while (rd.Read()){
                    ent.Add(Convert.ToString(rd["entrada"]));
                }
                con.Close();

                con.Open();
                string Query = ("select salida from registros where mac = '" + Obmac() + "' and fecha = '" + fechas[j] +"'");
                MySqlCommand cmd = new MySqlCommand(Query, con);
                MySqlDataReader rd1 = cmd.ExecuteReader();
                while (rd1.Read()){
                    sali.Add(Convert.ToString(rd1["salida"]));
                }
                con.Close();
                #region entrada
                int t = 0;
                if (ent[j].ToString().Equals("00:00")){
                    t = -1;
                } else{
                    string h = ent[j].Substring(0, 2);
                    string m = ent[j].Substring(2, 3);
                    m = m.Remove(0, 1);
                    t = ((Convert.ToInt32(h) * 60) + (Convert.ToInt32(m)));
                }
                if (t==-1){
                    entrada[j] = -1;
                } else if (t>0 && t<=550){
                    entrada[j] = 0;
                } else{
                    entrada[j] = t - 550;
                }
                #endregion
                #region salida
                int t1 =0;
                if (sali[j].ToString().Equals("00:00")){
                    t1 = -1;
                } else{
                    string h1 = sali[j].Substring(0, 2);
                    string m1 = sali[j].Substring(2, 3);
                    m1 = m1.Remove(0, 1);
                    t1 = ((Convert.ToInt32(h1) * 60) + (Convert.ToInt32(m1)));
                }
                if (t1==-1){
                    salida[j] = -1;
                } else if (t1>=1080){
                    salida[j] = 0;
                } else{
                    salida[j] = 1080-t1;
                }
                #endregion

                int hf = entrada[j] + salida[j];
                if (hf==-2){
                    descuento[j] = (480*des);
                    descuento[j] = (Math.Truncate(descuento[j] * 100) / 100);
                } else{
                    descuento[j] = (hf * des);
                    descuento[j] = (Math.Truncate(descuento[j] * 100) / 100);
                }
            }
             try {
                string consu = "INSERT INTO reportes (mac,fecha1,fecha2,fecha3,fecha4,fecha5,descuento1,descuento2,descuento3,descuento4,descuento5,descuentoTotal) VALUES (@mac,@fecha1,@fecha2,@fecha3,@fecha4,@fecha5,@descuento1,@descuento2,@descuento3,@descuento4,@descuento5,@descuentoTotal)";
                MySqlCommand cmd2 = new MySqlCommand(consu, con);
                #region Datos
                cmd2.Parameters.AddWithValue("@mac", Obmac());
                cmd2.Parameters.AddWithValue("@fecha1", fechas[0]);
                cmd2.Parameters.AddWithValue("@fecha2", fechas[1]);
                cmd2.Parameters.AddWithValue("@fecha3", fechas[2]);
                cmd2.Parameters.AddWithValue("@fecha4", fechas[3]);
                cmd2.Parameters.AddWithValue("@fecha5", fechas[4]);
                cmd2.Parameters.AddWithValue("@descuento1", (Convert.ToString(descuento[0])));
                cmd2.Parameters.AddWithValue("@descuento2", (Convert.ToString(descuento[1])));
                cmd2.Parameters.AddWithValue("@descuento3", (Convert.ToString(descuento[2])));
                cmd2.Parameters.AddWithValue("@descuento4", (Convert.ToString(descuento[3])));
                cmd2.Parameters.AddWithValue("@descuento5", (Convert.ToString(descuento[4])));
                cmd2.Parameters.AddWithValue("@descuentoTotal", (Convert.ToString(descuento.Sum())));
                #endregion
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Se guardó con éxito el pago del usuario: "+cmbTra.Text+"","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }catch(Exception f){}
            Regresar();
        }
        private int Contar(){
            int s = 0;
            try{
                MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
                con.Open();
                string Query = ("select count(mac) from trab");
                MySqlCommand cmd = new MySqlCommand(Query, con);
                s = Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
            }catch { }
            return s;
        }
        private int salario(string mac){
            MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            string query = "SELECT salario FROM trab WHERE mac=@mac";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("mac", mac);
            con.Open();
            int sal = Convert.ToInt32(cmd.ExecuteScalar());
            return sal;
        }
        private void llenC(){
            using (MySqlConnection conn = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p")){
                string query = "SELECT id, nombre from trab";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                da1.Fill(dt);

                cmbTra.ValueMember = "id";
                cmbTra.DisplayMember = "nombre";
                cmbTra.DataSource = dt;
            }
        }
        private string Obmac(){
            String connString = "datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p";
            using (MySqlConnection con = new MySqlConnection(connString)){
                using (MySqlCommand cmd = new MySqlCommand("select mac from trab WHERE nombre ='" + cmbTra.Text+"'")){
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    mac = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            return mac;
        }
    }
}