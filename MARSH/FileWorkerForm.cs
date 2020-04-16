using System;
using System.Linq;
using System.Windows.Forms;

namespace MARSH
{
    public partial class FileWorkerForm : Form
    {
        private FileWorker fw;

        public FileWorkerForm()
        {
            InitializeComponent();
            fw = new FileWorker();
        }

        private void WriteButtonClick(object sender, EventArgs e)
        {
            var owner = (StartForm) Owner;
            if (fw.WriteData(pathTextBox.Text, owner.Routes.Select(x => x.ToString()).ToArray()))
                Dispose();

            new ErrorForm("Произошла ошибка во время записи").ShowDialog(this);
        }

        private void ReadButtonClick(object sender, EventArgs e)
        {
            var owner = (StartForm) Owner;
            var data = fw.ReadData(pathTextBox.Text);
            if (data != null)
            {
                owner.UpdateTable(data
                    .Select(x => x.Split())
                    .Select(x => new Route(int.Parse(x[0]), x[1], x[2]))
                    .ToList());
                Dispose();
                return;
            }

            new ErrorForm("Произошла ошибка во время чтения файла").ShowDialog(this);
        }
    }
}
