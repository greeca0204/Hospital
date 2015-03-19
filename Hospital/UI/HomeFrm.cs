//**********************************************
//
//文件名：HomeFrm.cs
//
//描  述：首页界面
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
    public partial class HomeFrm : Form
    {
        private string docName;//记录登录医生姓名        

        //构造函数
        public HomeFrm(string _docName)
        {
            docName = _docName;
            InitializeComponent();
        }

        //初始化加载
        private void HomeFrm_Load(object sender, EventArgs e)
        {
            try
            {
                HospitalManager hospitalManager = new HospitalManager();//加载医院基本信息
                Hospital hospital = hospitalManager.GetHospitalInfo();
                this.lblUserName.Text = docName + ",欢迎你!" ;
                this.lblCName.Text = hospital.CName;
                this.lblIntro.Text = hospital.CIntro;
                this.picBox.ImageLocation = Convert.ToString(hospital.CLogo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("医院基本信息或医生基本信息加载失败！");
            }
            finally { }
        }

    }
}