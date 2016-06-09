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
    public partial class frmFind : Form
    {
        private DataProvider d;
        private long deviceID;
        private long sensorCode;

        public frmFind()
        {
            InitializeComponent();
            d = new DataProvider();
            dgvResults.CellContentClick += DgvResults_CellContentClick;
            txtSearch.KeyDown += TxtSearch_KeyDown;
            deviceID = -1;
            sensorCode = -1;
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmdFind_Click(cmdFind, new EventArgs());
        }

        public long DeviceID
        {
        get
            {
                return deviceID;
            }
        }

        public long SensorCode
        {
            get
            {
                return sensorCode;
            }
        }

        private void DgvResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                deviceID = d.GetID(long.Parse(dgvResults[0, e.RowIndex].Value.ToString()));
                if (dgvResults[2, e.RowIndex].Value!=null &&
                    dgvResults[2, e.RowIndex].Value.ToString() != string.Empty)
                    sensorCode = long.Parse(dgvResults[2, e.RowIndex].Value.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            dgvResults.Rows.Clear();
            switch (cboSearchType.Text)
            {
                case "По коду":
                    {
                        long deviceCode;
                        string result;
                        if (long.TryParse(txtSearch.Text, out deviceCode))
                            result = d.FindByCode(deviceCode);
                        else
                        {
                            MessageBox.Show("Введённое значение «" + txtSearch.Text + "» не является кодом устройства",
                                "Ошибка в строке поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        dgvResults.Rows.Add(txtSearch.Text, result, "", "", "=>");
                        break;
                    }
                case "По названию устройства":
                    {
                        List<Sensor> results = d.FindByDeviceName(txtSearch.Text, chkExact.Checked);
                        if (results.Count > 0)
                            foreach (Sensor s in results)
                                dgvResults.Rows.Add(s.DeviceCode, s.DeviceName);
                        break;
                    }
                case "По названию канала":
                    {
                        List<Sensor> results = d.FindByItemName(txtSearch.Text, chkExact.Checked);
                        if (results.Count > 0)
                            foreach (Sensor s in results)
                                dgvResults.Rows.Add(s.DeviceCode, s.DeviceName, s.SensorCode, s.SensorName);
                        break;
                    }
            }
        }
    }
}
