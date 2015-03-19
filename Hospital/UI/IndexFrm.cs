//**********************************************
//
//文件名：AdminFrm.cs
//
//描  述：管理员系统菜单首页
//
//作  者：罗家辉
//
//创建时间：2014-1-15
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

namespace Hospital
{
    public partial class IndexFrm : Form
    {
        string docName = "";
        EManage rule = EManage.None;
        int oid = 0;
        public IndexFrm(string _docName, EManage _rule, int _oid)
        {
            InitializeComponent();
            docName = _docName;
            rule = _rule;
            oid = _oid;
        }

        //进入系统，打开首页介绍
        private void Index_Load(object sender, EventArgs e)
        {
            this.tsmiIndex_Click(sender, e);

            this.Text += ("    当前用户："+docName);
            OfficeManager officeManager = new OfficeManager();
            
            //加载科室
            if(oid==0)
            {
                this.Text += "    所在科室：管理中心";
            }                
            else 
            {
                try
                {
                    Office office = officeManager.GetOfficeById(oid);
                    this.Text += ("    所在科室：" + office.OName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show("科室信息加载失败！");
                }
                finally { }               
            }                
            
            /*临时这样写，以后扩充科室业务时从这里开始修改*/
            /*控制用户权限*/
            if (rule == EManage.Admin)
            {
                this.tsmiSysSet.Visible = true;
                this.tsmiHospital.Visible = true;
            }
           
            if (rule == EManage.Common) 
            {
                this.tsmiSysSet.Visible = false;
                
                if (oid == 1) 
                {
                    this.datatsmiDataAnis.Visible = true;
                    this.tsmiUserInfo.Visible = true;
                    this.tsmiHospital.Visible = false;
                }
                else
                {
                    this.datatsmiDataAnis.Visible = false;
                    this.tsmiUserInfo.Visible = false;
                    this.tsmiHospital.Visible = false;
                }
            }
        }

        //退出系统
        private void tsmiExit_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("确实要退出程序吗？", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        //患者信息管理
        private void tsmipatientInfo_Click(object sender, EventArgs e)
        {
            try
            {
                PatientFrm form = new PatientFrm(this, docName);
                ShowManager showManager = new ShowManager(this, form);
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("患者基本信息加载失败！");
            }
            finally { }
        }
        
        //医院常用量表定制
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsualTestFrm form = new UsualTestFrm();
            ShowManager showManager = new ShowManager(this, form);
            showManager.ShowForm();
            
            try
            {
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("医院常用量表加载失败！");
            }
            finally { }
        }
        
        //基本心理测试统计分析
        private void datatsmiBanDataAnis_Click(object sender, EventArgs e)
        {
            try
            {
                BaseMentalTestAnalyFrm form = new BaseMentalTestAnalyFrm(docName);
                ShowManager showManager = new ShowManager(this, form);
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("单项数据分析加载失败！");
            }
            finally { }
        }

        //高级心理测试统计分析
        private void datatsmiMoreDataAnis_Click(object sender, EventArgs e)
        {
            try
            {
                ExtendMentalTestAnalyFrm form = new ExtendMentalTestAnalyFrm(docName);
                ShowManager showManager = new ShowManager(this, form);
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("多项数据分析加载失败！");
            }
            finally { }
        }

        //基本心率变异统计分析
        private void tsmiBaseHeartRate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("心率变异统计功能未开启！");
        }

        //高级心率变异统计分析
        private void tsmiExtendHeartRate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("心率变异统计功能未开启！");
        }

        //系统设置
        private void tsmiSysSet_Click(object sender, EventArgs e)
        {
            try
            {
                SystemSetFrm form = new SystemSetFrm(this, docName);
                ShowManager showManager = new ShowManager(this, form);
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("系统设置加载失败！");
            }
            finally { }
        }

        //帮助信息
        private void tsmiHelp_Click(object sender, EventArgs e)
        {
            try
            {
                string introduction = System.Configuration.ConfigurationManager.AppSettings["introduction"];
                System.Diagnostics.Process.Start(introduction);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("找不到说明书！");
            }
            finally { }
        }

        //联系我们
        private void tsmiLinkus_Click(object sender, EventArgs e)
        {
            ContactUsFrm contactUs = new ContactUsFrm();
            contactUs.Show();
        }

        //显示软件主页
        private void tsmiIndex_Click(object sender, EventArgs e)
        {
            try
            {
                HomeFrm form = new HomeFrm(docName);
                ShowManager showManager = new ShowManager(this, form);
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("主页加载失败！");
            }
            finally { }
        }

        //托盘
        private void tIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Maximized;
            this.Activate();
        }

        //科室管理
        private void tsmiOffice_Click(object sender, EventArgs e)
        {
            try
            {
                OfficeFrm form = new OfficeFrm(docName);
                ShowManager showManager = new ShowManager(this, form);
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("科室信息加载失败！");
            }
            finally { }
        }

        //医生管理
        private void tsmiDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                DoctorFrm form = new DoctorFrm(docName);
                ShowManager showManager = new ShowManager(this, form);
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("医生信息加载失败！");
            }
            finally { }
        }

    }
}
