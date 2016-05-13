/*
 * Created by SharpDevelop.
 * User: smke-ing3
 * Date: 03.03.2016
 * Time: 15:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PiramidaAnalize
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{       
        public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		}
		
		void MnuExitClick(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		void MnuAboutClick(object sender, EventArgs e)
		{
			frmAbout f=new frmAbout();			
			f.ShowDialog(this);
		}

        void MnuObjectsClick(object sender, EventArgs e)
        {
            string windowTitle = "Объекты в Пирамиде";
            bool contains = false;
            foreach (Form child in this.MdiChildren)
                if (child.Text == windowTitle)
                {
                    child.Activate();
                    contains = true;
                    break;
                }
            if (!contains)
            {
                frmObjects f = new frmObjects();

                this.Cursor = Cursors.WaitCursor;
                f.MdiParent = this;
                f.Text = windowTitle;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
            }
        }

        void MnuAnalizeClick(object sender, EventArgs e)
        {
            string windowTitle = "Анализ профиля";
            bool contains = false;
            foreach (Form child in this.MdiChildren)
                if (child.Text == windowTitle)
                {
                    child.Activate();
                    contains = true;
                    break;
                }
            if (!contains)
            {
                frmAnalize f = new frmAnalize();
                this.Cursor = Cursors.WaitCursor;
                f.MdiParent = this;
                f.Text = windowTitle;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
            }
        }

        private void mnuTest_Click(object sender, EventArgs e)
        {
            string windowTitle = "Тест";
            bool contains = false;
            foreach (Form child in this.MdiChildren)
                if (child.Text == windowTitle)
                {
                    child.Activate();
                    contains = true;
                    break;
                }
            if (!contains)
            {
                frmTest f = new frmTest();
                this.Cursor = Cursors.WaitCursor;
                f.MdiParent = this;
                f.Text = windowTitle;
                f.Show();                
            }
        }

        private void mnuOutput_Click(object sender, EventArgs e)
        {
            string windowTitle = "Выгрузка";
            bool contains = false;
            foreach (Form child in this.MdiChildren)
                if (child.Text == windowTitle)
                {
                    child.Activate();
                    contains = true;
                    break;
                }
            if (!contains)
            {
                frmOutput f = new frmOutput();
                this.Cursor = Cursors.WaitCursor;
                f.MdiParent = this;
                f.Text = windowTitle;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
            }
        }
		
		void MainFormLoad(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
            DataProvider d = new DataProvider();
            if (!d.TestConnection())
                MessageBox.Show("Приложению не удалось соединиться с базой данных Piramida2000\n" +
                    "Проверьте параметры соединения и доступность SQL сервера",
                    "Нет связи с базой данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

        private void mnuMap_Click(object sender, EventArgs e)
        {
            string windowTitle = "Карта сбора";
            bool contains = false;
            foreach (Form child in this.MdiChildren)
                if (child.Text == windowTitle)
                {
                    child.Activate();
                    contains = true;
                    break;
                }
            if (!contains)
            {
                frmMap f = new frmMap();
                this.Cursor = Cursors.WaitCursor;
                f.MdiParent = this;
                f.Text = windowTitle;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
