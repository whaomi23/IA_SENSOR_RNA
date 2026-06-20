namespace IA_SENSOR_RNA
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.BtnConfigurar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxPuertos = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.txtTemperatura = new System.Windows.Forms.TextBox();
            this.txtHumedad = new System.Windows.Forms.TextBox();
            this.txtIndicador = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnVerPMLS = new System.Windows.Forms.Button();
            this.comboBoxVerPML = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // BtnConfigurar
            // 
            this.BtnConfigurar.Location = new System.Drawing.Point(34, 106);
            this.BtnConfigurar.Name = "BtnConfigurar";
            this.BtnConfigurar.Size = new System.Drawing.Size(121, 23);
            this.BtnConfigurar.TabIndex = 12;
            this.BtnConfigurar.Text = "Usar Puerto";
            this.BtnConfigurar.UseVisualStyleBackColor = true;
            this.BtnConfigurar.Click += new System.EventHandler(this.BtnConfigurar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Config Puerto COM";
            // 
            // comboBoxPuertos
            // 
            this.comboBoxPuertos.FormattingEnabled = true;
            this.comboBoxPuertos.Location = new System.Drawing.Point(34, 79);
            this.comboBoxPuertos.Name = "comboBoxPuertos";
            this.comboBoxPuertos.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPuertos.TabIndex = 10;
            // 
            // txtTemperatura
            // 
            this.txtTemperatura.Location = new System.Drawing.Point(297, 79);
            this.txtTemperatura.Name = "txtTemperatura";
            this.txtTemperatura.Size = new System.Drawing.Size(100, 20);
            this.txtTemperatura.TabIndex = 17;
            // 
            // txtHumedad
            // 
            this.txtHumedad.Location = new System.Drawing.Point(297, 116);
            this.txtHumedad.Name = "txtHumedad";
            this.txtHumedad.Size = new System.Drawing.Size(100, 20);
            this.txtHumedad.TabIndex = 18;
            // 
            // txtIndicador
            // 
            this.txtIndicador.Location = new System.Drawing.Point(297, 156);
            this.txtIndicador.Name = "txtIndicador";
            this.txtIndicador.Size = new System.Drawing.Size(100, 20);
            this.txtIndicador.TabIndex = 19;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(297, 48);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(422, 20);
            this.txtEstado.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(251, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Estado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(251, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "TMP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "HM";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(257, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "X";
            // 
            // btnVerPMLS
            // 
            this.btnVerPMLS.Location = new System.Drawing.Point(252, 232);
            this.btnVerPMLS.Name = "btnVerPMLS";
            this.btnVerPMLS.Size = new System.Drawing.Size(145, 23);
            this.btnVerPMLS.TabIndex = 0;
            this.btnVerPMLS.Text = "Ver PML Generados";
            this.btnVerPMLS.Click += new System.EventHandler(this.btnVerPMLS_Click);
            // 
            // comboBoxVerPML
            // 
            this.comboBoxVerPML.FormattingEnabled = true;
            this.comboBoxVerPML.Location = new System.Drawing.Point(260, 275);
            this.comboBoxVerPML.Name = "comboBoxVerPML";
            this.comboBoxVerPML.Size = new System.Drawing.Size(500, 21);
            this.comboBoxVerPML.TabIndex = 28;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 462);
            this.Controls.Add(this.comboBoxVerPML);
            this.Controls.Add(this.btnVerPMLS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.txtIndicador);
            this.Controls.Add(this.txtHumedad);
            this.Controls.Add(this.txtTemperatura);
            this.Controls.Add(this.BtnConfigurar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPuertos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnConfigurar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxPuertos;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox txtTemperatura;
        private System.Windows.Forms.TextBox txtHumedad;
        private System.Windows.Forms.TextBox txtIndicador;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnVerPMLS;
        private System.Windows.Forms.ComboBox comboBoxVerPML;
    }
}

