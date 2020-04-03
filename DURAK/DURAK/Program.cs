using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DURAK
{
    class Program
    {
        static void Main()
        {
            var durakForm = new TableForm();
            Application.Run(durakForm);
            durakForm.Dispose();
        }
    }
}
