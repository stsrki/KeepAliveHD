namespace KeepAliveHD.Forms
{
    partial class VolumeNames
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgVolumeNames = new System.Windows.Forms.DataGridView();
            this.VolumeNamesName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgVolumeNames)).BeginInit();
            this.SuspendLayout();
            // 
            // dgVolumeNames
            // 
            this.dgVolumeNames.AllowUserToOrderColumns = true;
            this.dgVolumeNames.AllowUserToResizeRows = false;
            this.dgVolumeNames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVolumeNames.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgVolumeNames.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgVolumeNames.ColumnHeadersHeight = 20;
            this.dgVolumeNames.ColumnHeadersVisible = false;
            this.dgVolumeNames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VolumeNamesName});
            this.dgVolumeNames.Location = new System.Drawing.Point(12, 12);
            this.dgVolumeNames.MultiSelect = false;
            this.dgVolumeNames.Name = "dgVolumeNames";
            this.dgVolumeNames.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgVolumeNames.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgVolumeNames.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgVolumeNames.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVolumeNames.Size = new System.Drawing.Size(330, 144);
            this.dgVolumeNames.TabIndex = 2;
            this.dgVolumeNames.SelectionChanged += new System.EventHandler(this.dgVolumeNames_SelectionChanged);
            // 
            // VolumeNamesName
            // 
            this.VolumeNamesName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.VolumeNamesName.DataPropertyName = "Name";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.VolumeNamesName.DefaultCellStyle = dataGridViewCellStyle1;
            this.VolumeNamesName.HeaderText = "Volume Name";
            this.VolumeNamesName.Name = "VolumeNamesName";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::KeepAliveHD.Properties.Resources.ActionCancel_16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(180, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "   Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Image = global::KeepAliveHD.Properties.Resources.ActionAccept_16x16;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(12, 162);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(162, 25);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "   Accept";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // VolumeNames
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 199);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.dgVolumeNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VolumeNames";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Volume Name";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VolumeNames_FormClosing);
            this.Load += new System.EventHandler(this.VolumeNames_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgVolumeNames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgVolumeNames;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolumeNamesName;
    }
}