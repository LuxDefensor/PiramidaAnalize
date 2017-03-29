using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace PiramidaAnalize
{
    public partial class frmOutput : Form
    {
        private MainForm parent;
        private DataProvider d;
        private XLSExport xls;
        private bool callTreeEventsRecursively = true;
        private List<string> selected;
        private char[] invalidChars = Path.GetInvalidFileNameChars();
        private string presetFolder;
        private string[] presetsComment = new string[] {"# Этот файл относится к системе Пирамида 2000",
                                "# Он используется программой PirammidaAnalize",
                                "# для хранения наборов измерительных каналов.",
                                "# Не удалять!",
                                "######################################################################"};

        public frmOutput()
        {
            InitializeComponent();
        }

        private void frmOutput_Load(object sender, EventArgs e)
        {
            presetFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
            parent = (MainForm)(this.MdiParent);
            parent.Cursor = Cursors.Default;
            d = new DataProvider();
            xls = new XLSExport();
            this.Refresh();
            this.Cursor = Cursors.WaitCursor;
            d.PopulateTree(treeObjects, treeIcons);
            LoadPresets();
            cal1.SetDate(cal1.TodayDate.AddDays(-2));
            cal2.SetDate(cal2.TodayDate.AddDays(-1));
            this.Cursor = Cursors.Default;
        }

        #region Presets

        private void LstPresets_DoubleClick(object sender, EventArgs e)
        {
            string fileName;
            TreeNode[] found;
            if (lstPresets.SelectedIndex >= 0)
            {
                this.Cursor = Cursors.WaitCursor;
                treeObjects.CollapseAll();
                fileName = Path.Combine(presetFolder, lstPresets.SelectedItem.ToString() + ".pst");
                if (File.Exists(fileName))
                {
                    mnuClearAll_Click(sender, e);
                    selected = new List<string>(File.ReadAllLines(fileName).Where(s => s[0] != '#'));
                    callTreeEventsRecursively = false;
                    foreach (string node in selected)
                    {
                        found = treeObjects.Nodes.Find("S" + node, true);
                        if (found.Length == 1)
                            found[0].Checked = true;
                    }
                    found = treeObjects.Nodes.Find("S" + selected[0], true);
                    if (found.Length == 1)
                        found[0].EnsureVisible();
                    txtSelected.Text = CountNodes(treeObjects.Nodes[0]).ToString();
                    callTreeEventsRecursively = true;
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void BtnDeletePreset_Click(object sender, EventArgs e)
        {
            string fileName;
            if (lstPresets.SelectedIndex >= 0)
            {
                fileName = Path.Combine(presetFolder, lstPresets.SelectedItem.ToString() + ".pst");
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                    lstPresets.Items.RemoveAt(lstPresets.SelectedIndex);
                }
            }
        }

        private void BtnSavePreset_Click(object sender, EventArgs e)
        {
            string presetName;
            StringBuilder fileName;
            string filePath;
            frmInputBox dlg = new frmInputBox("Введите название набора", "");
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                presetName = dlg.Result;
                fileName = new StringBuilder(presetName.Length + 4);
                foreach (char c in presetName)
                    if (invalidChars.Contains(c))
                        fileName.Append("_");
                    else
                        fileName.Append(c);
                if (fileName.Length < 1)
                    fileName.Append(DateTime.Now.ToString("yyyyMMdd_HHmmss"));
                filePath = Path.Combine(presetFolder, fileName.ToString() + ".pst");
                if (File.Exists(filePath))
                {
                    MessageBox.Show(this, "Набор с именем " + presetName + " уже существует" +
                        Environment.NewLine + "Необходимо ввести уникальное название набора",
                        "Такой набор уже существует", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                selected = new List<string>(presetsComment);
                selected.AddRange(d.GetSelectedSensors(treeObjects.Nodes[0]).Select(n => n.ToString()));
                File.WriteAllLines(filePath, selected.ToArray());
                lstPresets.Items.Add(fileName);
            }
        }
        private void LoadPresets()
        {
            string[] presets = Directory.EnumerateFiles(presetFolder, "*.pst").ToArray();
            if (presets.Length > 0)
            {
                foreach (string s in presets)
                    lstPresets.Items.Add(Path.GetFileNameWithoutExtension(s));
            }
        }

        #endregion

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
