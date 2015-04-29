//**********************************************
//
//文件名：AccessPatientDetailService.cs
//
//描  述：病历信息Access数据库实现
//
//作  者：罗家辉
//
//创建时间：2014-7-6
//
//修改历史：2014-7-6  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hospital.Access
{
    class AccessPatientDetailService:IPatientDetailService
    {
        OleDbConnection con = null;
        public AccessPatientDetailService()
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }

        //查询患者的各项心理测试的详细结果
        public List<PatientItem> GetPatientItemByUid(int uid)
        {
            string sql = "Select * from tbl_patientDetail as A inner join tbl_testpaper as B on A.tid=B.tid where A.uid=@uid order by testtime desc";
            List<PatientItem> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@uid", uid);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<PatientItem>();

                        /*PatientDetail*/
                        int udid = Convert.ToInt32(dr["udid"]);
                        int ptid = Convert.ToInt32(dr["A.tid"]);
                        int did = Convert.ToInt32(dr["did"]);
                        string answer = Convert.ToString(dr["answer"]);
                        double score = Convert.ToDouble(dr["score"]);
                        string advice = Convert.ToString(dr["advice"]);
                        DateTime testtime = Convert.ToDateTime(dr["testtime"]);
                        string name = Convert.ToString(dr["A.tname"]);
                        PatientDetail patientDetail = Factory.CreatePatientDetail(udid, uid, ptid, did, answer, score, advice, testtime, name);

                        int ttid = Convert.ToInt32(dr["B.tid"]);
                        string tName = Convert.ToString(dr["B.tName"]);
                        int pid = Convert.ToInt32(dr["pid"]);
                        Test test = Factory.CreateTest(ttid, tName, pid);

                        PatientItem patientItem = Factory.CreatePatientItem(patientDetail,test);
                        list.Add(patientItem);
                    }
                }
            }
            con.Close();
            return list;
        }

        public PatientItem GetPatientItemByUdid(int udid)
        {
            string sql = "Select * from tbl_patientDetail as A inner join tbl_testpaper as B on A.tid=B.tid where udid=@udid  order by testtime desc";
            PatientItem patientItem = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@udid", udid);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        /*PatientDetail*/
                        int ptid = Convert.ToInt32(dr["A.tid"]);
                        int uid = Convert.ToInt32(dr["uid"]);
                        int did = Convert.ToInt32(dr["did"]);
                        string answer = (string)dr["answer"];
                        double score = Convert.ToDouble(dr["score"]);
                        string advice = (string)dr["advice"];
                        DateTime testtime = Convert.ToDateTime(dr["testtime"]);
                        string tname = (string)dr["A.tname"];
                        PatientDetail patientDetail = Factory.CreatePatientDetail(udid, uid, ptid, did, answer, score, advice, testtime, tname);

                        int ttid = Convert.ToInt32(dr["B.tid"]);
                        string tName = (string)dr["B.tName"];
                        int pid = Convert.ToInt32(dr["pid"]);
                        Test test = Factory.CreateTest(ttid, tName, pid);

                        patientItem = Factory.CreatePatientItem(patientDetail, test);
                    }
                }
            }
            con.Close();
            return patientItem;
        }

        //对某个病人的心理测试进行统计
        public List<Statistics> GetStatisticsInfoByUid(int uid)
        {
            string sql = "select A.tid as tid,B.tName,count(score) as cnt,avg(score) as avgv,max(score) as maxv,min(score) as minv from tbl_patientDetail as A inner join tbl_testpaper as B on A.tid=B.tid where A.uid=@uid group by A.tid,B.tName";
            List<Statistics> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@uid", uid);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<Statistics>();
                        int tid = Convert.ToInt32(dr["tid"]);
                        int cnt = Convert.ToInt32(dr["cnt"]);
                        double avgv = Convert.ToDouble(dr["avgv"]);
                        double maxv = Convert.ToDouble(dr["maxv"]);
                        double minv = Convert.ToDouble(dr["minv"]);
                        string tName = (string)dr["tName"];

                        Test test = new Test(0, tName, 0);
                        Statistics statistics = new Statistics(0, cnt, maxv, minv, avgv, test);
                        list.Add(statistics);
                    }
                }
            }
            con.Close();
            return list;
        }

        public List<ExtendStatistics> GetStatisticsInfo(int fsex, int fgroup, int fage)
        {
            string sql = "";
            string b_sql = "select A.tid as tid,B.tName,count(score) as cnt,avg(score) as avgv,max(score) as maxv,min(score) as minv";            
            string e_sql = " from tbl_patientDetail as A,tbl_testpaper as B,tbl_patientInfo as C where A.tid=B.tid and A.uid=C.uid";
            string b_fa_sql = " from(SELECT IIf(DateDiff('yyyy',brithday,Date())<10,'10岁以下',IIf(DateDiff('yyyy',brithday,Date()) Between 10 And 20,'10-20岁',IIf(DateDiff('yyyy',brithday,Date()) Between 21 And 30,'21-30岁',IIf(DateDiff('yyyy',brithday,Date()) Between 31 And 40,'31-40岁',IIf(DateDiff('yyyy',brithday,Date()) Between 41 And 50,'41-50岁',IIf(DateDiff('yyyy',brithday,Date())>50,'50岁以上')))))) AS ageGroup,* FROM tbl_patientInfo as C),tbl_patientDetail as A,tbl_testpaper as B where A.tid=B.tid and A.uid=C.uid";
            string sqlWhere1 = "";
            string sqlWhere2 = "";

            if (fsex == 0 && fgroup == 0 && fage == 0) {
                sqlWhere1 = "";
                sqlWhere2 = " group by A.tid,B.tName";
            }
            else if (fsex == 0 && fgroup == 0 && fage == 1) 
            {
                sqlWhere1 = ",ageGroup";
                sqlWhere2 = " group by A.tid,B.tName,ageGroup";
            }
            else if (fsex == 0 && fgroup == 1 && fage == 0) 
            {
                sqlWhere1 = ",testgroup";
                sqlWhere2 = " group by A.tid,B.tName,testgroup";
            }
            else if (fsex == 0 && fgroup == 1 && fage == 1) 
            {
                sqlWhere1 = ",testgroup,ageGroup";
                sqlWhere2 = " group by A.tid,B.tName,testgroup,ageGroup";
            }
            else if (fsex == 1 && fgroup == 0 && fage == 0) 
            {
                sqlWhere1 = ",sex";
                sqlWhere2 = " group by A.tid,B.tName,sex";
            }
            else if (fsex == 1 && fgroup == 0 && fage == 1) 
            {
                sqlWhere1 = ",sex,ageGroup";
                sqlWhere2 = " group by A.tid,B.tName,sex,ageGroup";
            }
            else if (fsex == 1 && fgroup == 1 && fage == 0) 
            {
                sqlWhere1 = ",sex,testgroup";
                sqlWhere2 = " group by A.tid,B.tName,sex,testgroup";
            }
            else if (fsex == 1 && fgroup == 1 && fage == 1) 
            {
                sqlWhere1 = ",sex,testgroup,ageGroup";
                sqlWhere2 = " group by A.tid,B.tName,sex,testgroup,ageGroup";
            }
            else 
            {
            
            }

            if (fage == 0)
            {
                sql = b_sql + sqlWhere1 + e_sql + sqlWhere2;
            }
            else
            {
                sql  =b_sql + sqlWhere1 + b_fa_sql + sqlWhere2;
            }

            List<ExtendStatistics> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<ExtendStatistics>();
                        int tid = Convert.ToInt32(dr["tid"]);
                        string tName = (string)dr["tName"];
                        
                        int cnt = Convert.ToInt32(dr["cnt"]);
                        double avgv = Convert.ToDouble(dr["avgv"]);
                        double maxv = Convert.ToDouble(dr["maxv"]);
                        double minv = Convert.ToDouble(dr["minv"]);

                        ESex sex = ESex.None;
                        int testGroup = 0;
                        string ageGroup = "";

                        if (fsex==1)
                        {
                            sex = (ESex)dr["sex"];
                        }

                        if (fgroup == 1)
                        {
                            testGroup = Convert.ToInt32(dr["testGroup"]);
                        }

                        if (fage==1)
                        {
                            ageGroup = (string)dr["ageGroup"];
                        }

                        ExtendStatistics estatistics2 = new ExtendStatistics(tid,tName,ageGroup,cnt,avgv,maxv,minv,sex,testGroup);
                        list.Add(estatistics2);
                    }
                }
            }
            con.Close();
            return list;
        }

        //插入患者心理测试信息
        public int InsertPatientDetail(PatientDetail patientDetail)
        {
            int rs = 0;
            string sql = "insert into tbl_patientDetail(uid,tid,did,answer,score,advice,testtime,tname) values(@uid, @tid, @did, @answer, @score, @advice, @testtime,@tname)";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@uid", patientDetail.Uid);
                cmd.Parameters.AddWithValue("@tid", patientDetail.Tid);
                cmd.Parameters.AddWithValue("@did", patientDetail.Did);
                cmd.Parameters.AddWithValue("@answer", patientDetail.Answer);
                cmd.Parameters.AddWithValue("@score", patientDetail.Score);
                cmd.Parameters.AddWithValue("@advice", patientDetail.Advice);
                cmd.Parameters.AddWithValue("@testtime", patientDetail.Testtime);
                cmd.Parameters.AddWithValue("@tname", patientDetail.TNameItem);
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            return rs;
        }

        //删除患者心理测试信息
        public int DeletePatientDetail(int udid)
        {
            int rs = 0;
            string sql = "delete from tbl_patientDetail where udid=@udid";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@udid", udid);
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            return rs;
        }

        //修改医生建议
        public int UpdateAdvice(int udid,string advice)
        {
            int rs = 0;
            string sql = "update tbl_PatientDetail set advice=@advice where udid=@udid";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@advice", advice);
                cmd.Parameters.AddWithValue("@udid", udid);
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            return rs;
        }

        // //获取一条题目的得分
        public double GetScore(int tid, int nid, string option)
        {
            double score = 0;
            string sql = "select score from tbl_options as A inner join tbl_questions as B on A.qid=B.qid where tid=@tid and nid=@nid and option=@option";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@tid", tid);
                cmd.Parameters.AddWithValue("@nid", nid);
                cmd.Parameters.AddWithValue("@option", option);
                score = (double)cmd.ExecuteScalar();
            }
            con.Close();
            return score;
        }

      
    }
}
