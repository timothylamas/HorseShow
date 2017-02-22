namespace HorseShow
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.stripShows = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tabForms = new System.Windows.Forms.TabControl();
            this.tabShows = new System.Windows.Forms.TabPage();
            this.btnRefreshShows = new System.Windows.Forms.Button();
            this.btnNewShow = new System.Windows.Forms.Button();
            this.grpShows = new System.Windows.Forms.GroupBox();
            this.grdShowsTable = new System.Windows.Forms.DataGridView();
            this.tabHorseRiderEntry = new System.Windows.Forms.TabPage();
            this.cmbEntryTableClasses = new System.Windows.Forms.ComboBox();
            this.cmbEntryTableEvents = new System.Windows.Forms.ComboBox();
            this.lblEntryClass = new System.Windows.Forms.Label();
            this.lblEntryTableEvent = new System.Windows.Forms.Label();
            this.grdEntryTable = new System.Windows.Forms.DataGridView();
            this.cmbRiderHorseEntryShowSelection = new System.Windows.Forms.ComboBox();
            this.lblRiderHorseEntryShowSelection = new System.Windows.Forms.Label();
            this.grpNewRiderHorseEntry = new System.Windows.Forms.GroupBox();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.cmbEventEntry = new System.Windows.Forms.ComboBox();
            this.grdClassesEntry = new System.Windows.Forms.DataGridView();
            this.txtHorseNameEntry = new System.Windows.Forms.TextBox();
            this.txtRiderNameEntry = new System.Windows.Forms.TextBox();
            this.lblHorseNameEntry = new System.Windows.Forms.Label();
            this.lblClassEntry = new System.Windows.Forms.Label();
            this.lblEventsEntry = new System.Windows.Forms.Label();
            this.lblRiderNameEntry = new System.Windows.Forms.Label();
            this.stripFooter = new System.Windows.Forms.StatusStrip();
            this.stripVersionNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.horseShowDBDataSet = new HorseShow.HorseShowDBDataSet();
            this.viewShowsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataViewShowsTable = new HorseShow.dataViewShowsTable();
            this.viewShowsTableTableAdapter = new HorseShow.dataViewShowsTableTableAdapters.viewShowsTableTableAdapter();
            this.dataViewShowsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataViewShowsTable1 = new HorseShow.dataViewShowsTable();
            this.btnRandomizeEntries = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.tabForms.SuspendLayout();
            this.tabShows.SuspendLayout();
            this.grpShows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowsTable)).BeginInit();
            this.tabHorseRiderEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntryTable)).BeginInit();
            this.grpNewRiderHorseEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClassesEntry)).BeginInit();
            this.stripFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horseShowDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewShowsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewShowsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewShowsTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewShowsTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1268, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(37, 20);
            this.menuFile.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminConsoleToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // adminConsoleToolStripMenuItem
            // 
            this.adminConsoleToolStripMenuItem.Name = "adminConsoleToolStripMenuItem";
            this.adminConsoleToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.adminConsoleToolStripMenuItem.Text = "Admin Console";
            this.adminConsoleToolStripMenuItem.Click += new System.EventHandler(this.adminConsoleToolStripMenuItem_Click);
            // 
            // toolStripMain
            // 
            this.toolStripMain.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripShows,
            this.toolStripButton1});
            this.toolStripMain.Location = new System.Drawing.Point(0, 24);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.toolStripMain.Size = new System.Drawing.Size(1268, 38);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // stripShows
            // 
            this.stripShows.Image = ((System.Drawing.Image)(resources.GetObject("stripShows.Image")));
            this.stripShows.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripShows.Name = "stripShows";
            this.stripShows.Size = new System.Drawing.Size(45, 35);
            this.stripShows.Text = "Shows";
            this.stripShows.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.stripShows.Click += new System.EventHandler(this.stripShows_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(104, 35);
            this.toolStripButton1.Text = "Rider/Horse Entry";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tabForms
            // 
            this.tabForms.Controls.Add(this.tabShows);
            this.tabForms.Controls.Add(this.tabHorseRiderEntry);
            this.tabForms.Location = new System.Drawing.Point(0, 65);
            this.tabForms.Name = "tabForms";
            this.tabForms.SelectedIndex = 0;
            this.tabForms.Size = new System.Drawing.Size(1257, 566);
            this.tabForms.TabIndex = 2;
            // 
            // tabShows
            // 
            this.tabShows.Controls.Add(this.btnRefreshShows);
            this.tabShows.Controls.Add(this.btnNewShow);
            this.tabShows.Controls.Add(this.grpShows);
            this.tabShows.Location = new System.Drawing.Point(4, 22);
            this.tabShows.Name = "tabShows";
            this.tabShows.Padding = new System.Windows.Forms.Padding(3);
            this.tabShows.Size = new System.Drawing.Size(1249, 540);
            this.tabShows.TabIndex = 0;
            this.tabShows.Text = "Shows";
            this.tabShows.UseVisualStyleBackColor = true;
            // 
            // btnRefreshShows
            // 
            this.btnRefreshShows.Location = new System.Drawing.Point(1159, 489);
            this.btnRefreshShows.Name = "btnRefreshShows";
            this.btnRefreshShows.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshShows.TabIndex = 2;
            this.btnRefreshShows.Text = "Refresh List";
            this.btnRefreshShows.UseVisualStyleBackColor = true;
            this.btnRefreshShows.Click += new System.EventHandler(this.btnRefreshShows_Click);
            // 
            // btnNewShow
            // 
            this.btnNewShow.Location = new System.Drawing.Point(15, 490);
            this.btnNewShow.Name = "btnNewShow";
            this.btnNewShow.Size = new System.Drawing.Size(111, 23);
            this.btnNewShow.TabIndex = 1;
            this.btnNewShow.Text = "Create New Show...";
            this.btnNewShow.UseVisualStyleBackColor = true;
            this.btnNewShow.Click += new System.EventHandler(this.btnNewShow_Click);
            // 
            // grpShows
            // 
            this.grpShows.Controls.Add(this.grdShowsTable);
            this.grpShows.Location = new System.Drawing.Point(8, 6);
            this.grpShows.Name = "grpShows";
            this.grpShows.Size = new System.Drawing.Size(1235, 477);
            this.grpShows.TabIndex = 0;
            this.grpShows.TabStop = false;
            this.grpShows.Text = "Shows";
            // 
            // grdShowsTable
            // 
            this.grdShowsTable.AllowUserToAddRows = false;
            this.grdShowsTable.AllowUserToDeleteRows = false;
            this.grdShowsTable.AllowUserToOrderColumns = true;
            this.grdShowsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShowsTable.Location = new System.Drawing.Point(7, 20);
            this.grdShowsTable.Name = "grdShowsTable";
            this.grdShowsTable.ReadOnly = true;
            this.grdShowsTable.Size = new System.Drawing.Size(1219, 451);
            this.grdShowsTable.TabIndex = 0;
            this.grdShowsTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdShowsTable_CellClick);
            // 
            // tabHorseRiderEntry
            // 
            this.tabHorseRiderEntry.Controls.Add(this.btnRandomizeEntries);
            this.tabHorseRiderEntry.Controls.Add(this.cmbEntryTableClasses);
            this.tabHorseRiderEntry.Controls.Add(this.cmbEntryTableEvents);
            this.tabHorseRiderEntry.Controls.Add(this.lblEntryClass);
            this.tabHorseRiderEntry.Controls.Add(this.lblEntryTableEvent);
            this.tabHorseRiderEntry.Controls.Add(this.grdEntryTable);
            this.tabHorseRiderEntry.Controls.Add(this.cmbRiderHorseEntryShowSelection);
            this.tabHorseRiderEntry.Controls.Add(this.lblRiderHorseEntryShowSelection);
            this.tabHorseRiderEntry.Controls.Add(this.grpNewRiderHorseEntry);
            this.tabHorseRiderEntry.Location = new System.Drawing.Point(4, 22);
            this.tabHorseRiderEntry.Name = "tabHorseRiderEntry";
            this.tabHorseRiderEntry.Padding = new System.Windows.Forms.Padding(3);
            this.tabHorseRiderEntry.Size = new System.Drawing.Size(1249, 540);
            this.tabHorseRiderEntry.TabIndex = 1;
            this.tabHorseRiderEntry.Text = "Rider/Horse Entry";
            this.tabHorseRiderEntry.UseVisualStyleBackColor = true;
            // 
            // cmbEntryTableClasses
            // 
            this.cmbEntryTableClasses.FormattingEnabled = true;
            this.cmbEntryTableClasses.Location = new System.Drawing.Point(769, 16);
            this.cmbEntryTableClasses.Name = "cmbEntryTableClasses";
            this.cmbEntryTableClasses.Size = new System.Drawing.Size(121, 21);
            this.cmbEntryTableClasses.TabIndex = 8;
            this.cmbEntryTableClasses.SelectedValueChanged += new System.EventHandler(this.cmbEntryTableClasses_SelectedValueChanged);
            // 
            // cmbEntryTableEvents
            // 
            this.cmbEntryTableEvents.FormattingEnabled = true;
            this.cmbEntryTableEvents.Location = new System.Drawing.Point(586, 16);
            this.cmbEntryTableEvents.Name = "cmbEntryTableEvents";
            this.cmbEntryTableEvents.Size = new System.Drawing.Size(121, 21);
            this.cmbEntryTableEvents.TabIndex = 7;
            this.cmbEntryTableEvents.SelectedValueChanged += new System.EventHandler(this.cmbEntryTableEvents_SelectedValueChanged);
            // 
            // lblEntryClass
            // 
            this.lblEntryClass.AutoSize = true;
            this.lblEntryClass.Location = new System.Drawing.Point(727, 16);
            this.lblEntryClass.Name = "lblEntryClass";
            this.lblEntryClass.Size = new System.Drawing.Size(35, 13);
            this.lblEntryClass.TabIndex = 6;
            this.lblEntryClass.Text = "Class:";
            // 
            // lblEntryTableEvent
            // 
            this.lblEntryTableEvent.AutoSize = true;
            this.lblEntryTableEvent.Location = new System.Drawing.Point(541, 16);
            this.lblEntryTableEvent.Name = "lblEntryTableEvent";
            this.lblEntryTableEvent.Size = new System.Drawing.Size(38, 13);
            this.lblEntryTableEvent.TabIndex = 5;
            this.lblEntryTableEvent.Text = "Event:";
            // 
            // grdEntryTable
            // 
            this.grdEntryTable.AllowUserToAddRows = false;
            this.grdEntryTable.AllowUserToDeleteRows = false;
            this.grdEntryTable.AllowUserToOrderColumns = true;
            this.grdEntryTable.AllowUserToResizeRows = false;
            this.grdEntryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEntryTable.Location = new System.Drawing.Point(341, 45);
            this.grdEntryTable.Name = "grdEntryTable";
            this.grdEntryTable.ShowEditingIcon = false;
            this.grdEntryTable.Size = new System.Drawing.Size(902, 449);
            this.grdEntryTable.TabIndex = 4;
            this.grdEntryTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEntryTable_CellClick);
            // 
            // cmbRiderHorseEntryShowSelection
            // 
            this.cmbRiderHorseEntryShowSelection.FormattingEnabled = true;
            this.cmbRiderHorseEntryShowSelection.Location = new System.Drawing.Point(96, 16);
            this.cmbRiderHorseEntryShowSelection.MaxDropDownItems = 20;
            this.cmbRiderHorseEntryShowSelection.Name = "cmbRiderHorseEntryShowSelection";
            this.cmbRiderHorseEntryShowSelection.Size = new System.Drawing.Size(224, 21);
            this.cmbRiderHorseEntryShowSelection.TabIndex = 3;
            this.cmbRiderHorseEntryShowSelection.SelectedIndexChanged += new System.EventHandler(this.cmbRiderHorseEntryShowSelection_SelectedIndexChanged);
            this.cmbRiderHorseEntryShowSelection.Click += new System.EventHandler(this.cmbRiderHorseEntryShowSelection_Click);
            // 
            // lblRiderHorseEntryShowSelection
            // 
            this.lblRiderHorseEntryShowSelection.AutoSize = true;
            this.lblRiderHorseEntryShowSelection.Location = new System.Drawing.Point(8, 16);
            this.lblRiderHorseEntryShowSelection.Name = "lblRiderHorseEntryShowSelection";
            this.lblRiderHorseEntryShowSelection.Size = new System.Drawing.Size(84, 13);
            this.lblRiderHorseEntryShowSelection.TabIndex = 2;
            this.lblRiderHorseEntryShowSelection.Text = "Show Selection:";
            // 
            // grpNewRiderHorseEntry
            // 
            this.grpNewRiderHorseEntry.Controls.Add(this.btnAddEntry);
            this.grpNewRiderHorseEntry.Controls.Add(this.cmbEventEntry);
            this.grpNewRiderHorseEntry.Controls.Add(this.grdClassesEntry);
            this.grpNewRiderHorseEntry.Controls.Add(this.txtHorseNameEntry);
            this.grpNewRiderHorseEntry.Controls.Add(this.txtRiderNameEntry);
            this.grpNewRiderHorseEntry.Controls.Add(this.lblHorseNameEntry);
            this.grpNewRiderHorseEntry.Controls.Add(this.lblClassEntry);
            this.grpNewRiderHorseEntry.Controls.Add(this.lblEventsEntry);
            this.grpNewRiderHorseEntry.Controls.Add(this.lblRiderNameEntry);
            this.grpNewRiderHorseEntry.Location = new System.Drawing.Point(9, 45);
            this.grpNewRiderHorseEntry.Name = "grpNewRiderHorseEntry";
            this.grpNewRiderHorseEntry.Size = new System.Drawing.Size(311, 489);
            this.grpNewRiderHorseEntry.TabIndex = 1;
            this.grpNewRiderHorseEntry.TabStop = false;
            this.grpNewRiderHorseEntry.Text = "New Entry";
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(82, 309);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(75, 23);
            this.btnAddEntry.TabIndex = 4;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // cmbEventEntry
            // 
            this.cmbEventEntry.FormattingEnabled = true;
            this.cmbEventEntry.Location = new System.Drawing.Point(82, 26);
            this.cmbEventEntry.Name = "cmbEventEntry";
            this.cmbEventEntry.Size = new System.Drawing.Size(125, 21);
            this.cmbEventEntry.TabIndex = 3;
            this.cmbEventEntry.SelectedValueChanged += new System.EventHandler(this.cmbEventEntry_SelectedValueChanged);
            // 
            // grdClassesEntry
            // 
            this.grdClassesEntry.AllowUserToAddRows = false;
            this.grdClassesEntry.AllowUserToDeleteRows = false;
            this.grdClassesEntry.AllowUserToResizeColumns = false;
            this.grdClassesEntry.AllowUserToResizeRows = false;
            this.grdClassesEntry.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grdClassesEntry.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdClassesEntry.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdClassesEntry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdClassesEntry.ColumnHeadersVisible = false;
            this.grdClassesEntry.GridColor = System.Drawing.SystemColors.Window;
            this.grdClassesEntry.Location = new System.Drawing.Point(82, 137);
            this.grdClassesEntry.MultiSelect = false;
            this.grdClassesEntry.Name = "grdClassesEntry";
            this.grdClassesEntry.RowHeadersVisible = false;
            this.grdClassesEntry.ShowEditingIcon = false;
            this.grdClassesEntry.Size = new System.Drawing.Size(150, 150);
            this.grdClassesEntry.TabIndex = 2;
            // 
            // txtHorseNameEntry
            // 
            this.txtHorseNameEntry.Location = new System.Drawing.Point(82, 94);
            this.txtHorseNameEntry.Name = "txtHorseNameEntry";
            this.txtHorseNameEntry.Size = new System.Drawing.Size(175, 20);
            this.txtHorseNameEntry.TabIndex = 1;
            // 
            // txtRiderNameEntry
            // 
            this.txtRiderNameEntry.Location = new System.Drawing.Point(82, 65);
            this.txtRiderNameEntry.Name = "txtRiderNameEntry";
            this.txtRiderNameEntry.Size = new System.Drawing.Size(175, 20);
            this.txtRiderNameEntry.TabIndex = 1;
            // 
            // lblHorseNameEntry
            // 
            this.lblHorseNameEntry.AutoSize = true;
            this.lblHorseNameEntry.Location = new System.Drawing.Point(6, 97);
            this.lblHorseNameEntry.Name = "lblHorseNameEntry";
            this.lblHorseNameEntry.Size = new System.Drawing.Size(69, 13);
            this.lblHorseNameEntry.TabIndex = 0;
            this.lblHorseNameEntry.Text = "Horse Name:";
            // 
            // lblClassEntry
            // 
            this.lblClassEntry.AutoSize = true;
            this.lblClassEntry.Location = new System.Drawing.Point(21, 137);
            this.lblClassEntry.Name = "lblClassEntry";
            this.lblClassEntry.Size = new System.Drawing.Size(49, 13);
            this.lblClassEntry.TabIndex = 0;
            this.lblClassEntry.Text = "Classes: ";
            // 
            // lblEventsEntry
            // 
            this.lblEventsEntry.AutoSize = true;
            this.lblEventsEntry.Location = new System.Drawing.Point(32, 26);
            this.lblEventsEntry.Name = "lblEventsEntry";
            this.lblEventsEntry.Size = new System.Drawing.Size(38, 13);
            this.lblEventsEntry.TabIndex = 0;
            this.lblEventsEntry.Text = "Event:";
            // 
            // lblRiderNameEntry
            // 
            this.lblRiderNameEntry.AutoSize = true;
            this.lblRiderNameEntry.Location = new System.Drawing.Point(9, 68);
            this.lblRiderNameEntry.Name = "lblRiderNameEntry";
            this.lblRiderNameEntry.Size = new System.Drawing.Size(66, 13);
            this.lblRiderNameEntry.TabIndex = 0;
            this.lblRiderNameEntry.Text = "Rider Name:";
            // 
            // stripFooter
            // 
            this.stripFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stripVersionNumber});
            this.stripFooter.Location = new System.Drawing.Point(0, 636);
            this.stripFooter.Name = "stripFooter";
            this.stripFooter.Size = new System.Drawing.Size(1268, 22);
            this.stripFooter.SizingGrip = false;
            this.stripFooter.TabIndex = 3;
            this.stripFooter.Text = "statusStrip1";
            // 
            // stripVersionNumber
            // 
            this.stripVersionNumber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.stripVersionNumber.Name = "stripVersionNumber";
            this.stripVersionNumber.Size = new System.Drawing.Size(81, 17);
            this.stripVersionNumber.Text = "Version 0.0.0.0";
            // 
            // horseShowDBDataSet
            // 
            this.horseShowDBDataSet.DataSetName = "HorseShowDBDataSet";
            this.horseShowDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewShowsTableBindingSource
            // 
            this.viewShowsTableBindingSource.DataMember = "viewShowsTable";
            this.viewShowsTableBindingSource.DataSource = this.dataViewShowsTable;
            // 
            // dataViewShowsTable
            // 
            this.dataViewShowsTable.DataSetName = "dataViewShowsTable";
            this.dataViewShowsTable.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewShowsTableTableAdapter
            // 
            this.viewShowsTableTableAdapter.ClearBeforeFill = true;
            // 
            // dataViewShowsTableBindingSource
            // 
            this.dataViewShowsTableBindingSource.DataSource = this.dataViewShowsTable;
            this.dataViewShowsTableBindingSource.Position = 0;
            // 
            // dataViewShowsTable1
            // 
            this.dataViewShowsTable1.DataSetName = "dataViewShowsTable";
            this.dataViewShowsTable1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnRandomizeEntries
            // 
            this.btnRandomizeEntries.Location = new System.Drawing.Point(1138, 500);
            this.btnRandomizeEntries.Name = "btnRandomizeEntries";
            this.btnRandomizeEntries.Size = new System.Drawing.Size(105, 23);
            this.btnRandomizeEntries.TabIndex = 9;
            this.btnRandomizeEntries.Text = "Randomize Entries";
            this.btnRandomizeEntries.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 658);
            this.Controls.Add(this.stripFooter);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Horse Show";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.tabForms.ResumeLayout(false);
            this.tabShows.ResumeLayout(false);
            this.grpShows.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdShowsTable)).EndInit();
            this.tabHorseRiderEntry.ResumeLayout(false);
            this.tabHorseRiderEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEntryTable)).EndInit();
            this.grpNewRiderHorseEntry.ResumeLayout(false);
            this.grpNewRiderHorseEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdClassesEntry)).EndInit();
            this.stripFooter.ResumeLayout(false);
            this.stripFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horseShowDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewShowsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewShowsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewShowsTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewShowsTable1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton stripShows;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabControl tabForms;
        private System.Windows.Forms.TabPage tabShows;
        private System.Windows.Forms.TabPage tabHorseRiderEntry;
        private System.Windows.Forms.StatusStrip stripFooter;
        private System.Windows.Forms.ToolStripStatusLabel stripVersionNumber;
        private System.Windows.Forms.GroupBox grpShows;
        private System.Windows.Forms.Button btnNewShow;
        private System.Windows.Forms.DataGridView grdShowsTable;
        private System.Windows.Forms.Button btnRefreshShows;
        private HorseShowDBDataSet horseShowDBDataSet;
        private dataViewShowsTable dataViewShowsTable;
        private System.Windows.Forms.BindingSource viewShowsTableBindingSource;
        private dataViewShowsTableTableAdapters.viewShowsTableTableAdapter viewShowsTableTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminConsoleToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbRiderHorseEntryShowSelection;
        private System.Windows.Forms.Label lblRiderHorseEntryShowSelection;
        private System.Windows.Forms.GroupBox grpNewRiderHorseEntry;
        private System.Windows.Forms.BindingSource dataViewShowsTableBindingSource;
        private dataViewShowsTable dataViewShowsTable1;
        private System.Windows.Forms.TextBox txtHorseNameEntry;
        private System.Windows.Forms.TextBox txtRiderNameEntry;
        private System.Windows.Forms.Label lblEventsEntry;
        private System.Windows.Forms.Label lblRiderNameEntry;
        private System.Windows.Forms.Label lblHorseNameEntry;
        private System.Windows.Forms.Label lblClassEntry;
        private System.Windows.Forms.DataGridView grdClassesEntry;
        private System.Windows.Forms.ComboBox cmbEventEntry;
        private System.Windows.Forms.DataGridView grdEntryTable;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.ComboBox cmbEntryTableClasses;
        private System.Windows.Forms.ComboBox cmbEntryTableEvents;
        private System.Windows.Forms.Label lblEntryClass;
        private System.Windows.Forms.Label lblEntryTableEvent;
        private System.Windows.Forms.Button btnRandomizeEntries;
    }
}

