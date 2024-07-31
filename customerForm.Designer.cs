namespace calendarApp
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
            this.customerTable = new System.Windows.Forms.DataGridView();
            this.editCustomerButton = new System.Windows.Forms.Button();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.newCustomerButton = new System.Windows.Forms.Button();
            this.mySqlDataAdapter1 = new MySql.Data.MySqlClient.MySqlDataAdapter();
            this.calendarButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).BeginInit();
            this.SuspendLayout();
            // 
            // customerTable
            // 
            this.customerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customerTable.Location = new System.Drawing.Point(12, 66);
            this.customerTable.Name = "customerTable";
            this.customerTable.RowHeadersWidth = 51;
            this.customerTable.RowTemplate.Height = 24;
            this.customerTable.Size = new System.Drawing.Size(1032, 482);
            this.customerTable.TabIndex = 0;
            // 
            // editCustomerButton
            // 
            this.editCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.editCustomerButton.Location = new System.Drawing.Point(34, 573);
            this.editCustomerButton.Name = "editCustomerButton";
            this.editCustomerButton.Size = new System.Drawing.Size(154, 50);
            this.editCustomerButton.TabIndex = 1;
            this.editCustomerButton.Text = "Edit Customer";
            this.editCustomerButton.UseVisualStyleBackColor = true;
            this.editCustomerButton.Click += new System.EventHandler(this.editCustomerButton_Click);
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.deleteCustomerButton.Location = new System.Drawing.Point(246, 573);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(169, 49);
            this.deleteCustomerButton.TabIndex = 2;
            this.deleteCustomerButton.Text = "Delete Customer";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // newCustomerButton
            // 
            this.newCustomerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.newCustomerButton.Location = new System.Drawing.Point(454, 573);
            this.newCustomerButton.Name = "newCustomerButton";
            this.newCustomerButton.Size = new System.Drawing.Size(200, 50);
            this.newCustomerButton.TabIndex = 3;
            this.newCustomerButton.Text = "Add Customer";
            this.newCustomerButton.UseVisualStyleBackColor = true;
            this.newCustomerButton.Click += new System.EventHandler(this.newCustomerButton_Click);
            // 
            // mySqlDataAdapter1
            // 
            this.mySqlDataAdapter1.DeleteCommand = null;
            this.mySqlDataAdapter1.InsertCommand = null;
            this.mySqlDataAdapter1.SelectCommand = null;
            this.mySqlDataAdapter1.UpdateCommand = null;
            // 
            // calendarButton
            // 
            this.calendarButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.calendarButton.Location = new System.Drawing.Point(850, 578);
            this.calendarButton.Name = "calendarButton";
            this.calendarButton.Size = new System.Drawing.Size(193, 43);
            this.calendarButton.TabIndex = 4;
            this.calendarButton.Text = "Calendar";
            this.calendarButton.UseVisualStyleBackColor = true;
            this.calendarButton.Click += new System.EventHandler(this.calendarButton_Click);
            // 
            // customerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 772);
            this.Controls.Add(this.calendarButton);
            this.Controls.Add(this.newCustomerButton);
            this.Controls.Add(this.deleteCustomerButton);
            this.Controls.Add(this.editCustomerButton);
            this.Controls.Add(this.customerTable);
            this.Name = "customerForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.customerTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView customerTable;
        private System.Windows.Forms.Button editCustomerButton;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.Button newCustomerButton;
        private MySql.Data.MySqlClient.MySqlDataAdapter mySqlDataAdapter1;
        private System.Windows.Forms.Button calendarButton;
    }
}