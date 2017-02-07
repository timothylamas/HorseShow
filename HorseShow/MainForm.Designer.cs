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
            this.label2 = new System.Windows.Forms.Label();
            this.stripFooter = new System.Windows.Forms.StatusStrip();
            this.stripVersionNumber = new System.Windows.Forms.ToolStripStatusLabel();
            this.horseShowDBDataSet = new HorseShow.HorseShowDBDataSet();
            this.dataViewShowsTable = new HorseShow.dataViewShowsTable();
            this.viewShowsTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.viewShowsTableTableAdapter = new HorseShow.dataViewShowsTableTableAdapters.viewShowsTableTableAdapter();
            this.showProducerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showContactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showPhoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.showNotesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.tabForms.SuspendLayout();
            this.tabShows.SuspendLayout();
            this.grpShows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowsTable)).BeginInit();
            this.tabHorseRiderEntry.SuspendLayout();
            this.stripFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horseShowDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewShowsTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewShowsTableBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile});
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
            this.grdShowsTable.AutoGenerateColumns = false;
            this.grdShowsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShowsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.showProducerDataGridViewTextBoxColumn,
            this.showContactDataGridViewTextBoxColumn,
            this.showPhoneNumberDataGridViewTextBoxColumn,
            this.showDateDataGridViewTextBoxColumn,
            this.showLocationDataGridViewTextBoxColumn,
            this.showNotesDataGridViewTextBoxColumn});
            this.grdShowsTable.DataSource = this.viewShowsTableBindingSource;
            this.grdShowsTable.Location = new System.Drawing.Point(7, 20);
            this.grdShowsTable.Name = "grdShowsTable";
            this.grdShowsTable.ReadOnly = true;
            this.grdShowsTable.Size = new System.Drawing.Size(1219, 451);
            this.grdShowsTable.TabIndex = 0;
            // 
            // tabHorseRiderEntry
            // 
            this.tabHorseRiderEntry.Controls.Add(this.label2);
            this.tabHorseRiderEntry.Location = new System.Drawing.Point(4, 22);
            this.tabHorseRiderEntry.Name = "tabHorseRiderEntry";
            this.tabHorseRiderEntry.Padding = new System.Windows.Forms.Padding(3);
            this.tabHorseRiderEntry.Size = new System.Drawing.Size(1249, 540);
            this.tabHorseRiderEntry.TabIndex = 1;
            this.tabHorseRiderEntry.Text = "Rider/Horse Entry";
            this.tabHorseRiderEntry.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "You are on the Horse/Rider Entry page";
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
            // dataViewShowsTable
            // 
            this.dataViewShowsTable.DataSetName = "dataViewShowsTable";
            this.dataViewShowsTable.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewShowsTableBindingSource
            // 
            this.viewShowsTableBindingSource.DataMember = "viewShowsTable";
            this.viewShowsTableBindingSource.DataSource = this.dataViewShowsTable;
            // 
            // viewShowsTableTableAdapter
            // 
            this.viewShowsTableTableAdapter.ClearBeforeFill = true;
            // 
            // showProducerDataGridViewTextBoxColumn
            // 
            this.showProducerDataGridViewTextBoxColumn.DataPropertyName = "ShowProducer";
            this.showProducerDataGridViewTextBoxColumn.HeaderText = "ShowProducer";
            this.showProducerDataGridViewTextBoxColumn.Name = "showProducerDataGridViewTextBoxColumn";
            this.showProducerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // showContactDataGridViewTextBoxColumn
            // 
            this.showContactDataGridViewTextBoxColumn.DataPropertyName = "ShowContact";
            this.showContactDataGridViewTextBoxColumn.HeaderText = "ShowContact";
            this.showContactDataGridViewTextBoxColumn.Name = "showContactDataGridViewTextBoxColumn";
            this.showContactDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // showPhoneNumberDataGridViewTextBoxColumn
            // 
            this.showPhoneNumberDataGridViewTextBoxColumn.DataPropertyName = "ShowPhoneNumber";
            this.showPhoneNumberDataGridViewTextBoxColumn.HeaderText = "ShowPhoneNumber";
            this.showPhoneNumberDataGridViewTextBoxColumn.Name = "showPhoneNumberDataGridViewTextBoxColumn";
            this.showPhoneNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // showDateDataGridViewTextBoxColumn
            // 
            this.showDateDataGridViewTextBoxColumn.DataPropertyName = "ShowDate";
            this.showDateDataGridViewTextBoxColumn.HeaderText = "ShowDate";
            this.showDateDataGridViewTextBoxColumn.Name = "showDateDataGridViewTextBoxColumn";
            this.showDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // showLocationDataGridViewTextBoxColumn
            // 
            this.showLocationDataGridViewTextBoxColumn.DataPropertyName = "ShowLocation";
            this.showLocationDataGridViewTextBoxColumn.HeaderText = "ShowLocation";
            this.showLocationDataGridViewTextBoxColumn.Name = "showLocationDataGridViewTextBoxColumn";
            this.showLocationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // showNotesDataGridViewTextBoxColumn
            // 
            this.showNotesDataGridViewTextBoxColumn.DataPropertyName = "ShowNotes";
            this.showNotesDataGridViewTextBoxColumn.HeaderText = "ShowNotes";
            this.showNotesDataGridViewTextBoxColumn.Name = "showNotesDataGridViewTextBoxColumn";
            this.showNotesDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.stripFooter.ResumeLayout(false);
            this.stripFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.horseShowDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataViewShowsTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewShowsTableBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn showProducerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn showContactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn showPhoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn showDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn showLocationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn showNotesDataGridViewTextBoxColumn;
    }
}

