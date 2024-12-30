namespace GlobalSchedulerAppC969
{
    partial class appointmentViewer
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
            this.appointmentDateLabel = new System.Windows.Forms.Label();
            this.appointmentsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // apptDateLabel
            // 
            this.appointmentDateLabel.AutoSize = true;
            this.appointmentDateLabel.Location = new System.Drawing.Point(233, 37);
            this.appointmentDateLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.appointmentDateLabel.Name = "apptDateLabel";
            this.appointmentDateLabel.Size = new System.Drawing.Size(164, 25);
            this.appointmentDateLabel.TabIndex = 1;
            this.appointmentDateLabel.Text = "Appointments for ";
            // 
            // ApptsDataGrid
            // 
            this.appointmentsDataGridView.AllowUserToAddRows = false;
            this.appointmentsDataGridView.AllowUserToDeleteRows = false;
            this.appointmentsDataGridView.AllowUserToResizeColumns = false;
            this.appointmentsDataGridView.AllowUserToResizeRows = false;
            this.appointmentsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appointmentsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.appointmentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentsDataGridView.Location = new System.Drawing.Point(46, 83);
            this.appointmentsDataGridView.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.appointmentsDataGridView.Name = "ApptsDataGrid";
            this.appointmentsDataGridView.ReadOnly = true;
            this.appointmentsDataGridView.RowHeadersVisible = false;
            this.appointmentsDataGridView.RowHeadersWidth = 72;
            this.appointmentsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentsDataGridView.Size = new System.Drawing.Size(664, 438);
            this.appointmentsDataGridView.TabIndex = 3;
            // 
            // DailyApptsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 563);
            this.Controls.Add(this.appointmentsDataGridView);
            this.Controls.Add(this.appointmentDateLabel);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "DailyApptsForm";
            this.Text = "Daily Appointments";
            this.Load += new System.EventHandler(this.appointmentsViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label appointmentDateLabel;
        private System.Windows.Forms.DataGridView appointmentsDataGridView;
    }
}