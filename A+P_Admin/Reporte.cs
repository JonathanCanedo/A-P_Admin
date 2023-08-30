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
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;

namespace A_P_Admin{
    public partial class Reporte : Form{
        public int xClick = 0, yClick = 0, salari = 0;
        string mac = "";
        double descT = 0;
        string[] fields = new string[5];
        string[] fields1 = new string[5];
        DataSet ds;
        public Reporte(){
            InitializeComponent();
            this.toolTip1.SetToolTip(this.PbRepGral, "Prsione la imagen para acceder a los reportes generales de pagos");
            this.toolTip1.SetToolTip(this.PbRepTrab, "Prsione la imagen para acceder a los reportes individuales de pagos");
        }
        private void pictureBox2_Click(object sender, EventArgs e){
            Regresar();
        }
        private void label8_MouseMove(object sender, MouseEventArgs e){
            if (e.Button != MouseButtons.Left){
                xClick = e.X; yClick = e.Y;
            }else{
                this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick);
            }
        }
        private void pictureBox5_Click(object sender, EventArgs e){
             DialogResult res = MessageBox.Show("¿ Realmente desea cerrar la aplicación ?","Advertencia",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res==DialogResult.Yes){
                System.Windows.Forms.Application.Exit();
            }else {
            }
        }
        private void pictureBox6_Click(object sender, EventArgs e){
            this.WindowState = FormWindowState.Minimized;
        }
        private void Reporte_Load(object sender, EventArgs e){
            //Carga de formulario
            lblFecha.Text = DateTime.Now.ToShortDateString();
            llenC();
            groupBox3.Visible = true;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            cmbTra.SelectedIndex = 0;
            consulta();
        }
        private void PbRepGral_Click(object sender, EventArgs e){
            groupBox2.Visible = true;
            groupBox1.Visible = false;
            groupBox3.Visible = false;
        }
        private void PbRepTrab_Click(object sender, EventArgs e){
            groupBox2.Visible = false;
            groupBox1.Visible = true;
            groupBox3.Visible = false;
            lblFecha.Visible = false;
        }
        private void btnExp_Click(object sender, EventArgs e){
            exportarExcel(dGvRep);
        }
        private void btnLimp_Click(object sender, EventArgs e){
            DialogResult r = MessageBox.Show("¿Esta seguro de vaciar la BD ?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(r == DialogResult.Yes){
                exportarExcel(dGvRep);
                try{
                    MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
                    string consu = "TRUNCATE TABLE reportes";
                    MySqlCommand cmd = new MySqlCommand(consu, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Se vacio exitosamente la BD de los pagos de los trabajadores", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }catch (Exception ae){}
            }else{}
            Regresar();
        }
        private void btnImp_Click(object sender, EventArgs e){
            imp();
            Regresar();
        }
        private void consulta(){
            MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            con.Open();
            MySqlCommand cmd = new MySqlCommand("select nombre, fecha1, descuento1, fecha2, descuento2, fecha3, descuento3, fecha4, descuento4, fecha5, descuento5, descuentoTotal from trab inner join reportes on trab.mac = reportes.mac", con);
            MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            adap.Fill(ds);
            dGvRep.DataSource = ds.Tables[0];
            con.Close();
        }
        private void exportarExcel(DataGridView tabla){
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);
            int IndiceColumna = 0;
            foreach (DataGridViewColumn col in tabla.Columns) { // Columnas{
                IndiceColumna++;
                excel.Cells[1, IndiceColumna] = col.DataPropertyName;
            }
            int IndeceFila = 0;
            foreach (DataGridViewRow row in tabla.Rows) {// Filas
                IndeceFila++;
                IndiceColumna = 0;
                foreach (DataGridViewColumn col in tabla.Columns){
                    IndiceColumna++;
                    excel.Cells[IndeceFila + 1, IndiceColumna] = row.Cells[col.Name].Value;
                }
            }
            excel.Visible = true;
        }
        private void imp(){
            this.BackColor = Color.White;
            foreach (Control c in this.Controls){
                if (c is Panel) { c.BackColor = Color.White; }
                if (c is System.Windows.Forms.Button) { c.Visible = false; }
            }
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            System.Drawing.Printing.PrintDocument printDocument1 = new System.Drawing.Printing.PrintDocument();
            Graphics g = this.CreateGraphics();
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, this.Width, this.Height));
            Image Img = (Image)bmp;

            this.BackColor = Color.White;
            foreach (Control c in this.Controls){
                if (c is Panel) { c.BackColor = Panel.DefaultBackColor; }
                if (c is System.Windows.Forms.Button) { c.Visible = true; }
            }
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            printDocument1.DefaultPageSettings.Landscape = false;
            printDocument1.PrintPage += (a, b) => { b.Graphics.DrawImage(Img, 50, 50); };
            printDocument1.Print();
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
        private bool exist(string mac, string fecha1, string fecha5){
            MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            string query = "SELECT COUNT(*) FROM reportes WHERE mac=@mac AND fecha1=@fecha1 AND fecha5=@fecha5";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("mac", mac);
            cmd.Parameters.AddWithValue("fecha1", fecha1);
            cmd.Parameters.AddWithValue("fecha5", fecha5);
            con.Open();
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            if (count == 0){
                return false;
            }else{
                return true;
            }
        }
        private void btnMostrar_Click(object sender, EventArgs e){
            if (Calendario1.Text==Calendario2.Text){
                MessageBox.Show("Las fechas del reporte de pago no pueden ser las mismas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else{
                MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
                if (exist(Omac(),Calendario1.Text, Calendario2.Text)){
                    //Metodo completo
                    hacer();
                    btnMostrar.Visible = false;
                    btnImp.Visible = true;
                    cmbTra.Enabled = false;
                    Calendario1.Enabled = false;
                    Calendario2.Enabled = false;
                    label6.Text = label6.Text + " " + cmbTra.Text;
                }else{
                    MessageBox.Show("El trabajador "+cmbTra.Text+" no tiene pagos en las fechas seleccionadas.", "Advertencia", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    Regresar();
                }
            }            
        }
        private void hacer(){
            MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            
            con.Open();
            string Query1 = ("select fecha1, fecha2, fecha3, fecha4, fecha5 from reportes where mac = '" + Omac() + "' and fecha1 = '" +Calendario1.Text+ "' and fecha5 = '" + Calendario2.Text + "'");
            MySqlCommand cmd1 = new MySqlCommand(Query1, con);
            MySqlDataReader rd = cmd1.ExecuteReader();
            while (rd.Read()){
                fields[0] = rd["fecha1"].ToString();
                fields[1] = rd["fecha2"].ToString();
                fields[2] = rd["fecha3"].ToString();
                fields[3] = rd["fecha4"].ToString();
                fields[4] = rd["fecha5"].ToString();
            }
            con.Close();

            con.Open();
            string Query = ("select descuento1, descuento2, descuento3, descuento4, descuento5 from reportes where mac = '" + Omac() + "' and fecha1 = '" + Calendario1.Text + "' and fecha5 = '" + Calendario2.Text + "'");
            MySqlCommand cmd = new MySqlCommand(Query, con);
            MySqlDataReader red = cmd.ExecuteReader();
            while (red.Read()){
                fields1[0] = red["descuento1"].ToString();
                fields1[1] = red["descuento2"].ToString();
                fields1[2] = red["descuento3"].ToString();
                fields1[3] = red["descuento4"].ToString();
                fields1[4] = red["descuento5"].ToString();
            }
            con.Close();

            salari = salario(Omac());
            lblSal.Text = lblSal.Text + "" + salari.ToString();
            descT = DescuentoT(Omac(), Calendario1.Text, Calendario2.Text);
            label3.Text = label3.Text + "" + descT.ToString();
            lblTot.Text = lblTot.Text + "" + Convert.ToString(salari - descT);
            lblF1.Text = fields[0];
            lblF2.Text = fields[1];
            lblF3.Text = fields[2];
            lblF4.Text = fields[3];
            lblF5.Text = fields[4];
            lblD1.Text = "Descuento de: $" + fields1[0];
            lblD2.Text = "Descuento de: $" + fields1[1];
            lblD3.Text = "Descuento de: $" + fields1[2];
            lblD4.Text = "Descuento de: $" + fields1[3];
            lblD5.Text = "Descuento de: $" + fields1[4];
        }
        private string Omac(){
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
        private void Regresar(){
            this.Dispose();
            Principal pr = new Principal();
            pr.label1.Text = label1.Text;
            pr.Show();
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
        private double DescuentoT(string mac, string fecha1, string fecha5){
            MySqlConnection con = new MySqlConnection("datasource=192.168.1.72;port=3306;username=AP;password=ap1234;database=a+p");
            string query = "SELECT descuentoTotal FROM reportes WHERE mac=@mac AND fecha1=@fecha1 AND fecha5=@fecha5";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("mac", mac);
            cmd.Parameters.AddWithValue("fecha1", fecha1);
            cmd.Parameters.AddWithValue("fecha5", fecha5);
            con.Open();
            double dT = Convert.ToDouble(cmd.ExecuteScalar());
            return dT;
        }
    }
}
