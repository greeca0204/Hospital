//**********************************************
//
//文件名：OfficeFrm.cs
//
//描  述：科室信息管理页面
//
//作  者：罗家辉
//
//创建时间：2014-1-16
//
//修改历史：2014-8-10  罗家辉 修改
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
    public partial class OfficeFrm : Form
    {
        private string docName;
        PatientDetailManager patientDetailManager = new PatientDetailManager();
        OfficeManager officeManager = new OfficeManager();

        //构造函数
        public OfficeFrm(string _docName)
        {
            docName = _docName;
            InitializeComponent();
        }

        //初始化
        private void OfficeFrm_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        //修改科室
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {                
                int oid = ((Office)this.dgvOffice.CurrentRow.DataBoundItem).OId;
                Office office = new Office(oid,this.txtOffice.Text.Trim(), 1);
                int rs = officeManager.UpdateOffice(office);
                if (rs != 0)
                {
                    MessageBox.Show("修改成功！");
                    RefreshData();//修改成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("修改失败！数据库异常！");
            }
            finally { }
        }

        //添加科室
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Office office = new Office(this.txtOffice.Text.Trim(), 1);
                int rs = officeManager.InsertOffice(office);
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
     
        //选择数据
        private void dgvOffice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvOffice.Rows[this.dgvOffice.CurrentCell.RowIndex].Selected = true;//点击时选中整行 
            this.txtOffice.Text = ((Office)this.dgvOffice.CurrentRow.DataBoundItem).OName;
        }

        //刷新表格
        private void RefreshData()
        {
            try
            {
                List<Office> list = officeManager.GetAllOffice();
                this.dgvOffice.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                this.dgvOffice.DataSource = list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("科室信息加载失败！");
            }
            finally { }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                int oid = ((Office)this.dgvOffice.CurrentRow.DataBoundItem).OId;
                int rs = 0;
                if (oid != 4)
                {
                    rs = officeManager.DeleteOffice(oid);
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
                else
                {
                    MessageBox.Show("不能删除管理中心！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("删除失败！数据库异常！");
            }
            finally { }
        }
    
        
    }
}
