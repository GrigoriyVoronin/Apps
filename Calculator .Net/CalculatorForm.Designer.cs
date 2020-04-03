using System;
using System.Globalization;
using System.Windows.Forms;

namespace Calculator.Net
{
    partial class CalculatorForm
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
            this.sign = new System.Windows.Forms.Button();
            this.zero = new System.Windows.Forms.Button();
            this.delimeter = new System.Windows.Forms.Button();
            this.calculate = new System.Windows.Forms.Button();
            this.one = new System.Windows.Forms.Button();
            this.two = new System.Windows.Forms.Button();
            this.three = new System.Windows.Forms.Button();
            this.plus = new System.Windows.Forms.Button();
            this.four = new System.Windows.Forms.Button();
            this.five = new System.Windows.Forms.Button();
            this.six = new System.Windows.Forms.Button();
            this.minus = new System.Windows.Forms.Button();
            this.seven = new System.Windows.Forms.Button();
            this.eight = new System.Windows.Forms.Button();
            this.nine = new System.Windows.Forms.Button();
            this.multiply = new System.Windows.Forms.Button();
            this.sqrt = new System.Windows.Forms.Button();
            this.clean = new System.Windows.Forms.Button();
            this.backspace = new System.Windows.Forms.Button();
            this.division = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // sign
            // 
            this.sign.Location = new System.Drawing.Point(12, 154);
            this.sign.Name = "sign";
            this.sign.Size = new System.Drawing.Size(75, 23);
            this.sign.TabIndex = 0;
            this.sign.Text = "+/-";
            this.sign.UseVisualStyleBackColor = true;
            this.sign.Click += new System.EventHandler(this.sign_Click);
            // 
            // zero
            // 
            this.zero.Location = new System.Drawing.Point(94, 154);
            this.zero.Name = "zero";
            this.zero.Size = new System.Drawing.Size(75, 23);
            this.zero.TabIndex = 1;
            this.zero.Text = "0";
            this.zero.UseVisualStyleBackColor = true;
            this.zero.Click += new System.EventHandler(this.zero_Click);
            // 
            // delimeter
            // 
            this.delimeter.Location = new System.Drawing.Point(174, 154);
            this.delimeter.Name = "delimeter";
            this.delimeter.Size = new System.Drawing.Size(75, 23);
            this.delimeter.TabIndex = 2;
            this.delimeter.Text = ",";
            this.delimeter.UseVisualStyleBackColor = true;
            this.delimeter.Click += new System.EventHandler(this.delimeter_Click);
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(255, 154);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(75, 23);
            this.calculate.TabIndex = 3;
            this.calculate.Text = "=";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // one
            // 
            this.one.Location = new System.Drawing.Point(12, 125);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(75, 23);
            this.one.TabIndex = 4;
            this.one.Text = "1";
            this.one.UseVisualStyleBackColor = true;
            this.one.Click += new System.EventHandler(this.one_Click);
            // 
            // two
            // 
            this.two.Location = new System.Drawing.Point(93, 125);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(75, 23);
            this.two.TabIndex = 5;
            this.two.Text = "2";
            this.two.UseVisualStyleBackColor = true;
            this.two.Click += new System.EventHandler(this.two_Click);
            // 
            // three
            // 
            this.three.Location = new System.Drawing.Point(174, 125);
            this.three.Name = "three";
            this.three.Size = new System.Drawing.Size(75, 23);
            this.three.TabIndex = 6;
            this.three.Text = "3";
            this.three.UseVisualStyleBackColor = true;
            this.three.Click += new System.EventHandler(this.three_Click);
            // 
            // plus
            // 
            this.plus.Location = new System.Drawing.Point(255, 125);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(75, 23);
            this.plus.TabIndex = 7;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.Click += new System.EventHandler(this.plus_Click);
            // 
            // four
            // 
            this.four.Location = new System.Drawing.Point(12, 96);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(75, 23);
            this.four.TabIndex = 8;
            this.four.Text = "4";
            this.four.UseVisualStyleBackColor = true;
            this.four.Click += new System.EventHandler(this.four_Click);
            // 
            // five
            // 
            this.five.Location = new System.Drawing.Point(94, 96);
            this.five.Name = "five";
            this.five.Size = new System.Drawing.Size(75, 23);
            this.five.TabIndex = 9;
            this.five.Text = "5";
            this.five.UseVisualStyleBackColor = true;
            this.five.Click += new System.EventHandler(this.five_Click);
            // 
            // six
            // 
            this.six.Location = new System.Drawing.Point(174, 96);
            this.six.Name = "six";
            this.six.Size = new System.Drawing.Size(75, 23);
            this.six.TabIndex = 10;
            this.six.Text = "6";
            this.six.UseVisualStyleBackColor = true;
            this.six.Click += new System.EventHandler(this.six_Click);
            // 
            // minus
            // 
            this.minus.Location = new System.Drawing.Point(255, 96);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(75, 23);
            this.minus.TabIndex = 11;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.Click += new System.EventHandler(this.minus_Click);
            // 
            // seven
            // 
            this.seven.Location = new System.Drawing.Point(12, 67);
            this.seven.Name = "seven";
            this.seven.Size = new System.Drawing.Size(75, 23);
            this.seven.TabIndex = 12;
            this.seven.Text = "7";
            this.seven.UseVisualStyleBackColor = true;
            this.seven.Click += new System.EventHandler(this.seven_Click);
            // 
            // eight
            // 
            this.eight.Location = new System.Drawing.Point(94, 67);
            this.eight.Name = "eight";
            this.eight.Size = new System.Drawing.Size(75, 23);
            this.eight.TabIndex = 13;
            this.eight.Text = "8";
            this.eight.UseVisualStyleBackColor = true;
            this.eight.Click += new System.EventHandler(this.eight_Click);
            // 
            // nine
            // 
            this.nine.Location = new System.Drawing.Point(174, 67);
            this.nine.Name = "nine";
            this.nine.Size = new System.Drawing.Size(75, 23);
            this.nine.TabIndex = 14;
            this.nine.Text = "9";
            this.nine.UseVisualStyleBackColor = true;
            this.nine.Click += new System.EventHandler(this.nine_Click);
            // 
            // multiply
            // 
            this.multiply.Location = new System.Drawing.Point(255, 67);
            this.multiply.Name = "multiply";
            this.multiply.Size = new System.Drawing.Size(75, 23);
            this.multiply.TabIndex = 15;
            this.multiply.Text = "*";
            this.multiply.UseVisualStyleBackColor = true;
            this.multiply.Click += new System.EventHandler(this.multiply_Click);
            // 
            // sqrt
            // 
            this.sqrt.Location = new System.Drawing.Point(12, 38);
            this.sqrt.Name = "sqrt";
            this.sqrt.Size = new System.Drawing.Size(75, 23);
            this.sqrt.TabIndex = 16;
            this.sqrt.Text = "sqrt";
            this.sqrt.UseVisualStyleBackColor = true;
            this.sqrt.Click += new System.EventHandler(this.Sqrt_Click);
            // 
            // clean
            // 
            this.clean.Location = new System.Drawing.Point(94, 38);
            this.clean.Name = "clean";
            this.clean.Size = new System.Drawing.Size(75, 23);
            this.clean.TabIndex = 17;
            this.clean.Text = "C";
            this.clean.UseVisualStyleBackColor = true;
            this.clean.Click += new System.EventHandler(this.clean_Click);
            // 
            // backspace
            // 
            this.backspace.Location = new System.Drawing.Point(174, 38);
            this.backspace.Name = "backspace";
            this.backspace.Size = new System.Drawing.Size(75, 23);
            this.backspace.TabIndex = 18;
            this.backspace.Text = "⇦";
            this.backspace.UseVisualStyleBackColor = true;
            this.backspace.Click += new System.EventHandler(this.backspace_Click);
            // 
            // division
            // 
            this.division.Location = new System.Drawing.Point(255, 38);
            this.division.Name = "division";
            this.division.Size = new System.Drawing.Size(75, 23);
            this.division.TabIndex = 19;
            this.division.Text = "/";
            this.division.UseVisualStyleBackColor = true;
            this.division.Click += new System.EventHandler(this.division_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(12, 12);
            this.textBox.MaxLength = 16;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(318, 20);
            this.textBox.TabIndex = 20;
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 191);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.division);
            this.Controls.Add(this.backspace);
            this.Controls.Add(this.clean);
            this.Controls.Add(this.sqrt);
            this.Controls.Add(this.multiply);
            this.Controls.Add(this.nine);
            this.Controls.Add(this.eight);
            this.Controls.Add(this.seven);
            this.Controls.Add(this.minus);
            this.Controls.Add(this.six);
            this.Controls.Add(this.five);
            this.Controls.Add(this.four);
            this.Controls.Add(this.plus);
            this.Controls.Add(this.three);
            this.Controls.Add(this.two);
            this.Controls.Add(this.one);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.delimeter);
            this.Controls.Add(this.zero);
            this.Controls.Add(this.sign);
            this.Name = "CalculatorForm";
            this.RightToLeftLayout = true;
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sign;
        private System.Windows.Forms.Button zero;
        private System.Windows.Forms.Button delimeter;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.Button one;
        private System.Windows.Forms.Button two;
        private System.Windows.Forms.Button three;
        private System.Windows.Forms.Button plus;
        private System.Windows.Forms.Button four;
        private System.Windows.Forms.Button five;
        private System.Windows.Forms.Button six;
        private System.Windows.Forms.Button minus;
        private System.Windows.Forms.Button seven;
        private System.Windows.Forms.Button eight;
        private System.Windows.Forms.Button nine;
        private System.Windows.Forms.Button multiply;
        private System.Windows.Forms.Button sqrt;
        private System.Windows.Forms.Button clean;
        private System.Windows.Forms.Button backspace;
        private System.Windows.Forms.Button division;
        private TextBox textBox;
    }
}

