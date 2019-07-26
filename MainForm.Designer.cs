namespace GitHubSkillEval
{
    partial class MainForm
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
            this.btnScanForLicenses = new System.Windows.Forms.Button();
            this.btnCreateLicenses = new System.Windows.Forms.Button();
            this.txtList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnScanForLicenses
            // 
            this.btnScanForLicenses.Location = new System.Drawing.Point(58, 272);
            this.btnScanForLicenses.Name = "btnScanForLicenses";
            this.btnScanForLicenses.Size = new System.Drawing.Size(140, 23);
            this.btnScanForLicenses.TabIndex = 0;
            this.btnScanForLicenses.Text = "Only Scan For Licenses";
            this.btnScanForLicenses.UseVisualStyleBackColor = true;
            this.btnScanForLicenses.Click += new System.EventHandler(this.BtnScanForLicenses_Click);
            // 
            // btnCreateLicenses
            // 
            this.btnCreateLicenses.Location = new System.Drawing.Point(274, 272);
            this.btnCreateLicenses.Name = "btnCreateLicenses";
            this.btnCreateLicenses.Size = new System.Drawing.Size(140, 23);
            this.btnCreateLicenses.TabIndex = 1;
            this.btnCreateLicenses.Text = "Scan and Create Licenses";
            this.btnCreateLicenses.UseVisualStyleBackColor = true;
            this.btnCreateLicenses.Click += new System.EventHandler(this.BtnCreateLicenses_Click);
            // 
            // txtList
            // 
            this.txtList.Location = new System.Drawing.Point(58, 26);
            this.txtList.Multiline = true;
            this.txtList.Name = "txtList";
            this.txtList.ReadOnly = true;
            this.txtList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtList.Size = new System.Drawing.Size(356, 230);
            this.txtList.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 317);
            this.Controls.Add(this.txtList);
            this.Controls.Add(this.btnCreateLicenses);
            this.Controls.Add(this.btnScanForLicenses);
            this.Name = "MainForm";
            this.Text = "GitHub Skill Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScanForLicenses;
        private System.Windows.Forms.Button btnCreateLicenses;
        private System.Windows.Forms.TextBox txtList;
    }
}

