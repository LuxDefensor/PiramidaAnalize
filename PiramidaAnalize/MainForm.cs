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
        private string writerConnectionString;

        public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            writerConnectionString = string.Empty;
		}

        public bool GetWriterAccess()
        {
            bool result = true;
            frmPassword pwd = new frmPassword();
            if (pwd.ShowDialog() == DialogResult.OK)
            {
                System.Data.SqlClient.SqlConnectionStringBuilder conString = new System.Data.SqlClient.SqlConnectionStringBuilder();
                database st = new PiramidaAnalize.database();
                conString.DataSource = st.Server;
                conString.InitialCatalog = st.Database;
                conString.UserID = pwd.Login;
                conString.Password = pwd.Password;
                writerConnectionString = conString.ToString();
                System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection(writerConnectionString);
                try
                {
                    cn.Open();
                }
                catch
                {
                    writerConnectionString = string.Empty;
                    result = false;
                }
                if (cn.State == System.Data.ConnectionState.Open)
                    cn.Close();
            }
            else
            {
                writerConnectionString = string.Empty;
                result = false;
            }                
            return result;
        }

        public string WriterConnectionString
        {
        get
            {
                return writerConnectionString;
            }
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

        private void mnuInput_Click(object sender, EventArgs e)
        {
            DataProvider d = new DataProvider();
            string windowTitle = "Ручной ввод данных";
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
                if (writerConnectionString == string.Empty)
                {
                    if (!GetWriterAccess())
                    {
                        MessageBox.Show("Недостаточно прав для ручного ввода данных\n" +
                            "Обратитесь к администратору системы", "Вы не можете вводить данные вручную",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }                    
                }
                if (!d.TestWriter(writerConnectionString))
                {
                    MessageBox.Show("Недостаточно прав для ручного ввода данных\n" +
                        "Обратитесь к администратору системы", "Вы не можете вводить данные вручную",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                frmManual f = new frmManual();
                this.Cursor = Cursors.WaitCursor;
                f.MdiParent = this;
                f.Text = windowTitle;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
            }
        }

        private void настройкаПодключенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings f = new frmSettings();
            f.ShowDialog();
        }

        private void mnuBalance_Click(object sender, EventArgs e)
        {
            string windowTitle = "Балансы электроэнергии";
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
                frmBalance f = new frmBalance();
                this.Cursor = Cursors.WaitCursor;
                f.MdiParent = this;
                f.Text = windowTitle;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
            }
        }

        private void mnuHelp_Click(object sender, EventArgs e)
        {

        }

        private void mnuColors_Click(object sender, EventArgs e)
        {
            string windowTitle = "Цвета";
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
                frmTestColors f = new frmTestColors();
                this.Cursor = Cursors.WaitCursor;
                f.MdiParent = this;
                f.Text = windowTitle;
                f.Show();
                f.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
