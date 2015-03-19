//**********************************************
//
//文件名：HeartRateFrm.cs
//
//描  述：心率变异信息录入界面
//
//作  者：罗家辉
//
//创建时间：2014-1-15
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
using System.Xml;

namespace Hospital
{
    public partial class HeartRateFrm : Form
    {
        private int uid;    //全局的患者id
        private int hrid;   //全局的选中的心率变异数据的id
        private string docName="";
        private IndexFrm indexFrm;
        HeartRateManager heartRateManager = new HeartRateManager(); //获取心率变异数据操作对象
        PatientInfoManager patientInfoManager = new PatientInfoManager();   //获取病人信息数据操作对象

        public HeartRateFrm(IndexFrm _indexFrm, int _uid)
        {
            InitializeComponent();
            this.uid = _uid;
            this.indexFrm = _indexFrm;
        }

        //页面最初时候的状态
        private void HeartRateFrm_Load(object sender, EventArgs e)
        {
            /*获取患者基本信息*/
            try
            {
                
                PatientInfo patientInfo = patientInfoManager.GetPatientInfoById(uid);
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

                RefreshData(uid);//刷新列表
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("患者基本信息加载失败！");
            }
            finally { }
            this.txtdates.Text = DateTime.Now.ToString();
        }     

        //点击添加按钮的事件
        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetDefaultValue();
            try
            {
                HeartRate heartRate = new HeartRate(hrid,
                     uid,
                     Convert.ToDouble(this.txtPhysiologicalPressure.Text.Trim()),
                     Convert.ToDouble(this.txtMentalPressure.Text.Trim()),
                     Convert.ToDouble(this.txtEEI.Text.Trim()),
                     Convert.ToDouble(this.txtDDI.Text.Trim()),
                     Convert.ToDouble(this.txtDEI.Text.Trim()),
                     Convert.ToDouble(this.txtSI.Text.Trim()),
                     Convert.ToDouble(this.txtStaticAutonomicNerves.Text.Trim()),
                     Convert.ToDouble(this.txtStaticParasympathetic.Text.Trim()),
                     Convert.ToDouble(this.txtBreathAutonomicNerves.Text.Trim()),
                     Convert.ToDouble(this.txtBreathParasympathetic.Text.Trim()),
                     Convert.ToDouble(this.txtValsalvaAutonomicNerves.Text.Trim()),
                     Convert.ToDouble(this.txtValsalvaParasympathetic.Text.Trim()),
                     Convert.ToDouble(this.txtPositionAutonomicNerves.Text.Trim()),
                     Convert.ToDouble(this.txtPositionParasympathetic.Text.Trim()),
                     DateTime.Parse(DateTime.Now.ToString()),
                     this.txtDiaResult.Text.Trim(),
                     this.txtEeiRs.Text.Trim(),
                     this.txtDdiRs.Text.Trim(),
                     this.txtDeiRs.Text.Trim(),
                     this.txtPsiRs.Text.Trim(),
                     this.txtMsiRs.Text.Trim(),
                     this.txtRestingRs.Text.Trim(),
                     this.txtBreathRs.Text.Trim(),
                     this.txtValsalvaRs.Text.Trim(),
                     this.txtStandingRs.Text.Trim()
                     );
                int rs = heartRateManager.InsertHeartRate(heartRate);
                if (rs != 0)
                {
                    MessageBox.Show("添加成功！");
                    RefreshData(uid);//添加成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
                this.txtDiaResult.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("添加失败！");
            }
            finally { }
        }

        //点击修改按钮的事件
        private void btnChange_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvHeartRate.Rows[this.dgvHeartRate.CurrentCell.RowIndex].Selected = true;//点击时选中整行
                hrid = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Id;//获取选中行的Id信息

                DateTime dates = DateTime.Parse(this.txtdates.Text.Trim());
                HeartRate heartRate = new HeartRate(hrid,
                     uid,
                     Convert.ToDouble(this.txtPhysiologicalPressure.Text.Trim()),
                     Convert.ToDouble(this.txtMentalPressure.Text.Trim()),
                     Convert.ToDouble(this.txtEEI.Text.Trim()),
                     Convert.ToDouble(this.txtDDI.Text.Trim()),
                     Convert.ToDouble(this.txtDEI.Text.Trim()),
                     Convert.ToDouble(this.txtSI.Text.Trim()),
                     Convert.ToDouble(this.txtStaticAutonomicNerves.Text.Trim()),
                     Convert.ToDouble(this.txtStaticParasympathetic.Text.Trim()),
                     Convert.ToDouble(this.txtBreathAutonomicNerves.Text.Trim()),
                     Convert.ToDouble(this.txtBreathParasympathetic.Text.Trim()),
                     Convert.ToDouble(this.txtValsalvaAutonomicNerves.Text.Trim()),
                     Convert.ToDouble(this.txtValsalvaParasympathetic.Text.Trim()),
                     Convert.ToDouble(this.txtPositionAutonomicNerves.Text.Trim()),
                     Convert.ToDouble(this.txtPositionParasympathetic.Text.Trim()),
                     dates, this.txtDiaResult.Text.Trim(),
                     this.txtEeiRs.Text.Trim(),
                     this.txtDdiRs.Text.Trim(),
                     this.txtDeiRs.Text.Trim(),
                     this.txtPsiRs.Text.Trim(),
                     this.txtMsiRs.Text.Trim(),
                     this.txtRestingRs.Text.Trim(),
                     this.txtBreathRs.Text.Trim(),
                     this.txtValsalvaRs.Text.Trim(),
                     this.txtStandingRs.Text.Trim());
                int rs = heartRateManager.UpdateHeartRate(heartRate);
                if (rs != 0)
                {
                    MessageBox.Show("修改成功！");
                    RefreshData(uid);//修改成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
                this.txtDiaResult.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("修改失败！数据库异常！");
            }
            finally { }
        }

        //点击数据网格的数据
        private void dgvHeartRate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvHeartRate.Rows[this.dgvHeartRate.CurrentCell.RowIndex].Selected = true;//点击时选中整行
                hrid = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Id;//获取选中行的Id信息
                this.txtdates.Text = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Dates.ToString();

                HeartRate hr = heartRateManager.GetOneHeartRate(hrid);
                this.txtPhysiologicalPressure.Text = hr.PhysPress.ToString();
                this.txtMentalPressure.Text = hr.PsycPress.ToString();
                this.txtEEI.Text = hr.Eei.ToString();
                this.txtDDI.Text = hr.Ddi.ToString();
                this.txtDEI.Text = hr.Dei.ToString();
                this.txtSI.Text = hr.Si.ToString();
                this.txtStaticAutonomicNerves.Text = hr.Sympathetic1.ToString();
                this.txtStaticParasympathetic.Text = hr.Parasympathetic1.ToString();
                this.txtBreathAutonomicNerves.Text = hr.Sympathetic2.ToString();
                this.txtBreathParasympathetic.Text = hr.Parasympathetic2.ToString();
                this.txtValsalvaAutonomicNerves.Text = hr.Sympathetic3.ToString();
                this.txtValsalvaParasympathetic.Text = hr.Parasympathetic3.ToString();
                this.txtPositionAutonomicNerves.Text = hr.Sympathetic4.ToString();
                this.txtPositionParasympathetic.Text = hr.Parasympathetic4.ToString();
                this.txtEeiRs.Text = hr.EeiRs.ToString();
                this.txtDdiRs.Text = hr.DdiRs.ToString();
                this.txtDeiRs.Text = hr.DeiRs.ToString();
                this.txtPsiRs.Text = hr.PsiRs.ToString();
                this.txtMsiRs.Text = hr.MsiRs.ToString();
                this.txtRestingRs.Text = hr.RestingRs.ToString();
                this.txtBreathRs.Text = hr.BreathRs.ToString();
                this.txtValsalvaRs.Text = hr.ValsalvaRs.ToString();
                this.txtStandingRs.Text = hr.StandingRs.ToString();
                this.txtDiaResult.Text = hr.DiaResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("心率变异信息加载失败！");
            }
            finally { }
        }

        //点击返回按钮
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

        //刷新数据网格的数据
        private void RefreshData(int uid)
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

        //删除选中记录
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.dgvHeartRate.Rows[this.dgvHeartRate.CurrentCell.RowIndex].Selected = true;//点击时选中整行
                int id = ((HeartRate)this.dgvHeartRate.CurrentRow.DataBoundItem).Id;//获取选中行的Id信息
                int rs = heartRateManager.DeleteHeartRate(id);
                if (rs != 0)
                {
                    MessageBox.Show("删除成功！");
                    RefreshData(uid);//修改成功后，刷新表格。
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
                this.txtDiaResult.Text = "";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("删除失败！数据库异常！");
            }
            finally { }
        }

        //导入XML数据
        private void btnImportXML_Click(object sender, EventArgs e)
        {
            MessageBox.Show("由于XML格式的原因，可能会导致XML导入不成功，请先将xml文件中<other1>……</other1>的这段文字全部删除，重新保存XML后即可正常使用！");
           
            XMLOperate();
        }   

        //XML操作
        private void XMLOperate()
        {
            string day = "";
            string month = "";
            string year = "";
            string hour = "";
            string min = "";

            try
            {
                openFileDialog1.ShowDialog();
                string FileName = openFileDialog1.FileName;
                XmlDocument myXml = new XmlDocument();
                myXml.Load(FileName);
                XmlNode heartRateInfo = myXml.DocumentElement;
                foreach (XmlNode node in heartRateInfo.ChildNodes)
                {
                    if (node.Name == "result_info")
                    {
                        foreach (XmlNode subNode in node.ChildNodes)
                        {
                            if (subNode.Name == "date_Day")
                                day = subNode.InnerText;
                            if (subNode.Name == "date_Month")
                                month = subNode.InnerText;
                            if (subNode.Name == "date_Year")
                                year = subNode.InnerText;
                            if (subNode.Name == "date_Hour")
                                hour = subNode.InnerText;
                            if (subNode.Name == "date_Minute")
                                min = subNode.InnerText;

                            txtdates.Text = year + "/" + month + "/" + day + " " + hour + ":" + month + ":00";
                        }
                    }

                    if (node.Name == "results")
                    {
                        foreach (XmlNode subNode in node.ChildNodes)
                        {
                            if (subNode.Name == "ptg")
                            {
                                foreach (XmlNode subNode2 in subNode.ChildNodes)
                                {
                                    if (subNode2.Attributes["code"].Value == "PTG-SI")
                                        txtSI.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "PTG-EEI")
                                        txtEEI.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "PTG-DDI")
                                        txtDDI.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "PTG-DEI")
                                        txtDEI.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "PTG-EEI-Comments")
                                        txtEeiRs.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "PTG-DDI-Comments")
                                        txtDdiRs.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "PTG-DEI-Comments")
                                        txtDeiRs.Text = subNode2.InnerText;
                                }
                            }

                            if (subNode.Name == "autonomicbalance")
                            {
                                foreach (XmlNode subNode2 in subNode.ChildNodes)
                                {
                                    if (subNode2.Attributes["code"].Value == "RESTING-LFA")
                                        txtStaticAutonomicNerves.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "RESTING-RFA")
                                        txtStaticParasympathetic.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "RESTING-Comments")
                                        txtRestingRs.Text = subNode2.InnerText;

                                    if (subNode2.Attributes["code"].Value == "BREATH-LFA")
                                        txtBreathAutonomicNerves.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "BREATH-RFA")
                                        txtBreathParasympathetic.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "BREATH-Comments")
                                        txtBreathRs.Text = subNode2.InnerText;

                                    if (subNode2.Attributes["code"].Value == "VALSALVA-LFA")
                                        txtValsalvaAutonomicNerves.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "VALSALVA-RFA")
                                        txtValsalvaParasympathetic.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "VALSALVA-Comments")
                                        txtValsalvaRs.Text = subNode2.InnerText;

                                    if (subNode2.Attributes["code"].Value == "STANDING-LFA")
                                        txtPositionAutonomicNerves.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "STANDING-RFA")
                                        txtPositionParasympathetic.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "STANDING-Comments")
                                        txtStandingRs.Text = subNode2.InnerText;
                                }
                            }

                            if (subNode.Name == "stresstest")
                            {
                                foreach (XmlNode subNode2 in subNode.ChildNodes)
                                {
                                    if (subNode2.Attributes["code"].Value == "ST-PSI")
                                        txtPhysiologicalPressure.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "ST-MSI")
                                        txtMentalPressure.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "ST-PSI-Comments")
                                        txtPsiRs.Text = subNode2.InnerText;
                                    if (subNode2.Attributes["code"].Value == "ST-MSI-Comments")
                                        txtMsiRs.Text = subNode2.InnerText;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("XML格式有误，请检查XML是否有不合法字符！");
            }
            finally { }
        }

        //设置默认值，以防某些值不填时发生错误。
        private void SetDefaultValue()
        {
            if (this.txtPhysiologicalPressure.Text.Trim() == "")
                this.txtPhysiologicalPressure.Text = "0";

            if (this.txtMentalPressure.Text.Trim() == "")
                this.txtMentalPressure.Text = "0";

            if (this.txtEEI.Text.Trim() == "")
                this.txtEEI.Text = "0";

            if (this.txtDDI.Text.Trim() == "")
                this.txtDDI.Text = "0";

            if (this.txtDEI.Text.Trim() == "")
                this.txtDEI.Text = "0";

            if (this.txtSI.Text.Trim() == "")
                this.txtSI.Text = "0";

            if (this.txtStaticAutonomicNerves.Text.Trim() == "")
                this.txtStaticAutonomicNerves.Text = "0";

            if (this.txtStaticParasympathetic.Text.Trim() == "")
                this.txtStaticParasympathetic.Text = "0";

            if (this.txtBreathAutonomicNerves.Text.Trim() == "")
                this.txtBreathAutonomicNerves.Text = "0";

            if (this.txtBreathParasympathetic.Text.Trim() == "")
                this.txtBreathParasympathetic.Text = "0";

            if (this.txtValsalvaAutonomicNerves.Text.Trim() == "")
                this.txtValsalvaAutonomicNerves.Text = "0";

            if (this.txtValsalvaParasympathetic.Text.Trim() == "")
                this.txtValsalvaParasympathetic.Text = "0";

            if (this.txtPositionAutonomicNerves.Text.Trim() == "")
                this.txtPositionAutonomicNerves.Text = "0";

            if (this.txtPositionParasympathetic.Text.Trim() == "")
                this.txtPositionParasympathetic.Text = "0";
        }
    }
}
