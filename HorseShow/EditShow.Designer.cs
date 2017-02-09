namespace HorseShow
{
    partial class frmEditShow
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
            this.lblHiddenValue = new System.Windows.Forms.Label();
            this.grpClasses = new System.Windows.Forms.GroupBox();
            this.txtAdditionalMoney = new System.Windows.Forms.TextBox();
            this.txtEntryFee = new System.Windows.Forms.TextBox();
            this.lblAdditionalMoney = new System.Windows.Forms.Label();
            this.lblEntryFee = new System.Windows.Forms.Label();
            this.txtNewClassInput = new System.Windows.Forms.TextBox();
            this.btnAddClass = new System.Windows.Forms.Button();
            this.listClasses = new System.Windows.Forms.ListBox();
            this.btnRemoveClass = new System.Windows.Forms.Button();
            this.grpEvents = new System.Windows.Forms.GroupBox();
            this.txtNewEventInput = new System.Windows.Forms.TextBox();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnRemoveEvent = new System.Windows.Forms.Button();
            this.listEvents = new System.Windows.Forms.ListBox();
            this.btnAddEditShowCancel = new System.Windows.Forms.Button();
            this.btnAddEditShowSaveChanges = new System.Windows.Forms.Button();
            this.dateShowDate = new System.Windows.Forms.DateTimePicker();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.txtShowProducer = new System.Windows.Forms.TextBox();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblShowDate = new System.Windows.Forms.Label();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.lblContactName = new System.Windows.Forms.Label();
            this.lblShowProducer = new System.Windows.Forms.Label();
            this.btnRenameClass = new System.Windows.Forms.Button();
            this.btnRenameEvent = new System.Windows.Forms.Button();
            this.btnSaveMoney = new System.Windows.Forms.Button();
            this.grpClasses.SuspendLayout();
            this.grpEvents.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHiddenValue
            // 
            this.lblHiddenValue.AutoSize = true;
            this.lblHiddenValue.Location = new System.Drawing.Point(356, 6);
            this.lblHiddenValue.Name = "lblHiddenValue";
            this.lblHiddenValue.Size = new System.Drawing.Size(68, 13);
            this.lblHiddenValue.TabIndex = 19;
            this.lblHiddenValue.Text = "hidden value";
            this.lblHiddenValue.Visible = false;
            // 
            // grpClasses
            // 
            this.grpClasses.Controls.Add(this.btnSaveMoney);
            this.grpClasses.Controls.Add(this.btnRenameClass);
            this.grpClasses.Controls.Add(this.txtAdditionalMoney);
            this.grpClasses.Controls.Add(this.txtEntryFee);
            this.grpClasses.Controls.Add(this.lblAdditionalMoney);
            this.grpClasses.Controls.Add(this.lblEntryFee);
            this.grpClasses.Controls.Add(this.txtNewClassInput);
            this.grpClasses.Controls.Add(this.btnAddClass);
            this.grpClasses.Controls.Add(this.listClasses);
            this.grpClasses.Controls.Add(this.btnRemoveClass);
            this.grpClasses.Location = new System.Drawing.Point(225, 186);
            this.grpClasses.Name = "grpClasses";
            this.grpClasses.Size = new System.Drawing.Size(277, 231);
            this.grpClasses.TabIndex = 25;
            this.grpClasses.TabStop = false;
            this.grpClasses.Text = "Classes";
            // 
            // txtAdditionalMoney
            // 
            this.txtAdditionalMoney.Location = new System.Drawing.Point(182, 84);
            this.txtAdditionalMoney.Name = "txtAdditionalMoney";
            this.txtAdditionalMoney.Size = new System.Drawing.Size(73, 20);
            this.txtAdditionalMoney.TabIndex = 4;
            // 
            // txtEntryFee
            // 
            this.txtEntryFee.Location = new System.Drawing.Point(182, 36);
            this.txtEntryFee.Name = "txtEntryFee";
            this.txtEntryFee.Size = new System.Drawing.Size(73, 20);
            this.txtEntryFee.TabIndex = 3;
            // 
            // lblAdditionalMoney
            // 
            this.lblAdditionalMoney.AutoSize = true;
            this.lblAdditionalMoney.Location = new System.Drawing.Point(179, 68);
            this.lblAdditionalMoney.Name = "lblAdditionalMoney";
            this.lblAdditionalMoney.Size = new System.Drawing.Size(91, 13);
            this.lblAdditionalMoney.TabIndex = 3;
            this.lblAdditionalMoney.Text = "Additional Money:";
            // 
            // lblEntryFee
            // 
            this.lblEntryFee.AutoSize = true;
            this.lblEntryFee.Location = new System.Drawing.Point(179, 20);
            this.lblEntryFee.Name = "lblEntryFee";
            this.lblEntryFee.Size = new System.Drawing.Size(55, 13);
            this.lblEntryFee.TabIndex = 0;
            this.lblEntryFee.Text = "Entry Fee:";
            // 
            // txtNewClassInput
            // 
            this.txtNewClassInput.Location = new System.Drawing.Point(6, 173);
            this.txtNewClassInput.Name = "txtNewClassInput";
            this.txtNewClassInput.Size = new System.Drawing.Size(100, 20);
            this.txtNewClassInput.TabIndex = 0;
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(112, 173);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Size = new System.Drawing.Size(24, 23);
            this.btnAddClass.TabIndex = 1;
            this.btnAddClass.TabStop = false;
            this.btnAddClass.Text = "+";
            this.btnAddClass.UseVisualStyleBackColor = true;
            this.btnAddClass.Click += new System.EventHandler(this.btnAddClass_Click);
            // 
            // listClasses
            // 
            this.listClasses.FormattingEnabled = true;
            this.listClasses.Location = new System.Drawing.Point(6, 20);
            this.listClasses.Name = "listClasses";
            this.listClasses.Size = new System.Drawing.Size(167, 147);
            this.listClasses.TabIndex = 0;
            this.listClasses.TabStop = false;
            this.listClasses.SelectedValueChanged += new System.EventHandler(this.listClasses_SelectedValueChanged);
            // 
            // btnRemoveClass
            // 
            this.btnRemoveClass.Location = new System.Drawing.Point(142, 173);
            this.btnRemoveClass.Name = "btnRemoveClass";
            this.btnRemoveClass.Size = new System.Drawing.Size(24, 23);
            this.btnRemoveClass.TabIndex = 2;
            this.btnRemoveClass.TabStop = false;
            this.btnRemoveClass.Text = "-";
            this.btnRemoveClass.UseVisualStyleBackColor = true;
            this.btnRemoveClass.Click += new System.EventHandler(this.btnRemoveClass_Click);
            // 
            // grpEvents
            // 
            this.grpEvents.Controls.Add(this.btnRenameEvent);
            this.grpEvents.Controls.Add(this.txtNewEventInput);
            this.grpEvents.Controls.Add(this.btnAddEvent);
            this.grpEvents.Controls.Add(this.btnRemoveEvent);
            this.grpEvents.Controls.Add(this.listEvents);
            this.grpEvents.Location = new System.Drawing.Point(11, 186);
            this.grpEvents.Name = "grpEvents";
            this.grpEvents.Size = new System.Drawing.Size(177, 231);
            this.grpEvents.TabIndex = 24;
            this.grpEvents.TabStop = false;
            this.grpEvents.Text = "Events";
            // 
            // txtNewEventInput
            // 
            this.txtNewEventInput.Location = new System.Drawing.Point(6, 173);
            this.txtNewEventInput.Name = "txtNewEventInput";
            this.txtNewEventInput.Size = new System.Drawing.Size(100, 20);
            this.txtNewEventInput.TabIndex = 0;
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(112, 173);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(24, 23);
            this.btnAddEvent.TabIndex = 1;
            this.btnAddEvent.TabStop = false;
            this.btnAddEvent.Text = "+";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnRemoveEvent
            // 
            this.btnRemoveEvent.Location = new System.Drawing.Point(142, 173);
            this.btnRemoveEvent.Name = "btnRemoveEvent";
            this.btnRemoveEvent.Size = new System.Drawing.Size(24, 23);
            this.btnRemoveEvent.TabIndex = 2;
            this.btnRemoveEvent.TabStop = false;
            this.btnRemoveEvent.Text = "-";
            this.btnRemoveEvent.UseVisualStyleBackColor = true;
            this.btnRemoveEvent.Click += new System.EventHandler(this.btnRemoveEvent_Click);
            // 
            // listEvents
            // 
            this.listEvents.FormattingEnabled = true;
            this.listEvents.Location = new System.Drawing.Point(4, 20);
            this.listEvents.Name = "listEvents";
            this.listEvents.Size = new System.Drawing.Size(167, 147);
            this.listEvents.TabIndex = 0;
            this.listEvents.TabStop = false;
            this.listEvents.SelectedValueChanged += new System.EventHandler(this.listEvents_SelectedValueChanged);
            // 
            // btnAddEditShowCancel
            // 
            this.btnAddEditShowCancel.Location = new System.Drawing.Point(311, 438);
            this.btnAddEditShowCancel.Name = "btnAddEditShowCancel";
            this.btnAddEditShowCancel.Size = new System.Drawing.Size(87, 23);
            this.btnAddEditShowCancel.TabIndex = 23;
            this.btnAddEditShowCancel.Text = "Cancel";
            this.btnAddEditShowCancel.UseVisualStyleBackColor = true;
            this.btnAddEditShowCancel.Click += new System.EventHandler(this.btnAddEditShowCancel_Click);
            // 
            // btnAddEditShowSaveChanges
            // 
            this.btnAddEditShowSaveChanges.Location = new System.Drawing.Point(17, 438);
            this.btnAddEditShowSaveChanges.Name = "btnAddEditShowSaveChanges";
            this.btnAddEditShowSaveChanges.Size = new System.Drawing.Size(87, 23);
            this.btnAddEditShowSaveChanges.TabIndex = 22;
            this.btnAddEditShowSaveChanges.Text = "Save Changes";
            this.btnAddEditShowSaveChanges.UseVisualStyleBackColor = true;
            this.btnAddEditShowSaveChanges.Click += new System.EventHandler(this.btnAddEditShowSaveChanges_Click);
            // 
            // dateShowDate
            // 
            this.dateShowDate.Location = new System.Drawing.Point(102, 96);
            this.dateShowDate.Name = "dateShowDate";
            this.dateShowDate.Size = new System.Drawing.Size(200, 20);
            this.dateShowDate.TabIndex = 18;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(101, 149);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(229, 20);
            this.txtNotes.TabIndex = 21;
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(102, 122);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(229, 20);
            this.txtLocation.TabIndex = 20;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(102, 69);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(229, 20);
            this.txtPhoneNumber.TabIndex = 17;
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(102, 44);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(229, 20);
            this.txtContactName.TabIndex = 16;
            // 
            // txtShowProducer
            // 
            this.txtShowProducer.Location = new System.Drawing.Point(102, 18);
            this.txtShowProducer.Name = "txtShowProducer";
            this.txtShowProducer.Size = new System.Drawing.Size(229, 20);
            this.txtShowProducer.TabIndex = 14;
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(57, 149);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 13);
            this.lblNotes.TabIndex = 13;
            this.lblNotes.Text = "Notes:";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(44, 122);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(51, 13);
            this.lblLocation.TabIndex = 12;
            this.lblLocation.Text = "Location:";
            // 
            // lblShowDate
            // 
            this.lblShowDate.AutoSize = true;
            this.lblShowDate.Location = new System.Drawing.Point(32, 96);
            this.lblShowDate.Name = "lblShowDate";
            this.lblShowDate.Size = new System.Drawing.Size(63, 13);
            this.lblShowDate.TabIndex = 11;
            this.lblShowDate.Text = "Show Date:";
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(14, 69);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(81, 13);
            this.lblPhoneNumber.TabIndex = 10;
            this.lblPhoneNumber.Text = "Phone Number:";
            // 
            // lblContactName
            // 
            this.lblContactName.AutoSize = true;
            this.lblContactName.Location = new System.Drawing.Point(17, 44);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(78, 13);
            this.lblContactName.TabIndex = 15;
            this.lblContactName.Text = "Contact Name:";
            // 
            // lblShowProducer
            // 
            this.lblShowProducer.AutoSize = true;
            this.lblShowProducer.Location = new System.Drawing.Point(12, 19);
            this.lblShowProducer.Name = "lblShowProducer";
            this.lblShowProducer.Size = new System.Drawing.Size(83, 13);
            this.lblShowProducer.TabIndex = 9;
            this.lblShowProducer.Text = "Show Producer:";
            // 
            // btnRenameClass
            // 
            this.btnRenameClass.Location = new System.Drawing.Point(7, 200);
            this.btnRenameClass.Name = "btnRenameClass";
            this.btnRenameClass.Size = new System.Drawing.Size(75, 23);
            this.btnRenameClass.TabIndex = 5;
            this.btnRenameClass.Text = "Rename";
            this.btnRenameClass.UseVisualStyleBackColor = true;
            this.btnRenameClass.Click += new System.EventHandler(this.btnRenameClass_Click);
            // 
            // btnRenameEvent
            // 
            this.btnRenameEvent.Location = new System.Drawing.Point(4, 199);
            this.btnRenameEvent.Name = "btnRenameEvent";
            this.btnRenameEvent.Size = new System.Drawing.Size(75, 23);
            this.btnRenameEvent.TabIndex = 5;
            this.btnRenameEvent.Text = "Rename";
            this.btnRenameEvent.UseVisualStyleBackColor = true;
            this.btnRenameEvent.Click += new System.EventHandler(this.btnRenameEvent_Click);
            // 
            // btnSaveMoney
            // 
            this.btnSaveMoney.Location = new System.Drawing.Point(215, 110);
            this.btnSaveMoney.Name = "btnSaveMoney";
            this.btnSaveMoney.Size = new System.Drawing.Size(40, 23);
            this.btnSaveMoney.TabIndex = 6;
            this.btnSaveMoney.Text = "Save";
            this.btnSaveMoney.UseVisualStyleBackColor = true;
            // 
            // frmEditShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 471);
            this.Controls.Add(this.lblHiddenValue);
            this.Controls.Add(this.grpClasses);
            this.Controls.Add(this.grpEvents);
            this.Controls.Add(this.btnAddEditShowCancel);
            this.Controls.Add(this.btnAddEditShowSaveChanges);
            this.Controls.Add(this.dateShowDate);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.txtPhoneNumber);
            this.Controls.Add(this.txtContactName);
            this.Controls.Add(this.txtShowProducer);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblShowDate);
            this.Controls.Add(this.lblPhoneNumber);
            this.Controls.Add(this.lblContactName);
            this.Controls.Add(this.lblShowProducer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEditShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Show";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditShow_FormClosing);
            this.grpClasses.ResumeLayout(false);
            this.grpClasses.PerformLayout();
            this.grpEvents.ResumeLayout(false);
            this.grpEvents.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHiddenValue;
        private System.Windows.Forms.GroupBox grpClasses;
        private System.Windows.Forms.TextBox txtAdditionalMoney;
        private System.Windows.Forms.TextBox txtEntryFee;
        private System.Windows.Forms.Label lblAdditionalMoney;
        private System.Windows.Forms.Label lblEntryFee;
        private System.Windows.Forms.TextBox txtNewClassInput;
        private System.Windows.Forms.Button btnAddClass;
        private System.Windows.Forms.ListBox listClasses;
        private System.Windows.Forms.Button btnRemoveClass;
        private System.Windows.Forms.GroupBox grpEvents;
        private System.Windows.Forms.TextBox txtNewEventInput;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnRemoveEvent;
        private System.Windows.Forms.ListBox listEvents;
        private System.Windows.Forms.Button btnAddEditShowCancel;
        private System.Windows.Forms.Button btnAddEditShowSaveChanges;
        private System.Windows.Forms.DateTimePicker dateShowDate;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.TextBox txtShowProducer;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblShowDate;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.Label lblContactName;
        private System.Windows.Forms.Label lblShowProducer;
        private System.Windows.Forms.Button btnSaveMoney;
        private System.Windows.Forms.Button btnRenameClass;
        private System.Windows.Forms.Button btnRenameEvent;
    }
}