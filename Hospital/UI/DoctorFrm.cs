//**********************************************
//
//文件名：BaseMentalTestAnalyFrm.cs
//
//描  述：基本心理测试统计分析页面
//
//作  者：罗家辉
//
//创建时间：2014-1-16
//
//修改历史：2014-7-13  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace Hospital
{
    public partial class DoctorFrm : Form
    {
        private string docName;
        PatientDetailManager patientDetailManager = new PatientDetailManager();
        LoginManager loginManager = new LoginManager();

        //构造函数
        public DoctorFrm(string _docName)
        {
            docName = _docName;
            InitializeComponent();
        }


        private void SingleDateAnalysisFrm_Load(object sender, EventArgs e)
        {
            RefreshData();//添加成功后，刷新表格。
        }

        private void dgvDoctor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvDoctor.Rows[this.dgvDoctor.CurrentCell.RowIndex].Selected = true;//点击时选中整行 
            this.txtDoctor.Text = ((Doctor)this.dgvDoctor.CurrentRow.DataBoundItem).UserName;
            //this.txtPassword.Text = ((Doctor)this.dgvDoctor.CurrentRow.DataBoundItem).PassWord;
            this.cmbRule.SelectedValue = ((Doctor)this.dgvDoctor.CurrentRow.DataBoundItem).Rule;
            this.cmbOid.SelectedValue = ((Doctor)this.dgvDoctor.CurrentRow.DataBoundItem).Oid;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Doctor doctor = new Doctor(this.txtDoctor.Text.Trim(), this.txtPassword.Text.Trim(), (EManage)this.cmbRule.SelectedValue, (int)this.cmbOid.SelectedValue);
                int rs = loginManager.InsertDoctorInfo(doctor);
                if (rs != 0)
                {
                    MessageBox.Show("添加成功！");
                    RefreshData();//添加成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("添加失败！数据库异常！");
            }
            finally { }
        }  

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int rs = 0;
                int id = ((Doctor)this.dgvDoctor.CurrentRow.DataBoundItem).Id;
                Doctor doctor = new Doctor(id, this.txtDoctor.Text.Trim(), this.txtPassword.Text.Trim(), (EManage)this.cmbRule.SelectedValue, (int)this.cmbOid.SelectedValue);
                if (chkPassword.Checked)
                {
                    rs = loginManager.UpdateDoctorInfo(doctor);
                }
                else
                {
                    rs = loginManager.UpdateDoctorInfoExceptPsw(doctor);
                }
                if (rs != 0)
                {
                    MessageBox.Show("修改成功！");
                    RefreshData();//添加成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("添加失败！数据库异常！");
            }
            finally { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = ((Doctor)this.dgvDoctor.CurrentRow.DataBoundItem).Id;
                int rs = 0;
                if (id != 1){
                    rs = loginManager.DeleteDoctorInfo(id);
                    if (rs != 0)
                    {
                        MessageBox.Show("删除成功！");
                        RefreshData();//修改成功后，刷新表格。
                    }
                    else
                    {
                        MessageBox.Show("删除失败！");
                    }
                }        
                else{
                    MessageBox.Show("不能删除管理员账号！");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("删除失败！数据库异常！");
            }
            finally { }
        }

        public void RefreshData()
        {
            this.txtDoctor.Text = "";
            this.txtPassword.Text = "";

            try
            {
                List<Doctor> list = loginManager.GetAllDoctor();
                this.FillManageCgy();
                this.FillOfficeCgy();
                this.dgvDoctor.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                this.dgvDoctor.DataSource = list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("病历信息加载失败！");
            }
            finally { }
        }

        //
        private void FillOfficeCgy()
        {
            coloid.DisplayMember = "Name";
            coloid.ValueMember = "Id";
            coloid.DataSource = Common.FillOfficeCgy();

            cmbOid.DisplayMember = "Name";
            cmbOid.ValueMember = "Id";
            cmbOid.DataSource = Common.FillOfficeCgy();
        }

        private void FillManageCgy()
        {
            colRule.DisplayMember = "Name";
            colRule.ValueMember = "Id";
            colRule.DataSource = Common.FillManageCgy();

            cmbRule.DisplayMember = "Name";
            cmbRule.ValueMember = "Id";
            cmbRule.DataSource = Common.FillManageCgy();
        }
    }
}
