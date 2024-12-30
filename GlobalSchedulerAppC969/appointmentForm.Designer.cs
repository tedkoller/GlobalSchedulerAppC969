namespace GlobalSchedulerAppC969
{
    partial class appointmentForm
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Dispose of resources being used.
        /// </summary>
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
        /// Required method for Designer support.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelType = new System.Windows.Forms.Label();
            this.labelCustomerId = new System.Windows.Forms.Label();
            this.labelStartTime = new System.Windows.Forms.Label();
            this.labelEndTime = new System.Windows.Forms.Label();
            this.inputType = new System.Windows.Forms.TextBox();
            this.inputCustomer = new System.Windows.Forms.TextBox();
            this.selectStart = new System.Windows.Forms.DateTimePicker();
            this.selectEnd = new System.Windows.Forms.DateTimePicker();
            this.saveAppointmentButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.appointmentTypeHelper = new System.Windows.Forms.ToolTip(this.components);
            this.customerIdHelper = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(30, 30);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(63, 25);
            this.labelType.TabIndex = 0;
            this.labelType.Text = "Type:";
            // 
            // labelCustomerId
            // 
            this.labelCustomerId.AutoSize = true;
            this.labelCustomerId.Location = new System.Drawing.Point(30, 80);
            this.labelCustomerId.Name = "labelCustomerId";
            this.labelCustomerId.Size = new System.Drawing.Size(127, 25);
            this.labelCustomerId.TabIndex = 1;
            this.labelCustomerId.Text = "Customer ID:";
            // 
            // labelStartTime
            // 
            this.labelStartTime.AutoSize = true;
            this.labelStartTime.Location = new System.Drawing.Point(30, 130);
            this.labelStartTime.Name = "labelStartTime";
            this.labelStartTime.Size = new System.Drawing.Size(108, 25);
            this.labelStartTime.TabIndex = 2;
            this.labelStartTime.Text = "Start Time:";
            // 
            // labelEndTime
            // 
            this.labelEndTime.AutoSize = true;
            this.labelEndTime.Location = new System.Drawing.Point(30, 180);
            this.labelEndTime.Name = "labelEndTime";
            this.labelEndTime.Size = new System.Drawing.Size(102, 25);
            this.labelEndTime.TabIndex = 3;
            this.labelEndTime.Text = "End Time:";
            // 
            // inputType
            // 
            this.inputType.Location = new System.Drawing.Point(150, 27);
            this.inputType.Name = "inputType";
            this.inputType.Size = new System.Drawing.Size(250, 29);
            this.inputType.TabIndex = 4;
            this.inputType.TextChanged += new System.EventHandler(this.InputType_TextChanged);
            // 
            // inputCustomer
            // 
            this.inputCustomer.Location = new System.Drawing.Point(150, 77);
            this.inputCustomer.Name = "inputCustomer";
            this.inputCustomer.Size = new System.Drawing.Size(250, 29);
            this.inputCustomer.TabIndex = 5;
            this.inputCustomer.TextChanged += new System.EventHandler(this.InputCustomer_TextChanged);
            // 
            // selectStart
            // 
            this.selectStart.CustomFormat = "yyyy-MM-dd hh:mm:ss tt";
            this.selectStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.selectStart.Location = new System.Drawing.Point(150, 125);
            this.selectStart.Name = "selectStart";
            this.selectStart.Size = new System.Drawing.Size(250, 29);
            this.selectStart.TabIndex = 6;
            // 
            // selectEnd
            // 
            this.selectEnd.CustomFormat = "yyyy-MM-dd hh:mm:ss tt";
            this.selectEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.selectEnd.Location = new System.Drawing.Point(150, 175);
            this.selectEnd.Name = "selectEnd";
            this.selectEnd.Size = new System.Drawing.Size(250, 29);
            this.selectEnd.TabIndex = 7;
            // 
            // saveAppointmentButton
            // 
            this.saveAppointmentButton.Location = new System.Drawing.Point(150, 220);
            this.saveAppointmentButton.Name = "saveAppointmentButton";
            this.saveAppointmentButton.Size = new System.Drawing.Size(100, 30);
            this.saveAppointmentButton.TabIndex = 8;
            this.saveAppointmentButton.Text = "Save";
            this.saveAppointmentButton.UseVisualStyleBackColor = true;
            this.saveAppointmentButton.Click += new System.EventHandler(this.SaveAppointmentButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(300, 220);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(100, 30);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // appointmentTypeHelper
            // 
            this.appointmentTypeHelper.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // customerIdHelper
            // 
            this.customerIdHelper.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Warning;
            // 
            // appointmentForm
            // 
            this.ClientSize = new System.Drawing.Size(450, 280);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveAppointmentButton);
            this.Controls.Add(this.selectEnd);
            this.Controls.Add(this.selectStart);
            this.Controls.Add(this.inputCustomer);
            this.Controls.Add(this.inputType);
            this.Controls.Add(this.labelEndTime);
            this.Controls.Add(this.labelStartTime);
            this.Controls.Add(this.labelCustomerId);
            this.Controls.Add(this.labelType);
            this.Name = "appointmentForm";
            this.Text = "Manage Appointment";
            this.Load += new System.EventHandler(this.appointmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.Label labelCustomerId;
        private System.Windows.Forms.Label labelStartTime;
        private System.Windows.Forms.Label labelEndTime;
        private System.Windows.Forms.TextBox inputType;
        private System.Windows.Forms.TextBox inputCustomer;
        private System.Windows.Forms.DateTimePicker selectStart;
        private System.Windows.Forms.DateTimePicker selectEnd;
        private System.Windows.Forms.Button saveAppointmentButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ToolTip appointmentTypeHelper;
        private System.Windows.Forms.ToolTip customerIdHelper;
    }
}
