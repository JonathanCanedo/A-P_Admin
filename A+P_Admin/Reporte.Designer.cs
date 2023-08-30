namespace A_P_Admin
{
    partial class Reporte
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Reporte));
            this.dGvRep = new System.Windows.Forms.DataGridView();
            this.lblFecha = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExp = new System.Windows.Forms.Button();
            this.btnImp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Calendario2 = new System.Windows.Forms.DateTimePicker();
            this.Calendario1 = new System.Windows.Forms.DateTimePicker();
            this.cmbTra = new System.Windows.Forms.ComboBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.lblTot = new System.Windows.Forms.Label();
            this.lblD5 = new System.Windows.Forms.Label();
            this.lblD4 = new System.Windows.Forms.Label();
            this.lblD3 = new System.Windows.Forms.Label();
            this.lblD2 = new System.Windows.Forms.Label();
            this.lblD1 = new System.Windows.Forms.Label();
            this.lblSal = new System.Windows.Forms.Label();
            this.lblF5 = new System.Windows.Forms.Label();
            this.lblF4 = new System.Windows.Forms.Label();
            this.lblF3 = new System.Windows.Forms.Label();
            this.lblF2 = new System.Windows.Forms.Label();
            this.lblF1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLimp = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PbRepTrab = new System.Windows.Forms.PictureBox();
            this.PbRepGral = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dGvRep)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbRepTrab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbRepGral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // dGvRep
            // 
            this.dGvRep.AllowUserToAddRows = false;
            this.dGvRep.AllowUserToDeleteRows = false;
            this.dGvRep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGvRep.Location = new System.Drawing.Point(8, 14);
            this.dGvRep.Name = "dGvRep";
            this.dGvRep.ReadOnly = true;
            this.dGvRep.Size = new System.Drawing.Size(518, 282);
            this.dGvRep.TabIndex = 89;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFecha.Location = new System.Drawing.Point(551, 42);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(51, 20);
            this.lblFecha.TabIndex = 88;
            this.lblFecha.Text = "label2";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.RoyalBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(0, -1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(687, 31);
            this.label8.TabIndex = 84;
            this.label8.Text = "  Asistencia de trabajadores";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label8_MouseMove);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(613, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 92;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // btnExp
            // 
            this.btnExp.Location = new System.Drawing.Point(354, 302);
            this.btnExp.Name = "btnExp";
            this.btnExp.Size = new System.Drawing.Size(96, 28);
            this.btnExp.TabIndex = 93;
            this.btnExp.Text = "Exportar a excel";
            this.btnExp.UseVisualStyleBackColor = true;
            this.btnExp.Click += new System.EventHandler(this.btnExp_Click);
            // 
            // btnImp
            // 
            this.btnImp.Location = new System.Drawing.Point(398, 331);
            this.btnImp.Name = "btnImp";
            this.btnImp.Size = new System.Drawing.Size(75, 23);
            this.btnImp.TabIndex = 94;
            this.btnImp.Text = "Imprimir";
            this.btnImp.UseVisualStyleBackColor = true;
            this.btnImp.Click += new System.EventHandler(this.btnImp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Calendario2);
            this.groupBox1.Controls.Add(this.Calendario1);
            this.groupBox1.Controls.Add(this.cmbTra);
            this.groupBox1.Controls.Add(this.btnMostrar);
            this.groupBox1.Controls.Add(this.lblTot);
            this.groupBox1.Controls.Add(this.lblD5);
            this.groupBox1.Controls.Add(this.lblD4);
            this.groupBox1.Controls.Add(this.lblD3);
            this.groupBox1.Controls.Add(this.lblD2);
            this.groupBox1.Controls.Add(this.lblD1);
            this.groupBox1.Controls.Add(this.lblSal);
            this.groupBox1.Controls.Add(this.lblF5);
            this.groupBox1.Controls.Add(this.lblF4);
            this.groupBox1.Controls.Add(this.lblF3);
            this.groupBox1.Controls.Add(this.lblF2);
            this.groupBox1.Controls.Add(this.lblF1);
            this.groupBox1.Controls.Add(this.btnImp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(134, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 360);
            this.groupBox1.TabIndex = 95;
            this.groupBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(384, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 16);
            this.label5.TabIndex = 112;
            this.label5.Text = "Viernes: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 111;
            this.label4.Text = "Lunes: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(241, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 16);
            this.label3.TabIndex = 110;
            this.label3.Text = "Descuento total: $";
            // 
            // Calendario2
            // 
            this.Calendario2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Calendario2.Location = new System.Drawing.Point(387, 35);
            this.Calendario2.Name = "Calendario2";
            this.Calendario2.Size = new System.Drawing.Size(86, 20);
            this.Calendario2.TabIndex = 109;
            // 
            // Calendario1
            // 
            this.Calendario1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Calendario1.Location = new System.Drawing.Point(295, 35);
            this.Calendario1.Name = "Calendario1";
            this.Calendario1.Size = new System.Drawing.Size(86, 20);
            this.Calendario1.TabIndex = 108;
            // 
            // cmbTra
            // 
            this.cmbTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTra.FormattingEnabled = true;
            this.cmbTra.Location = new System.Drawing.Point(85, 35);
            this.cmbTra.Name = "cmbTra";
            this.cmbTra.Size = new System.Drawing.Size(196, 21);
            this.cmbTra.TabIndex = 107;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(398, 331);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 106;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // lblTot
            // 
            this.lblTot.AutoSize = true;
            this.lblTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTot.Location = new System.Drawing.Point(254, 259);
            this.lblTot.Name = "lblTot";
            this.lblTot.Size = new System.Drawing.Size(102, 16);
            this.lblTot.TabIndex = 105;
            this.lblTot.Text = "Total a pagar: $";
            // 
            // lblD5
            // 
            this.lblD5.AutoSize = true;
            this.lblD5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD5.Location = new System.Drawing.Point(167, 203);
            this.lblD5.Name = "lblD5";
            this.lblD5.Size = new System.Drawing.Size(96, 16);
            this.lblD5.TabIndex = 104;
            this.lblD5.Text = "Descuento 5: $";
            // 
            // lblD4
            // 
            this.lblD4.AutoSize = true;
            this.lblD4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD4.Location = new System.Drawing.Point(167, 176);
            this.lblD4.Name = "lblD4";
            this.lblD4.Size = new System.Drawing.Size(99, 16);
            this.lblD4.TabIndex = 103;
            this.lblD4.Text = "Descuento 4:  $";
            // 
            // lblD3
            // 
            this.lblD3.AutoSize = true;
            this.lblD3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD3.Location = new System.Drawing.Point(167, 147);
            this.lblD3.Name = "lblD3";
            this.lblD3.Size = new System.Drawing.Size(96, 16);
            this.lblD3.TabIndex = 102;
            this.lblD3.Text = "Descuento 3: $";
            // 
            // lblD2
            // 
            this.lblD2.AutoSize = true;
            this.lblD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD2.Location = new System.Drawing.Point(167, 118);
            this.lblD2.Name = "lblD2";
            this.lblD2.Size = new System.Drawing.Size(96, 16);
            this.lblD2.TabIndex = 101;
            this.lblD2.Text = "Descuento 2: $";
            // 
            // lblD1
            // 
            this.lblD1.AutoSize = true;
            this.lblD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblD1.Location = new System.Drawing.Point(167, 89);
            this.lblD1.Name = "lblD1";
            this.lblD1.Size = new System.Drawing.Size(96, 16);
            this.lblD1.TabIndex = 100;
            this.lblD1.Text = "Descuento 1: $";
            // 
            // lblSal
            // 
            this.lblSal.AutoSize = true;
            this.lblSal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSal.Location = new System.Drawing.Point(292, 67);
            this.lblSal.Name = "lblSal";
            this.lblSal.Size = new System.Drawing.Size(64, 16);
            this.lblSal.TabIndex = 99;
            this.lblSal.Text = "Salario: $";
            // 
            // lblF5
            // 
            this.lblF5.AutoSize = true;
            this.lblF5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF5.Location = new System.Drawing.Point(10, 203);
            this.lblF5.Name = "lblF5";
            this.lblF5.Size = new System.Drawing.Size(62, 16);
            this.lblF5.TabIndex = 98;
            this.lblF5.Text = "Fecha 5: ";
            // 
            // lblF4
            // 
            this.lblF4.AutoSize = true;
            this.lblF4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF4.Location = new System.Drawing.Point(10, 176);
            this.lblF4.Name = "lblF4";
            this.lblF4.Size = new System.Drawing.Size(62, 16);
            this.lblF4.TabIndex = 97;
            this.lblF4.Text = "Fecha 4: ";
            // 
            // lblF3
            // 
            this.lblF3.AutoSize = true;
            this.lblF3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF3.Location = new System.Drawing.Point(10, 147);
            this.lblF3.Name = "lblF3";
            this.lblF3.Size = new System.Drawing.Size(62, 16);
            this.lblF3.TabIndex = 96;
            this.lblF3.Text = "Fecha 3: ";
            // 
            // lblF2
            // 
            this.lblF2.AutoSize = true;
            this.lblF2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF2.Location = new System.Drawing.Point(10, 118);
            this.lblF2.Name = "lblF2";
            this.lblF2.Size = new System.Drawing.Size(62, 16);
            this.lblF2.TabIndex = 95;
            this.lblF2.Text = "Fecha 2: ";
            // 
            // lblF1
            // 
            this.lblF1.AutoSize = true;
            this.lblF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblF1.Location = new System.Drawing.Point(10, 89);
            this.lblF1.Name = "lblF1";
            this.lblF1.Size = new System.Drawing.Size(62, 16);
            this.lblF1.TabIndex = 2;
            this.lblF1.Text = "Fecha 1: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Trabajador: ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnLimp);
            this.groupBox2.Controls.Add(this.btnExp);
            this.groupBox2.Controls.Add(this.dGvRep);
            this.groupBox2.Location = new System.Drawing.Point(134, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(532, 339);
            this.groupBox2.TabIndex = 96;
            this.groupBox2.TabStop = false;
            // 
            // btnLimp
            // 
            this.btnLimp.Location = new System.Drawing.Point(252, 302);
            this.btnLimp.Name = "btnLimp";
            this.btnLimp.Size = new System.Drawing.Size(96, 28);
            this.btnLimp.TabIndex = 94;
            this.btnLimp.Text = "Vaciar BD";
            this.btnLimp.UseVisualStyleBackColor = true;
            this.btnLimp.Click += new System.EventHandler(this.btnLimp_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PbRepTrab);
            this.groupBox3.Controls.Add(this.PbRepGral);
            this.groupBox3.Location = new System.Drawing.Point(134, 51);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(411, 307);
            this.groupBox3.TabIndex = 97;
            this.groupBox3.TabStop = false;
            // 
            // PbRepTrab
            // 
            this.PbRepTrab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbRepTrab.Image = global::A_P_Admin.Properties.Resources.RI;
            this.PbRepTrab.Location = new System.Drawing.Point(106, 162);
            this.PbRepTrab.Name = "PbRepTrab";
            this.PbRepTrab.Size = new System.Drawing.Size(207, 131);
            this.PbRepTrab.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbRepTrab.TabIndex = 99;
            this.PbRepTrab.TabStop = false;
            this.PbRepTrab.Click += new System.EventHandler(this.PbRepTrab_Click);
            // 
            // PbRepGral
            // 
            this.PbRepGral.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PbRepGral.Image = global::A_P_Admin.Properties.Resources.RG;
            this.PbRepGral.Location = new System.Drawing.Point(106, 19);
            this.PbRepGral.Name = "PbRepGral";
            this.PbRepGral.Size = new System.Drawing.Size(207, 137);
            this.PbRepGral.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PbRepGral.TabIndex = 98;
            this.PbRepGral.TabStop = false;
            this.PbRepGral.Click += new System.EventHandler(this.PbRepGral_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::A_P_Admin.Properties.Resources.FlechaAz;
            this.pictureBox2.Location = new System.Drawing.Point(608, 383);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 45);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 91;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 51);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 90;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox6.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = global::A_P_Admin.Properties.Resources.mi;
            this.pictureBox6.Location = new System.Drawing.Point(632, 4);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(18, 20);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 86;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.BackColor = System.Drawing.Color.RoyalBlue;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = global::A_P_Admin.Properties.Resources.ce;
            this.pictureBox5.Location = new System.Drawing.Point(656, 4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(18, 20);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox5.TabIndex = 85;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 336);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 113;
            this.label6.Text = "Firma trabajador: ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 317);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 13);
            this.label7.TabIndex = 114;
            this.label7.Text = "_______________________________";
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 440);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reporte";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGvRep)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PbRepTrab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbRepGral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGvRep;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExp;
        private System.Windows.Forms.Button btnImp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbTra;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Label lblTot;
        private System.Windows.Forms.Label lblD5;
        private System.Windows.Forms.Label lblD4;
        private System.Windows.Forms.Label lblD3;
        private System.Windows.Forms.Label lblD2;
        private System.Windows.Forms.Label lblD1;
        private System.Windows.Forms.Label lblSal;
        private System.Windows.Forms.Label lblF5;
        private System.Windows.Forms.Label lblF4;
        private System.Windows.Forms.Label lblF3;
        private System.Windows.Forms.Label lblF2;
        private System.Windows.Forms.Label lblF1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox PbRepTrab;
        private System.Windows.Forms.PictureBox PbRepGral;
        private System.Windows.Forms.Button btnLimp;
        private System.Windows.Forms.DateTimePicker Calendario2;
        private System.Windows.Forms.DateTimePicker Calendario1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}