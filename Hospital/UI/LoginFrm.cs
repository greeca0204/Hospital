//**********************************************
//
//文件名：LoginFrm.cs
//
//描  述：医护人员登录界面
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
using System.Text;
using System.Windows.Forms;

namespace Hospital
{
    public partial class LoginFrm : Form
    {
        //构造函数
        public LoginFrm()
        {
            
            InitializeComponent();
        }
       
        //点击登录按钮
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Login();       
        }

        //光标在用户框中键盘按下回车
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Login();
            }
        }

        //光标在密码框中键盘按下回车
        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Login();
            }
        }

        //光标在登录按钮中键盘按下回车
        private void btn_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Login();
            }
        }

        //登录方法
        public void Login()
        {
            //this.txtUserName.Text = "admin";
            //this.txtPassWord.Text = "123456";
            if (this.txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("用户名不能为空！");
                this.txtUserName.Focus();
            }
            else if (this.txtPassWord.Text.Trim() == "")
            {
                MessageBox.Show("密码不能为空！");
                this.txtPassWord.Focus();
            }
            else
            {
                try
                {
                    LoginManager loginManager = new LoginManager();//加载医生基本信息
                    Doctor doctor = loginManager.GeDoctor(this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim());
                    Common.CurrentDoctor = doctor;

                    if (doctor != null)
                    {
                        if (doctor.Rule == EManage.Freeze)
                        {
                            MessageBox.Show("该医生账号已被冻结！");
                            this.txtUserName.Clear();
                            this.txtPassWord.Clear();
                            this.txtUserName.Focus();
                        }
                        else
                        {
                            IndexFrm form = new IndexFrm(this.txtUserName.Text.Trim(), doctor.Rule, doctor.Oid);
                            form.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码不正确，请重新输入！");
                        this.txtUserName.Clear();
                        this.txtPassWord.Clear();
                        this.txtUserName.Focus();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show("数据库连接失败！");
                }
                finally { }
            }
        }
    }
}