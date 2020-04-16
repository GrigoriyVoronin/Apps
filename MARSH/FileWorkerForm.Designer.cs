using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MARSH
{
    partial class FileWorkerForm
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
            this.pathLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(125, 10),
                Name = "pathLabel",
                Size = new Size(50, 15),
                TabIndex = 0,
                Text = "Путь к файлу",
            };

            this.pathTextBox = new TextBox()
            {
                Location = new Point(100, 25),
                Name = "pathTextBox",
                Size = new Size(100, 20),
                TabIndex = 1,
            };

            this.writeButton = new Button()
            {
                Location = new Point(20, 50),
                Name = "writeButton",
                Size = new Size(120, 20),
                TabIndex = 2,
                Text = "Записать в файл",
                UseVisualStyleBackColor = true,
            };
            this.writeButton.Click += new EventHandler(this.WriteButtonClick);

            this.readButton = new Button()
            {
                Location = new Point(150, 50),
                Name = "readButton",
                Size = new System.Drawing.Size(120, 20),
                TabIndex = 3,
                Text = "Прочитать из файла",
                UseVisualStyleBackColor = true,
            };
            this.readButton.Click += new EventHandler(this.ReadButtonClick);

            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(5F, 10F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 100);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.pathLabel);
            this.Name = "FileWorkerForm";
            this.Text = "Файл";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label pathLabel;
        private TextBox pathTextBox;
        private Button writeButton;
        private Button readButton;
    }
}