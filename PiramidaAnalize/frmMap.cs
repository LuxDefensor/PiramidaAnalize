﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PiramidaAnalize
{
    public partial class frmMap : Form
    {
        private MainForm parent;
        private DataProvider d;
        private bool enableMap = false;

        public frmMap()
        {
            InitializeComponent();
            d = new DataProvider();            
            this.Load += FrmMap_Load;
            toolChooseParam.SelectedIndexChanged += ToolChooseParam_SelectedIndexChanged;            
            dtpMap.ValueChanged += DtpMap_ValueChanged;
            toolInterval.SelectedIndexChanged += ToolInterval_SelectedIndexChanged;
        }

        private void ToolChooseParam_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SetupMap();
            this.Cursor = Cursors.Default;
        }

        private void DtpMap_ValueChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            SetupMap();
            this.Cursor = Cursors.Default;
        }        

        private void treeObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            toolCurrentObject.Text = e.Node.FullPath;
            this.Refresh();
            SetupMap();
            this.Cursor = Cursors.Default;
        }

        private void ToolInterval_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            switch (toolInterval.SelectedIndex)
            {
                case 0: //День
                    {
                        //Оставим день без изменения
                        break;
                    }
                case 1: //Неделя
                    {
                        dtpMap.Value = dtpMap.Value.FirstDayOfWeek();
                        break;
                    }
                case 2: //Месяц
                    {
                        if (dtpMap.Value.Day != 1)
                            dtpMap.Value = new DateTime(dtpMap.Value.Year, dtpMap.Value.Month, 1);
                        break;
                    }
                case 3: //Год
                    {
                        if (dtpMap.Value.Month != 1 || dtpMap.Value.Day != 1)
                            dtpMap.Value = new DateTime(dtpMap.Value.Year, 1, 1);
                        break;
                    }
            }
            SetupMap();
            this.Cursor = Cursors.Default;
        }

        private void FrmMap_Load(object sender, EventArgs e)
        {
            parent = (MainForm)(this.MdiParent);
            parent.Cursor = Cursors.Default;
            this.Cursor = Cursors.WaitCursor;
            d.PopulateDevices(treeObjects);
            this.Cursor = Cursors.Default;
            DateTime initialDate = DateTime.Today;
            if (initialDate.Day == 1)
                initialDate = initialDate.AddMonths(-1);
            else
                initialDate = initialDate.FirstDayOfMonth();
            dtpMap.Value = initialDate;
            enableMap = true;
        }

        private void SetupMap()
        {
            if (!enableMap)
                return;
            if (treeObjects.SelectedNode == null)
                return;
            //if (treeObjects.SelectedNode.Text == "Корень")
            //    return;
            string selectedNode = treeObjects.SelectedNode.Tag.ToString();
            string interval;
            long objectID = -1;
            objectID = long.Parse(selectedNode.Substring(1));        
            int param;
            DateTime baseDate, endDate;
            int daysCount = 0;
            baseDate = dtpMap.Value;
            dgvMap.Columns.Clear();
            #region Pick parameter
            switch (toolChooseParam.Text)
            {
                case "12 - Получасовки":
                    {
                        param = 12;
                        break;
                    }
                case "101 - Зафиксированные показания":
                    {
                        param = 101;
                        break;
                    }
                default:
                    {
                        param = 12;
                        break;
                    }
            }
            #endregion
            #region Pick interval
            switch (toolInterval.Text)
            {
                case "День":
                    {
                        endDate = baseDate.AddDays(1);
                        interval = "halfhour";                        
                        break;
                    }
                case "Неделя":
                    {
                        baseDate = baseDate.FirstDayOfWeek();
                        endDate = baseDate.AddDays(7);
                        interval = "day";
                        daysCount = 7;
                        break;
                    }
                case "Месяц":
                    {
                        baseDate = baseDate.FirstDayOfMonth();
                        endDate = baseDate.AddMonths(1);
                        interval = "day";
                        daysCount = dtpMap.Value.DaysInMonth();
                        break;
                    }
                case "Год":
                    {
                        baseDate = baseDate.FirstDayOfYear();
                        endDate = baseDate.AddYears(1);
                        interval = "month";
                        daysCount = dtpMap.Value.DaysInYear();
                        break;
                    }
                default: // То же самое, что и "Месяц"
                    {
                        baseDate = baseDate.FirstDayOfMonth();
                        endDate = baseDate.AddMonths(1);
                        interval = "day";
                        daysCount = dtpMap.Value.DaysInMonth();
                        break;
                    }
            }
            #endregion
            #region Pick functions
            switch (selectedNode[0])
            {
                case 'F':
                    {
                        MakeFolderMap(objectID, baseDate, endDate, interval, param, daysCount);                        
                        break;
                    }
                case 'D':
                    {
                        MakeDeviceMap(objectID, baseDate, endDate, interval, param, daysCount);
                        break;
                    }
            }
            #endregion
            #region Tweak headers
            DateTime headerDate = baseDate;
            Graphics graphMap = dgvMap.CreateGraphics();
            float stringWidth = 0;
            try
            {
                stringWidth = graphMap.MeasureString(headerDate.ToString("dd.MM.yyyy ddd"),
                                                           dgvMap.ColumnHeadersDefaultCellStyle.Font).Width;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            foreach (DataGridViewColumn col in dgvMap.Columns)
            {
                if (col.Index > 1)
                {
                    if (col.Width > stringWidth)
                        col.HeaderText = headerDate.ToString("dd.MM.yyyy ddd");
                    else
                        col.HeaderText = (col.Index - 1).ToString();
                }
                col.HeaderCell.ToolTipText = headerDate.ToString("dd.MM.yyyy ddd");
                headerDate = headerDate.IterateDate(interval);
            }

            #endregion

        }

        private void MakeFolderMap(long folderID, DateTime baseDate, DateTime endDate, string interval, 
             int parameter=12, int daysCount=0)
        {
            List<Folder> folders = new List<Folder>();
            if (folderID != 0)
                folders = d.GetImmediateFolders(folderID);
            List<Device> devices = d.GetDevices(folderID);
            DateTime currentDate = baseDate;
            int totalValues, completed = 0;
            double percent, expected;
            dgvMap.RowCount = folders.Count + devices.Count;
            switch (interval)
            {
                case "halfhour":
                    {
                        dgvMap.ColumnCount = 50;
                        break;
                    }
                case "day":
                    {
                        dgvMap.ColumnCount = 2 + daysCount;
                        break;
                    }
                case "month":
                    {
                        dgvMap.ColumnCount = 14;
                        break;
                    }
            }
            totalValues = dgvMap.RowCount * (dgvMap.ColumnCount - 2);
            int currentRow = 0;
            dgvMap.Columns[0].HeaderText = "Код";
            dgvMap.Columns[1].HeaderText = "Объект";
            dgvMap.Columns[0].Frozen = true;
            dgvMap.Columns[1].Frozen = true;
            dgvMap.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMap.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            for (int i = 2; i < dgvMap.ColumnCount; i++)
            {
                dgvMap.Columns[i].HeaderText = (i - 1).ToString();
                dgvMap.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            toolProgressLabel.Visible = true;
            toolProgressBar.Visible = true;
            this.Refresh();
            foreach (Folder f in folders)
            {
                dgvMap.Rows[currentRow].Cells[0].Value = f.FolderID;
                dgvMap.Rows[currentRow].Cells[1].Value = f.FolderName;
                dgvMap.Rows[currentRow].Cells[0].Style.BackColor = Color.Cornsilk;
                dgvMap.Rows[currentRow].Cells[1].Style.BackColor = Color.Cornsilk;
                currentDate = baseDate;
                expected = d.ExpectedInFolder(f.FolderID, interval, daysCount, parameter);
                for (int i = 2; i < dgvMap.ColumnCount; i++)
                {
                    if (expected > 0)
                        percent = 100 * d.FactInFolder(f.FolderID, interval, currentDate, parameter, daysCount) / expected;
                    else
                        percent = 0;
                    dgvMap.Rows[currentRow].Cells[i].Style.BackColor = GetColor(percent);
                    currentDate = currentDate.IterateDate(interval);
                    completed++;
                    toolProgressBar.ProgressBar.Value = (int)(100 * completed / totalValues);
                }     
                currentRow++;
            }
            foreach (Device dev in devices)
            {
                dgvMap.Rows[currentRow].Cells[0].Value = dev.DeviceCode;
                dgvMap.Rows[currentRow].Cells[1].Value = dev.DeviceName;
                currentDate = baseDate;
                expected = d.ExpectedInDevice(dev.DeviceID, interval, daysCount, parameter);
                for (int i = 2; i < dgvMap.ColumnCount; i++)
                {
                    if (expected > 0)
                        percent = 100 * d.FactInDevice(dev.DeviceID, interval, currentDate, parameter, daysCount) / expected;
                    else
                        percent = 0;
                    dgvMap.Rows[currentRow].Cells[i].Style.BackColor = GetColor(percent);
                    currentDate = currentDate.IterateDate(interval);
                    completed++;
                    toolProgressBar.ProgressBar.Value = (int)(100 * completed / totalValues);
                }
                currentRow++;
            }
            toolProgressBar.Visible = false;
            toolProgressLabel.Visible = false;
        }

        private void MakeDeviceMap(long deviceID, DateTime baseDate, DateTime endDate, string interval,
            int parameter = 12, int daysCount = 0)
        {
            List<Sensor> sensors = d.GetSensors(deviceID);
            DateTime currentDate = baseDate;
            int totalValues, completed = 0;
            double percent, expected;
            dgvMap.RowCount = sensors.Count;
            switch (interval)
            {
                case "halfhour":
                    {
                        dgvMap.ColumnCount = 50;
                        break;
                    }
                case "day":
                    {
                        dgvMap.ColumnCount = 2 + daysCount;
                        break;
                    }
                case "month":
                    {
                        dgvMap.ColumnCount = 14;
                        break;
                    }
            }
            dgvMap.Columns[0].HeaderText = "Код";
            dgvMap.Columns[1].HeaderText = "Объект";
            dgvMap.Columns[0].Frozen = true;
            dgvMap.Columns[1].Frozen = true;
            dgvMap.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvMap.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            for (int i = 2; i < dgvMap.ColumnCount; i++)
            {
                dgvMap.Columns[i].HeaderText = (i - 1).ToString();
                dgvMap.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            totalValues = dgvMap.RowCount * (dgvMap.ColumnCount - 2);
            int currentRow = 0;
            toolProgressLabel.Visible = true;
            toolProgressBar.Visible = true;
            this.Refresh();
            foreach (Sensor s in sensors)
            {
                dgvMap.Rows[currentRow].Cells[0].Value = s.SensorCode;
                dgvMap.Rows[currentRow].Cells[1].Value = s.SensorName;
                currentDate = baseDate;
                expected = d.ExpectedInSensor(s.SensorID, interval, daysCount, parameter);
                for (int i = 2; i < dgvMap.ColumnCount; i++)
                {
                    if (expected > 0)
                        percent = 100 * d.FactInSensor(s.SensorID, interval, currentDate, parameter, daysCount) / expected;
                    else
                        percent = 0;
                    dgvMap.Rows[currentRow].Cells[i].Style.BackColor = GetColor(percent);
                    currentDate = currentDate.IterateDate(interval);
                    completed++;
                    toolProgressBar.ProgressBar.Value = (int)(100 * completed / totalValues);
                }                
                currentRow++;
            }
            toolProgressBar.Visible = false;
            toolProgressLabel.Visible = false;
        }


        private void toolInterval_Validating(object sender, CancelEventArgs e)
        {
            if (!toolInterval.Items.Contains(toolInterval.Text))
            {
                toolInterval.Text = "Месяц";
                MessageBox.Show("Нужно выбрать значение из списка", "Неправильный интервал",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            else if (toolInterval.Text == "Год")
            {
                DialogResult resp = MessageBox.Show("Построение карты сбора за год займёт много времени. Вы уверены?",
                    "Подтверждение выбора", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resp == DialogResult.No)
                {
                    toolInterval.Text = "Месяц";
                    e.Cancel = true;
                }

            }
        }

        private void toolChooseParam_Validating(object sender, CancelEventArgs e)
        {
            if (!toolChooseParam.Items.Contains(toolChooseParam.Text))
            {
                toolChooseParam.Text = "12 - Получасовки";
                MessageBox.Show("Нужно выбрать значение из списка", "Неправильный параметр",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private Color GetColor(double percent)
        {
            Color result;
            if (percent > 100)
                result = Color.White;
            else if (percent == 100)
                result = Color.Lime;
            else if (percent >= 50 && percent < 100)
                result = Color.Yellow;
            else if (percent > 0 && percent < 50)
                result = Color.Orange;
            else
                result = Color.Red;
            return result;
        }
        
    }
}
