using System.Windows.Forms;

namespace MARSH
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string text)
        {
            InitializeComponent();
            errorLabel.Text = text;
        }
    }
}
