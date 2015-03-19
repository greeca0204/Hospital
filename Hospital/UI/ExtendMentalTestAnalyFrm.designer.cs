namespace Hospital
{
    partial class ExtendMentalTestAnalyFrm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAge = new System.Windows.Forms.CheckBox();
            this.chkGroup = new System.Windows.Forms.CheckBox();
            this.dgvMentalTest = new System.Windows.Forms.DataGridView();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coltestGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colsex = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.max = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.min = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkSex = new System.Windows.Forms.CheckBox();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMentalTest)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkAge);
            this.groupBox2.Controls.Add(this.chkGroup);
            this.groupBox2.Controls.Add(this.dgvMentalTest);
            this.groupBox2.Controls.Add(this.chkSex);
            this.groupBox2.Controls.Add(this.btnExcel);
            this.groupBox2.Controls.Add(this.btnQuery);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(786, 340);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "项目统计表格";
            // 
            // chkAge
            // 
            this.chkAge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAge.AutoSize = true;
            this.chkAge.Location = new System.Drawing.Point(114, 24);
            this.chkAge.Name = "chkAge";
            this.chkAge.Size = new System.Drawing.Size(48, 16);
            this.chkAge.TabIndex = 21;
            this.chkAge.Text = "年龄";
            this.chkAge.UseVisualStyleBackColor = true;
            // 
            // chkGroup
            // 
            this.chkGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGroup.AutoSize = true;
            this.chkGroup.Location = new System.Drawing.Point(6, 24);
            this.chkGroup.Name = "chkGroup";
            this.chkGroup.Size = new System.Drawing.Size(48, 16);
            this.chkGroup.TabIndex = 0;
            this.chkGroup.Text = "分组";
            this.chkGroup.UseVisualStyleBackColor = true;
            // 
            // dgvMentalTest
            // 
            this.dgvMentalTest.AllowUserToAddRows = false;
            this.dgvMentalTest.AllowUserToDeleteRows = false;
            this.dgvMentalTest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMentalTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMentalTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMentalTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tName,
            this.coltestGroup,
            this.colsex,
            this.colAge,
            this.count,
            this.max,
            this.min,
            this.avg});
            this.dgvMentalTest.Location = new System.Drawing.Point(5, 49);
            this.dgvMentalTest.Name = "dgvMentalTest";
            this.dgvMentalTest.RowTemplate.Height = 23;
            this.dgvMentalTest.Size = new System.Drawing.Size(774, 281);
            this.dgvMentalTest.TabIndex = 2;
            this.dgvMentalTest.Click += new System.EventHandler(this.dgvMentalTest_Click);
            // 
            // tName
            // 
            this.tName.DataPropertyName = "tName";
            this.tName.HeaderText = "量表名称";
            this.tName.Name = "tName";
            // 
            // coltestGroup
            // 
            this.coltestGroup.DataPropertyName = "testGroup";
            this.coltestGroup.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.coltestGroup.HeaderText = "用户组";
            this.coltestGroup.Name = "coltestGroup";
            this.coltestGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.coltestGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colsex
            // 
            this.colsex.DataPropertyName = "sex";
            this.colsex.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colsex.HeaderText = "性别";
            this.colsex.Name = "colsex";
            this.colsex.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colsex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colAge
            // 
            this.colAge.DataPropertyName = "ageGroup";
            this.colAge.HeaderText = "年龄段";
            this.colAge.Name = "colAge";
            // 
            // count
            // 
            this.count.DataPropertyName = "cnt";
            this.count.HeaderText = "测试总数";
            this.count.Name = "count";
            // 
            // max
            // 
            this.max.DataPropertyName = "maxv";
            this.max.HeaderText = "最大值";
            this.max.Name = "max";
            // 
            // min
            // 
            this.min.DataPropertyName = "minv";
            this.min.HeaderText = "最小值";
            this.min.Name = "min";
            // 
            // avg
            // 
            this.avg.DataPropertyName = "avgv";
            this.avg.HeaderText = "平均值";
            this.avg.Name = "avg";
            // 
            // chkSex
            // 
            this.chkSex.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSex.AutoSize = true;
            this.chkSex.Location = new System.Drawing.Point(60, 24);
            this.chkSex.Name = "chkSex";
            this.chkSex.Size = new System.Drawing.Size(48, 16);
            this.chkSex.TabIndex = 2;
            this.chkSex.Text = "性别";
            this.chkSex.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(249, 20);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 4;
            this.btnExcel.Text = "导出EXCEL";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(168, 20);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 3;
            this.btnQuery.Text = "汇总查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Location = new System.Drawing.Point(12, 358);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 253);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "统计图表";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Location = new System.Drawing.Point(6, 20);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(771, 223);
            this.panel3.TabIndex = 10;
            // 
            // ExtendMentalTestAnalyFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 644);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExtendMentalTestAnalyFrm";
            this.Text = "多项数据分析";
            this.Load += new System.EventHandler(this.MulDateAnalysis_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMentalTest)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvMentalTest;
        private System.Windows.Forms.CheckBox chkGroup;
        private System.Windows.Forms.CheckBox chkSex;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewComboBoxColumn coltestGroup;
        private System.Windows.Forms.DataGridViewComboBoxColumn colsex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn count;
        private System.Windows.Forms.DataGridViewTextBoxColumn max;
        private System.Windows.Forms.DataGridViewTextBoxColumn min;
        private System.Windows.Forms.DataGridViewTextBoxColumn avg;
    }
}