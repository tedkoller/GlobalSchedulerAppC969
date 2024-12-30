namespace GlobalSchedulerAppC969
{
    partial class customerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(customerForm));
            this.customerFormTitleLabel = new System.Windows.Forms.Label();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.addressInput = new System.Windows.Forms.TextBox();
            this.inputPhone = new System.Windows.Forms.TextBox();
            this.customerPhoneLabel = new System.Windows.Forms.Label();
            this.customerAddressLabel = new System.Windows.Forms.Label();
            this.saveCusButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.customerNameLabel = new System.Windows.Forms.Label();
            this.customerCityLabel = new System.Windows.Forms.Label();
            this.inputCity = new System.Windows.Forms.TextBox();
            this.countryInput = new System.Windows.Forms.TextBox();
            this.nameToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.addressToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cityToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.countryToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.phoneToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.customerFormTitleLabel, "label1");
            this.customerFormTitleLabel.Name = "label1";
            // 
            // nameTextbox
            // 
            resources.ApplyResources(this.nameInput, "nameTextbox");
            this.nameInput.Name = "nameTextbox";
            this.nameInput.TextChanged += new System.EventHandler(this.nameTextbox_TextChanged);
            // 
            // addressTextbox
            // 
            resources.ApplyResources(this.addressInput, "addressTextbox");
            this.addressInput.Name = "addressTextbox";
            this.addressInput.TextChanged += new System.EventHandler(this.addressTextbox_TextChanged);
            // 
            // phoneTextbox
            // 
            resources.ApplyResources(this.inputPhone, "phoneTextbox");
            this.inputPhone.Name = "phoneTextbox";
            this.inputPhone.TextChanged += new System.EventHandler(this.phoneTextbox_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.customerPhoneLabel, "label4");
            this.customerPhoneLabel.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.customerAddressLabel, "label3");
            this.customerAddressLabel.Name = "label3";
            // 
            // saveCusButton
            // 
            resources.ApplyResources(this.saveCusButton, "saveCusButton");
            this.saveCusButton.Name = "saveCusButton";
            this.saveCusButton.UseVisualStyleBackColor = true;
            this.saveCusButton.Click += new System.EventHandler(this.saveCustomerButton_Click);
            // 
            // cancelButton
            // 
            resources.ApplyResources(this.cancelButton, "cancelButton");
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.customerNameLabel, "label2");
            this.customerNameLabel.Name = "label2";
            // 
            // label5
            // 
            resources.ApplyResources(this.customerCityLabel, "label5");
            this.customerCityLabel.Name = "label5";
            // 
            // cityTextbox
            // 
            resources.ApplyResources(this.inputCity, "cityTextbox");
            this.inputCity.Name = "cityTextbox";
            this.inputCity.TextChanged += new System.EventHandler(this.cityTextbox_TextChanged);
            // 
            // countryTextbox
            // 
            resources.ApplyResources(this.countryInput, "countryTextbox");
            this.countryInput.Name = "countryTextbox";
            this.countryInput.TextChanged += new System.EventHandler(this.countryTextbox_TextChanged);
            // 
            // AddUpdateCustomerForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.countryInput);
            this.Controls.Add(this.inputCity);
            this.Controls.Add(this.customerCityLabel);
            this.Controls.Add(this.customerNameLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveCusButton);
            this.Controls.Add(this.customerAddressLabel);
            this.Controls.Add(this.customerPhoneLabel);
            this.Controls.Add(this.inputPhone);
            this.Controls.Add(this.addressInput);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.customerFormTitleLabel);
            this.Name = "AddUpdateCustomerForm";
            this.Load += new System.EventHandler(this.customerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label customerFormTitleLabel;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.TextBox addressInput;
        private System.Windows.Forms.TextBox inputPhone;
        private System.Windows.Forms.Label customerPhoneLabel;
        private System.Windows.Forms.Label customerAddressLabel;
        private System.Windows.Forms.Button saveCusButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label customerNameLabel;
        private System.Windows.Forms.Label customerCityLabel;
        private System.Windows.Forms.TextBox inputCity;
        private System.Windows.Forms.TextBox countryInput;
        private System.Windows.Forms.ToolTip nameToolTip;
        private System.Windows.Forms.ToolTip addressToolTip;
        private System.Windows.Forms.ToolTip cityToolTip;
        private System.Windows.Forms.ToolTip countryToolTip;
        private System.Windows.Forms.ToolTip phoneToolTip;
    }
}