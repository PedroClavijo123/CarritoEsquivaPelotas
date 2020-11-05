using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;
using AForge;
using AForge.Imaging;
using AForge.Math.Geometry;

namespace Control_Carrito
{
    public partial class Form1 : Form
    {
        MJPEGStream stream;
        Bitmap bmp;
        bool Ingreso = false; //inicializamos variables que determina si ha ingresa entre un par de circulos
        bool Hay2Circulos = false;//si se cambian de valor si el hilo de procesamiento de imgen ha finalizado
        bool PrimerGiro = true;

        int TiempoPrimerGiro = 850;
        int TiempoAvanzar = 1500;
        int TiempoSegundoGiro = 1050;

        bool FlagInicio = true;

        int DisminucionPrimerGiro = 50;
        int DisminucionAvance = 100;
        int AumentoSegundoGiro = 50;

        bool GiroDerecha = false;

        bool Mov = false;

        int tiempoGiro;

        public Form1()
        {
            //Desde aquí se recibiran los frames enviados desde la cámara del celular
            InitializeComponent();
            stream = new MJPEGStream("http://192.168.1.134:4747/video?640x480");//creando objeto stream
            //Se disparará el evento stream_NewFrame
            stream.NewFrame += stream_NewFrame;
            
        }

        private void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            //Cada vez que se reciba un nuevo frame se mostrará en un picturebox
            bmp = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bmp;//asignamos a nuestro picturebox el bitmap obtenido

                if (!Ingreso)//ingreso cambia de valor  
                {
                    //iniciaremos la ejecución de un nuevo hilo (seuncdario)pasándole como parametro el bitmap actual osea bmp
                    backgroundWorker1.RunWorkerAsync(bmp);
                    Ingreso = true;
                }
            
        }



        //Declaración y creación de delegados 
        delegate void Pasar_Imagen(Bitmap Mapa);//pasar imagen de hilo secundario a hilo principal

        private void Mostrar_Imagen(Bitmap Mapa)//muestra la imagen en picture

        {
            pb_Imagen_Procesada.Image = Mapa;
        }
        delegate void Pasar_Distancias(string Distancias);//pasa las distacias de hilo secundario desde al pricipal

        private void Mostrar_Distancia(string Distancias) //distancias de las pelotas al celular
        {

            lbl_DistanciaCirculo1.Text = Distancias.Split('-')[0];

            lbl_DistanciaCirculo2.Text = Distancias.Split('-')[1];
        }

        delegate void Pasar_Datos(List<string> Datos); //pasa datos de existencia de pelotas de hilo secundario desde al pricipal

        private void Mostrar_Datos(List<string> Datos)
        {
            if (Datos.Count == 2)
            {
                //Si es que datos contiene 2 elementos indicara que se identificaron 2 circunferencias en la imagen
                //Llenamos los labesl con los datos obtenidos
                string[] Datos1 = Datos[0].Split('-');
                lbl_C1X.Text = Datos1[0];
                lbl_C1Y.Text = Datos1[1];
                lbl_Radio1.Text = Datos1[2];

                string[] Datos2 = Datos[1].Split('-');
                lbl_C2X.Text = Datos2[0];
                lbl_C2Y.Text = Datos2[1];
                lbl_Radio2.Text = Datos2[2];

                //Actualizamos la variable booleana Hay2Circulos en true
                Hay2Circulos = true;
            }
            else
            {
                //Caso contrario actualizamos la variable booleana Hay2Circulos en false
                Hay2Circulos = false;
            }
            
        }

        /// //////////////////////////////////////////////////////
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)//funcionamiento del hilo secundario
        {

            //Recuperamos el bitmap seleccionado
            Size a = new Size(640, 480);
            Bitmap bmp2 = new Bitmap((Bitmap)e.Argument,a); //recuperamos el bitmap
           
            //Reducimos el tamaño de la imagen para hacer el procesamiento mas rápido
            Bitmap ImgReducida = new Bitmap((Bitmap)bmp2.Clone(), a);

            //Hacemos llamado a la función FiltrarColoresAzulyRojo para filtrar y resaltar los colores rojo y azul de las pelotas
            bmp2 = FiltrarColoresAzulyRojo(ImgReducida);

            //Con el nuevo bitmap hacemos llamado a la función Procesar_Circulos que nos devolverá los datos de los círculos encontrados
            List<string> Datos = Procesar_Circulos(bmp2);

            //Hacemos llamado a los delegados para pasar los datos obtenidos del procesamiento de la imagen
            Pasar_Datos pd = new Pasar_Datos(Mostrar_Datos);
            this.Invoke(pd, Datos);

            Pasar_Imagen pa = new Pasar_Imagen(Mostrar_Imagen);
            this.Invoke(pa, bmp2);

            double espaciocarro = 0, cordxbolaA = 0, cordxbolaB, formula = 0;
            try
            {
                string[] separar = Datos[Datos.Count - 1].Split('-');        // Datos.Add(CENTRO.X + "-" + CENTRO.Y + "-" + RADIO); distancia bola A y B
                espaciocarro = float.Parse(separar[2]) * 2 * 6;              // diamentroX6pelotas       tamañoX del carro
                cordxbolaA = float.Parse(separar[1]);                        // distancia bola A camara a objeto
                cordxbolaB = float.Parse(separar[2]);                        // distancia bola B
                formula = cordxbolaA * Math.Sin(60) + 3 * float.Parse(separar[2]) * 2; // distancia de pelota a A X sen60 + 3 diametro
                formula = (cordxbolaB - (formula - 3 * float.Parse(separar[2])*2) * Math.Sin(60) > 4) ? formula : 0;
            }//para saber si 
            catch (Exception)
            {
                espaciocarro = 0;               // tamaño del carro
                cordxbolaA = 0;                 // 
                cordxbolaB = 0;
                formula = 0;
            }


            //Construimos la lógica para indicarle el movimiento al carrito según los datos obtenidos

            if (Mov)
            {
                //Verificar si es que se hizo la lectura de 2 circulos
                if (Hay2Circulos)
                {
                    //Verificamos si la coordenada en X del centro del primer círculo es mayor
                    if (float.Parse(lbl_C1X.Text) > float.Parse(lbl_C2X.Text))
                    {
                        //Verificamos si la diferencia entre los radios de los círculos es mayor a 4 pixeles 
                        //y si el radio del primer círculo es mayor que el segundo
                        //indicará que la pelota de la izquierda es mayor al de la derecha
                        if ((float.Parse(lbl_Radio1.Text) - float.Parse(lbl_Radio2.Text)) > 4)
                        {
                            serialPort1.Write("d");
                            System.Threading.Thread.Sleep(TiempoPrimerGiro);

                            serialPort1.Write("w");
                            System.Threading.Thread.Sleep(TiempoAvanzar);

                            
                            serialPort1.Write("p");

                            //Disminuimos los tiempos de giro y de avance del carro
                            TiempoPrimerGiro -= DisminucionPrimerGiro;
                            TiempoAvanzar -= DisminucionAvance;
                            TiempoSegundoGiro += AumentoSegundoGiro;
                            PrimerGiro = true;
                        }
                        else if ((float.Parse(lbl_Radio2.Text) - float.Parse(lbl_Radio1.Text)) > 4)
                        {
                            //Caso contrario indicará que la pelota de la derecha es mayor radio al de la izquierda

                            serialPort1.Write("a");
                            System.Threading.Thread.Sleep(TiempoPrimerGiro);

                            serialPort1.Write("w");
                            System.Threading.Thread.Sleep(TiempoAvanzar);
                            
                            serialPort1.Write("p");

                            //Disminuimos los tiempos de giro y de avance del carro

                            TiempoPrimerGiro -= DisminucionPrimerGiro;
                            TiempoAvanzar -= DisminucionAvance;
                            TiempoSegundoGiro += AumentoSegundoGiro;
                            PrimerGiro = true;
                        }
                        else
                        {
                            serialPort1.Write("w");
                            System.Threading.Thread.Sleep(3000);
                            serialPort1.Write("p");
                        }
                    }
                    else
                    {
                        
                        
                            //Si es que la distancia es menor a 4 pixeles 
                            //el carro avanza hacia adelante
                            serialPort1.Write("w");
                            System.Threading.Thread.Sleep(3000);
                            serialPort1.Write("p");
                        
                    }
                    //Hacemos el cálculo de las distancias
                    double radio1 = double.Parse(lbl_Radio1.Text);
                    double Distancia1 = 4.5 * 0.3 / (radio1 / 1000);

                    double radio2 = double.Parse(lbl_Radio2.Text);
                    double Distancia2 = 4.5 * 0.3 / (radio2 / 1000);
                    
                    //Hacemos llamado al delegado para actualizar las distancias calculadas
                    Pasar_Distancias pa2 = new Pasar_Distancias(Mostrar_Distancia);
                    string a2 = Distancia1.ToString() + "-" + Distancia2.ToString();

                    this.Invoke(pa2, a2);
                }
                else
                {

                    if (!FlagInicio)//cuando el vehiculo no ha hecho ningun movimiento tiene k hacer un giro
                        //para encotrar las pelotas
                    {
                        if(PrimerGiro)
                        {
                            //Si es el primer giro hacemos un giro de 1 segundo
                            serialPort1.Write("a");
                            System.Threading.Thread.Sleep(1000);
                            serialPort1.Write("p");
                            PrimerGiro = false;
                        }
                        else
                        {
                            //Caso contrario hacemos giros consecutivos de 200 milisegundos
                            serialPort1.Write("a");
                            System.Threading.Thread.Sleep(200);
                            serialPort1.Write("p");
                        }
                        

                    }
                    else
                    {
                        FlagInicio = false;
                    }

                }
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//repetimos el procedimiento
        {
            //Al terminar la ejecución del procesamiento de la imagen en el hio secundario
            //iniciamos nuevamente el hilo secundario con una nueva imagen
            System.Threading.Thread.Sleep(1200);
            backgroundWorker1.Dispose();
            backgroundWorker1.CancelAsync();
            backgroundWorker1.RunWorkerAsync(bmp);
        }

        
       //control
        private void btnConnect_Click(object sender, EventArgs e)
        {
            //Evento para hacer la conexión al módulo bluetooth en el carro
            serialPort1.PortName = "COM6";
            serialPort1.BaudRate = 9600;
            serialPort1.Open();

            if (!serialPort1.IsOpen) return;
            btnConnect.Enabled = false;

            MessageBox.Show("Connected", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //Desconecta el módulo bluetooth
            if (serialPort1.IsOpen)
                serialPort1.Close();
            btnConnect.Enabled = true;
            MessageBox.Show("Disconnected", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string tx = TxWindows.Text;
            serialPort1.Write(tx);
            //serialPort1.Close();
            TxWindows.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen) serialPort1.Close();
        }



        private void buTeclas_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Eventos para controlar la pulsación de las teclas
            if (e.KeyChar == (char)Keys.W)
            {
                serialPort1.Write("w");
                
                TxWindows.Clear();
            }
            if (e.KeyChar == (char)Keys.A)
            {
                serialPort1.Write("d");
                TxWindows.Clear();
            }
            if (e.KeyChar == (char)Keys.S)
            {
                //MessageBox.Show("S");
                serialPort1.Write("s");
                TxWindows.Clear();
            }
            if (e.KeyChar == (char)Keys.D)
            {
                // MessageBox.Show("D");
                serialPort1.Write("a");

                TxWindows.Clear();
            }
        }

        private void buTeclas_KeyUp(object sender, KeyEventArgs e)
        {
            serialPort1.Write("p");
            TxWindows.Clear();
        }

        private void TxWindows_TextChanged(object sender, EventArgs e)
        {

        }

        //video
        private void buIniciar_Click(object sender, EventArgs e)
        {
            //Se inicia la recepción de streams
            stream.Start();
        }

        private void buTerminar_Click(object sender, EventArgs e)
        {
            //Se detiene la recepción de streams
            stream.Stop();
        }

        public Bitmap FiltrarColoresAzulyRojo(Bitmap Mapa)
        {
            //Método para filtrar los colores azul y rojo de una imagen 
            Bitmap AuxMapa = Mapa;
            for (int x = 1; x < AuxMapa.Width - 1; x++)
            {
                for (int y = 1; y < AuxMapa.Height - 1; y++)
                {
                    Color oc = AuxMapa.GetPixel(x, y);
                    Color nc = Color.FromArgb(oc.A, 0, 0, oc.B);

                    //Obtenemos los intervalos de tonos a procesar
                    int tonorojo = int.Parse(numericUpDown2.Value.ToString());
                    int tonorojo2 = int.Parse(numericUpDown3.Value.ToString());
                    int tonoazul = int.Parse(numericUpDown4.Value.ToString());
                    int tonoazul2 = int.Parse(numericUpDown5.Value.ToString());

                    if ((oc.R > tonorojo) && (oc.R - oc.G > tonorojo2) && (oc.R - oc.B > tonorojo2))
                    {
                        nc = Color.FromArgb(oc.A, 255, 0, 0); //color rojo   
                    }
                    else if ((oc.B > tonoazul) && (oc.B - oc.G > tonoazul2) && (oc.B - oc.R > tonoazul2))
                    {
                        nc = Color.FromArgb(oc.A, 0, 0, 255);  //color azul
                    }
                    else
                    {
                        nc = Color.FromArgb(oc.A, 0, 0, 0); //negro
                    }

                    AuxMapa.SetPixel(x, y, nc);//modificar pixel en el auxiliar
                }
            }
            return AuxMapa;
        }

        public List<string> Procesar_Circulos(Bitmap BMP)
        {
            //Módulo para encontrar los círculos en una imagen
            List<string> Datos = new List<string>();//crear lista datos k almacenas los datos recopilados
            Rectangle RECTANGULO = new Rectangle(0, 0, BMP.Width, BMP.Height);//declaramos una variable tipo rectangulo k almacenar ala circunferenia
            BitmapData BMPDATOS = BMP.LockBits(RECTANGULO, ImageLockMode.ReadWrite, BMP.PixelFormat);//Bitmapdata obtiene los datos de la imagen

            Bitmap A = new Bitmap(BMP.Width, BMP.Height);//bitmap vacio k almacena el borde de la imagen procesada

            ColorFiltering FILTRO = new ColorFiltering();//filtro k se ablicara a la imagen

            FILTRO.Red = new IntRange(0, 100);//recibe tonalidades de 0 a 100 en sus 3 capas
            FILTRO.Green = new IntRange(0, 100);
            FILTRO.Blue = new IntRange(0, 100);

            FILTRO.FillOutsideRange = false;
            FILTRO.ApplyInPlace(BMPDATOS);

            //BUSCA LOS ELEMENTOS
            BlobCounter ELEMENTOS = new BlobCounter(); //alamacena  los elementos encontrados en la imagen
            ELEMENTOS.FilterBlobs = true;
            ELEMENTOS.MinHeight = 20; //ALTURA y alcho MINIMA del objeto
            ELEMENTOS.MinWidth = 20;

            ELEMENTOS.ProcessImage(BMPDATOS);//obtiene los elementos de la imagen
            Blob[] ELEMENTOSINFO = ELEMENTOS.GetObjectsInformation();
            BMP.UnlockBits(BMPDATOS);

            SimpleShapeChecker BUSCADOR = new SimpleShapeChecker(); //PARA DETERMINAR LA FORMA DE LOS ELEMENTOS ENCONTRADOS
            Graphics DIBUJO = Graphics.FromImage(BMP);//PARA DIBUJAR LOS ELEMENTOS
            Graphics DIBUJO2 = Graphics.FromImage(A);

            Pen CIRCULOS = new Pen(Color.Black, 5); //CIRCULOS
            Pen TRIANGULOS = new Pen(Color.Black, 5); //TRIANGULOS
            Pen CUADRILATEROS = new Pen(Color.Black, 5); //CUADRILATEROS
            Pen TRAZO = new Pen(Color.Red); //'PARA SEÑALIZAR LAS FORMAS


            for (int i = 0; i < ELEMENTOSINFO.Length; i++)//recorremos la imagen pixel a pixel 
            {

                System.Collections.Generic.List<AForge.IntPoint> PUNTOS = ELEMENTOS.GetBlobsEdgePoints(ELEMENTOSINFO[i]);//'OBTIENE LOS PUNTOS DE LA FORMA
                AForge.Point CENTRO = new AForge.Point(); //'CENTRO DEL CIRCULO
                float RADIO = new float(); //'RADIO DEL CIRCULO

                if (BUSCADOR.IsCircle(PUNTOS, out CENTRO, out RADIO))//
                {//'SI ES UN CIRCULO dibujamos
                        DIBUJO.DrawEllipse(CIRCULOS, (int)Math.Round(CENTRO.X - RADIO), (int)Math.Round(CENTRO.Y - RADIO), (int)Math.Round(RADIO * 2), (int)Math.Round(RADIO * 2));// 'DIBUJA EL CIRCULO
                        DIBUJO2.DrawEllipse(CIRCULOS, (int)Math.Round(CENTRO.X - RADIO), (int)Math.Round(CENTRO.Y - RADIO), (int)Math.Round(RADIO * 2), (int)Math.Round(RADIO * 2));// 'DIBUJA EL CIRCULO

                        Datos.Add(CENTRO.X+"-"+CENTRO.Y+"-"+RADIO);
                }
            }

            
            //Mostrar_Imagen A
            Pasar_Imagen pa = new Pasar_Imagen(Mostrar_Imagen);
            this.Invoke(pa, A);

            return Datos;

            
        }


        private void btn_ReiniciarTiempoGiro_Click(object sender, EventArgs e)
        {
            //Evento para reinicializar los valores de los giros
            TiempoPrimerGiro = 800;
            TiempoAvanzar = 1500;
            TiempoSegundoGiro = 1100;
        }



    }
}

