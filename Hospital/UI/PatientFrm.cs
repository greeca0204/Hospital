//**********************************************
//
//文件名：PatientFrm.cs
//
//描  述：患者基本信息界面
//
//作  者：罗家辉
//
//创建时间：2014-1-15
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
using Word = Microsoft.Office.Interop.Word;

namespace Hospital
{
    public partial class PatientFrm : Form
    {
        private int uid;    //全局的患者id
        private string docName;
        HospitalManager hospitalManager = new HospitalManager();
        HeartRateManager heartRateManager = new HeartRateManager(); //获取心率变异数据操作对象
        PatientInfoManager patientInfoManager = new PatientInfoManager();   //获取病人信息数据操作对象
        TestGroupManager testGroupManager = new TestGroupManager();
        PatientDetailManager patientDetailManager = new PatientDetailManager();
        AcountManager acountManager = new AcountManager();

        IndexFrm indexFrm;
        string strSex = "";

        public PatientFrm(IndexFrm indexFrms,string _docName)
        {
            this.docName = _docName;
			indexFrm = indexFrms;
            InitializeComponent();          
        }

        //页面最初时候的状态
        private void User_Load(object sender, EventArgs e)
        {
            RefreshPatientInfoData();
            this.cmbQSex.SelectedIndex = 0;
            this.cmbQGroup.SelectedIndex = 0;      
        }

        //查询患者基本信息
        private void btnQuery_Click(object sender, EventArgs e)
        {
            string bAge = this.txtQBAge.Text.Trim();
            string eAge = this.txtQEAge.Text.Trim();
            if (bAge != "" && eAge == "")
            {
                MessageBox.Show("使用年龄进行查询时，请输入起始年龄！");
            }
            else if(bAge == "" && eAge != "")
            {
                MessageBox.Show("使用年龄进行查询时，请输入终止年龄！");
            }
            else if((bAge != "" && eAge != "")&&(!IsNum(bAge) && IsNum(eAge)))
            {
                MessageBox.Show("起始年龄应该为整数！");
            }
            else if((bAge != "" && eAge != "")&&(IsNum(bAge) && !IsNum(eAge)))
            {
                MessageBox.Show("终止年龄应该为整数！");
            }
            else if((bAge != "" && eAge != "")&&(!IsNum(bAge) && !IsNum(eAge)))
            {
                MessageBox.Show("起始年龄和终止年龄应该为整数！");
            }
            else if ((bAge != "" && eAge != "") && (IsNum(bAge) && IsNum(eAge)) && (Convert.ToInt32(bAge)>Convert.ToInt32(eAge)))
            {
                MessageBox.Show("起始年龄不能大于终止年龄！");
            }
            else
            {
                try
                {
                    List<PatientInfo> list = patientInfoManager.GetPatientInfoByUserDet(this.txtQHospiNum.Text.Trim(), this.txtQUserName.Text.Trim(), (ESex)this.cmbQSex.SelectedValue, (int)this.cmbQGroup.SelectedValue, bAge, eAge);
                    this.dgvPatientInfo.DataSource = list;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    MessageBox.Show("患者基本信息加载失败！");
                }
                finally { }
            }            
        }

        public static bool IsNum(string str)
        {
            bool blResult = true;//默认状态下是数字

            foreach (char Char in str)
            {
                if (!char.IsNumber(Char))
                {
                    blResult = false;
                    break;
                }
            }
            if (blResult)
            {
            if (int.Parse(str) == 0)
                blResult = false;
            }
            return blResult;
        }

        //添加患者基本信息
        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                PatientInfo patientInfo = new PatientInfo(0, this.txtHospiNum.Text.Trim(), this.txtUserName.Text.Trim(), (ESex)this.cmbSex.SelectedValue, DateTime.Parse(this.datebBrithday.Text.Trim()), this.txtTel.Text.Trim(), this.txtAddress.Text.Trim(), (int)this.cmbTestGroup.SelectedValue, this.txtAD.Text.Trim(), this.txtONum.Text.Trim());
                int rs = 0;
                rs = patientInfoManager.InsertPatientInfo(patientInfo);
                if (rs != 0)
                {
                    MessageBox.Show("患者基本信息添加成功！");
                }
                else
                {
                    MessageBox.Show("患者基本信息添加失败！");
                }
                /*
                int result = patientInfoManager.GetPatientInfoByHospiNum(this.txtHospiNum.Text);//置标志位，用于判断该患者信息是否存在
                if (result == 0)
                {
                    rs = patientInfoManager.InsertPatientInfo(patientInfo);
                    if (rs != 0)
                    {
                        MessageBox.Show("患者基本信息添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("患者基本信息添加失败！");   
                    }
                }
                else
                {
                    MessageBox.Show("该患者记录已经存在！");
                }
                */
                RefreshPatientInfoData();              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("患者基本信息添加失败！数据库异常！");
            }
            finally { }
        }

        //修改患者基本信息
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                int uid = ((PatientInfo)this.dgvPatientInfo.CurrentRow.DataBoundItem).Uid;
                PatientInfo patientInfo = new PatientInfo(uid, this.txtHospiNum.Text.Trim(), this.txtUserName.Text.Trim(), (ESex)this.cmbSex.SelectedValue, DateTime.Parse(this.datebBrithday.Text.Trim()), this.txtTel.Text.Trim(), this.txtAddress.Text.Trim(), (int)this.cmbTestGroup.SelectedValue, this.txtAD.Text.Trim(), this.txtONum.Text.Trim());
                int rs = patientInfoManager.UpdatePatientInfo(patientInfo);
                if (rs != 0)
                {
                    MessageBox.Show("患者基本信息修改成功！");
                    RefreshPatientInfoData();
                }
                else
                {
                    MessageBox.Show("患者基本信息修改失败！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("患者基本信息修改失败！数据库异常！");
            }
            finally { }
        }

        //心率变异测试数据录入
        private void btnHeartRecord_Click(object sender, EventArgs e)
        {
            try
            {
                uid = ((PatientInfo)this.dgvPatientInfo.CurrentRow.DataBoundItem).Uid;
                HeartRateFrm form = new HeartRateFrm(indexFrm, uid);
                ShowManager showManager = new ShowManager(indexFrm, form);
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("心率变异页面加载失败！");
            }
            finally { }
        }

        //心率变异测试
        private void btnHeartTest_Click(object sender, EventArgs e)
        {
            try
            {
                string title = System.Configuration.ConfigurationManager.AppSettings["title"];
                System.Diagnostics.Process.Start(title);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("心率变异软件没有安装在本机上！");
            }
            finally { }
        }
        
        //心理测试
        private void btnPsyTest_Click(object sender, EventArgs e)
        {
            try
            {
                this.uid = (int)this.dgvPatientInfo.Rows[this.dgvPatientInfo.CurrentCell.RowIndex].Cells[0].Value;
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

        //选中患者基本信息
        private void dgvPatientInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dgvPatientInfo.Rows[this.dgvPatientInfo.CurrentCell.RowIndex].Selected = true;
            int uid = ((PatientInfo)this.dgvPatientInfo.CurrentRow.DataBoundItem).Uid;
            PatientInfo patientInfo = patientInfoManager.GetPatientInfoById(uid);
            this.txtHospiNum.Text = patientInfo.HospiNum;
            this.txtUserName.Text = patientInfo.UserName;
            this.cmbSex.SelectedValue = (ESex)patientInfo.Sex;
            this.datebBrithday.Text = patientInfo.Brithday.ToString();
            this.txtTel.Text = patientInfo.Tel;
            this.txtAddress.Text = patientInfo.Address;
            this.cmbTestGroup.SelectedValue = patientInfo.TestGroup;
            this.txtONum.Text = patientInfo.ONum;
            this.txtAD.Text = patientInfo.AD;
            this.txtTestMentalResult.Text = "";
            this.txtHeartRateResult.Text = "";

            this.LoadHeartRateResult();
            this.LoadMentalTestResult();

        }       

        //选中心率变异数据网格的一行
        private void dgvHeartRate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvHeartRate.Rows[this.dgvHeartRate.CurrentCell.RowIndex].Selected = true;//点击时选中整行
                this.txtHeartRateResult.Text = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).DiaResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("没有选中心率变异数据！");
            }
            finally { }
        }

        //选中心理测试结果
        private void dgvMentalTest_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvMentalTestResult.Rows[this.dgvMentalTestResult.CurrentCell.RowIndex].Selected = true;//点击时选中整行

                int tid = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Tid;
                double score = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Score;
                string name = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).TNameItem;
                List<Acount> list = acountManager.ChoiceAccount(tid, score,strSex, name);
                string str = "";
                for (int i = 0; i < list.Count; i++)
                {
                    str += (list[i].Name + "：" + list[i].Explain + "\r\n");
                }
                this.txtTestMentalResult.Text = str;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("心理测试结果加载失败！");
            }
            finally { }
        }

        //查看详细的心理测试结果
        private void btnMentalTestDetail_Click(object sender, EventArgs e)
        {
            try
            {
                this.uid = (int)this.dgvPatientInfo.Rows[this.dgvPatientInfo.CurrentCell.RowIndex].Cells[0].Value;
                MentalTestReportFrm form = new MentalTestReportFrm(indexFrm, uid);
                ShowManager showManager = new ShowManager(indexFrm, form);
                showManager.ShowForm();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("心理测试结果加载失败！");
            }
            finally { }
        }     

        //刷新患者基本信息
        private void RefreshPatientInfoData()
        {
            try
            {
                List<PatientInfo> list = patientInfoManager.GetPatientInfo();
                this.FillSexCgy();
                this.FillTestGroupCgy();
                this.FillPatientInfoDis();
                this.dgvPatientInfo.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                this.dgvPatientInfo.DataSource = list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("患者基本信息加载失败！");
            }
            finally { }
        }

        //刷新心率变异信息
        private void RefreshHeartRateData(int uid)
        {
            try
            {
                List<HeartRate> list = heartRateManager.GetOneHeartRateByUid(uid);
                this.dgvHeartRate.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                this.dgvHeartRate.DataSource = list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("心率变异信息加载失败！");
            }
            finally { }
        }

        //加载心率变异测试信息
        public void LoadHeartRateResult()
        {
            try
            {
                uid = ((PatientInfo)this.dgvPatientInfo.CurrentRow.DataBoundItem).Uid;
                List<HeartRate> list = heartRateManager.GetOneHeartRateByUid(uid);
                this.dgvHeartRate.AutoGenerateColumns = false;//不要帮我把没有绑定的列自动添加进来
                this.dgvHeartRate.DataSource = list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("心率变异测试信息加载失败！");
            }
            finally { }
        }

        //加载心理测试信息
        public void LoadMentalTestResult()
        {
            try
            {
                uid = ((PatientInfo)this.dgvPatientInfo.CurrentRow.DataBoundItem).Uid;
                List<PatientItem> list = patientDetailManager.GetPatientItemByUid(uid);
                this.dgvMentalTestResult.AutoGenerateColumns = false;
                this.dgvMentalTestResult.DataSource = list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("病历信息加载失败！");
            }
            finally { }
        }

        //填充左方的性别选项框
        private void FillSexCgy()
        {
            cmbSex.DisplayMember = "Name";
            cmbSex.ValueMember = "Id";
            cmbSex.DataSource = Common.FillSexCgy();

            cmbQSex.DisplayMember = "Name";
            cmbQSex.ValueMember = "Id";
            cmbQSex.DataSource = Common.FillSexCgy();
        }

        //填充左方的分组选项框
        private void FillTestGroupCgy()
        {
            cmbTestGroup.DisplayMember = "Name";
            cmbTestGroup.ValueMember = "Id";
            cmbTestGroup.DataSource = Common.FillTestGroupCgy();

            cmbQGroup.DisplayMember = "Name";
            cmbQGroup.ValueMember = "Id";
            cmbQGroup.DataSource = Common.FillTestGroupCgy();
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

        private void btnDeleteMentalTest_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvMentalTestResult.Rows[this.dgvMentalTestResult.CurrentCell.RowIndex].Selected = true;//点击时选中整行
                int udid = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Udid;//获取选中行的Id信息
                int rs = patientDetailManager.DeletePatientDetail(udid);
                if (rs != 0)
                {
                    MessageBox.Show("删除成功！");
                    LoadMentalTestResult();//修改成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                this.txtTestMentalResult.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("删除失败！数据库异常！");
            }
            finally { }
        }

        private void btnDeleteHeartRate_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvHeartRate.Rows[this.dgvHeartRate.CurrentCell.RowIndex].Selected = true;//点击时选中整行
                int id = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Id;//获取选中行的Id信息
                int rs = heartRateManager.DeleteHeartRate(id);
                if (rs != 0)
                {
                    MessageBox.Show("删除成功！");
                    LoadHeartRateResult();//修改成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                this.txtHeartRateResult.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("删除失败！数据库异常！");
            }
            finally { }
        }

        private void btnModifyHeartRatePram_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                this.dgvHeartRate.Rows[this.dgvHeartRate.CurrentCell.RowIndex].Selected = true;//点击时选中整行
                int id = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Id;//获取选中行的Id信息
                int uid = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Uid;
                double physPress = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).PhysPress;
                double psycPress = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).PsycPress;
                double eei = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Eei;
                double ddi = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Ddi;
                double dei = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Dei;
                double si = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Si;
                double sympathetic1 = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Sympathetic1;
                double parasympathetic1 = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Parasympathetic1;
                double sympathetic2 = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Sympathetic2;
                double parasympathetic2 = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Parasympathetic2;
                double sympathetic3 = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Sympathetic3;
                double parasympathetic3 = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Parasympathetic3;
                double sympathetic4 = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Sympathetic4;
                double parasympathetic4 = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Parasympathetic4;
                DateTime dates = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Dates;
                string diaResult = this.txtHeartRateResult.Text.Trim();

                HeartRate heartRate = new HeartRate(id,uid,physPress,psycPress,eei,ddi,dei,si,sympathetic1,parasympathetic1,sympathetic2,parasympathetic2,sympathetic3,parasympathetic3,sympathetic4,parasympathetic4,dates,diaResult);

                int rs = heartRateManager.UpdateHeartRate(heartRate);
                if (rs != 0)
                {
                    MessageBox.Show("修改成功！");
                    RefreshHeartRateData(uid);//修改成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
                this.txtHeartRateResult.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("修改失败！数据库异常！");
            }
            finally { }
             * */
        }

        private void btnPerviewPrint_Click(object sender, EventArgs e)
        {
            int suid = ((PatientInfo)this.dgvPatientInfo.CurrentRow.DataBoundItem).Uid;
            int udid = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Udid;
            int hid = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Id;

            PatientInfo patientInfo = patientInfoManager.GetPatientInfoById(suid);
            PatientItem patientItem = patientDetailManager.GetPatientItemByUdid(udid);
            Hospital hospital = hospitalManager.GetHospitalInfo();
            HeartRate heartRate = heartRateManager.GetOneHeartRate(hid);
            TestGroup testGroup = testGroupManager.GetTestGroupBygid(patientInfo.TestGroup);
            
            int intSex = Convert.ToInt32(patientInfo.Sex);

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
                FileName = System.Configuration.ConfigurationManager.AppSettings["printAllTest"];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("没有配置病历存放的目录位置！");
            }
            finally { }

            FileName += DateTime.Now.ToString("yyyy-MM-dd")+patientInfo.UserName + "病历.doc";

            try
            {
                Word.ApplicationClass MyWord = new Word.ApplicationClass();
                Word._Document MyDoc;
                Object Nothing = System.Reflection.Missing.Value;
                MyDoc = MyWord.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);

                //页头
                MyWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekCurrentPageHeader;
                MyWord.Selection.WholeStory();
                MyWord.Selection.TypeText(hospital.CName+"心理测试管理系统");
                MyWord.ActiveWindow.ActivePane.View.SeekView = Word.WdSeekView.wdSeekMainDocument;

                //页面设置，设置页面为纵向布局，设置纸张类型为A4纸
                MyDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientLandscape;
                MyDoc.PageSetup.PageWidth = MyWord.CentimetersToPoints(21F);
                MyDoc.PageSetup.PageHeight = MyWord.CentimetersToPoints(29.7F);

                //标题
                MyWord.Application.Selection.Font.Size = 16;//字号
                MyWord.Selection.ParagraphFormat.LineSpacing = 15f;//设置文档的行间距
                MyWord.Selection.Font.Bold = (int)Word.WdConstants.wdToggle; // 黑体
                MyWord.Application.Selection.TypeText(hospital.CName+"心理测试与心率变异检测报告");
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
                oPara1.Range.Text += "\t" + this.txtTestMentalResult.Text+"\t";

                oPara1.Range.Text += "医生建议：";
                oPara1.Range.Text += "\t" + patientItem.Advice;

                oPara1.Range.Text += "心理变异测试：";
                oPara1.Range.Text += "诊断结果：";
                oPara1.Range.Text += "\t" + heartRate.DiaResult;

                oPara1.Range.Text += "EEI分析结果：" + heartRate.EeiRs;
                oPara1.Range.Text += "DDI分析结果：" + heartRate.DdiRs;
                oPara1.Range.Text += "DEI分析结果：" + heartRate.DeiRs;
                oPara1.Range.Text += "生理压力分析结果：" + heartRate.PsiRs;
                oPara1.Range.Text += "心理压力分析结果：" + heartRate.MsiRs;
                oPara1.Range.Text += "静息状态分析结果：" + heartRate.RestingRs;
                oPara1.Range.Text += "深呼吸状态分析结果：" + heartRate.BreathRs;
                oPara1.Range.Text += "Valsalva动作分析结果：" + heartRate.ValsalvaRs;
                oPara1.Range.Text += "体位改变分析结果：" + heartRate.StandingRs;
                
                oPara1.Range.Text += "医生建议：";
                oPara1.Range.Text += "\t" + heartRate.DiaResult;

                oPara1.Range.Text += "医生：" + docName;                
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
                MessageBox.Show("该患者暂无心理测试信息！");
            }
            finally { }
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            try
            {
                TestGroupManager testGroupManager = new TestGroupManager();
                int rs = 0;
                int result = testGroupManager.GetTestGroupCnt(this.cmbQGroup.Text.Trim());//置标志位，用于判断该患者信息是否存在
                if (result == 0)
                {
                    rs = testGroupManager.InsertTestGroup(this.cmbQGroup.Text.Trim());
                    if (rs != 0)
                    {
                        MessageBox.Show("分组添加成功！");
                    }
                    else
                    {
                        MessageBox.Show("分组添加失败！");
                    }
                }
                else
                {
                    MessageBox.Show("该分组记录已经存在！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("添加失败！数据库连接异常！");
            }
            finally
            {
                this.cmbQGroup.Text = "";
                this.FillTestGroupCgy();
            }
        }

        private void btnPrintMentalTest_Click(object sender, EventArgs e)
        {
            int suid = ((PatientInfo)this.dgvPatientInfo.CurrentRow.DataBoundItem).Uid;
            int udid = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Udid;
            int hid = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Id;

            PatientInfo patientInfo = patientInfoManager.GetPatientInfoById(suid);
            PatientItem patientItem = patientDetailManager.GetPatientItemByUdid(udid);
            Hospital hospital = hospitalManager.GetHospitalInfo();
            HeartRate heartRate = heartRateManager.GetOneHeartRate(hid);
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
                oPara1.Range.Text += "\t" + this.txtTestMentalResult.Text + "\t";

                oPara1.Range.Text += "医生建议：";
                oPara1.Range.Text += "\t" + patientItem.Advice;

                oPara1.Range.Text += "医生：" + docName;
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

        private void button2_Click(object sender, EventArgs e)
        {
            int suid = ((PatientInfo)this.dgvPatientInfo.CurrentRow.DataBoundItem).Uid;
            int udid = ((PatientItem)this.dgvMentalTestResult.CurrentRow.DataBoundItem).Udid;
            int hid = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Id;

            PatientInfo patientInfo = patientInfoManager.GetPatientInfoById(suid);
            PatientItem patientItem = patientDetailManager.GetPatientItemByUdid(udid);
            Hospital hospital = hospitalManager.GetHospitalInfo();
            HeartRate heartRate = heartRateManager.GetOneHeartRate(hid);
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
                FileName = System.Configuration.ConfigurationManager.AppSettings["printHeartRateTest"];
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

                oPara1.Range.Text += "心理变异测试：";
                oPara1.Range.Text += "诊断结果：";
                oPara1.Range.Text += "\t" + heartRate.DiaResult;

                //oPara1.Range.Text += "心率变异分析结果：";
                //oPara1.Range.Text += "无创动脉硬化检测结果：";
                //oPara1.Range.Text += "植物神经功能检测结果：";
                oPara1.Range.Text += "医生建议：";
                oPara1.Range.Text += "\t" + heartRate.DiaResult;

                oPara1.Range.Text += "医生：" + docName;
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
    }
}