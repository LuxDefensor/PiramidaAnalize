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
    public partial class frmBalanceList: Form
    {
        private DataProvider d;
        private XLSExport xls;
        private MainForm parent;
        private bool dirty = false;

        public frmBalanceList()
        {
            InitializeComponent();
            d = new DataProvider();
            xls = new XLSExport();
            this.Load += FrmBalanceList_Load;
            dgvBalances.CurrentCellDirtyStateChanged += DgvBalances_CurrentCellDirtyStateChanged;
        }

        private void DgvBalances_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dirty = !dirty;
            if (dirty && dgvBalances.CurrentCell.ColumnIndex == 2)
            {
                bool newState =
                    d.ToggleBalanceSelection((int)dgvBalances[0, dgvBalances.CurrentCell.RowIndex].Value);
                dgvBalances.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            dgvBalances.EndEdit();
        }

        private void FrmBalanceList_Load(object sender, EventArgs e)
        {
            parent = (MainForm)(this.MdiParent);
            dtFrom.Value = DateTime.Today.AddDays(-1);
            Requery();
        }

        private void toolSelectAll_Click(object sender, EventArgs e)
        {
            
            d.SelectAllBalances(true);
            Requery();
        }

        private void toolToggleAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvBalances.Rows)
            {
                bool newState = d.ToggleBalanceSelection((int)dgvBalances[0, row.Index].Value);
            }
            Requery();
        }

        private void Requery()
        {
            System.Data.DataSet rowSource = d.GetAllBalances(false);
            rowSource.Tables[0].Columns[0].ReadOnly = true;
            rowSource.Tables[0].Columns[1].ReadOnly = true;
            rowSource.Tables[0].Columns[2].ReadOnly = false; // Флажки
            dgvBalances.DataSource = rowSource;
            dgvBalances.DataMember = rowSource.Tables[0].TableName;
            dgvBalances.Columns[0].HeaderText = "Код";
            dgvBalances.Columns[1].HeaderText = "Название баланса";
            dgvBalances.Columns[2].HeaderText = "Выбрать";
            dgvBalances.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void toolDeselectAll_Click(object sender, EventArgs e)
        {
            d.SelectAllBalances(false);
            Requery();
        }

        private void toolExcel_Click(object sender, EventArgs e)
        {
            if (dtFrom.Value > dtTill.Value)
                return;
            System.Globalization.CultureInfo cultureUS = System.Globalization.CultureInfo.GetCultureInfo("en-US");
            System.Globalization.CultureInfo cultureCurrent = System.Globalization.CultureInfo.CurrentCulture;
            double threshold = 1;
            if (toolMaxPercent.Text != null)
            {
                if (!double.TryParse(toolMaxPercent.Text,
                                     System.Globalization.NumberStyles.Float,
                                     cultureCurrent.NumberFormat,
                                     out threshold))
                    double.TryParse(toolMaxPercent.Text,
                                    System.Globalization.NumberStyles.Float,
                                    cultureUS.NumberFormat,
                                    out threshold);
            }
            xls.OutputBalanceList(dtFrom.Value, dtTill.Value, threshold);                    
        }

    }
}
