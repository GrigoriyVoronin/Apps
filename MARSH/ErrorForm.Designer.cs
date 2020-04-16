using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MARSH
{
    partial class ErrorForm
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
            this.errorLabel = new Label()
            {
                AutoSize = true,
                Location = new Point(15, 10),
                Name = "ErrorLabel",
                Size = new Size(50, 15),
            };
            SuspendLayout();

            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(249, 34);
            this.Controls.Add(this.errorLabel);
            this.Name = "ErrorForm";
            this.Text = "Error";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label errorLabel;
    }
}