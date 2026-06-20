using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using IAupt.uptRNA;

namespace IA_SENSOR_RNA
{
    public partial class Vista2Control : UserControl
    {
        public Vista2Control()
        {
            InitializeComponent();
            CargarPMLsActuales();
            CargarPPMSActuales();


            // Mostrar los valores actuales de los trackbars en los labels
            labelTrackBar1.Text = trackBar1.Value.ToString();
            labelTrackBar2.Text = trackBar2.Value.ToString();
            labelTrackBar3.Text = trackBar3.Value.ToString();


        }

        private void Vista2Control_Load(object sender, EventArgs e)
        {

        }



        private void CargarPMLsActuales()
        {
            string carpetaActual = AppDomain.CurrentDomain.BaseDirectory;

            string[] archivosPPMS = Directory.GetFiles(carpetaActual, "*.pml")
                                            .Select(Path.GetFileName)
                                            .ToArray();

           

            comboBoxPMLSActuales.Items.Clear();
            comboBoxPMLSActuales.Items.AddRange(archivosPPMS);
        }

        private void CargarPPMSActuales()
        {
            string carpetaActual = AppDomain.CurrentDomain.BaseDirectory;

            string[] archivosPML = Directory.GetFiles(carpetaActual, "*.ppm")
                                            .Select(Path.GetFileName)
                                            .ToArray();



            comboBoxCargarPPMS.Items.Clear();
            comboBoxCargarPPMS.Items.AddRange(archivosPML);
        }




        private void EntrenarPMLaPPM_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBoxPMLSActuales.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un archivo PML para entrenar.", "Error");
                    return;
                }

                string archivoPML = Path.Combine(Application.StartupPath, comboBoxPMLSActuales.SelectedItem.ToString());

                // Cargar y entrenar la red neuronal
                PerceptronMultiCapa rna = new PerceptronMultiCapa(archivoPML);
                rna.entrenar(); // Entrenamiento supervisado

                MessageBox.Show("Entrenamiento finalizado.\nModelo guardado como archivo .ppm", "Éxito");


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el entrenamiento: {ex.Message}", "Error");
            }
        }

       

       

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelTrackBar1.Text = trackBar1.Value.ToString();

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            labelTrackBar2.Text = trackBar2.Value.ToString();

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            labelTrackBar3.Text = trackBar3.Value.ToString();

        }

       

        private void btnReconocerPA_Click(object sender, EventArgs e)
        {
            if (comboBoxCargarPPMS.SelectedItem == null)
            {
                string[] archivosPPM = Directory.GetFiles(Application.StartupPath, "*.ppm");
                if (archivosPPM.Length > 0)
                {
                    comboBoxCargarPPMS.SelectedItem = Path.GetFileName(archivosPPM[0]);
                }
                else
                {
                    MessageBox.Show("No se encontraron archivos PPM entrenados. Primero entrena el modelo.", "Error");
                    return;
                }
            }

            // Aquí ya no es necesario pasar argumentos, ya que la variable comboBoxCargarPPMS.SelectedItem tiene el valor correcto
            string archivoPPM = Path.Combine(Application.StartupPath, comboBoxCargarPPMS.SelectedItem.ToString());
            PerceptronMultiCapa rna = new PerceptronMultiCapa(archivoPPM);


            double[] x = { trackBar1.Value, trackBar2.Value, trackBar3.Value };
            rna.reconocer(x);

            double[,] y = rna.y;
            // Convertir la matriz a una cadena
            string resultado = ConvertirMatrizADobleString(y);

            // Obtener la recomendación y clasificación basada en la salida
            string recomendacion = ObtenerRecomendacion(x);
            string clasificacion = ClasificarTemperaturas(x);

            // Mostrar el resultado en un MessageBox
            MessageBox.Show(resultado, "Resultado de Reconocimiento");
            // Graficar la activación
            GraficarActivacion(y);
            // Mostrar el resultado, la recomendación y la clasificación en un MessageBox
            MessageBox.Show($"{resultado}\nRecomendación: {recomendacion}\nClasificación: {clasificacion}", "Resultado de Reconocimiento");
        }

        private string ConvertirMatrizADobleString(double[,] matriz)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    sb.Append(matriz[i, j].ToString("F2") + "\t"); // Formato con 2 decimales
                }
                sb.AppendLine(); // Nueva línea después de cada fila
            }
            return sb.ToString();
        }

        private void GraficarActivacion(double[,] y)
        {
            chartActivacion.Series.Clear();

            // Asegúrate de que y tenga al menos 3 columnas
            int numeroDeColumnas = y.GetLength(1);
            int numeroDeFilas = y.GetLength(0);

            // Colores y estilos para las series
            Color[] colores = { Color.Red, Color.Green, Color.Blue };
            ChartDashStyle[] estilos = { ChartDashStyle.Solid, ChartDashStyle.Dash, ChartDashStyle.Dot };

            // Graficar cada columna de la matriz y
            for (int col = 0; col < Math.Min(numeroDeColumnas, 3); col++)
            {
                Series series = new Series($"Activación {col + 1}");
                series.ChartType = SeriesChartType.Line;
                series.Color = colores[col];
                series.BorderDashStyle = estilos[col];
                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 5;
                series.MarkerColor = colores[col];

                for (int row = 0; row < numeroDeFilas; row++)
                {
                    series.Points.AddXY(row, y[row, col]); // Graficar cada fila de la columna actual
                }

                chartActivacion.Series.Add(series);
            }

            // Configuración adicional del gráfico
            chartActivacion.Titles.Clear();
            chartActivacion.Titles.Add("Activaciones de la Red Neuronal");
            chartActivacion.ChartAreas[0].AxisX.Title = "Índice";
            chartActivacion.ChartAreas[0].AxisY.Title = "Valor de Activación";

            chartActivacion.Invalidate(); // Refrescar el gráfico
        }

        private string ObtenerRecomendacion(double[] entradas)
        {
            int temp1 = (int)entradas[0];
            int temp2 = (int)entradas[1];
            int temp3 = (int)entradas[2];

            if (temp1 == 30 && temp2 == 0) return "Salida: 1";
            if (temp1 == 10 && temp2 == 30) return "Salida: 2";
            if (temp1 == 15 && temp2 == 30) return "Salida: 2";
            if (temp1 == 20 && temp2 == 42) return "Salida: 4";
            if (temp1 == 25 && temp2 == 40) return "Salida: 5";
            if (temp1 == 30 && temp2 == 50) return "Salida: 6";
            if (temp1 == 35 && temp2 == 60) return "Salida: 7";
            if (temp1 == 40 && temp2 == 10) return "Salida: 8";

            return "Salida Desconocida"; // Si no coincide con ningún patrón
        }

        private string ClasificarTemperaturas(double[] entradas)
        {
            string clasificacion = "Clasificación de Temperaturas:\n";

            foreach (var temp in entradas)
            {
                if (temp < 15)
                {
                    clasificacion += $"{temp}°C: Frío\n";
                }
                else if (temp >= 15 && temp < 25)
                {
                    clasificacion += $"{temp}°C: Templado\n";
                }
                else if (temp >= 25 && temp < 35)
                {
                    clasificacion += $"{temp}°C: Cálido\n";
                }
                else
                {
                    clasificacion += $"{temp}°C: Calor Extremo\n";
                }
            }

            return clasificacion;
        }

    }
}
