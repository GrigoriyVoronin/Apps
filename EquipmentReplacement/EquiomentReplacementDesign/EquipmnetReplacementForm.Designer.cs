using System;
using System.Drawing;
using System.Windows.Forms;

namespace EquiomentReplacementDesign
{
    partial class EquipmnetReplacementForm
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
            this.buttonStatrtCalculate = new System.Windows.Forms.Button();
            this.labelDuration = new System.Windows.Forms.Label();
            this.labelNewCost = new System.Windows.Forms.Label();
            this.maskedTextBoxDuration = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxNewCost = new System.Windows.Forms.MaskedTextBox();
            this.labelInitialAge = new System.Windows.Forms.Label();
            this.maskedTextBoxInitialAge = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // buttonStatrtCalculate
            // 
            this.buttonStatrtCalculate.Location = new System.Drawing.Point(171, 130);
            this.buttonStatrtCalculate.Name = "buttonStatrtCalculate";
            this.buttonStatrtCalculate.Size = new System.Drawing.Size(249, 72);
            this.buttonStatrtCalculate.TabIndex = 1;
            this.buttonStatrtCalculate.Text = "Заполнить оставшиеся данные";
            this.buttonStatrtCalculate.UseVisualStyleBackColor = true;
            this.buttonStatrtCalculate.Click += new System.EventHandler(this.Button2_Click);
            // 
            // labelDuration
            // 
            this.labelDuration.AutoSize = true;
            this.labelDuration.Location = new System.Drawing.Point(12, 32);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(125, 13);
            this.labelDuration.TabIndex = 2;
            this.labelDuration.Text = "Длительность периода";
            // 
            // labelNewCost
            // 
            this.labelNewCost.AutoSize = true;
            this.labelNewCost.Location = new System.Drawing.Point(199, 32);
            this.labelNewCost.Name = "labelNewCost";
            this.labelNewCost.Size = new System.Drawing.Size(145, 13);
            this.labelNewCost.TabIndex = 4;
            this.labelNewCost.Text = "Цена нового оборудования";
            // 
            // maskedTextBoxDuration
            // 
            this.maskedTextBoxDuration.HidePromptOnLeave = true;
            this.maskedTextBoxDuration.Location = new System.Drawing.Point(15, 60);
            this.maskedTextBoxDuration.Mask = "000000000";
            this.maskedTextBoxDuration.Name = "maskedTextBoxDuration";
            this.maskedTextBoxDuration.Size = new System.Drawing.Size(122, 20);
            this.maskedTextBoxDuration.TabIndex = 5;
            this.maskedTextBoxDuration.ValidatingType = typeof(int);
            // 
            // maskedTextBoxNewCost
            // 
            this.maskedTextBoxNewCost.HidePromptOnLeave = true;
            this.maskedTextBoxNewCost.Location = new System.Drawing.Point(202, 60);
            this.maskedTextBoxNewCost.Mask = "000000000";
            this.maskedTextBoxNewCost.Name = "maskedTextBoxNewCost";
            this.maskedTextBoxNewCost.Size = new System.Drawing.Size(142, 20);
            this.maskedTextBoxNewCost.TabIndex = 6;
            this.maskedTextBoxNewCost.ValidatingType = typeof(int);
            // 
            // labelInitialAge
            // 
            this.labelInitialAge.AutoSize = true;
            this.labelInitialAge.Location = new System.Drawing.Point(384, 32);
            this.labelInitialAge.Name = "labelInitialAge";
            this.labelInitialAge.Size = new System.Drawing.Size(182, 13);
            this.labelInitialAge.TabIndex = 7;
            this.labelInitialAge.Text = "Начальный возраст оборудования";
            // 
            // maskedTextBoxInitialAge
            // 
            this.maskedTextBoxInitialAge.HidePromptOnLeave = true;
            this.maskedTextBoxInitialAge.Location = new System.Drawing.Point(387, 60);
            this.maskedTextBoxInitialAge.Mask = "000000000";
            this.maskedTextBoxInitialAge.Name = "maskedTextBoxInitialAge";
            this.maskedTextBoxInitialAge.Size = new System.Drawing.Size(179, 20);
            this.maskedTextBoxInitialAge.TabIndex = 8;
            this.maskedTextBoxInitialAge.ValidatingType = typeof(int);
            // 
            // EquipmnetReplacementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 229);
            this.Controls.Add(this.maskedTextBoxInitialAge);
            this.Controls.Add(this.labelInitialAge);
            this.Controls.Add(this.maskedTextBoxNewCost);
            this.Controls.Add(this.maskedTextBoxDuration);
            this.Controls.Add(this.labelNewCost);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.buttonStatrtCalculate);
            this.Name = "EquipmnetReplacementForm";
            this.Text = "Замена оборудования";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonStatrtCalculate;
        private Label labelDuration;
        private Label labelNewCost;
        private MaskedTextBox maskedTextBoxDuration;
        private MaskedTextBox maskedTextBoxNewCost;
        private Label labelInitialAge;
        private MaskedTextBox maskedTextBoxInitialAge;
    }
}

