namespace Hospital
{
    partial class IndexFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexFrm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiIndex = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHospital = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOffice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDoctor = new System.Windows.Forms.ToolStripMenuItem();
            this.医院常用量表定制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUserInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.datatsmiDataAnis = new System.Windows.Forms.ToolStripMenuItem();
            this.datatsmiBanDataAnis = new System.Windows.Forms.ToolStripMenuItem();
            this.datatsmiMoreDataAnis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSysSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLinkus = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiIndex,
            this.tsmiHospital,
            this.tsmiUserInfo,
            this.datatsmiDataAnis,
            this.tsmiSysSet,
            this.tsmiHelp,
            this.tsmiLinkus,
            this.tsmiExit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(667, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiIndex
            // 
            this.tsmiIndex.Name = "tsmiIndex";
            this.tsmiIndex.Size = new System.Drawing.Size(44, 21);
            this.tsmiIndex.Text = "首页";
            this.tsmiIndex.Click += new System.EventHandler(this.tsmiIndex_Click);
            // 
            // tsmiHospital
            // 
            this.tsmiHospital.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOffice,
            this.tsmiDoctor,
            this.医院常用量表定制ToolStripMenuItem});
            this.tsmiHospital.Name = "tsmiHospital";
            this.tsmiHospital.Size = new System.Drawing.Size(92, 21);
            this.tsmiHospital.Text = "医院信息管理";
            // 
            // tsmiOffice
            // 
            this.tsmiOffice.Name = "tsmiOffice";
            this.tsmiOffice.Size = new System.Drawing.Size(172, 22);
            this.tsmiOffice.Text = "科室信息管理";
            this.tsmiOffice.Click += new System.EventHandler(this.tsmiOffice_Click);
            // 
            // tsmiDoctor
            // 
            this.tsmiDoctor.Name = "tsmiDoctor";
            this.tsmiDoctor.Size = new System.Drawing.Size(172, 22);
            this.tsmiDoctor.Text = "医生信息管理";
            this.tsmiDoctor.Click += new System.EventHandler(this.tsmiDoctor_Click);
            // 
            // 医院常用量表定制ToolStripMenuItem
            // 
            this.医院常用量表定制ToolStripMenuItem.Name = "医院常用量表定制ToolStripMenuItem";
            this.医院常用量表定制ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.医院常用量表定制ToolStripMenuItem.Text = "医院常用量表定制";
            this.医院常用量表定制ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // tsmiUserInfo
            // 
            this.tsmiUserInfo.Name = "tsmiUserInfo";
            this.tsmiUserInfo.Size = new System.Drawing.Size(92, 21);
            this.tsmiUserInfo.Text = "患者信息管理";
            this.tsmiUserInfo.Click += new System.EventHandler(this.tsmipatientInfo_Click);
            // 
            // datatsmiDataAnis
            // 
            this.datatsmiDataAnis.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datatsmiBanDataAnis,
            this.datatsmiMoreDataAnis});
            this.datatsmiDataAnis.Name = "datatsmiDataAnis";
            this.datatsmiDataAnis.Size = new System.Drawing.Size(68, 21);
            this.datatsmiDataAnis.Text = "统计分析";
            // 
            // datatsmiBanDataAnis
            // 
            this.datatsmiBanDataAnis.Name = "datatsmiBanDataAnis";
            this.datatsmiBanDataAnis.Size = new System.Drawing.Size(196, 22);
            this.datatsmiBanDataAnis.Text = "基本心理测试统计分析";
            this.datatsmiBanDataAnis.Click += new System.EventHandler(this.datatsmiBanDataAnis_Click);
            // 
            // datatsmiMoreDataAnis
            // 
            this.datatsmiMoreDataAnis.Name = "datatsmiMoreDataAnis";
            this.datatsmiMoreDataAnis.Size = new System.Drawing.Size(196, 22);
            this.datatsmiMoreDataAnis.Text = "高级心理测试统计分析";
            this.datatsmiMoreDataAnis.Click += new System.EventHandler(this.datatsmiMoreDataAnis_Click);
            // 
            // tsmiSysSet
            // 
            this.tsmiSysSet.Name = "tsmiSysSet";
            this.tsmiSysSet.Size = new System.Drawing.Size(68, 21);
            this.tsmiSysSet.Text = "系统设置";
            this.tsmiSysSet.Click += new System.EventHandler(this.tsmiSysSet_Click);
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(68, 21);
            this.tsmiHelp.Text = "帮助信息";
            this.tsmiHelp.Click += new System.EventHandler(this.tsmiHelp_Click);
            // 
            // tsmiLinkus
            // 
            this.tsmiLinkus.Name = "tsmiLinkus";
            this.tsmiLinkus.Size = new System.Drawing.Size(68, 21);
            this.tsmiLinkus.Text = "联系我们";
            this.tsmiLinkus.Click += new System.EventHandler(this.tsmiLinkus_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(44, 21);
            this.tsmiExit.Text = "退出";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tIcon
            // 
            this.tIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("tIcon.Icon")));
            this.tIcon.Text = "notifyIcon1";
            this.tIcon.Visible = true;
            this.tIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tIcon_MouseDoubleClick);
            // 
            // IndexFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(667, 311);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IndexFrm";
            this.Text = "弘瑞心理健康管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Index_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiUserInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiSysSet;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem datatsmiDataAnis;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmiLinkus;
        private System.Windows.Forms.ToolStripMenuItem datatsmiBanDataAnis;
        private System.Windows.Forms.ToolStripMenuItem datatsmiMoreDataAnis;
        private System.Windows.Forms.ToolStripMenuItem tsmiIndex;
        private System.Windows.Forms.NotifyIcon tIcon;
        private System.Windows.Forms.ToolStripMenuItem tsmiHospital;
        private System.Windows.Forms.ToolStripMenuItem tsmiOffice;
        private System.Windows.Forms.ToolStripMenuItem tsmiDoctor;
        private System.Windows.Forms.ToolStripMenuItem 医院常用量表定制ToolStripMenuItem;
    }
}

