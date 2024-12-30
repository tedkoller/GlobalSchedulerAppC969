namespace GlobalSchedulerAppC969
{
    partial class reportViewer
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
            this.reportTypeLabel = new System.Windows.Forms.Label();
            this.userScheduleDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.userScheduleDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // reportTypeLabel
            // 
            this.reportTypeLabel.AutoSize = true;
            this.reportTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.reportTypeLabel.Location = new System.Drawing.Point(60, 62);
            this.reportTypeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.reportTypeLabel.Name = "reportTypeLabel";
            this.reportTypeLabel.Size = new System.Drawing.Size(0, 22);
            this.reportTypeLabel.TabIndex = 0;
            // 
            // userScheduleDataGridView
            // 
            this.userScheduleDataGridView.AllowUserToAddRows = false;
            this.userScheduleDataGridView.AllowUserToDeleteRows = false;
            this.userScheduleDataGridView.AllowUserToResizeColumns = false;
            this.userScheduleDataGridView.AllowUserToResizeRows = false;
            this.userScheduleDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userScheduleDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.userScheduleDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userScheduleDataGridView.Location = new System.Drawing.Point(18, 62);
            this.userScheduleDataGridView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.userScheduleDataGridView.Name = "userScheduleDataGridView";
            this.userScheduleDataGridView.ReadOnly = true;
            this.userScheduleDataGridView.RowHeadersVisible = false;
            this.userScheduleDataGridView.RowHeadersWidth = 72;
            this.userScheduleDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.userScheduleDataGridView.Size = new System.Drawing.Size(615, 382);
            this.userScheduleDataGridView.TabIndex = 3;
            this.userScheduleDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userScheduleDataGridView_CellContentClick);
            // 
            // reportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 489);
            this.Controls.Add(this.userScheduleDataGridView);
            this.Controls.Add(this.reportTypeLabel);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "reportViewer";
            this.Text = "Generated Report";
            this.Load += new System.EventHandler(this.reportViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userScheduleDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label reportTypeLabel;
        private System.Windows.Forms.DataGridView userScheduleDataGridView;
    }
}