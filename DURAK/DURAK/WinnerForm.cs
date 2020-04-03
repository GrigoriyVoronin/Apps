using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DURAK
{
    partial class WinnerForm : Form
    {
        public WinnerForm(Player player)
        {
            InitializeComponent();
            WinnerLabel.Text = "Победил: "+player.Name;
        }
    }
}
