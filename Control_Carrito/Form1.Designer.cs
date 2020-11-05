namespace Control_Carrito
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.TxWindows = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buTeclas = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buIniciar = new System.Windows.Forms.Button();
            this.buTerminar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pb_Imagen_Procesada = new System.Windows.Forms.PictureBox();
            this.lbl_Radio1 = new System.Windows.Forms.Label();
            this.lbl_C1Y = new System.Windows.Forms.Label();
            this.lbl_C1X = new System.Windows.Forms.Label();
            this.lbl_C2X = new System.Windows.Forms.Label();
            this.lbl_C2Y = new System.Windows.Forms.Label();
            this.lbl_Radio2 = new System.Windows.Forms.Label();
            this.lbl_DistanciaCirculo1 = new System.Windows.Forms.Label();
            this.lbl_DistanciaCirculo2 = new System.Windows.Forms.Label();
            this.btn_ControlManual = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.btn_ReiniciarTiempoGiro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Imagen_Procesada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(829, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "W";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnLeft
            // 
            this.btnLeft.Location = new System.Drawing.Point(719, 195);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(75, 23);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.Text = "A";
            this.btnLeft.UseVisualStyleBackColor = true;
            // 
            // btnRight
            // 
            this.btnRight.Location = new System.Drawing.Point(958, 195);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(75, 23);
            this.btnRight.TabIndex = 2;
            this.btnRight.Text = "D";
            this.btnRight.UseVisualStyleBackColor = true;
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(829, 240);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(75, 23);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "S";
            this.btnDown.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(831, 355);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(776, 53);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(903, 53);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 6;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // TxWindows
            // 
            this.TxWindows.Location = new System.Drawing.Point(817, 313);
            this.TxWindows.Name = "TxWindows";
            this.TxWindows.Size = new System.Drawing.Size(100, 20);
            this.TxWindows.TabIndex = 7;
            this.TxWindows.TextChanged += new System.EventHandler(this.TxWindows_TextChanged);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM5";
            // 
            // buTeclas
            // 
            this.buTeclas.Location = new System.Drawing.Point(829, 195);
            this.buTeclas.Name = "buTeclas";
            this.buTeclas.Size = new System.Drawing.Size(75, 23);
            this.buTeclas.TabIndex = 10;
            this.buTeclas.Text = "INICIAR";
            this.buTeclas.UseVisualStyleBackColor = true;
            this.buTeclas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.buTeclas_KeyPress);
            this.buTeclas.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buTeclas_KeyUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(28, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(571, 319);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // buIniciar
            // 
            this.buIniciar.Location = new System.Drawing.Point(634, 113);
            this.buIniciar.Name = "buIniciar";
            this.buIniciar.Size = new System.Drawing.Size(75, 23);
            this.buIniciar.TabIndex = 12;
            this.buIniciar.Text = "INICIAR";
            this.buIniciar.UseVisualStyleBackColor = true;
            this.buIniciar.Click += new System.EventHandler(this.buIniciar_Click);
            // 
            // buTerminar
            // 
            this.buTerminar.Location = new System.Drawing.Point(634, 154);
            this.buTerminar.Name = "buTerminar";
            this.buTerminar.Size = new System.Drawing.Size(75, 23);
            this.buTerminar.TabIndex = 12;
            this.buTerminar.Text = "FINALIZAR";
            this.buTerminar.UseVisualStyleBackColor = true;
            this.buTerminar.Click += new System.EventHandler(this.buTerminar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pb_Imagen_Procesada
            // 
            this.pb_Imagen_Procesada.Location = new System.Drawing.Point(28, 337);
            this.pb_Imagen_Procesada.Name = "pb_Imagen_Procesada";
            this.pb_Imagen_Procesada.Size = new System.Drawing.Size(571, 308);
            this.pb_Imagen_Procesada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Imagen_Procesada.TabIndex = 13;
            this.pb_Imagen_Procesada.TabStop = false;
            // 
            // lbl_Radio1
            // 
            this.lbl_Radio1.AutoSize = true;
            this.lbl_Radio1.Location = new System.Drawing.Point(917, 459);
            this.lbl_Radio1.Name = "lbl_Radio1";
            this.lbl_Radio1.Size = new System.Drawing.Size(55, 13);
            this.lbl_Radio1.TabIndex = 14;
            this.lbl_Radio1.Text = "distancia1";
            // 
            // lbl_C1Y
            // 
            this.lbl_C1Y.AutoSize = true;
            this.lbl_C1Y.Location = new System.Drawing.Point(828, 459);
            this.lbl_C1Y.Name = "lbl_C1Y";
            this.lbl_C1Y.Size = new System.Drawing.Size(58, 13);
            this.lbl_C1Y.TabIndex = 14;
            this.lbl_C1Y.Text = "distancia 2";
            // 
            // lbl_C1X
            // 
            this.lbl_C1X.AutoSize = true;
            this.lbl_C1X.Location = new System.Drawing.Point(732, 459);
            this.lbl_C1X.Name = "lbl_C1X";
            this.lbl_C1X.Size = new System.Drawing.Size(55, 13);
            this.lbl_C1X.TabIndex = 15;
            this.lbl_C1X.Text = "distancia1";
            // 
            // lbl_C2X
            // 
            this.lbl_C2X.AutoSize = true;
            this.lbl_C2X.Location = new System.Drawing.Point(732, 497);
            this.lbl_C2X.Name = "lbl_C2X";
            this.lbl_C2X.Size = new System.Drawing.Size(55, 13);
            this.lbl_C2X.TabIndex = 18;
            this.lbl_C2X.Text = "distancia1";
            // 
            // lbl_C2Y
            // 
            this.lbl_C2Y.AutoSize = true;
            this.lbl_C2Y.Location = new System.Drawing.Point(828, 497);
            this.lbl_C2Y.Name = "lbl_C2Y";
            this.lbl_C2Y.Size = new System.Drawing.Size(58, 13);
            this.lbl_C2Y.TabIndex = 16;
            this.lbl_C2Y.Text = "distancia 2";
            // 
            // lbl_Radio2
            // 
            this.lbl_Radio2.AutoSize = true;
            this.lbl_Radio2.Location = new System.Drawing.Point(917, 497);
            this.lbl_Radio2.Name = "lbl_Radio2";
            this.lbl_Radio2.Size = new System.Drawing.Size(55, 13);
            this.lbl_Radio2.TabIndex = 17;
            this.lbl_Radio2.Text = "distancia1";
            // 
            // lbl_DistanciaCirculo1
            // 
            this.lbl_DistanciaCirculo1.AutoSize = true;
            this.lbl_DistanciaCirculo1.Location = new System.Drawing.Point(732, 559);
            this.lbl_DistanciaCirculo1.Name = "lbl_DistanciaCirculo1";
            this.lbl_DistanciaCirculo1.Size = new System.Drawing.Size(55, 13);
            this.lbl_DistanciaCirculo1.TabIndex = 19;
            this.lbl_DistanciaCirculo1.Text = "distancia1";
            // 
            // lbl_DistanciaCirculo2
            // 
            this.lbl_DistanciaCirculo2.AutoSize = true;
            this.lbl_DistanciaCirculo2.Location = new System.Drawing.Point(842, 559);
            this.lbl_DistanciaCirculo2.Name = "lbl_DistanciaCirculo2";
            this.lbl_DistanciaCirculo2.Size = new System.Drawing.Size(55, 13);
            this.lbl_DistanciaCirculo2.TabIndex = 20;
            this.lbl_DistanciaCirculo2.Text = "distancia1";
            // 
            // btn_ControlManual
            // 
            this.btn_ControlManual.Location = new System.Drawing.Point(820, 103);
            this.btn_ControlManual.Name = "btn_ControlManual";
            this.btn_ControlManual.Size = new System.Drawing.Size(86, 23);
            this.btn_ControlManual.TabIndex = 21;
            this.btn_ControlManual.Text = "Control Manual";
            this.btn_ControlManual.UseVisualStyleBackColor = true;
            this.btn_ControlManual.Click += new System.EventHandler(this.btn_ControlManual_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(0, 0);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 22;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(643, 23);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(99, 20);
            this.numericUpDown2.TabIndex = 23;
            this.numericUpDown2.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(643, 56);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(99, 20);
            this.numericUpDown3.TabIndex = 24;
            this.numericUpDown3.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(634, 314);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(99, 20);
            this.numericUpDown4.TabIndex = 25;
            this.numericUpDown4.Value = new decimal(new int[] {
            13,
            0,
            0,
            0});
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.Location = new System.Drawing.Point(634, 348);
            this.numericUpDown5.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(99, 20);
            this.numericUpDown5.TabIndex = 26;
            this.numericUpDown5.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // btn_ReiniciarTiempoGiro
            // 
            this.btn_ReiniciarTiempoGiro.Location = new System.Drawing.Point(920, 23);
            this.btn_ReiniciarTiempoGiro.Name = "btn_ReiniciarTiempoGiro";
            this.btn_ReiniciarTiempoGiro.Size = new System.Drawing.Size(83, 23);
            this.btn_ReiniciarTiempoGiro.TabIndex = 27;
            this.btn_ReiniciarTiempoGiro.Text = "Reiniciar giro";
            this.btn_ReiniciarTiempoGiro.UseVisualStyleBackColor = true;
            this.btn_ReiniciarTiempoGiro.Click += new System.EventHandler(this.btn_ReiniciarTiempoGiro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 657);
            this.Controls.Add(this.btn_ReiniciarTiempoGiro);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btn_ControlManual);
            this.Controls.Add(this.lbl_DistanciaCirculo2);
            this.Controls.Add(this.lbl_DistanciaCirculo1);
            this.Controls.Add(this.lbl_C2X);
            this.Controls.Add(this.lbl_C2Y);
            this.Controls.Add(this.lbl_Radio2);
            this.Controls.Add(this.lbl_C1X);
            this.Controls.Add(this.lbl_C1Y);
            this.Controls.Add(this.lbl_Radio1);
            this.Controls.Add(this.pb_Imagen_Procesada);
            this.Controls.Add(this.buTerminar);
            this.Controls.Add(this.buIniciar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buTeclas);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.TxWindows);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnDisconnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Imagen_Procesada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox TxWindows;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buTeclas;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buIniciar;
        private System.Windows.Forms.Button buTerminar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pb_Imagen_Procesada;
        private System.Windows.Forms.Label lbl_Radio1;
        private System.Windows.Forms.Label lbl_C1Y;
        private System.Windows.Forms.Label lbl_C1X;
        private System.Windows.Forms.Label lbl_C2X;
        private System.Windows.Forms.Label lbl_C2Y;
        private System.Windows.Forms.Label lbl_Radio2;
        private System.Windows.Forms.Label lbl_DistanciaCirculo1;
        private System.Windows.Forms.Label lbl_DistanciaCirculo2;
        private System.Windows.Forms.Button btn_ControlManual;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Button btn_ReiniciarTiempoGiro;
    }
}

