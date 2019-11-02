namespace TP_Complejidad
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.btnDibujar = new System.Windows.Forms.Button();
            this.btnDibujarCamino = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.rbProgramacionDinamica = new System.Windows.Forms.RadioButton();
            this.rbConstraintPrograming = new System.Windows.Forms.RadioButton();
            this.cbDataSet = new System.Windows.Forms.ComboBox();
            this.cbOpciones = new System.Windows.Forms.ComboBox();
            this.cbMapas = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(3, 3);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(999, 622);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.Load += new System.EventHandler(this.gMapControl1_Load);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIniciar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIniciar.FlatAppearance.BorderSize = 0;
            this.btnIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciar.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIniciar.Location = new System.Drawing.Point(3, 3);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(156, 149);
            this.btnIniciar.TabIndex = 1;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // btnDibujar
            // 
            this.btnDibujar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDibujar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDibujar.Enabled = false;
            this.btnDibujar.FlatAppearance.BorderSize = 0;
            this.btnDibujar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDibujar.Font = new System.Drawing.Font("Calibri", 14.75F, System.Drawing.FontStyle.Bold);
            this.btnDibujar.Location = new System.Drawing.Point(3, 158);
            this.btnDibujar.Name = "btnDibujar";
            this.btnDibujar.Size = new System.Drawing.Size(156, 149);
            this.btnDibujar.TabIndex = 2;
            this.btnDibujar.Text = "Realizar busqueda";
            this.btnDibujar.UseVisualStyleBackColor = true;
            this.btnDibujar.Click += new System.EventHandler(this.btnDibujar_Click);
            // 
            // btnDibujarCamino
            // 
            this.btnDibujarCamino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDibujarCamino.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDibujarCamino.Enabled = false;
            this.btnDibujarCamino.FlatAppearance.BorderSize = 0;
            this.btnDibujarCamino.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDibujarCamino.Font = new System.Drawing.Font("Calibri", 14.75F, System.Drawing.FontStyle.Bold);
            this.btnDibujarCamino.Location = new System.Drawing.Point(3, 313);
            this.btnDibujarCamino.Name = "btnDibujarCamino";
            this.btnDibujarCamino.Size = new System.Drawing.Size(156, 149);
            this.btnDibujarCamino.TabIndex = 3;
            this.btnDibujarCamino.Text = "Mostrar graficamente el camino";
            this.btnDibujarCamino.UseVisualStyleBackColor = true;
            this.btnDibujarCamino.Click += new System.EventHandler(this.btnDibujarCamino_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.7513F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.2487F));
            this.tableLayoutPanel1.Controls.Add(this.gMapControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1173, 628);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btnIniciar, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnDibujar, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnDibujarCamino, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(1008, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(162, 622);
            this.tableLayoutPanel2.TabIndex = 1;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 468);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.13245F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(156, 151);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.rbProgramacionDinamica, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.rbConstraintPrograming, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.cbDataSet, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.cbOpciones, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.cbMapas, 0, 4);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(150, 145);
            this.tableLayoutPanel4.TabIndex = 7;
            // 
            // rbProgramacionDinamica
            // 
            this.rbProgramacionDinamica.AutoSize = true;
            this.rbProgramacionDinamica.Location = new System.Drawing.Point(3, 3);
            this.rbProgramacionDinamica.Name = "rbProgramacionDinamica";
            this.rbProgramacionDinamica.Size = new System.Drawing.Size(137, 17);
            this.rbProgramacionDinamica.TabIndex = 0;
            this.rbProgramacionDinamica.TabStop = true;
            this.rbProgramacionDinamica.Text = "Programacion Dinamica";
            this.rbProgramacionDinamica.UseVisualStyleBackColor = true;
            // 
            // rbConstraintPrograming
            // 
            this.rbConstraintPrograming.AutoSize = true;
            this.rbConstraintPrograming.Location = new System.Drawing.Point(3, 33);
            this.rbConstraintPrograming.Name = "rbConstraintPrograming";
            this.rbConstraintPrograming.Size = new System.Drawing.Size(136, 17);
            this.rbConstraintPrograming.TabIndex = 1;
            this.rbConstraintPrograming.TabStop = true;
            this.rbConstraintPrograming.Text = "Constraint Programming";
            this.rbConstraintPrograming.UseVisualStyleBackColor = true;
            // 
            // cbDataSet
            // 
            this.cbDataSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDataSet.FormattingEnabled = true;
            this.cbDataSet.Items.AddRange(new object[] {
            "Centros Poblados",
            "Centros Educativos"});
            this.cbDataSet.Location = new System.Drawing.Point(3, 63);
            this.cbDataSet.Name = "cbDataSet";
            this.cbDataSet.Size = new System.Drawing.Size(144, 21);
            this.cbDataSet.TabIndex = 2;
            this.cbDataSet.SelectedIndexChanged += new System.EventHandler(this.cbDataSet_SelectedIndexChanged);
            // 
            // cbOpciones
            // 
            this.cbOpciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOpciones.FormattingEnabled = true;
            this.cbOpciones.Items.AddRange(new object[] {
            "Capitales Regionales",
            "Capitales Provinciales",
            "Capitales Distritales"});
            this.cbOpciones.Location = new System.Drawing.Point(3, 90);
            this.cbOpciones.Name = "cbOpciones";
            this.cbOpciones.Size = new System.Drawing.Size(144, 21);
            this.cbOpciones.TabIndex = 3;
            // 
            // cbMapas
            // 
            this.cbMapas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMapas.FormattingEnabled = true;
            this.cbMapas.Items.AddRange(new object[] {
            "Google Maps Callejero",
            "Google Maps Terraneo",
            "Google Maps Híbrido",
            "World Street Map",
            "Open Clycle Map"});
            this.cbMapas.Location = new System.Drawing.Point(3, 119);
            this.cbMapas.Name = "cbMapas";
            this.cbMapas.Size = new System.Drawing.Size(144, 21);
            this.cbMapas.TabIndex = 4;
            this.cbMapas.SelectedIndexChanged += new System.EventHandler(this.cbMapas_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 628);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traveling Salesman Problem";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Button btnDibujar;
        private System.Windows.Forms.Button btnDibujarCamino;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.RadioButton rbProgramacionDinamica;
        private System.Windows.Forms.RadioButton rbConstraintPrograming;
        private System.Windows.Forms.ComboBox cbDataSet;
        private System.Windows.Forms.ComboBox cbOpciones;
        private System.Windows.Forms.ComboBox cbMapas;
    }
}

