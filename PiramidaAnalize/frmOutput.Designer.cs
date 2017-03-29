namespace PiramidaAnalize
{
    partial class frmOutput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutput));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSelection = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.InvertAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolOutput = new System.Windows.Forms.ToolStripButton();
            this.treeObjects = new System.Windows.Forms.TreeView();
            this.cal1 = new System.Windows.Forms.MonthCalendar();
            this.cal2 = new System.Windows.Forms.MonthCalendar();
            this.lstTemplates = new System.Windows.Forms.ListBox();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.treeIcons = new System.Windows.Forms.ImageList(this.components);
            this.txtCal1 = new System.Windows.Forms.TextBox();
            this.txtCal2 = new System.Windows.Forms.TextBox();
            this.lstPresets = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnDeletePreset = new System.Windows.Forms.Button();
            this.btnSavePreset = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSelection,
            this.toolStripSeparator1,
            this.toolOutput});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(795, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSelection
            // 
            this.toolSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolSelection.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSelectAll,
            this.mnuClearAll,
            this.InvertAll});
            this.toolSelection.Image = ((System.Drawing.Image)(resources.GetObject("toolSelection.Image")));
            this.toolSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSelection.Name = "toolSelection";
            this.toolSelection.Size = new System.Drawing.Size(81, 22);
            this.toolSelection.Text = "Выделение";
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.Size = new System.Drawing.Size(189, 22);
            this.mnuSelectAll.Text = "Выделить всё";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // mnuClearAll
            // 
            this.mnuClearAll.Name = "mnuClearAll";
            this.mnuClearAll.Size = new System.Drawing.Size(189, 22);
            this.mnuClearAll.Text = "Очистить всё";
            this.mnuClearAll.Click += new System.EventHandler(this.mnuClearAll_Click);
            // 
            // InvertAll
            // 
            this.InvertAll.Name = "InvertAll";
            this.InvertAll.Size = new System.Drawing.Size(189, 22);
            this.InvertAll.Text = "Обратить выделение";
            this.InvertAll.Click += new System.EventHandler(this.InvertAll_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolOutput
            // 
            this.toolOutput.Image = global::PiramidaAnalize.Properties.Resources._16_16_04_EXCEL_EXE_00002;
            this.toolOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOutput.Name = "toolOutput";
            this.toolOutput.Size = new System.Drawing.Size(84, 22);
            this.toolOutput.Text = "Выгрузить";
            this.toolOutput.Click += new System.EventHandler(this.toolOutput_Click);
            // 
            // treeObjects
            // 
            this.treeObjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeObjects.CheckBoxes = true;
            this.treeObjects.Location = new System.Drawing.Point(12, 41);
            this.treeObjects.Name = "treeObjects";
            this.treeObjects.Size = new System.Drawing.Size(286, 187);
            this.treeObjects.TabIndex = 1;
            this.treeObjects.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeObjects_AfterCheck);
            // 
            // cal1
            // 
            this.cal1.Location = new System.Drawing.Point(328, 41);
            this.cal1.Name = "cal1";
            this.cal1.TabIndex = 2;
            this.cal1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Cal1DateChanged);
            // 
            // cal2
            // 
            this.cal2.Location = new System.Drawing.Point(510, 41);
            this.cal2.Name = "cal2";
            this.cal2.TabIndex = 3;
            this.cal2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.Cal2DateChanged);
            // 
            // lstTemplates
            // 
            this.lstTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lstTemplates.FormattingEnabled = true;
            this.lstTemplates.ItemHeight = 16;
            this.lstTemplates.Items.AddRange(new object[] {
            "Получасовки",
            "Получасовки + Часовки",
            "Потребление за период (12)",
            "Потребление посуточно (12)",
            "Зафиксированные показания",
            "Показания попарно",
            "Сверка показаний с получасовками"});
            this.lstTemplates.Location = new System.Drawing.Point(328, 234);
            this.lstTemplates.Name = "lstTemplates";
            this.lstTemplates.Size = new System.Drawing.Size(346, 212);
            this.lstTemplates.TabIndex = 4;
            // 
            // txtSelected
            // 
            this.txtSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSelected.Location = new System.Drawing.Point(212, 234);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.Size = new System.Drawing.Size(86, 20);
            this.txtSelected.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Выбрано каналов:";
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
            this.txtCal1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCal1.Location = new System.Drawing.Point(328, 208);
            this.txtCal1.Name = "txtCal1";
            this.txtCal1.ReadOnly = true;
            this.txtCal1.Size = new System.Drawing.Size(164, 20);
            this.txtCal1.TabIndex = 7;
            this.txtCal1.TabStop = false;
            this.txtCal1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCal2
            // 
            this.txtCal2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCal2.Location = new System.Drawing.Point(510, 208);
            this.txtCal2.Name = "txtCal2";
            this.txtCal2.ReadOnly = true;
            this.txtCal2.Size = new System.Drawing.Size(164, 20);
            this.txtCal2.TabIndex = 8;
            this.txtCal2.TabStop = false;
            this.txtCal2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lstPresets
            // 
            this.lstPresets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lstPresets.FormattingEnabled = true;
            this.lstPresets.Location = new System.Drawing.Point(12, 286);
            this.lstPresets.Name = "lstPresets";
            this.lstPresets.Size = new System.Drawing.Size(242, 160);
            this.lstPresets.TabIndex = 9;
            this.toolTip1.SetToolTip(this.lstPresets, "Двойной щелчок - загручить набор каналов в дерево");
            this.lstPresets.DoubleClick += new System.EventHandler(this.LstPresets_DoubleClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Сохранённые наборы:";
            // 
            // btnDeletePreset
            // 
            this.btnDeletePreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeletePreset.Font = new System.Drawing.Font("Wingdings", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnDeletePreset.ForeColor = System.Drawing.Color.Red;
            this.btnDeletePreset.Location = new System.Drawing.Point(260, 328);
            this.btnDeletePreset.Name = "btnDeletePreset";
            this.btnDeletePreset.Size = new System.Drawing.Size(38, 36);
            this.btnDeletePreset.TabIndex = 13;
            this.btnDeletePreset.Text = "";
            this.toolTip1.SetToolTip(this.btnDeletePreset, "Удалить набор каналов");
            this.btnDeletePreset.UseVisualStyleBackColor = true;
            this.btnDeletePreset.Click += new System.EventHandler(this.BtnDeletePreset_Click);
            // 
            // btnSavePreset
            // 
            this.btnSavePreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSavePreset.Font = new System.Drawing.Font("Wingdings", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.btnSavePreset.ForeColor = System.Drawing.Color.Green;
            this.btnSavePreset.Location = new System.Drawing.Point(260, 286);
            this.btnSavePreset.Name = "btnSavePreset";
            this.btnSavePreset.Size = new System.Drawing.Size(38, 36);
            this.btnSavePreset.TabIndex = 12;
            this.btnSavePreset.Text = "<";
            this.toolTip1.SetToolTip(this.btnSavePreset, "Сохранить набор каналов");
            this.btnSavePreset.UseVisualStyleBackColor = true;
            this.btnSavePreset.Click += new System.EventHandler(this.BtnSavePreset_Click);
            // 
            // frmOutput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 464);
            this.Controls.Add(this.btnDeletePreset);
            this.Controls.Add(this.btnSavePreset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstPresets);
            this.Controls.Add(this.txtCal2);
            this.Controls.Add(this.txtCal1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSelected);
            this.Controls.Add(this.lstTemplates);
            this.Controls.Add(this.cal2);
            this.Controls.Add(this.cal1);
            this.Controls.Add(this.treeObjects);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmOutput";
            this.ShowInTaskbar = false;
            this.Text = "frmOutput";
            this.Load += new System.EventHandler(this.frmOutput_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.TextBox txtCal2;
        private System.Windows.Forms.TextBox txtCal1;

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolOutput;
        private System.Windows.Forms.TreeView treeObjects;
        private System.Windows.Forms.MonthCalendar cal1;
        private System.Windows.Forms.MonthCalendar cal2;
        private System.Windows.Forms.ListBox lstTemplates;
        private System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ImageList treeIcons;
        private System.Windows.Forms.ToolStripDropDownButton toolSelection;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuClearAll;
        private System.Windows.Forms.ToolStripMenuItem InvertAll;
        private System.Windows.Forms.ListBox lstPresets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeletePreset;
        private System.Windows.Forms.Button btnSavePreset;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}