//**********************************************
//
//文件名：SingleDateAnalysisFrm.cs
//
//描  述：单项数据分析界面
//
//作  者：罗家辉
//
//创建时间：2014-1-16
//
//修改历史：2014-1-16 罗家辉 创建
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
    public partial class MentalTestAnalyByPatFrm : Form
    {
        private string docName="";
        PatientDetailManager patientDetailManager = new PatientDetailManager();
        PatientInfoManager piMan = new PatientInfoManager();
        private HBarChart barChart;

        IndexFrm indexFrm;
        int uid = 0;

        public MentalTestAnalyByPatFrm(IndexFrm _indexFrm, int _uid)
        {
            InitializeComponent();
            uid = _uid;
            indexFrm = _indexFrm;
        }

        private void SingleDateAnalysisFrm_Load(object sender, EventArgs e)
        {

            /*获取患者基本信息*/
            if (uid != 0)
            {
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

                try
                {
                    List<Statistics> list = patientDetailManager.GetStatisticsInfoByUid(uid);
                    this.dgvMentalTest.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                    this.dgvMentalTest.DataSource = list;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show("病历信息加载失败！");
                }
                finally { }   
            }
            else
            {
                MessageBox.Show("未选择病人！");
            }         
        }

        private void btnPerviewPrint_Click(object sender, EventArgs e)
        {
            
        }

        private void expExcel_Click(object sender, EventArgs e)
        {
            ExportExcel exportExcel = new ExportExcel();
            exportExcel.exportExcel(dgvMentalTest);
        }

        private void btnBack_Click(object sender, EventArgs e)
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

        private void dgvMentalTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvMentalTest.Rows[this.dgvMentalTest.CurrentCell.RowIndex].Selected = true;
            this.panel3.Controls.Remove(barChart);
            string tName = ((Statistics)dgvMentalTest.CurrentRow.DataBoundItem).TName;
            int count = ((Statistics)dgvMentalTest.CurrentRow.DataBoundItem).Count;
            double max = ((Statistics)dgvMentalTest.CurrentRow.DataBoundItem).Max;
            double min = ((Statistics)dgvMentalTest.CurrentRow.DataBoundItem).Min;
            double avg = ((Statistics)dgvMentalTest.CurrentRow.DataBoundItem).Avg;

            barChart = new HBarChart();
            this.panel3.Controls.Add(barChart);
            barChart.Dock = DockStyle.Fill;

            barChart.Border.Width = 10;
            barChart.Shadow.Mode = CShadowProperty.Modes.Both;
            barChart.Shadow.WidthInner = 1;
            barChart.Shadow.WidthOuter = 4;
            barChart.Shadow.ColorOuter = Color.FromArgb(100, 0, 0, 0);

            barChart.Description.Text = tName + "量表数据统计";


            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("测试总数", typeof(System.Int32));
            dt.Columns.Add("最大值", typeof(System.Double));
            dt.Columns.Add("最小值", typeof(System.Double));
            dt.Columns.Add("平均值", typeof(System.Double));

            dr = dt.NewRow();

            dr[0] = count;
            dr[1] = max;
            dr[2] = min;
            dr[3] = avg;

            dt.Rows.Add(dr);

            this.barChart.DataSource = dt; 
        }
    }
}
