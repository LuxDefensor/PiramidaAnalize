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
    public partial class frmOutput : Form
    {
        private MainForm parent;
        private DataProvider d;
        private XLSExport xls;
        private bool callTreeEventsRecursively = true;

        public frmOutput()
        {
            InitializeComponent();
        }

        private void frmOutput_Load(object sender, EventArgs e)
        {
            parent = (MainForm)(this.MdiParent);
            parent.Cursor = Cursors.Default;
            d = new DataProvider();
            xls = new XLSExport();
            this.Refresh();
            this.Cursor = Cursors.WaitCursor;
            d.PopulateTree(treeObjects, treeIcons);
            cal1.SetDate(cal1.TodayDate.AddDays(-2));
            cal2.SetDate(cal2.TodayDate.AddDays(-1));
            this.Cursor = Cursors.Default;
            
        }

        private void treeObjects_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (callTreeEventsRecursively)
            {
                this.Cursor = Cursors.WaitCursor;
                if (e.Node.Nodes.Count > 0)
                    foreach (TreeNode n in e.Node.Nodes)
                        n.Checked = !n.Checked;
                int count = 0;
                foreach (TreeNode n in treeObjects.Nodes)
                    count += CountNodes(n);
                txtSelected.Text = count.ToString();
                this.Cursor = Cursors.Default;
            }
        }

        private int CountNodes(TreeNode root)
        {
            int result = 0;
            foreach (TreeNode n in root.Nodes)
            {
                if (n.Checked && n.Tag.ToString()[0]=='S') result++;
                result += CountNodes(n);
            }
            return result;
        }

        private void toolOutput_Click(object sender, EventArgs e)
        {
            if (txtSelected.Text != "0")
            {
                if (cal1.SelectionStart <= cal2.SelectionStart)
                {
                    if (lstTemplates.SelectedItem != null)
                    {
                    	List<long> selectedSensors = d.GetSelectedSensors(treeObjects.Nodes[0]);
                        switch (lstTemplates.SelectedItem.ToString())
                        {                                 
                            case "Получасовки":
                                {
                                    xls.OutputHalves(selectedSensors, cal1.SelectionStart, cal2.SelectionStart);            
                                    break;
                                }
                            case "Получасовки + Часовки":
                                {
                                    xls.OutputHalvesPlusHours(selectedSensors, cal1.SelectionStart, cal2.SelectionStart);
                                    break;
                                }
                            case "Потребление за период (12)":
                                {
                                    xls.OutputConsumption(selectedSensors, cal1.SelectionStart, cal2.SelectionStart);
                                    break;
                                }
                            case "Потребление посуточно (12)":
                                {
                                    xls.OutputConsumptionDaily(selectedSensors, cal1.SelectionStart, cal2.SelectionStart);
                                    break;
                                }
                            case "Зафиксированные показания":
                                {
                                    xls.OutputFixed(selectedSensors, cal1.SelectionStart, cal2.SelectionStart);
                                    break;
                                }
                            case "Показания попарно":
                                {
                                    xls.OutputPair(selectedSensors, cal1.SelectionStart, cal2.SelectionStart);
                                    break;
                                }
                            case "Сверка показаний с получасовками":
                                {
                                    xls.OutputCompare(selectedSensors, cal1.SelectionStart, cal2.SelectionStart);
                                    break;
                                }
                        }                        
                    }
                }
            }
        }
        
        void Cal1DateChanged(object sender, DateRangeEventArgs e)
        {
        	txtCal1.Text = cal1.SelectionStart.ToShortDateString();
        }
        
        void Cal2DateChanged(object sender, DateRangeEventArgs e)
        {
        	txtCal2.Text = cal2.SelectionStart.ToShortDateString();
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            callTreeEventsRecursively = false;
            recursiveSelection(treeObjects.Nodes[0], true);
            callTreeEventsRecursively = true;
            txtSelected.Text = CountNodes(treeObjects.Nodes[0]).ToString();
            this.Cursor = Cursors.Default;
        }

        private void mnuClearAll_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            callTreeEventsRecursively = false;
            recursiveSelection(treeObjects.Nodes[0], false);
            callTreeEventsRecursively = true;
            txtSelected.Text = "0";
            this.Cursor = Cursors.Default;
        }

        private void InvertAll_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            foreach (TreeNode n in treeObjects.Nodes)
                n.Checked = false;
            txtSelected.Text = CountNodes(treeObjects.Nodes[0]).ToString();
            this.Cursor = Cursors.Default; 
        }

        private void recursiveSelection(TreeNode root, bool markChecked)
        {
            root.Checked = markChecked;
            foreach (TreeNode n in root.Nodes)
            {
                recursiveSelection(n, markChecked);
            }
        }
    }
}
