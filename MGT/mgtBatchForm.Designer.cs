namespace MGT
{
    partial class mgtBatchForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datagridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightByCarrierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.highlightByOrgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label_linesWasStatic = new System.Windows.Forms.Label();
            this.label_linesWasDynamic = new System.Windows.Forms.Label();
            this.label_linesContainsIPsStatic = new System.Windows.Forms.Label();
            this.label_linesContainsIPsDynamic = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView_batchGrid = new System.Windows.Forms.DataGridView();
            this.Clipdata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carrier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Organisation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ccode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView_ListOfISP = new System.Windows.Forms.DataGridView();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_batchGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListOfISP)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.datagridToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1225, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // datagridToolStripMenuItem
            // 
            this.datagridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highlightByCarrierToolStripMenuItem,
            this.highlightByOrgToolStripMenuItem});
            this.datagridToolStripMenuItem.Name = "datagridToolStripMenuItem";
            this.datagridToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.datagridToolStripMenuItem.Text = "Highlight";
            // 
            // highlightByCarrierToolStripMenuItem
            // 
            this.highlightByCarrierToolStripMenuItem.Name = "highlightByCarrierToolStripMenuItem";
            this.highlightByCarrierToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.highlightByCarrierToolStripMenuItem.Text = "Highlight by Carrier";
            this.highlightByCarrierToolStripMenuItem.Click += new System.EventHandler(this.highlightByCarrierToolStripMenuItem_Click);
            // 
            // highlightByOrgToolStripMenuItem
            // 
            this.highlightByOrgToolStripMenuItem.Name = "highlightByOrgToolStripMenuItem";
            this.highlightByOrgToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.highlightByOrgToolStripMenuItem.Text = "Highlight by Org";
            this.highlightByOrgToolStripMenuItem.Click += new System.EventHandler(this.highlightByOrgToolStripMenuItem_Click);
            // 
            // label_linesWasStatic
            // 
            this.label_linesWasStatic.AutoSize = true;
            this.label_linesWasStatic.Location = new System.Drawing.Point(191, 5);
            this.label_linesWasStatic.Name = "label_linesWasStatic";
            this.label_linesWasStatic.Size = new System.Drawing.Size(138, 13);
            this.label_linesWasStatic.TabIndex = 3;
            this.label_linesWasStatic.Text = "Строк было скопировано:";
            // 
            // label_linesWasDynamic
            // 
            this.label_linesWasDynamic.AutoSize = true;
            this.label_linesWasDynamic.Location = new System.Drawing.Point(326, 5);
            this.label_linesWasDynamic.Name = "label_linesWasDynamic";
            this.label_linesWasDynamic.Size = new System.Drawing.Size(13, 13);
            this.label_linesWasDynamic.TabIndex = 4;
            this.label_linesWasDynamic.Text = "0";
            // 
            // label_linesContainsIPsStatic
            // 
            this.label_linesContainsIPsStatic.AutoSize = true;
            this.label_linesContainsIPsStatic.Location = new System.Drawing.Point(363, 5);
            this.label_linesContainsIPsStatic.Name = "label_linesContainsIPsStatic";
            this.label_linesContainsIPsStatic.Size = new System.Drawing.Size(116, 13);
            this.label_linesContainsIPsStatic.TabIndex = 5;
            this.label_linesContainsIPsStatic.Text = "Из них содержало IP:";
            // 
            // label_linesContainsIPsDynamic
            // 
            this.label_linesContainsIPsDynamic.AutoSize = true;
            this.label_linesContainsIPsDynamic.Location = new System.Drawing.Point(485, 5);
            this.label_linesContainsIPsDynamic.Name = "label_linesContainsIPsDynamic";
            this.label_linesContainsIPsDynamic.Size = new System.Drawing.Size(13, 13);
            this.label_linesContainsIPsDynamic.TabIndex = 6;
            this.label_linesContainsIPsDynamic.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_batchGrid);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_ListOfISP);
            this.splitContainer1.Size = new System.Drawing.Size(1225, 674);
            this.splitContainer1.SplitterDistance = 937;
            this.splitContainer1.TabIndex = 7;
            // 
            // dataGridView_batchGrid
            // 
            this.dataGridView_batchGrid.AllowUserToDeleteRows = false;
            this.dataGridView_batchGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_batchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_batchGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clipdata,
            this.IP,
            this.Country,
            this.City,
            this.Carrier,
            this.Organisation,
            this.Ccode,
            this.State,
            this.Sld});
            this.dataGridView_batchGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_batchGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_batchGrid.Name = "dataGridView_batchGrid";
            this.dataGridView_batchGrid.ReadOnly = true;
            this.dataGridView_batchGrid.RowHeadersWidth = 10;
            this.dataGridView_batchGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_batchGrid.Size = new System.Drawing.Size(937, 674);
            this.dataGridView_batchGrid.TabIndex = 1;
            // 
            // Clipdata
            // 
            this.Clipdata.HeaderText = "Clipdata";
            this.Clipdata.Name = "Clipdata";
            this.Clipdata.ReadOnly = true;
            this.Clipdata.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Clipdata.Width = 60;
            // 
            // IP
            // 
            this.IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.ReadOnly = true;
            this.IP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.IP.Width = 21;
            // 
            // Country
            // 
            this.Country.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Country.Width = 21;
            // 
            // City
            // 
            this.City.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.City.Width = 21;
            // 
            // Carrier
            // 
            this.Carrier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Carrier.HeaderText = "Carrier";
            this.Carrier.Name = "Carrier";
            this.Carrier.ReadOnly = true;
            this.Carrier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Carrier.Width = 21;
            // 
            // Organisation
            // 
            this.Organisation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Organisation.HeaderText = "Organisation";
            this.Organisation.Name = "Organisation";
            this.Organisation.ReadOnly = true;
            this.Organisation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Organisation.Width = 21;
            // 
            // Ccode
            // 
            this.Ccode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Ccode.HeaderText = "Ccode";
            this.Ccode.Name = "Ccode";
            this.Ccode.ReadOnly = true;
            this.Ccode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Ccode.Width = 21;
            // 
            // State
            // 
            this.State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.State.Width = 21;
            // 
            // Sld
            // 
            this.Sld.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Sld.HeaderText = "Sld";
            this.Sld.Name = "Sld";
            this.Sld.ReadOnly = true;
            this.Sld.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Sld.Width = 21;
            // 
            // dataGridView_ListOfISP
            // 
            this.dataGridView_ListOfISP.AllowUserToDeleteRows = false;
            this.dataGridView_ListOfISP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ListOfISP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Percent,
            this.ISP});
            this.dataGridView_ListOfISP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_ListOfISP.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_ListOfISP.Name = "dataGridView_ListOfISP";
            this.dataGridView_ListOfISP.ReadOnly = true;
            this.dataGridView_ListOfISP.RowHeadersWidth = 10;
            this.dataGridView_ListOfISP.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView_ListOfISP.Size = new System.Drawing.Size(284, 674);
            this.dataGridView_ListOfISP.TabIndex = 3;
            // 
            // Percent
            // 
            this.Percent.HeaderText = "Percent";
            this.Percent.MaxInputLength = 3;
            this.Percent.Name = "Percent";
            this.Percent.ReadOnly = true;
            // 
            // ISP
            // 
            this.ISP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ISP.HeaderText = "ISP";
            this.ISP.Name = "ISP";
            this.ISP.ReadOnly = true;
            this.ISP.Width = 49;
            // 
            // mgtBatchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 698);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label_linesContainsIPsDynamic);
            this.Controls.Add(this.label_linesContainsIPsStatic);
            this.Controls.Add(this.label_linesWasDynamic);
            this.Controls.Add(this.label_linesWasStatic);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "mgtBatchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Результат пакетной обработки";
            this.TopMost = true;
            this.ResizeEnd += new System.EventHandler(this.mgtBatchForm_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_batchGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ListOfISP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datagridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightByCarrierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightByOrgToolStripMenuItem;
        private System.Windows.Forms.Label label_linesWasStatic;
        private System.Windows.Forms.Label label_linesWasDynamic;
        private System.Windows.Forms.Label label_linesContainsIPsStatic;
        private System.Windows.Forms.Label label_linesContainsIPsDynamic;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView_batchGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Clipdata;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carrier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Organisation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ccode;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sld;
        private System.Windows.Forms.DataGridView dataGridView_ListOfISP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISP;
    }
}