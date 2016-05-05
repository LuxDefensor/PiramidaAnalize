/*
 * Created by SharpDevelop.
 * User: smke-ing3
 * Date: 04.03.2016
 * Time: 13:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PiramidaAnalize
{
	partial class frmAnalize
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnalize));
            this.dgvSensors = new System.Windows.Forms.DataGridView();
            this.mainTree = new System.Windows.Forms.TreeView();
            this.cal1 = new System.Windows.Forms.MonthCalendar();
            this.cal2 = new System.Windows.Forms.MonthCalendar();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvLegend = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolClear = new System.Windows.Forms.ToolStripButton();
            this.toolPrint = new System.Windows.Forms.ToolStripButton();
            this.treeIcons = new System.Windows.Forms.ImageList(this.components);
            this.txtCal1 = new System.Windows.Forms.TextBox();
            this.txtCal2 = new System.Windows.Forms.TextBox();
            this.table1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegend)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.table1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSensors
            // 
            this.dgvSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table1.SetColumnSpan(this.dgvSensors, 2);
            this.dgvSensors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSensors.Location = new System.Drawing.Point(3, 393);
            this.dgvSensors.MultiSelect = false;
            this.dgvSensors.Name = "dgvSensors";
            this.table1.SetRowSpan(this.dgvSensors, 2);
            this.dgvSensors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSensors.Size = new System.Drawing.Size(474, 155);
            this.dgvSensors.TabIndex = 5;
            this.dgvSensors.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DgvSensorsMouseClick);
            // 
            // mainTree
            // 
            this.mainTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTree.FullRowSelect = true;
            this.mainTree.HideSelection = false;
            this.mainTree.Location = new System.Drawing.Point(3, 3);
            this.mainTree.Name = "mainTree";
            this.mainTree.PathSeparator = "=>";
            this.table1.SetRowSpan(this.mainTree, 4);
            this.mainTree.Size = new System.Drawing.Size(294, 384);
            this.mainTree.TabIndex = 4;
            this.mainTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTreeAfterSelect);
            // 
            // cal1
            // 
            this.cal1.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.cal1.Location = new System.Drawing.Point(309, 9);
            this.cal1.Name = "cal1";
            this.cal1.ShowTodayCircle = false;
            this.cal1.TabIndex = 7;
            this.cal1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cal1_DateChanged);
            // 
            // cal2
            // 
            this.cal2.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.cal2.Location = new System.Drawing.Point(309, 204);
            this.cal2.Name = "cal2";
            this.cal2.ShowTodayCircle = false;
            this.cal2.TabIndex = 8;
            this.cal2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.cal2_DateChanged);
            // 
            // chart1
            // 
            this.chart1.BorderlineColor = System.Drawing.Color.Black;
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea3.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea3.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(483, 3);
            this.chart1.Name = "chart1";
            this.table1.SetRowSpan(this.chart1, 5);
            this.chart1.Size = new System.Drawing.Size(423, 295);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            // 
            // dgvLegend
            // 
            this.dgvLegend.AllowUserToAddRows = false;
            this.dgvLegend.AllowUserToDeleteRows = false;
            this.dgvLegend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLegend.Location = new System.Drawing.Point(483, 304);
            this.dgvLegend.Name = "dgvLegend";
            this.dgvLegend.Size = new System.Drawing.Size(423, 244);
            this.dgvLegend.TabIndex = 10;
            this.dgvLegend.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLegend_CellBeginEdit);
            this.dgvLegend.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLegend_CellContentClick);
            this.dgvLegend.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLegend_CellValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolClear,
            this.toolPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(909, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolClear
            // 
            this.toolClear.Image = global::PiramidaAnalize.Properties.Resources.Delete;
            this.toolClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClear.Name = "toolClear";
            this.toolClear.Size = new System.Drawing.Size(122, 22);
            this.toolClear.Text = "Очистить график";
            this.toolClear.Click += new System.EventHandler(this.toolClear_Click);
            // 
            // toolPrint
            // 
            this.toolPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolPrint.Image = global::PiramidaAnalize.Properties.Resources._16_16_04_shell32_dll_00128;
            this.toolPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolPrint.Name = "toolPrint";
            this.toolPrint.Size = new System.Drawing.Size(23, 22);
            this.toolPrint.Text = "Печать";
            this.toolPrint.Click += new System.EventHandler(this.toolPrint_Click);
            // 
            // treeIcons
            // 
            this.treeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeIcons.ImageStream")));
            this.treeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.treeIcons.Images.SetKeyName(0, "32.32.04.shell32.dll.00030.ico");
            this.treeIcons.Images.SetKeyName(1, "32.32.04.shell32.dll.00068.ico");
            this.treeIcons.Images.SetKeyName(2, "Meter.ico");
            // 
            // txtCal1
            // 
            this.txtCal1.BackColor = System.Drawing.SystemColors.Control;
            this.txtCal1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCal1.Location = new System.Drawing.Point(303, 173);
            this.txtCal1.Name = "txtCal1";
            this.txtCal1.Size = new System.Drawing.Size(174, 20);
            this.txtCal1.TabIndex = 13;
            this.txtCal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCal2
            // 
            this.txtCal2.BackColor = System.Drawing.SystemColors.Control;
            this.txtCal2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCal2.Location = new System.Drawing.Point(303, 368);
            this.txtCal2.Name = "txtCal2";
            this.txtCal2.Size = new System.Drawing.Size(174, 20);
            this.txtCal2.TabIndex = 14;
            this.txtCal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // table1
            // 
            this.table1.ColumnCount = 3;
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table1.Controls.Add(this.cal1, 1, 0);
            this.table1.Controls.Add(this.mainTree, 0, 0);
            this.table1.Controls.Add(this.txtCal2, 1, 3);
            this.table1.Controls.Add(this.chart1, 2, 0);
            this.table1.Controls.Add(this.txtCal1, 1, 1);
            this.table1.Controls.Add(this.cal2, 1, 2);
            this.table1.Controls.Add(this.dgvSensors, 0, 4);
            this.table1.Controls.Add(this.dgvLegend, 2, 5);
            this.table1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table1.Location = new System.Drawing.Point(0, 25);
            this.table1.Name = "table1";
            this.table1.RowCount = 6;
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.table1.Size = new System.Drawing.Size(909, 551);
            this.table1.TabIndex = 15;
            // 
            // frmAnalize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 576);
            this.Controls.Add(this.table1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmAnalize";
            this.ShowInTaskbar = false;
            this.Text = "Анализ профиля";
            this.Load += new System.EventHandler(this.FrmAnalizeLoad);
            this.ResizeEnd += new System.EventHandler(this.FrmAnalizeResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLegend)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.table1.ResumeLayout(false);
            this.table1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.MonthCalendar cal2;
		private System.Windows.Forms.MonthCalendar cal1;
		private System.Windows.Forms.TreeView mainTree;
        private System.Windows.Forms.DataGridView dgvSensors;
        private System.Windows.Forms.DataGridView dgvLegend;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolClear;
        private System.Windows.Forms.ImageList treeIcons;
        private System.Windows.Forms.TextBox txtCal1;
        private System.Windows.Forms.TextBox txtCal2;
        private System.Windows.Forms.ToolStripButton toolPrint;
        private System.Windows.Forms.TableLayoutPanel table1;
    }
}
