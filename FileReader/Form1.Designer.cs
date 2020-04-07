using System.Drawing;

namespace FileReader
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.file_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openBase_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.information_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firm_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metro_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.help_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about_toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.info_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_toolStripMenuItem,
            this.information_ToolStripMenuItem,
            this.help_toolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1165, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // file_toolStripMenuItem
            // 
            this.file_toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openBase_toolStripMenuItem,
            this.exit_toolStripMenuItem});
            this.file_toolStripMenuItem.Name = "file_toolStripMenuItem";
            this.file_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.file_toolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.file_toolStripMenuItem.Text = "File";
            // 
            // openBase_toolStripMenuItem
            // 
            this.openBase_toolStripMenuItem.Name = "openBase_toolStripMenuItem";
            this.openBase_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.A)));
            this.openBase_toolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.openBase_toolStripMenuItem.Text = "Open base";
            this.openBase_toolStripMenuItem.Click += new System.EventHandler(this.openBase_toolStripMenuItem_Click_1);
            // 
            // exit_toolStripMenuItem
            // 
            this.exit_toolStripMenuItem.Name = "exit_toolStripMenuItem";
            this.exit_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.B)));
            this.exit_toolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.exit_toolStripMenuItem.Text = "Exit";
            this.exit_toolStripMenuItem.Click += new System.EventHandler(this.exit_toolStripMenuItem_Click);
            // 
            // information_ToolStripMenuItem
            // 
            this.information_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firm_toolStripMenuItem,
            this.metro_toolStripMenuItem});
            this.information_ToolStripMenuItem.Name = "information_ToolStripMenuItem";
            this.information_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.information_ToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.information_ToolStripMenuItem.Text = "Информация";
            // 
            // firm_toolStripMenuItem
            // 
            this.firm_toolStripMenuItem.Name = "firm_toolStripMenuItem";
            this.firm_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.C)));
            this.firm_toolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.firm_toolStripMenuItem.Text = "Фирма";
            this.firm_toolStripMenuItem.Click += new System.EventHandler(this.firm_toolStripMenuItem_Click);
            // 
            // metro_toolStripMenuItem
            // 
            this.metro_toolStripMenuItem.Name = "metro_toolStripMenuItem";
            this.metro_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.D)));
            this.metro_toolStripMenuItem.Size = new System.Drawing.Size(231, 22);
            this.metro_toolStripMenuItem.Text = "Станция метро";
            this.metro_toolStripMenuItem.Click += new System.EventHandler(this.metro_toolStripMenuItem_Click);
            // 
            // help_toolStripMenuItem
            // 
            this.help_toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about_toolStripMenuItem});
            this.help_toolStripMenuItem.Name = "help_toolStripMenuItem";
            this.help_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.help_toolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.help_toolStripMenuItem.Text = "Help";
            // 
            // about_toolStripMenuItem
            // 
            this.about_toolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.info_ToolStripMenuItem});
            this.about_toolStripMenuItem.Name = "about_toolStripMenuItem";
            this.about_toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.about_toolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.about_toolStripMenuItem.Text = "About";
            // 
            // info_ToolStripMenuItem
            // 
            this.info_ToolStripMenuItem.Name = "info_ToolStripMenuItem";
            this.info_ToolStripMenuItem.Size = new System.Drawing.Size(256, 50);
            this.info_ToolStripMenuItem.Text = "Если хотите сбросить фильтр по\n одному из параметров, остаьвте\n поле \"Other\" пуст" +
    "ым.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 500);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            this.Name = "Form1";
            this.Text = "Воронин Григорий ИВТ-19-1 12 Вариант";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem file_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openBase_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exit_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem information_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem firm_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metro_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem help_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem about_toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem info_ToolStripMenuItem;
    }
}

