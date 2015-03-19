namespace Hospital
{
    partial class ContactUsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContactUsFrm));
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblTax = new System.Windows.Forms.Label();
            this.lblWebsite = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picLogo.BackColor = System.Drawing.SystemColors.Window;
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.InitialImage = ((System.Drawing.Image)(resources.GetObject("picLogo.InitialImage")));
            this.picLogo.Location = new System.Drawing.Point(-1, -2);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(703, 126);
            this.picLogo.TabIndex = 3;
            this.picLogo.TabStop = false;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.BackColor = System.Drawing.SystemColors.Window;
            this.lblAddress.Location = new System.Drawing.Point(244, 159);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(185, 12);
            this.lblAddress.TabIndex = 4;
            this.lblAddress.Text = "地址：广州市白云区鹤龙一路32号";
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.BackColor = System.Drawing.SystemColors.Window;
            this.lblTel.Location = new System.Drawing.Point(244, 181);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(191, 12);
            this.lblTel.TabIndex = 5;
            this.lblTel.Text = "电话：（020）36351278  37328062";
            // 
            // lblTax
            // 
            this.lblTax.AutoSize = true;
            this.lblTax.BackColor = System.Drawing.SystemColors.Window;
            this.lblTax.Location = new System.Drawing.Point(244, 205);
            this.lblTax.Name = "lblTax";
            this.lblTax.Size = new System.Drawing.Size(155, 12);
            this.lblTax.TabIndex = 6;
            this.lblTax.Text = "传真：（020）36350920-607";
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.BackColor = System.Drawing.SystemColors.Window;
            this.lblWebsite.Location = new System.Drawing.Point(244, 228);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(143, 12);
            this.lblWebsite.TabIndex = 7;
            this.lblWebsite.Text = "网址：www.chinahori.com";
            // 
            // ContactUsFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(702, 298);
            this.Controls.Add(this.lblWebsite);
            this.Controls.Add(this.lblTax);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.picLogo);
            this.MaximizeBox = false;
            this.Name = "ContactUsFrm";
            this.Text = "联系我们";
            this.Load += new System.EventHandler(this.ContactUs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblTax;
        private System.Windows.Forms.Label lblWebsite;
    }
}