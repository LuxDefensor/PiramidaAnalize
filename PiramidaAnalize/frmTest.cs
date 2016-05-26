using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PiramidaAnalize
{
    public partial class frmTest: Form
    {
        private MainForm parent;
        public frmTest()
        {
            InitializeComponent();
            this.Load += FrmTest_Load;
            this.Click += FrmTest_Click;
        }

        private void FrmTest_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
            for (int i = 1; i < 256; i++)
            {
                this.listBox1.Items.Add(string.Format("{0:0000} - {1:??}", i, XLSImport.GetColumnHeader(i)));
            }
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            parent = (MainForm)this.MdiParent;
            parent.Cursor = Cursors.Default;

        }
    }
}
