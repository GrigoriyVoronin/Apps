using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileReader
{
    public partial class Form1 : Form
    {
        private DataGridView table;

        private string firmName;

        private string metroStation;

        public Form1()
        {
            InitializeComponent();
        }

        private void openBase_toolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (table!=null && !table.IsDisposed)
                return;
            var data = TextParser.CreateData("pc.txt");
            CreateTable(data);
            Controls.Add(table);
        }

        private void CreateTable(List<Computer> data)
        {
            table = new DataGridView();
            ((ISupportInitialize)table).BeginInit();
            table.ColumnCount = 11;
            table.Columns[0].Name = "Model";
            table.Columns[1].Name = "RAM";
            table.Columns[2].Name = "HDD";
            table.Columns[3].Name = "Video";
            table.Columns[4].Name = "CD ROM";
            table.Columns[5].Name = "Sound";
            table.Columns[6].Name = "Notes";
            table.Columns[7].Name = "Price";
            table.Columns[8].Name = "Firm";
            table.Columns[9].Name = "Telephone";
            table.Columns[10].Name = "Metro";
            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            table.Location = new Point(0, 25);
            table.Name = "dataGridView";
            table.Size = new Size(Size.Width - 20, Size.Height-60);
            for (int i = 0; i < data.Count; i++)
                table.Rows.Add(data[i].ToString().Split('\t'));
            ((ISupportInitialize)table).EndInit();
        }

        private void exit_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Remove(table);
            metroStation = null;
            firmName = null;
            table.Dispose();
        }

        private void firm_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            var diaologForm = new Choose_Form("Фирма", "РиМ", "РИК", "ASCOD", "СВЕГА-ПЛЮС");
            diaologForm.ShowDialog(this);
            firmName = diaologForm.ChoosedName;
            FiltrateData();
        }

        private void FiltrateData()
        {
            table?.Dispose();
            var data = TextParser.CreateData("pc.txt").Where(x=> (firmName==null ? true :  x.Firm.Contains(firmName) )
                &&(metroStation==null?true : x.MetroStation.Contains(metroStation))).OrderBy(x=>double.Parse(x.Price)).ToList();
            CreateTable(data);
            Controls.Add(table);
        }

        private void metro_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            var diaologForm = new Choose_Form("Станция метро", "Горьк.", "Петр.", "Техн.и-т", "Пл.Восст.");
            diaologForm.ShowDialog(this);
            metroStation = diaologForm.ChoosedName;
            FiltrateData();
        }
    }
}
