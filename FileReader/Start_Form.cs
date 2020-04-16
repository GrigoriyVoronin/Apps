using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FileReader
{
    public partial class Start_Form : Form
    {
        private DataGridView table;

        private string firmName;

        private string metroStation;

        public Start_Form()
        {
            InitializeComponent();
        }

        private void OpenBase_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (table?.IsDisposed == false)
                return;

            var data = TextParser.CreateData("pc.txt");
            CreateTable(data);
            Controls.Add(table);
        }

        private void CreateTable(List<Computer> data)
        {
            table = new DataGridView()
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(0, 25),
                Name = "dataGridView",
                Size = new Size(Size.Width - 20, Size.Height - 60),
            };
            ((ISupportInitialize) table).BeginInit();
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

            ((ISupportInitialize)table).EndInit();
            foreach (var t in data)
                table.Rows.Add(t.ToString().Split('\t'));

        }

        private void Exit_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Remove(table);
            metroStation = null;
            firmName = null;
            table.Dispose();
        }

        private void Firm_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            var diaologForm = new Choose_Form("Фирма", "РиМ", "РИК", "ASCOD", "СВЕГА-ПЛЮС");
            diaologForm.ShowDialog(this);
            firmName = diaologForm.ChoosedName;
            FiltrateData();
        }

        private void FiltrateData()
        {
            table?.Dispose();
            var data = TextParser.CreateData("pc.txt").Where(x => (firmName == null ? true : x.Firm.Contains(firmName))
                && (metroStation == null ? true : x.MetroStation.Contains(metroStation))).OrderBy(x => x.Price).ToList();
            CreateTable(data);
            Controls.Add(table);
        }

        private void Metro_toolStripMenuItem_Click(object sender, EventArgs e)
        {
            var diaologForm = new Choose_Form("Станция метро", "Горьк.", "Петр.", "Техн.и-т", "Пл.Восст.");
            diaologForm.ShowDialog(this);
            metroStation = diaologForm.ChoosedName;
            FiltrateData();
        }
    }
}
