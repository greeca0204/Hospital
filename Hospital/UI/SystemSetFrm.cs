//**********************************************
//
//文件名：SystemSetFrm.cs
//
//描  述：系统设置界面
//
//作  者：罗家辉
//
//创建时间：2014-1-16
//
//修改历史：2014-7-3  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hospital
{
    public partial class SystemSetFrm : Form
    {
        private string docName;
        HospitalManager hospitalManager = new HospitalManager();
        Hospital hospital = null; 
        string programPath = Application.StartupPath;//图片相对路径      
        string[] words = null;  //图片名称
        string pictruePath = null; //图片文件路径的字符串
        IndexFrm indexFrm;

        public SystemSetFrm(IndexFrm indexFrms,string _docName)
        {
            indexFrm = indexFrms;
			this.docName = _docName;
            InitializeComponent();         
        }

        //页面最初时候的状态
        private void SystemSetFrm_Load(object sender, EventArgs e)
        {
            try
            {
                hospital = hospitalManager.GetHospitalInfo();
                this.txtHospitalName.Text = hospital.CName.ToString();
                this.txtHospitalIntroduction.Text = hospital.CIntro.ToString();
                this.pictruePath = programPath + "\\" + hospital.CLogo.ToString();
                this.txtSignPath.Text = this.pictruePath;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("医院基本信息加载失败！");
            }
            finally { }
        }

        //点击保存按钮
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.words = pictruePath.Split('\\');
                hospital = new Hospital(1, this.txtHospitalName.Text.Trim(), this.txtHospitalIntroduction.Text.Trim(), this.words[this.words.Length - 1]);
                int rs = hospitalManager.UpdateHospitalInfo(hospital);

                if (rs != 0)
                {
                    MessageBox.Show("修改成功！");
                    this.Close();
                    HomeFrm form = new HomeFrm(docName);
                    ShowManager showManager = new ShowManager(indexFrm, form);
                    showManager.ShowForm();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("修改失败！数据库连接异常！");
            }
            finally { }
        }

        //点击浏览按钮
        private void btnViewPictrue_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            txtSignPath.Text = openFileDialog.FileName;
            this.pictruePath = openFileDialog.FileName;
            try
            {
                if (!File.Exists(Path.Combine(programPath, openFileDialog.SafeFileName)))
                {
                    File.Copy(openFileDialog.FileName, Path.Combine(programPath, openFileDialog.SafeFileName), false);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("浏览失败！");
            }
            finally { }
        }
    }
}
