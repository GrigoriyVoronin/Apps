using System;
using System.Linq;
using System.Windows.Forms;

namespace MARSH
{
    public partial class AddRouteForm : Form
    {
        public AddRouteForm()
        {
            InitializeComponent();
        }

        private void AddButtonClick(object sender, EventArgs e)
        {
            var owner = (StartForm) Owner;
            var routeNumb = int.Parse(numberOfRouteTextBox.Text);
            if (owner.Routes.Select(x => x.NumberOfRoute).Contains(routeNumb))
            {
                new ErrorForm("Такой маршрут уже существует!").ShowDialog(this);
                return;
            }

            owner.AddRowInTable(new Route(routeNumb, startNameTextBox.Text, endNameTextBox.Text));
        }

        private void NumberOfRouteTextBoxTextChanged(object sender, EventArgs e)
        {
            var text = (TextBox) sender;
            text.Text = int.TryParse(text.Text, out var numb)
                ? numb.ToString()
                : text.Text.Substring(0, text.Text.Length - 1 > 0 ? text.Text.Length - 1 : 0);
            OnTextChanged();
        }

        private void StartNameTextBoxTextChanged(object sender, EventArgs e)
        {
            OnTextChanged();
        }

        private void EndNameTextBoxTextChanged(object sender, EventArgs e)
        {
            OnTextChanged();
        }

        private void OnTextChanged()
        {
            addButton.Enabled = numberOfRouteTextBox.Text.Length > 0
                                && startNameTextBox.Text.Length > 0
                                && endNameTextBox.Text.Length > 0;
        }
    }
}