namespace PiramidaAnalize
{
    partial class frmManual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManual));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cal1 = new System.Windows.Forms.MonthCalendar();
            this.mainTree = new System.Windows.Forms.TreeView();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.opt12 = new System.Windows.Forms.RadioButton();
            this.txtSelected = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tipLoad = new System.Windows.Forms.ToolTip(this.components);
            this.tipSave = new System.Windows.Forms.ToolTip(this.components);
            this.cmdSave = new System.Windows.Forms.Button();
            this.cmdLoad = new System.Windows.Forms.Button();
            this.cmdFromExcel = new System.Windows.Forms.Button();
            this.tipExcel = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.cal1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainTree, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvData, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(918, 589);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cal1
            // 
            this.cal1.Location = new System.Drawing.Point(9, 9);
            this.cal1.Name = "cal1";
            this.cal1.TabIndex = 0;
            // 
            // mainTree
            // 
            this.mainTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTree.FullRowSelect = true;
            this.mainTree.HideSelection = false;
            this.mainTree.Location = new System.Drawing.Point(3, 183);
            this.mainTree.Name = "mainTree";
            this.mainTree.PathSeparator = " => ";
            this.mainTree.Size = new System.Drawing.Size(174, 403);
            this.mainTree.TabIndex = 1;
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(183, 183);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.Size = new System.Drawing.Size(732, 403);
            this.dgvData.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.txtSelected);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(183, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(732, 174);
            this.panel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmdFromExcel);
            this.groupBox2.Controls.Add(this.cmdSave);
            this.groupBox2.Controls.Add(this.cmdLoad);
            this.groupBox2.Location = new System.Drawing.Point(251, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 100);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Команды";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(27, 131);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(218, 20);
            this.txtDate.TabIndex = 3;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.opt12);
            this.groupBox1.Location = new System.Drawing.Point(27, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 74);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметр";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(204, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Зафиксированные показания (101)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // opt12
            // 
            this.opt12.AutoSize = true;
            this.opt12.Checked = true;
            this.opt12.Location = new System.Drawing.Point(6, 19);
            this.opt12.Name = "opt12";
            this.opt12.Size = new System.Drawing.Size(112, 17);
            this.opt12.TabIndex = 0;
            this.opt12.TabStop = true;
            this.opt12.Text = "Получасовки (12)";
            this.opt12.UseVisualStyleBackColor = true;
            // 
            // txtSelected
            // 
            this.txtSelected.Location = new System.Drawing.Point(154, 15);
            this.txtSelected.Name = "txtSelected";
            this.txtSelected.Size = new System.Drawing.Size(530, 20);
            this.txtSelected.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выбранное устройство";
            // 
            // tipLoad
            // 
            this.tipLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tipLoad.IsBalloon = true;
            this.tipLoad.StripAmpersands = true;
            this.tipLoad.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipLoad.ToolTipTitle = "Считать данные из БД";
            // 
            // tipSave
            // 
            this.tipSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.tipSave.IsBalloon = true;
            this.tipSave.StripAmpersands = true;
            this.tipSave.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipSave.ToolTipTitle = "Записать данные в БД";
            // 
            // cmdSave
            // 
            this.cmdSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdSave.BackgroundImage")));
            this.cmdSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdSave.Location = new System.Drawing.Point(91, 19);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(79, 75);
            this.cmdSave.TabIndex = 1;
            this.tipSave.SetToolTip(this.cmdSave, "Записать в БД данные, введённые вручную (существующие данные будут перезаписаны)");
            this.cmdSave.UseVisualStyleBackColor = true;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // cmdLoad
            // 
            this.cmdLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdLoad.BackgroundImage")));
            this.cmdLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdLoad.Location = new System.Drawing.Point(6, 19);
            this.cmdLoad.Name = "cmdLoad";
            this.cmdLoad.Size = new System.Drawing.Size(79, 75);
            this.cmdLoad.TabIndex = 0;
            this.tipLoad.SetToolTip(this.cmdLoad, "Загрузить в таблицу ниже данные из БД (все несохраненные изменения будут потеряны" +
        ")");
            this.cmdLoad.UseVisualStyleBackColor = true;
            this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
            // 
            // cmdFromExcel
            // 
            this.cmdFromExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("cmdFromExcel.BackgroundImage")));
            this.cmdFromExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cmdFromExcel.Location = new System.Drawing.Point(176, 19);
            this.cmdFromExcel.Name = "cmdFromExcel";
            this.cmdFromExcel.Size = new System.Drawing.Size(79, 75);
            this.cmdFromExcel.TabIndex = 2;
            this.tipExcel.SetToolTip(this.cmdFromExcel, "Загрузить в БД данные из файла Excel");
            this.cmdFromExcel.UseVisualStyleBackColor = true;
            this.cmdFromExcel.Click += new System.EventHandler(this.cmdFromExcel_Click);
            // 
            // tipExcel
            // 
            this.tipExcel.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tipExcel.ToolTipTitle = "Импорт данных из Excel";
            // 
            // frmManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 589);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "frmManual";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ручной ввод данных";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MonthCalendar cal1;
        private System.Windows.Forms.TreeView mainTree;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton opt12;
        private System.Windows.Forms.TextBox txtSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button cmdLoad;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.ToolTip tipSave;
        private System.Windows.Forms.ToolTip tipLoad;
        private System.Windows.Forms.Button cmdFromExcel;
        private System.Windows.Forms.ToolTip tipExcel;
    }
}