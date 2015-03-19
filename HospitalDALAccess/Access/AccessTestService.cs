//**********************************************
//
//文件名：AccessTestService.cs
//
//描  述：量表信息Access数据库实现
//
//作  者：罗家辉
//
//创建时间：2014-4-12
//
//修改历史：2014-7-6  罗家辉 修改
//*********************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hospital.Access
{
    public class AccessTestService : ITestService
    {
        OleDbConnection con = null;
        public AccessTestService()
        {
            String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }
        
        public int updateTestByUsual(int tid,bool uflag)
        {
            int rs = 0;
            string sql = "update tbl_testpaper set uflag=@uflag where tid=@tid";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@uflag", uflag);
                cmd.Parameters.AddWithValue("@tid", tid);
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            return rs;
        }


        public int updateTestByHUsual(int tid, bool hflag)
         {
             int rs = 0;
             string sql = "update tbl_testpaper set hflag=@hflag where tid=@tid";
             con.Open();
             using (OleDbCommand cmd = new OleDbCommand(sql, con))
             {
                 cmd.Parameters.AddWithValue("@hflag", hflag);
                 cmd.Parameters.AddWithValue("@tid", tid);
                 rs = cmd.ExecuteNonQuery();
             }
             con.Close();
             return rs;
         }

        public int updateTestBySUsual(int tid, bool sflag)
        {
            int rs = 0;
            string sql = "update tbl_testpaper set sflag=@sflag where tid=@tid";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@sflag", sflag);
                cmd.Parameters.AddWithValue("@tid", tid);
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            return rs;
        }

        /*
         public int updateTestByHUsual(int tid,bool uflag,bool hflag)
         {
             int rs = 0;
             string sql = "update tbl_testpaper set uflag=@uflag and hflag=@hflag where tid=@tid";
             con.Open();
             using (OleDbCommand cmd = new OleDbCommand(sql, con))
             {
                 cmd.Parameters.AddWithValue("@uflag",uflag);
                 cmd.Parameters.AddWithValue("@hflag",hflag);
                 cmd.Parameters.AddWithValue("@tid", tid);
                 rs = cmd.ExecuteNonQuery();
             }
             con.Close();
             return rs;
         }
          */
        public List<Test> GetTestByItem()
        {
            string sql = "Select tId, tName, pid,uflag,hflag,sflag from tbl_testpaper where pid = 201 or pid = 202 or pid = 203 or pid = 204 ";
            List<Test> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<Test>();
                        int tId = Convert.ToInt32(dr["tId"]);
                        string tName = Convert.ToString(dr["tName"]);
                        int pid = Convert.ToInt32(dr["pid"]);
                        bool uflag = Convert.ToBoolean(dr["uflag"]);
                        bool hflag = Convert.ToBoolean(dr["hflag"]);
                        bool sflag = Convert.ToBoolean(dr["sflag"]);
                        Test test = new Test(tId, tName,pid,uflag,hflag,sflag);
                        list.Add(test);
                    }
                }
            }
        
            con.Close();
            return list;
        }

    }
}
