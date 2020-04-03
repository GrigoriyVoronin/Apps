namespace EquiomentReplacementDesign
{
    partial class ErorForm
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
            this.labelErorMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelErorMessage
            // 
            this.labelErorMessage.Location = new System.Drawing.Point(60, 80);
            this.labelErorMessage.Name = "labelErorMessage";
            this.labelErorMessage.Size = new System.Drawing.Size(250, 50);
            this.labelErorMessage.TabIndex = 0;
            this.labelErorMessage.Text = "Введи корректные данные!";
            // 
            // ErorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 213);
            this.Controls.Add(this.labelErorMessage);
            this.Name = "ErorForm";
            this.Text = "Неверный формат данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelErorMessage;
    }
}