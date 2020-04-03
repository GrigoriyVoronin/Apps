using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator.Net
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
            KeyPreview = true;
            KeyPress += CalculatorForm_KeyPress;
        }

        private void CalculatorForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '1')
                AddChar(one.Text);
            else if (e.KeyChar == '2')
                AddChar(two.Text);
            else if (e.KeyChar == '3')
                AddChar(three.Text);
            else if (e.KeyChar == '4')
                AddChar(four.Text);
            else if (e.KeyChar == '5')
                AddChar(five.Text);
            else if (e.KeyChar == '6')
                AddChar(six.Text);
            else if (e.KeyChar == '7')
                AddChar(seven.Text);
            else if (e.KeyChar == '8')
                AddChar(eight.Text);
            else if (e.KeyChar == '9')
                AddChar(nine.Text);
            else if (e.KeyChar == '0')
                AddChar(zero.Text);
            else if (e.KeyChar == '+')
                AddSpecChar(plus.Text);
            else if (e.KeyChar == '-')
                AddSpecChar(minus.Text);
            else if (e.KeyChar == '/')
                AddSpecChar(division.Text);
            else if (e.KeyChar == '*')
                AddSpecChar(multiply.Text);
            else if (e.KeyChar == '.')
                AddDelimeter();
            else if (e.KeyChar == '=')
                Calculate();
            else if (e.KeyChar== (char)Keys.Back && textBox.TextLength > 0)
                    textBox.Text = textBox.Text.Substring(0, textBox.TextLength - 1);
            else if (e.KeyChar == (char)Keys.Escape)
                    textBox.Text = "";
        }

        private readonly char[] Signs = {'*','-','+','/'};

        private void Sqrt_Click(object sender, EventArgs e)
        {
            Calculate();
            if (textBox.TextLength > 0 && textBox.Text[0] == '-')
                return;
            if(textBox.TextLength>0)
                textBox.Text = Math.Sqrt(double.Parse(textBox.Text)).ToString();
        }

        private void clean_Click(object sender, EventArgs e)
        {
            textBox.Text = "";
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (textBox.TextLength>0)
                textBox.Text = textBox.Text.Substring(0, textBox.TextLength-1);
        }

        private void division_Click(object sender, EventArgs e)
        {
            AddSpecChar(division.Text);
        }

        private void seven_Click(object sender, EventArgs e)
        {
            AddChar(seven.Text);
        }

        private void eight_Click(object sender, EventArgs e)
        {
            AddChar(eight.Text);
        }

        private void nine_Click(object sender, EventArgs e)
        {
            AddChar(nine.Text);
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            AddSpecChar(multiply.Text);
        }

        private void four_Click(object sender, EventArgs e)
        {
            AddChar(four.Text);
        }

        private void five_Click(object sender, EventArgs e)
        {
            AddChar(five.Text);
        }

        private void six_Click(object sender, EventArgs e)
        {
            AddChar(six.Text);
        }

        private void one_Click(object sender, EventArgs e)
        {
            AddChar(one.Text);
        }

        private void two_Click(object sender, EventArgs e)
        {
            AddChar(two.Text);
        }

        private void three_Click(object sender, EventArgs e)
        {
            AddChar(three.Text);
        }

        private void minus_Click(object sender, EventArgs e)
        {
            AddSpecChar(minus.Text);
        }

        private void plus_Click(object sender, EventArgs e)
        {
            AddSpecChar(plus.Text);
        }

        private void sign_Click(object sender, EventArgs e)
        {
            AddSign();
        }

        private void zero_Click(object sender, EventArgs e)
        {
            AddChar(zero.Text);
        }

        private void delimeter_Click(object sender, EventArgs e)
        {
            AddDelimeter();
        }

        private void calculate_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            var numbers = textBox.Text.Split(Signs,StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length == 1 || numbers.Length==0)  
                return;
            var doubleNumbers = new double[2];
            var sign = ' ';
            if (textBox.Text[0] == '-')
            {
                doubleNumbers[0] = -double.Parse(numbers[0]);
                sign = textBox.Text[numbers[0].Length + 1];
            }
            else
            {
                doubleNumbers[0] = double.Parse(numbers[0]);
                sign = textBox.Text[numbers[0].Length];
            }
                
            doubleNumbers[1] = double.Parse(numbers[1]);
            CalculateResult(doubleNumbers, sign);
        }

        private void CalculateResult(double[] doubleNumbers, char sign)
        {
            switch (sign)
            {
                case '-':
                    textBox.Text = (doubleNumbers[0] - doubleNumbers[1]).ToString();
                    break;
                case '+':
                    textBox.Text = (doubleNumbers[0] + doubleNumbers[1]).ToString();
                    break;
                case '/':
                    if (doubleNumbers[1] == 0)
                        textBox.Text = "";
                    else
                        textBox.Text = (doubleNumbers[0] / doubleNumbers[1]).ToString();
                    break;
                case '*':
                    textBox.Text = (doubleNumbers[0] * doubleNumbers[1]).ToString();
                    break;
            }
        }


        private void AddChar(string str)
        {
            var numbers = textBox.Text.Split(Signs, StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length == 1)
            {
                if (numbers[0].Length < 11)
                    textBox.Text = textBox.Text + str;
            }
            if (numbers.Length == 2)
            {
                if(numbers[1].Length<11)
                    textBox.Text = textBox.Text + str;
            }
            if (numbers.Length == 0)
            {
                if (textBox.TextLength < 11)
                    textBox.Text = textBox.Text + str;
            }
                
        }

        private void AddSign()
        {
            var text = textBox.Text;
            if (text.Length>0 && text[0] == '-')
                textBox.Text = text.Substring(1);
            else
            {
                textBox.Text = "-" + text;
            }
        }

        private void AddSpecChar(string specChar)
        {
            var text = textBox.Text;
            if (textBox.TextLength > 0)
            {
                if (text[0]=='-' && text.Length>1)
                    if (IsContainAnySign(text.Substring(1)))
                        Calculate();
                    else
                        AddChar(specChar);
                else if (text.Length>0)
                    if (IsContainAnySign(text))
                        Calculate();
                    else
                        AddChar(specChar);
            } 
        }

        private bool IsContainAnySign(string text)
        {
            for (int i = 0; i < Signs.Length; i++)
            {
                if (text.Contains(Signs[i]))
                {
                    return true;
                }
            }

            return false;
        }

        private void AddDelimeter()
        {
            var numbers = textBox.Text.Split(Signs, StringSplitOptions.RemoveEmptyEntries);
            if (numbers.Length>1)
                if (!numbers[1].Contains(delimeter.Text)&&numbers[1].Length>0)
                    AddChar(delimeter.Text);
            if (numbers.Length==1)
                if (!numbers[0].Contains(delimeter.Text))
                    AddChar(delimeter.Text);
        }
    }
}
