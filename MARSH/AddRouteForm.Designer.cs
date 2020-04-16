using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MARSH
{
    partial class AddRouteForm
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
            this.numberOfRouteTextBox = new TextBox()
            {
                Location = new Point(12, 25),
                Name = "numberOfRouteTextBox",
                Size = new Size(100, 20),
                TabIndex = 0,
            };
            numberOfRouteTextBox.TextChanged += new EventHandler(this.NumberOfRouteTextBoxTextChanged);

            this.startNameTextBox = new TextBox()
            {
                Location = new Point(118, 25),
                Name = "startNameTextBox",
                Size = new Size(100, 20),
                TabIndex = 1,
            };
            startNameTextBox.TextChanged += new EventHandler(this.StartNameTextBoxTextChanged);

            this.endNameTextBox = new TextBox()
            {
                Location = new Point(224, 25),
                Name = "endNameTextBox",
                Size = new Size(100, 20),
                TabIndex = 2,
            };
            endNameTextBox.TextChanged += new EventHandler(this.EndNameTextBoxTextChanged);

            this.numberOfRouteLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(9, 9),
                Name = "numberOfRouteLabel",
                Size = new Size(108, 13),
                TabIndex = 3,
                Text = "Номер маршрута",
            };

            this.startNameLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(115, 9),
                Name = "startNameLabel",
                Size = new Size(81, 13),
                TabIndex = 4,
                Text = "Точка отправления",
            };

            this.endNamwLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(221, 9),
                Name = "endNamwLabel",
                Size = new Size(81, 13),
                TabIndex = 5,
                Text = "Конечная точка",
            };
            this.addButton = new Button()
            {
                Location = new Point(130, 63),
                Name = "addButton",
                Size = new Size(75, 23),
                TabIndex = 6,
                Text = "Добавить",
                UseVisualStyleBackColor = true,
                Enabled = false,
            };
            addButton.Click += new EventHandler(this.AddButtonClick);

            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(348, 101);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.endNamwLabel);
            this.Controls.Add(this.startNameLabel);
            this.Controls.Add(this.numberOfRouteLabel);
            this.Controls.Add(this.endNameTextBox);
            this.Controls.Add(this.startNameTextBox);
            this.Controls.Add(this.numberOfRouteTextBox);
            this.Name = "AddRouteForm";
            this.Text = "Добавление нового маршрута";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private TextBox numberOfRouteTextBox;
        private TextBox startNameTextBox;
        private TextBox endNameTextBox;
        private Label numberOfRouteLabel;
        private Label startNameLabel;
        private Label endNamwLabel;
        private Button addButton;
    }
}