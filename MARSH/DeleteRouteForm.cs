using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MARSH
{
    public partial class DeleteRouteForm : Form
    {
        public DeleteRouteForm()
        {
            InitializeComponent();
        }

        private void NumberOfRouteTextBoxTextChanged(object sender, EventArgs e)
        {
            var text = (TextBox) sender;
            text.Text = int.TryParse(text.Text, out var numb)
                ? numb.ToString()
                : text.Text.Substring(0, text.Text.Length - 1 > 0 ? text.Text.Length - 1 : 0);
            OnTextChanged();
        }

        private void OnTextChanged()
        {
            deleteButton.Enabled = numberOfRouteTextBox.Text.Length > 0;
        }

        private void DeleteButtonClick(object sender, EventArgs e)
        {
            var owner = (StartForm) Owner;
            var routeNumb = int.Parse(numberOfRouteTextBox.Text);
            if (!owner.Routes.Select(x => x.NumberOfRoute).Contains(routeNumb))
            {
                new ErrorForm("Такого маршрута не существует!").ShowDialog(this);
                return;
            }

            owner.DeleteRowFromTable(routeNumb);
        }
    }
}
