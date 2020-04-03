using System.Collections.Generic;
using System.Linq;

namespace EquiomentReplacementDesign
{
    partial class FormResult
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
        private void InitializeComponent(int profit, List<int> yearsWhenChange)
        {
            this.labelProfit = new System.Windows.Forms.Label();
            this.labelYears = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelProfit
            // 
            this.labelProfit.AutoSize = true;
            this.labelProfit.Location = new System.Drawing.Point(30, 70);
            this.labelProfit.Name = "labelProfit";
            this.labelProfit.Size = new System.Drawing.Size(50, 50);
            this.labelProfit.TabIndex = 0;
            this.labelProfit.Text = string.Format("Максимально возможная прибыль за выбранный период составит: {0}",profit);
            //
            // labelYears
            //
            this.labelYears.AutoSize = true;
            this.labelYears.Location = new System.Drawing.Point(30, 130);
            this.labelYears.Name = "labelYers";
            this.labelYears.Size = new System.Drawing.Size(50, 50);
            this.labelYears.TabIndex = 1;
            var years = string.Join(", ", yearsWhenChange);
            years = years.Equals("")
                ? "Заменять оборудовнаие в данный период не нужно"
                : string.Format("Года в которые нужно заменить оборудование {0}", years);
            this.labelYears.Text = years;
            // 
            // FormResult
            // 
            this.ClientSize = new System.Drawing.Size(600, 200);
            this.Controls.Add(this.labelProfit);
            this.Controls.Add(this.labelYears);
            this.Name = "FormResult";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProfit;
        private System.Windows.Forms.Label labelYears;
    }
}