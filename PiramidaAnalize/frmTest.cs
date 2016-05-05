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
            toolStripProgressBar1.ProgressBar.PerformStep();
            if (toolStripProgressBar1.Value == 200)
                toolStripProgressBar1.Value = 0;

        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            parent = (MainForm)this.MdiParent;
            parent.Cursor = Cursors.Default;

        }
    }
}
