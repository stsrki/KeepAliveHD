namespace KeepAliveHD.Forms
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle44 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle41 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle42 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle43 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageConfiguration = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgDrives = new System.Windows.Forms.DataGridView();
            this.DrivesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrivesLetter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrivesVolumeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrivesWriteTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DrivesWriteTimeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriveStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriveStatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsDrives = new System.Windows.Forms.ToolStrip();
            this.btnDriveNew = new System.Windows.Forms.ToolStripButton();
            this.btnDriveDelete = new System.Windows.Forms.ToolStripButton();
            this.btnDriveEdit = new System.Windows.Forms.ToolStripSplitButton();
            this.btnDriveVolumeNamesEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageDriveInfo = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tsConnectedDrives = new System.Windows.Forms.ToolStrip();
            this.btnDriveNewMulti = new System.Windows.Forms.ToolStripButton();
            this.btnConnectedDriveRefresh = new System.Windows.Forms.Button();
            this.dgConnectedDrives = new System.Windows.Forms.DataGridView();
            this.InfoDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoVolumeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoTotalSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoFreeSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InfoType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkDelayWriteOnResume = new System.Windows.Forms.CheckBox();
            this.chkIgnoreVolumeNames = new System.Windows.Forms.CheckBox();
            this.btnOpenLogDir = new System.Windows.Forms.Button();
            this.chkLogMessages = new System.Windows.Forms.CheckBox();
            this.chkDeleteTextFile = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.chkHideTrayIcon = new System.Windows.Forms.CheckBox();
            this.cboTimeUnit = new System.Windows.Forms.ComboBox();
            this.numTimeAmount = new System.Windows.Forms.NumericUpDown();
            this.chkTurnOffWhenUserInactive = new System.Windows.Forms.CheckBox();
            this.chkMinimizeOnClose = new System.Windows.Forms.CheckBox();
            this.chkSystemHideInTray = new System.Windows.Forms.CheckBox();
            this.chkSystemAutoRun = new System.Windows.Forms.CheckBox();
            this.tabPageAbout = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lnkEmail = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lnkHomepage = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ilTabs32 = new System.Windows.Forms.ImageList(this.components);
            this.tmrIdle = new System.Windows.Forms.Timer(this.components);
            this.ntfTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctxTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxTrayShow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ctxTrayClose = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEngineStop = new System.Windows.Forms.Button();
            this.btnEngineStart = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabPageConfiguration.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDrives)).BeginInit();
            this.tsDrives.SuspendLayout();
            this.tabPageDriveInfo.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tsConnectedDrives.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConnectedDrives)).BeginInit();
            this.tabPageSettings.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeAmount)).BeginInit();
            this.tabPageAbout.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.ctxTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMain.Controls.Add(this.tabPageConfiguration);
            this.tabMain.Controls.Add(this.tabPageDriveInfo);
            this.tabMain.Controls.Add(this.tabPageSettings);
            this.tabMain.Controls.Add(this.tabPageAbout);
            this.tabMain.ImageList = this.ilTabs32;
            this.tabMain.Location = new System.Drawing.Point(12, 12);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(478, 411);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            // 
            // tabPageConfiguration
            // 
            this.tabPageConfiguration.Controls.Add(this.groupBox1);
            this.tabPageConfiguration.ImageKey = "TabPageDriveGo_32x32.png";
            this.tabPageConfiguration.Location = new System.Drawing.Point(4, 39);
            this.tabPageConfiguration.Name = "tabPageConfiguration";
            this.tabPageConfiguration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfiguration.Size = new System.Drawing.Size(470, 368);
            this.tabPageConfiguration.TabIndex = 0;
            this.tabPageConfiguration.Text = "Configuration  ";
            this.tabPageConfiguration.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnEngineStart);
            this.groupBox1.Controls.Add(this.btnEngineStop);
            this.groupBox1.Controls.Add(this.dgDrives);
            this.groupBox1.Controls.Add(this.tsDrives);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 356);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Drive options";
            // 
            // dgDrives
            // 
            this.dgDrives.AllowUserToAddRows = false;
            this.dgDrives.AllowUserToDeleteRows = false;
            this.dgDrives.AllowUserToOrderColumns = true;
            this.dgDrives.AllowUserToResizeRows = false;
            this.dgDrives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDrives.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgDrives.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgDrives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgDrives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DrivesID,
            this.DrivesLetter,
            this.DrivesVolumeName,
            this.DrivesWriteTime,
            this.DrivesWriteTimeText,
            this.DriveStatus,
            this.DriveStatusText});
            this.dgDrives.Location = new System.Drawing.Point(6, 58);
            this.dgDrives.Name = "dgDrives";
            this.dgDrives.ReadOnly = true;
            this.dgDrives.RowHeadersVisible = false;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.Color.Black;
            this.dgDrives.RowsDefaultCellStyle = dataGridViewCellStyle39;
            this.dgDrives.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgDrives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDrives.Size = new System.Drawing.Size(446, 263);
            this.dgDrives.TabIndex = 1;
            this.dgDrives.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgDrives_CellMouseDoubleClick);
            this.dgDrives.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgDrives_RowsAdded);
            this.dgDrives.SelectionChanged += new System.EventHandler(this.dgDrives_SelectionChanged);
            this.dgDrives.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgDrives_KeyDown);
            // 
            // DrivesID
            // 
            this.DrivesID.DataPropertyName = "ID";
            this.DrivesID.HeaderText = "DrivesID";
            this.DrivesID.Name = "DrivesID";
            this.DrivesID.ReadOnly = true;
            this.DrivesID.Visible = false;
            // 
            // DrivesLetter
            // 
            this.DrivesLetter.DataPropertyName = "Drive";
            this.DrivesLetter.HeaderText = "Drive";
            this.DrivesLetter.Name = "DrivesLetter";
            this.DrivesLetter.ReadOnly = true;
            // 
            // DrivesVolumeName
            // 
            this.DrivesVolumeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DrivesVolumeName.DataPropertyName = "VolumeName";
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DrivesVolumeName.DefaultCellStyle = dataGridViewCellStyle34;
            this.DrivesVolumeName.HeaderText = "Volume Name(s)";
            this.DrivesVolumeName.Name = "DrivesVolumeName";
            this.DrivesVolumeName.ReadOnly = true;
            // 
            // DrivesWriteTime
            // 
            this.DrivesWriteTime.DataPropertyName = "TimeInterval";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DrivesWriteTime.DefaultCellStyle = dataGridViewCellStyle35;
            this.DrivesWriteTime.HeaderText = "Write Every";
            this.DrivesWriteTime.Name = "DrivesWriteTime";
            this.DrivesWriteTime.ReadOnly = true;
            this.DrivesWriteTime.Visible = false;
            this.DrivesWriteTime.Width = 80;
            // 
            // DrivesWriteTimeText
            // 
            this.DrivesWriteTimeText.DataPropertyName = "TimeIntervalText";
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DrivesWriteTimeText.DefaultCellStyle = dataGridViewCellStyle36;
            this.DrivesWriteTimeText.HeaderText = "Interval";
            this.DrivesWriteTimeText.Name = "DrivesWriteTimeText";
            this.DrivesWriteTimeText.ReadOnly = true;
            this.DrivesWriteTimeText.Width = 90;
            // 
            // DriveStatus
            // 
            this.DriveStatus.DataPropertyName = "Status";
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DriveStatus.DefaultCellStyle = dataGridViewCellStyle37;
            this.DriveStatus.HeaderText = "Status";
            this.DriveStatus.Name = "DriveStatus";
            this.DriveStatus.ReadOnly = true;
            this.DriveStatus.Visible = false;
            this.DriveStatus.Width = 90;
            // 
            // DriveStatusText
            // 
            this.DriveStatusText.DataPropertyName = "StatusText";
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DriveStatusText.DefaultCellStyle = dataGridViewCellStyle38;
            this.DriveStatusText.HeaderText = "Status";
            this.DriveStatusText.Name = "DriveStatusText";
            this.DriveStatusText.ReadOnly = true;
            this.DriveStatusText.Width = 90;
            // 
            // tsDrives
            // 
            this.tsDrives.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsDrives.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDriveNew,
            this.btnDriveDelete,
            this.btnDriveEdit});
            this.tsDrives.Location = new System.Drawing.Point(3, 16);
            this.tsDrives.Name = "tsDrives";
            this.tsDrives.Size = new System.Drawing.Size(452, 39);
            this.tsDrives.TabIndex = 0;
            this.tsDrives.Text = "toolStrip1";
            // 
            // btnDriveNew
            // 
            this.btnDriveNew.Image = global::KeepAliveHD.Properties.Resources.ActionDriveAdd_32x32;
            this.btnDriveNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDriveNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDriveNew.Name = "btnDriveNew";
            this.btnDriveNew.Size = new System.Drawing.Size(94, 36);
            this.btnDriveNew.Text = "Add drive";
            this.btnDriveNew.Click += new System.EventHandler(this.btnDriveNew_Click);
            // 
            // btnDriveDelete
            // 
            this.btnDriveDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnDriveDelete.Image = global::KeepAliveHD.Properties.Resources.ActionDriveRemove_32x32;
            this.btnDriveDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDriveDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDriveDelete.Name = "btnDriveDelete";
            this.btnDriveDelete.Size = new System.Drawing.Size(115, 36);
            this.btnDriveDelete.Text = "Remove drive";
            this.btnDriveDelete.Click += new System.EventHandler(this.btnDriveDelete_Click);
            // 
            // btnDriveEdit
            // 
            this.btnDriveEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDriveVolumeNamesEdit});
            this.btnDriveEdit.Image = global::KeepAliveHD.Properties.Resources.ActionDriveEdit_32x32;
            this.btnDriveEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDriveEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDriveEdit.Name = "btnDriveEdit";
            this.btnDriveEdit.Size = new System.Drawing.Size(104, 36);
            this.btnDriveEdit.Text = "Edit drive";
            this.btnDriveEdit.ButtonClick += new System.EventHandler(this.btnDriveEdit_ButtonClick);
            // 
            // btnDriveVolumeNamesEdit
            // 
            this.btnDriveVolumeNamesEdit.Name = "btnDriveVolumeNamesEdit";
            this.btnDriveVolumeNamesEdit.Size = new System.Drawing.Size(189, 22);
            this.btnDriveVolumeNamesEdit.Text = "Define volume names";
            this.btnDriveVolumeNamesEdit.Click += new System.EventHandler(this.btnDriveVolumeNamesEdit_Click);
            // 
            // tabPageDriveInfo
            // 
            this.tabPageDriveInfo.Controls.Add(this.groupBox3);
            this.tabPageDriveInfo.ImageKey = "TabPageDriveInfo_32x32.png";
            this.tabPageDriveInfo.Location = new System.Drawing.Point(4, 39);
            this.tabPageDriveInfo.Name = "tabPageDriveInfo";
            this.tabPageDriveInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDriveInfo.Size = new System.Drawing.Size(470, 368);
            this.tabPageDriveInfo.TabIndex = 1;
            this.tabPageDriveInfo.Text = "Drive info  ";
            this.tabPageDriveInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tsConnectedDrives);
            this.groupBox3.Controls.Add(this.btnConnectedDriveRefresh);
            this.groupBox3.Controls.Add(this.dgConnectedDrives);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(458, 356);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Connected drives";
            // 
            // tsConnectedDrives
            // 
            this.tsConnectedDrives.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsConnectedDrives.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDriveNewMulti});
            this.tsConnectedDrives.Location = new System.Drawing.Point(3, 16);
            this.tsConnectedDrives.Name = "tsConnectedDrives";
            this.tsConnectedDrives.Size = new System.Drawing.Size(452, 39);
            this.tsConnectedDrives.TabIndex = 4;
            this.tsConnectedDrives.Text = "toolStrip1";
            // 
            // btnDriveNewMulti
            // 
            this.btnDriveNewMulti.Image = global::KeepAliveHD.Properties.Resources.ActionDriveAdd_32x32;
            this.btnDriveNewMulti.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDriveNewMulti.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDriveNewMulti.Name = "btnDriveNewMulti";
            this.btnDriveNewMulti.Size = new System.Drawing.Size(160, 36);
            this.btnDriveNewMulti.Text = "Add all selected drives";
            this.btnDriveNewMulti.ToolTipText = "Add all selected drives to the writing mode";
            this.btnDriveNewMulti.Click += new System.EventHandler(this.btnDriveNewMulti_Click);
            // 
            // btnConnectedDriveRefresh
            // 
            this.btnConnectedDriveRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectedDriveRefresh.Location = new System.Drawing.Point(6, 327);
            this.btnConnectedDriveRefresh.Name = "btnConnectedDriveRefresh";
            this.btnConnectedDriveRefresh.Size = new System.Drawing.Size(446, 23);
            this.btnConnectedDriveRefresh.TabIndex = 3;
            this.btnConnectedDriveRefresh.Text = "Refresh";
            this.btnConnectedDriveRefresh.UseVisualStyleBackColor = true;
            this.btnConnectedDriveRefresh.Click += new System.EventHandler(this.btnConnectedDriveRefresh_Click);
            // 
            // dgConnectedDrives
            // 
            this.dgConnectedDrives.AllowUserToAddRows = false;
            this.dgConnectedDrives.AllowUserToDeleteRows = false;
            this.dgConnectedDrives.AllowUserToOrderColumns = true;
            this.dgConnectedDrives.AllowUserToResizeRows = false;
            this.dgConnectedDrives.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgConnectedDrives.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgConnectedDrives.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgConnectedDrives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgConnectedDrives.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InfoDrive,
            this.InfoVolumeName,
            this.InfoTotalSize,
            this.InfoFreeSpace,
            this.InfoType});
            this.dgConnectedDrives.Location = new System.Drawing.Point(6, 58);
            this.dgConnectedDrives.Name = "dgConnectedDrives";
            this.dgConnectedDrives.ReadOnly = true;
            this.dgConnectedDrives.RowHeadersVisible = false;
            dataGridViewCellStyle44.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle44.SelectionForeColor = System.Drawing.Color.Black;
            this.dgConnectedDrives.RowsDefaultCellStyle = dataGridViewCellStyle44;
            this.dgConnectedDrives.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgConnectedDrives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgConnectedDrives.Size = new System.Drawing.Size(446, 263);
            this.dgConnectedDrives.TabIndex = 2;
            this.dgConnectedDrives.SelectionChanged += new System.EventHandler(this.dgConnectedDrives_SelectionChanged);
            // 
            // InfoDrive
            // 
            this.InfoDrive.DataPropertyName = "Drive";
            this.InfoDrive.HeaderText = "Drive";
            this.InfoDrive.Name = "InfoDrive";
            this.InfoDrive.ReadOnly = true;
            // 
            // InfoVolumeName
            // 
            this.InfoVolumeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InfoVolumeName.DataPropertyName = "VolumeName";
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.InfoVolumeName.DefaultCellStyle = dataGridViewCellStyle40;
            this.InfoVolumeName.HeaderText = "Volume Name";
            this.InfoVolumeName.Name = "InfoVolumeName";
            this.InfoVolumeName.ReadOnly = true;
            // 
            // InfoTotalSize
            // 
            this.InfoTotalSize.DataPropertyName = "TotalSize";
            dataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.InfoTotalSize.DefaultCellStyle = dataGridViewCellStyle41;
            this.InfoTotalSize.HeaderText = "Total Size";
            this.InfoTotalSize.Name = "InfoTotalSize";
            this.InfoTotalSize.ReadOnly = true;
            this.InfoTotalSize.Width = 70;
            // 
            // InfoFreeSpace
            // 
            this.InfoFreeSpace.DataPropertyName = "FreeSpace";
            dataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.InfoFreeSpace.DefaultCellStyle = dataGridViewCellStyle42;
            this.InfoFreeSpace.HeaderText = "Free Space";
            this.InfoFreeSpace.Name = "InfoFreeSpace";
            this.InfoFreeSpace.ReadOnly = true;
            this.InfoFreeSpace.Width = 70;
            // 
            // InfoType
            // 
            this.InfoType.DataPropertyName = "DriveType";
            dataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.InfoType.DefaultCellStyle = dataGridViewCellStyle43;
            this.InfoType.HeaderText = "Type";
            this.InfoType.Name = "InfoType";
            this.InfoType.ReadOnly = true;
            this.InfoType.Width = 80;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.groupBox5);
            this.tabPageSettings.Controls.Add(this.groupBox2);
            this.tabPageSettings.ImageKey = "TabPageConfiguration_32x32.png";
            this.tabPageSettings.Location = new System.Drawing.Point(4, 39);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(470, 368);
            this.tabPageSettings.TabIndex = 3;
            this.tabPageSettings.Text = "Settings  ";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.chkDelayWriteOnResume);
            this.groupBox5.Controls.Add(this.chkIgnoreVolumeNames);
            this.groupBox5.Controls.Add(this.btnOpenLogDir);
            this.groupBox5.Controls.Add(this.chkLogMessages);
            this.groupBox5.Controls.Add(this.chkDeleteTextFile);
            this.groupBox5.Location = new System.Drawing.Point(6, 135);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(458, 227);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Behaviour";
            // 
            // chkDelayWriteOnResume
            // 
            this.chkDelayWriteOnResume.AutoSize = true;
            this.chkDelayWriteOnResume.Location = new System.Drawing.Point(6, 103);
            this.chkDelayWriteOnResume.Name = "chkDelayWriteOnResume";
            this.chkDelayWriteOnResume.Size = new System.Drawing.Size(238, 17);
            this.chkDelayWriteOnResume.TabIndex = 5;
            this.chkDelayWriteOnResume.Text = "Delay writing when resumed from sleep mode";
            this.chkDelayWriteOnResume.UseVisualStyleBackColor = true;
            this.chkDelayWriteOnResume.CheckedChanged += new System.EventHandler(this.chkDelayWriteOnResume_CheckedChanged);
            // 
            // chkIgnoreVolumeNames
            // 
            this.chkIgnoreVolumeNames.AutoSize = true;
            this.chkIgnoreVolumeNames.Location = new System.Drawing.Point(6, 47);
            this.chkIgnoreVolumeNames.Name = "chkIgnoreVolumeNames";
            this.chkIgnoreVolumeNames.Size = new System.Drawing.Size(127, 17);
            this.chkIgnoreVolumeNames.TabIndex = 4;
            this.chkIgnoreVolumeNames.Text = "Ignore volume names";
            this.chkIgnoreVolumeNames.UseVisualStyleBackColor = true;
            this.chkIgnoreVolumeNames.CheckedChanged += new System.EventHandler(this.chkIgnoreVolumeNames_CheckedChanged);
            // 
            // btnOpenLogDir
            // 
            this.btnOpenLogDir.Location = new System.Drawing.Point(157, 72);
            this.btnOpenLogDir.Name = "btnOpenLogDir";
            this.btnOpenLogDir.Size = new System.Drawing.Size(106, 21);
            this.btnOpenLogDir.TabIndex = 3;
            this.btnOpenLogDir.Text = "Open logs directory";
            this.btnOpenLogDir.UseVisualStyleBackColor = true;
            this.btnOpenLogDir.Click += new System.EventHandler(this.btnOpenLogDir_Click);
            // 
            // chkLogMessages
            // 
            this.chkLogMessages.AutoSize = true;
            this.chkLogMessages.Location = new System.Drawing.Point(6, 75);
            this.chkLogMessages.Name = "chkLogMessages";
            this.chkLogMessages.Size = new System.Drawing.Size(131, 17);
            this.chkLogMessages.TabIndex = 2;
            this.chkLogMessages.Text = "Log all error messages";
            this.chkLogMessages.UseVisualStyleBackColor = true;
            this.chkLogMessages.CheckedChanged += new System.EventHandler(this.chkLogMessages_CheckedChanged);
            // 
            // chkDeleteTextFile
            // 
            this.chkDeleteTextFile.AutoSize = true;
            this.chkDeleteTextFile.Location = new System.Drawing.Point(6, 19);
            this.chkDeleteTextFile.Name = "chkDeleteTextFile";
            this.chkDeleteTextFile.Size = new System.Drawing.Size(208, 17);
            this.chkDeleteTextFile.TabIndex = 1;
            this.chkDeleteTextFile.Text = "Delete text file after it has being written";
            this.chkDeleteTextFile.UseVisualStyleBackColor = true;
            this.chkDeleteTextFile.CheckedChanged += new System.EventHandler(this.chkDeleteTextFile_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkStartMinimized);
            this.groupBox2.Controls.Add(this.chkHideTrayIcon);
            this.groupBox2.Controls.Add(this.cboTimeUnit);
            this.groupBox2.Controls.Add(this.numTimeAmount);
            this.groupBox2.Controls.Add(this.chkTurnOffWhenUserInactive);
            this.groupBox2.Controls.Add(this.chkMinimizeOnClose);
            this.groupBox2.Controls.Add(this.chkSystemHideInTray);
            this.groupBox2.Controls.Add(this.chkSystemAutoRun);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "System";
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.Location = new System.Drawing.Point(6, 98);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(96, 17);
            this.chkStartMinimized.TabIndex = 11;
            this.chkStartMinimized.Text = "Start minimized";
            this.chkStartMinimized.UseVisualStyleBackColor = true;
            this.chkStartMinimized.CheckedChanged += new System.EventHandler(this.chkStartMinimized_CheckedChanged);
            // 
            // chkHideTrayIcon
            // 
            this.chkHideTrayIcon.AutoSize = true;
            this.chkHideTrayIcon.Location = new System.Drawing.Point(214, 71);
            this.chkHideTrayIcon.Name = "chkHideTrayIcon";
            this.chkHideTrayIcon.Size = new System.Drawing.Size(218, 17);
            this.chkHideTrayIcon.TabIndex = 10;
            this.chkHideTrayIcon.Text = "Hide tray icon when minimized (not used)";
            this.chkHideTrayIcon.UseVisualStyleBackColor = true;
            this.chkHideTrayIcon.Visible = false;
            this.chkHideTrayIcon.CheckedChanged += new System.EventHandler(this.chkHideTrayIcon_CheckedChanged);
            // 
            // cboTimeUnit
            // 
            this.cboTimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTimeUnit.FormattingEnabled = true;
            this.cboTimeUnit.Location = new System.Drawing.Point(325, 39);
            this.cboTimeUnit.Name = "cboTimeUnit";
            this.cboTimeUnit.Size = new System.Drawing.Size(63, 21);
            this.cboTimeUnit.TabIndex = 9;
            this.cboTimeUnit.SelectedIndexChanged += new System.EventHandler(this.cboTimeUnit_SelectedIndexChanged);
            // 
            // numTimeAmount
            // 
            this.numTimeAmount.Location = new System.Drawing.Point(271, 39);
            this.numTimeAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimeAmount.Name = "numTimeAmount";
            this.numTimeAmount.Size = new System.Drawing.Size(48, 20);
            this.numTimeAmount.TabIndex = 8;
            this.numTimeAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimeAmount.ValueChanged += new System.EventHandler(this.numTimeAmount_ValueChanged);
            // 
            // chkTurnOffWhenUserInactive
            // 
            this.chkTurnOffWhenUserInactive.AutoSize = true;
            this.chkTurnOffWhenUserInactive.Location = new System.Drawing.Point(252, 19);
            this.chkTurnOffWhenUserInactive.Name = "chkTurnOffWhenUserInactive";
            this.chkTurnOffWhenUserInactive.Size = new System.Drawing.Size(200, 17);
            this.chkTurnOffWhenUserInactive.TabIndex = 3;
            this.chkTurnOffWhenUserInactive.Text = "Disable writing if user is not active for";
            this.chkTurnOffWhenUserInactive.UseVisualStyleBackColor = true;
            this.chkTurnOffWhenUserInactive.CheckedChanged += new System.EventHandler(this.chkTurnOffWhenUserInactive_CheckedChanged);
            // 
            // chkMinimizeOnClose
            // 
            this.chkMinimizeOnClose.AutoSize = true;
            this.chkMinimizeOnClose.Location = new System.Drawing.Point(23, 71);
            this.chkMinimizeOnClose.Name = "chkMinimizeOnClose";
            this.chkMinimizeOnClose.Size = new System.Drawing.Size(142, 17);
            this.chkMinimizeOnClose.TabIndex = 2;
            this.chkMinimizeOnClose.Text = "Minimize on close button";
            this.chkMinimizeOnClose.UseVisualStyleBackColor = true;
            this.chkMinimizeOnClose.CheckedChanged += new System.EventHandler(this.chkMinimizeOnClose_CheckedChanged);
            // 
            // chkSystemHideInTray
            // 
            this.chkSystemHideInTray.AutoSize = true;
            this.chkSystemHideInTray.Location = new System.Drawing.Point(6, 48);
            this.chkSystemHideInTray.Name = "chkSystemHideInTray";
            this.chkSystemHideInTray.Size = new System.Drawing.Size(185, 17);
            this.chkSystemHideInTray.TabIndex = 1;
            this.chkSystemHideInTray.Text = "Minimize to tray instead of taskbar";
            this.chkSystemHideInTray.UseVisualStyleBackColor = true;
            this.chkSystemHideInTray.CheckedChanged += new System.EventHandler(this.chkSystemHideInTray_CheckedChanged);
            // 
            // chkSystemAutoRun
            // 
            this.chkSystemAutoRun.AutoSize = true;
            this.chkSystemAutoRun.Location = new System.Drawing.Point(6, 19);
            this.chkSystemAutoRun.Name = "chkSystemAutoRun";
            this.chkSystemAutoRun.Size = new System.Drawing.Size(118, 17);
            this.chkSystemAutoRun.TabIndex = 0;
            this.chkSystemAutoRun.Text = "Auto-Run at startup";
            this.chkSystemAutoRun.UseVisualStyleBackColor = true;
            this.chkSystemAutoRun.CheckedChanged += new System.EventHandler(this.chkSystemAutoRun_CheckedChanged);
            // 
            // tabPageAbout
            // 
            this.tabPageAbout.Controls.Add(this.groupBox4);
            this.tabPageAbout.ImageKey = "TabPageAbout_32x32.png";
            this.tabPageAbout.Location = new System.Drawing.Point(4, 39);
            this.tabPageAbout.Name = "tabPageAbout";
            this.tabPageAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAbout.Size = new System.Drawing.Size(470, 368);
            this.tabPageAbout.TabIndex = 2;
            this.tabPageAbout.Text = "About  ";
            this.tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.lnkEmail);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.lnkHomepage);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(458, 356);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "About KeepAliveHD";
            // 
            // label9
            // 
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(9, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(443, 127);
            this.label9.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(95, 214);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(357, 23);
            this.label6.TabIndex = 10;
            this.label6.Text = "1.6 beta";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(6, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 23);
            this.label8.TabIndex = 9;
            this.label8.Text = "Version:";
            // 
            // lnkEmail
            // 
            this.lnkEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lnkEmail.Location = new System.Drawing.Point(95, 289);
            this.lnkEmail.Name = "lnkEmail";
            this.lnkEmail.Size = new System.Drawing.Size(357, 23);
            this.lnkEmail.TabIndex = 8;
            this.lnkEmail.TabStop = true;
            this.lnkEmail.Text = "https://github.com/stsrki/KeepAliveHD/issues";
            this.lnkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmail_LinkClicked);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(6, 289);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 23);
            this.label7.TabIndex = 6;
            this.label7.Text = "Contact:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(95, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(357, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mladen Macanoviæ";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(6, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Author:";
            // 
            // lnkHomepage
            // 
            this.lnkHomepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lnkHomepage.Location = new System.Drawing.Point(95, 237);
            this.lnkHomepage.Name = "lnkHomepage";
            this.lnkHomepage.Size = new System.Drawing.Size(357, 23);
            this.lnkHomepage.TabIndex = 3;
            this.lnkHomepage.TabStop = true;
            this.lnkHomepage.Text = "https://github.com/stsrki/keepalivehd";
            this.lnkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHomepage_LinkClicked);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(6, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Homepage:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(95, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(357, 71);
            this.label2.TabIndex = 1;
            this.label2.Text = "KeepAliveHD is a simple program which writes a small text file every few minutes " +
    "to your external hard disk drive(s) to keep them from going into auto-sleep mode" +
    ".";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Description:";
            // 
            // ilTabs32
            // 
            this.ilTabs32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTabs32.ImageStream")));
            this.ilTabs32.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTabs32.Images.SetKeyName(0, "TabPageConfiguration_32x32.png");
            this.ilTabs32.Images.SetKeyName(1, "TabPageDriveInfo_32x32.png");
            this.ilTabs32.Images.SetKeyName(2, "TabPageAbout_32x32.png");
            this.ilTabs32.Images.SetKeyName(3, "TabPageDriveGo_32x32.png");
            // 
            // tmrIdle
            // 
            this.tmrIdle.Interval = 1000;
            this.tmrIdle.Tick += new System.EventHandler(this.tmrIdle_Tick);
            // 
            // ntfTray
            // 
            this.ntfTray.Icon = ((System.Drawing.Icon)(resources.GetObject("ntfTray.Icon")));
            this.ntfTray.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ntfTray_MouseUp);
            // 
            // ctxTray
            // 
            this.ctxTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxTrayShow,
            this.toolStripMenuItem1,
            this.ctxTrayClose});
            this.ctxTray.Name = "ctxTray";
            this.ctxTray.Size = new System.Drawing.Size(104, 54);
            // 
            // ctxTrayShow
            // 
            this.ctxTrayShow.Name = "ctxTrayShow";
            this.ctxTrayShow.Size = new System.Drawing.Size(103, 22);
            this.ctxTrayShow.Text = "Show";
            this.ctxTrayShow.Click += new System.EventHandler(this.ctxTrayShow_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // ctxTrayClose
            // 
            this.ctxTrayClose.Name = "ctxTrayClose";
            this.ctxTrayClose.Size = new System.Drawing.Size(103, 22);
            this.ctxTrayClose.Text = "Close";
            this.ctxTrayClose.Click += new System.EventHandler(this.ctxTrayClose_Click);
            // 
            // btnEngineStop
            // 
            this.btnEngineStop.Location = new System.Drawing.Point(377, 327);
            this.btnEngineStop.Name = "btnEngineStop";
            this.btnEngineStop.Size = new System.Drawing.Size(75, 23);
            this.btnEngineStop.TabIndex = 11;
            this.btnEngineStop.Text = "Stop";
            this.btnEngineStop.UseVisualStyleBackColor = true;
            this.btnEngineStop.Click += new System.EventHandler(this.btnEngineStop_Click);
            // 
            // btnEngineStart
            // 
            this.btnEngineStart.Location = new System.Drawing.Point(6, 327);
            this.btnEngineStart.Name = "btnEngineStart";
            this.btnEngineStart.Size = new System.Drawing.Size(75, 23);
            this.btnEngineStart.TabIndex = 12;
            this.btnEngineStart.Text = "Start";
            this.btnEngineStart.UseVisualStyleBackColor = true;
            this.btnEngineStart.Click += new System.EventHandler(this.btnEngineStart_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 435);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeepAliveHD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.tabMain.ResumeLayout(false);
            this.tabPageConfiguration.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDrives)).EndInit();
            this.tsDrives.ResumeLayout(false);
            this.tsDrives.PerformLayout();
            this.tabPageDriveInfo.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tsConnectedDrives.ResumeLayout(false);
            this.tsConnectedDrives.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgConnectedDrives)).EndInit();
            this.tabPageSettings.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimeAmount)).EndInit();
            this.tabPageAbout.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ctxTray.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageConfiguration;
        private System.Windows.Forms.TabPage tabPageDriveInfo;
        private System.Windows.Forms.ImageList ilTabs32;
        private System.Windows.Forms.TabPage tabPageAbout;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip tsDrives;
        private System.Windows.Forms.ToolStripButton btnDriveDelete;
        private System.Windows.Forms.DataGridView dgDrives;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgConnectedDrives;
        private System.Windows.Forms.ToolStripButton btnDriveNew;
        private System.Windows.Forms.CheckBox chkSystemHideInTray;
        private System.Windows.Forms.CheckBox chkSystemAutoRun;
        private System.Windows.Forms.CheckBox chkMinimizeOnClose;
        private System.Windows.Forms.CheckBox chkTurnOffWhenUserInactive;
        private System.Windows.Forms.ComboBox cboTimeUnit;
        private System.Windows.Forms.NumericUpDown numTimeAmount;
        private System.Windows.Forms.Timer tmrIdle;
        private System.Windows.Forms.NotifyIcon ntfTray;
        private System.Windows.Forms.ContextMenuStrip ctxTray;
        private System.Windows.Forms.ToolStripMenuItem ctxTrayShow;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ctxTrayClose;
        private System.Windows.Forms.Button btnConnectedDriveRefresh;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lnkHomepage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lnkEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip tsConnectedDrives;
        private System.Windows.Forms.ToolStripButton btnDriveNewMulti;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkDeleteTextFile;
        private System.Windows.Forms.CheckBox chkHideTrayIcon;
        private System.Windows.Forms.CheckBox chkLogMessages;
        private System.Windows.Forms.Button btnOpenLogDir;
        private System.Windows.Forms.CheckBox chkIgnoreVolumeNames;
        private System.Windows.Forms.ToolStripSplitButton btnDriveEdit;
        private System.Windows.Forms.ToolStripMenuItem btnDriveVolumeNamesEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoDrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoVolumeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoTotalSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoFreeSpace;
        private System.Windows.Forms.DataGridViewTextBoxColumn InfoType;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkDelayWriteOnResume;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesLetter;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesVolumeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesWriteTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesWriteTimeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriveStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriveStatusText;
        private System.Windows.Forms.Button btnEngineStart;
        private System.Windows.Forms.Button btnEngineStop;
    }
}