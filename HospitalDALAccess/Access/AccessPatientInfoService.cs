//**********************************************
//
//文件名：AccessPatientInfoService.cs
//
//描  述：患者基本信息管理Access数据库实现
//
//作  者：罗家辉
//
//创建时间：2014-2-17
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
    public class AccessPatientInfoService : IPatientInfoService
    {
        OleDbConnection con = null;
        public AccessPatientInfoService()
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }

        //获取患者基本信息
        public List<PatientInfo> GetPatientInfo()
        {
            string sql = "Select uid,hospiNum,userName,sex,brithday, tel,address,testGroup,AD,ONum from tbl_patientInfo order by uid desc";
            List<PatientInfo> list = null;
            con.Open(); 
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {                    
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<PatientInfo>();

                        int uid = (int)dr["uid"];
                        string hospiNum = (string)dr["hospiNum"];
                        string userName = (string)dr["userName"];
                        ESex sex = (ESex)Convert.ToInt32(dr["sex"]);
                        DateTime brithday =Convert.ToDateTime(dr["brithday"]);
                        string tel = (string)dr["tel"];
                        string address = (string)dr["address"];
                        int testGroup = Convert.ToInt32(dr["testGroup"]);
                        string aD = (string)dr["AD"];
                        string oNum = (string)dr["ONum"];

                        PatientInfo patientInfo = Factory.CreatePatientInfo(uid, hospiNum, userName, sex, brithday, tel, address, testGroup, aD, oNum);
                        list.Add(patientInfo);
                    }
                }                
            }
            con.Close();
            return list;
        }

        //获取指定患者的基本信息
        public PatientInfo GetPatientInfoById(int id)
        {
            string sql = "Select uid,hospiNum,userName,sex,brithday, tel,address,testGroup,AD,ONum from tbl_patientInfo where uid=@uid";
            PatientInfo patientInfo = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@uid", id);              
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int uid = (int)dr["uid"];
                        string hospiNum = (string)dr["hospiNum"];
                        string userName = (string)dr["userName"];
                        ESex sex = (ESex)Convert.ToInt32(dr["sex"]);
                        DateTime brithday = Convert.ToDateTime(dr["brithday"]);
                        string tel = (string)dr["tel"];
                        string address = (string)dr["address"];
                        int testGroup = Convert.ToInt32(dr["testGroup"]);
                        string aD = (string)dr["AD"];
                        string oNum = (string)dr["ONum"];
                        
                        patientInfo = new PatientInfo(uid, hospiNum, userName, sex, brithday, tel, address, testGroup,aD,oNum);
                    }
                }               
            }
            con.Close();
            return patientInfo;
        }

        //查看同意医保卡号的记录
        public int GetPatientInfoByHospiNum(string hNum)
        {
            int chNum = 0;
            string sql = "Select count(hospiNum) as chNum from tbl_patientInfo where hospiNum=@hospiNum";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {               
                cmd.Parameters.AddWithValue("@hospiNum", hNum);                
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        //chNum = (int)dr["chNum"];
                        //chNum = dr.GetInt32(0);
                        chNum = Convert.ToInt32(dr["chNum"]);
                    }
                }               
            }
            con.Close();
            return chNum;
        }

        //条件查找患者基本信息，含模糊查找
        public List<PatientInfo> GetPatientInfoByUserDet(string hNum, string uName, ESex uSex, int uTestGroup, string bAge, string eAge)
        {
            string sql = "Select uid,hospiNum,userName,sex,brithday, tel,address,testGroup,AD,ONum from tbl_patientInfo";
            string WhereText = " where";

            if (hNum != "" || uName != "" || uSex != ESex.None || uTestGroup != -1 || (bAge != "" && eAge != ""))
            {
                if (hNum.Length > 0)
                {
                    WhereText += " hospiNum like @hospiNum and";
                }
                if (uName.Length > 0)
                {
                    WhereText += " userName like @userName  and";
                }
                if (uSex != ESex.None)
                {
                    WhereText += " sex =@sex and";
                }
                if (uTestGroup != -1)
                {
                    WhereText += " testGroup =@testGroup and";
                }
                if (bAge.Length>0 && eAge.Length>0)
                {
                    WhereText += " (year(now())-year(brithday) between @bAge and @eAge) and";
                }
            }
            else
            {
                WhereText = "";
            }

            if (WhereText != "")
            {
                sql += WhereText.Substring(0, WhereText.Length - 4);//去掉最后一个and
            }

            sql += " order by uid desc";

            List<PatientInfo> list = null;
            con.Open();
            using ( OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                if (hNum != "" || uName != "" || uSex != ESex.None || uTestGroup != -1 || (bAge != "" && eAge != ""))
               {
                   if (hNum.Length > 0)
                   {
                       cmd.Parameters.AddWithValue("@hospiNum", "%"+hNum+"%");
                   }
                   if (uName.Length > 0)
                   {
                       cmd.Parameters.AddWithValue("@userName", "%" + uName + "%");
                   }
                   if (uSex != ESex.None)
                   {
                       cmd.Parameters.AddWithValue("@sex", Convert.ToInt32(uSex));
                   }
                   if (uTestGroup != -1)
                   {
                       cmd.Parameters.AddWithValue("@testGroup", Convert.ToInt32(uTestGroup));
                   }
                   if (bAge.Length > 0 && eAge.Length > 0)
                   {
                       cmd.Parameters.AddWithValue("@bAge", Convert.ToInt32(bAge));
                       cmd.Parameters.AddWithValue("@eAge", Convert.ToInt32(eAge));
                   }
               }
          
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<PatientInfo>();

                        int uid = (int)dr["uid"];
                        string hospiNum = (string)dr["hospiNum"];
                        string userName = (string)dr["userName"];
                        ESex sex = (ESex)Convert.ToInt32(dr["sex"]); ;
                        DateTime brithday = Convert.ToDateTime(dr["brithday"]);
                        string tel = (string)dr["tel"];
                        string address = (string)dr["address"];
                        int testGroup = Convert.ToInt32(dr["testGroup"]);
                        string aD = (string)dr["AD"];
                        string oNum = (string)dr["ONum"];

                        PatientInfo patientInfo = Factory.CreatePatientInfo(uid, hospiNum, userName, sex, brithday, tel, address, testGroup,aD,oNum);
                        list.Add(patientInfo);
                    }
                }
            }
            con.Close();
            return list;
        }

        //插入患者基本信息
        public int InsertPatientInfo(PatientInfo patientInfo)
        {      
            int rs = 0;
            string sql = "insert into tbl_patientInfo(hospiNum,userName,sex,brithday,tel,address,testGroup,AD,ONum) values (@hospiNum,@username,@sex,@brithday,@tel,@address,@testGroup,@aD,@oNum)";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@hospiNum", patientInfo.HospiNum);
                cmd.Parameters.AddWithValue("@username", patientInfo.UserName);
                cmd.Parameters.AddWithValue("@sex", patientInfo.Sex);
                cmd.Parameters.AddWithValue("@brithday", patientInfo.Brithday);
                cmd.Parameters.AddWithValue("@tel", patientInfo.Tel);
                cmd.Parameters.AddWithValue("@address", patientInfo.Address);
                cmd.Parameters.AddWithValue("@testGroup", Convert.ToInt32(patientInfo.TestGroup));
                cmd.Parameters.AddWithValue("@aD", patientInfo.AD);
                cmd.Parameters.AddWithValue("@oNum", patientInfo.ONum);
                rs = cmd.ExecuteNonQuery();     
            }
            con.Close();
            return rs;
        }

        //修改患者基本信息
        public int UpdatePatientInfo(PatientInfo patientInfo) 
        {
            int rs = 0;
            string sql = "update tbl_patientInfo set hospiNum=@hospiNum,userName=@username,sex=@sex,brithday=@brithday,tel=@tel,address=@address,testGroup=@testGroup,AD=@aD,ONum=@oNum where uid=@uid";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@hospiNum", patientInfo.HospiNum);
                cmd.Parameters.AddWithValue("@username", patientInfo.UserName);
                cmd.Parameters.AddWithValue("@sex", patientInfo.Sex);
                cmd.Parameters.AddWithValue("@brithday", patientInfo.Brithday);
                cmd.Parameters.AddWithValue("@tel", patientInfo.Tel);
                cmd.Parameters.AddWithValue("@address", patientInfo.Address);
                cmd.Parameters.AddWithValue("@testGroup", Convert.ToInt32(patientInfo.TestGroup));
                cmd.Parameters.AddWithValue("@aD", patientInfo.AD);
                cmd.Parameters.AddWithValue("@oNum", patientInfo.ONum);
                cmd.Parameters.AddWithValue("@uid", Convert.ToInt32(patientInfo.Uid));
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            return rs;
        }
        
        //删除患者基本信息
        public int DeletePatientInfo(int uid)
        {
            int rs = 0;
            try
            {
                string sql = "delete from tbl_patientInfo where uid=@uid";
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@uid", uid);
                    rs = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                con.Close();
            }
            return rs;
        }
    }
}
