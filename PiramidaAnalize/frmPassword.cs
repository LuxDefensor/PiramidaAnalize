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
    public partial class frmPassword : Form
    {
        public frmPassword()
        {
            InitializeComponent();
        }

        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
        }

        public string Login
        {
            get
            {
                return txtLogin.Text;
            }
        }
    }
}
