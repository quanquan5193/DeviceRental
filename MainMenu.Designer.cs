
namespace DeviceRental
{
    partial class MainMenu
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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDeviceRental = new System.Windows.Forms.TabPage();
            this.dgvDeviceRental = new System.Windows.Forms.DataGridView();
            this.tabEmployee = new System.Windows.Forms.TabPage();
            this.tabDevice = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabDeviceRental.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceRental)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDeviceRental);
            this.tabControl1.Controls.Add(this.tabEmployee);
            this.tabControl1.Controls.Add(this.tabDevice);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(775, 425);
            this.tabControl1.TabIndex = 1;
            // 
            // tabDeviceRental
            // 
            this.tabDeviceRental.Controls.Add(this.dgvDeviceRental);
            this.tabDeviceRental.Location = new System.Drawing.Point(4, 22);
            this.tabDeviceRental.Name = "tabDeviceRental";
            this.tabDeviceRental.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeviceRental.Size = new System.Drawing.Size(767, 399);
            this.tabDeviceRental.TabIndex = 0;
            this.tabDeviceRental.Text = "Device Rental";
            this.tabDeviceRental.UseVisualStyleBackColor = true;
            // 
            // dgvDeviceRental
            // 
            this.dgvDeviceRental.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeviceRental.Location = new System.Drawing.Point(7, 7);
            this.dgvDeviceRental.MultiSelect = false;
            this.dgvDeviceRental.Name = "dgvDeviceRental";
            this.dgvDeviceRental.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceRental.Size = new System.Drawing.Size(754, 306);
            this.dgvDeviceRental.TabIndex = 0;
            this.dgvDeviceRental.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDeviceRental_CellContentClick);
            // 
            // tabEmployee
            // 
            this.tabEmployee.Location = new System.Drawing.Point(4, 22);
            this.tabEmployee.Name = "tabEmployee";
            this.tabEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmployee.Size = new System.Drawing.Size(767, 399);
            this.tabEmployee.TabIndex = 1;
            this.tabEmployee.Text = "Employee";
            this.tabEmployee.UseVisualStyleBackColor = true;
            // 
            // tabDevice
            // 
            this.tabDevice.Location = new System.Drawing.Point(4, 22);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Size = new System.Drawing.Size(767, 399);
            this.tabDevice.TabIndex = 2;
            this.tabDevice.Text = "Device";
            this.tabDevice.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainMenu";
            this.Text = "Device Rental";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabDeviceRental.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceRental)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDeviceRental;
        private System.Windows.Forms.TabPage tabEmployee;
        private System.Windows.Forms.TabPage tabDevice;
        private System.Windows.Forms.DataGridView dgvDeviceRental;
    }
}

