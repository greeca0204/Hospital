namespace Hospital
{
    partial class BaseMentalTestAnalyFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.expExcel = new System.Windows.Forms.Button();
            this.dgvMentalTest = new System.Windows.Forms.DataGridView();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cnt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMentalTest)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.expExcel);
            this.groupBox1.Controls.Add(this.dgvMentalTest);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 344);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目统计表格";
            // 
            // expExcel
            // 
            this.expExcel.Location = new System.Drawing.Point(6, 19);
            this.expExcel.Name = "expExcel";
            this.expExcel.Size = new System.Drawing.Size(75, 23);
            this.expExcel.TabIndex = 20;
            this.expExcel.Text = "导出Excel";
            this.expExcel.UseVisualStyleBackColor = true;
            this.expExcel.Click += new System.EventHandler(this.expExcel_Click);
            // 
            // dgvMentalTest
            // 
            this.dgvMentalTest.AllowUserToAddRows = false;
            this.dgvMentalTest.AllowUserToDeleteRows = false;
            this.dgvMentalTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMentalTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMentalTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMentalTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tName,
            this.cnt,
            this.maxv,
            this.minv,
            this.avgv});
            this.dgvMentalTest.Location = new System.Drawing.Point(6, 48);
            this.dgvMentalTest.Name = "dgvMentalTest";
            this.dgvMentalTest.RowTemplate.Height = 23;
            this.dgvMentalTest.Size = new System.Drawing.Size(765, 290);
            this.dgvMentalTest.TabIndex = 1;
            this.dgvMentalTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMentalTest_CellClick);
            // 
            // tName
            // 
            this.tName.DataPropertyName = "tName";
            this.tName.HeaderText = "量表名称";
            this.tName.Name = "tName";
            // 
            // cnt
            // 
            this.cnt.DataPropertyName = "cnt";
            this.cnt.HeaderText = "测试总数";
            this.cnt.Name = "cnt";
            // 
            // maxv
            // 
            this.maxv.DataPropertyName = "maxv";
            this.maxv.HeaderText = "最大值";
            this.maxv.Name = "maxv";
            // 
            // minv
            // 
            this.minv.DataPropertyName = "minv";
            this.minv.HeaderText = "最小值";
            this.minv.Name = "minv";
            // 
            // avgv
            // 
            this.avgv.DataPropertyName = "avgv";
            this.avgv.HeaderText = "平均值";
            this.avgv.Name = "avgv";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Location = new System.Drawing.Point(12, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 243);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计图表";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(771, 223);
            this.panel3.TabIndex = 10;
            // 
            // BaseMentalTestAnalyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 617);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseMentalTestAnalyFrm";
            this.Text = "单项数据分析";
            this.Load += new System.EventHandler(this.SingleDateAnalysisFrm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMentalTest)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMentalTest;
        private System.Windows.Forms.Button expExcel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cnt;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxv;
        private System.Windows.Forms.DataGridViewTextBoxColumn minv;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgv;
    }
}