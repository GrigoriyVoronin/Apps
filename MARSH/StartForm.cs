using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MARSH
{
    public partial class StartForm : Form
    {
        public List<Route> Routes
        {
            get => routes;
            private set
            {
                routes = value;
                CreateTable();
            }
        }

        private List<Route> routes = new List<Route>();

        private DataGridView table;

        public StartForm()
        {
            InitializeComponent();
            CreateTable();
        }

        private void AddRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AddRouteForm().ShowDialog(this);
        }

        private void DeleteRouteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new DeleteRouteForm().ShowDialog(this);
        }

        private void SearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SearchForm().ShowDialog(this);
        }

        private void SortByStartNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Routes = Routes.OrderBy(x => x.StrartName).ToList();
        }

        private void SortByEndNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Routes = Routes.OrderBy(x => x.EndName).ToList();
        }

        private void SortByNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Routes = Routes.OrderBy(x => x.NumberOfRoute).ToList();
        }

        public void AddRowInTable(Route route)
        {
            Routes.Add(route);
            table.Rows.Add(route.ToString().Split());
        }

        public void DeleteRowFromTable(int numberOfRoute)
        {
            for (var i = 0; i < table?.RowCount; i++)
            {
                if (int.Parse((string) table.Rows[i].Cells[0].Value) != numberOfRoute) continue;
                table.Rows.RemoveAt(i);
                break;
            }

            Routes.Remove(Routes.Find(x=>x.NumberOfRoute==numberOfRoute));
        }

        private void CreateTable(List<Route> searchRoutes = null)
        {
            Controls.Remove(table);
            table = new DataGridView()
            {
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Location = new Point(0, 25),
                Name = "dataGridView",
                Size = new Size(Size.Width - 20, Size.Height - 60),
            };
            ((ISupportInitialize) table).BeginInit();
            table.ColumnCount = 3;
            table.Columns[0].Name = "Номер маршрута";
            table.Columns[1].Name = "Точка отправления";
            table.Columns[2].Name = "Конечная точка";

            ((ISupportInitialize) table).EndInit();
            foreach (var route in searchRoutes ?? Routes)
                table.Rows.Add(route.ToString().Split());
            Controls.Add(table);
        }

        private void FileToolStripMenuItemClick(object sender, EventArgs e)
        {
            var fileForm = new FileWorkerForm();
            fileForm.ShowDialog(this);
        }

        public void UpdateTable(List<Route> newRoutes)
        {
            Routes = newRoutes;
        }

        public void FiltrateData(string startName, string endName)
        {
            List<Route> data = null;
            switch (startName)
            {
                case null when endName is null:
                    new ErrorForm("Недопустимый ввод").ShowDialog(this);
                    break;
                case null:
                    data = Routes.Where(x => x.EndName.Contains(endName)).ToList();
                    break;
                default:
                {
                    data = endName is null
                        ? Routes.Where(x => x.StrartName.Contains(startName)).ToList()
                        : Routes.Where(x => x.StrartName.Contains(startName) && x.EndName.Contains(endName)).ToList();
                    break;
                }
            }

            if (data == null || data.Count == 0)
                new ErrorForm("Таких маршрутов не существует").ShowDialog(this);
            else
                CreateTable(data);
        }
    }
}
