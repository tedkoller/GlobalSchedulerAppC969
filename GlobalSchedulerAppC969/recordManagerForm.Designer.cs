namespace GlobalSchedulerAppC969
{
    partial class recordManagerForm
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
            this.customerDataGrid = new System.Windows.Forms.DataGridView();
            this.appointmentDataGrid = new System.Windows.Forms.DataGridView();
            this.customerSectionLabel = new System.Windows.Forms.Label();
            this.appointmentSectionLabel = new System.Windows.Forms.Label();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.updateCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.deleteApptButton = new System.Windows.Forms.Button();
            this.updateApptButton = new System.Windows.Forms.Button();
            this.addApptButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.ApptByDayPicker = new System.Windows.Forms.DateTimePicker();
            this.dayApptHeaderLabel = new System.Windows.Forms.Label();
            this.utcApptsRadio = new System.Windows.Forms.RadioButton();
            this.localApptsRadio = new System.Windows.Forms.RadioButton();
            this.reportSectionLabel = new System.Windows.Forms.Label();
            this.userScheduleButton = new System.Windows.Forms.Button();
            this.customerScheduleLabel = new System.Windows.Forms.Label();
            this.nextApptLabel = new System.Windows.Forms.Label();
            this.nextAppointmentButton = new System.Windows.Forms.Button();
            this.monthlyApptLabel = new System.Windows.Forms.Label();
            this.apptTypeReportButton = new System.Windows.Forms.Button();
            this.userIdScheduleTextBox = new System.Windows.Forms.TextBox();
            this.monthlyApptViewLabel = new System.Windows.Forms.Label();
            this.monthlyApptViewPicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // customerDataGrid
            // 
            this.customerDataGrid.AllowUserToAddRows = false;
            this.customerDataGrid.AllowUserToDeleteRows = false;
            this.customerDataGrid.AllowUserToResizeColumns = false;
            this.customerDataGrid.AllowUserToResizeRows = false;
            this.customerDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.customerDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.customerDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerDataGrid.Location = new System.Drawing.Point(61, 128);
            this.customerDataGrid.Margin = new System.Windows.Forms.Padding(5);
            this.customerDataGrid.Name = "customerDataGrid";
            this.customerDataGrid.ReadOnly = true;
            this.customerDataGrid.RowHeadersVisible = false;
            this.customerDataGrid.RowHeadersWidth = 72;
            this.customerDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.customerDataGrid.Size = new System.Drawing.Size(554, 370);
            this.customerDataGrid.TabIndex = 1;
            // 
            // appointmentDataGrid
            // 
            this.appointmentDataGrid.AllowUserToAddRows = false;
            this.appointmentDataGrid.AllowUserToDeleteRows = false;
            this.appointmentDataGrid.AllowUserToResizeColumns = false;
            this.appointmentDataGrid.AllowUserToResizeRows = false;
            this.appointmentDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.appointmentDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.appointmentDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.appointmentDataGrid.Location = new System.Drawing.Point(719, 128);
            this.appointmentDataGrid.Margin = new System.Windows.Forms.Padding(5);
            this.appointmentDataGrid.Name = "appointmentDataGrid";
            this.appointmentDataGrid.ReadOnly = true;
            this.appointmentDataGrid.RowHeadersVisible = false;
            this.appointmentDataGrid.RowHeadersWidth = 72;
            this.appointmentDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.appointmentDataGrid.Size = new System.Drawing.Size(617, 370);
            this.appointmentDataGrid.TabIndex = 2;
            // 
            // label1
            // 
            this.customerSectionLabel.AutoSize = true;
            this.customerSectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerSectionLabel.Location = new System.Drawing.Point(56, 32);
            this.customerSectionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.customerSectionLabel.Name = "label1";
            this.customerSectionLabel.Size = new System.Drawing.Size(200, 40);
            this.customerSectionLabel.TabIndex = 3;
            this.customerSectionLabel.Text = "Customers";
            // 
            // label2
            // 
            this.appointmentSectionLabel.AutoSize = true;
            this.appointmentSectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appointmentSectionLabel.Location = new System.Drawing.Point(722, 32);
            this.appointmentSectionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.appointmentSectionLabel.Name = "label2";
            this.appointmentSectionLabel.Size = new System.Drawing.Size(249, 40);
            this.appointmentSectionLabel.TabIndex = 4;
            this.appointmentSectionLabel.Text = "Appointments";
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.addCustomerButton.Location = new System.Drawing.Point(61, 83);
            this.addCustomerButton.Margin = new System.Windows.Forms.Padding(5);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(108, 35);
            this.addCustomerButton.TabIndex = 5;
            this.addCustomerButton.Text = "Add Customer";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // updateCustomerButton
            // 
            this.updateCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.updateCustomerButton.Location = new System.Drawing.Point(179, 83);
            this.updateCustomerButton.Margin = new System.Windows.Forms.Padding(5);
            this.updateCustomerButton.Name = "updateCustomerButton";
            this.updateCustomerButton.Size = new System.Drawing.Size(133, 35);
            this.updateCustomerButton.TabIndex = 6;
            this.updateCustomerButton.Text = "Update Customer";
            this.updateCustomerButton.UseVisualStyleBackColor = true;
            this.updateCustomerButton.Click += new System.EventHandler(this.updateCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.deleteCustomerButton.Location = new System.Drawing.Point(468, 83);
            this.deleteCustomerButton.Margin = new System.Windows.Forms.Padding(5);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(147, 35);
            this.deleteCustomerButton.TabIndex = 7;
            this.deleteCustomerButton.Text = "Delete Customer";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // deleteApptButton
            // 
            this.deleteApptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.deleteApptButton.Location = new System.Drawing.Point(1170, 83);
            this.deleteApptButton.Margin = new System.Windows.Forms.Padding(5);
            this.deleteApptButton.Name = "deleteApptButton";
            this.deleteApptButton.Size = new System.Drawing.Size(166, 35);
            this.deleteApptButton.TabIndex = 10;
            this.deleteApptButton.Text = "Delete Appointment";
            this.deleteApptButton.UseVisualStyleBackColor = true;
            this.deleteApptButton.Click += new System.EventHandler(this.deleteApptButton_Click);
            // 
            // updateApptButton
            // 
            this.updateApptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.updateApptButton.Location = new System.Drawing.Point(864, 83);
            this.updateApptButton.Margin = new System.Windows.Forms.Padding(5);
            this.updateApptButton.Name = "updateApptButton";
            this.updateApptButton.Size = new System.Drawing.Size(156, 35);
            this.updateApptButton.TabIndex = 9;
            this.updateApptButton.Text = "Update Appointment";
            this.updateApptButton.UseVisualStyleBackColor = true;
            this.updateApptButton.Click += new System.EventHandler(this.updateApptButton_Click);
            // 
            // addApptButton
            // 
            this.addApptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.addApptButton.Location = new System.Drawing.Point(718, 83);
            this.addApptButton.Margin = new System.Windows.Forms.Padding(5);
            this.addApptButton.Name = "addApptButton";
            this.addApptButton.Size = new System.Drawing.Size(136, 35);
            this.addApptButton.TabIndex = 8;
            this.addApptButton.Text = "Add Appointment";
            this.addApptButton.UseVisualStyleBackColor = true;
            this.addApptButton.Click += new System.EventHandler(this.addAppointmenttButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.closeButton.Location = new System.Drawing.Point(1216, 708);
            this.closeButton.Margin = new System.Windows.Forms.Padding(5);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(120, 35);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // ApptByDayPicker
            // 
            this.ApptByDayPicker.Location = new System.Drawing.Point(935, 533);
            this.ApptByDayPicker.Margin = new System.Windows.Forms.Padding(5);
            this.ApptByDayPicker.Name = "ApptByDayPicker";
            this.ApptByDayPicker.Size = new System.Drawing.Size(298, 26);
            this.ApptByDayPicker.TabIndex = 13;
            this.ApptByDayPicker.ValueChanged += new System.EventHandler(this.refreshDailyApptView);
            // 
            // label3
            // 
            this.dayApptHeaderLabel.AutoSize = true;
            this.dayApptHeaderLabel.Location = new System.Drawing.Point(707, 538);
            this.dayApptHeaderLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dayApptHeaderLabel.Name = "label3";
            this.dayApptHeaderLabel.Size = new System.Drawing.Size(204, 20);
            this.dayApptHeaderLabel.TabIndex = 14;
            this.dayApptHeaderLabel.Text = "View Appointments By Day:";
            // 
            // utcApptsRadio
            // 
            this.utcApptsRadio.AutoSize = true;
            this.utcApptsRadio.Location = new System.Drawing.Point(710, 636);
            this.utcApptsRadio.Margin = new System.Windows.Forms.Padding(5);
            this.utcApptsRadio.Name = "utcApptsRadio";
            this.utcApptsRadio.Size = new System.Drawing.Size(104, 24);
            this.utcApptsRadio.TabIndex = 15;
            this.utcApptsRadio.Text = "UTC Time";
            this.utcApptsRadio.UseVisualStyleBackColor = true;
            this.utcApptsRadio.CheckedChanged += new System.EventHandler(this.toggleGlobalApptView);
            // 
            // localApptsRadio
            // 
            this.localApptsRadio.AutoSize = true;
            this.localApptsRadio.Checked = true;
            this.localApptsRadio.Location = new System.Drawing.Point(819, 636);
            this.localApptsRadio.Margin = new System.Windows.Forms.Padding(5);
            this.localApptsRadio.Name = "localApptsRadio";
            this.localApptsRadio.Size = new System.Drawing.Size(110, 24);
            this.localApptsRadio.TabIndex = 16;
            this.localApptsRadio.TabStop = true;
            this.localApptsRadio.Text = "Local Time";
            this.localApptsRadio.UseVisualStyleBackColor = true;
            this.localApptsRadio.CheckedChanged += new System.EventHandler(this.toggleLocalApptView);
            // 
            // label4
            // 
            this.reportSectionLabel.AutoSize = true;
            this.reportSectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportSectionLabel.Location = new System.Drawing.Point(57, 533);
            this.reportSectionLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.reportSectionLabel.Name = "label4";
            this.reportSectionLabel.Size = new System.Drawing.Size(181, 25);
            this.reportSectionLabel.TabIndex = 17;
            this.reportSectionLabel.Text = "Generate Reports";
            this.reportSectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userScheduleButton
            // 
            this.userScheduleButton.Location = new System.Drawing.Point(518, 616);
            this.userScheduleButton.Margin = new System.Windows.Forms.Padding(5);
            this.userScheduleButton.Name = "userScheduleButton";
            this.userScheduleButton.Size = new System.Drawing.Size(97, 35);
            this.userScheduleButton.TabIndex = 18;
            this.userScheduleButton.Text = "View";
            this.userScheduleButton.UseVisualStyleBackColor = true;
            this.userScheduleButton.Click += new System.EventHandler(this.userScheduleButton_Click);
            // 
            // label5
            // 
            this.customerScheduleLabel.AutoSize = true;
            this.customerScheduleLabel.Location = new System.Drawing.Point(64, 623);
            this.customerScheduleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.customerScheduleLabel.Name = "label5";
            this.customerScheduleLabel.Size = new System.Drawing.Size(228, 20);
            this.customerScheduleLabel.TabIndex = 19;
            this.customerScheduleLabel.Text = "View Schedule by Customer ID";
            // 
            // label6
            // 
            this.nextApptLabel.AutoSize = true;
            this.nextApptLabel.Location = new System.Drawing.Point(65, 668);
            this.nextApptLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.nextApptLabel.Name = "label6";
            this.nextApptLabel.Size = new System.Drawing.Size(212, 20);
            this.nextApptLabel.TabIndex = 21;
            this.nextApptLabel.Text = "Next Upcoming Appointment";
            // 
            // nextAppointmentButton
            // 
            this.nextAppointmentButton.Location = new System.Drawing.Point(518, 661);
            this.nextAppointmentButton.Margin = new System.Windows.Forms.Padding(5);
            this.nextAppointmentButton.Name = "nextAppointmentButton";
            this.nextAppointmentButton.Size = new System.Drawing.Size(97, 35);
            this.nextAppointmentButton.TabIndex = 20;
            this.nextAppointmentButton.Text = "View";
            this.nextAppointmentButton.UseVisualStyleBackColor = true;
            this.nextAppointmentButton.Click += new System.EventHandler(this.nextAppointmentButton_Click);
            // 
            // label7
            // 
            this.monthlyApptLabel.AutoSize = true;
            this.monthlyApptLabel.Location = new System.Drawing.Point(65, 576);
            this.monthlyApptLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.monthlyApptLabel.Name = "label7";
            this.monthlyApptLabel.Size = new System.Drawing.Size(243, 20);
            this.monthlyApptLabel.TabIndex = 23;
            this.monthlyApptLabel.Text = "Monthly Appointment Breakdown";
            // 
            // apptTypeReportButton
            // 
            this.apptTypeReportButton.Location = new System.Drawing.Point(518, 568);
            this.apptTypeReportButton.Margin = new System.Windows.Forms.Padding(5);
            this.apptTypeReportButton.Name = "apptTypeReportButton";
            this.apptTypeReportButton.Size = new System.Drawing.Size(97, 35);
            this.apptTypeReportButton.TabIndex = 22;
            this.apptTypeReportButton.Text = "View";
            this.apptTypeReportButton.UseVisualStyleBackColor = true;
            this.apptTypeReportButton.Click += new System.EventHandler(this.generateApptTypeReport);
            // 
            // userIdScheduleTextBox
            // 
            this.userIdScheduleTextBox.Location = new System.Drawing.Point(294, 619);
            this.userIdScheduleTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.userIdScheduleTextBox.Name = "userIdScheduleTextBox";
            this.userIdScheduleTextBox.Size = new System.Drawing.Size(166, 26);
            this.userIdScheduleTextBox.TabIndex = 24;
            this.userIdScheduleTextBox.TextChanged += new System.EventHandler(this.userIdScheduleTextBox_TextChanged);
            // 
            // label8
            // 
            this.monthlyApptViewLabel.AutoSize = true;
            this.monthlyApptViewLabel.Location = new System.Drawing.Point(707, 588);
            this.monthlyApptViewLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.monthlyApptViewLabel.Name = "label8";
            this.monthlyApptViewLabel.Size = new System.Drawing.Size(221, 20);
            this.monthlyApptViewLabel.TabIndex = 26;
            this.monthlyApptViewLabel.Text = "View Appointments By Month:";
            // 
            // monthlyApptViewPicker
            // 
            this.monthlyApptViewPicker.Location = new System.Drawing.Point(935, 583);
            this.monthlyApptViewPicker.Margin = new System.Windows.Forms.Padding(5);
            this.monthlyApptViewPicker.Name = "monthlyApptViewPicker";
            this.monthlyApptViewPicker.Size = new System.Drawing.Size(298, 26);
            this.monthlyApptViewPicker.TabIndex = 25;
            this.monthlyApptViewPicker.ValueChanged += new System.EventHandler(this.refreshMonthlyView);
            // 
            // recordManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1397, 771);
            this.Controls.Add(this.monthlyApptViewLabel);
            this.Controls.Add(this.monthlyApptViewPicker);
            this.Controls.Add(this.userIdScheduleTextBox);
            this.Controls.Add(this.monthlyApptLabel);
            this.Controls.Add(this.apptTypeReportButton);
            this.Controls.Add(this.nextApptLabel);
            this.Controls.Add(this.nextAppointmentButton);
            this.Controls.Add(this.customerScheduleLabel);
            this.Controls.Add(this.userScheduleButton);
            this.Controls.Add(this.reportSectionLabel);
            this.Controls.Add(this.localApptsRadio);
            this.Controls.Add(this.utcApptsRadio);
            this.Controls.Add(this.dayApptHeaderLabel);
            this.Controls.Add(this.ApptByDayPicker);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.deleteApptButton);
            this.Controls.Add(this.updateApptButton);
            this.Controls.Add(this.addApptButton);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.updateCustomerButton);
            this.Controls.Add(this.addCustomerButton);
            this.Controls.Add(this.appointmentSectionLabel);
            this.Controls.Add(this.customerSectionLabel);
            this.Controls.Add(this.appointmentDataGrid);
            this.Controls.Add(this.customerDataGrid);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "recordManagerForm";
            this.Text = "Customer Records";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.logUserExit);
            this.Load += new System.EventHandler(this.RecordsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.customerDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView customerDataGrid;
        private System.Windows.Forms.DataGridView appointmentDataGrid;
        private System.Windows.Forms.Label appointmentSectionLabel;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button updateCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Button deleteApptButton;
        private System.Windows.Forms.Button updateApptButton;
        private System.Windows.Forms.Button addApptButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.DateTimePicker ApptByDayPicker;
        private System.Windows.Forms.Label dayApptHeaderLabel;
        private System.Windows.Forms.RadioButton utcApptsRadio;
        private System.Windows.Forms.RadioButton localApptsRadio;
        private System.Windows.Forms.Label reportSectionLabel;
        private System.Windows.Forms.Button userScheduleButton;
        private System.Windows.Forms.Label customerScheduleLabel;
        private System.Windows.Forms.Label nextApptLabel;
        private System.Windows.Forms.Button nextAppointmentButton;
        private System.Windows.Forms.Label monthlyApptLabel;
        private System.Windows.Forms.Button apptTypeReportButton;
        private System.Windows.Forms.TextBox userIdScheduleTextBox;
        private System.Windows.Forms.Label monthlyApptViewLabel;
        private System.Windows.Forms.DateTimePicker monthlyApptViewPicker;
        private System.Windows.Forms.Label customerSectionLabel;
    }
}