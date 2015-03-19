namespace Hospital
{
    partial class UsualTestFrm
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
            this.dgvUsualTest = new System.Windows.Forms.DataGridView();
            this.tid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.asdame = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uflag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hflag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sflag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsualTest)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsualTest
            // 
            this.dgvUsualTest.AllowUserToAddRows = false;
            this.dgvUsualTest.AllowUserToDeleteRows = false;
            this.dgvUsualTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsualTest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tid,
            this.asdame,
            this.uflag,
            this.hflag,
            this.sflag});
            this.dgvUsualTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsualTest.Location = new System.Drawing.Point(0, 0);
            this.dgvUsualTest.Name = "dgvUsualTest";
            this.dgvUsualTest.RowTemplate.Height = 23;
            this.dgvUsualTest.Size = new System.Drawing.Size(789, 346);
            this.dgvUsualTest.TabIndex = 0;
            this.dgvUsualTest.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.CellValueChanged);
            this.dgvUsualTest.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvUsualTest_CurrentCellDirtyStateChanged);
            // 
            // tid
            // 
            this.tid.DataPropertyName = "tId";
            this.tid.HeaderText = "tid";
            this.tid.Name = "tid";
            this.tid.Visible = false;
            // 
            // asdame
            // 
            this.asdame.DataPropertyName = "tName";
            this.asdame.HeaderText = "量表";
            this.asdame.Name = "asdame";
            this.asdame.Width = 400;
            // 
            // uflag
            // 
            this.uflag.DataPropertyName = "uflag";
            this.uflag.FalseValue = "false";
            this.uflag.HeaderText = "通用常用量表";
            this.uflag.Name = "uflag";
            this.uflag.TrueValue = "true";
            this.uflag.Width = 300;
            // 
            // hflag
            // 
            this.hflag.DataPropertyName = "hflag";
            this.hflag.FalseValue = "false";
            this.hflag.HeaderText = "医院通用量表";
            this.hflag.Name = "hflag";
            this.hflag.TrueValue = "true";
            this.hflag.Width = 300;
            // 
            // sflag
            // 
            this.sflag.DataPropertyName = "sflag";
            this.sflag.FalseValue = "false";
            this.sflag.HeaderText = "显示测试量表";
            this.sflag.Name = "sflag";
            this.sflag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.sflag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.sflag.TrueValue = "true";
            this.sflag.Width = 300;
            // 
            // UsualTestFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 346);
            this.Controls.Add(this.dgvUsualTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UsualTestFrm";
            this.Text = "CommonTestFrm";
            this.Load += new System.EventHandler(this.UsualTestFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsualTest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsualTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn tid;
        private System.Windows.Forms.DataGridViewTextBoxColumn asdame;
        private System.Windows.Forms.DataGridViewCheckBoxColumn uflag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hflag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sflag;

    }
}