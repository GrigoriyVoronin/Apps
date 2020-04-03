using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EquiomentReplacementDesign
{
    public partial class DataTableForm : Form
    {
        private static int _duration;
        private static int _initialAge;
        private static int _costNew;
        public DataTableForm(int size,int initialAge, int costNew)
        {
            _duration =size;
            _initialAge = initialAge;
            _costNew = costNew;
            InitializeComponent(size+2);
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            int[] revenueFromEquipment = new int[_duration+1];
            int[] equipmentMaintenanceCost = new int[_duration + 1];
            int[] sellingPrice = new int[_duration + 1];
            try
            {
                for (int i = 1; i < _duration + 2; i++)
                {
                    revenueFromEquipment[i - 1] = int.Parse(tableLayoutPanel1.GetControlFromPosition(i, 2).Text);
                    equipmentMaintenanceCost[i - 1] = int.Parse(tableLayoutPanel1.GetControlFromPosition(i, 3).Text);
                    sellingPrice[i - 1] = int.Parse(tableLayoutPanel1.GetControlFromPosition(i, 1).Text);
                }

                var (profit, yearsWhenChange) = EquipmentReplacementLogic.EquipmentReplacementLogic.Run(revenueFromEquipment, equipmentMaintenanceCost,
                    sellingPrice, _duration + 1, _costNew, _initialAge);
                FormResult resultForm = new FormResult(profit, yearsWhenChange);
                resultForm.Show();
            }
            catch
            {
                ErorForm erorForm = new ErorForm();
                erorForm.Show();
            }
        }
    }
}
