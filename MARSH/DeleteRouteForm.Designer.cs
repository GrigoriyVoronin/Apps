using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MARSH
{
    partial class DeleteRouteForm
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
            this.numberOfRouteLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(110, 20),
                Name = "numberOfRouteLabel",
                Size = new Size(80, 20),
                TabIndex = 0,
                Text = "Номер маршрута",
            };

            this.deleteButton = new Button()
            {
                Location = new Point(115, 80),
                Name = "deleteButton",
                Size = new Size(75, 23),
                TabIndex = 1,
                Text = "Удалить",
                UseVisualStyleBackColor = true,
            };
            deleteButton.Click += new EventHandler(this.DeleteButtonClick);

            this.numberOfRouteTextBox = new TextBox()
            {
                Location = new Point(115, 50),
                Name = "numberOfRouteTextBox",
                Size = new Size(80, 20),
                TabIndex = 2,
            };
            numberOfRouteTextBox.TextChanged += new EventHandler(this.NumberOfRouteTextBoxTextChanged);
            this.SuspendLayout();

            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 150);
            this.Controls.Add(this.numberOfRouteTextBox);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.numberOfRouteLabel);
            this.Name = "DeleteRouteForm";
            this.Text = "Удаление маршрута";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label numberOfRouteLabel;
        private Button deleteButton;
        private TextBox numberOfRouteTextBox;
    }
}