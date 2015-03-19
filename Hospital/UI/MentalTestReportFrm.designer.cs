namespace Hospital
{
    partial class MentalTestReportFrm
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
            this.btnPsyTest = new System.Windows.Forms.Button();
            this.btnTestMentalSta = new System.Windows.Forms.Button();
            this.btnDoctAdvice = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvMentalTestResult = new System.Windows.Forms.DataGridView();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtAdvice = new System.Windows.Forms.TextBox();
            this.txtMentalTestResult = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.GroupBox();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.lblSex = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.Testtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TNameItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Answer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Advice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMentalTestResult)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.btnBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnPsyTest);
            this.groupBox2.Controls.Add(this.btnTestMentalSta);
            this.groupBox2.Controls.Add(this.btnDoctAdvice);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.dgvMentalTestResult);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnPrint);
            this.groupBox2.Location = new System.Drawing.Point(14, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(961, 298);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "心理测试结果";
            // 
            // btnPsyTest
            // 
            this.btnPsyTest.Location = new System.Drawing.Point(114, 21);
            this.btnPsyTest.Name = "btnPsyTest";
            this.btnPsyTest.Size = new System.Drawing.Size(75, 23);
            this.btnPsyTest.TabIndex = 11;
            this.btnPsyTest.Text = "添加测试";
            this.btnPsyTest.UseVisualStyleBackColor = true;
            this.btnPsyTest.Click += new System.EventHandler(this.btnPsyTest_Click);
            // 
            // btnTestMentalSta
            // 
            this.btnTestMentalSta.Location = new System.Drawing.Point(293, 21);
            this.btnTestMentalSta.Name = "btnTestMentalSta";
            this.btnTestMentalSta.Size = new System.Drawing.Size(138, 23);
            this.btnTestMentalSta.TabIndex = 10;
            this.btnTestMentalSta.Text = "个人心理测试病历统计";
            this.btnTestMentalSta.UseVisualStyleBackColor = true;
            this.btnTestMentalSta.Click += new System.EventHandler(this.btnTestMentalSta_Click);
            // 
            // btnDoctAdvice
            // 
            this.btnDoctAdvice.Location = new System.Drawing.Point(6, 21);
            this.btnDoctAdvice.Name = "btnDoctAdvice";
            this.btnDoctAdvice.Size = new System.Drawing.Size(102, 23);
            this.btnDoctAdvice.TabIndex = 9;
            this.btnDoctAdvice.Text = "添加医生意见";
            this.btnDoctAdvice.UseVisualStyleBackColor = true;
            this.btnDoctAdvice.Click += new System.EventHandler(this.btnDoctAdvice_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(518, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvMentalTestResult
            // 
            this.dgvMentalTestResult.AllowUserToAddRows = false;
            this.dgvMentalTestResult.AllowUserToDeleteRows = false;
            this.dgvMentalTestResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMentalTestResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMentalTestResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMentalTestResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Testtime,
            this.TName,
            this.TNameItem,
            this.Score,
            this.Answer,
            this.Advice});
            this.dgvMentalTestResult.Location = new System.Drawing.Point(6, 50);
            this.dgvMentalTestResult.Name = "dgvMentalTestResult";
            this.dgvMentalTestResult.RowTemplate.Height = 23;
            this.dgvMentalTestResult.Size = new System.Drawing.Size(949, 242);
            this.dgvMentalTestResult.TabIndex = 7;
            this.dgvMentalTestResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMentalTestResult_CellClick);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(195, 21);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(92, 23);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "删除测试结果";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(437, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtAdvice);
            this.groupBox3.Controls.Add(this.txtMentalTestResult);
            this.groupBox3.Location = new System.Drawing.Point(12, 382);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(963, 254);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测试结论编辑";
            // 
            // txtAdvice
            // 
            this.txtAdvice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAdvice.Location = new System.Drawing.Point(452, 20);
            this.txtAdvice.Multiline = true;
            this.txtAdvice.Name = "txtAdvice";
            this.txtAdvice.Size = new System.Drawing.Size(505, 228);
            this.txtAdvice.TabIndex = 10;
            // 
            // txtMentalTestResult
            // 
            this.txtMentalTestResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMentalTestResult.Location = new System.Drawing.Point(6, 20);
            this.txtMentalTestResult.Multiline = true;
            this.txtMentalTestResult.Name = "txtMentalTestResult";
            this.txtMentalTestResult.ReadOnly = true;
            this.txtMentalTestResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMentalTestResult.Size = new System.Drawing.Size(440, 228);
            this.txtMentalTestResult.TabIndex = 9;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Controls.Add(this.lblAge);
            this.btnBack.Controls.Add(this.lblTel);
            this.btnBack.Controls.Add(this.lblGroup);
            this.btnBack.Controls.Add(this.lblSex);
            this.btnBack.Controls.Add(this.lblUserName);
            this.btnBack.Location = new System.Drawing.Point(20, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(955, 49);
            this.btnBack.TabIndex = 10;
            this.btnBack.TabStop = false;
            this.btnBack.Text = "患者信息";
            // 
            // lblAge
            // 
            this.lblAge.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(258, 21);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(23, 12);
            this.lblAge.TabIndex = 4;
            this.lblAge.Text = "age";
            // 
            // lblTel
            // 
            this.lblTel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(761, 21);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(23, 12);
            this.lblTel.TabIndex = 3;
            this.lblTel.Text = "tel";
            // 
            // lblGroup
            // 
            this.lblGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblGroup.AutoSize = true;
            this.lblGroup.Location = new System.Drawing.Point(592, 21);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(35, 12);
            this.lblGroup.TabIndex = 2;
            this.lblGroup.Text = "group";
            // 
            // lblSex
            // 
            this.lblSex.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSex.AutoSize = true;
            this.lblSex.Location = new System.Drawing.Point(415, 21);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(23, 12);
            this.lblSex.TabIndex = 1;
            this.lblSex.Text = "sex";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(87, 21);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(29, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "name";
            // 
            // Testtime
            // 
            this.Testtime.DataPropertyName = "Testtime";
            this.Testtime.HeaderText = "测试时间";
            this.Testtime.Name = "Testtime";
            // 
            // TName
            // 
            this.TName.DataPropertyName = "TName";
            this.TName.HeaderText = "量表名";
            this.TName.Name = "TName";
            // 
            // TNameItem
            // 
            this.TNameItem.DataPropertyName = "TNameItem";
            this.TNameItem.HeaderText = "量表项";
            this.TNameItem.Name = "TNameItem";
            // 
            // Score
            // 
            this.Score.DataPropertyName = "Score";
            this.Score.HeaderText = "得分";
            this.Score.Name = "Score";
            // 
            // Answer
            // 
            this.Answer.DataPropertyName = "Answer";
            this.Answer.HeaderText = "患者测试答案";
            this.Answer.Name = "Answer";
            // 
            // Advice
            // 
            this.Advice.DataPropertyName = "Advice";
            this.Advice.HeaderText = "医生建议";
            this.Advice.Name = "Advice";
            // 
            // MentalTestReportFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 648);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MentalTestReportFrm";
            this.Text = "心理测试报告结果";
            this.Load += new System.EventHandler(this.TestReportFrm_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMentalTestResult)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.btnBack.ResumeLayout(false);
            this.btnBack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtMentalTestResult;
        private System.Windows.Forms.DataGridView dgvMentalTestResult;
        private System.Windows.Forms.GroupBox btnBack;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblTel;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.Label lblSex;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTestMentalSta;
        private System.Windows.Forms.Button btnDoctAdvice;
        private System.Windows.Forms.TextBox txtAdvice;
        private System.Windows.Forms.Button btnPsyTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Testtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TNameItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn Answer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Advice;
    }
}