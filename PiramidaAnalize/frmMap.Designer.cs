namespace PiramidaAnalize
{
    partial class frmMap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMap));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.treeObjects = new System.Windows.Forms.TreeView();
            this.dgvMap = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolChooseParam = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolInterval = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdGo = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolCurrentObject = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.dtpMap = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMap)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.treeObjects, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dgvMap, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtpMap, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(879, 519);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // treeObjects
            // 
            this.treeObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeObjects.FullRowSelect = true;
            this.treeObjects.HideSelection = false;
            this.treeObjects.Location = new System.Drawing.Point(3, 69);
            this.treeObjects.Name = "treeObjects";
            this.treeObjects.PathSeparator = " => ";
            this.treeObjects.Size = new System.Drawing.Size(294, 427);
            this.treeObjects.TabIndex = 0;
            this.treeObjects.TabStop = false;
            this.treeObjects.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeObjects_AfterSelect);
            // 
            // dgvMap
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMap.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMap.Location = new System.Drawing.Point(303, 29);
            this.dgvMap.Name = "dgvMap";
            this.dgvMap.RowHeadersVisible = false;
            this.tableLayoutPanel1.SetRowSpan(this.dgvMap, 2);
            this.dgvMap.Size = new System.Drawing.Size(573, 467);
            this.dgvMap.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolChooseParam,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.toolInterval,
            this.toolStripSeparator1,
            this.cmdGo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(879, 26);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(167, 23);
            this.toolStripLabel1.Text = "Показывать сбор параметра:";
            // 
            // toolChooseParam
            // 
            this.toolChooseParam.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.toolChooseParam.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolChooseParam.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolChooseParam.Items.AddRange(new object[] {
            "12 - Получасовки",
            "101 - Зафиксированные показания"});
            this.toolChooseParam.Name = "toolChooseParam";
            this.toolChooseParam.Size = new System.Drawing.Size(200, 26);
            this.toolChooseParam.Text = "12 - Получасовки";
            this.toolChooseParam.Validating += new System.ComponentModel.CancelEventHandler(this.toolChooseParam_Validating);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(60, 23);
            this.toolStripLabel2.Text = "Интервал";
            // 
            // toolInterval
            // 
            this.toolInterval.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.toolInterval.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.toolInterval.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toolInterval.Items.AddRange(new object[] {
            "День",
            "Неделя",
            "Месяц",
            "Год"});
            this.toolInterval.Name = "toolInterval";
            this.toolInterval.Size = new System.Drawing.Size(84, 26);
            this.toolInterval.Text = "Месяц";
            this.toolInterval.Validating += new System.ComponentModel.CancelEventHandler(this.toolInterval_Validating);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // cmdGo
            // 
            this.cmdGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdGo.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdGo.ForeColor = System.Drawing.Color.Red;
            this.cmdGo.Image = ((System.Drawing.Image)(resources.GetObject("cmdGo.Image")));
            this.cmdGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.Size = new System.Drawing.Size(23, 23);
            this.cmdGo.Text = "!";
            this.cmdGo.ToolTipText = "Построить карту сбора";
            // 
            // statusStrip1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.statusStrip1, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolCurrentObject,
            this.toolStripStatusLabel2,
            this.toolProgressLabel,
            this.toolProgressBar});
            this.statusStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusStrip1.Location = new System.Drawing.Point(0, 499);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(879, 20);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(101, 15);
            this.toolStripStatusLabel1.Text = "Текущий объект:";
            // 
            // toolCurrentObject
            // 
            this.toolCurrentObject.MergeIndex = 1;
            this.toolCurrentObject.Name = "toolCurrentObject";
            this.toolCurrentObject.Size = new System.Drawing.Size(0, 15);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripStatusLabel2.ForeColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(30, 15);
            // 
            // toolProgressLabel
            // 
            this.toolProgressLabel.Name = "toolProgressLabel";
            this.toolProgressLabel.Size = new System.Drawing.Size(149, 15);
            this.toolProgressLabel.Text = "Построение карты сбора:";
            this.toolProgressLabel.Visible = false;
            // 
            // toolProgressBar
            // 
            this.toolProgressBar.Name = "toolProgressBar";
            this.toolProgressBar.Size = new System.Drawing.Size(200, 14);
            this.toolProgressBar.Step = 1;
            this.toolProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.toolProgressBar.Visible = false;
            // 
            // dtpMap
            // 
            this.dtpMap.CustomFormat = "dd MMMM yyyy (dddd)";
            this.dtpMap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpMap.Location = new System.Drawing.Point(40, 36);
            this.dtpMap.Margin = new System.Windows.Forms.Padding(40, 10, 3, 3);
            this.dtpMap.Name = "dtpMap";
            this.dtpMap.Size = new System.Drawing.Size(200, 20);
            this.dtpMap.TabIndex = 4;
            // 
            // frmMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 519);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmMap";
            this.ShowInTaskbar = false;
            this.Text = "Карта сбора";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMap)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeObjects;
        private System.Windows.Forms.DataGridView dgvMap;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolCurrentObject;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox toolChooseParam;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolInterval;
        private System.Windows.Forms.DateTimePicker dtpMap;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolProgressLabel;
        private System.Windows.Forms.ToolStripProgressBar toolProgressBar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton cmdGo;
    }
}