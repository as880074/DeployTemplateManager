namespace DeployTemplateManager
{
    partial class DeployToolForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chkListBoxPublishSites = new CheckedListBox();
            txtPublishEnvironment = new TextBox();
            lblEnvironment = new Label();
            lblPublishSite = new Label();
            button1 = new Button();
            lblChangeItem = new Label();
            txtChangeItem = new TextBox();
            label1 = new Label();
            textBoxCreditFrontendBackendCommitId = new TextBox();
            label2 = new Label();
            textBoxSlotGameFrontendCommitId = new TextBox();
            label3 = new Label();
            textBoxSlotGameBackendCommitId = new TextBox();
            label4 = new Label();
            textBoxCreditFrontendBackendRollbackCommitId = new TextBox();
            label5 = new Label();
            textBoxSlotGameFrontendRollbackCommitId = new TextBox();
            label6 = new Label();
            textBoxSlotGameBackendRollbackCommitId = new TextBox();
            SuspendLayout();
            // 
            // chkListBoxPublishSites
            // 
            chkListBoxPublishSites.FormattingEnabled = true;
            chkListBoxPublishSites.Location = new Point(32, 44);
            chkListBoxPublishSites.Name = "chkListBoxPublishSites";
            chkListBoxPublishSites.Size = new Size(714, 130);
            chkListBoxPublishSites.TabIndex = 0;
            // 
            // txtPublishEnvironment
            // 
            txtPublishEnvironment.Location = new Point(32, 211);
            txtPublishEnvironment.Name = "txtPublishEnvironment";
            txtPublishEnvironment.Size = new Size(271, 23);
            txtPublishEnvironment.TabIndex = 1;
            // 
            // lblEnvironment
            // 
            lblEnvironment.AutoSize = true;
            lblEnvironment.Location = new Point(29, 191);
            lblEnvironment.Name = "lblEnvironment";
            lblEnvironment.Size = new Size(55, 15);
            lblEnvironment.TabIndex = 2;
            lblEnvironment.Text = "發布環境";
            // 
            // lblPublishSite
            // 
            lblPublishSite.AutoSize = true;
            lblPublishSite.ForeColor = SystemColors.ControlText;
            lblPublishSite.Location = new Point(32, 23);
            lblPublishSite.Name = "lblPublishSite";
            lblPublishSite.Size = new Size(55, 15);
            lblPublishSite.TabIndex = 3;
            lblPublishSite.Text = "發布站台";
            lblPublishSite.TextAlign = ContentAlignment.BottomRight;
            // 
            // button1
            // 
            button1.Location = new Point(665, 690);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "產生";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblChangeItem
            // 
            lblChangeItem.AutoSize = true;
            lblChangeItem.Location = new Point(29, 403);
            lblChangeItem.Name = "lblChangeItem";
            lblChangeItem.Size = new Size(55, 15);
            lblChangeItem.TabIndex = 5;
            lblChangeItem.Text = "異動項目";
            // 
            // txtChangeItem
            // 
            txtChangeItem.Location = new Point(29, 430);
            txtChangeItem.Multiline = true;
            txtChangeItem.Name = "txtChangeItem";
            txtChangeItem.Size = new Size(711, 240);
            txtChangeItem.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 247);
            label1.Name = "label1";
            label1.Size = new Size(205, 15);
            label1.TabIndex = 8;
            label1.Text = "Credit Frontend,Backend CommitId";
            // 
            // textBoxCreditFrontendBackendCommitId
            // 
            textBoxCreditFrontendBackendCommitId.Location = new Point(32, 267);
            textBoxCreditFrontendBackendCommitId.Name = "textBoxCreditFrontendBackendCommitId";
            textBoxCreditFrontendBackendCommitId.Size = new Size(271, 23);
            textBoxCreditFrontendBackendCommitId.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 297);
            label2.Name = "label2";
            label2.Size = new Size(176, 15);
            label2.TabIndex = 10;
            label2.Text = "SlotGame FrontEnd CommitId";
            // 
            // textBoxSlotGameFrontendCommitId
            // 
            textBoxSlotGameFrontendCommitId.Location = new Point(32, 317);
            textBoxSlotGameFrontendCommitId.Name = "textBoxSlotGameFrontendCommitId";
            textBoxSlotGameFrontendCommitId.Size = new Size(271, 23);
            textBoxSlotGameFrontendCommitId.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 347);
            label3.Name = "label3";
            label3.Size = new Size(176, 15);
            label3.TabIndex = 12;
            label3.Text = "SlotGame Backend  CommitId";
            // 
            // textBoxSlotGameBackendCommitId
            // 
            textBoxSlotGameBackendCommitId.Location = new Point(32, 367);
            textBoxSlotGameBackendCommitId.Name = "textBoxSlotGameBackendCommitId";
            textBoxSlotGameBackendCommitId.Size = new Size(271, 23);
            textBoxSlotGameBackendCommitId.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(380, 247);
            label4.Name = "label4";
            label4.Size = new Size(257, 15);
            label4.TabIndex = 14;
            label4.Text = "Credit Frontend,Backend Rollback CommitId";
            // 
            // textBoxCreditFrontendBackendRollbackCommitId
            // 
            textBoxCreditFrontendBackendRollbackCommitId.Location = new Point(383, 267);
            textBoxCreditFrontendBackendRollbackCommitId.Name = "textBoxCreditFrontendBackendRollbackCommitId";
            textBoxCreditFrontendBackendRollbackCommitId.Size = new Size(271, 23);
            textBoxCreditFrontendBackendRollbackCommitId.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(380, 297);
            label5.Name = "label5";
            label5.Size = new Size(231, 15);
            label5.TabIndex = 16;
            label5.Text = "SlotGame FrontEnd Rollback  CommitId";
            // 
            // textBoxSlotGameFrontendRollbackCommitId
            // 
            textBoxSlotGameFrontendRollbackCommitId.Location = new Point(383, 317);
            textBoxSlotGameFrontendRollbackCommitId.Name = "textBoxSlotGameFrontendRollbackCommitId";
            textBoxSlotGameFrontendRollbackCommitId.Size = new Size(271, 23);
            textBoxSlotGameFrontendRollbackCommitId.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(380, 347);
            label6.Name = "label6";
            label6.Size = new Size(225, 15);
            label6.TabIndex = 18;
            label6.Text = "SlotGame Backend Rollback CommitId";
            // 
            // textBoxSlotGameBackendRollbackCommitId
            // 
            textBoxSlotGameBackendRollbackCommitId.Location = new Point(383, 367);
            textBoxSlotGameBackendRollbackCommitId.Name = "textBoxSlotGameBackendRollbackCommitId";
            textBoxSlotGameBackendRollbackCommitId.Size = new Size(271, 23);
            textBoxSlotGameBackendRollbackCommitId.TabIndex = 17;
            // 
            // DeployToolForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(783, 741);
            Controls.Add(label6);
            Controls.Add(textBoxSlotGameBackendRollbackCommitId);
            Controls.Add(label5);
            Controls.Add(textBoxSlotGameFrontendRollbackCommitId);
            Controls.Add(label4);
            Controls.Add(textBoxCreditFrontendBackendRollbackCommitId);
            Controls.Add(label3);
            Controls.Add(textBoxSlotGameBackendCommitId);
            Controls.Add(label2);
            Controls.Add(textBoxSlotGameFrontendCommitId);
            Controls.Add(label1);
            Controls.Add(textBoxCreditFrontendBackendCommitId);
            Controls.Add(txtChangeItem);
            Controls.Add(lblChangeItem);
            Controls.Add(button1);
            Controls.Add(lblPublishSite);
            Controls.Add(lblEnvironment);
            Controls.Add(txtPublishEnvironment);
            Controls.Add(chkListBoxPublishSites);
            Name = "DeployToolForm";
            Text = "發版工具";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private CheckedListBox chkListBoxPublishSites;
        private TextBox txtPublishEnvironment;
        private Label lblEnvironment;
        private Label lblPublishSite;
        private Button button1;
        private Label lblChangeItem;
        private TextBox txtChangeItem;
        private Label label1;
        private TextBox textBoxCreditFrontendBackendCommitId;
        private Label label2;
        private TextBox textBoxSlotGameFrontendCommitId;
        private Label label3;
        private TextBox textBoxSlotGameBackendCommitId;
        private Label label4;
        private TextBox textBoxCreditFrontendBackendRollbackCommitId;
        private Label label5;
        private TextBox textBoxSlotGameFrontendRollbackCommitId;
        private Label label6;
        private TextBox textBoxSlotGameBackendRollbackCommitId;
    }
}
