namespace IA_SENSOR_RNA
{
    partial class Vista2Control
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPMLSActuales = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EntrenarPMLaPPM = new System.Windows.Forms.Button();
            this.btnReconocer = new System.Windows.Forms.Button();
            this.comboBoxCargarPPMS = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.labelTrackBar1 = new System.Windows.Forms.TextBox();
            this.labelTrackBar2 = new System.Windows.Forms.TextBox();
            this.labelTrackBar3 = new System.Windows.Forms.TextBox();
            this.btnReconocerPA = new System.Windows.Forms.Button();
            this.chartActivacion = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartActivacion)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(195, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vista de reconocimiento";
            // 
            // comboBoxPMLSActuales
            // 
            this.comboBoxPMLSActuales.FormattingEnabled = true;
            this.comboBoxPMLSActuales.Location = new System.Drawing.Point(30, 123);
            this.comboBoxPMLSActuales.Name = "comboBoxPMLSActuales";
            this.comboBoxPMLSActuales.Size = new System.Drawing.Size(414, 21);
            this.comboBoxPMLSActuales.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(206, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Carga un pml definido y entrenalo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(27, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Carga el PPM y reconcelo";
            // 
            // EntrenarPMLaPPM
            // 
            this.EntrenarPMLaPPM.Location = new System.Drawing.Point(450, 121);
            this.EntrenarPMLaPPM.Name = "EntrenarPMLaPPM";
            this.EntrenarPMLaPPM.Size = new System.Drawing.Size(75, 23);
            this.EntrenarPMLaPPM.TabIndex = 7;
            this.EntrenarPMLaPPM.Text = "Entrenar";
            this.EntrenarPMLaPPM.UseVisualStyleBackColor = true;
            this.EntrenarPMLaPPM.Click += new System.EventHandler(this.EntrenarPMLaPPM_Click);
            // 
            // btnReconocer
            // 
            this.btnReconocer.Location = new System.Drawing.Point(0, 0);
            this.btnReconocer.Name = "btnReconocer";
            this.btnReconocer.Size = new System.Drawing.Size(75, 23);
            this.btnReconocer.TabIndex = 12;
            // 
            // comboBoxCargarPPMS
            // 
            this.comboBoxCargarPPMS.FormattingEnabled = true;
            this.comboBoxCargarPPMS.Location = new System.Drawing.Point(30, 209);
            this.comboBoxCargarPPMS.Name = "comboBoxCargarPPMS";
            this.comboBoxCargarPPMS.Size = new System.Drawing.Size(414, 21);
            this.comboBoxCargarPPMS.TabIndex = 9;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(30, 285);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(414, 45);
            this.trackBar1.TabIndex = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(30, 336);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(414, 45);
            this.trackBar2.TabIndex = 11;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(30, 400);
            this.trackBar3.Maximum = 100;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(414, 45);
            this.trackBar3.TabIndex = 13;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // labelTrackBar1
            // 
            this.labelTrackBar1.Location = new System.Drawing.Point(492, 285);
            this.labelTrackBar1.Name = "labelTrackBar1";
            this.labelTrackBar1.Size = new System.Drawing.Size(100, 20);
            this.labelTrackBar1.TabIndex = 14;
            // 
            // labelTrackBar2
            // 
            this.labelTrackBar2.Location = new System.Drawing.Point(492, 336);
            this.labelTrackBar2.Name = "labelTrackBar2";
            this.labelTrackBar2.Size = new System.Drawing.Size(100, 20);
            this.labelTrackBar2.TabIndex = 15;
            // 
            // labelTrackBar3
            // 
            this.labelTrackBar3.Location = new System.Drawing.Point(492, 400);
            this.labelTrackBar3.Name = "labelTrackBar3";
            this.labelTrackBar3.Size = new System.Drawing.Size(100, 20);
            this.labelTrackBar3.TabIndex = 16;
            // 
            // btnReconocerPA
            // 
            this.btnReconocerPA.Location = new System.Drawing.Point(508, 245);
            this.btnReconocerPA.Name = "btnReconocerPA";
            this.btnReconocerPA.Size = new System.Drawing.Size(75, 23);
            this.btnReconocerPA.TabIndex = 18;
            this.btnReconocerPA.Text = "Reconocer";
            this.btnReconocerPA.UseVisualStyleBackColor = true;
            this.btnReconocerPA.Click += new System.EventHandler(this.btnReconocerPA_Click);
            // 
            // chartActivacion
            // 
            chartArea1.Name = "ChartArea1";
            this.chartActivacion.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartActivacion.Legends.Add(legend1);
            this.chartActivacion.Location = new System.Drawing.Point(680, 92);
            this.chartActivacion.Name = "chartActivacion";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartActivacion.Series.Add(series1);
            this.chartActivacion.Size = new System.Drawing.Size(353, 300);
            this.chartActivacion.TabIndex = 19;
            this.chartActivacion.Text = "chart1";
            // 
            // Vista2Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartActivacion);
            this.Controls.Add(this.btnReconocerPA);
            this.Controls.Add(this.labelTrackBar3);
            this.Controls.Add(this.labelTrackBar2);
            this.Controls.Add(this.labelTrackBar1);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.comboBoxCargarPPMS);
            this.Controls.Add(this.btnReconocer);
            this.Controls.Add(this.EntrenarPMLaPPM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPMLSActuales);
            this.Controls.Add(this.label1);
            this.Name = "Vista2Control";
            this.Size = new System.Drawing.Size(1200, 458);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartActivacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPMLSActuales;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button EntrenarPMLaPPM;
        private System.Windows.Forms.Button btnReconocer;
        private System.Windows.Forms.ComboBox comboBoxCargarPPMS;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TextBox labelTrackBar1;
        private System.Windows.Forms.TextBox labelTrackBar2;
        private System.Windows.Forms.TextBox labelTrackBar3;
        private System.Windows.Forms.Button btnReconocerPA;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartActivacion;
    }
}
