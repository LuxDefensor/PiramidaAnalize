/*
 * Created by SharpDevelop.
 * User: smke-ing3
 * Date: 04.03.2016
 * Time: 13:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;
using System.Drawing.Printing;

namespace PiramidaAnalize
{
	/// <summary>
	/// Description of frmAnalize.
	/// </summary>
	public partial class frmAnalize : Form
	{
		private DataProvider d;
        private MainForm parent;
        private Color[] colors = new Color[22];
        private System.Data.DataSet dsPlots;
		
		public frmAnalize()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			d=new DataProvider();
            dsPlots = new DataSet();
            DataTable tb = new System.Data.DataTable("Plots");
            tb.Columns.Add(new System.Data.DataColumn("selected", true.GetType()));
            tb.Columns.Add(new System.Data.DataColumn("plots","".GetType()));
            tb.Columns.Add(new System.Data.DataColumn("colors","".GetType()));
            dsPlots.Tables.Add(tb);

            #region Define colors
            colors[0] = Color.Black;
            colors[1] = Color.Aqua;
            colors[2] = Color.Blue;
            colors[3] = Color.Coral;
            colors[4] = Color.Brown;
            colors[5] = Color.Chartreuse;
            colors[6] = Color.Crimson;
            colors[7] = Color.CornflowerBlue;
            colors[8] = Color.DarkCyan;
            colors[9] = Color.DarkMagenta;
            colors[10] = Color.Orange;
            colors[11] = Color.DarkOliveGreen;
            colors[12] = Color.DarkSalmon;
            colors[13] = Color.Green;
            colors[14] = Color.Gold;
            colors[15] = Color.DarkRed;
            colors[16] = Color.Lime;
            colors[17] = Color.Magenta;
            colors[18] = Color.OrangeRed;
            colors[19] = Color.RoyalBlue;
            colors[20] = Color.YellowGreen;
            colors[21] = Color.Red;
            #endregion
        }
		
		void FrmAnalizeLoad(object sender, EventArgs e)
		{
            dgvLegend.DataSource = dsPlots;
            dgvLegend.DataMember = "Plots";
            dgvLegend.Columns[0].HeaderText = "х";
            dgvLegend.Columns[1].HeaderText = "Графики";
            dgvLegend.Columns[2].HeaderText = "Цвет";            
            dgvLegend.Columns[0].Width = 20;
            //dgvLegend.Columns[1].Width = (int)(dgvLegend.Width * 0.8);
            dgvLegend.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLegend.Columns[2].Width = 50;
            dgvLegend.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLegend.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvLegend.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            parent = (MainForm)this.MdiParent;
            this.Size=this.MdiParent.ClientSize;
			this.Refresh();
            d.PopulateTree(mainTree, treeIcons);
			cal1.SetDate(cal1.TodayDate.AddDays(-2));
			cal2.SetDate(cal2.TodayDate.AddDays(-1));
            parent.Cursor = Cursors.Default;
		}

        void MainTreeAfterSelect(object sender, TreeViewEventArgs e)
        {            
        	UpdateForms();
        }

        void DgvSensorsMouseClick(object sender, MouseEventArgs e)
        {
            if (dgvSensors.CurrentRow == null) return;            
            string grafikName;
            Series grafik = new Series();
            string stringSensorID = mainTree.SelectedNode.Tag.ToString().Substring(1);
            long sensorID;
            long.TryParse(stringSensorID, out sensorID);
            DateTime theDay;
            DateTime.TryParse(dgvSensors.CurrentRow.Cells[0].Value.ToString(), out theDay);
            grafikName = d.GetName("Sensor", stringSensorID) + " " + theDay.ToString("yyyy-MM-dd");            
            DataSet dsTemp = d.DrawDayGraph(sensorID, theDay);
            //grafik.Points.DataBindY(dsTemp.Tables[0].Rows, "value0");            
            grafik.Points.DataBindXY(dsTemp.Tables[0].Rows, "time", dsTemp.Tables[0].Rows, "value0");
            grafik.Name = grafikName;
            grafik.Color = colors[chart1.Series.Count % colors.GetLength(0)];
            grafik.BorderWidth = 2;
            grafik.ChartType = SeriesChartType.Line;
            grafik.ChartArea = "ChartArea1";
            //chart1.ChartAreas["ChartArea1"].AxisX.CustomLabels.Add(4, DateTimeIntervalType.Hours);
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 2;
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.Interval = 6;
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.TruncatedLabels = true;
            //chart1.ChartAreas["ChartArea1"].AxisY.Title = "кВт";
            //chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Verdana", 12);
            //chart1.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Far;
            //chart1.ChartAreas["ChartArea1"].AxisY.TextOrientation = TextOrientation.Horizontal;
            try
            {
                chart1.Series.Add(grafik);
            }
            catch
            {
                //already exists
                
            }

            dsPlots.Tables["Plots"].Clear();
            foreach (Series s in chart1.Series)
            {
                DataRow r = dsPlots.Tables["Plots"].NewRow();
                r[0] = true;
                r[1] = s.Name;
                dsPlots.Tables["Plots"].Rows.Add(r);
                dgvLegend.Rows[dgvLegend.Rows.Count - 1].Cells[2].Style.BackColor = s.Color;
            }
        }

        private void dgvLegend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLegend.EndEdit();
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                //dgvLegend.CommitEdit(DataGridViewDataErrorContexts.Commit);
                chart1.Series[e.RowIndex].ChartArea = (bool)(dgvLegend[e.ColumnIndex, e.RowIndex].Value) ? "ChartArea1" : "";
            }            
        }

        private void toolClear_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            dsPlots.Tables[0].Clear();
        }
		
		private void UpdateForms()
		{
            this.Cursor = Cursors.WaitCursor;
            if (mainTree.SelectedNode!=null && 
			    mainTree.SelectedNode.Tag.ToString().Substring(0, 1) == "S")
            {
                string stringSensorID = mainTree.SelectedNode.Tag.ToString().Substring(1);
                long sensorID;
                long.TryParse(stringSensorID, out sensorID);
                d.ProfileForms(dgvSensors, sensorID, cal1.SelectionStart, cal2.SelectionStart);
                lblCurrent.Text = mainTree.SelectedNode.FullPath;
            }
            else
            {
                dgvSensors.DataMember = "";
                dgvSensors.DataSource = "";
                lblCurrent.Text = "";
            }
            this.Cursor = Cursors.Default;
		}

        private void cal2_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtCal2.Text = cal2.SelectionStart.ToShortDateString();
            UpdateForms();
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            PrintDialog dlgPrint = new PrintDialog();
            dlgPrint.Document = doc;
            //dlgPrint.PrinterSettings.DefaultPageSettings.Landscape = true;
            if (dlgPrint.ShowDialog() == DialogResult.OK)
            {                
                doc.PrinterSettings = dlgPrint.PrinterSettings;
                doc.DocumentName = string.Format("Суточные профили {0}", DateTime.Today);
                
                try
                {
                    doc.Print();                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }                                       
            }
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            /*
            e.Graphics.Clip = new Region(new RectangleF(0, 0, (chart1.Width + 10) , table1.Height));
            //e.Graphics.PageUnit = GraphicsUnit.Display;
            e.Graphics.CopyFromScreen(new Point(chart1.Left - 5, chart1.Top),
                                      Point.Empty,
                                      new Size((int)e.Graphics.ClipBounds.Width, (int)e.Graphics.ClipBounds.Height));
            e.Graphics.ScaleTransform(90f / 600, 90f / 600);
            */
            Image im;
            Bitmap bmp;
            bmp = new Bitmap(4000, 6500);            
            chart1.DrawToBitmap(bmp, new Rectangle(0, 0, chart1.Width, chart1.Height));            
            im = Image.FromHbitmap(bmp.GetHbitmap());

            e.Graphics.DrawImage(im,
                new Rectangle(0, 0, e.PageBounds.Width - 40, chart1.Height),
                new Rectangle(0, 0, chart1.Width, chart1.Height), GraphicsUnit.Pixel);
            bmp.Dispose();
            bmp = new Bitmap(4000, 6500);
            dgvLegend.DrawToBitmap(bmp, new Rectangle(0, 0, dgvLegend.Width, dgvLegend.Height));
            im = Image.FromHbitmap(bmp.GetHbitmap());
            e.Graphics.DrawImage(im, 0, chart1.Height + 10, 
                new Rectangle(0, 0, dgvLegend.Width, dgvLegend.Height), GraphicsUnit.Pixel);
            e.Graphics.ScaleTransform(0.5f, 1);
            im.Dispose();
            bmp.Dispose();
        }

        private void cal1_DateChanged(object sender, DateRangeEventArgs e)
        {
            txtCal1.Text = cal1.SelectionStart.ToShortDateString();
        }
    }
}
