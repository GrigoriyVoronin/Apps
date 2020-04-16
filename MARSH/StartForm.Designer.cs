using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MARSH
{
    partial class StartForm
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.addRouteToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "addRouteToolStripMenuItem",
                Size = new Size(107, 22),
                Text = "Add",
            };
            this.addRouteToolStripMenuItem.Click += new EventHandler(this.AddRouteToolStripMenuItem_Click);

            this.deleteRouteToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "deleteRouteToolStripMenuItem",
                Size = new Size(107, 22),
                Text = "Delete",
            };
            this.deleteRouteToolStripMenuItem.Click += new EventHandler(this.DeleteRouteToolStripMenuItem_Click);

            this.routeToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "routeToolStripMenuItem",
                Size = new Size(50, 20),
                Text = "Route",
            };
            this.routeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.addRouteToolStripMenuItem,
                this.deleteRouteToolStripMenuItem});

            this.fileToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "fileToolStripMenuItem",
                Size = new Size(37, 20),
                Text = "Работа с файлов",
            };
            this.fileToolStripMenuItem.Click += new EventHandler(this.FileToolStripMenuItemClick);

            this.sortByStartNameToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "sortByStartNameToolStripMenuItem",
                Size = new Size(180, 22),
                Text = "По пункту отправления",
            };
            this.sortByStartNameToolStripMenuItem.Click += new EventHandler(this.SortByStartNameToolStripMenuItem_Click);

            this.sortByEndNameToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "sortByEndNameToolStripMenuItem",
                Size = new Size(180, 22),
                Text = "По конечному пункту",
            };
            this.sortByEndNameToolStripMenuItem.Click += new EventHandler(this.SortByEndNameToolStripMenuItem_Click);

            this.sortByNumberToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "sortByNumberToolStripMenuItem",
                Size = new Size(180, 22),
                Text = "По номеру маршрута",
            };
            this.sortByNumberToolStripMenuItem.Click += new EventHandler(this.SortByNumberToolStripMenuItem_Click);

            this.sortToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "sortToolStripMenuItem",
                Size = new Size(109, 22),
                Text = "Сортировка",
            };
            this.sortToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.sortByStartNameToolStripMenuItem,
                this.sortByEndNameToolStripMenuItem,
                this.sortByNumberToolStripMenuItem});

            this.searchToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "searchToolStripMenuItem",
                Size = new Size(109, 22),
                Text = "Поиск",
            };
            this.searchToolStripMenuItem.Click += new EventHandler(this.SearchToolStripMenuItem_Click);

            this.prepareToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "prepareToolStripMenuItem",
                Size = new Size(114, 20),
                Text = "Преобразования коллекции",
            };
            this.prepareToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
                this.sortToolStripMenuItem,
                this.searchToolStripMenuItem});

            this.menuMenuStrip = new MenuStrip()
            {
                Location = new Point(0, 0),
                Name = "menuMenuStrip",
                Size = new Size(356, 24),
                TabIndex = 0,
            };
            this.menuMenuStrip.Items.AddRange(new ToolStripItem[] {
                this.routeToolStripMenuItem,
                this.fileToolStripMenuItem,
                this.prepareToolStripMenuItem});

            this.menuMenuStrip.SuspendLayout();
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(356, 329);
            this.Controls.Add(this.menuMenuStrip);
            this.MainMenuStrip = this.menuMenuStrip;
            this.Name = "StartForm";
            this.Text = "Воронин Григорий ИВТ-19-1";
            this.menuMenuStrip.ResumeLayout(false);
            this.menuMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private MenuStrip menuMenuStrip;
        private ToolStripMenuItem routeToolStripMenuItem;
        private ToolStripMenuItem addRouteToolStripMenuItem;
        private ToolStripMenuItem deleteRouteToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem prepareToolStripMenuItem;
        private ToolStripMenuItem sortToolStripMenuItem;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem sortByStartNameToolStripMenuItem;
        private ToolStripMenuItem sortByEndNameToolStripMenuItem;
        private ToolStripMenuItem sortByNumberToolStripMenuItem;
    }
}

