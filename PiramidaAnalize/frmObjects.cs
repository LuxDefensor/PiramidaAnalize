/*
 * Created by SharpDevelop.
 * User: smke-ing3
 * Date: 04.03.2016
 * Time: 9:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;


namespace PiramidaAnalize
{
	/// <summary>
	/// Description of frmObjects.
	/// </summary>
	public partial class frmObjects : Form
	{

        private Color[] colors = new Color[22];

        private DataProvider d;
        private MainForm parent;
		
		public frmObjects()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            #region Define colors
            colors[0] = Color.Black;
            colors[1] = Color.Aqua;
            colors[2] = Color.Blue;
            colors[3] = Color.Coral;
            colors[4] = Color.Brown;
            colors[5] = Color.Chartreuse;
            colors[6] = Color.Crimson;
            colors[7] = Color.CornflowerBlue;
            colors[8] = Color.DarkCyan;
            colors[9] = Color.DarkMagenta;
            colors[10] = Color.Orange;
            colors[11] = Color.DarkOliveGreen;
            colors[12] = Color.DarkSalmon;
            colors[13] = Color.Green;
            colors[14] = Color.Gold;
            colors[15] = Color.DarkRed;
            colors[16] = Color.Lime;
            colors[17] = Color.Magenta;
            colors[18] = Color.OrangeRed;
            colors[19] = Color.RoyalBlue;
            colors[20] = Color.YellowGreen;
            colors[21] = Color.Red;
            #endregion
            d = new DataProvider();
            cmdSelectAll.Click += CmdSelectAll_Click;
            cmdDeselectAll.Click += CmdDeselectAll_Click;
            cmdRefresh.Click += CmdRefresh_Click;
            opt12.CheckedChanged += Opt12_CheckedChanged;
            opt101.CheckedChanged += Opt101_CheckedChanged;
            calMap.DateChanged += CalMap_DateChanged;
		}

        private void CmdRefresh_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ManageView(tabs.SelectedIndex);
            this.Cursor = Cursors.Default;
        }

        private void CalMap_DateChanged(object sender, DateRangeEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ManageView(tabs.SelectedIndex);
            this.Cursor = Cursors.Default;
        }

        private void Opt101_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ManageView(tabs.SelectedIndex);
            this.Cursor = Cursors.Default;
        }

        private void Opt12_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ManageView(tabs.SelectedIndex);
            this.Cursor = Cursors.Default;
        }

        private void CmdDeselectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode n in treeSensors.Nodes)
                n.Checked = false;
        }

        private void CmdSelectAll_Click(object sender, EventArgs e)
        {
            foreach (TreeNode n in treeSensors.Nodes)
                n.Checked = true;
                            
        }

        void FrmObjectsLoad(object sender, EventArgs e)
		{
			this.Size=this.MdiParent.ClientSize;
			this.Refresh();
            parent = (MainForm)this.MdiParent;
			d.PopulateDevices(mainTree);
            parent.Cursor = Cursors.Default;
		}
		
		void MainTreeAfterSelect(object sender, TreeViewEventArgs e)
		{
            this.Cursor = Cursors.WaitCursor;
            ManageView(tabs.SelectedIndex);
            this.Cursor = Cursors.Default;

		}

        private void tabs_Selected(object sender, TabControlEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ManageView(e.TabPageIndex);
            this.Cursor = Cursors.Default;
        }

        private void ManageView(int tabIndex)
        {
            if (mainTree.SelectedNode != null)
                txtDevice.Text = mainTree.SelectedNode.FullPath;
            else
                return;
            string stringDeviceID = mainTree.SelectedNode.Tag.ToString().Substring(1);
            long deviceID, deviceCode;
            long.TryParse(stringDeviceID, out deviceID);
            deviceCode = d.GetCode(deviceID);
            txtDeviceCode.Text = deviceCode.ToString();
            txtDate.Text = calMap.SelectionStart.ToShortDateString();
            txtDeviceID.Text = stringDeviceID;
            switch (tabIndex)
            {
                case 0: // Список каналов учёта
                    {

                        if (mainTree.SelectedNode.Tag.ToString().Substring(0, 1) == "D")
                        {
                            d.FillSensors(dgvSensors, deviceID);
                        }
                        else
                        {
                            dgvSensors.DataMember = "";
                            dgvSensors.DataSource = "";
                            txtDeviceCode.Text = "";
                        }
                        break;
                    }
                case 1: // Карта сбора
                    {
                        if (mainTree.SelectedNode.Tag.ToString().Substring(0, 1) == "D")
                        {
                            d.FillMap(dgvMap, stringDeviceID, calMap.SelectionStart);
                            dgvMap.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.AllCells);
                            dgvMap.AutoResizeColumn(1, DataGridViewAutoSizeColumnMode.AllCells);
                        }
                        else
                        {
                            dgvMap.DataMember = "";
                            dgvMap.DataSource = "";
                            txtDeviceCode.Text = "";
                        }
                        break;
                    }
                case 2: // Значения
                    {
                        dgvData.DataMember = "";
                        dgvData.DataSource = "";
                        txtDeviceCode.Text = "";
                        if (mainTree.SelectedNode.Tag.ToString().Substring(0, 1) == "D")
                        {
                            try
                            {
                                txtDeviceCode.Text = deviceCode.ToString();
                                lblValuesDevice.Text = string.Format("{0} за {1}", mainTree.SelectedNode.Text,
                                    calMap.SelectionStart.ToShortDateString());
                                if (opt12.Checked)
                                {
                                    dgvData.DataSource = d.GetHalfhoursDailyPivot(deviceCode, calMap.SelectionStart);
                                    dgvData.DataMember = "DailyData";
                                }
                                else
                                {
                                    System.Data.DataSet fixedVals = new System.Data.DataSet();
                                    fixedVals.Tables.Add("fixedTable");
                                    fixedVals.Tables[0].Columns.Add("No", typeof(long));
                                    fixedVals.Tables[0].Columns.Add("SensorName", typeof(string));
                                    fixedVals.Tables[0].Columns.Add("SelectedValue", typeof(string));
                                    fixedVals.Tables[0].Columns[2].Caption = "Выбранные";                                    
                                    fixedVals.Tables[0].Columns.Add("LastDate", typeof(DateTime));
                                    fixedVals.Tables[0].Columns[3].Caption = "Последние";
                                    fixedVals.Tables[0].Columns.Add("LastValue", typeof(string));
                                    fixedVals.Tables[0].Columns[4].Caption = "Показания";
                                    List<Sensor> sensors = d.GetSensors(deviceID);
                                    DataProvider.DataPoint val1;
                                    System.Data.DataRow newRow;
                                    double val2;
                                    foreach (Sensor s in sensors)
                                    {
                                        val2 = d.GetOneFixedData(deviceCode, s.SensorCode, calMap.SelectionStart);
                                        val1 = d.GetLastFixedData(deviceCode, s.SensorCode);
                                        newRow = fixedVals.Tables[0].Rows.Add();
                                        newRow[0] = s.SensorCode;
                                        newRow[1] = s.SensorName;
                                        newRow[2] = (val2 < 0) ? "---" : val2.ToString("#,##0.0000");
                                        newRow[3] = val1.TimeStamp;
                                        newRow[4] = (val1.DataEntry < 0) ? "---" : val1.DataEntry.ToString("#,##0.0000");                                        
                                    }
                                    dgvData.DataSource = fixedVals;
                                    dgvData.DataMember = "fixedTable";
                                    dgvData.Columns[2].HeaderText = calMap.SelectionStart.ToShortDateString();
                                    dgvData.Columns[3].HeaderText = "Последние";
                                    dgvData.Columns[4].HeaderText = "Показания";
                                }
                                dgvData.Columns[0].HeaderText = "№";
                                dgvData.Columns[1].HeaderText = "Время";
                                dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                                dgvData.Columns[0].Frozen = true;
                                dgvData.Columns[1].Frozen = true;
                                foreach (DataGridViewRow row in dgvData.Rows)
                                {
                                    row.Cells[0].Style.Format = "#";
                                    row.Cells[1].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                    if (opt101.Checked)
                                        row.Cells[3].Style.Format = "dd.MM.yyyy";
                                }
                                foreach (DataGridViewColumn col in dgvData.Columns)
                                {
                                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                }                                
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }                                               
                        break;
                    }
                case 3: // График
                    {
                        treeSensors.Nodes.Clear();
                        chart1.Series.Clear();
                        chart1.Titles.Clear();
                        txtDeviceCode.Text = "";
                        if (mainTree.SelectedNode.Tag.ToString().Substring(0, 1) == "D")
                        {
                            TreeNode currentNode;
                            int currentColor;
                            Title t;
                            Series grafik;
                            t = chart1.Titles.Add("Basic");
                            t.Text = calMap.SelectionStart.ToShortDateString() + " - " + mainTree.SelectedNode.Text;
                            t.Font = new Font("Tahoma", 16);
                            t.Alignment = ContentAlignment.TopCenter;                           
                            txtDeviceCode.Text = deviceCode.ToString();
                            List<Sensor> sensors = d.GetSensors(deviceID);
                            currentColor = 0;
                            foreach (Sensor s in sensors)
                            {
                                currentNode = treeSensors.Nodes.Add(s.SensorCode.ToString(),
                                    string.Format("{0}. {1}", s.SensorCode, s.SensorName));
                                currentNode.Tag = s.SensorCode.ToString();
                                currentNode.BackColor = colors[currentColor % colors.GetLength(0)];
                                if (currentColor % colors.GetLength(0) == 0)
                                    currentNode.ForeColor = Color.White;
                                grafik = chart1.Series.Add(s.SensorCode.ToString());
                                currentNode.Checked = true;
                                System.Data.DataSet dsTemp = d.DrawDayGraph(s.SensorID, calMap.SelectionStart);
                                grafik.Points.DataBindXY(dsTemp.Tables[0].Rows, "time", dsTemp.Tables[0].Rows, "value0");
                                grafik.Color = colors[currentColor % colors.GetLength(0)];
                                grafik.BorderWidth = 2;
                                grafik.ChartType = SeriesChartType.Line;
                                grafik.ChartArea = "ChartArea1";
                                currentColor++;                                
                            }
                            
                        }
                        break;
                    }
            } // End of switch(tabIndex)
            tabs.TabPages[tabIndex].Refresh();
        }

        private void treeSensors_AfterCheck(object sender, TreeViewEventArgs e)
        {
            Series checkedGrafik;
            try
            {
                checkedGrafik = chart1.Series.FindByName(e.Node.Tag.ToString());
                if (checkedGrafik != null)
                    checkedGrafik.ChartArea = (e.Node.Checked) ? "ChartArea1" : "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "After checked event handler");
            }
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            long deviceID;
            TreeNode deviceNode;
            frmFind f = new frmFind();
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                deviceID = f.DeviceID;
                deviceNode = FindNode("D" + deviceID.ToString());
                mainTree.SelectedNode = deviceNode;
                deviceNode.EnsureVisible();
            }
        }

        private TreeNode FindNode(string key)
        {
            TreeNode result;
            result = mainTree.Nodes[key];
            if (result == null)
                foreach (TreeNode subNode in mainTree.Nodes)
                {
                    result = RecursiveSearch(subNode, key);
                    if (result != null)
                        break;
                }
            return result;
        }

        private TreeNode RecursiveSearch(TreeNode root, string key)
        {
            TreeNode result = root.Nodes[key];
            if (result == null)
            {
                foreach (TreeNode currentNode in root.Nodes)
                {
                    result = RecursiveSearch(currentNode, key);
                    if (result != null)
                        break;
                }
            }
            return result;
        }
    }
}
