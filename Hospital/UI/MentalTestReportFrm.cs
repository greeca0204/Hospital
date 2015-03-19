//**********************************************
//
//文件名：MentalTestReportFrm.cs
//
//描  述：心理测试报告结果界面
//
//作  者：罗家辉
//
//创建时间：2014-1-16
//
//修改历史：2014-7-13 罗家辉 创建
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
using Word = Microsoft.Office.Interop.Word;

namespace Hospital
{
    public partial class MentalTestReportFrm : Form
    {
        private string docName="";
        PatientInfoManager patientInfoManager = new PatientInfoManager();
        HospitalManager hospitalManager = new HospitalManager();
        PatientDetailManager patientDetailManager = new PatientDetailManager();
        AcountManager acountManager = new AcountManager();
        TestGroupManager testGroupManager = new TestGroupManager();
        IndexFrm indexFrm;
        int uid = 0;
        string strSex = "";

        public MentalTestReportFrm(IndexFrm _indexFrm, int _uid)
        {
            InitializeComponent();
            uid = _uid;
            indexFrm = _indexFrm; 
        }

        private void TestReportFrm_Load(object sender, EventArgs e)
        {
            /*获取患者基本信息*/
            PatientInfo patientInfo = patientInfoManager.GetPatientInfoById(uid);
            int sex = Convert.ToInt32(patientInfo.Sex);
            int testgroup = patientInfo.TestGroup;

            lblUserName.Text = "患者姓名:" + patientInfo.UserName.ToString();//姓名
            lblAge.Text = "年龄：" + patientInfo.Age.ToString() + "岁";//年龄

            //性别
            if (sex == 0)
            {
                lblSex.Text = "性别：女";
                strSex = "女";
            }
            else if (sex == 1)
            {
                lblSex.Text = "性别：男";
                strSex = "男";
            }
            else
            {
                lblSex.Text = "性别：未知";
            }

            //分组
            TestGroupManager testGroupManager = new TestGroupManager();
            TestGroup testGroup = testGroupManager.GetTestGroupBygid(testgroup);
            if (testGroup == null)
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

            this.LoadMentalTestResult(uid);
        }

        //加载心理测试信息
        public void LoadMentalTestResult(int uid)
        {
            try
            {
                List<PatientItem> list = patientDetailManager.GetPatientItemByUid(uid);
                this.dgvMentalTestResult.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                this.dgvMentalTestResult.DataSource = list;
                this.txtAdvice.Text = "";
                this.txtMentalTestResult.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("病历信息加载失败！");
            }
        }

        //选中患者心理测试结果
        private void dgvMentalTestResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvMentalTestResult.Rows[this.dgvMentalTestResult.CurrentCell.RowIndex].Selected = true;//点击时选中整行

                int tid = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Tid;
                double score = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Score;
                string advice = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Advice;
                string name = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).TNameItem;
                List<Acount> list = acountManager.ChoiceAccount(tid,score,strSex, name);
                string str = "";
                for (int i = 0; i < list.Count; i++)
                {
                    str += (list[i].Name + "：" + list[i].Explain + "\r\n");
                }
                this.txtMentalTestResult.Text = str;
                this.txtAdvice.Text = advice;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("心理测试结果加载失败！");
            }
            finally { }
        }
        
        //添加医生意见
        private void btnDoctAdvice_Click(object sender, EventArgs e)
        {
            try
            {
                int udid = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Udid;//获取选中行的Id信息
                string advice = this.txtAdvice.Text.Trim();
                int rs = patientDetailManager.UpdateAdvice(udid, advice);
                if (rs != 0)
                {
                    MessageBox.Show("诊断意见添加成功！");
                    LoadMentalTestResult(uid);//修改成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("诊断意见添加失败！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("添加失败！数据库异常！");
            }
            finally { }
        }

        //添加测试
        private void btnPsyTest_Click(object sender, EventArgs e)
        {
            try
            {
                MentalTestFrm form = new MentalTestFrm(indexFrm, uid);
                ShowManager showManager = new ShowManager(indexFrm, form);
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("心理测试页面加载失败！");
            }
            finally { }
        }

        //删除测试结果
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvMentalTestResult.Rows[this.dgvMentalTestResult.CurrentCell.RowIndex].Selected = true;//点击时选中整行
                int udid = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Udid;//获取选中行的Id信息
                int rs = patientDetailManager.DeletePatientDetail(udid);
                if (rs != 0)
                {
                    MessageBox.Show("删除成功！");
                    LoadMentalTestResult(uid);//修改成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                this.txtMentalTestResult.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("删除失败！数据库异常！");
            }
            finally { }
        }

        //个人心理测试病历统计
        private void btnTestMentalSta_Click(object sender, EventArgs e)
        {
            try
            {
                MentalTestAnalyByPatFrm form = new MentalTestAnalyByPatFrm(indexFrm, uid);
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

        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int udid = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Udid;

            PatientInfo patientInfo = patientInfoManager.GetPatientInfoById(this.uid);
            PatientItem patientItem = patientDetailManager.GetPatientItemByUdid(udid);
            Hospital hospital = hospitalManager.GetHospitalInfo();
            TestGroup testGroup = testGroupManager.GetTestGroupBygid(patientInfo.TestGroup);

            int intSex = Convert.ToInt32(patientInfo.Sex);
            string strSex = "";
            if (intSex == 1)
            {
                strSex = "男";
            }
            else
            {
                strSex = "女";
            }

            string FileName = "";

            try
            {
                FileName = System.Configuration.ConfigurationManager.AppSettings["printMentalTest"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("没有配置病历存放的目录位置！");
            }
            finally { }

            FileName += DateTime.Now.ToString("yyyy-MM-dd") + patientInfo.UserName + "病历.doc";

            try
            {
                Word.ApplicationClass MyWord = new Word.ApplicationClass();
                Word._Document MyDoc;
                Object Nothing = System.Reflection.Missing.Value;
                MyDoc = MyWord.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

                //页头
                MyWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;
                MyWord.Selection.WholeStory();
                MyWord.Selection.TypeText(hospital.CName + "心理测试管理系统");
                MyWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;

                //页面设置，设置页面为纵向布局，设置纸张类型为A4纸
                MyDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                MyDoc.PageSetup.PageWidth = MyWord.CentimetersToPoints(21F);
                MyDoc.PageSetup.PageHeight = MyWord.CentimetersToPoints(29.7F);

                //标题
                MyWord.Application.Selection.Font.Size = 16;//字号
                MyWord.Selection.ParagraphFormat.LineSpacing = 15f;//设置文档的行间距
                MyWord.Selection.Font.Bold = (int)Word.WdConstants.wdToggle; // 黑体
                MyWord.Application.Selection.TypeText(hospital.CName + "心理测试与心率变异检测报告");
                MyWord.Application.Selection.TypeParagraph();

                //病历内容
                Word.Paragraph oPara1;
                oPara1 = MyDoc.Content.Paragraphs.Add(ref Nothing);
                oPara1.Range.Font.Size = 12;
                oPara1.Range.Font.Bold = 0;
                oPara1.Format.SpaceAfter = 10;    //24 pt spacing after paragraph.
                oPara1.Range.InsertParagraphAfter();

                oPara1.Range.Text = "医院：" + hospital.CName;
                oPara1.Range.Text += "打印日期：" + DateTime.Now.ToString("yyyy-MM-dd") + "\t\t科别：精神科\t\t门诊号：" + patientInfo.ONum + "\t\t住院号：" + patientInfo.AD;
                oPara1.Range.Text += "姓名：" + patientInfo.UserName;
                oPara1.Range.Text += "医保卡号：" + patientInfo.HospiNum + "\t\t测试组别：" + testGroup.GName;
                oPara1.Range.Text += "性别：" + strSex + "\t\t出生日期：" + patientInfo.Brithday.ToString("yyyy-MM-dd") + "\t\t年龄：" + patientInfo.Age + "\t\t电话号码：" + patientInfo.Tel;
                oPara1.Range.Text += "家庭地址：" + patientInfo.Address;

                oPara1.Range.Text += "初步诊断：";

                oPara1.Range.Text += "心理测试：" + patientItem.TName;
                oPara1.Range.Text += "诊断结果：";
                oPara1.Range.Text += "\t" + this.txtMentalTestResult.Text + "\t";

                oPara1.Range.Text += "医生建议：";
                oPara1.Range.Text += "\t" + patientItem.Advice;

                oPara1.Range.Text += "医生：罗家辉";
                object MyFileName = FileName;

                //将WordDoc文档对象的内容保存为DOC文档 
                MyDoc.SaveAs(ref MyFileName, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
                MyDoc.Close(ref Nothing, ref Nothing, ref Nothing);//关闭WordDoc文档对象 
                MyWord.Quit(ref Nothing, ref Nothing, ref Nothing);//关闭WordApp组件对象                
                System.Diagnostics.Process.Start(FileName);//打开病历
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("病历打印失败！");
            }
            finally { }
        }

        //返回患者基本信息页面
        private void button1_Click(object sender, EventArgs e)
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

    }
}
