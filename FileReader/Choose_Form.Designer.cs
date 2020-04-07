using System;

namespace FileReader
{
    partial class Choose_Form
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
        private void InitializeComponent(string name, string firstButton, string secondButton, string thirdButton, string fouthButton)
        {
            this.label = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.otherName_textBox = new System.Windows.Forms.TextBox();
            this.other_radioButton = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.ok_button = new System.Windows.Forms.Button();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(85, 10);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(44, 13);
            this.label.TabIndex = 0;
            this.label.Text = name;
            // 
            // panel
            // 
            this.panel.Controls.Add(this.otherName_textBox);
            this.panel.Controls.Add(this.other_radioButton);
            this.panel.Controls.Add(this.radioButton1);
            this.panel.Controls.Add(this.radioButton2);
            this.panel.Controls.Add(this.radioButton3);
            this.panel.Controls.Add(this.radioButton4);
            this.panel.Location = new System.Drawing.Point(1, 36);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(214, 98);
            this.panel.TabIndex = 1;
            // 
            // otherName_textBox
            // 
            this.otherName_textBox.Enabled = false;
            this.otherName_textBox.Location = new System.Drawing.Point(106, 60);
            this.otherName_textBox.Name = "otherName_textBox";
            this.otherName_textBox.Size = new System.Drawing.Size(85, 20);
            this.otherName_textBox.TabIndex = 5;
            // 
            // other_radioButton
            // 
            this.other_radioButton.AutoSize = true;
            this.other_radioButton.Location = new System.Drawing.Point(11, 63);
            this.other_radioButton.Name = "other_radioButton";
            this.other_radioButton.Size = new System.Drawing.Size(51, 17);
            this.other_radioButton.TabIndex = 4;
            this.other_radioButton.TabStop = true;
            this.other_radioButton.Text = "Other";
            this.other_radioButton.UseVisualStyleBackColor = true;
            this.other_radioButton.CheckedChanged += new System.EventHandler(this.other_radioButton_chekedChange);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(106, 37);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(94, 17);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = firstButton;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(11, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = secondButton;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(106, 17);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(45, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = thirdButton;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(11, 17);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(47, 17);
            this.radioButton4.TabIndex = 0;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = fouthButton;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // ok_button
            // 
            this.ok_button.Location = new System.Drawing.Point(88, 165);
            this.ok_button.Name = "ok_button";
            this.ok_button.Size = new System.Drawing.Size(41, 23);
            this.ok_button.TabIndex = 2;
            this.ok_button.Text = "Ok";
            this.ok_button.UseVisualStyleBackColor = true;
            this.ok_button.Click += new System.EventHandler(this.ok_button_Click);
            // 
            // Choose_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 200);
            this.Controls.Add(this.ok_button);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label);
            this.Name = "Choose_Form";
            this.Text = "Choose_Form";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void other_radioButton_chekedChange(object sender, EventArgs e)
        {
            if (this.other_radioButton.Checked)
                this.otherName_textBox.Enabled = true;
            else
                this.otherName_textBox.Enabled = false;
        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox otherName_textBox;
        private System.Windows.Forms.RadioButton other_radioButton;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button ok_button;
    }
}