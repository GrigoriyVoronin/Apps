using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EquipmentReplacementLogic;

namespace EquiomentReplacementDesign
{
    public partial class EquipmnetReplacementForm : Form
    {
        public EquipmnetReplacementForm()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                var size = int.Parse(maskedTextBoxDuration.Text.Trim());
                var initialAge = int.Parse(maskedTextBoxInitialAge.Text.Trim());
                var newCost = int.Parse(maskedTextBoxNewCost.Text.Trim());
                if (size < 1 || newCost < 1)
                    throw new Exception();
                if (initialAge >= size)
                    initialAge = size;
                DataTableForm dataTable = new DataTableForm(size, initialAge, newCost);
                dataTable.Show();
            }
            catch 
            {
                ErorForm erorForm = new ErorForm();
                erorForm.Show();
            }
        }
    }
}
