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
    public partial class FormResult : Form
    {
        public FormResult(int profit,List<int> yersWhenChange)
        {
            InitializeComponent(profit,yersWhenChange);
        }
    }
}
