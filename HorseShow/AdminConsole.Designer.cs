namespace HorseShow
{
    partial class frmAdminConsole
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
            this.lblSQLQuery = new System.Windows.Forms.Label();
            this.txtSQLQuery = new System.Windows.Forms.TextBox();
            this.grdSQLResults = new System.Windows.Forms.DataGridView();
            this.lblResultOutput = new System.Windows.Forms.Label();
            this.btnRunQuery = new System.Windows.Forms.Button();
            this.grpOutput = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdSQLResults)).BeginInit();
            this.grpOutput.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSQLQuery
            // 
            this.lblSQLQuery.AutoSize = true;
            this.lblSQLQuery.Location = new System.Drawing.Point(19, 27);
            this.lblSQLQuery.Name = "lblSQLQuery";
            this.lblSQLQuery.Size = new System.Drawing.Size(59, 13);
            this.lblSQLQuery.TabIndex = 0;
            this.lblSQLQuery.Text = "SQL Query";
            // 
            // txtSQLQuery
            // 
            this.txtSQLQuery.Location = new System.Drawing.Point(22, 43);
            this.txtSQLQuery.Name = "txtSQLQuery";
            this.txtSQLQuery.Size = new System.Drawing.Size(1144, 20);
            this.txtSQLQuery.TabIndex = 1;
            this.txtSQLQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSQLQuery_KeyDown);
            // 
            // grdSQLResults
            // 
            this.grdSQLResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdSQLResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSQLResults.Location = new System.Drawing.Point(3, 16);
            this.grdSQLResults.Name = "grdSQLResults";
            this.grdSQLResults.Size = new System.Drawing.Size(1235, 467);
            this.grdSQLResults.TabIndex = 2;
            // 
            // lblResultOutput
            // 
            this.lblResultOutput.AutoSize = true;
            this.lblResultOutput.Location = new System.Drawing.Point(16, 451);
            this.lblResultOutput.Name = "lblResultOutput";
            this.lblResultOutput.Size = new System.Drawing.Size(0, 13);
            this.lblResultOutput.TabIndex = 4;
            // 
            // btnRunQuery
            // 
            this.btnRunQuery.Location = new System.Drawing.Point(1182, 40);
            this.btnRunQuery.Name = "btnRunQuery";
            this.btnRunQuery.Size = new System.Drawing.Size(75, 23);
            this.btnRunQuery.TabIndex = 5;
            this.btnRunQuery.Text = "Run Query";
            this.btnRunQuery.UseVisualStyleBackColor = true;
            this.btnRunQuery.Click += new System.EventHandler(this.btnRunQuery_Click);
            // 
            // grpOutput
            // 
            this.grpOutput.Controls.Add(this.grdSQLResults);
            this.grpOutput.Location = new System.Drawing.Point(19, 70);
            this.grpOutput.Name = "grpOutput";
            this.grpOutput.Size = new System.Drawing.Size(1244, 486);
            this.grpOutput.TabIndex = 6;
            this.grpOutput.TabStop = false;
            this.grpOutput.Text = "Output";
            // 
            // frmAdminConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 574);
            this.Controls.Add(this.grpOutput);
            this.Controls.Add(this.btnRunQuery);
            this.Controls.Add(this.lblResultOutput);
            this.Controls.Add(this.txtSQLQuery);
            this.Controls.Add(this.lblSQLQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmAdminConsole";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminConsole";
            ((System.ComponentModel.ISupportInitialize)(this.grdSQLResults)).EndInit();
            this.grpOutput.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSQLQuery;
        private System.Windows.Forms.TextBox txtSQLQuery;
        private System.Windows.Forms.DataGridView grdSQLResults;
        private System.Windows.Forms.Label lblResultOutput;
        private System.Windows.Forms.Button btnRunQuery;
        private System.Windows.Forms.GroupBox grpOutput;
    }
}