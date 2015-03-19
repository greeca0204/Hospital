namespace Hospital
{
    partial class HomeFrm
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
            this.lblIntro = new System.Windows.Forms.Label();
            this.lblCName = new System.Windows.Forms.Label();
            this.pbxCompanySign = new System.Windows.Forms.PictureBox();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.lblUserName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxCompanySign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.BackColor = System.Drawing.Color.PaleGreen;
            this.lblIntro.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.lblIntro.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblIntro.Location = new System.Drawing.Point(503, 147);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(583, 473);
            this.lblIntro.TabIndex = 4;
            this.lblIntro.Text = "label2";
            // 
            // lblCName
            // 
            this.lblCName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCName.BackColor = System.Drawing.Color.PaleGreen;
            this.lblCName.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblCName.Location = new System.Drawing.Point(561, 72);
            this.lblCName.Name = "lblCName";
            this.lblCName.Size = new System.Drawing.Size(374, 62);
            this.lblCName.TabIndex = 3;
            this.lblCName.Text = "label1";
            // 
            // pbxCompanySign
            // 
            this.pbxCompanySign.BackColor = System.Drawing.Color.PaleGreen;
            this.pbxCompanySign.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxCompanySign.Location = new System.Drawing.Point(0, 0);
            this.pbxCompanySign.Name = "pbxCompanySign";
            this.pbxCompanySign.Size = new System.Drawing.Size(710, 408);
            this.pbxCompanySign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxCompanySign.TabIndex = 9;
            this.pbxCompanySign.TabStop = false;
            // 
            // picBox
            // 
            this.picBox.BackColor = System.Drawing.Color.PaleGreen;
            this.picBox.Location = new System.Drawing.Point(50, 66);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(419, 567);
            this.picBox.TabIndex = 10;
            this.picBox.TabStop = false;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.BackColor = System.Drawing.Color.PaleGreen;
            this.lblUserName.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblUserName.Location = new System.Drawing.Point(45, 30);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(374, 33);
            this.lblUserName.TabIndex = 11;
            this.lblUserName.Text = "label1";
            // 
            // HomeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 408);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.lblIntro);
            this.Controls.Add(this.lblCName);
            this.Controls.Add(this.pbxCompanySign);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeFrm";
            this.Text = "首页";
            this.Load += new System.EventHandler(this.HomeFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxCompanySign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Label lblCName;
        private System.Windows.Forms.PictureBox pbxCompanySign;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label lblUserName;
    }
}