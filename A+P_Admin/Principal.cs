using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_P_Admin{
    public partial class Principal : Form{
        public int xClick = 0, yClick = 0;
        public Principal(){
            InitializeComponent();
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
        private void regresarToolStripMenuItem_Click(object sender, EventArgs e){
            DialogResult res = MessageBox.Show("¿ Desea regresar al logueo de la aplicación ?","Advertencia", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (res == DialogResult.Yes){
                this.Hide();
                Form1 lo = new Form1();
                lo.Show();
            }else {
            }
        }
        private void pagoAcomuladoToolStripMenuItem_Click(object sender, EventArgs e){
            this.Hide();
            AsisTr asis = new AsisTr();
            asis.label1.Text = label1.Text;
            asis.Show();
        }
        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e){
            this.Dispose();
            Perfil per = new Perfil();
            per.label1.Text = label1.Text;
            per.a = 2;
            per.Show();
        }
        private void cambiarEmailToolStripMenuItem_Click(object sender, EventArgs e){
            this.Dispose();
            Perfil per = new Perfil();
            per.label1.Text = label1.Text;
            per.a = 3;
            per.Show();
        }
        private void registrarToolStripMenuItem_Click(object sender, EventArgs e){
            this.Dispose();
            Trabajador tra = new Trabajador();
            tra.label1.Text = label1.Text;
            tra.a = 1;
            tra.Show();
        }
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e){
            this.Dispose();
            Trabajador tra = new Trabajador();
            tra.label1.Text = label1.Text;
            tra.a = 2;
            tra.Show();
        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e){
            this.Dispose();
            Trabajador tra = new Trabajador();
            tra.label1.Text = label1.Text;
            tra.a = 3;
            tra.Show();
        }
        private void entradaToolStripMenuItem_Click(object sender, EventArgs e){
            this.Dispose();
            Justificar js = new Justificar();
            js.label1.Text = label1.Text;
            js.a = 1;
            js.Show();
        }
        private void salidaToolStripMenuItem_Click(object sender, EventArgs e){
            this.Dispose();
            Justificar js = new Justificar();
            js.label1.Text = label1.Text;
            js.a = 2;
            js.Show();
        }
        private void justificarToolStripMenuItem_Click(object sender, EventArgs e){
            this.Dispose();
            Justificar js = new Justificar();
            js.label1.Text = label1.Text;
            js.a = 3;
            js.Show();
        }
        private void realizarPagosToolStripMenuItem_Click(object sender, EventArgs e){
            this.Dispose();
            Pagos pg = new Pagos();
            pg.label1.Text = label1.Text;
            pg.Show();
        }
        private void reporteToolStripMenuItem_Click(object sender, EventArgs e){
            this.Dispose();
            Reporte rep = new Reporte();
            rep.label1.Text = label1.Text;
            rep.Show();
        }
        private void Principal_Load(object sender, EventArgs e){
            lblFecha.Text = DateTime.Now.ToShortDateString();
            if (label1.Text == "Admin") {
                reporteToolStripMenuItem.Visible = true;
                modificarAsistenciaToolStripMenuItem.Visible = true;
                trabajadorToolStripMenuItem.Visible = true;
                realizarPagosToolStripMenuItem.Visible = true;
                pagoAcomuladoToolStripMenuItem.Visible = false;
                perfilToolStripMenuItem.Visible = true;
                regresarToolStripMenuItem.Visible = true;
                lblFecha.Location = new Point (498,65);
            }else if (label1.Text == "SU"){
                reporteToolStripMenuItem.Visible = false;
                modificarAsistenciaToolStripMenuItem.Visible = false;
                trabajadorToolStripMenuItem.Visible = false;
                realizarPagosToolStripMenuItem.Visible = false;
                pagoAcomuladoToolStripMenuItem.Visible = true;
                perfilToolStripMenuItem.Visible = true;
                regresarToolStripMenuItem.Visible = true;
                pictureBox1.Visible = false;
                lblFecha.Location = new Point(187, 55);
                pictureBox4.Location = new Point(42,72);
                pictureBox4.Size = new Size(206, 266);
                this.Size = new Size(290, 350);
            }
        }
    }
}