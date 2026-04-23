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
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Main ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            tabMain = new System.Windows.Forms.TabControl();
            tabPageConfiguration = new System.Windows.Forms.TabPage();
            groupBox1 = new System.Windows.Forms.GroupBox();
            btnEngineStart = new System.Windows.Forms.Button();
            btnEngineStop = new System.Windows.Forms.Button();
            dgDrives = new System.Windows.Forms.DataGridView();
            tsDrives = new System.Windows.Forms.ToolStrip();
            btnDriveNew = new System.Windows.Forms.ToolStripButton();
            btnDriveDelete = new System.Windows.Forms.ToolStripButton();
            btnDriveEdit = new System.Windows.Forms.ToolStripSplitButton();
            btnDriveVolumeNamesEdit = new System.Windows.Forms.ToolStripMenuItem();
            lblStatus = new System.Windows.Forms.Label();
            tabPageDriveInfo = new System.Windows.Forms.TabPage();
            groupBox3 = new System.Windows.Forms.GroupBox();
            tsConnectedDrives = new System.Windows.Forms.ToolStrip();
            btnDriveNewMulti = new System.Windows.Forms.ToolStripButton();
            btnConnectedDriveRefresh = new System.Windows.Forms.Button();
            dgConnectedDrives = new System.Windows.Forms.DataGridView();
            InfoDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            InfoVolumeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            InfoTotalSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            InfoFreeSpace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            InfoType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tabPageSettings = new System.Windows.Forms.TabPage();
            groupBox5 = new System.Windows.Forms.GroupBox();
            chkShowCountdownTimer = new System.Windows.Forms.CheckBox();
            chkDelayWriteOnResume = new System.Windows.Forms.CheckBox();
            chkIgnoreVolumeNames = new System.Windows.Forms.CheckBox();
            btnOpenLogDir = new System.Windows.Forms.Button();
            chkLogMessages = new System.Windows.Forms.CheckBox();
            chkDeleteTextFile = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            cboTimeUnitReading = new System.Windows.Forms.ComboBox();
            numTimeAmountReading = new System.Windows.Forms.NumericUpDown();
            chkTurnOffWhenUserInactiveReading = new System.Windows.Forms.CheckBox();
            label10 = new System.Windows.Forms.Label();
            chkStartMinimized = new System.Windows.Forms.CheckBox();
            chkHideTrayIcon = new System.Windows.Forms.CheckBox();
            cboTimeUnitWriting = new System.Windows.Forms.ComboBox();
            numTimeAmountWriting = new System.Windows.Forms.NumericUpDown();
            chkTurnOffWhenUserInactiveWriting = new System.Windows.Forms.CheckBox();
            chkMinimizeOnClose = new System.Windows.Forms.CheckBox();
            chkSystemHideInTray = new System.Windows.Forms.CheckBox();
            chkSystemAutoRun = new System.Windows.Forms.CheckBox();
            tabPageAbout = new System.Windows.Forms.TabPage();
            groupBox4 = new System.Windows.Forms.GroupBox();
            lnkDonations = new System.Windows.Forms.LinkLabel();
            label6 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            lblAppVersion = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            lnkIssues = new System.Windows.Forms.LinkLabel();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            lnkHomepage = new System.Windows.Forms.LinkLabel();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ilTabs32 = new System.Windows.Forms.ImageList( components );
            tmrIdle = new System.Windows.Forms.Timer( components );
            ntfTray = new System.Windows.Forms.NotifyIcon( components );
            ctxTray = new System.Windows.Forms.ContextMenuStrip( components );
            ctxTrayShow = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            ctxTrayClose = new System.Windows.Forms.ToolStripMenuItem();
            DrivesID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DrivesLetter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DrivesVolumeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DrivesWriteTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DrivesWriteTimeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DriveStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DrivesNextRunText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            DriveStatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tabMain.SuspendLayout();
            tabPageConfiguration.SuspendLayout();
            groupBox1.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)dgDrives ).BeginInit();
            tsDrives.SuspendLayout();
            tabPageDriveInfo.SuspendLayout();
            groupBox3.SuspendLayout();
            tsConnectedDrives.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)dgConnectedDrives ).BeginInit();
            tabPageSettings.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            ( (System.ComponentModel.ISupportInitialize)numTimeAmountReading ).BeginInit();
            ( (System.ComponentModel.ISupportInitialize)numTimeAmountWriting ).BeginInit();
            tabPageAbout.SuspendLayout();
            groupBox4.SuspendLayout();
            ctxTray.SuspendLayout();
            SuspendLayout();
            // 
            // tabMain
            // 
            tabMain.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            tabMain.Controls.Add( tabPageConfiguration );
            tabMain.Controls.Add( tabPageDriveInfo );
            tabMain.Controls.Add( tabPageSettings );
            tabMain.Controls.Add( tabPageAbout );
            tabMain.ImageList = ilTabs32;
            tabMain.Location = new System.Drawing.Point( 14, 14 );
            tabMain.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new System.Drawing.Size( 558, 474 );
            tabMain.TabIndex = 0;
            tabMain.SelectedIndexChanged +=  tabMain_SelectedIndexChanged ;
            // 
            // tabPageConfiguration
            // 
            tabPageConfiguration.Controls.Add( groupBox1 );
            tabPageConfiguration.ImageKey = "TabPageDriveGo_32x32.png";
            tabPageConfiguration.Location = new System.Drawing.Point( 4, 39 );
            tabPageConfiguration.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            tabPageConfiguration.Name = "tabPageConfiguration";
            tabPageConfiguration.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            tabPageConfiguration.Size = new System.Drawing.Size( 550, 431 );
            tabPageConfiguration.TabIndex = 0;
            tabPageConfiguration.Text = "Configuration  ";
            tabPageConfiguration.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            groupBox1.Controls.Add( btnEngineStart );
            groupBox1.Controls.Add( btnEngineStop );
            groupBox1.Controls.Add( dgDrives );
            groupBox1.Controls.Add( tsDrives );
            groupBox1.Controls.Add( lblStatus );
            groupBox1.Location = new System.Drawing.Point( 7, 7 );
            groupBox1.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            groupBox1.Size = new System.Drawing.Size( 534, 411 );
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Drive options";
            // 
            // btnEngineStart
            // 
            btnEngineStart.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left ;
            btnEngineStart.Location = new System.Drawing.Point( 7, 377 );
            btnEngineStart.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            btnEngineStart.Name = "btnEngineStart";
            btnEngineStart.Size = new System.Drawing.Size( 88, 27 );
            btnEngineStart.TabIndex = 12;
            btnEngineStart.Text = "Start";
            btnEngineStart.UseVisualStyleBackColor = true;
            btnEngineStart.Click +=  btnEngineStart_Click ;
            // 
            // btnEngineStop
            // 
            btnEngineStop.Anchor =  System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Right ;
            btnEngineStop.Location = new System.Drawing.Point( 440, 377 );
            btnEngineStop.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            btnEngineStop.Name = "btnEngineStop";
            btnEngineStop.Size = new System.Drawing.Size( 88, 27 );
            btnEngineStop.TabIndex = 11;
            btnEngineStop.Text = "Stop";
            btnEngineStop.UseVisualStyleBackColor = true;
            btnEngineStop.Click +=  btnEngineStop_Click ;
            // 
            // dgDrives
            // 
            dgDrives.AllowUserToAddRows = false;
            dgDrives.AllowUserToDeleteRows = false;
            dgDrives.AllowUserToOrderColumns = true;
            dgDrives.AllowUserToResizeRows = false;
            dgDrives.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            dgDrives.BackgroundColor = System.Drawing.SystemColors.Window;
            dgDrives.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgDrives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgDrives.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] { DrivesID, DrivesLetter, DrivesVolumeName, DrivesWriteTime, DrivesWriteTimeText, DriveStatus, DrivesNextRunText, DriveStatusText } );
            dgDrives.Location = new System.Drawing.Point( 7, 67 );
            dgDrives.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            dgDrives.Name = "dgDrives";
            dgDrives.ReadOnly = true;
            dgDrives.RowHeadersVisible = false;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb( 255, 255, 192 );
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dgDrives.RowsDefaultCellStyle = dataGridViewCellStyle7;
            dgDrives.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dgDrives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgDrives.Size = new System.Drawing.Size( 520, 303 );
            dgDrives.TabIndex = 1;
            dgDrives.CellMouseDoubleClick +=  dgDrives_CellMouseDoubleClick ;
            dgDrives.RowsAdded +=  dgDrives_RowsAdded ;
            dgDrives.SelectionChanged +=  dgDrives_SelectionChanged ;
            dgDrives.KeyDown +=  dgDrives_KeyDown ;
            // 
            // tsDrives
            // 
            tsDrives.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            tsDrives.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { btnDriveNew, btnDriveDelete, btnDriveEdit } );
            tsDrives.Location = new System.Drawing.Point( 4, 19 );
            tsDrives.Name = "tsDrives";
            tsDrives.Size = new System.Drawing.Size( 526, 39 );
            tsDrives.TabIndex = 0;
            tsDrives.Text = "toolStrip1";
            // 
            // btnDriveNew
            // 
            btnDriveNew.Image = Properties.Resources.ActionDriveAdd_32x32;
            btnDriveNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDriveNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDriveNew.Name = "btnDriveNew";
            btnDriveNew.Size = new System.Drawing.Size( 94, 36 );
            btnDriveNew.Text = "Add drive";
            btnDriveNew.Click +=  btnDriveNew_Click ;
            // 
            // btnDriveDelete
            // 
            btnDriveDelete.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            btnDriveDelete.Image = Properties.Resources.ActionDriveRemove_32x32;
            btnDriveDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDriveDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDriveDelete.Name = "btnDriveDelete";
            btnDriveDelete.Size = new System.Drawing.Size( 115, 36 );
            btnDriveDelete.Text = "Remove drive";
            btnDriveDelete.Click +=  btnDriveDelete_Click ;
            // 
            // btnDriveEdit
            // 
            btnDriveEdit.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] { btnDriveVolumeNamesEdit } );
            btnDriveEdit.Image = Properties.Resources.ActionDriveEdit_32x32;
            btnDriveEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDriveEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDriveEdit.Name = "btnDriveEdit";
            btnDriveEdit.Size = new System.Drawing.Size( 104, 36 );
            btnDriveEdit.Text = "Edit drive";
            btnDriveEdit.ButtonClick +=  btnDriveEdit_ButtonClick ;
            // 
            // btnDriveVolumeNamesEdit
            // 
            btnDriveVolumeNamesEdit.Name = "btnDriveVolumeNamesEdit";
            btnDriveVolumeNamesEdit.Size = new System.Drawing.Size( 189, 22 );
            btnDriveVolumeNamesEdit.Text = "Define volume names";
            btnDriveVolumeNamesEdit.Click +=  btnDriveVolumeNamesEdit_Click ;
            // 
            // lblStatus
            // 
            lblStatus.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            lblStatus.Location = new System.Drawing.Point( 7, 377 );
            lblStatus.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size( 426, 27 );
            lblStatus.TabIndex = 13;
            lblStatus.Text = "Program is running...";
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPageDriveInfo
            // 
            tabPageDriveInfo.Controls.Add( groupBox3 );
            tabPageDriveInfo.ImageKey = "TabPageDriveInfo_32x32.png";
            tabPageDriveInfo.Location = new System.Drawing.Point( 4, 39 );
            tabPageDriveInfo.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            tabPageDriveInfo.Name = "tabPageDriveInfo";
            tabPageDriveInfo.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            tabPageDriveInfo.Size = new System.Drawing.Size( 550, 431 );
            tabPageDriveInfo.TabIndex = 1;
            tabPageDriveInfo.Text = "Drive info  ";
            tabPageDriveInfo.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            groupBox3.Controls.Add( tsConnectedDrives );
            groupBox3.Controls.Add( btnConnectedDriveRefresh );
            groupBox3.Controls.Add( dgConnectedDrives );
            groupBox3.Location = new System.Drawing.Point( 7, 7 );
            groupBox3.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            groupBox3.Size = new System.Drawing.Size( 534, 411 );
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Connected drives";
            // 
            // tsConnectedDrives
            // 
            tsConnectedDrives.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            tsConnectedDrives.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { btnDriveNewMulti } );
            tsConnectedDrives.Location = new System.Drawing.Point( 4, 19 );
            tsConnectedDrives.Name = "tsConnectedDrives";
            tsConnectedDrives.Size = new System.Drawing.Size( 526, 39 );
            tsConnectedDrives.TabIndex = 4;
            tsConnectedDrives.Text = "toolStrip1";
            // 
            // btnDriveNewMulti
            // 
            btnDriveNewMulti.Image = Properties.Resources.ActionDriveAdd_32x32;
            btnDriveNewMulti.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            btnDriveNewMulti.ImageTransparentColor = System.Drawing.Color.Magenta;
            btnDriveNewMulti.Name = "btnDriveNewMulti";
            btnDriveNewMulti.Size = new System.Drawing.Size( 160, 36 );
            btnDriveNewMulti.Text = "Add all selected drives";
            btnDriveNewMulti.ToolTipText = "Add all selected drives to the writing mode";
            btnDriveNewMulti.Click +=  btnDriveNewMulti_Click ;
            // 
            // btnConnectedDriveRefresh
            // 
            btnConnectedDriveRefresh.Anchor =   System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            btnConnectedDriveRefresh.Location = new System.Drawing.Point( 7, 377 );
            btnConnectedDriveRefresh.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            btnConnectedDriveRefresh.Name = "btnConnectedDriveRefresh";
            btnConnectedDriveRefresh.Size = new System.Drawing.Size( 520, 27 );
            btnConnectedDriveRefresh.TabIndex = 3;
            btnConnectedDriveRefresh.Text = "Refresh";
            btnConnectedDriveRefresh.UseVisualStyleBackColor = true;
            btnConnectedDriveRefresh.Click +=  btnConnectedDriveRefresh_Click ;
            // 
            // dgConnectedDrives
            // 
            dgConnectedDrives.AllowUserToAddRows = false;
            dgConnectedDrives.AllowUserToDeleteRows = false;
            dgConnectedDrives.AllowUserToOrderColumns = true;
            dgConnectedDrives.AllowUserToResizeRows = false;
            dgConnectedDrives.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            dgConnectedDrives.BackgroundColor = System.Drawing.SystemColors.Window;
            dgConnectedDrives.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dgConnectedDrives.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgConnectedDrives.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] { InfoDrive, InfoVolumeName, InfoTotalSize, InfoFreeSpace, InfoType } );
            dgConnectedDrives.Location = new System.Drawing.Point( 7, 67 );
            dgConnectedDrives.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            dgConnectedDrives.Name = "dgConnectedDrives";
            dgConnectedDrives.ReadOnly = true;
            dgConnectedDrives.RowHeadersVisible = false;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb( 255, 255, 192 );
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            dgConnectedDrives.RowsDefaultCellStyle = dataGridViewCellStyle12;
            dgConnectedDrives.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dgConnectedDrives.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgConnectedDrives.Size = new System.Drawing.Size( 520, 303 );
            dgConnectedDrives.TabIndex = 2;
            dgConnectedDrives.SelectionChanged +=  dgConnectedDrives_SelectionChanged ;
            // 
            // InfoDrive
            // 
            InfoDrive.DataPropertyName = "Drive";
            InfoDrive.HeaderText = "Drive";
            InfoDrive.Name = "InfoDrive";
            InfoDrive.ReadOnly = true;
            // 
            // InfoVolumeName
            // 
            InfoVolumeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            InfoVolumeName.DataPropertyName = "VolumeName";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            InfoVolumeName.DefaultCellStyle = dataGridViewCellStyle8;
            InfoVolumeName.HeaderText = "Volume Name";
            InfoVolumeName.Name = "InfoVolumeName";
            InfoVolumeName.ReadOnly = true;
            // 
            // InfoTotalSize
            // 
            InfoTotalSize.DataPropertyName = "TotalSize";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            InfoTotalSize.DefaultCellStyle = dataGridViewCellStyle9;
            InfoTotalSize.HeaderText = "Total Size";
            InfoTotalSize.Name = "InfoTotalSize";
            InfoTotalSize.ReadOnly = true;
            InfoTotalSize.Width = 70;
            // 
            // InfoFreeSpace
            // 
            InfoFreeSpace.DataPropertyName = "FreeSpace";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            InfoFreeSpace.DefaultCellStyle = dataGridViewCellStyle10;
            InfoFreeSpace.HeaderText = "Free Space";
            InfoFreeSpace.Name = "InfoFreeSpace";
            InfoFreeSpace.ReadOnly = true;
            InfoFreeSpace.Width = 70;
            // 
            // InfoType
            // 
            InfoType.DataPropertyName = "DriveType";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            InfoType.DefaultCellStyle = dataGridViewCellStyle11;
            InfoType.HeaderText = "Type";
            InfoType.Name = "InfoType";
            InfoType.ReadOnly = true;
            InfoType.Width = 80;
            // 
            // tabPageSettings
            // 
            tabPageSettings.Controls.Add( groupBox5 );
            tabPageSettings.Controls.Add( groupBox2 );
            tabPageSettings.ImageKey = "TabPageConfiguration_32x32.png";
            tabPageSettings.Location = new System.Drawing.Point( 4, 39 );
            tabPageSettings.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            tabPageSettings.Size = new System.Drawing.Size( 550, 431 );
            tabPageSettings.TabIndex = 3;
            tabPageSettings.Text = "Settings  ";
            tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Anchor =   System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            groupBox5.Controls.Add( chkShowCountdownTimer );
            groupBox5.Controls.Add( chkDelayWriteOnResume );
            groupBox5.Controls.Add( chkIgnoreVolumeNames );
            groupBox5.Controls.Add( btnOpenLogDir );
            groupBox5.Controls.Add( chkLogMessages );
            groupBox5.Controls.Add( chkDeleteTextFile );
            groupBox5.Location = new System.Drawing.Point( 7, 227 );
            groupBox5.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            groupBox5.Size = new System.Drawing.Size( 534, 191 );
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "Behaviour";
            // 
            // chkShowCountdownTimer
            // 
            chkShowCountdownTimer.AutoSize = true;
            chkShowCountdownTimer.Location = new System.Drawing.Point( 7, 151 );
            chkShowCountdownTimer.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            chkShowCountdownTimer.Name = "chkShowCountdownTimer";
            chkShowCountdownTimer.Size = new System.Drawing.Size( 150, 19 );
            chkShowCountdownTimer.TabIndex = 6;
            chkShowCountdownTimer.Text = "Show countdown timer";
            chkShowCountdownTimer.UseVisualStyleBackColor = true;
            // 
            // chkDelayWriteOnResume
            // 
            chkDelayWriteOnResume.AutoSize = true;
            chkDelayWriteOnResume.Location = new System.Drawing.Point( 7, 119 );
            chkDelayWriteOnResume.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            chkDelayWriteOnResume.Name = "chkDelayWriteOnResume";
            chkDelayWriteOnResume.Size = new System.Drawing.Size( 269, 19 );
            chkDelayWriteOnResume.TabIndex = 5;
            chkDelayWriteOnResume.Text = "Delay writing when resumed from sleep mode";
            chkDelayWriteOnResume.UseVisualStyleBackColor = true;
            chkDelayWriteOnResume.CheckedChanged +=  chkDelayWriteOnResume_CheckedChanged ;
            // 
            // chkIgnoreVolumeNames
            // 
            chkIgnoreVolumeNames.AutoSize = true;
            chkIgnoreVolumeNames.Location = new System.Drawing.Point( 7, 54 );
            chkIgnoreVolumeNames.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            chkIgnoreVolumeNames.Name = "chkIgnoreVolumeNames";
            chkIgnoreVolumeNames.Size = new System.Drawing.Size( 141, 19 );
            chkIgnoreVolumeNames.TabIndex = 4;
            chkIgnoreVolumeNames.Text = "Ignore volume names";
            chkIgnoreVolumeNames.UseVisualStyleBackColor = true;
            chkIgnoreVolumeNames.CheckedChanged +=  chkIgnoreVolumeNames_CheckedChanged ;
            // 
            // btnOpenLogDir
            // 
            btnOpenLogDir.Location = new System.Drawing.Point( 183, 83 );
            btnOpenLogDir.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            btnOpenLogDir.Name = "btnOpenLogDir";
            btnOpenLogDir.Size = new System.Drawing.Size( 124, 24 );
            btnOpenLogDir.TabIndex = 3;
            btnOpenLogDir.Text = "Open logs directory";
            btnOpenLogDir.UseVisualStyleBackColor = true;
            btnOpenLogDir.Click +=  btnOpenLogDir_Click ;
            // 
            // chkLogMessages
            // 
            chkLogMessages.AutoSize = true;
            chkLogMessages.Location = new System.Drawing.Point( 7, 87 );
            chkLogMessages.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            chkLogMessages.Name = "chkLogMessages";
            chkLogMessages.Size = new System.Drawing.Size( 143, 19 );
            chkLogMessages.TabIndex = 2;
            chkLogMessages.Text = "Log all error messages";
            chkLogMessages.UseVisualStyleBackColor = true;
            chkLogMessages.CheckedChanged +=  chkLogMessages_CheckedChanged ;
            // 
            // chkDeleteTextFile
            // 
            chkDeleteTextFile.AutoSize = true;
            chkDeleteTextFile.Location = new System.Drawing.Point( 7, 22 );
            chkDeleteTextFile.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 8 );
            chkDeleteTextFile.Name = "chkDeleteTextFile";
            chkDeleteTextFile.Size = new System.Drawing.Size( 228, 19 );
            chkDeleteTextFile.TabIndex = 1;
            chkDeleteTextFile.Text = "Delete text file after it has been written";
            chkDeleteTextFile.UseVisualStyleBackColor = true;
            chkDeleteTextFile.CheckedChanged +=  chkDeleteTextFile_CheckedChanged ;
            // 
            // groupBox2
            // 
            groupBox2.Anchor =   System.Windows.Forms.AnchorStyles.Bottom  |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            groupBox2.Controls.Add( cboTimeUnitReading );
            groupBox2.Controls.Add( numTimeAmountReading );
            groupBox2.Controls.Add( chkTurnOffWhenUserInactiveReading );
            groupBox2.Controls.Add( label10 );
            groupBox2.Controls.Add( chkStartMinimized );
            groupBox2.Controls.Add( chkHideTrayIcon );
            groupBox2.Controls.Add( cboTimeUnitWriting );
            groupBox2.Controls.Add( numTimeAmountWriting );
            groupBox2.Controls.Add( chkTurnOffWhenUserInactiveWriting );
            groupBox2.Controls.Add( chkMinimizeOnClose );
            groupBox2.Controls.Add( chkSystemHideInTray );
            groupBox2.Controls.Add( chkSystemAutoRun );
            groupBox2.Location = new System.Drawing.Point( 7, 7 );
            groupBox2.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            groupBox2.Size = new System.Drawing.Size( 534, 214 );
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "System";
            // 
            // cboTimeUnitReading
            // 
            cboTimeUnitReading.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboTimeUnitReading.FormattingEnabled = true;
            cboTimeUnitReading.Location = new System.Drawing.Point( 302, 180 );
            cboTimeUnitReading.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            cboTimeUnitReading.Name = "cboTimeUnitReading";
            cboTimeUnitReading.Size = new System.Drawing.Size( 73, 23 );
            cboTimeUnitReading.TabIndex = 15;
            // 
            // numTimeAmountReading
            // 
            numTimeAmountReading.Location = new System.Drawing.Point( 238, 180 );
            numTimeAmountReading.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            numTimeAmountReading.Minimum = new decimal( new int[] { 1, 0, 0, 0 } );
            numTimeAmountReading.Name = "numTimeAmountReading";
            numTimeAmountReading.Size = new System.Drawing.Size( 56, 23 );
            numTimeAmountReading.TabIndex = 14;
            numTimeAmountReading.Value = new decimal( new int[] { 1, 0, 0, 0 } );
            // 
            // chkTurnOffWhenUserInactiveReading
            // 
            chkTurnOffWhenUserInactiveReading.AutoSize = true;
            chkTurnOffWhenUserInactiveReading.Location = new System.Drawing.Point( 7, 181 );
            chkTurnOffWhenUserInactiveReading.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 8 );
            chkTurnOffWhenUserInactiveReading.Name = "chkTurnOffWhenUserInactiveReading";
            chkTurnOffWhenUserInactiveReading.Size = new System.Drawing.Size( 226, 19 );
            chkTurnOffWhenUserInactiveReading.TabIndex = 13;
            chkTurnOffWhenUserInactiveReading.Text = "Disable reading if user is not active for";
            chkTurnOffWhenUserInactiveReading.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            label10.Location = new System.Drawing.Point( 7, 139 );
            label10.Margin = new System.Windows.Forms.Padding( 3, 0, 3, 8 );
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size( 520, 1 );
            label10.TabIndex = 12;
            // 
            // chkStartMinimized
            // 
            chkStartMinimized.AutoSize = true;
            chkStartMinimized.Location = new System.Drawing.Point( 7, 112 );
            chkStartMinimized.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 8 );
            chkStartMinimized.Name = "chkStartMinimized";
            chkStartMinimized.Size = new System.Drawing.Size( 109, 19 );
            chkStartMinimized.TabIndex = 11;
            chkStartMinimized.Text = "Start minimized";
            chkStartMinimized.UseVisualStyleBackColor = true;
            chkStartMinimized.CheckedChanged +=  chkStartMinimized_CheckedChanged ;
            // 
            // chkHideTrayIcon
            // 
            chkHideTrayIcon.AutoSize = true;
            chkHideTrayIcon.Location = new System.Drawing.Point( 236, 82 );
            chkHideTrayIcon.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            chkHideTrayIcon.Name = "chkHideTrayIcon";
            chkHideTrayIcon.Size = new System.Drawing.Size( 248, 19 );
            chkHideTrayIcon.TabIndex = 10;
            chkHideTrayIcon.Text = "Hide tray icon when minimized (not used)";
            chkHideTrayIcon.UseVisualStyleBackColor = true;
            chkHideTrayIcon.Visible = false;
            chkHideTrayIcon.CheckedChanged +=  chkHideTrayIcon_CheckedChanged ;
            // 
            // cboTimeUnitWriting
            // 
            cboTimeUnitWriting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboTimeUnitWriting.FormattingEnabled = true;
            cboTimeUnitWriting.Location = new System.Drawing.Point( 302, 150 );
            cboTimeUnitWriting.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            cboTimeUnitWriting.Name = "cboTimeUnitWriting";
            cboTimeUnitWriting.Size = new System.Drawing.Size( 73, 23 );
            cboTimeUnitWriting.TabIndex = 9;
            cboTimeUnitWriting.SelectedIndexChanged +=  cboTimeUnitWriting_SelectedIndexChanged ;
            // 
            // numTimeAmountWriting
            // 
            numTimeAmountWriting.Location = new System.Drawing.Point( 238, 150 );
            numTimeAmountWriting.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            numTimeAmountWriting.Minimum = new decimal( new int[] { 1, 0, 0, 0 } );
            numTimeAmountWriting.Name = "numTimeAmountWriting";
            numTimeAmountWriting.Size = new System.Drawing.Size( 56, 23 );
            numTimeAmountWriting.TabIndex = 8;
            numTimeAmountWriting.Value = new decimal( new int[] { 1, 0, 0, 0 } );
            numTimeAmountWriting.ValueChanged +=  numTimeAmountWriting_ValueChanged ;
            // 
            // chkTurnOffWhenUserInactiveWriting
            // 
            chkTurnOffWhenUserInactiveWriting.AutoSize = true;
            chkTurnOffWhenUserInactiveWriting.Location = new System.Drawing.Point( 7, 151 );
            chkTurnOffWhenUserInactiveWriting.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 8 );
            chkTurnOffWhenUserInactiveWriting.Name = "chkTurnOffWhenUserInactiveWriting";
            chkTurnOffWhenUserInactiveWriting.Size = new System.Drawing.Size( 223, 19 );
            chkTurnOffWhenUserInactiveWriting.TabIndex = 3;
            chkTurnOffWhenUserInactiveWriting.Text = "Disable writing if user is not active for";
            chkTurnOffWhenUserInactiveWriting.UseVisualStyleBackColor = true;
            chkTurnOffWhenUserInactiveWriting.CheckedChanged +=  chkTurnOffWhenUserInactiveWriting_CheckedChanged ;
            // 
            // chkMinimizeOnClose
            // 
            chkMinimizeOnClose.AutoSize = true;
            chkMinimizeOnClose.Location = new System.Drawing.Point( 27, 82 );
            chkMinimizeOnClose.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 8 );
            chkMinimizeOnClose.Name = "chkMinimizeOnClose";
            chkMinimizeOnClose.Size = new System.Drawing.Size( 161, 19 );
            chkMinimizeOnClose.TabIndex = 2;
            chkMinimizeOnClose.Text = "Minimize on close button";
            chkMinimizeOnClose.UseVisualStyleBackColor = true;
            chkMinimizeOnClose.CheckedChanged +=  chkMinimizeOnClose_CheckedChanged ;
            // 
            // chkSystemHideInTray
            // 
            chkSystemHideInTray.AutoSize = true;
            chkSystemHideInTray.Location = new System.Drawing.Point( 7, 52 );
            chkSystemHideInTray.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 8 );
            chkSystemHideInTray.Name = "chkSystemHideInTray";
            chkSystemHideInTray.Size = new System.Drawing.Size( 208, 19 );
            chkSystemHideInTray.TabIndex = 1;
            chkSystemHideInTray.Text = "Minimize to tray instead of taskbar";
            chkSystemHideInTray.UseVisualStyleBackColor = true;
            chkSystemHideInTray.CheckedChanged +=  chkSystemHideInTray_CheckedChanged ;
            // 
            // chkSystemAutoRun
            // 
            chkSystemAutoRun.AutoSize = true;
            chkSystemAutoRun.Location = new System.Drawing.Point( 7, 22 );
            chkSystemAutoRun.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 8 );
            chkSystemAutoRun.Name = "chkSystemAutoRun";
            chkSystemAutoRun.Size = new System.Drawing.Size( 131, 19 );
            chkSystemAutoRun.TabIndex = 0;
            chkSystemAutoRun.Text = "Auto-Run at startup";
            chkSystemAutoRun.UseVisualStyleBackColor = true;
            chkSystemAutoRun.CheckedChanged +=  chkSystemAutoRun_CheckedChanged ;
            // 
            // tabPageAbout
            // 
            tabPageAbout.Controls.Add( groupBox4 );
            tabPageAbout.ImageKey = "TabPageAbout_32x32.png";
            tabPageAbout.Location = new System.Drawing.Point( 4, 39 );
            tabPageAbout.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            tabPageAbout.Name = "tabPageAbout";
            tabPageAbout.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            tabPageAbout.Size = new System.Drawing.Size( 550, 431 );
            tabPageAbout.TabIndex = 2;
            tabPageAbout.Text = "About  ";
            tabPageAbout.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Anchor =    System.Windows.Forms.AnchorStyles.Top  |  System.Windows.Forms.AnchorStyles.Bottom   |  System.Windows.Forms.AnchorStyles.Left   |  System.Windows.Forms.AnchorStyles.Right ;
            groupBox4.Controls.Add( lnkDonations );
            groupBox4.Controls.Add( label6 );
            groupBox4.Controls.Add( label9 );
            groupBox4.Controls.Add( lblAppVersion );
            groupBox4.Controls.Add( label8 );
            groupBox4.Controls.Add( lnkIssues );
            groupBox4.Controls.Add( label7 );
            groupBox4.Controls.Add( label4 );
            groupBox4.Controls.Add( label5 );
            groupBox4.Controls.Add( lnkHomepage );
            groupBox4.Controls.Add( label3 );
            groupBox4.Controls.Add( label2 );
            groupBox4.Controls.Add( label1 );
            groupBox4.Location = new System.Drawing.Point( 7, 7 );
            groupBox4.Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            groupBox4.Size = new System.Drawing.Size( 534, 411 );
            groupBox4.TabIndex = 0;
            groupBox4.TabStop = false;
            groupBox4.Text = "About KeepAliveHD";
            // 
            // lnkDonations
            // 
            lnkDonations.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            lnkDonations.Image = (System.Drawing.Image)resources.GetObject( "lnkDonations.Image" );
            lnkDonations.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lnkDonations.Location = new System.Drawing.Point( 114, 360 );
            lnkDonations.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            lnkDonations.Name = "lnkDonations";
            lnkDonations.Padding = new System.Windows.Forms.Padding( 23, 0, 0, 0 );
            lnkDonations.Size = new System.Drawing.Size( 413, 27 );
            lnkDonations.TabIndex = 13;
            lnkDonations.TabStop = true;
            lnkDonations.Text = "Patreon";
            lnkDonations.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lnkDonations.LinkClicked +=  lnkDonations_LinkClicked ;
            // 
            // label6
            // 
            label6.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            label6.Location = new System.Drawing.Point( 7, 360 );
            label6.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size( 97, 27 );
            label6.TabIndex = 12;
            label6.Text = "Donations:";
            // 
            // label9
            // 
            label9.Image = (System.Drawing.Image)resources.GetObject( "label9.Image" );
            label9.Location = new System.Drawing.Point( 10, 18 );
            label9.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size( 517, 147 );
            label9.TabIndex = 11;
            // 
            // lblAppVersion
            // 
            lblAppVersion.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            lblAppVersion.Location = new System.Drawing.Point( 111, 247 );
            lblAppVersion.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            lblAppVersion.Name = "lblAppVersion";
            lblAppVersion.Size = new System.Drawing.Size( 416, 27 );
            lblAppVersion.TabIndex = 10;
            lblAppVersion.Text = "1.6 beta";
            // 
            // label8
            // 
            label8.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            label8.Location = new System.Drawing.Point( 7, 247 );
            label8.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size( 97, 27 );
            label8.TabIndex = 9;
            label8.Text = "Version:";
            // 
            // lnkIssues
            // 
            lnkIssues.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            lnkIssues.Location = new System.Drawing.Point( 111, 333 );
            lnkIssues.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            lnkIssues.Name = "lnkIssues";
            lnkIssues.Size = new System.Drawing.Size( 416, 27 );
            lnkIssues.TabIndex = 8;
            lnkIssues.TabStop = true;
            lnkIssues.Text = "Issues && Feature request";
            lnkIssues.LinkClicked +=  lnkIssues_LinkClicked ;
            // 
            // label7
            // 
            label7.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            label7.Location = new System.Drawing.Point( 7, 333 );
            label7.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size( 97, 27 );
            label7.TabIndex = 6;
            label7.Text = "Contact:";
            // 
            // label4
            // 
            label4.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            label4.Location = new System.Drawing.Point( 111, 303 );
            label4.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size( 416, 27 );
            label4.TabIndex = 5;
            label4.Text = "Mladen Macanoviæ";
            // 
            // label5
            // 
            label5.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            label5.Location = new System.Drawing.Point( 7, 303 );
            label5.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size( 97, 27 );
            label5.TabIndex = 4;
            label5.Text = "Author:";
            // 
            // lnkHomepage
            // 
            lnkHomepage.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            lnkHomepage.Location = new System.Drawing.Point( 111, 273 );
            lnkHomepage.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            lnkHomepage.Name = "lnkHomepage";
            lnkHomepage.Size = new System.Drawing.Size( 416, 27 );
            lnkHomepage.TabIndex = 3;
            lnkHomepage.TabStop = true;
            lnkHomepage.Text = "KeepAliveHD";
            lnkHomepage.LinkClicked +=  lnkHomepage_LinkClicked ;
            // 
            // label3
            // 
            label3.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            label3.Location = new System.Drawing.Point( 7, 273 );
            label3.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size( 97, 27 );
            label3.TabIndex = 2;
            label3.Text = "Homepage:";
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            label2.Location = new System.Drawing.Point( 111, 165 );
            label2.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size( 416, 82 );
            label2.TabIndex = 1;
            label2.Text = "KeepAliveHD is a simple program which writes a small text file every few minutes to your external hard disk drive(s) to keep them from going into auto-sleep mode.";
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 238 );
            label1.Location = new System.Drawing.Point( 7, 165 );
            label1.Margin = new System.Windows.Forms.Padding( 4, 0, 4, 0 );
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size( 97, 27 );
            label1.TabIndex = 0;
            label1.Text = "Description:";
            // 
            // ilTabs32
            // 
            ilTabs32.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            ilTabs32.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject( "ilTabs32.ImageStream" );
            ilTabs32.TransparentColor = System.Drawing.Color.Transparent;
            ilTabs32.Images.SetKeyName( 0, "TabPageConfiguration_32x32.png" );
            ilTabs32.Images.SetKeyName( 1, "TabPageDriveInfo_32x32.png" );
            ilTabs32.Images.SetKeyName( 2, "TabPageAbout_32x32.png" );
            ilTabs32.Images.SetKeyName( 3, "TabPageDriveGo_32x32.png" );
            // 
            // tmrIdle
            // 
            tmrIdle.Interval = 1000;
            tmrIdle.Tick +=  tmrIdle_Tick ;
            // 
            // ntfTray
            // 
            ntfTray.Icon = (System.Drawing.Icon)resources.GetObject( "ntfTray.Icon" );
            ntfTray.MouseUp +=  ntfTray_MouseUp ;
            // 
            // ctxTray
            // 
            ctxTray.Items.AddRange( new System.Windows.Forms.ToolStripItem[] { ctxTrayShow, toolStripMenuItem1, ctxTrayClose } );
            ctxTray.Name = "ctxTray";
            ctxTray.Size = new System.Drawing.Size( 104, 54 );
            // 
            // ctxTrayShow
            // 
            ctxTrayShow.Name = "ctxTrayShow";
            ctxTrayShow.Size = new System.Drawing.Size( 103, 22 );
            ctxTrayShow.Text = "Show";
            ctxTrayShow.Click +=  ctxTrayShow_Click ;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size( 100, 6 );
            // 
            // ctxTrayClose
            // 
            ctxTrayClose.Name = "ctxTrayClose";
            ctxTrayClose.Size = new System.Drawing.Size( 103, 22 );
            ctxTrayClose.Text = "Close";
            ctxTrayClose.Click +=  ctxTrayClose_Click ;
            // 
            // DrivesID
            // 
            DrivesID.DataPropertyName = "ID";
            DrivesID.HeaderText = "DrivesID";
            DrivesID.Name = "DrivesID";
            DrivesID.ReadOnly = true;
            DrivesID.Visible = false;
            // 
            // DrivesLetter
            // 
            DrivesLetter.DataPropertyName = "Drive";
            DrivesLetter.HeaderText = "Drive";
            DrivesLetter.Name = "DrivesLetter";
            DrivesLetter.ReadOnly = true;
            // 
            // DrivesVolumeName
            // 
            DrivesVolumeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            DrivesVolumeName.DataPropertyName = "VolumeName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            DrivesVolumeName.DefaultCellStyle = dataGridViewCellStyle1;
            DrivesVolumeName.HeaderText = "Volume Name(s)";
            DrivesVolumeName.Name = "DrivesVolumeName";
            DrivesVolumeName.ReadOnly = true;
            // 
            // DrivesWriteTime
            // 
            DrivesWriteTime.DataPropertyName = "TimeInterval";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            DrivesWriteTime.DefaultCellStyle = dataGridViewCellStyle2;
            DrivesWriteTime.HeaderText = "Write Every";
            DrivesWriteTime.Name = "DrivesWriteTime";
            DrivesWriteTime.ReadOnly = true;
            DrivesWriteTime.Visible = false;
            DrivesWriteTime.Width = 80;
            // 
            // DrivesWriteTimeText
            // 
            DrivesWriteTimeText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            DrivesWriteTimeText.DataPropertyName = "TimeIntervalText";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            DrivesWriteTimeText.DefaultCellStyle = dataGridViewCellStyle3;
            DrivesWriteTimeText.HeaderText = "Interval";
            DrivesWriteTimeText.Name = "DrivesWriteTimeText";
            DrivesWriteTimeText.ReadOnly = true;
            DrivesWriteTimeText.Width = 71;
            // 
            // DriveStatus
            // 
            DriveStatus.DataPropertyName = "Status";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            DriveStatus.DefaultCellStyle = dataGridViewCellStyle4;
            DriveStatus.HeaderText = "Status";
            DriveStatus.Name = "DriveStatus";
            DriveStatus.ReadOnly = true;
            DriveStatus.Visible = false;
            DriveStatus.Width = 90;
            // 
            // DrivesNextRunText
            // 
            DrivesNextRunText.DataPropertyName = "NextRunText";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            DrivesNextRunText.DefaultCellStyle = dataGridViewCellStyle5;
            DrivesNextRunText.HeaderText = "Next Run";
            DrivesNextRunText.Name = "DrivesNextRunText";
            DrivesNextRunText.ReadOnly = true;
            DrivesNextRunText.Width = 80;
            // 
            // DriveStatusText
            // 
            DriveStatusText.DataPropertyName = "StatusText";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            DriveStatusText.DefaultCellStyle = dataGridViewCellStyle6;
            DriveStatusText.HeaderText = "Status";
            DriveStatusText.Name = "DriveStatusText";
            DriveStatusText.ReadOnly = true;
            DriveStatusText.Width = 90;
            // 
            // Main
            // 
            AutoScaleDimensions = new System.Drawing.SizeF( 7F, 15F );
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size( 586, 502 );
            Controls.Add( tabMain );
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject( "$this.Icon" );
            Margin = new System.Windows.Forms.Padding( 4, 3, 4, 3 );
            MaximizeBox = false;
            Name = "Main";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "KeepAliveHD";
            FormClosing +=  Main_FormClosing ;
            FormClosed +=  Main_FormClosed ;
            Resize +=  Main_Resize ;
            tabMain.ResumeLayout( false );
            tabPageConfiguration.ResumeLayout( false );
            groupBox1.ResumeLayout( false );
            groupBox1.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)dgDrives ).EndInit();
            tsDrives.ResumeLayout( false );
            tsDrives.PerformLayout();
            tabPageDriveInfo.ResumeLayout( false );
            groupBox3.ResumeLayout( false );
            groupBox3.PerformLayout();
            tsConnectedDrives.ResumeLayout( false );
            tsConnectedDrives.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)dgConnectedDrives ).EndInit();
            tabPageSettings.ResumeLayout( false );
            groupBox5.ResumeLayout( false );
            groupBox5.PerformLayout();
            groupBox2.ResumeLayout( false );
            groupBox2.PerformLayout();
            ( (System.ComponentModel.ISupportInitialize)numTimeAmountReading ).EndInit();
            ( (System.ComponentModel.ISupportInitialize)numTimeAmountWriting ).EndInit();
            tabPageAbout.ResumeLayout( false );
            groupBox4.ResumeLayout( false );
            ctxTray.ResumeLayout( false );
            ResumeLayout( false );

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
        private System.Windows.Forms.CheckBox chkTurnOffWhenUserInactiveWriting;
        private System.Windows.Forms.ComboBox cboTimeUnitWriting;
        private System.Windows.Forms.NumericUpDown numTimeAmountWriting;
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
        private System.Windows.Forms.LinkLabel lnkIssues;
        private System.Windows.Forms.Label lblAppVersion;
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
        private System.Windows.Forms.Button btnEngineStart;
        private System.Windows.Forms.Button btnEngineStop;
        private System.Windows.Forms.LinkLabel lnkDonations;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.CheckBox chkShowCountdownTimer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboTimeUnitReading;
        private System.Windows.Forms.NumericUpDown numTimeAmountReading;
        private System.Windows.Forms.CheckBox chkTurnOffWhenUserInactiveReading;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesLetter;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesVolumeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesWriteTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesWriteTimeText;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriveStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DrivesNextRunText;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriveStatusText;
    }
}