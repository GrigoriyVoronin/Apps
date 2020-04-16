using System;
using System.Windows.Forms;

namespace FileReader
{
    public partial class Choose_Form : Form
    {
        public string ChoosedName { get; private set; }

        public Choose_Form(string name, string firstButton, string secondButton,string thirdButton, string fouthButton)
        {
            InitializeComponent(name, firstButton,secondButton,thirdButton,fouthButton);
        }

        private void Ok_button_Click(object sender, EventArgs e)
        {
            if (other_radioButton.Checked)
            {
                ChoosedName = otherName_textBox.Text;
                Dispose();
                return;
            }

            foreach (var radBut in panel.Controls)
            {
                if ((radBut is RadioButton) && ((RadioButton)radBut).Checked)
                {
                    ChoosedName = ((RadioButton)radBut).Text;
                    Dispose();
                    return;
                }
            }
        }
    }
}
