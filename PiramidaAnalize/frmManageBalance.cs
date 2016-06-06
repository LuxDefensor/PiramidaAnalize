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
    public partial class frmManageBalance: Form
    {
        private DataProvider d;
        private bool dirty = false;
        MainForm parent;
        private long exisitngBalance;
        private long draggedID;
        private List<TreeNode> selected;
        private List<long> plusSensors;
        private List<long> minusSensors;

        public frmManageBalance(long balance = -1)
        {
            InitializeComponent();
            parent = (MainForm)this.MdiParent;
            d = new DataProvider();
            exisitngBalance = balance;
            selected = new List<TreeNode>();
            plusSensors = new List<long>();
            minusSensors = new List<long>();
            this.Load += FrmManageBalance_Load;
            treeObjects.AfterCheck += TreeObjects_AfterCheck;
            cmdPlaceToPlus.Click += CmdPlaceToPlus_Click;
            cmdPlaceToMinus.Click += CmdPlaceToMinus_Click;
            cmdRemoveFromPlus.Click += CmdRemoveFromPlus_Click;
            cmdRemoveFromMinus.Click += CmdRemoveFromMinus_Click;
            dgvDetailMinus.DataError += DgvDetailMinus_DataError;
            dgvDetailPlus.DataError += DgvDetailPlus_DataError;
            toolSave.Click += ToolSave_Click;
        }

        private void ToolSave_Click(object sender, EventArgs e)
        {
            if (dgvDetailMinus.Rows.Count == 0 && dgvDetailPlus.Rows.Count == 0)
            {
                MessageBox.Show("В каждом балансе должен бать хоть один канал в качестве слагаемого,\n" +
                    "иначе его нельзя будет найти в дереве", "Попытка сохранения пустого баланса",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            if (((MainForm)this.MdiParent).WriterConnectionString == string.Empty)
            {
                if (!((MainForm)MdiParent).GetWriterAccess())
                {
                    MessageBox.Show("Недостаточно прав для редактирования балансов\n" +
                        "Обратитесь к администратору системы", "Вы не можете редактировать балансы",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            if (!d.TestWriter(((MainForm)MdiParent).WriterConnectionString))
            {
                MessageBox.Show("Недостаточно прав для редактирования балансов\n" +
                    "Обратитесь к администратору системы", "Вы не можете редактировать балансы",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            DialogResult resp = MessageBox.Show("Вы собираетесь заменить в БД настройки данного баланса.\n" +
                "Продолжить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;
            System.Data.DataTable details=new DataTable();
            details.Columns.Add("Sign", typeof(Int16));
            details.Columns.Add("Object", typeof(int));
            details.Columns.Add("Item", typeof(int));
            details.Columns.Add("Parnumber", typeof(Int16));
            foreach (DataGridViewRow row in dgvDetailPlus.Rows)
            {
                details.Rows.Add("1",
                    int.Parse(row.Cells[0].Value.ToString()),
                    int.Parse(row.Cells[2].Value.ToString()),
                    Int16.Parse(row.Cells[4].Value.ToString()));
            }
            foreach (DataGridViewRow row in dgvDetailMinus.Rows)
            {
                details.Rows.Add("-1",
                    int.Parse(row.Cells[0].Value.ToString()),
                    int.Parse(row.Cells[2].Value.ToString()),
                    Int16.Parse(row.Cells[4].Value.ToString()));
            }
            if (d.UpdateBalanceDetails(exisitngBalance, txtTitle.Text, details, 
                                       ((MainForm)MdiParent).WriterConnectionString))
            {
                MessageBox.Show("Настройки данного баланса успешно изменены", "Сохранение завершено",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dirty = false;
            }
            else
            {
                MessageBox.Show("Во время сохранения произошла ошибка, изменения не были сохранены",
                    "Отмена сохранения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmdRemoveFromMinus_Click(object sender, EventArgs e)
        {
            if (dgvDetailMinus.CurrentCell == null)
            {
                MessageBox.Show("Выберите канал, который хотите удалить", "Канал не выбран",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                long sensorID = d.GetSensorID(long.Parse(dgvDetailMinus.CurrentRow.Cells[0].Value.ToString()),
                    long.Parse(dgvDetailMinus.CurrentRow.Cells[2].Value.ToString()));
                if (minusSensors.Contains(sensorID))
                {
                    minusSensors.Remove(sensorID);
                    dgvDetailMinus.Rows.Remove(dgvDetailMinus.CurrentRow);
                    dirty = true;
                }
                else
                {
                    MessageBox.Show("Выбранного канала нет во вспомогательном списке",
                        "Ошибка синхронизации списков", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CmdRemoveFromPlus_Click(object sender, EventArgs e)
        {
            if (dgvDetailPlus.CurrentCell == null)
            {
                MessageBox.Show("Выберите канал, который хотите удалить", "Канал не выбран",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                long sensorID = d.GetSensorID(long.Parse(dgvDetailPlus.CurrentRow.Cells[0].Value.ToString()),
                    long.Parse(dgvDetailPlus.CurrentRow.Cells[2].Value.ToString()));
                if (plusSensors.Contains(sensorID))
                {
                    plusSensors.Remove(sensorID);
                    dgvDetailPlus.Rows.Remove(dgvDetailPlus.CurrentRow);
                    dirty = true;
                }
                else
                {
                    MessageBox.Show("Выбранного канала нет во вспомогательном списке",
                        "Ошибка синхронизации списков", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CmdPlaceToMinus_Click(object sender, EventArgs e)
        {
            long sensorID;
            TreeNode node;
            if (selected.Count == 0)
            {
                MessageBox.Show("Нужно отметить галочками те каналы, которые вы хотите поместить " +
                    "в список, и затем нажать на кнопку со стрелкой", "Каналы не выбраны",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for (int i = selected.Count - 1; i >= 0; i--)
            {
                node = selected[i];
                sensorID = long.Parse(node.Tag.ToString().Substring(1));
                if (plusSensors.Contains(sensorID))
                {
                    MessageBox.Show(node.Text + " уже содержится в верхнем списке каналов",
                        "Дублирование канала", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    continue;
                }
                if (minusSensors.Contains(sensorID))
                {
                    MessageBox.Show(node.Text + " уже содержится в нижнем списке каналов",
                        "Дублирование канала", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    continue;
                }
                minusSensors.Add(sensorID);
                Dictionary<string, string> sensorInfo = d.SensorInfo(sensorID);
                dgvDetailMinus.Rows.Add(sensorInfo["DeviceCode"],
                                       sensorInfo["DeviceName"],
                                       sensorInfo["SensorCode"],
                                       sensorInfo["SensorName"],
                                       "12");
                node.Checked = false;
                dirty = true;
            }
        }

        private void DgvDetailPlus_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(string.Format("Plus: row {0}, column {1} - {2}", 
                e.RowIndex, e.ColumnIndex,e.Exception.Message));
        }

        private void DgvDetailMinus_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(string.Format("Minus: row {0}, column {1} - {2}",
                e.RowIndex, e.ColumnIndex, e.Exception.Message));
        }

        private void CmdPlaceToPlus_Click(object sender, EventArgs e)
        {
            long sensorID;
            TreeNode node;
            if (selected.Count == 0)
            {
                MessageBox.Show("Нужно отметить галочками те каналы, которые вы хотите поместить " +
                    "в список, и затем нажать на кнопку со стрелкой", "Каналы не выбраны",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            for(int i=selected.Count-1;i>=0;i--)
            {
                node = selected[i];
                sensorID = long.Parse(node.Tag.ToString().Substring(1));
                if (plusSensors.Contains(sensorID))
                {
                    MessageBox.Show(node.Text + " уже содержится в верхнем списке каналов",
                        "Дублирование канала", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    continue;
                }
                if (minusSensors.Contains(sensorID))
                {
                    MessageBox.Show(node.Text + " уже содержится в нижнем списке каналов",
                        "Дублирование канала", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    continue;
                }
                plusSensors.Add(sensorID);
                Dictionary<string, string> sensorInfo = d.SensorInfo(sensorID);
                dgvDetailPlus.Rows.Add(sensorInfo["DeviceCode"],
                                       sensorInfo["DeviceName"],
                                       sensorInfo["SensorCode"],
                                       sensorInfo["SensorName"],
                                       "12");
                node.Checked = false;
                dirty = true;
            }
        }

        private void TreeObjects_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag.ToString()[0] == 'S')
            {
                if (e.Node.Checked)
                {
                    if (!selected.Contains(e.Node))
                        selected.Add(e.Node);
                }
                else
                {
                    if (selected.Contains(e.Node))
                        selected.Remove(e.Node);
                }
            }
        }

        private void FrmManageBalance_Load(object sender, EventArgs e)
        {
            System.Data.DataSet details;
            long sensorID;
            foreach (DataGridViewColumn col in dgvDetailPlus.Columns)
            {
                dgvDetailMinus.Columns.Add((DataGridViewColumn)col.Clone());
            }
            d.PopulateTree(treeObjects, treeIcons);
            if (exisitngBalance > 0)
            {
                txtTitle.Text = d.GetBalanceName(exisitngBalance);
                details = d.GetBalanceDetails(exisitngBalance);
                foreach (System.Data.DataRow row in details.Tables[0].Rows)
                {
                    sensorID = d.GetSensorID((int)row[4], (int)row[5]);
                    if ((Int16)row[0] == -1)
                    {
                        dgvDetailMinus.Rows.Add(row[4], row[1], row[5], row[2], row[3].ToString());
                        minusSensors.Add(sensorID);
                    }
                    else
                    {
                        dgvDetailPlus.Rows.Add(row[4], row[1], row[5], row[2], row[3].ToString());
                        plusSensors.Add(sensorID);
                    }
                }
            }
            this.MdiParent.Cursor = Cursors.Default;
        }

        private void toolReset_Click(object sender, EventArgs e)
        {
            long sensorID;
            DialogResult resp = MessageBox.Show("Вы собираетесь заменить в БД настройки данного канала.\n" +
                                        "Продолжить?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.No)
                return;
            minusSensors.Clear();
            plusSensors.Clear();
            txtTitle.Text = d.GetBalanceName(exisitngBalance);
            DataSet details = d.GetBalanceDetails(exisitngBalance);
            dgvDetailMinus.Rows.Clear();
            dgvDetailPlus.Rows.Clear();
            foreach (DataRow row in details.Tables[0].Rows)
            {
                sensorID = d.GetSensorID((int)row[4], (int)row[5]);
                if ((Int16)row[0] == -1)
                {
                    dgvDetailMinus.Rows.Add(row[4], row[1], row[5], row[2], row[3].ToString());
                    minusSensors.Add(sensorID);
                }
                else
                {
                    dgvDetailPlus.Rows.Add(row[4], row[1], row[5], row[2], row[3].ToString());
                    plusSensors.Add(sensorID);
                }
            }
            dirty = false;
        }

        private void toolClose_Click(object sender, EventArgs e)
        {
            // TODO Добавить проверку на пустой баланс
            if (dirty)
            {
                DialogResult resp = MessageBox.Show("Есть несохранённые изменения в данном балансе.\n" +
                    "При закрытии окна они будут утеряны. Продолжить?", "Подтверждение закрытия",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return;
            }
            this.Close();
        }
    }
}
