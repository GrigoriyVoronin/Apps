using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FileReader
{
    partial class Choose_Form
    {
        private Label label;
        private Panel panel;
        private TextBox otherName_textBox;
        private RadioButton other_radioButton;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton4;
        private Button ok_button;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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

        private void InitializeComponent(string name, string firstButton, string secondButton, string thirdButton, string fouthButton)
        {
            SuspendLayout();

            label = new Label()
            {
                AutoSize = true,
                Location = new Point(85, 10),
                Name = "label",
                Size = new Size(44, 13),
                Text = name,
            };

            otherName_textBox = new TextBox()
            {
                Enabled = false,
                Location = new Point(106, 60),
                Name = "otherName_textBox",
                Size = new Size(85, 20),
            };

            other_radioButton = new RadioButton()
            {
                AutoSize = true,
                Location = new Point(11, 63),
                Name = "other_radioButton",
                Size = new Size(51, 17),
                Text = "Other",
                UseVisualStyleBackColor = true,
            };
            other_radioButton.CheckedChanged += new EventHandler(Other_radioButton_chekedChange);

            radioButton1 = new RadioButton()
            {
                AutoSize = true,
                Location = new Point(106, 37),
                Name = "radioButton1",
                Size = new Size(94, 17),
                Text = firstButton,
                UseVisualStyleBackColor = true,
            };

            radioButton2 = new RadioButton()
            {
                AutoSize = true,
                Location = new Point(11, 40),
                Name = "radioButton2",
                Size = new Size(62, 17),
                Text = secondButton,
                UseVisualStyleBackColor = true,
            };

            radioButton3 = new RadioButton()
            {
                AutoSize = true,
                Location = new Point(106, 17),
                Name = "radioButton3",
                Size = new Size(45, 17),
                Text = thirdButton,
                UseVisualStyleBackColor = true,
            };

            radioButton4 = new RadioButton()
            {
                AutoSize = true,
                Location = new Point(11, 17),
                Name = "radioButton4",
                Size = new Size(47, 17),
                Text = fouthButton,
                UseVisualStyleBackColor = true,
            };

            panel = new Panel()
            {
                Location = new Point(1, 36),
                Name = "panel",
                Size = new Size(214, 98),
            };
            panel.Controls.AddRange(new Control[] { otherName_textBox, other_radioButton, radioButton1, radioButton2, radioButton3, radioButton4 });

            ok_button = new Button()
            {
                Location = new Point(88, 165),
                Name = "ok_button",
                Size = new Size(41, 23),
                Text = "Ok",
                UseVisualStyleBackColor = true,
            };
            ok_button.Click += new EventHandler(Ok_button_Click);

            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(234, 200);
            Controls.AddRange(new Control[] { ok_button, panel, label });
            Name = "Choose_Form";
            Text = "Choose_Form";
            ResumeLayout(false);
            PerformLayout();
        }

        private void Other_radioButton_chekedChange(object sender, EventArgs e)
        {
            if (other_radioButton.Checked)
                otherName_textBox.Enabled = true;
            else
                otherName_textBox.Enabled = false;
        }
    }
}