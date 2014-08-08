namespace MGT
{
    partial class mgtBatchProgressForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mgtBatchProgressForm));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label_progress = new System.Windows.Forms.Label();
            this.label_ramQueriesVar = new System.Windows.Forms.Label();
            this.label_SQLiteQueriesNetworkVar = new System.Windows.Forms.Label();
            this.label_quovaApiQueriesVar = new System.Windows.Forms.Label();
            this.label_SQLiteQueriesLocalVar = new System.Windows.Forms.Label();
            this.label_sleepTime = new System.Windows.Forms.Label();
            this.label_averageTime = new System.Windows.Forms.Label();
            this.label_apiQueriesPercent = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Maximum = 50;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(387, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 0;
            // 
            // label_progress
            // 
            this.label_progress.AutoSize = true;
            this.label_progress.Location = new System.Drawing.Point(0, 26);
            this.label_progress.Name = "label_progress";
            this.label_progress.Size = new System.Drawing.Size(47, 13);
            this.label_progress.TabIndex = 1;
            this.label_progress.Text = "progress";
            // 
            // label_ramQueriesVar
            // 
            this.label_ramQueriesVar.AutoSize = true;
            this.label_ramQueriesVar.Location = new System.Drawing.Point(0, 40);
            this.label_ramQueriesVar.Name = "label_ramQueriesVar";
            this.label_ramQueriesVar.Size = new System.Drawing.Size(24, 13);
            this.label_ramQueriesVar.TabIndex = 2;
            this.label_ramQueriesVar.Text = "ram";
            // 
            // label_SQLiteQueriesNetworkVar
            // 
            this.label_SQLiteQueriesNetworkVar.AutoSize = true;
            this.label_SQLiteQueriesNetworkVar.Location = new System.Drawing.Point(0, 67);
            this.label_SQLiteQueriesNetworkVar.Name = "label_SQLiteQueriesNetworkVar";
            this.label_SQLiteQueriesNetworkVar.Size = new System.Drawing.Size(45, 13);
            this.label_SQLiteQueriesNetworkVar.TabIndex = 3;
            this.label_SQLiteQueriesNetworkVar.Text = "network";
            // 
            // label_quovaApiQueriesVar
            // 
            this.label_quovaApiQueriesVar.AutoSize = true;
            this.label_quovaApiQueriesVar.Location = new System.Drawing.Point(0, 80);
            this.label_quovaApiQueriesVar.Name = "label_quovaApiQueriesVar";
            this.label_quovaApiQueriesVar.Size = new System.Drawing.Size(21, 13);
            this.label_quovaApiQueriesVar.TabIndex = 4;
            this.label_quovaApiQueriesVar.Text = "api";
            // 
            // label_SQLiteQueriesLocalVar
            // 
            this.label_SQLiteQueriesLocalVar.AutoSize = true;
            this.label_SQLiteQueriesLocalVar.Location = new System.Drawing.Point(0, 54);
            this.label_SQLiteQueriesLocalVar.Name = "label_SQLiteQueriesLocalVar";
            this.label_SQLiteQueriesLocalVar.Size = new System.Drawing.Size(29, 13);
            this.label_SQLiteQueriesLocalVar.TabIndex = 5;
            this.label_SQLiteQueriesLocalVar.Text = "local";
            // 
            // label_sleepTime
            // 
            this.label_sleepTime.AutoSize = true;
            this.label_sleepTime.Location = new System.Drawing.Point(174, 26);
            this.label_sleepTime.Name = "label_sleepTime";
            this.label_sleepTime.Size = new System.Drawing.Size(55, 13);
            this.label_sleepTime.TabIndex = 6;
            this.label_sleepTime.Text = "sleepTime";
            // 
            // label_averageTime
            // 
            this.label_averageTime.AutoSize = true;
            this.label_averageTime.Location = new System.Drawing.Point(174, 40);
            this.label_averageTime.Name = "label_averageTime";
            this.label_averageTime.Size = new System.Drawing.Size(69, 13);
            this.label_averageTime.TabIndex = 7;
            this.label_averageTime.Text = "averageTime";
            // 
            // label_apiQueriesPercent
            // 
            this.label_apiQueriesPercent.AutoSize = true;
            this.label_apiQueriesPercent.Location = new System.Drawing.Point(174, 54);
            this.label_apiQueriesPercent.Name = "label_apiQueriesPercent";
            this.label_apiQueriesPercent.Size = new System.Drawing.Size(94, 13);
            this.label_apiQueriesPercent.TabIndex = 8;
            this.label_apiQueriesPercent.Text = "apiQueriesPercent";
            // 
            // mgtBatchProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 98);
            this.ControlBox = false;
            this.Controls.Add(this.label_apiQueriesPercent);
            this.Controls.Add(this.label_averageTime);
            this.Controls.Add(this.label_sleepTime);
            this.Controls.Add(this.label_SQLiteQueriesLocalVar);
            this.Controls.Add(this.label_quovaApiQueriesVar);
            this.Controls.Add(this.label_SQLiteQueriesNetworkVar);
            this.Controls.Add(this.label_ramQueriesVar);
            this.Controls.Add(this.label_progress);
            this.Controls.Add(this.progressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mgtBatchProgressForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Progress";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label_progress;
        private System.Windows.Forms.Label label_ramQueriesVar;
        private System.Windows.Forms.Label label_SQLiteQueriesNetworkVar;
        private System.Windows.Forms.Label label_quovaApiQueriesVar;
        private System.Windows.Forms.Label label_SQLiteQueriesLocalVar;
        private System.Windows.Forms.Label label_sleepTime;
        private System.Windows.Forms.Label label_averageTime;
        private System.Windows.Forms.Label label_apiQueriesPercent;
    }
}