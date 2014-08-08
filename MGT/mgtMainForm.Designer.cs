namespace MGT
{
    partial class mgtMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mgtMainForm));
            this.label_IPStatic = new System.Windows.Forms.Label();
            this.label_CarrierStatic = new System.Windows.Forms.Label();
            this.label_OrgStatic = new System.Windows.Forms.Label();
            this.label_IPDynamic = new System.Windows.Forms.Label();
            this.label_CarrierDynamic = new System.Windows.Forms.Label();
            this.label_OrgDynamic = new System.Windows.Forms.Label();
            this.label_GeoStatic = new System.Windows.Forms.Label();
            this.pictureBox_CountryFlag = new System.Windows.Forms.PictureBox();
            this.label_GeoDynamic = new System.Windows.Forms.Label();
            this.label_StateStatic = new System.Windows.Forms.Label();
            this.label_StateDynamic = new System.Windows.Forms.Label();
            this.label_sldStatic = new System.Windows.Forms.Label();
            this.label_sldDynamic = new System.Windows.Forms.Label();
            this.label_batchProccessLinesDynamic = new System.Windows.Forms.Label();
            this.label_linesInClipBoard = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyIcon_geoData = new System.Windows.Forms.NotifyIcon(this.components);
            this.richTextBox_requestsHistory = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startMonitoringToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableBatchHotkeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentIteration0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchAll4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchAddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchCleanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchParseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchShowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CountryFlag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_IPStatic
            // 
            this.label_IPStatic.AutoSize = true;
            this.label_IPStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_IPStatic.Location = new System.Drawing.Point(10, 4);
            this.label_IPStatic.Name = "label_IPStatic";
            this.label_IPStatic.Size = new System.Drawing.Size(23, 13);
            this.label_IPStatic.TabIndex = 0;
            this.label_IPStatic.Text = "IP:";
            // 
            // label_CarrierStatic
            // 
            this.label_CarrierStatic.AutoSize = true;
            this.label_CarrierStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_CarrierStatic.Location = new System.Drawing.Point(3, 20);
            this.label_CarrierStatic.Name = "label_CarrierStatic";
            this.label_CarrierStatic.Size = new System.Drawing.Size(30, 13);
            this.label_CarrierStatic.TabIndex = 1;
            this.label_CarrierStatic.Text = "Car:";
            // 
            // label_OrgStatic
            // 
            this.label_OrgStatic.AutoSize = true;
            this.label_OrgStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_OrgStatic.Location = new System.Drawing.Point(3, 35);
            this.label_OrgStatic.Name = "label_OrgStatic";
            this.label_OrgStatic.Size = new System.Drawing.Size(31, 13);
            this.label_OrgStatic.TabIndex = 2;
            this.label_OrgStatic.Text = "Org:";
            // 
            // label_IPDynamic
            // 
            this.label_IPDynamic.AutoSize = true;
            this.label_IPDynamic.Location = new System.Drawing.Point(33, 4);
            this.label_IPDynamic.Name = "label_IPDynamic";
            this.label_IPDynamic.Size = new System.Drawing.Size(88, 13);
            this.label_IPDynamic.TabIndex = 3;
            this.label_IPDynamic.Text = "255.255.255.255";
            // 
            // label_CarrierDynamic
            // 
            this.label_CarrierDynamic.AutoSize = true;
            this.label_CarrierDynamic.Location = new System.Drawing.Point(35, 20);
            this.label_CarrierDynamic.Name = "label_CarrierDynamic";
            this.label_CarrierDynamic.Size = new System.Drawing.Size(37, 13);
            this.label_CarrierDynamic.TabIndex = 4;
            this.label_CarrierDynamic.Text = "Carrier";
            // 
            // label_OrgDynamic
            // 
            this.label_OrgDynamic.AutoSize = true;
            this.label_OrgDynamic.Location = new System.Drawing.Point(35, 35);
            this.label_OrgDynamic.Name = "label_OrgDynamic";
            this.label_OrgDynamic.Size = new System.Drawing.Size(66, 13);
            this.label_OrgDynamic.TabIndex = 5;
            this.label_OrgDynamic.Text = "Organisation";
            // 
            // label_GeoStatic
            // 
            this.label_GeoStatic.AutoSize = true;
            this.label_GeoStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_GeoStatic.Location = new System.Drawing.Point(119, 4);
            this.label_GeoStatic.Name = "label_GeoStatic";
            this.label_GeoStatic.Size = new System.Drawing.Size(34, 13);
            this.label_GeoStatic.TabIndex = 6;
            this.label_GeoStatic.Text = "Geo:";
            // 
            // pictureBox_CountryFlag
            // 
            this.pictureBox_CountryFlag.Location = new System.Drawing.Point(154, 5);
            this.pictureBox_CountryFlag.Name = "pictureBox_CountryFlag";
            this.pictureBox_CountryFlag.Size = new System.Drawing.Size(18, 12);
            this.pictureBox_CountryFlag.TabIndex = 7;
            this.pictureBox_CountryFlag.TabStop = false;
            this.pictureBox_CountryFlag.Click += new System.EventHandler(this.pictureBox_CountryFlag_Click);
            // 
            // label_GeoDynamic
            // 
            this.label_GeoDynamic.AutoSize = true;
            this.label_GeoDynamic.Location = new System.Drawing.Point(172, 5);
            this.label_GeoDynamic.Name = "label_GeoDynamic";
            this.label_GeoDynamic.Size = new System.Drawing.Size(27, 13);
            this.label_GeoDynamic.TabIndex = 8;
            this.label_GeoDynamic.Text = "Geo";
            // 
            // label_StateStatic
            // 
            this.label_StateStatic.AutoSize = true;
            this.label_StateStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_StateStatic.Location = new System.Drawing.Point(3, 51);
            this.label_StateStatic.Name = "label_StateStatic";
            this.label_StateStatic.Size = new System.Drawing.Size(30, 13);
            this.label_StateStatic.TabIndex = 14;
            this.label_StateStatic.Text = "Sta:";
            // 
            // label_StateDynamic
            // 
            this.label_StateDynamic.AutoSize = true;
            this.label_StateDynamic.Location = new System.Drawing.Point(35, 51);
            this.label_StateDynamic.Name = "label_StateDynamic";
            this.label_StateDynamic.Size = new System.Drawing.Size(32, 13);
            this.label_StateDynamic.TabIndex = 16;
            this.label_StateDynamic.Text = "State";
            // 
            // label_sldStatic
            // 
            this.label_sldStatic.AutoSize = true;
            this.label_sldStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sldStatic.Location = new System.Drawing.Point(3, 66);
            this.label_sldStatic.Name = "label_sldStatic";
            this.label_sldStatic.Size = new System.Drawing.Size(29, 13);
            this.label_sldStatic.TabIndex = 17;
            this.label_sldStatic.Text = "Sld:";
            // 
            // label_sldDynamic
            // 
            this.label_sldDynamic.AutoSize = true;
            this.label_sldDynamic.Location = new System.Drawing.Point(35, 66);
            this.label_sldDynamic.Name = "label_sldDynamic";
            this.label_sldDynamic.Size = new System.Drawing.Size(22, 13);
            this.label_sldDynamic.TabIndex = 18;
            this.label_sldDynamic.Text = "Sld";
            // 
            // label_batchProccessLinesDynamic
            // 
            this.label_batchProccessLinesDynamic.AutoSize = true;
            this.label_batchProccessLinesDynamic.Location = new System.Drawing.Point(283, 63);
            this.label_batchProccessLinesDynamic.Name = "label_batchProccessLinesDynamic";
            this.label_batchProccessLinesDynamic.Size = new System.Drawing.Size(85, 13);
            this.label_batchProccessLinesDynamic.TabIndex = 31;
            this.label_batchProccessLinesDynamic.Text = "Lines to parse: 0";
            this.label_batchProccessLinesDynamic.Click += new System.EventHandler(this.label_batchProccessLinesDynamic_Click);
            // 
            // label_linesInClipBoard
            // 
            this.label_linesInClipBoard.AutoSize = true;
            this.label_linesInClipBoard.Location = new System.Drawing.Point(267, 47);
            this.label_linesInClipBoard.Name = "label_linesInClipBoard";
            this.label_linesInClipBoard.Size = new System.Drawing.Size(101, 13);
            this.label_linesInClipBoard.TabIndex = 30;
            this.label_linesInClipBoard.Text = "Lines in clipboard: 0";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "MGT updateAviable";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.BalloonTipClicked += new System.EventHandler(this.notifyIcon1_BalloonTipClicked);
            // 
            // notifyIcon_geoData
            // 
            this.notifyIcon_geoData.Text = "MGT";
            this.notifyIcon_geoData.Visible = true;
            this.notifyIcon_geoData.BalloonTipClicked += new System.EventHandler(this.notifyIcon_geoData_BalloonTipClicked);
            // 
            // richTextBox_requestsHistory
            // 
            this.richTextBox_requestsHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_requestsHistory.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_requestsHistory.Name = "richTextBox_requestsHistory";
            this.richTextBox_requestsHistory.Size = new System.Drawing.Size(384, 260);
            this.richTextBox_requestsHistory.TabIndex = 31;
            this.richTextBox_requestsHistory.Text = "";
            this.richTextBox_requestsHistory.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox_requestsHistory_LinkClicked);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label_batchProccessLinesDynamic);
            this.splitContainer1.Panel1.Controls.Add(this.label_IPStatic);
            this.splitContainer1.Panel1.Controls.Add(this.label_linesInClipBoard);
            this.splitContainer1.Panel1.Controls.Add(this.label_CarrierStatic);
            this.splitContainer1.Panel1.Controls.Add(this.label_OrgStatic);
            this.splitContainer1.Panel1.Controls.Add(this.label_sldDynamic);
            this.splitContainer1.Panel1.Controls.Add(this.label_IPDynamic);
            this.splitContainer1.Panel1.Controls.Add(this.label_sldStatic);
            this.splitContainer1.Panel1.Controls.Add(this.label_CarrierDynamic);
            this.splitContainer1.Panel1.Controls.Add(this.label_StateDynamic);
            this.splitContainer1.Panel1.Controls.Add(this.label_OrgDynamic);
            this.splitContainer1.Panel1.Controls.Add(this.label_StateStatic);
            this.splitContainer1.Panel1.Controls.Add(this.label_GeoStatic);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox_CountryFlag);
            this.splitContainer1.Panel1.Controls.Add(this.label_GeoDynamic);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox_requestsHistory);
            this.splitContainer1.Size = new System.Drawing.Size(384, 347);
            this.splitContainer1.SplitterDistance = 83;
            this.splitContainer1.TabIndex = 32;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.batchToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(286, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(98, 83);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startMonitoringToolStripMenuItem,
            this.enableBatchHotkeyToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.currentIteration0ToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(85, 19);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // startMonitoringToolStripMenuItem
            // 
            this.startMonitoringToolStripMenuItem.Name = "startMonitoringToolStripMenuItem";
            this.startMonitoringToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.startMonitoringToolStripMenuItem.Text = "Start Monitoring";
            this.startMonitoringToolStripMenuItem.Click += new System.EventHandler(this.startMonitoringToolStripMenuItem_Click);
            // 
            // enableBatchHotkeyToolStripMenuItem
            // 
            this.enableBatchHotkeyToolStripMenuItem.Name = "enableBatchHotkeyToolStripMenuItem";
            this.enableBatchHotkeyToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.enableBatchHotkeyToolStripMenuItem.Text = "Enable batch hotkey";
            this.enableBatchHotkeyToolStripMenuItem.Click += new System.EventHandler(this.enableBatchHotkeyToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // currentIteration0ToolStripMenuItem
            // 
            this.currentIteration0ToolStripMenuItem.Enabled = false;
            this.currentIteration0ToolStripMenuItem.Name = "currentIteration0ToolStripMenuItem";
            this.currentIteration0ToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.currentIteration0ToolStripMenuItem.Text = "Current iteration: [0]";
            // 
            // batchToolStripMenuItem
            // 
            this.batchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batchAll4ToolStripMenuItem,
            this.batchAddToolStripMenuItem,
            this.batchCleanToolStripMenuItem,
            this.batchParseToolStripMenuItem,
            this.batchShowToolStripMenuItem});
            this.batchToolStripMenuItem.Name = "batchToolStripMenuItem";
            this.batchToolStripMenuItem.Size = new System.Drawing.Size(85, 19);
            this.batchToolStripMenuItem.Text = "Batch";
            // 
            // batchAll4ToolStripMenuItem
            // 
            this.batchAll4ToolStripMenuItem.Name = "batchAll4ToolStripMenuItem";
            this.batchAll4ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.batchAll4ToolStripMenuItem.Text = "All4";
            this.batchAll4ToolStripMenuItem.Click += new System.EventHandler(this.batchAll4ToolStripMenuItem_Click);
            // 
            // batchAddToolStripMenuItem
            // 
            this.batchAddToolStripMenuItem.Name = "batchAddToolStripMenuItem";
            this.batchAddToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.batchAddToolStripMenuItem.Text = "Add";
            this.batchAddToolStripMenuItem.Click += new System.EventHandler(this.batchAddToolStripMenuItem_Click);
            // 
            // batchCleanToolStripMenuItem
            // 
            this.batchCleanToolStripMenuItem.Name = "batchCleanToolStripMenuItem";
            this.batchCleanToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.batchCleanToolStripMenuItem.Text = "Clean";
            this.batchCleanToolStripMenuItem.Click += new System.EventHandler(this.batchCleanToolStripMenuItem_Click);
            // 
            // batchParseToolStripMenuItem
            // 
            this.batchParseToolStripMenuItem.Name = "batchParseToolStripMenuItem";
            this.batchParseToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.batchParseToolStripMenuItem.Text = "Parse";
            this.batchParseToolStripMenuItem.Click += new System.EventHandler(this.batchParseToolStripMenuItem_Click);
            // 
            // batchShowToolStripMenuItem
            // 
            this.batchShowToolStripMenuItem.Name = "batchShowToolStripMenuItem";
            this.batchShowToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.batchShowToolStripMenuItem.Text = "Show";
            this.batchShowToolStripMenuItem.Click += new System.EventHandler(this.batchShowToolStripMenuItem_Click);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
            // 
            // mgtMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 347);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(400, 2015);
            this.MinimumSize = new System.Drawing.Size(400, 115);
            this.Name = "mgtMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MGT";
            this.TopMost = true;
            this.ResizeEnd += new System.EventHandler(this.mgtMainForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_CountryFlag)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_IPStatic;
        private System.Windows.Forms.Label label_CarrierStatic;
        private System.Windows.Forms.Label label_OrgStatic;
        private System.Windows.Forms.Label label_IPDynamic;
        private System.Windows.Forms.Label label_CarrierDynamic;
        private System.Windows.Forms.Label label_OrgDynamic;
        private System.Windows.Forms.Label label_GeoStatic;
        private System.Windows.Forms.PictureBox pictureBox_CountryFlag;
        private System.Windows.Forms.Label label_GeoDynamic;
        private System.Windows.Forms.Label label_StateStatic;
        private System.Windows.Forms.Label label_StateDynamic;
        private System.Windows.Forms.Label label_sldStatic;
        private System.Windows.Forms.Label label_sldDynamic;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.NotifyIcon notifyIcon_geoData;
        private System.Windows.Forms.RichTextBox richTextBox_requestsHistory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startMonitoringToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableBatchHotkeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentIteration0ToolStripMenuItem;
        private System.Windows.Forms.Label label_batchProccessLinesDynamic;
        private System.Windows.Forms.Label label_linesInClipBoard;
        private System.Windows.Forms.ToolStripMenuItem batchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchAddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchCleanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchParseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchShowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchAll4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
    }
}

