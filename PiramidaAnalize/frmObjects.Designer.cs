/*
 * Created by SharpDevelop.
 * User: smke-ing3
 * Date: 04.03.2016
 * Time: 9:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PiramidaAnalize
{
	partial class frmObjects
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObjects));
            this.mainTree = new System.Windows.Forms.TreeView();
            this.dgvSensors = new System.Windows.Forms.DataGridView();
            this.txtDevice = new System.Windows.Forms.TextBox();
            this.txtDeviceCode = new System.Windows.Forms.TextBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabSensors = new System.Windows.Forms.TabPage();
            this.tabMap = new System.Windows.Forms.TabPage();
            this.dgvMap = new System.Windows.Forms.DataGridView();
            this.tabVals = new System.Windows.Forms.TabPage();
            this.opt101 = new System.Windows.Forms.RadioButton();
            this.opt12 = new System.Windows.Forms.RadioButton();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.tabChart = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cmdDeselectAll = new System.Windows.Forms.Button();
            this.cmdSelectAll = new System.Windows.Forms.Button();
            this.treeSensors = new System.Windows.Forms.TreeView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtDeviceID = new System.Windows.Forms.TextBox();
            this.calMap = new System.Windows.Forms.MonthCalendar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensors)).BeginInit();
            this.tabs.SuspendLayout();
            this.tabSensors.SuspendLayout();
            this.tabMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMap)).BeginInit();
            this.tabVals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.tabChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainTree
            // 
            this.mainTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.mainTree.FullRowSelect = true;
            this.mainTree.HideSelection = false;
            this.mainTree.Location = new System.Drawing.Point(12, 179);
            this.mainTree.Name = "mainTree";
            this.mainTree.PathSeparator = " => ";
            this.mainTree.Size = new System.Drawing.Size(243, 370);
            this.mainTree.TabIndex = 0;
            this.mainTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.MainTreeAfterSelect);
            // 
            // dgvSensors
            // 
            this.dgvSensors.AllowUserToAddRows = false;
            this.dgvSensors.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSensors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSensors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSensors.Location = new System.Drawing.Point(3, 3);
            this.dgvSensors.MultiSelect = false;
            this.dgvSensors.Name = "dgvSensors";
            this.dgvSensors.ReadOnly = true;
            this.dgvSensors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSensors.Size = new System.Drawing.Size(584, 479);
            this.dgvSensors.TabIndex = 0;
            // 
            // txtDevice
            // 
            this.txtDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDevice.Location = new System.Drawing.Point(394, 12);
            this.txtDevice.Name = "txtDevice";
            this.txtDevice.Size = new System.Drawing.Size(458, 20);
            this.txtDevice.TabIndex = 3;
            // 
            // txtDeviceCode
            // 
            this.txtDeviceCode.Location = new System.Drawing.Point(328, 12);
            this.txtDeviceCode.Name = "txtDeviceCode";
            this.txtDeviceCode.Size = new System.Drawing.Size(60, 20);
            this.txtDeviceCode.TabIndex = 2;
            this.txtDeviceCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.tabSensors);
            this.tabs.Controls.Add(this.tabMap);
            this.tabs.Controls.Add(this.tabVals);
            this.tabs.Controls.Add(this.tabChart);
            this.tabs.Location = new System.Drawing.Point(261, 38);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(598, 511);
            this.tabs.TabIndex = 4;
            this.tabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabs_Selected);
            // 
            // tabSensors
            // 
            this.tabSensors.Controls.Add(this.dgvSensors);
            this.tabSensors.Location = new System.Drawing.Point(4, 22);
            this.tabSensors.Name = "tabSensors";
            this.tabSensors.Padding = new System.Windows.Forms.Padding(3);
            this.tabSensors.Size = new System.Drawing.Size(590, 485);
            this.tabSensors.TabIndex = 0;
            this.tabSensors.Text = "Список каналов учёта";
            this.tabSensors.UseVisualStyleBackColor = true;
            // 
            // tabMap
            // 
            this.tabMap.Controls.Add(this.dgvMap);
            this.tabMap.Location = new System.Drawing.Point(4, 22);
            this.tabMap.Name = "tabMap";
            this.tabMap.Size = new System.Drawing.Size(590, 485);
            this.tabMap.TabIndex = 3;
            this.tabMap.Text = "Карта сбора";
            this.tabMap.UseVisualStyleBackColor = true;
            // 
            // dgvMap
            // 
            this.dgvMap.AllowUserToAddRows = false;
            this.dgvMap.AllowUserToDeleteRows = false;
            this.dgvMap.AllowUserToResizeColumns = false;
            this.dgvMap.AllowUserToResizeRows = false;
            this.dgvMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMap.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvMap.Location = new System.Drawing.Point(0, 0);
            this.dgvMap.Name = "dgvMap";
            this.dgvMap.ReadOnly = true;
            this.dgvMap.Size = new System.Drawing.Size(590, 485);
            this.dgvMap.TabIndex = 0;
            // 
            // tabVals
            // 
            this.tabVals.Controls.Add(this.opt101);
            this.tabVals.Controls.Add(this.opt12);
            this.tabVals.Controls.Add(this.dgvData);
            this.tabVals.Location = new System.Drawing.Point(4, 22);
            this.tabVals.Name = "tabVals";
            this.tabVals.Padding = new System.Windows.Forms.Padding(3);
            this.tabVals.Size = new System.Drawing.Size(590, 485);
            this.tabVals.TabIndex = 1;
            this.tabVals.Text = "Значения";
            this.tabVals.UseVisualStyleBackColor = true;
            // 
            // opt101
            // 
            this.opt101.AutoSize = true;
            this.opt101.Location = new System.Drawing.Point(124, 11);
            this.opt101.Name = "opt101";
            this.opt101.Size = new System.Drawing.Size(204, 17);
            this.opt101.TabIndex = 2;
            this.opt101.Text = "(101) Зафиксированные показания";
            this.opt101.UseVisualStyleBackColor = true;
            // 
            // opt12
            // 
            this.opt12.AutoSize = true;
            this.opt12.Checked = true;
            this.opt12.Location = new System.Drawing.Point(6, 11);
            this.opt12.Name = "opt12";
            this.opt12.Size = new System.Drawing.Size(112, 17);
            this.opt12.TabIndex = 1;
            this.opt12.TabStop = true;
            this.opt12.Text = "(12) Получасовки";
            this.opt12.UseVisualStyleBackColor = true;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "###";
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = "####";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvData.Location = new System.Drawing.Point(6, 34);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dgvData.RowTemplate.DefaultCellStyle.Format = "N2";
            this.dgvData.RowTemplate.DefaultCellStyle.NullValue = "---";
            this.dgvData.Size = new System.Drawing.Size(578, 445);
            this.dgvData.TabIndex = 0;
            // 
            // tabChart
            // 
            this.tabChart.BackColor = System.Drawing.SystemColors.Control;
            this.tabChart.Controls.Add(this.splitContainer1);
            this.tabChart.Location = new System.Drawing.Point(4, 22);
            this.tabChart.Name = "tabChart";
            this.tabChart.Size = new System.Drawing.Size(590, 485);
            this.tabChart.TabIndex = 2;
            this.tabChart.Text = "График";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cmdDeselectAll);
            this.splitContainer1.Panel1.Controls.Add(this.cmdSelectAll);
            this.splitContainer1.Panel1.Controls.Add(this.treeSensors);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart1);
            this.splitContainer1.Size = new System.Drawing.Size(590, 485);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 0;
            // 
            // cmdDeselectAll
            // 
            this.cmdDeselectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdDeselectAll.Location = new System.Drawing.Point(129, 3);
            this.cmdDeselectAll.Name = "cmdDeselectAll";
            this.cmdDeselectAll.Size = new System.Drawing.Size(95, 22);
            this.cmdDeselectAll.TabIndex = 2;
            this.cmdDeselectAll.Text = "Очистить всё";
            this.cmdDeselectAll.UseVisualStyleBackColor = true;
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.Location = new System.Drawing.Point(3, 3);
            this.cmdSelectAll.Name = "cmdSelectAll";
            this.cmdSelectAll.Size = new System.Drawing.Size(95, 22);
            this.cmdSelectAll.TabIndex = 1;
            this.cmdSelectAll.Text = "Выделить всё";
            this.cmdSelectAll.UseVisualStyleBackColor = true;
            // 
            // treeSensors
            // 
            this.treeSensors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeSensors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeSensors.CheckBoxes = true;
            this.treeSensors.HideSelection = false;
            this.treeSensors.Location = new System.Drawing.Point(0, 31);
            this.treeSensors.Name = "treeSensors";
            this.treeSensors.ShowLines = false;
            this.treeSensors.ShowPlusMinus = false;
            this.treeSensors.ShowRootLines = false;
            this.treeSensors.Size = new System.Drawing.Size(224, 454);
            this.treeSensors.TabIndex = 0;
            this.treeSensors.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeSensors_AfterCheck);
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(359, 485);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.BackColor = System.Drawing.SystemColors.Control;
            this.txtDeviceID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeviceID.Location = new System.Drawing.Point(262, 15);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(62, 13);
            this.txtDeviceID.TabIndex = 1;
            this.txtDeviceID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // calMap
            // 
            this.calMap.Location = new System.Drawing.Point(12, 12);
            this.calMap.Name = "calMap";
            this.calMap.TabIndex = 1;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "iconBlack.png");
            this.imageList1.Images.SetKeyName(1, "iconRed.png");
            this.imageList1.Images.SetKeyName(2, "iconBlue.png");
            this.imageList1.Images.SetKeyName(3, "iconLime.png");
            this.imageList1.Images.SetKeyName(4, "iconViolet.png");
            this.imageList1.Images.SetKeyName(5, "iconAzure.png");
            this.imageList1.Images.SetKeyName(6, "iconOrange.png");
            this.imageList1.Images.SetKeyName(7, "iconGreen.png");
            this.imageList1.Images.SetKeyName(8, "iconPurple.png");
            this.imageList1.Images.SetKeyName(9, "iconSwamp.png");
            // 
            // frmObjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 571);
            this.Controls.Add(this.calMap);
            this.Controls.Add(this.txtDeviceID);
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.txtDeviceCode);
            this.Controls.Add(this.txtDevice);
            this.Controls.Add(this.mainTree);
            this.Name = "frmObjects";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Объекты в Пирамиде";
            this.Load += new System.EventHandler(this.FrmObjectsLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensors)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tabSensors.ResumeLayout(false);
            this.tabMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMap)).EndInit();
            this.tabVals.ResumeLayout(false);
            this.tabVals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.tabChart.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.TextBox txtDevice;
		private System.Windows.Forms.DataGridView dgvSensors;
		private System.Windows.Forms.TreeView mainTree;
        private System.Windows.Forms.TextBox txtDeviceCode;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabSensors;
        private System.Windows.Forms.TabPage tabVals;
        private System.Windows.Forms.TabPage tabChart;
        private System.Windows.Forms.TabPage tabMap;
        private System.Windows.Forms.TextBox txtDeviceID;
        private System.Windows.Forms.DataGridView dgvMap;
        private System.Windows.Forms.MonthCalendar calMap;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TreeView treeSensors;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button cmdDeselectAll;
        private System.Windows.Forms.Button cmdSelectAll;
        private System.Windows.Forms.RadioButton opt101;
        private System.Windows.Forms.RadioButton opt12;
    }
}
