namespace calendarApp
{
    partial class customerEdit
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
            this.customerNameInput = new System.Windows.Forms.TextBox();
            this.customerNameInputLabel = new System.Windows.Forms.Label();
            this.customerAddressInputLabel = new System.Windows.Forms.Label();
            this.customerAddressInput = new System.Windows.Forms.TextBox();
            this.customerPhoneInputLabel = new System.Windows.Forms.Label();
            this.customerPhoneInput = new System.Windows.Forms.TextBox();
            this.customerCityInputLabel = new System.Windows.Forms.Label();
            this.customerCityInput = new System.Windows.Forms.TextBox();
            this.customerCountryInputLabel = new System.Windows.Forms.Label();
            this.customerCountryInput = new System.Windows.Forms.TextBox();
            this.saveCustomerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // customerNameInput
            // 
            this.customerNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerNameInput.Location = new System.Drawing.Point(39, 78);
            this.customerNameInput.Name = "customerNameInput";
            this.customerNameInput.Size = new System.Drawing.Size(230, 30);
            this.customerNameInput.TabIndex = 0;
            // 
            // customerNameInputLabel
            // 
            this.customerNameInputLabel.AutoSize = true;
            this.customerNameInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerNameInputLabel.Location = new System.Drawing.Point(34, 44);
            this.customerNameInputLabel.Name = "customerNameInputLabel";
            this.customerNameInputLabel.Size = new System.Drawing.Size(154, 25);
            this.customerNameInputLabel.TabIndex = 2;
            this.customerNameInputLabel.Text = "Customer Name";
            // 
            // customerAddressInputLabel
            // 
            this.customerAddressInputLabel.AutoSize = true;
            this.customerAddressInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerAddressInputLabel.Location = new System.Drawing.Point(322, 44);
            this.customerAddressInputLabel.Name = "customerAddressInputLabel";
            this.customerAddressInputLabel.Size = new System.Drawing.Size(175, 25);
            this.customerAddressInputLabel.TabIndex = 4;
            this.customerAddressInputLabel.Text = "Customer Address";
            // 
            // customerAddressInput
            // 
            this.customerAddressInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerAddressInput.Location = new System.Drawing.Point(318, 78);
            this.customerAddressInput.Name = "customerAddressInput";
            this.customerAddressInput.Size = new System.Drawing.Size(230, 30);
            this.customerAddressInput.TabIndex = 3;
            // 
            // customerPhoneInputLabel
            // 
            this.customerPhoneInputLabel.AutoSize = true;
            this.customerPhoneInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerPhoneInputLabel.Location = new System.Drawing.Point(568, 44);
            this.customerPhoneInputLabel.Name = "customerPhoneInputLabel";
            this.customerPhoneInputLabel.Size = new System.Drawing.Size(233, 25);
            this.customerPhoneInputLabel.TabIndex = 6;
            this.customerPhoneInputLabel.Text = "Customer Phone Number";
            // 
            // customerPhoneInput
            // 
            this.customerPhoneInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerPhoneInput.Location = new System.Drawing.Point(573, 78);
            this.customerPhoneInput.Name = "customerPhoneInput";
            this.customerPhoneInput.Size = new System.Drawing.Size(230, 30);
            this.customerPhoneInput.TabIndex = 5;
            // 
            // customerCityInputLabel
            // 
            this.customerCityInputLabel.AutoSize = true;
            this.customerCityInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerCityInputLabel.Location = new System.Drawing.Point(34, 156);
            this.customerCityInputLabel.Name = "customerCityInputLabel";
            this.customerCityInputLabel.Size = new System.Drawing.Size(170, 31);
            this.customerCityInputLabel.TabIndex = 8;
            this.customerCityInputLabel.Text = "Customer City";
            // 
            // customerCityInput
            // 
            this.customerCityInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerCityInput.Location = new System.Drawing.Point(39, 195);
            this.customerCityInput.Name = "customerCityInput";
            this.customerCityInput.Size = new System.Drawing.Size(230, 30);
            this.customerCityInput.TabIndex = 7;
            // 
            // customerCountryInputLabel
            // 
            this.customerCountryInputLabel.AutoSize = true;
            this.customerCountryInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerCountryInputLabel.Location = new System.Drawing.Point(313, 156);
            this.customerCountryInputLabel.Name = "customerCountryInputLabel";
            this.customerCountryInputLabel.Size = new System.Drawing.Size(214, 31);
            this.customerCountryInputLabel.TabIndex = 10;
            this.customerCountryInputLabel.Text = "Customer Country";
            // 
            // customerCountryInput
            // 
            this.customerCountryInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.customerCountryInput.Location = new System.Drawing.Point(318, 195);
            this.customerCountryInput.Name = "customerCountryInput";
            this.customerCountryInput.Size = new System.Drawing.Size(230, 30);
            this.customerCountryInput.TabIndex = 9;
            // 
            // saveCustomerButton
            // 
            this.saveCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.saveCustomerButton.Location = new System.Drawing.Point(55, 272);
            this.saveCustomerButton.Name = "saveCustomerButton";
            this.saveCustomerButton.Size = new System.Drawing.Size(198, 52);
            this.saveCustomerButton.TabIndex = 11;
            this.saveCustomerButton.Text = "Save Customer";
            this.saveCustomerButton.UseVisualStyleBackColor = true;
            this.saveCustomerButton.Click += new System.EventHandler(this.saveCustomerButton_Click);
            // 
            // customerEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 699);
            this.Controls.Add(this.saveCustomerButton);
            this.Controls.Add(this.customerCountryInputLabel);
            this.Controls.Add(this.customerCountryInput);
            this.Controls.Add(this.customerCityInputLabel);
            this.Controls.Add(this.customerCityInput);
            this.Controls.Add(this.customerPhoneInputLabel);
            this.Controls.Add(this.customerPhoneInput);
            this.Controls.Add(this.customerAddressInputLabel);
            this.Controls.Add(this.customerAddressInput);
            this.Controls.Add(this.customerNameInputLabel);
            this.Controls.Add(this.customerNameInput);
            this.Name = "customerEdit";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customerNameInput;
        private System.Windows.Forms.Label customerNameInputLabel;
        private System.Windows.Forms.Label customerAddressInputLabel;
        private System.Windows.Forms.TextBox customerAddressInput;
        private System.Windows.Forms.Label customerPhoneInputLabel;
        private System.Windows.Forms.TextBox customerPhoneInput;
        private System.Windows.Forms.Label customerCityInputLabel;
        private System.Windows.Forms.TextBox customerCityInput;
        private System.Windows.Forms.Label customerCountryInputLabel;
        private System.Windows.Forms.TextBox customerCountryInput;
        private System.Windows.Forms.Button saveCustomerButton;
    }
}