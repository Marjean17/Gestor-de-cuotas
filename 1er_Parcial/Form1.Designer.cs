namespace _1er_Parcial
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnDesAsignar = new Button();
            dataGBecas = new DataGridView();
            dataGAlum = new DataGridView();
            textBImporteBeca = new TextBox();
            textBCod = new TextBox();
            textBApe = new TextBox();
            textBNom = new TextBox();
            textBDNI = new TextBox();
            labValorBecasEnAlu = new Label();
            label12 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            btnBajaBeca = new Button();
            btnModBeca = new Button();
            btnAltaBeca = new Button();
            btnBajaAlum = new Button();
            btnModAlum = new Button();
            btnAltaAlum = new Button();
            btnAsigAuto = new Button();
            dataGCuotaPaga = new DataGridView();
            dataGBecasEnAlum = new DataGridView();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnGeneraCuotas = new Button();
            btnPagar = new Button();
            dataGCuotaImpaga = new DataGridView();
            label13 = new Label();
            textBLeg = new TextBox();
            label14 = new Label();
            label15 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label9 = new Label();
            textBImpActual = new TextBox();
            label10 = new Label();
            radioBIng = new RadioButton();
            radioBGrado = new RadioButton();
            radioBPost = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dataGBecas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGAlum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGCuotaPaga).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGBecasEnAlum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGCuotaImpaga).BeginInit();
            SuspendLayout();
            // 
            // btnDesAsignar
            // 
            btnDesAsignar.BackColor = Color.LightGray;
            btnDesAsignar.Location = new Point(494, 687);
            btnDesAsignar.Name = "btnDesAsignar";
            btnDesAsignar.Size = new Size(88, 33);
            btnDesAsignar.TabIndex = 67;
            btnDesAsignar.Text = "Quitarla";
            btnDesAsignar.UseVisualStyleBackColor = false;
            btnDesAsignar.Click += btnDesAsignar_Click;
            // 
            // dataGBecas
            // 
            dataGBecas.AllowUserToAddRows = false;
            dataGBecas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGBecas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGBecas.Location = new Point(800, 90);
            dataGBecas.Name = "dataGBecas";
            dataGBecas.ReadOnly = true;
            dataGBecas.RowHeadersWidth = 62;
            dataGBecas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGBecas.Size = new Size(726, 147);
            dataGBecas.TabIndex = 66;
            dataGBecas.SelectionChanged += dataGBecas_SelectionChanged;
            // 
            // dataGAlum
            // 
            dataGAlum.AllowUserToAddRows = false;
            dataGAlum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGAlum.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGAlum.Location = new Point(225, 90);
            dataGAlum.Name = "dataGAlum";
            dataGAlum.ReadOnly = true;
            dataGAlum.RowHeadersWidth = 62;
            dataGAlum.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGAlum.Size = new Size(355, 259);
            dataGAlum.TabIndex = 65;
            dataGAlum.SelectionChanged += dataGAlu_SelectionChanged;
            // 
            // textBImporteBeca
            // 
            textBImporteBeca.Location = new Point(625, 188);
            textBImporteBeca.Name = "textBImporteBeca";
            textBImporteBeca.Size = new Size(158, 31);
            textBImporteBeca.TabIndex = 64;
            // 
            // textBCod
            // 
            textBCod.Location = new Point(625, 118);
            textBCod.Name = "textBCod";
            textBCod.Size = new Size(158, 31);
            textBCod.TabIndex = 60;
            // 
            // textBApe
            // 
            textBApe.Location = new Point(11, 189);
            textBApe.Name = "textBApe";
            textBApe.Size = new Size(150, 31);
            textBApe.TabIndex = 59;
            // 
            // textBNom
            // 
            textBNom.Location = new Point(11, 127);
            textBNom.Name = "textBNom";
            textBNom.Size = new Size(150, 31);
            textBNom.TabIndex = 58;
            // 
            // textBDNI
            // 
            textBDNI.Location = new Point(11, 391);
            textBDNI.Name = "textBDNI";
            textBDNI.Size = new Size(150, 31);
            textBDNI.TabIndex = 57;
            // 
            // labValorBecasEnAlu
            // 
            labValorBecasEnAlu.AutoSize = true;
            labValorBecasEnAlu.Location = new Point(229, 733);
            labValorBecasEnAlu.Name = "labValorBecasEnAlu";
            labValorBecasEnAlu.Size = new Size(337, 25);
            labValorBecasEnAlu.TabIndex = 56;
            labValorBecasEnAlu.Text = "La persona tiene becas por un valor de: $";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(625, 162);
            label12.Name = "label12";
            label12.Size = new Size(151, 25);
            label12.TabIndex = 55;
            label12.Text = "Monto de la beca";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(625, 91);
            label8.Name = "label8";
            label8.Size = new Size(71, 25);
            label8.TabIndex = 51;
            label8.Text = "Codigo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(11, 161);
            label7.Name = "label7";
            label7.Size = new Size(78, 25);
            label7.TabIndex = 50;
            label7.Text = "Apellido";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 99);
            label6.Name = "label6";
            label6.Size = new Size(78, 25);
            label6.TabIndex = 49;
            label6.Text = "Nombre";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 363);
            label5.Name = "label5";
            label5.Size = new Size(43, 25);
            label5.TabIndex = 48;
            label5.Text = "DNI";
            // 
            // btnBajaBeca
            // 
            btnBajaBeca.BackColor = Color.Red;
            btnBajaBeca.ForeColor = SystemColors.ButtonHighlight;
            btnBajaBeca.Location = new Point(618, 513);
            btnBajaBeca.Name = "btnBajaBeca";
            btnBajaBeca.Size = new Size(158, 60);
            btnBajaBeca.TabIndex = 47;
            btnBajaBeca.Text = "Baja de beca seleccionada";
            btnBajaBeca.UseVisualStyleBackColor = false;
            btnBajaBeca.Click += btnBajaBeca_Click;
            // 
            // btnModBeca
            // 
            btnModBeca.BackColor = Color.LightGray;
            btnModBeca.Location = new Point(618, 473);
            btnModBeca.Name = "btnModBeca";
            btnModBeca.Size = new Size(158, 34);
            btnModBeca.TabIndex = 46;
            btnModBeca.Text = "Modificar beca";
            btnModBeca.UseVisualStyleBackColor = false;
            btnModBeca.Click += btnModBeca_Click;
            // 
            // btnAltaBeca
            // 
            btnAltaBeca.BackColor = Color.LightGray;
            btnAltaBeca.Location = new Point(618, 433);
            btnAltaBeca.Name = "btnAltaBeca";
            btnAltaBeca.Size = new Size(158, 34);
            btnAltaBeca.TabIndex = 45;
            btnAltaBeca.Text = "Alta de Beca";
            btnAltaBeca.UseVisualStyleBackColor = false;
            btnAltaBeca.Click += btnAltaBeca_Click;
            // 
            // btnBajaAlum
            // 
            btnBajaAlum.BackColor = Color.Red;
            btnBajaAlum.ForeColor = SystemColors.ButtonHighlight;
            btnBajaAlum.Location = new Point(2, 557);
            btnBajaAlum.Name = "btnBajaAlum";
            btnBajaAlum.Size = new Size(160, 67);
            btnBajaAlum.TabIndex = 44;
            btnBajaAlum.Text = "Baja de Alumno seleccionado";
            btnBajaAlum.UseVisualStyleBackColor = false;
            btnBajaAlum.Click += btnBajaAlu_Click;
            // 
            // btnModAlum
            // 
            btnModAlum.BackColor = Color.LightGray;
            btnModAlum.Location = new Point(-1, 514);
            btnModAlum.Name = "btnModAlum";
            btnModAlum.Size = new Size(163, 37);
            btnModAlum.TabIndex = 43;
            btnModAlum.Text = "Modificar alumno";
            btnModAlum.UseVisualStyleBackColor = false;
            btnModAlum.Click += btnModAlu_Click;
            // 
            // btnAltaAlum
            // 
            btnAltaAlum.BackColor = Color.LightGray;
            btnAltaAlum.Location = new Point(-1, 472);
            btnAltaAlum.Name = "btnAltaAlum";
            btnAltaAlum.Size = new Size(163, 36);
            btnAltaAlum.TabIndex = 42;
            btnAltaAlum.Text = "Alta de alumno";
            btnAltaAlum.UseVisualStyleBackColor = false;
            btnAltaAlum.Click += btnAltaAlu_Click;
            // 
            // btnAsigAuto
            // 
            btnAsigAuto.BackColor = Color.LightGray;
            btnAsigAuto.Location = new Point(227, 687);
            btnAsigAuto.Name = "btnAsigAuto";
            btnAsigAuto.Size = new Size(261, 33);
            btnAsigAuto.TabIndex = 41;
            btnAsigAuto.Text = "Asignarle la beca seleccionada";
            btnAsigAuto.UseVisualStyleBackColor = false;
            btnAsigAuto.Click += btnAsigBeca_Click;
            // 
            // dataGCuotaPaga
            // 
            dataGCuotaPaga.AllowUserToAddRows = false;
            dataGCuotaPaga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGCuotaPaga.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGCuotaPaga.Location = new Point(800, 513);
            dataGCuotaPaga.Name = "dataGCuotaPaga";
            dataGCuotaPaga.ReadOnly = true;
            dataGCuotaPaga.RowHeadersWidth = 62;
            dataGCuotaPaga.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGCuotaPaga.Size = new Size(726, 245);
            dataGCuotaPaga.TabIndex = 40;
            // 
            // dataGBecasEnAlum
            // 
            dataGBecasEnAlum.AllowUserToAddRows = false;
            dataGBecasEnAlum.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGBecasEnAlum.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGBecasEnAlum.Location = new Point(227, 513);
            dataGBecasEnAlum.Name = "dataGBecasEnAlum";
            dataGBecasEnAlum.ReadOnly = true;
            dataGBecasEnAlum.RowHeadersWidth = 62;
            dataGBecasEnAlum.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGBecasEnAlum.Size = new Size(353, 155);
            dataGBecasEnAlum.TabIndex = 39;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(800, 478);
            label4.Name = "label4";
            label4.Size = new Size(201, 25);
            label4.TabIndex = 38;
            label4.Text = "Detalle de cuotas pagas";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(229, 485);
            label3.Name = "label3";
            label3.Size = new Size(270, 25);
            label3.TabIndex = 37;
            label3.Text = "Becas en el alumno seleccionado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(800, 33);
            label2.Name = "label2";
            label2.Size = new Size(122, 25);
            label2.TabIndex = 36;
            label2.Text = "Lista de becas";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(227, 33);
            label1.Name = "label1";
            label1.Size = new Size(145, 25);
            label1.TabIndex = 35;
            label1.Text = "Lista de alumnos";
            // 
            // btnGeneraCuotas
            // 
            btnGeneraCuotas.BackColor = Color.LightGray;
            btnGeneraCuotas.Location = new Point(1368, 768);
            btnGeneraCuotas.Name = "btnGeneraCuotas";
            btnGeneraCuotas.Size = new Size(158, 34);
            btnGeneraCuotas.TabIndex = 68;
            btnGeneraCuotas.Text = "Generar Cuotas";
            btnGeneraCuotas.UseVisualStyleBackColor = false;
            btnGeneraCuotas.Click += btnGeneraCuotas_Click;
            // 
            // btnPagar
            // 
            btnPagar.BackColor = Color.LightGray;
            btnPagar.Location = new Point(1293, 433);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(233, 34);
            btnPagar.TabIndex = 69;
            btnPagar.Text = "Pagar Cuota Seleccionada";
            btnPagar.UseVisualStyleBackColor = false;
            btnPagar.Click += btnPagar_Click;
            // 
            // dataGCuotaImpaga
            // 
            dataGCuotaImpaga.AllowUserToAddRows = false;
            dataGCuotaImpaga.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGCuotaImpaga.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGCuotaImpaga.Location = new Point(800, 290);
            dataGCuotaImpaga.Name = "dataGCuotaImpaga";
            dataGCuotaImpaga.ReadOnly = true;
            dataGCuotaImpaga.RowHeadersWidth = 62;
            dataGCuotaImpaga.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGCuotaImpaga.Size = new Size(726, 132);
            dataGCuotaImpaga.TabIndex = 70;
            dataGCuotaImpaga.SelectionChanged += dataGCuotaImpaga_SelectionChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(800, 262);
            label13.Name = "label13";
            label13.Size = new Size(221, 25);
            label13.TabIndex = 71;
            label13.Text = "Detalle de cuotas impagas";
            // 
            // textBLeg
            // 
            textBLeg.Location = new Point(12, 60);
            textBLeg.Name = "textBLeg";
            textBLeg.Size = new Size(150, 31);
            textBLeg.TabIndex = 73;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(12, 32);
            label14.Name = "label14";
            label14.Size = new Size(64, 25);
            label14.TabIndex = 72;
            label14.Text = "Legajo";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(12, 229);
            label15.Name = "label15";
            label15.Size = new Size(92, 25);
            label15.TabIndex = 74;
            label15.Text = "Condicion";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(1262, 768);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(100, 31);
            dateTimePicker1.TabIndex = 76;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1104, 773);
            label9.Name = "label9";
            label9.Size = new Size(152, 25);
            label9.TabIndex = 77;
            label9.Text = "Periodo a generar";
            // 
            // textBImpActual
            // 
            textBImpActual.Location = new Point(980, 770);
            textBImpActual.Name = "textBImpActual";
            textBImpActual.Size = new Size(118, 31);
            textBImpActual.TabIndex = 78;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(871, 777);
            label10.Name = "label10";
            label10.Size = new Size(103, 25);
            label10.TabIndex = 79;
            label10.Text = "Valor actual";
            // 
            // radioBIng
            // 
            radioBIng.AutoSize = true;
            radioBIng.Checked = true;
            radioBIng.Location = new Point(9, 257);
            radioBIng.Name = "radioBIng";
            radioBIng.Size = new Size(120, 29);
            radioBIng.TabIndex = 80;
            radioBIng.TabStop = true;
            radioBIng.Text = "Ingresante\r\n";
            radioBIng.UseVisualStyleBackColor = true;
            // 
            // radioBGrado
            // 
            radioBGrado.AutoSize = true;
            radioBGrado.Location = new Point(9, 290);
            radioBGrado.Name = "radioBGrado";
            radioBGrado.Size = new Size(86, 29);
            radioBGrado.TabIndex = 81;
            radioBGrado.Text = "Grado";
            radioBGrado.UseVisualStyleBackColor = true;
            // 
            // radioBPost
            // 
            radioBPost.AutoSize = true;
            radioBPost.Location = new Point(9, 320);
            radioBPost.Name = "radioBPost";
            radioBPost.Size = new Size(119, 29);
            radioBPost.TabIndex = 82;
            radioBPost.Text = "Postgrado";
            radioBPost.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1545, 858);
            Controls.Add(radioBPost);
            Controls.Add(radioBGrado);
            Controls.Add(radioBIng);
            Controls.Add(label10);
            Controls.Add(textBImpActual);
            Controls.Add(label9);
            Controls.Add(dateTimePicker1);
            Controls.Add(label15);
            Controls.Add(textBLeg);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(dataGCuotaImpaga);
            Controls.Add(btnPagar);
            Controls.Add(btnGeneraCuotas);
            Controls.Add(btnDesAsignar);
            Controls.Add(dataGBecas);
            Controls.Add(dataGAlum);
            Controls.Add(textBImporteBeca);
            Controls.Add(textBCod);
            Controls.Add(textBApe);
            Controls.Add(textBNom);
            Controls.Add(textBDNI);
            Controls.Add(labValorBecasEnAlu);
            Controls.Add(label12);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(btnBajaBeca);
            Controls.Add(btnModBeca);
            Controls.Add(btnAltaBeca);
            Controls.Add(btnBajaAlum);
            Controls.Add(btnModAlum);
            Controls.Add(btnAltaAlum);
            Controls.Add(btnAsigAuto);
            Controls.Add(dataGCuotaPaga);
            Controls.Add(dataGBecasEnAlum);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGBecas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGAlum).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGCuotaPaga).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGBecasEnAlum).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGCuotaImpaga).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDesAsignar;
        private DataGridView dataGBecas;
        private DataGridView dataGAlum;
        private TextBox textBImporteBeca;
        private TextBox textBCod;
        private TextBox textBApe;
        private TextBox textBNom;
        private TextBox textBDNI;
        private Label labValorBecasEnAlu;
        private Label label12;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button btnBajaBeca;
        private Button btnModBeca;
        private Button btnAltaBeca;
        private Button btnBajaAlum;
        private Button btnModAlum;
        private Button btnAltaAlum;
        private Button btnAsigAuto;
        private DataGridView dataGCuotaPaga;
        private DataGridView dataGBecasEnAlum;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnGeneraCuotas;
        private Button btnPagar;
        private DataGridView dataGCuotaImpaga;
        private Label label13;
        private TextBox textBLeg;
        private Label label14;
        private TextBox textBCond;
        private Label label15;
        private DateTimePicker dateTimePicker1;
        private Label label9;
        private TextBox textBImpActual;
        private Label label10;
        private RadioButton radioBIng;
        private RadioButton radioBGrado;
        private RadioButton radioBPost;
    }
}
