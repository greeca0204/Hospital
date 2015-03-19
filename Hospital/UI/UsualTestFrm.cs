using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hospital
{
    public partial class UsualTestFrm : Form
    {
        List<Test> list = null;
        TestManager testManger = null;

        public UsualTestFrm()
        {

            InitializeComponent();
        }

        private void UsualTestFrm_Load(object sender, EventArgs e)
        {
            this.dgvUsualTest.AllowUserToResizeColumns = false;
            testManger = new TestManager();
            try
            {
                list = testManger.GetTestByItem();
                this.dgvUsualTest.AutoGenerateColumns = false;
                this.dgvUsualTest.DataSource = list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("量表数据加载失败！");
            }
            finally { }
        }

        private void dgvUsualTest_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvUsualTest.IsCurrentCellDirty) //有未提交的更//改
                {
                    this.dgvUsualTest.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("数据提交失败！");
            }
            finally { }
        }

        //触发datagridview更改值事件
        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvUsualTest.Columns[e.ColumnIndex].Name.Equals("uflag") || this.dgvUsualTest.Columns[e.ColumnIndex].Name.Equals("hflag") || this.dgvUsualTest.Columns[e.ColumnIndex].Name.Equals("sflag"))
                {
                    int curColumn = this.dgvUsualTest.CurrentCell.ColumnIndex;
                    int curRow = this.dgvUsualTest.CurrentCell.RowIndex;
                    DataGridViewCell tidCell = this.dgvUsualTest.Rows[curRow].Cells[0] as DataGridViewCell;
                    int tidValue = Convert.ToInt32(tidCell.Value);
                    if (curColumn == 2)//DataGridView的第3列
                    {
                        DataGridViewCheckBoxCell checkCell = this.dgvUsualTest.Rows[curRow].Cells[2] as DataGridViewCheckBoxCell;
                        Boolean usualFlag = Convert.ToBoolean(checkCell.Value);
                        this.testManger.updateTestByUsual(Convert.ToInt32(tidValue), usualFlag);
                    }
                    else if (curColumn == 3)//DataGridView的第4列
                    {
                        DataGridViewCheckBoxCell checkCell = this.dgvUsualTest.Rows[curRow].Cells[3] as DataGridViewCheckBoxCell;
                        Boolean usualFlag = Convert.ToBoolean(checkCell.Value);
                        this.testManger.updateTestByHUsual(Convert.ToInt32(tidValue), usualFlag);
                    }
                    else if (curColumn == 4)//DataGridView的第5列
                    {
                        DataGridViewCheckBoxCell checkCell = this.dgvUsualTest.Rows[curRow].Cells[4] as DataGridViewCheckBoxCell;
                        Boolean usualFlag = Convert.ToBoolean(checkCell.Value);
                        this.testManger.updateTestBySUsual(Convert.ToInt32(tidValue), usualFlag);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("数据提交失败！");
            }
            finally { }
        }
    }
}
