using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace ShowSort
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
            fileToolStripMenuItem = new ToolStripMenuItem()
            {
                Text = "File",
            };
            fileToolStripMenuItem.Click += new EventHandler(FileMenuItemClick);

            animateToolStripMenuItem = new ToolStripMenuItem()
            {
                Text = "Animate",
                Enabled=false,
            };
            animateToolStripMenuItem.Click += new EventHandler(AnimateMenuItemClick);

            aboutToolStripMenuItem = new ToolStripMenuItem()
            {
                Text = "About",
            };
            aboutToolStripMenuItem.Click+= new EventHandler(AboutMenuItemClick);

            exitToolStripMenuItem = new ToolStripMenuItem()
            {
                Text = "Exit"
            };
            exitToolStripMenuItem.Click += new EventHandler(ExitMenuItemClick);


            menuStrip = new MenuStrip()
            {
                Name = "Menu",
                TabIndex=0,
            };
            menuStrip.Items.AddRange(new ToolStripMenuItem[] {fileToolStripMenuItem, animateToolStripMenuItem,
                aboutToolStripMenuItem, exitToolStripMenuItem});

            
            components = new Container();
            AutoScaleMode = AutoScaleMode.Font;
            Text = "Воронин ИВТ-19-1 4В";
            SizeChanged+=new EventHandler((sender,e)=>chart.Size=Size);
            MinimumSize = new Size (800,800);
            Controls.AddRange(new Control[] {menuStrip});
        }

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem animateToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}

