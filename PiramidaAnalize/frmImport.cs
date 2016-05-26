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
    public partial class frmImport : Form
    {
        long currentDevice;
        string deviceName;
        int parameter;
        DateTime currentDay;
        DataProvider d;
        XLSImport source;

        public frmImport(long deviceID, string deviceName, int parameter, DateTime selectedDate)
        {
            InitializeComponent();
            d = new DataProvider();
            currentDevice = deviceID;
            this.parameter = parameter;
            this.deviceName = deviceName;
            currentDay = selectedDate;
            toolOpen.Click += ToolOpen_Click;
            this.Load += FrmImport_Load;
        }

        public DataGridView Sheet
        {
        get
            {
                return dgvSheet;
            }
        }

        private void FrmImport_Load(object sender, EventArgs e)
        {
            lblDevice.Text = deviceName;
            lblDate.Text = currentDay.ToShortDateString();
            lblParameter.Text = (parameter == 12) ? "Получасовки (12)" :
                "Зафиксированные показания (101)";
            List<Sensor> sensors = d.GetSensors(currentDevice);
            foreach (Sensor s in sensors)
                lstSensors.Items.Add(s.SensorName);
        }

        private void ToolOpen_Click(object sender, EventArgs e)
        {
            List<Sensor> sensors = d.GetSensors(currentDevice);
            object[] values;
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                source = new XLSImport(dlgOpen.FileName);
                dgvSheet.RowCount = (parameter == 12) ? 48 : 1;
                dgvSheet.ColumnCount = sensors.Count;
                foreach (DataGridViewColumn col in dgvSheet.Columns)
                {
                    col.HeaderText = XLSImport.GetColumnHeader(col.Index + 1);
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    values = source.GetColumn(col.Index + 1, dgvSheet.RowCount);
                    for (int i = 0; i < dgvSheet.RowCount; i++)
                    {
                        dgvSheet[col.Index, i].Value = values[i];
                    }
                }
                source.Close();
                this.Cursor = Cursors.Default;
            }
        }
    }
}
