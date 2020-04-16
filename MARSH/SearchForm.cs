using System;
using System.Windows.Forms;

namespace MARSH
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchButtonClick(object sender, EventArgs e)
        {
            var owner = (StartForm) Owner;
            owner.FiltrateData(startTextBox.Text,endTextBox.Text);
            Dispose();
        }
    }
}
