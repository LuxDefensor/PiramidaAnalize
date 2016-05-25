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
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //TODO как это вообще должно работать?
            txtServer.DataBindings["Text"].WriteValue();
            txtDatabase.DataBindings["Text"].WriteValue();
            txtUsername.DataBindings["Text"].WriteValue();
            txtPassword.DataBindings["Text"].WriteValue();
        }
    }
}
