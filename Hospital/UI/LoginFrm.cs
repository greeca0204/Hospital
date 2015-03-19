//**********************************************
//
//�ļ�����LoginFrm.cs
//
//��  ����ҽ����Ա��¼����
//
//��  �ߣ��޼һ�
//
//����ʱ�䣺2014-1-15
//
//�޸���ʷ��2014-8-10  �޼һ� �޸�
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
        //���캯��
        public LoginFrm()
        {
            
            InitializeComponent();
        }
       
        //�����¼��ť
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Login();       
        }

        //������û����м��̰��»س�
        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Login();
            }
        }

        //�����������м��̰��»س�
        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Login();
            }
        }

        //����ڵ�¼��ť�м��̰��»س�
        private void btn_Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Login();
            }
        }

        //��¼����
        public void Login()
        {
            //this.txtUserName.Text = "admin";
            //this.txtPassWord.Text = "123456";
            if (this.txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("�û�������Ϊ�գ�");
                this.txtUserName.Focus();
            }
            else if (this.txtPassWord.Text.Trim() == "")
            {
                MessageBox.Show("���벻��Ϊ�գ�");
                this.txtPassWord.Focus();
            }
            else
            {
                try
                {
                    LoginManager loginManager = new LoginManager();//����ҽ��������Ϣ
                    Doctor doctor = loginManager.GeDoctor(this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim());
                    Common.CurrentDoctor = doctor;

                    if (doctor != null)
                    {
                        if (doctor.Rule == EManage.Freeze)
                        {
                            MessageBox.Show("��ҽ���˺��ѱ����ᣡ");
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
                        MessageBox.Show("�û��������벻��ȷ�����������룡");
                        this.txtUserName.Clear();
                        this.txtPassWord.Clear();
                        this.txtUserName.Focus();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show("���ݿ�����ʧ�ܣ�");
                }
                finally { }
            }
        }
    }
}