/*
 * Created by SharpDevelop.
 * User: smke-ing3
 * Date: 04.03.2016
 * Time: 8:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PiramidaAnalize
{
	/// <summary>
	/// Description of frmAbout.
	/// </summary>
	public partial class frmAbout : Form
	{
		public frmAbout()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            this.Load += FrmAbout_Load;
		}

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            txtVersion.Text = "v." + Application.ProductVersion.ToString();
        }
    }
}
