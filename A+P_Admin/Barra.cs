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
    public partial class Barra : Form{
        public Barra(){
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e){
            Barr();
        }
        private void Barra_Load(object sender, EventArgs e){
            lbl3.BackColor = Color.Transparent;
            timer1.Start();
        }
        public void Barr(){
            progressBar1.Increment(1);
            lbl3.Text = progressBar1.Value.ToString() + " %";
            if (progressBar1.Value == progressBar1.Maximum){
                timer1.Stop();
                this.Hide();
                Form1 log = new Form1();
                log.Show();
            }
        }
    }
}