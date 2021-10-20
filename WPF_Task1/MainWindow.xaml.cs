using System.Windows;
using System.Windows.Controls;

namespace WPF_Task1
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string leftOperand = "";
        private string operation = "";
        private string rightOperand = "";

        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement button in LayoutRoot.Children)
                if (button is Button currentButton)
                    currentButton.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var s = (string) ((Button) e.OriginalSource).Content;
            textBlock.Text += s;
            var result = int.TryParse(s, out var num);
            if (result)
            {
                if (operation == "")
                    leftOperand += s;
                else
                    rightOperand += s;
            }
            else
            {
                if (s == "=")
                {
                    Update_RightOp();
                    textBlock.Text += rightOperand;
                    operation = "";
                }
                else if (s == "CLEAR")
                {
                    leftOperand = "";
                    rightOperand = "";
                    operation = "";
                    textBlock.Text = "";
                }
                else
                {
                    if (rightOperand != "")
                    {
                        Update_RightOp();
                        leftOperand = rightOperand;
                        rightOperand = "";
                    }

                    operation = s;
                }
            }
        }

        private void Update_RightOp()
        {
            var num1 = int.Parse(leftOperand);
            var num2 = int.Parse(rightOperand);
            switch (operation)
            {
                case "+":
                    rightOperand = (num1 + num2).ToString();
                    break;
                case "-":
                    rightOperand = (num1 - num2).ToString();
                    break;
                case "*":
                    rightOperand = (num1 * num2).ToString();
                    break;
                case "/":
                    rightOperand = (num1 / num2).ToString();
                    break;
            }
        }
    }
}