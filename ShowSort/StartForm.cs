using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ShowSort
{
    public partial class StartForm : Form
    {
        private double[] data = Array.Empty<double>();

        private Chart chart = new Chart();

        private readonly BackgroundWorker back = new BackgroundWorker();

        public StartForm()
        {
            InitializeComponent();
            back.WorkerSupportsCancellation=true;
            back.DoWork += BackDoWork;
        }

        private void FileMenuItemClick(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog()
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Text files|*.txt;*.doc;*.docx",
            };
            try
            {
                ofd.ShowDialog(this);
                data=File
                    .ReadAllText(ofd.FileName)
                    .Split()
                    .Select(x=>double.Parse(x))
                    .ToArray();
                animateToolStripMenuItem.Enabled=true;
            }
            catch
            {
                MessageBox.Show(this,"Неверный путь к файлу\r\nили некорректное содержимое файла");
            }

            ofd.Dispose();
        }

        private void AnimateMenuItemClick(object sender, EventArgs e)
        {
            Controls.Remove(chart);
            chart.Dispose();
            chart = CreateChart();
            Controls.Add(chart);
            chart.Show();
            Thread.Sleep(10);
            back.RunWorkerAsync(chart);
        }

        private void BackDoWork(object sender, DoWorkEventArgs e)
        {
            new ChooseSort().Sort((Chart)e.Argument);
        }

        private void AboutMenuItemClick(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Разработчик Воронин Григорий ИВТ-19-1");
        }

        private void ExitMenuItemClick(object sender, EventArgs e)
        {
            Dispose();
        }

        private Chart CreateChart()
        {
            var chart = new Chart()
            {
                Size=new Size(Size.Width,Size.Height),
            };
            chart.Titles.Add("Сортировка выбором");
            var chartArea = new ChartArea();
            chartArea.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas.Add(chartArea);
            var series = new Series()
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Blue,
            };
            var data = this.data.ToArray();
            for (int i =0;i<data.Length;i++)
                series.Points.Add(new DataPoint(i,data[i]));
            chart.Series.Add(series);
            return chart;
        }
    }
}
