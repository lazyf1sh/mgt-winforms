namespace MGT
{
    partial class mgtRamCache
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_GetCacheData = new System.Windows.Forms.Button();
            this.dataGridView_localCache = new System.Windows.Forms.DataGridView();
            this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carrier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ogranisation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ccode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sld = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_localCache)).BeginInit();
            this.SuspendLayout();
            // 
            // button_GetCacheData
            // 
            this.button_GetCacheData.Location = new System.Drawing.Point(12, 202);
            this.button_GetCacheData.Name = "button_GetCacheData";
            this.button_GetCacheData.Size = new System.Drawing.Size(115, 23);
            this.button_GetCacheData.TabIndex = 4;
            this.button_GetCacheData.Text = "Показать";
            this.button_GetCacheData.UseVisualStyleBackColor = true;
            this.button_GetCacheData.Click += new System.EventHandler(this.button_GetCacheData_Click_1);
            // 
            // dataGridView_localCache
            // 
            this.dataGridView_localCache.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_localCache.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_localCache.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IP,
            this.Country,
            this.City,
            this.Carrier,
            this.Ogranisation,
            this.Ccode,
            this.State,
            this.sld});
            this.dataGridView_localCache.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_localCache.Name = "dataGridView_localCache";
            this.dataGridView_localCache.Size = new System.Drawing.Size(127, 196);
            this.dataGridView_localCache.TabIndex = 5;
            // 
            // IP
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            this.IP.DefaultCellStyle = dataGridViewCellStyle1;
            this.IP.HeaderText = "IP";
            this.IP.Name = "IP";
            this.IP.Width = 42;
            // 
            // Country
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            this.Country.DefaultCellStyle = dataGridViewCellStyle2;
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            // 
            // City
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            this.City.DefaultCellStyle = dataGridViewCellStyle3;
            this.City.HeaderText = "City";
            this.City.Name = "City";
            // 
            // Carrier
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            this.Carrier.DefaultCellStyle = dataGridViewCellStyle4;
            this.Carrier.HeaderText = "Carrier";
            this.Carrier.Name = "Carrier";
            // 
            // Ogranisation
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            this.Ogranisation.DefaultCellStyle = dataGridViewCellStyle5;
            this.Ogranisation.HeaderText = "Ogranisation";
            this.Ogranisation.Name = "Ogranisation";
            // 
            // Ccode
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            this.Ccode.DefaultCellStyle = dataGridViewCellStyle6;
            this.Ccode.HeaderText = "Ccode";
            this.Ccode.Name = "Ccode";
            this.Ccode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // State
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            this.State.DefaultCellStyle = dataGridViewCellStyle7;
            this.State.HeaderText = "State";
            this.State.Name = "State";
            // 
            // sld
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            this.sld.DefaultCellStyle = dataGridViewCellStyle8;
            this.sld.HeaderText = "sld";
            this.sld.Name = "sld";
            // 
            // mgtRamCache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(136, 237);
            this.Controls.Add(this.dataGridView_localCache);
            this.Controls.Add(this.button_GetCacheData);
            this.Name = "mgtRamCache";
            this.Text = "mgtRamCache";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_localCache)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_GetCacheData;
        private System.Windows.Forms.DataGridView dataGridView_localCache;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carrier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ogranisation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ccode;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn sld;
    }
}