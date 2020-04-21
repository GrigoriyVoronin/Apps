using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace ShowSort
{
    internal class ChooseSort
    {
        private delegate void ChangePointColor(int index, Chart chart, Color color);

        private delegate void UpdateChart(Chart chart);

        public void Sort(Chart chart)
        {
            lock(chart)
            {
            var list = chart.Series[0].Points;
            for (int i = 0; i < list.Count-1; i++)
            {
                var min = i;
                for (int j = i + 1; j < list.Count; j++)
                    if (list[j].YValues[0] < list[min].YValues[0])
                    {
                        Thread.Sleep(1);
                        chart.Invoke(new ChangePointColor(ColorChange),min,chart, Color.Blue);
                        min = j;
                        chart.Invoke(new ChangePointColor(ColorChange),min,chart, Color.Red);
                        chart.Invoke(new UpdateChart(UpdateChart1),chart);
                    }
                Thread.Sleep(1);
                var buffer = list[i].YValues[0];
                list[i].YValues[0]=list[min].YValues[0];
                list[min].YValues[0] = buffer;
                chart.Invoke(new ChangePointColor(ColorChange),min,chart, Color.Blue);
                chart.Invoke(new UpdateChart(UpdateChart1),chart);
            }
            }
        }

        private void ColorChange(int index, Chart chart, Color color)
        {
            chart.Series[0].Points[index].Color= color;
        }

        private void UpdateChart1(Chart chart)
        {
            chart.Update();
        }
    }
}
