namespace Hospital
{
    partial class SystemSetFrm
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
            this.gopHospital = new System.Windows.Forms.GroupBox();
            this.txtSignPath = new System.Windows.Forms.TextBox();
            this.btnViewPictrue = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.txtHospitalIntroduction = new System.Windows.Forms.TextBox();
            this.lblComIntro = new System.Windows.Forms.Label();
            this.lblComName = new System.Windows.Forms.Label();
            this.txtHospitalName = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gopHospital.SuspendLayout();
            this.SuspendLayout();
            // 
            // gopHospital
            // 
            this.gopHospital.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gopHospital.Controls.Add(this.txtSignPath);
            this.gopHospital.Controls.Add(this.btnViewPictrue);
            this.gopHospital.Controls.Add(this.btnSave);
            this.gopHospital.Controls.Add(this.lblLogo);
            this.gopHospital.Controls.Add(this.txtHospitalIntroduction);
            this.gopHospital.Controls.Add(this.lblComIntro);
            this.gopHospital.Controls.Add(this.lblComName);
            this.gopHospital.Controls.Add(this.txtHospitalName);
            this.gopHospital.Location = new System.Drawing.Point(12, 12);
            this.gopHospital.Name = "gopHospital";
            this.gopHospital.Size = new System.Drawing.Size(459, 331);
            this.gopHospital.TabIndex = 0;
            this.gopHospital.TabStop = false;
            this.gopHospital.Text = "医院基本信息";
            // 
            // txtSignPath
            // 
            this.txtSignPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSignPath.Location = new System.Drawing.Point(130, 248);
            this.txtSignPath.Name = "txtSignPath";
            this.txtSignPath.Size = new System.Drawing.Size(229, 21);
            this.txtSignPath.TabIndex = 8;
            // 
            // btnViewPictrue
            // 
            this.btnViewPictrue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewPictrue.Location = new System.Drawing.Point(365, 249);
            this.btnViewPictrue.Name = "btnViewPictrue";
            this.btnViewPictrue.Size = new System.Drawing.Size(75, 23);
            this.btnViewPictrue.TabIndex = 7;
            this.btnViewPictrue.Text = "浏览";
            this.btnViewPictrue.UseVisualStyleBackColor = true;
            this.btnViewPictrue.Click += new System.EventHandler(this.btnViewPictrue_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(177, 287);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogo.AutoSize = true;
            this.lblLogo.Location = new System.Drawing.Point(37, 249);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(89, 12);
            this.lblLogo.TabIndex = 4;
            this.lblLogo.Text = "使用单位图标：";
            // 
            // txtHospitalIntroduction
            // 
            this.txtHospitalIntroduction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHospitalIntroduction.Location = new System.Drawing.Point(130, 72);
            this.txtHospitalIntroduction.Multiline = true;
            this.txtHospitalIntroduction.Name = "txtHospitalIntroduction";
            this.txtHospitalIntroduction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtHospitalIntroduction.Size = new System.Drawing.Size(306, 170);
            this.txtHospitalIntroduction.TabIndex = 3;
            // 
            // lblComIntro
            // 
            this.lblComIntro.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComIntro.AutoSize = true;
            this.lblComIntro.Location = new System.Drawing.Point(35, 72);
            this.lblComIntro.Name = "lblComIntro";
            this.lblComIntro.Size = new System.Drawing.Size(83, 12);
            this.lblComIntro.TabIndex = 2;
            this.lblComIntro.Text = "使用单位简介:";
            // 
            // lblComName
            // 
            this.lblComName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblComName.AutoSize = true;
            this.lblComName.Location = new System.Drawing.Point(35, 42);
            this.lblComName.Name = "lblComName";
            this.lblComName.Size = new System.Drawing.Size(89, 12);
            this.lblComName.TabIndex = 1;
            this.lblComName.Text = "使用单位名称：";
            // 
            // txtHospitalName
            // 
            this.txtHospitalName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHospitalName.Location = new System.Drawing.Point(130, 42);
            this.txtHospitalName.Name = "txtHospitalName";
            this.txtHospitalName.Size = new System.Drawing.Size(306, 21);
            this.txtHospitalName.TabIndex = 0;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // SystemSetFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 355);
            this.Controls.Add(this.gopHospital);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SystemSetFrm";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SystemSetFrm_Load);
            this.gopHospital.ResumeLayout(false);
            this.gopHospital.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gopHospital;
        private System.Windows.Forms.Label lblComName;
        private System.Windows.Forms.TextBox txtHospitalName;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblComIntro;
        private System.Windows.Forms.TextBox txtHospitalIntroduction;
        private System.Windows.Forms.Button btnViewPictrue;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txtSignPath;
    }
}