//**********************************************
//
//文件名：MentalTestFrm.cs
//
//描  述：项目测试页面
//
//作  者：罗家辉
//
//创建时间：2014-1-16
//
//修改历史：2014-7-4  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hospital;
using System.Xml;
using System.Collections;

namespace Hospital
{
    public partial class MentalTestFrm : Form
    {
        private string docName="";
        PatientInfoManager piMan = new PatientInfoManager();
        PatientDetailManager pdMan = new PatientDetailManager();
        QuestionManager qMan = new QuestionManager();
        OptionManager oMan = new OptionManager();

        Dictionary<char, Options> oDic = null;
        Dictionary<int, Questions> qDic = null;
        Dictionary<int, string> adic = new Dictionary<int, string>();
        MetalTestTreeCreate metalTestTreeCreate = new MetalTestTreeCreate();
        RadioButton[] rb = null;
        Dictionary<int ,int> rbDic = null;

        IndexFrm indexFrm;
        int uid = 0;
        int number = 0;
        char option;

        int next = 1;       
        int questionCount = 0;

        public MentalTestFrm(IndexFrm _indexFrm, int _uid)
        {           
            InitializeComponent();
            uid = _uid;
            indexFrm = _indexFrm;
            rbDic = new Dictionary<int,int>();
        }

        private void PsychologyTestFrm_Load(object sender, EventArgs e)
        {
            /*获取患者基本信息*/
            PatientInfo patientInfo = piMan.GetPatientInfoById(uid);
            int sex = Convert.ToInt32(patientInfo.Sex);
            int testgroup = patientInfo.TestGroup;

            lblUserName.Text = "患者姓名:" + patientInfo.UserName.ToString();//姓名
            lblAge.Text = "年龄：" + patientInfo.Age.ToString() + "岁";//年龄

            //性别
            if (sex == 0)
            {
                lblSex.Text = "性别：女";
            }
            else if (sex == 1)
            {
                lblSex.Text = "性别：男";
            }
            else
            {
                lblSex.Text = "性别：未知";
            }

            //分组
            TestGroupManager testGroupManager = new TestGroupManager();
            TestGroup testGroup = testGroupManager.GetTestGroupBygid(testgroup);
            if (testGroup==null)
            {
                lblGroup.Text = "测试分组：未知";
            }
            else
            {
                lblGroup.Text = "测试分组：" + testGroup.GName;
            }

            if (patientInfo.Tel.ToString() == "")
            {
                lblTel.Text = "电话：未知"; //电话
            }
            else
            {
                lblTel.Text = "电话：" + patientInfo.Tel.ToString();//电话
            }

            //metalTestTreeCreate.CreateTree(this.treeView1);
            metalTestTreeCreate.CreateTree4(this.treeView1);
            metalTestTreeCreate.CreateTree2(this.treeView1);
            metalTestTreeCreate.CreateTree3(this.treeView1);
            btnBack.Enabled = false;
            btnNext.Enabled = false;
            btnSubmit.Enabled = false;
        }
  
        //双击树形目录
        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                tbTestQuestion.Text = "";
                flowLayoutPanel.Controls.Clear();
                TreeNode node = treeView1.SelectedNode;
                int tid = Convert.ToInt32(node.Name);
                /*获取第一条问题*/
                qDic = qMan.GetQuestion(tid);

                if (qDic == null)
                {
                    MessageBox.Show("该量表没有内容！");
                }
                else
                {
                    next = 1;
                    rbDic = new Dictionary<int, int>();
                    TestCreate(next);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("量表加载失败，可能是题目或者题目选项不完整所导致的！");
            }
            finally { }
        }

        // 上一题按钮实现
        private void btnBack_Click(object sender, EventArgs e)
        {
            next--;
            TestCreate(next);
            if(rbDic.ContainsKey(next))
            rb[Convert.ToInt32(rbDic[next])].Checked = true;
        }

        // 下一题按钮实现
        private void btnNext_Click(object sender, EventArgs e)
        {
            next++;
            TestCreate(next);
            if (rbDic.ContainsKey(next))
                 rb[Convert.ToInt32(rbDic[next])].Checked = true;
        }

        //提交按钮
        private void btnSubmit_Click(object sender, EventArgs e)
        {             
            TreeNode node = treeView1.SelectedNode;
            int tid = Convert.ToInt32(node.Name);
            int cnt = qMan.CountAccount(tid);

            pdMan.TotalPoints(uid, tid, cnt, adic);
            /*结果查询*/
            MentalTestReportFrm form = new MentalTestReportFrm(indexFrm, uid);
            ShowManager showManager = new ShowManager(indexFrm, form);
            showManager.ShowForm();
        }

        
        //返回患者信息界面
        private void btnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                PatientFrm form = new PatientFrm(indexFrm, docName);
                ShowManager showManager = new ShowManager(indexFrm, form);//返回患者基本信息页面
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("患者基本信息加载失败！");
            }
            finally { }
        }

        //生成量表
        public void TestCreate(int next)
        {
            TreeNode node = treeView1.SelectedNode;
            int tid = Convert.ToInt32(node.Name);
            int cnt = qMan.CountAccount(tid);
            if (next == 1)
            {
                btnBack.Enabled = false;
                btnNext.Enabled = true;
            }
            else if (next > cnt)
            {
                btnBack.Enabled = true;
                btnNext.Enabled = false;
                int flag=0;
                for (int i = 1; i <= cnt; i++)
                {
                   
                        if (adic[i] == "")
                        {
                            flag = 1;
                        }    
                }

                if (flag == 0)
                {
                    this.btnSubmit.Enabled = true;
                }
                else
                {
                    this.btnSubmit.Enabled = false;
                }
            }
            else
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
            }

            if (qDic.ContainsKey(next))
            {
                tbTestQuestion.Text = qDic[next].NId + "、" + qDic[next].Question;
                tbTestQuestion.Font = new Font(tbTestQuestion.Font.FontFamily, 20, tbTestQuestion.Font.Style);
                flowLayoutPanel.Controls.Clear();
                oDic = oMan.GetOptions(qDic[next].QId);
                number = oMan.CountAccount(qDic[next].QId);
                rb = new RadioButton[number];
                for (int i = 0; i < number; i++)
                {
                    option = Convert.ToChar(64 + i + 1);

                    RadioButton temcheck = new RadioButton();
                    rb[i] = temcheck;
                    rb[i].Size = new System.Drawing.Size(1500, 30);
                    rb[i].Font = new Font(rb[i].Font.FontFamily, 14, rb[i].Font.Style);
                    rb[i].Text = oDic[option].Option.ToString() + "." + oDic[option].Title.ToString();

                    if (!(next == questionCount))
                    {
                        rb[i].Click += new EventHandler(jmp_Click);
                    }

                    flowLayoutPanel.Controls.Add(rb[i]);

                }
            }           
        }

        //跳到下一题
        private void jmp_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            int tid = Convert.ToInt32(node.Name);
            string str  = ((RadioButton)sender).Text.ToString().Substring(0, 1);
            string rbText = ((RadioButton)sender).Text.ToString().Trim();
            for (int i = 0; i < number; i++)//获取按钮下标
            {

                if (rb[i] != null && rb[i].Text.Trim() == rbText)
                    rbDic.Remove(next);
                if (!rbDic.ContainsKey(next))
                    rbDic.Add(next,i);
            }
            if (adic == null)
            {
                adic.Add(next, str);
            }
            else
            {
                adic.Remove(next);
                if (!adic.ContainsKey(next))
                    adic.Add(next, str);
            }
            this.btnNext_Click(sender, e);//跳到下一题
        }

        private void addUsualTest_Click(object sender, EventArgs e)
        {
            
        }
    }
}
