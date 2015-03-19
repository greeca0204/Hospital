namespace Hospital
{
    partial class MentalTestAnalyByPatFrm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.expExcel = new System.Windows.Forms.Button();
            this.dgvMentalTest = new System.Windows.Forms.DataGridView();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMentalTest)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnBack);
            this.groupBox1.Controls.Add(this.expExcel);
            this.groupBox1.Controls.Add(this.dgvMentalTest);
            this.groupBox1.Location = new System.Drawing.Point(9, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(777, 338);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "项目统计表格";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(87, 19);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "返回";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
            this.count,
            this.max,
            this.min,
            this.avg});
            this.dgvMentalTest.Location = new System.Drawing.Point(6, 57);
            this.dgvMentalTest.Name = "dgvMentalTest";
            this.dgvMentalTest.RowTemplate.Height = 23;
            this.dgvMentalTest.Size = new System.Drawing.Size(765, 275);
            this.dgvMentalTest.TabIndex = 1;
            this.dgvMentalTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMentalTest_CellClick);
            // 
            // tName
            // 
            this.tName.DataPropertyName = "tName";
            this.tName.HeaderText = "量表名称";
            this.tName.Name = "tName";
            // 
            // count
            // 
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "测试总数";
            this.count.Name = "count";
            // 
            // max
            // 
            this.max.DataPropertyName = "max";
            this.max.HeaderText = "最大值";
            this.max.Name = "max";
            // 
            // min
            // 
            this.min.DataPropertyName = "min";
            this.min.HeaderText = "最小值";
            this.min.Name = "min";
            // 
            // avg
            // 
            this.avg.DataPropertyName = "avg";
            this.avg.HeaderText = "平均值";
            this.avg.Name = "avg";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Location = new System.Drawing.Point(12, 411);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(777, 194);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "统计图表";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 17);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(771, 174);
            this.panel3.TabIndex = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lblAge);
            this.groupBox3.Controls.Add(this.lblTel);
            this.groupBox3.Controls.Add(this.lblGroup);
            this.groupBox3.Controls.Add(this.lblSex);
            this.groupBox3.Controls.Add(this.lblUserName);
            this.groupBox3.Location = new System.Drawing.Point(15, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(771, 49);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "患者信息";
            // 
            // lblAge
            // 
            this.lblAge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(166, 21);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(23, 12);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "age";
            // 
            // lblTel
            // 
            this.lblTel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(669, 21);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(23, 12);
            this.lblTel.TabIndex = 3;
            this.lblTel.Text = "tel";
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(500, 21);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(35, 12);
            this.lblGroup.TabIndex = 2;
            this.lblGroup.Text = "group";
            // 
            // lblSex
            // 
            this.lblSex.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(323, 21);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(23, 12);
            this.lblSex.TabIndex = 1;
            this.lblSex.Text = "sex";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(6, 21);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(29, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "name";
            // 
            // MentalTestAnalyByPatFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 617);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MentalTestAnalyByPatFrm";
            this.Text = "单项数据分析";
            this.Load += new System.EventHandler(this.SingleDateAnalysisFrm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMentalTest)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvMentalTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn max;
        private System.Windows.Forms.DataGridViewTextBoxColumn min;
        private System.Windows.Forms.DataGridViewTextBoxColumn avg;
        private System.Windows.Forms.Button expExcel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnBack;
    }
}