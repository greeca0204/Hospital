//**********************************************
//
//文件名：ExtendMentalTestAnalyFrm.cs
//
//描  述：多项数据分析界面
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
    public partial class ExtendMentalTestAnalyFrm : Form
    {
        private string docName;
        private HBarChart barChart;
        PatientDetailManager patientDetailManager = new PatientDetailManager();
        public ExtendMentalTestAnalyFrm(string _docName)
        {
            docName = _docName;
            InitializeComponent();
        }

        private void MulDateAnalysis_Load(object sender, EventArgs e)
        {

        }

        //填充患者信息数据网格中的选项框
        private void FillPatientInfoDis()
        {
            coltestGroup.DisplayMember = "Name";
            coltestGroup.ValueMember = "Id";
            coltestGroup.DataSource = Common.FillTestGroupCgy();

            colsex.DisplayMember = "Name";
            colsex.ValueMember = "Id";
            colsex.DataSource = Common.FillSexCgy();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                this.FillPatientInfoDis();

                if (chkSex.Checked && chkGroup.Checked && !chkAge.Checked)
                {
                    List<ExtendStatistics> list = patientDetailManager.GetStatisticsInfo(1,1,0);
                    this.dgvMentalTest.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                    this.dgvMentalTest.Columns["colSex"].Visible = true;
                    this.dgvMentalTest.Columns["colTestGroup"].Visible = true;
                    this.dgvMentalTest.Columns["colAge"].Visible = false;
                    this.dgvMentalTest.DataSource = list;
                }
                else if (!chkSex.Checked && chkGroup.Checked && !chkAge.Checked)
                {
                    List<ExtendStatistics> list = patientDetailManager.GetStatisticsInfo(0,1,0);
                    this.dgvMentalTest.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                    this.dgvMentalTest.Columns["colSex"].Visible = false;
                    this.dgvMentalTest.Columns["colTestGroup"].Visible = true;
                    this.dgvMentalTest.Columns["colAge"].Visible = false;
                    this.dgvMentalTest.DataSource = list;
                }
                else if (chkSex.Checked && !chkGroup.Checked && !chkAge.Checked)
                {
                    List<ExtendStatistics> list = patientDetailManager.GetStatisticsInfo(1,0,0);
                    this.dgvMentalTest.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                    this.dgvMentalTest.Columns["colSex"].Visible = true;
                    this.dgvMentalTest.Columns["colTestGroup"].Visible = false;
                    this.dgvMentalTest.Columns["colAge"].Visible = false;
                    this.dgvMentalTest.DataSource = list;
                }
                else if (!chkSex.Checked && !chkGroup.Checked && !chkAge.Checked)
                {
                    List<ExtendStatistics> list = patientDetailManager.GetStatisticsInfo(0,0,0);
                    this.dgvMentalTest.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                    this.dgvMentalTest.Columns["colSex"].Visible = false;
                    this.dgvMentalTest.Columns["colTestGroup"].Visible = false;
                    this.dgvMentalTest.Columns["colAge"].Visible = false;
                    this.dgvMentalTest.DataSource = list;
                }
                else if (chkSex.Checked && chkGroup.Checked && chkAge.Checked)
                {
                    List<ExtendStatistics> list = patientDetailManager.GetStatisticsInfo(1, 1, 1);
                    this.dgvMentalTest.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                    this.dgvMentalTest.Columns["colSex"].Visible = true;
                    this.dgvMentalTest.Columns["colTestGroup"].Visible = true;
                    this.dgvMentalTest.Columns["colAge"].Visible = true;
                    this.dgvMentalTest.DataSource = list;
                }
                else if (!chkSex.Checked && chkGroup.Checked && chkAge.Checked)
                {
                    List<ExtendStatistics> list = patientDetailManager.GetStatisticsInfo(0, 1, 1);
                    this.dgvMentalTest.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                    this.dgvMentalTest.Columns["colSex"].Visible = false;
                    this.dgvMentalTest.Columns["colTestGroup"].Visible = true;
                    this.dgvMentalTest.Columns["colAge"].Visible = true;
                    this.dgvMentalTest.DataSource = list;
                }
                else if (chkSex.Checked && !chkGroup.Checked && chkAge.Checked)
                {
                    List<ExtendStatistics> list = patientDetailManager.GetStatisticsInfo(1, 0, 1);
                    this.dgvMentalTest.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                    this.dgvMentalTest.Columns["colSex"].Visible = true;
                    this.dgvMentalTest.Columns["colTestGroup"].Visible = false;
                    this.dgvMentalTest.Columns["colAge"].Visible = true;
                    this.dgvMentalTest.DataSource = list;
                }
                else if (!chkSex.Checked && !chkGroup.Checked && chkAge.Checked)
                {
                    List<ExtendStatistics> list = patientDetailManager.GetStatisticsInfo(0, 0, 1);
                    this.dgvMentalTest.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                    this.dgvMentalTest.Columns["colSex"].Visible = false;
                    this.dgvMentalTest.Columns["colTestGroup"].Visible = false;
                    this.dgvMentalTest.Columns["colAge"].Visible = true;
                    this.dgvMentalTest.DataSource = list;
                }
                else
                {
                    MessageBox.Show("选项出错！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("病历信息加载失败！");
            }
            finally { }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportExcel exportExcel = new ExportExcel();
            exportExcel.exportExcel(dgvMentalTest);
        }

        private void dgvMentalTest_Click(object sender, EventArgs e)
        {
            this.dgvMentalTest.Rows[this.dgvMentalTest.CurrentCell.RowIndex].Selected = true;
            this.panel3.Controls.Remove(barChart);
            string tName = ((ExtendStatistics)dgvMentalTest.CurrentRow.DataBoundItem).TName;
            int count = ((ExtendStatistics)dgvMentalTest.CurrentRow.DataBoundItem).Cnt;
            double max = ((ExtendStatistics)dgvMentalTest.CurrentRow.DataBoundItem).Maxv;
            double min = ((ExtendStatistics)dgvMentalTest.CurrentRow.DataBoundItem).Minv;
            double avg = ((ExtendStatistics)dgvMentalTest.CurrentRow.DataBoundItem).Avgv;

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
