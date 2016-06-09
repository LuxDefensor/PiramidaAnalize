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
    public partial class frmBalance : Form
    {
        private MainForm parent;
        private DataProvider d;
        private XLSExport xls;
        private long currentBalance;

        public frmBalance()
        {
            InitializeComponent();
            d = new DataProvider();
            xls = new XLSExport();
            this.Load += FrmBalance_Load;
            treeObjects.AfterSelect += TreeObjects_AfterSelect;
            dgvBalance.CellMouseClick += DgvBalance_CellMouseClick;
            this.ResizeEnd += FrmBalance_ResizeEnd;
            toolExcel.Click += ToolExcel_Click;
            dgvBalance.SelectionChanged += DgvBalance_SelectionChanged;
            this.Activated += FrmBalance_Activated;
        }

        private void FrmBalance_Activated(object sender, EventArgs e)
        {
            TreeObjects_AfterSelect(treeObjects,
                new TreeViewEventArgs(treeObjects.SelectedNode, TreeViewAction.Unknown));
        }

        private void DgvBalance_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBalance.SelectedCells != null && dgvBalance.SelectedCells.Count == 1)
            {
                currentBalance = long.Parse(dgvBalance[0, dgvBalance.SelectedCells[0].RowIndex].Value.ToString());
            }            
        }

        private void ToolExcel_Click(object sender, EventArgs e)
        {
            if (currentBalance > 0 && dtFrom.Value <= dtTill.Value)
                xls.OutputBalance(currentBalance, dtFrom.Value, dtTill.Value);
        }

        private void FrmBalance_ResizeEnd(object sender, EventArgs e)
        {
            tableLayoutPanel1.ColumnStyles[1].Width =
                (tableLayoutPanel1.Width - tableLayoutPanel1.ColumnStyles[0].Width - tableLayoutPanel1.ColumnStyles[3].Width) / 2;
            tableLayoutPanel1.ColumnStyles[2].Width = tableLayoutPanel1.ColumnStyles[1].Width;
        }

        private void DgvBalance_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataSet details;
            dgvMinus.Rows.Clear();
            dgvPlus.Rows.Clear();
            long balanceNo = long.Parse(dgvBalance[0, e.RowIndex].Value.ToString());
            details = d.GetBalanceDetails(balanceNo);
            foreach (DataRow row in details.Tables[0].Rows)
            {
                if (row.Field<Int16>(0) == -1)
                    dgvMinus.Rows.Add(row[1], row[2], row[3]);
                else
                    dgvPlus.Rows.Add(row[1], row[2], row[3]);
            }
            if (e.ColumnIndex == 2)
            {
                parent.Cursor = Cursors.WaitCursor;
                frmManageBalance frm = new frmManageBalance((int)dgvBalance[0, e.RowIndex].Value);
                frm.MdiParent = this.parent;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void TreeObjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            long deviceID;
            DataSet rowSource;
            dgvPlus.Rows.Clear();
            dgvMinus.Rows.Clear();
            if (e.Node.Tag.ToString()[0] == 'D')
            {
                deviceID = long.Parse(e.Node.Tag.ToString().Substring(1));
                rowSource = d.GetBalanceList(deviceID);
                if (rowSource.Tables[0].Rows.Count > 0)
                {
                    dgvBalance.DataSource = rowSource;
                    dgvBalance.DataMember = rowSource.Tables[0].TableName;
                    dgvBalance.Columns[2].Width = 100;
                    dgvBalance.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvBalance.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgvBalance.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgvBalance.Columns[2].DefaultCellStyle.ForeColor = Color.Green;
                    dgvBalance.Columns[2].DefaultCellStyle.BackColor = SystemColors.Control;
                    dgvBalance.Columns[2].DefaultCellStyle.Font =
                        new Font("Arial", 12, FontStyle.Bold);
                    dgvBalance.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    DgvBalance_CellMouseClick(dgvBalance, new DataGridViewCellMouseEventArgs(0, 0, 0, 0,
                        new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0)));
                }
                else
                {
                    dgvBalance.DataMember = "";
                    dgvBalance.DataSource = "";
                    dgvBalance.Refresh();
                }
            }
            else
            {
                dgvBalance.DataMember = "";
                dgvBalance.DataSource = "";
                dgvBalance.Refresh();
            }
        }

        private void FrmBalance_Load(object sender, EventArgs e)
        {
            parent = (MainForm)(this.MdiParent);
            parent.Cursor = Cursors.Default;
            this.Cursor = Cursors.WaitCursor;
            d.PopulateDevices(treeObjects);
            this.Cursor = Cursors.Default;
            dtFrom.Value = DateTime.Today.AddDays(-1);
            dgvMinus.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            dgvPlus.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            currentBalance = -1;
        }

        private void toolList_Click(object sender, EventArgs e)
        {
            frmBalanceList frm = new frmBalanceList();
            frm.MdiParent = parent;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void toolAddNew_Click(object sender, EventArgs e)
        {
            if (parent.WriterConnectionString == string.Empty)
            {
                if (!parent.GetWriterAccess())
                {
                    MessageBox.Show("Недостаточно прав для добавления баланса.\n" +
                        "Обратитесь к администратору системы", "Вы не можете создавать балансы",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            if (!d.TestWriter(parent.WriterConnectionString))
            {
                MessageBox.Show("Недостаточно прав для добавления баланса\n" +
                    "Обратитесь к администратору системы", "Вы не можете создавать балансы",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            long newBalanceNo;
            newBalanceNo = d.CreateBalance(parent.WriterConnectionString);
            if (newBalanceNo < 0)
            {
                MessageBox.Show(newBalanceNo.ToString());
            }
            else
            {
                parent.Cursor = Cursors.WaitCursor;
                frmManageBalance frm = new frmManageBalance(newBalanceNo);
                frm.MdiParent = this.parent;
                frm.WindowState = FormWindowState.Maximized;
                frm.Show();
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (dgvBalance.CurrentRow == null)
                return;
            long balanceNo = long.Parse(dgvBalance.CurrentRow.Cells[0].Value.ToString());
            if (parent.WriterConnectionString == string.Empty)
            {
                if (!parent.GetWriterAccess())
                {
                    MessageBox.Show("Недостаточно прав для удаления баланса.\n" +
                        "Обратитесь к администратору системы", "Вы не можете удалять балансы",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            if (!d.TestWriter(parent.WriterConnectionString))
            {
                MessageBox.Show("Недостаточно прав для удаления баланса\n" +
                    "Обратитесь к администратору системы", "Вы не можете удалять балансы",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string message = string.Format("Вы собираетесь удалить следующий баланс:\n{0}",
                dgvBalance.CurrentRow.Cells[1].Value);
            DialogResult resp = MessageBox.Show(message, "Подтверждение удаления",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp == DialogResult.Yes)
            {
                if (d.DeleteBalance(balanceNo, parent.WriterConnectionString))
                {
                    MessageBox.Show("Баланс удалён успешно", "Удаление завершено", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TreeObjects_AfterSelect(treeObjects, 
                        new TreeViewEventArgs(treeObjects.SelectedNode, TreeViewAction.Unknown));
                }
                else
                {
                    MessageBox.Show("Не удалось удалить баланс", "Ошибка удаления", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
