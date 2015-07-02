namespace UsersList
{
    partial class frmTFSView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_dp = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstProjects = new System.Windows.Forms.ListBox();
            this.lblConnectedServer = new System.Windows.Forms.Label();
            this.pnlPrjList = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblServerSelect = new System.Windows.Forms.Label();
            this.rtnGIRMSC9 = new System.Windows.Forms.RadioButton();
            this.rtnGIRMS27 = new System.Windows.Forms.RadioButton();
            this.lblServer = new System.Windows.Forms.Label();
            this.btnExpXL = new System.Windows.Forms.Button();
            this.btnExpPDF = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pbrProgress = new System.Windows.Forms.ProgressBar();
            this.dtView = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PandR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();
            this.pnlPrjList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_dp
            // 
            this.btn_dp.Location = new System.Drawing.Point(428, 9);
            this.btn_dp.Name = "btn_dp";
            this.btn_dp.Size = new System.Drawing.Size(121, 25);
            this.btn_dp.TabIndex = 5;
            this.btn_dp.Text = "&Connect to TFS...";
            this.btn_dp.UseVisualStyleBackColor = true;
            this.btn_dp.Click += new System.EventHandler(this.btn_dp_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TFS Projects";
            // 
            // lstProjects
            // 
            this.lstProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProjects.FormattingEnabled = true;
            this.lstProjects.Location = new System.Drawing.Point(0, 0);
            this.lstProjects.Name = "lstProjects";
            this.lstProjects.Size = new System.Drawing.Size(140, 440);
            this.lstProjects.TabIndex = 6;
            this.lstProjects.SelectedIndexChanged += new System.EventHandler(this.lstProjects_SelectedIndexChanged);
            // 
            // lblConnectedServer
            // 
            this.lblConnectedServer.AutoSize = true;
            this.lblConnectedServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectedServer.Location = new System.Drawing.Point(843, 16);
            this.lblConnectedServer.Name = "lblConnectedServer";
            this.lblConnectedServer.Size = new System.Drawing.Size(113, 13);
            this.lblConnectedServer.TabIndex = 8;
            this.lblConnectedServer.Text = "Connected Server:";
            this.lblConnectedServer.Visible = false;
            // 
            // pnlPrjList
            // 
            this.pnlPrjList.Controls.Add(this.lstProjects);
            this.pnlPrjList.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPrjList.Location = new System.Drawing.Point(0, 0);
            this.pnlPrjList.Name = "pnlPrjList";
            this.pnlPrjList.Size = new System.Drawing.Size(140, 440);
            this.pnlPrjList.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblServerSelect);
            this.panel1.Controls.Add(this.rtnGIRMSC9);
            this.panel1.Controls.Add(this.rtnGIRMS27);
            this.panel1.Controls.Add(this.lblServer);
            this.panel1.Controls.Add(this.btnExpXL);
            this.panel1.Controls.Add(this.btnExpPDF);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblConnectedServer);
            this.panel1.Controls.Add(this.btn_dp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1230, 44);
            this.panel1.TabIndex = 13;
            // 
            // lblServerSelect
            // 
            this.lblServerSelect.AutoSize = true;
            this.lblServerSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerSelect.Location = new System.Drawing.Point(147, 15);
            this.lblServerSelect.Name = "lblServerSelect";
            this.lblServerSelect.Size = new System.Drawing.Size(88, 13);
            this.lblServerSelect.TabIndex = 2;
            this.lblServerSelect.Text = "Select Server:";
            // 
            // rtnGIRMSC9
            // 
            this.rtnGIRMSC9.AutoSize = true;
            this.rtnGIRMSC9.BackColor = System.Drawing.Color.Tomato;
            this.rtnGIRMSC9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rtnGIRMSC9.Location = new System.Drawing.Point(344, 7);
            this.rtnGIRMSC9.Name = "rtnGIRMSC9";
            this.rtnGIRMSC9.Size = new System.Drawing.Size(75, 30);
            this.rtnGIRMSC9.TabIndex = 4;
            this.rtnGIRMSC9.Text = "GIRMSC9\r\n(TFS Test)";
            this.rtnGIRMSC9.UseVisualStyleBackColor = false;
            // 
            // rtnGIRMS27
            // 
            this.rtnGIRMS27.AutoSize = true;
            this.rtnGIRMS27.BackColor = System.Drawing.Color.LightGreen;
            this.rtnGIRMS27.Checked = true;
            this.rtnGIRMS27.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rtnGIRMS27.Location = new System.Drawing.Point(239, 7);
            this.rtnGIRMS27.Name = "rtnGIRMS27";
            this.rtnGIRMS27.Size = new System.Drawing.Size(105, 30);
            this.rtnGIRMS27.TabIndex = 3;
            this.rtnGIRMS27.TabStop = true;
            this.rtnGIRMS27.Text = "GIRMS27 \r\n(TFS Production)";
            this.rtnGIRMS27.UseVisualStyleBackColor = false;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.Location = new System.Drawing.Point(956, 16);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(0, 13);
            this.lblServer.TabIndex = 9;
            // 
            // btnExpXL
            // 
            this.btnExpXL.Location = new System.Drawing.Point(715, 9);
            this.btnExpXL.Name = "btnExpXL";
            this.btnExpXL.Size = new System.Drawing.Size(121, 25);
            this.btnExpXL.TabIndex = 7;
            this.btnExpXL.Text = "Export to Excel";
            this.btnExpXL.UseVisualStyleBackColor = true;
            this.btnExpXL.Click += new System.EventHandler(this.btnExpXL_Click);
            // 
            // btnExpPDF
            // 
            this.btnExpPDF.Location = new System.Drawing.Point(588, 10);
            this.btnExpPDF.Name = "btnExpPDF";
            this.btnExpPDF.Size = new System.Drawing.Size(121, 25);
            this.btnExpPDF.TabIndex = 6;
            this.btnExpPDF.Text = "Export to PDF";
            this.btnExpPDF.UseVisualStyleBackColor = true;
            this.btnExpPDF.Click += new System.EventHandler(this.btnExpPDF_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pbrProgress);
            this.panel2.Controls.Add(this.dtView);
            this.panel2.Controls.Add(this.pnlPrjList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1230, 440);
            this.panel2.TabIndex = 11;
            // 
            // pbrProgress
            // 
            this.pbrProgress.Location = new System.Drawing.Point(140, 417);
            this.pbrProgress.Name = "pbrProgress";
            this.pbrProgress.Size = new System.Drawing.Size(1090, 23);
            this.pbrProgress.TabIndex = 13;
            this.pbrProgress.Visible = false;
            // 
            // dtView
            // 
            this.dtView.AllowUserToAddRows = false;
            this.dtView.AllowUserToDeleteRows = false;
            this.dtView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dtView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.AdId,
            this.email,
            this.domain,
            this.PandR,
            this.Status});
            this.dtView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtView.Location = new System.Drawing.Point(140, 0);
            this.dtView.Name = "dtView";
            this.dtView.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtView.Size = new System.Drawing.Size(1090, 440);
            this.dtView.TabIndex = 12;
            // 
            // UserName
            // 
            this.UserName.DividerWidth = 2;
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 175;
            // 
            // AdId
            // 
            this.AdId.DividerWidth = 2;
            this.AdId.HeaderText = "AD Id";
            this.AdId.Name = "AdId";
            this.AdId.ReadOnly = true;
            this.AdId.Width = 174;
            // 
            // email
            // 
            this.email.DividerWidth = 2;
            this.email.HeaderText = "Email Address";
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 175;
            // 
            // domain
            // 
            this.domain.DividerWidth = 2;
            this.domain.HeaderText = "Domain";
            this.domain.Name = "domain";
            this.domain.ReadOnly = true;
            this.domain.Width = 174;
            // 
            // PandR
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.PandR.DefaultCellStyle = dataGridViewCellStyle3;
            this.PandR.DividerWidth = 2;
            this.PandR.HeaderText = "Projects and Rights";
            this.PandR.Name = "PandR";
            this.PandR.ReadOnly = true;
            this.PandR.Width = 175;
            // 
            // Status
            // 
            this.Status.DividerWidth = 2;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 174;
            // 
            // dlgSave
            // 
            this.dlgSave.InitialDirectory = "C:\\";
            // 
            // frmTFSView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 484);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmTFSView";
            this.Text = "Team Foundation Server - Projects & Users";
            this.pnlPrjList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_dp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstProjects;
        private System.Windows.Forms.Label lblConnectedServer;
        private System.Windows.Forms.Panel pnlPrjList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtView;
        private System.Windows.Forms.Button btnExpXL;
        private System.Windows.Forms.Button btnExpPDF;
        private System.Windows.Forms.SaveFileDialog dlgSave;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblServerSelect;
        private System.Windows.Forms.RadioButton rtnGIRMSC9;
        private System.Windows.Forms.RadioButton rtnGIRMS27;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdId;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn domain;
        private System.Windows.Forms.DataGridViewTextBoxColumn PandR;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.ProgressBar pbrProgress;
    }
}

