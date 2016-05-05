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
    public partial class frmTestColors : Form
    {
        private MainForm parent;
        
        public frmTestColors()
        {
            InitializeComponent();
            
        }

        private void frmTest_Load(object sender, EventArgs e)
        {
            parent = (MainForm)(this.MdiParent);
            int cr = 0;
            foreach (var c in Enum.GetNames(typeof(System.Drawing.KnownColor)))
            {
                dgv1.Rows.Add(c);
                dgv1[1, cr].Style.BackColor = System.Drawing.Color.FromKnownColor((System.Drawing.KnownColor)Enum.Parse(typeof(System.Drawing.KnownColor), c));
                cr++;
            }
            parent.Cursor = Cursors.Default;
        }
    }
}
