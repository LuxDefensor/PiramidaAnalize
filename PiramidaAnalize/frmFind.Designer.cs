namespace PiramidaAnalize
{
    partial class frmFind
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
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdFind = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.chkExact = new System.Windows.Forms.CheckBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.DevCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdGo = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSearchType
            // 
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Items.AddRange(new object[] {
            "По коду",
            "По названию устройства",
            "По названию канала"});
            this.cboSearchType.Location = new System.Drawing.Point(78, 25);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(227, 21);
            this.cboSearchType.TabIndex = 0;
            this.cboSearchType.TabStop = false;
            this.cboSearchType.Text = "По коду";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вид поиска";
            // 
            // cmdFind
            // 
            this.cmdFind.BackColor = System.Drawing.SystemColors.Window;
            this.cmdFind.BackgroundImage = global::PiramidaAnalize.Properties.Resources.Find;
            this.cmdFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.cmdFind.Location = new System.Drawing.Point(321, 25);
            this.cmdFind.Name = "cmdFind";
            this.cmdFind.Size = new System.Drawing.Size(54, 56);
            this.cmdFind.TabIndex = 2;
            this.cmdFind.TabStop = false;
            this.cmdFind.UseVisualStyleBackColor = false;
            this.cmdFind.Click += new System.EventHandler(this.cmdFind_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtSearch.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtSearch.Location = new System.Drawing.Point(10, 52);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(295, 29);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkExact
            // 
            this.chkExact.AutoSize = true;
            this.chkExact.Checked = true;
            this.chkExact.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExact.Location = new System.Drawing.Point(12, 87);
            this.chkExact.Name = "chkExact";
            this.chkExact.Size = new System.Drawing.Size(125, 17);
            this.chkExact.TabIndex = 4;
            this.chkExact.TabStop = false;
            this.chkExact.Text = "Точное совпадение";
            this.chkExact.UseVisualStyleBackColor = true;
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DevCode,
            this.DevName,
            this.ItemCode,
            this.ItemName,
            this.cmdGo});
            this.dgvResults.Location = new System.Drawing.Point(12, 137);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.ReadOnly = true;
            this.dgvResults.Size = new System.Drawing.Size(592, 379);
            this.dgvResults.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Результаты:";
            // 
            // DevCode
            // 
            this.DevCode.HeaderText = "Код";
            this.DevCode.Name = "DevCode";
            this.DevCode.ReadOnly = true;
            this.DevCode.Width = 60;
            // 
            // DevName
            // 
            this.DevName.HeaderText = "Устройство";
            this.DevName.Name = "DevName";
            this.DevName.ReadOnly = true;
            this.DevName.Width = 200;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Код";
            this.ItemCode.Name = "ItemCode";
            this.ItemCode.ReadOnly = true;
            this.ItemCode.Width = 40;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Канал";
            this.ItemName.Name = "ItemName";
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 200;
            // 
            // cmdGo
            // 
            this.cmdGo.HeaderText = "=>";
            this.cmdGo.Name = "cmdGo";
            this.cmdGo.ReadOnly = true;
            this.cmdGo.Width = 40;
            // 
            // frmFind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 528);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.chkExact);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cmdFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSearchType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFind";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск объектов";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdFind;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.CheckBox chkExact;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewButtonColumn cmdGo;
        private System.Windows.Forms.Label label2;
    }
}