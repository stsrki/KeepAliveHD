namespace KeepAliveHD.Forms
{
    partial class DriveSettingsMulti
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDrives = new System.Windows.Forms.TextBox();
            this.numTimeInterval = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cboTimeUnit = new System.Windows.Forms.ComboBox();
            this.cboOperation = new System.Windows.Forms.ComboBox();
            this.lblOperationInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(280, 55);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 17;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Selected drives";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDrives
            // 
            this.txtDrives.Location = new System.Drawing.Point(15, 25);
            this.txtDrives.Name = "txtDrives";
            this.txtDrives.ReadOnly = true;
            this.txtDrives.Size = new System.Drawing.Size(329, 20);
            this.txtDrives.TabIndex = 13;
            // 
            // numTimeInterval
            // 
            this.numTimeInterval.Location = new System.Drawing.Point(144, 52);
            this.numTimeInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimeInterval.Name = "numTimeInterval";
            this.numTimeInterval.Size = new System.Drawing.Size(48, 20);
            this.numTimeInterval.TabIndex = 11;
            this.numTimeInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::KeepAliveHD.Properties.Resources.ActionCancel_16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(183, 78);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 25);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "   Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Image = global::KeepAliveHD.Properties.Resources.ActionAccept_16x16;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(15, 78);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(162, 25);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "   Accept";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // cboTimeUnit
            // 
            this.cboTimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeUnit.FormattingEnabled = true;
            this.cboTimeUnit.Location = new System.Drawing.Point(198, 51);
            this.cboTimeUnit.Name = "cboTimeUnit";
            this.cboTimeUnit.Size = new System.Drawing.Size(68, 21);
            this.cboTimeUnit.TabIndex = 18;
            // 
            // cboOperation
            // 
            this.cboOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperation.FormattingEnabled = true;
            this.cboOperation.Location = new System.Drawing.Point(15, 51);
            this.cboOperation.Name = "cboOperation";
            this.cboOperation.Size = new System.Drawing.Size(68, 21);
            this.cboOperation.TabIndex = 19;
            this.cboOperation.SelectedIndexChanged += new System.EventHandler(this.cboOperation_SelectedIndexChanged);
            // 
            // lblOperationInfo
            // 
            this.lblOperationInfo.AutoSize = true;
            this.lblOperationInfo.Location = new System.Drawing.Point(89, 54);
            this.lblOperationInfo.Name = "lblOperationInfo";
            this.lblOperationInfo.Size = new System.Drawing.Size(49, 13);
            this.lblOperationInfo.TabIndex = 20;
            this.lblOperationInfo.Text = "file every";
            this.lblOperationInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DriveSettingsMulti
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(356, 114);
            this.Controls.Add(this.lblOperationInfo);
            this.Controls.Add(this.cboOperation);
            this.Controls.Add(this.cboTimeUnit);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDrives);
            this.Controls.Add(this.numTimeInterval);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriveSettingsMulti";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Multiple Drive Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DriveSettingsMulti_FormClosing);
            this.Load += new System.EventHandler(this.DriveSettingsMulti_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTimeInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDrives;
        private System.Windows.Forms.NumericUpDown numTimeInterval;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ComboBox cboTimeUnit;
        private System.Windows.Forms.ComboBox cboOperation;
        private System.Windows.Forms.Label lblOperationInfo;
    }
}