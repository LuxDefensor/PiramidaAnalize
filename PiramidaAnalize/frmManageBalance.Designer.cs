namespace PiramidaAnalize
{
    partial class frmManageBalance
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageBalance));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvDetailMinus = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeObjects = new System.Windows.Forms.TreeView();
            this.dgvDetailPlus = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdRemoveFromPlus = new System.Windows.Forms.Button();
            this.cmdPlaceToPlus = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmdRemoveFromMinus = new System.Windows.Forms.Button();
            this.cmdPlaceToMinus = new System.Windows.Forms.Button();
            this.treeIcons = new System.Windows.Forms.ImageList(this.components);
            this.deviceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parnumber = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolReset = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolClose = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailMinus)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailPlus)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolReset,
            this.toolStripSeparator1,
            this.toolClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(783, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvDetailMinus, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeObjects, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvDetailPlus, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(783, 460);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvDetailMinus
            // 
            this.dgvDetailMinus.AllowDrop = true;
            this.dgvDetailMinus.AllowUserToAddRows = false;
            this.dgvDetailMinus.AllowUserToDeleteRows = false;
            this.dgvDetailMinus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetailMinus.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetailMinus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailMinus.Location = new System.Drawing.Point(243, 253);
            this.dgvDetailMinus.Name = "dgvDetailMinus";
            this.dgvDetailMinus.RowHeadersVisible = false;
            this.dgvDetailMinus.Size = new System.Drawing.Size(537, 204);
            this.dgvDetailMinus.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtTitle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(243, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(537, 34);
            this.panel1.TabIndex = 0;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTitle.Location = new System.Drawing.Point(123, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(405, 26);
            this.txtTitle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название баланса:";
            // 
            // treeObjects
            // 
            this.treeObjects.CheckBoxes = true;
            this.treeObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeObjects.HideSelection = false;
            this.treeObjects.Location = new System.Drawing.Point(3, 43);
            this.treeObjects.Name = "treeObjects";
            this.tableLayoutPanel1.SetRowSpan(this.treeObjects, 2);
            this.treeObjects.Size = new System.Drawing.Size(194, 414);
            this.treeObjects.TabIndex = 1;
            // 
            // dgvDetailPlus
            // 
            this.dgvDetailPlus.AllowDrop = true;
            this.dgvDetailPlus.AllowUserToAddRows = false;
            this.dgvDetailPlus.AllowUserToDeleteRows = false;
            this.dgvDetailPlus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetailPlus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceCode,
            this.deviceName,
            this.sensorCode,
            this.sensorName,
            this.Parnumber});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetailPlus.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetailPlus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetailPlus.Location = new System.Drawing.Point(243, 43);
            this.dgvDetailPlus.Name = "dgvDetailPlus";
            this.dgvDetailPlus.RowHeadersVisible = false;
            this.dgvDetailPlus.Size = new System.Drawing.Size(537, 204);
            this.dgvDetailPlus.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cmdRemoveFromPlus);
            this.panel2.Controls.Add(this.cmdPlaceToPlus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(203, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(34, 204);
            this.panel2.TabIndex = 3;
            // 
            // cmdRemoveFromPlus
            // 
            this.cmdRemoveFromPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmdRemoveFromPlus.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdRemoveFromPlus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRemoveFromPlus.Location = new System.Drawing.Point(3, 48);
            this.cmdRemoveFromPlus.Name = "cmdRemoveFromPlus";
            this.cmdRemoveFromPlus.Size = new System.Drawing.Size(27, 29);
            this.cmdRemoveFromPlus.TabIndex = 1;
            this.cmdRemoveFromPlus.Text = "п";
            this.cmdRemoveFromPlus.UseVisualStyleBackColor = false;
            // 
            // cmdPlaceToPlus
            // 
            this.cmdPlaceToPlus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cmdPlaceToPlus.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdPlaceToPlus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdPlaceToPlus.Location = new System.Drawing.Point(3, 12);
            this.cmdPlaceToPlus.Name = "cmdPlaceToPlus";
            this.cmdPlaceToPlus.Size = new System.Drawing.Size(27, 29);
            this.cmdPlaceToPlus.TabIndex = 0;
            this.cmdPlaceToPlus.Text = "р";
            this.cmdPlaceToPlus.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmdRemoveFromMinus);
            this.panel3.Controls.Add(this.cmdPlaceToMinus);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(203, 253);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(34, 204);
            this.panel3.TabIndex = 4;
            // 
            // cmdRemoveFromMinus
            // 
            this.cmdRemoveFromMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cmdRemoveFromMinus.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdRemoveFromMinus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdRemoveFromMinus.Location = new System.Drawing.Point(3, 48);
            this.cmdRemoveFromMinus.Name = "cmdRemoveFromMinus";
            this.cmdRemoveFromMinus.Size = new System.Drawing.Size(27, 29);
            this.cmdRemoveFromMinus.TabIndex = 3;
            this.cmdRemoveFromMinus.Text = "п";
            this.cmdRemoveFromMinus.UseVisualStyleBackColor = false;
            // 
            // cmdPlaceToMinus
            // 
            this.cmdPlaceToMinus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.cmdPlaceToMinus.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.cmdPlaceToMinus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdPlaceToMinus.Location = new System.Drawing.Point(3, 12);
            this.cmdPlaceToMinus.Name = "cmdPlaceToMinus";
            this.cmdPlaceToMinus.Size = new System.Drawing.Size(27, 29);
            this.cmdPlaceToMinus.TabIndex = 2;
            this.cmdPlaceToMinus.Text = "р";
            this.cmdPlaceToMinus.UseVisualStyleBackColor = false;
            // 
            // treeIcons
            // 
            this.treeIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeIcons.ImageStream")));
            this.treeIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.treeIcons.Images.SetKeyName(0, "32.32.04.shell32.dll.00030.ico");
            this.treeIcons.Images.SetKeyName(1, "32.32.04.shell32.dll.00068.ico");
            this.treeIcons.Images.SetKeyName(2, "Meter.ico");
            // 
            // deviceCode
            // 
            this.deviceCode.HeaderText = "Код";
            this.deviceCode.Name = "deviceCode";
            this.deviceCode.ReadOnly = true;
            this.deviceCode.Width = 60;
            // 
            // deviceName
            // 
            this.deviceName.HeaderText = "Устройство";
            this.deviceName.Name = "deviceName";
            this.deviceName.ReadOnly = true;
            this.deviceName.Width = 300;
            // 
            // sensorCode
            // 
            this.sensorCode.HeaderText = "Код";
            this.sensorCode.Name = "sensorCode";
            this.sensorCode.ReadOnly = true;
            this.sensorCode.Width = 40;
            // 
            // sensorName
            // 
            this.sensorName.HeaderText = "Канал";
            this.sensorName.Name = "sensorName";
            this.sensorName.ReadOnly = true;
            this.sensorName.Width = 300;
            // 
            // Parnumber
            // 
            this.Parnumber.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Parnumber.HeaderText = "Параметр";
            this.Parnumber.Items.AddRange(new object[] {
            "12",
            "101"});
            this.Parnumber.Name = "Parnumber";
            this.Parnumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Parnumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Parnumber.Width = 60;
            // 
            // toolSave
            // 
            this.toolSave.Image = global::PiramidaAnalize.Properties.Resources.Save;
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(85, 22);
            this.toolSave.Text = "Сохранить";
            this.toolSave.ToolTipText = "Сохранить";
            // 
            // toolReset
            // 
            this.toolReset.Image = global::PiramidaAnalize.Properties.Resources.refresh;
            this.toolReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolReset.Name = "toolReset";
            this.toolReset.Size = new System.Drawing.Size(143, 22);
            this.toolReset.Text = "Сбросить изменения";
            this.toolReset.ToolTipText = "Сбросить все изменения";
            this.toolReset.Click += new System.EventHandler(this.toolReset_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolClose
            // 
            this.toolClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolClose.Image = ((System.Drawing.Image)(resources.GetObject("toolClose.Image")));
            this.toolClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolClose.Name = "toolClose";
            this.toolClose.Size = new System.Drawing.Size(57, 22);
            this.toolClose.Text = "Закрыть";
            this.toolClose.Click += new System.EventHandler(this.toolClose_Click);
            // 
            // frmManageBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 485);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmManageBalance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Настройка баланса";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailMinus)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetailPlus)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeObjects;
        private System.Windows.Forms.DataGridView dgvDetailPlus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cmdRemoveFromPlus;
        private System.Windows.Forms.Button cmdPlaceToPlus;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDetailMinus;
        private System.Windows.Forms.ImageList treeIcons;
        private System.Windows.Forms.Button cmdRemoveFromMinus;
        private System.Windows.Forms.Button cmdPlaceToMinus;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Parnumber;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolClose;
    }
}