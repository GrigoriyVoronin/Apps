using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MARSH
{
    partial class SearchForm
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
            this.startTextBox = new TextBox()
            {
                Location = new Point(12, 52),
                Name = "startTextBox",
                Size = new Size(100, 20),
                TabIndex = 0,
            };

            this.endTextBox = new TextBox()
            {
                Location = new Point(188, 52),
                Name = "endTextBox",
                Size = new Size(100, 20),
                TabIndex = 1,
            };

            this.startLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(46, 20),
                Name = "startLabel",
                Size = new Size(35, 13),
                TabIndex = 2,
                Text = "startLabel",
            };

            this.endLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(215, 20),
                Name = "endLabel",
                Size = new Size(35, 13),
                TabIndex = 3,
                Text = "endLabel",
            };

            this.searchButton = new Button()
            {
                Location = new Point(115, 97),
                Name = "searchButton",
                Size = new Size(75, 23),
                TabIndex = 4,
                Text = "Поиск",
                UseVisualStyleBackColor = true,
            };
            this.searchButton.Click += new EventHandler(this.SearchButtonClick);

            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(325, 138);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.endLabel);
            this.Controls.Add(this.startLabel);
            this.Controls.Add(this.endTextBox);
            this.Controls.Add(this.startTextBox);
            this.Name = "SearchForm";
            this.Text = "Поиск маршрутов";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox startTextBox;
        private TextBox endTextBox;
        private Label startLabel;
        private Label endLabel;
        private Button searchButton;
    }
}