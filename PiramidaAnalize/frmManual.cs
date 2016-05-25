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
    /// <summary>
    /// Ручной ввод данных
    /// </summary>
    public partial class frmManual : Form
    {
        private DataProvider d;
        private MainForm parent;
        private bool dataChanged;
        private long currentDevice = -1;

        public frmManual()
        {
            InitializeComponent();
            dataChanged = false;
            d = new DataProvider();
            this.Load += FrmManual_Load;            
            dgvData.CellEndEdit += DgvData_CellEndEdit;
            mainTree.BeforeSelect += MainTree_BeforeSelect;
            mainTree.AfterSelect += MainTree_AfterSelect;
        }

        private void MainTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag != null && e.Node.Tag.ToString()[0] == 'D')
            {
                currentDevice = long.Parse(e.Node.Tag.ToString().Substring(1));
                txtSelected.Text = e.Node.Text;
            }
            else
            {
                currentDevice = -1;
                txtSelected.Text = "";
            }
            dgvData.Rows.Clear();  
        }

        private void MainTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (dataChanged)
            {
                DialogResult response = MessageBox.Show("В таблице есть несохранённые данные!\n" +
                    "Переход на другой объект приведёт к их потере. Продолжить?", "Переход на другой объект",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (response == DialogResult.Cancel)
                    e.Cancel = true;
                else
                {
                    //ClearTable();
                    dataChanged = false;
                }
            }
        }

        private void DgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double newConsumption = 0;
            string currentValue = string.Empty;
            double currentValueDouble = 0;
            System.Globalization.CultureInfo culture = System.Globalization.CultureInfo.CurrentCulture;
            if (dgvData[e.ColumnIndex, e.RowIndex].Value == null)
            {
                dgvData[e.ColumnIndex, e.RowIndex].Tag = "Clear";
            }
            else
            {
                dgvData[e.ColumnIndex, e.RowIndex].Style.Font = new Font(dgvData.DefaultCellStyle.Font,
                    FontStyle.Bold);
                currentValue = dgvData[e.ColumnIndex, e.RowIndex].Value.ToString();
                currentValue = currentValue.Replace('.', culture.NumberFormat.NumberDecimalSeparator[0]);
                currentValue = currentValue.Replace(',', culture.NumberFormat.NumberDecimalSeparator[0]);
                if (double.TryParse(currentValue, System.Globalization.NumberStyles.Float,
                    culture.NumberFormat, out currentValueDouble))
                {
                    dgvData[e.ColumnIndex, e.RowIndex].Value = currentValueDouble;
                    dgvData[e.ColumnIndex, e.RowIndex].Style.BackColor = dgvData.DefaultCellStyle.BackColor;
                    dgvData[e.ColumnIndex, e.RowIndex].ToolTipText = "";
                    dgvData[e.ColumnIndex, e.RowIndex].Tag = "Update";
                }
                else
                {
                    dgvData[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
                    dgvData[e.ColumnIndex, e.RowIndex].ToolTipText =
                        "Программа не воспринимает данное значение как число";
                    dgvData[e.ColumnIndex, e.RowIndex].Tag = "Ignore";
                }
                if (opt12.Checked)
                {
                    for (int i = 3; i < dgvData.ColumnCount; i++)
                    {
                        if (dgvData[i, e.RowIndex].Tag == null
                         || dgvData[i, e.RowIndex].Tag.ToString() == "Update")
                            newConsumption += double.Parse(dgvData[i, e.RowIndex].Value.ToString(), culture.NumberFormat);
                    }
                    dgvData[2, e.RowIndex].Style.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Bold);
                    dgvData[2, e.RowIndex].Value = newConsumption / 2;
                }
            }
            dataChanged = true;            
        }

        private void FrmManual_Load(object sender, EventArgs e)
        {
            this.Size = this.MdiParent.ClientSize;
            this.Refresh();
            parent = (MainForm)this.MdiParent;
            d.PopulateDevices(mainTree);
            parent.Cursor = Cursors.Default;
        }

        private void LoadTable(long deviceID, int parameter)
        {
            long totalCells, currentCell;
            int currentRow;
            long deviceCode = d.GetCode(deviceID);
            double currentValue = 0;
            this.Cursor = Cursors.WaitCursor;
            List<Sensor> sensors = d.GetSensors(deviceID);
            dgvData.RowCount = sensors.Count;
            currentRow = 0;
            if (parameter == 12)
            {
                dgvData.ColumnCount = 51; //код канала, название канала, 48 получасовок и потребление
                #region Make column headers
                dgvData.Columns[0].ReadOnly = true;
                dgvData.Columns[0].Frozen = true;
                dgvData.Columns[0].HeaderText = "Код";
                dgvData.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgvData.Columns[0].DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                dgvData.Columns[1].ReadOnly = true;
                dgvData.Columns[1].Frozen = true;
                dgvData.Columns[1].HeaderText = "Канал";
                dgvData.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[1].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgvData.Columns[1].DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                dgvData.Columns[2].ReadOnly = true;
                dgvData.Columns[2].Frozen = true;
                dgvData.Columns[2].HeaderText = "Потребление";
                dgvData.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[2].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgvData.Columns[2].DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                dgvData.Columns[3].ReadOnly = false;
                dgvData.Columns[3].DefaultCellStyle.BackColor = SystemColors.Window;
                dgvData.Columns[4].ReadOnly = false;
                dgvData.Columns[4].DefaultCellStyle.BackColor = SystemColors.Window;
                dgvData.Columns[5].ReadOnly = false;
                dgvData.Columns[5].DefaultCellStyle.BackColor = SystemColors.Window;
                dgvData.Columns[6].ReadOnly = false;
                dgvData.Columns[6].DefaultCellStyle = dgvData.DefaultCellStyle;
                for (int currentColumn = 3; currentColumn < dgvData.ColumnCount; currentColumn++)
                {
                    dgvData.Columns[currentColumn].HeaderText = string.Format("{0} - {1}",
                        cal1.SelectionStart.AddMinutes(30 * (currentColumn - 3)).ToString("HH:mm"),
                        cal1.SelectionStart.AddMinutes(30 * (currentColumn - 2)).ToString("HH:mm"));
                    dgvData.Columns[currentColumn].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvData.Columns[currentColumn].DefaultCellStyle.Font =
                        new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                }
                #endregion
                totalCells = dgvData.RowCount * 48;
                foreach (Sensor s in sensors)
                {
                    dgvData[0, currentRow].Value = s.SensorCode;
                    dgvData[1, currentRow].Value = s.SensorName;
                    dgvData[2, currentRow].Value = d.GetDayConsumption(deviceCode, s.SensorCode, cal1.SelectionStart);
                    for (int currentColumn = 3; currentColumn < dgvData.ColumnCount; currentColumn++)
                    {
                        currentValue = d.GetSingleHalfhour(deviceCode, s.SensorCode,
                            cal1.SelectionStart.AddMinutes(30 * (currentColumn - 2)));
                        dgvData[currentColumn, currentRow].Style.Font = dgvData.DefaultCellStyle.Font;
                        dgvData[currentColumn, currentRow].Style.BackColor =
                            dgvData.Columns[currentColumn].DefaultCellStyle.BackColor;
                        if (currentValue < 0)
                        {
                            dgvData[currentColumn, currentRow].Value = null;
                            dgvData[currentColumn, currentRow].Tag = "Empty";
                        }
                        else
                            dgvData[currentColumn, currentRow].Value = currentValue;
                    }
                    currentRow++;
                }
            }
            else
            {
                // код канала, название канала, последняя дата, последние показания, 
                //дата предыдущих показаний, предыдущие показания, показания на выбранную дату.            
                dgvData.ColumnCount = 7;
                #region Make column headers
                dgvData.Columns[0].ReadOnly = true;
                dgvData.Columns[0].Frozen = true;
                dgvData.Columns[0].HeaderText = "Код";
                dgvData.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                dgvData.Columns[0].DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                dgvData.Columns[1].ReadOnly = true;
                dgvData.Columns[1].Frozen = true;
                dgvData.Columns[1].HeaderText = "Канал";
                dgvData.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[1].DefaultCellStyle.BackColor = Color.LightGray;
                dgvData.Columns[1].DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                dgvData.Columns[2].ReadOnly = true;
                dgvData.Columns[2].HeaderText = "Дата"; // дата последних показаний
                dgvData.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[2].DefaultCellStyle.BackColor = Color.LightGray;
                dgvData.Columns[2].DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                dgvData.Columns[3].ReadOnly = true;
                dgvData.Columns[3].HeaderText = "Последние"; // последние показания
                dgvData.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[3].DefaultCellStyle.BackColor = Color.LightGray;
                dgvData.Columns[3].DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                dgvData.Columns[4].ReadOnly = true;
                dgvData.Columns[4].HeaderText = "Дата"; // дата предыдущих показаний
                dgvData.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[4].DefaultCellStyle.BackColor = Color.LightGray;
                dgvData.Columns[4].DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                dgvData.Columns[5].ReadOnly = true;
                dgvData.Columns[5].HeaderText = "Предыдущие"; // предыдущие показания
                dgvData.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[5].DefaultCellStyle.BackColor = Color.LightGray;
                dgvData.Columns[5].DefaultCellStyle.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                dgvData.Columns[6].ReadOnly = false;
                dgvData.Columns[6].HeaderText = cal1.SelectionStart.ToShortDateString(); // запрошенные показания
                dgvData.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvData.Columns[6].DefaultCellStyle.BackColor = SystemColors.Window;
                #endregion
                totalCells = dgvData.RowCount;
                foreach (Sensor s in sensors)
                {
                    dgvData[0, currentRow].Value = s.SensorCode;
                    dgvData[1, currentRow].Value = s.SensorName;
                    DataProvider.DataPoint last = d.GetLastFixedData(deviceCode, s.SensorCode);
                    dgvData[2, currentRow].Value = last.TimeStamp.ToShortDateString();
                    dgvData[3, currentRow].Value = last.DataEntry;
                    last = d.GetPriorFixedData(deviceCode, s.SensorCode, cal1.SelectionStart);
                    dgvData[4, currentRow].Value = last.TimeStamp.ToShortDateString();
                    dgvData[5, currentRow].Value = last.DataEntry;
                    foreach (DataGridViewColumn col in dgvData.Columns)
                    {
                        dgvData[col.Index, currentRow].Style.Font = dgvData.DefaultCellStyle.Font;
                        dgvData[col.Index, currentRow].Style.BackColor =
                            col.DefaultCellStyle.BackColor;
                    }
                    double val = d.GetOneFixedData(deviceCode, s.SensorCode, cal1.SelectionStart);
                    if (val < 0)
                    {
                        dgvData[6, currentRow].Value = null;
                        dgvData[6, currentRow].Tag = "Empty";
                    }
                    else
                        dgvData[6, currentRow].Value = val;
                    currentRow++;
                }
            }
            dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            this.Cursor = Cursors.Default;
        }

        private void SaveTable(long deviceID, int parameter, DateTime dateSave)
        {
            DateTime currentDate = dateSave;
            long deviceCode = d.GetCode(deviceID);
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                if (parameter == 12)
                {
                    for (int i = 3; i < dgvData.ColumnCount; i++)
                    {
                        currentDate = dateSave.AddMinutes(30 * (i - 2));
                        if (dgvData[i, row.Index].Tag != null)
                        {
                            if (dgvData[i, row.Index].Tag.ToString() == "Update")
                            {
                                d.WriteOneData(parent.WriterConnectionString, 12, deviceCode,
                                    long.Parse(dgvData[0, row.Index].Value.ToString()), currentDate,
                                    long.Parse(dgvData[i, row.Index].Value.ToString()));
                                dgvData[i, row.Index].Tag = null;
                                dgvData[i, row.Index].Style.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                            }
                            else if (dgvData[i, row.Index].Tag.ToString() == "Clear")
                            {
                                d.ClearOneData(parent.WriterConnectionString, 12, deviceCode,
                                    long.Parse(dgvData[0, row.Index].Value.ToString()), currentDate);
                                dgvData[i, row.Index].Tag = null;
                                dgvData[i, row.Index].Style.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                            }
                        }
                    }
                    dgvData[2, row.Index].Style.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                }
                else
                {
                    if (dgvData[6, row.Index].Tag != null)
                    {
                        if (dgvData[6, row.Index].Tag.ToString() == "Update")
                        {
                            d.WriteOneData(parent.WriterConnectionString, 101, deviceCode,
                                long.Parse(dgvData[0, row.Index].Value.ToString()), dateSave,
                                long.Parse(dgvData[6, row.Index].Value.ToString()));
                            dgvData[6, row.Index].Tag = null;
                            dgvData[6, row.Index].Style.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                        }
                        else if (dgvData[6, row.Index].Tag.ToString() == "Clear")
                        {
                            d.ClearOneData(parent.WriterConnectionString, 101, deviceCode,
                                long.Parse(dgvData[0, row.Index].Value.ToString()), dateSave);
                            dgvData[6, row.Index].Tag = null;
                            dgvData[6, row.Index].Style.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                        }
                    }
                }
            }
        }

        private void ClearTable()
        {
            foreach (DataGridViewRow row in dgvData.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!cell.ReadOnly)
                    {
                        cell.Value = null;
                        cell.Tag = null;
                        cell.Style.BackColor = SystemColors.Window;
                        cell.Style.Font = new Font(dgvData.DefaultCellStyle.Font, FontStyle.Regular);
                    }
                }
            }
        }

        private void cmdLoad_Click(object sender, EventArgs e)
        {
            if (dataChanged)
            {
                if (MessageBox.Show("Все несохранённые данные, введённые вручную в таблице, будут утеряны\n" +
                    "Вы уверены, что хотите загрузить данные из базы?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            txtDate.Text = cal1.SelectionStart.ToLongDateString();
            if (currentDevice > 0)
                LoadTable(currentDevice, (opt12.Checked) ? 12 : 101);
            dataChanged = false;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            DateTime dt;
            if (dataChanged)
            {
                if (MessageBox.Show("Эта операция запишет введённые вами данные в базу данных\n" +
                    "вместо существующих в ней значений (если они есть)\n" +
                    "Вы уверены, что хотите записать данные в базу?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            dt = cal1.SelectionStart;
            if (currentDevice > 0)
                SaveTable(currentDevice, (opt12.Checked) ? 12 : 101, dt);
            dataChanged = false;
        }

        private void cmdFromExcel_Click(object sender, EventArgs e)
        {
            if (currentDevice > 0)
            {
                Form frm = new frmImport(currentDevice, txtSelected.Text, cal1.SelectionStart);
                frm.ShowDialog();
            }
        }
    }
}
