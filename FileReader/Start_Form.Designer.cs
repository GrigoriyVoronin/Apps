using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FileReader
{
    partial class Start_Form
    {
        private MenuStrip menuStrip;
        private ToolStripMenuItem file_toolStripMenuItem;
        private ToolStripMenuItem openBase_toolStripMenuItem;
        private ToolStripMenuItem exit_toolStripMenuItem;
        private ToolStripMenuItem information_ToolStripMenuItem;
        private ToolStripMenuItem firm_toolStripMenuItem;
        private ToolStripMenuItem metro_toolStripMenuItem;
        private ToolStripMenuItem help_toolStripMenuItem;
        private ToolStripMenuItem about_toolStripMenuItem;
        private ToolStripMenuItem info_ToolStripMenuItem;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            openBase_toolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "openBase_toolStripMenuItem",
                ShortcutKeys = (Keys.Control | Keys.Shift) | Keys.A,
                Size = new Size(204, 22),
                Text = "Open base",
            };
            openBase_toolStripMenuItem.Click += new EventHandler(OpenBase_toolStripMenuItem_Click);

            exit_toolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "exit_toolStripMenuItem",
                ShortcutKeys = (Keys.Control | Keys.Shift) | Keys.B,
                Size = new Size(204, 22),
                Text = "Exit",
            };
            exit_toolStripMenuItem.Click += new EventHandler(Exit_toolStripMenuItem_Click);

            file_toolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "file_toolStripMenuItem",
                ShortcutKeys = Keys.Control | Keys.A,
                Size = new Size(37, 20),
                Text = "File",
            };
            file_toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openBase_toolStripMenuItem, exit_toolStripMenuItem });

            firm_toolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "firm_toolStripMenuItem",
                ShortcutKeys = (Keys.Control | Keys.Shift) | Keys.C,
                Size = new Size(231, 22),
                Text = "Фирма",
            };
            firm_toolStripMenuItem.Click += new EventHandler(Firm_toolStripMenuItem_Click);

            metro_toolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "metro_toolStripMenuItem",
                ShortcutKeys = (Keys.Control | Keys.Shift) | Keys.D,
                Size = new Size(231, 22),
                Text = "Станция метро",
            };
            metro_toolStripMenuItem.Click += new EventHandler(Metro_toolStripMenuItem_Click);

            information_ToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "information_ToolStripMenuItem",
                ShortcutKeys = Keys.Control | Keys.B,
                Size = new System.Drawing.Size(93, 20),
                Text = "Информация",
            };
            information_ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { firm_toolStripMenuItem, metro_toolStripMenuItem });

            info_ToolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "info_ToolStripMenuItem",
                Size = new Size(256, 50),
                Text = "Если хотите сбросить фильтр по\n одному из параметров, остаьвте\n поле \"Other\" пустым.",
            };

            about_toolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "about_toolStripMenuItem",
                ShortcutKeys = (Keys.Control | Keys.Shift) | Keys.E,
                Size = new Size(180, 22),
                Text = "About",
            };
            about_toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { info_ToolStripMenuItem });

            help_toolStripMenuItem = new ToolStripMenuItem()
            {
                Name = "help_toolStripMenuItem",
                ShortcutKeys = Keys.Control | Keys.C,
                Size = new Size(44, 20),
                Text = "Help",
            };
            help_toolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { about_toolStripMenuItem });

            menuStrip = new MenuStrip()
            {
                Location = new Point(0, 0),
                Name = "menuStrip",
                Size = new Size(1165, 24),
                Text = "menuStrip",
            };
            menuStrip.Items.AddRange(new ToolStripItem[] { file_toolStripMenuItem, information_ToolStripMenuItem, help_toolStripMenuItem });

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1165, 500);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            MaximumSize = Size;
            MinimumSize = Size;
            Name = "Start_Form";
            Text = "Воронин Григорий ИВТ-19-1 12 Вариант";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

