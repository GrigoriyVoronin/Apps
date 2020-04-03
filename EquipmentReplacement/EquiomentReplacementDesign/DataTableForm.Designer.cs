using System.Drawing;
using System.Windows.Forms;
using EquiomentReplacementDesign;
namespace EquiomentReplacementDesign
{
    partial class DataTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent(int size)
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = size;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 200);
            AddLabelWithText(0, "Текущий год");
            AddLabelWithText(1, "Доход от продажи");
            AddLabelWithText(2, "Доход от использования");
            AddLabelWithText(3, "Затраты на обсуживание");
            InitFirstRow(size);
            InitTextBoxs(size);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(350, 250);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100,100);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Вычислить";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.Button2_Click);
            // 
            // DataTableForm
            // 

            this.ClientSize = new System.Drawing.Size(800, 400);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.buttonStart);
            this.Name = "DataTableForm";
            this.Text = "Таблица данных";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AddLabelWithText(int row, string text)
        {
            var label = new Label();
            var sized = new Size();
            sized.Height = 50;
            sized.Width = 150;
            label.Size = sized;
            label.Text = text;
            this.tableLayoutPanel1.Controls.Add(label, 0, row);
        }

        private void InitFirstRow(int size)
        {
            for (int i = 1; i < size; i++)
            {
                var label = new Label();
                var sized = new Size();
                sized.Height = 50;
                sized.Width = 50;
                label.Size = sized;
                label.Text = (i-1).ToString();
                this.tableLayoutPanel1.Controls.Add(label, i, 0);
            }
        }
        private void InitTextBoxs(int size)
        {
        for(int j=1; j<4; j++)
            for (int i = 1; i < size; i++)
            {
                var maskedTextBox = new MaskedTextBox();
                    var sized = new Size();
                    sized.Height = 50;
                    sized.Width = 50;
                    maskedTextBox.Size = sized;
                    maskedTextBox.Mask = "000000000";
                maskedTextBox.ValidatingType = typeof(int);
                maskedTextBox.HidePromptOnLeave = true;
                this.tableLayoutPanel1.Controls.Add(maskedTextBox, i, j);
            }
        }
        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button buttonStart;
    }
}