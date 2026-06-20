using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace IA_SENSOR_RNA
{
    public partial class Form1 : Form
    {
        private List<int[]> patronesEntrada = new List<int[]>();
        private List<int> patronesSalida = new List<int>();
        private string rutaPML;

        public Form1()
        {
            InitializeComponent();
         
            // Mostrar un MessageBox para seleccionar la vista
            DialogResult resultado = MessageBox.Show("Selecciona una vista:\n\nSí: Vista 1 (Formulario actual)\nNo: Vista 2 (Control alterno)",
                                                     "Seleccionar Vista", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Vista 1: continuar con el formulario actual
                rutaPML = Path.Combine(Application.StartupPath, @"Ejemplo2.pml");
            }
            else
            {
                // Vista 2: cargar el control de usuario alternativo
                CargarVista2();
            }
            ReadPML();
        }

        private void CargarVista2()
        {
            try
            {
                // Limpiar los controles actuales del formulario
                this.Controls.Clear();

                // Crear una instancia del control de usuario Vista2Control
                Vista2Control vista2 = new Vista2Control
                {
                    Dock = DockStyle.Fill // Hacer que el control ocupe todo el formulario
                };

                // Agregar el control al formulario
                this.Controls.Add(vista2);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar Vista 2: {ex.Message}", "Error");
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            PuertosActualesPCom();
        }

        private void PuertosActualesPCom()
        {
            string[] puertos = SerialPort.GetPortNames();
            comboBoxPuertos.Items.Clear();
            comboBoxPuertos.Items.AddRange(puertos);

            if (puertos.Length > 0)
            {
                comboBoxPuertos.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No se encontraron puertos COM disponibles.", "Advertencia");
            }
        }

        private void ConfigurarPuertoSerial()
        {
            try
            {
                if (comboBoxPuertos.SelectedItem == null)
                {
                    MessageBox.Show("Selecciona un puerto COM antes de continuar.", "Advertencia");
                    return;
                }

                serialPort1.PortName = comboBoxPuertos.SelectedItem.ToString();
                serialPort1.BaudRate = 115200;
                serialPort1.DataReceived += SerialPort_DataReceived;

                if (!serialPort1.IsOpen)
                    serialPort1.Open();

                MessageBox.Show("Puerto serial configurado correctamente.", "Éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al configurar el puerto serial: {ex.Message}", "Error");
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string jsonData = serialPort1.ReadLine();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    DatosSensor datos = JsonSerializer.Deserialize<DatosSensor>(jsonData);
                    this.Invoke(new Action(() => ProcesarDatosSensor(datos)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al leer o procesar datos del puerto serial: {ex.Message}", "Error");
            }
        }

        private void ProcesarDatosSensor(DatosSensor datos)
        {
            try
            {
                // Generar tres entradas (x1, x2, x3)
                int[] entrada = { (int)Math.Round(datos.temperatura), (int)Math.Round(datos.humedad), 0 }; // x1 = temperatura, x2 = humedad, x3 = 0
                int salidaEsperada = GenerarSalidaEsperada(datos);

                AgregarPatron(entrada, salidaEsperada);

                txtTemperatura.Text = entrada[0].ToString();
                txtHumedad.Text = entrada[1].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar los datos del sensor: {ex.Message}", "Error");
            }
        }

        private int GenerarSalidaEsperada(DatosSensor datos)
        {
            // Generar salidas esperadas del 1 al 9 en secuencia
            int indice = patronesSalida.Count % 9; // Obtener el índice cíclico basado en la cantidad de patrones registrados
            return indice + 1; // Devuelve un valor entre 1 y 9
        }

        private void AgregarPatron(int[] entrada, int salidaEsperada)
        {
            try
            {
                if (!patronesEntrada.Any(p => p.SequenceEqual(entrada)))
                {
                    patronesEntrada.Add(entrada);
                    patronesSalida.Add(salidaEsperada);

                    txtEstado.Text = $"Se ha registrado el patrón número {patronesEntrada.Count}.";

                    GuardarPatronEnArchivo();

                    if (patronesEntrada.Count >= 8)
                    {
                        DetenerProgramaConEsperaYCierre();
                    }
                }
                else
                {
                    txtEstado.Text = "El patrón recibido ya existe, no se agregará nuevamente.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar patrón: {ex.Message}", "Error");
            }
        }

        private void GuardarPatronEnArchivo()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(rutaPML))
                {
                    // Escribir cabecera del archivo PML
                    writer.WriteLine("3 3 8 1");
                    writer.WriteLine("2.75");
                    writer.WriteLine("100000");
                    writer.WriteLine("0.00001");
                    writer.WriteLine("8");
                    writer.WriteLine(); // Espacio adicional entre la cabecera y los patrones

                    // Escribir patrones de entrada
                    foreach (var entrada in patronesEntrada)
                    {
                        writer.WriteLine(string.Join("    ", entrada));
                    }

                    writer.WriteLine(); // Espacio adicional entre los patrones y las salidas

                    // Escribir salidas en forma de lista
                    foreach (var salida in patronesSalida)
                    {
                        writer.WriteLine(salida);
                    }
                }

                txtEstado.Text = $"Archivo PML actualizado con {patronesEntrada.Count} patrones.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el archivo PML: {ex.Message}", "Error");
            }
        }



        private void DetenerProgramaConEsperaYCierre()
        {
            try
            {
                txtEstado.Text = "Se han registrado los 8 patrones. Cerrando el archivo y esperando 10 milisegundos...";

                // Esperar 10 milisegundos
                Thread.Sleep(10);

                // Cerrar el puerto serial si está abierto
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }

                MessageBox.Show("Se han registrado los 8 patrones. El programa se ha detenido.", "Información");

                // Desactivar el evento y salir de la aplicación
                serialPort1.DataReceived -= SerialPort_DataReceived;
                Application.Exit(); // Finalizar la aplicación
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al detener el programa: {ex.Message}", "Error");
            }
        }

        private void BtnConfigurar_Click(object sender, EventArgs e)
        {
            ConfigurarPuertoSerial();
        }

        private void BtnEntrenar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este botón no tiene funcionalidad en esta versión.", "Información");
        }

        private void BtnProbar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este botón no tiene funcionalidad en esta versión.", "Información");
        }

        private void ReadPML()
        {
            try
            {
                // Directorio donde se encuentran los archivos .pml
                string directorio = Directory.GetCurrentDirectory(); // Cambia esto por tu ruta deseada

                // Obtener todos los archivos .pml del directorio
                string[] archivosPML = Directory.GetFiles(directorio, "*.pml");

                // Agregar los archivos al ComboBox
                comboBoxVerPML.Items.Clear(); // Limpiar cualquier elemento previo
                comboBoxVerPML.Items.AddRange(archivosPML);

                // Mostrar mensaje si no hay archivos
                if (archivosPML.Length == 0)
                {
                    Console.WriteLine("No se encontraron archivos .pml en el directorio especificado.");
                }
            }
            catch (Exception ex)
            {
                // Manejar errores al cargar los archivos
                Console.WriteLine($"Error al cargar los archivos .pml: {ex.Message}");
            }
        }

        private void btnVerPMLS_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener el archivo seleccionado en el ComboBox
                string archivoSeleccionado = comboBoxVerPML.SelectedItem?.ToString();

                // Validar que se haya seleccionado un archivo
                if (string.IsNullOrEmpty(archivoSeleccionado))
                {
                    Console.WriteLine("Por favor, selecciona un archivo PML.");
                    return;
                }

                // Leer el contenido del archivo seleccionado
                if (File.Exists(archivoSeleccionado))
                {
                    string contenido = File.ReadAllText(archivoSeleccionado);

                    // Mostrar el contenido en la consola
                    Console.WriteLine($"Contenido del archivo '{archivoSeleccionado}':");
                    Console.WriteLine(contenido);
                }
                else
                {
                    Console.WriteLine($"El archivo '{archivoSeleccionado}' no existe.");
                }
            }
            catch (Exception ex)
            {
                // Manejar errores y mostrar mensaje en la consola
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }
        }

        
    }



    public class DatosSensor
    {
        public double temperatura { get; set; }
        public double humedad { get; set; }
    }
}
