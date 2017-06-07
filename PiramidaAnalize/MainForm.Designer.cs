/*
 * Created by SharpDevelop.
 * User: smke-ing3
 * Date: 03.03.2016
 * Time: 15:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PiramidaAnalize
{
	partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPiramida = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuObjects = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOutput = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкаПодключенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColors = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuPiramida,
            this.mnuTools,
            this.mnuWindow,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.MdiWindowListItem = this.mnuWindow;
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(695, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(48, 20);
            this.mnuFile.Text = "&Файл";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(108, 22);
            this.mnuExit.Text = "В&ыход";
            this.mnuExit.Click += new System.EventHandler(this.MnuExitClick);
            // 
            // mnuPiramida
            // 
            this.mnuPiramida.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuObjects,
            this.mnuOutput,
            this.mnuMap});
            this.mnuPiramida.Name = "mnuPiramida";
            this.mnuPiramida.Size = new System.Drawing.Size(76, 20);
            this.mnuPiramida.Text = "&Пирамида";
            // 
            // mnuObjects
            // 
            this.mnuObjects.Name = "mnuObjects";
            this.mnuObjects.Size = new System.Drawing.Size(152, 22);
            this.mnuObjects.Text = "&Объекты";
            this.mnuObjects.Click += new System.EventHandler(this.MnuObjectsClick);
            // 
            // mnuOutput
            // 
            this.mnuOutput.Name = "mnuOutput";
            this.mnuOutput.Size = new System.Drawing.Size(152, 22);
            this.mnuOutput.Text = "&Выгрузка";
            this.mnuOutput.Click += new System.EventHandler(this.mnuOutput_Click);
            // 
            // mnuMap
            // 
            this.mnuMap.Name = "mnuMap";
            this.mnuMap.Size = new System.Drawing.Size(152, 22);
            this.mnuMap.Text = "&Карта сбора";
            this.mnuMap.Click += new System.EventHandler(this.mnuMap_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкаПодключенияToolStripMenuItem});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(59, 20);
            this.mnuTools.Text = "С&ервис";
            // 
            // настройкаПодключенияToolStripMenuItem
            // 
            this.настройкаПодключенияToolStripMenuItem.Name = "настройкаПодключенияToolStripMenuItem";
            this.настройкаПодключенияToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.настройкаПодключенияToolStripMenuItem.Text = "Настройка подключения";
            this.настройкаПодключенияToolStripMenuItem.Click += new System.EventHandler(this.настройкаПодключенияToolStripMenuItem_Click);
            // 
            // mnuWindow
            // 
            this.mnuWindow.Name = "mnuWindow";
            this.mnuWindow.Size = new System.Drawing.Size(48, 20);
            this.mnuWindow.Text = "Ок&но";
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout,
            this.mnuTest,
            this.mnuColors});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(65, 20);
            this.mnuHelp.Text = "&Справка";
            this.mnuHelp.Click += new System.EventHandler(this.mnuHelp_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(154, 22);
            this.mnuAbout.Text = "О &программе";
            this.mnuAbout.Click += new System.EventHandler(this.MnuAboutClick);
            // 
            // mnuTest
            // 
            this.mnuTest.Name = "mnuTest";
            this.mnuTest.Size = new System.Drawing.Size(154, 22);
            this.mnuTest.Text = "Тестовое окно";
            this.mnuTest.Click += new System.EventHandler(this.mnuTest_Click);
            // 
            // mnuColors
            // 
            this.mnuColors.Name = "mnuColors";
            this.mnuColors.Size = new System.Drawing.Size(154, 22);
            this.mnuColors.Text = "Цвета";
            this.mnuColors.Click += new System.EventHandler(this.mnuColors_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 526);
            this.Controls.Add(this.mnuMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Анализ данных Пирамиды";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem настройкаПодключенияToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuTools;
		private System.Windows.Forms.ToolStripMenuItem mnuAbout;
		private System.Windows.Forms.ToolStripMenuItem mnuHelp;
		private System.Windows.Forms.ToolStripMenuItem mnuWindow;
		private System.Windows.Forms.ToolStripMenuItem mnuMap;
		private System.Windows.Forms.ToolStripMenuItem mnuOutput;
		private System.Windows.Forms.ToolStripMenuItem mnuObjects;
		private System.Windows.Forms.ToolStripMenuItem mnuPiramida;
		private System.Windows.Forms.ToolStripMenuItem mnuExit;
		private System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuTest;
        private System.Windows.Forms.ToolStripMenuItem mnuColors;
    }
}
