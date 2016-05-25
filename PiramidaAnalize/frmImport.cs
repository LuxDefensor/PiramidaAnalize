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
        DateTime currentDay;
        DataProvider d;

        public frmImport(long deviceID,string deviceName,DateTime selectedDate)
        {
            InitializeComponent();
            d = new DataProvider();
            currentDevice = deviceID;
            this.deviceName = deviceName;
            currentDay = selectedDate;
            toolOpen.Click += ToolOpen_Click;
            this.Load += FrmImport_Load;
        }

        private void FrmImport_Load(object sender, EventArgs e)
        {
            lblDevice.Text = deviceName;
            lblDate.Text = currentDay.ToShortDateString();
            List<Sensor> sensors = d.GetSensors(currentDevice);
            foreach (Sensor s in sensors)
                lstSensors.Items.Add(s.SensorName);
        }

        private void ToolOpen_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
