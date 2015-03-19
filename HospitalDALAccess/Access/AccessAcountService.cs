//**********************************************
//
//文件名：AccessAccountService.cs
//
//描  述：量表测试结果管理Access数据库实现
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
    public class AccessAcountService : IAcountService
    {
        OleDbConnection con = null;
        public AccessAcountService()
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }

        //通用获取测试结果
        public List<Acount> GetAccount(int tid, double score)
        {
            string sql = "Select * from tbl_acount where hmid=@tid and @max<max and @min>=min";
            List<Acount> list = null;
            con.Open();
            
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                    cmd.Parameters.AddWithValue("@tid", tid);
                    cmd.Parameters.AddWithValue("@max", score);
                    cmd.Parameters.AddWithValue("@min", score);
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (list == null)
                                list = new List<Acount>();

                            int no = Convert.ToInt32(dr["no"]);
                            int hmid = tid;
                            string name = Convert.ToString(dr["name"]);
                            double min = Convert.ToDouble(dr["min"]);
                            double max = Convert.ToDouble(dr["max"]);
                            string explain = Convert.ToString(dr["explain"]);

                            Acount acount = Factory.CreateAcount(no, hmid, name, min, max, explain);
                            list.Add(acount);
                        }
                }
            }
            con.Close();
            return list;
        }

        //增加量表项条件，获取测试结果
        public List<Acount> GetAccountAddName(int tid, double score, string nameItem)
        {
            string sql = "Select * from tbl_acount where hmid=@tid and @max<max and @min>=min and name=@nameItem";
            List<Acount> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@tid", tid);
                cmd.Parameters.AddWithValue("@max", score);
                cmd.Parameters.AddWithValue("@min", score);
                cmd.Parameters.AddWithValue("@nameItem", nameItem);

                using (OleDbDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        if (list == null)
                            list = new List<Acount>();

                        int no = Convert.ToInt32(dr["no"]);
                        int hmid = tid;
                        string name = Convert.ToString(dr["name"]);
                        double min = Convert.ToDouble(dr["min"]);
                        double max = Convert.ToDouble(dr["max"]);
                        string explain = Convert.ToString(dr["explain"]);

                        Acount acount = Factory.CreateAcount(no, hmid, name, min, max, explain);
                        list.Add(acount);
                    }
                }
            }
            
            con.Close();
            return list;
        }

        //增加性别（xb）条件，获取测试结果
        public List<Acount> GetAccountAddSex(int tid, double score, string xb, string nameItem)
        {
            string sql = "Select * from tbl_acount where hmid=@tid and @max<max and @min>=min and xb=@xb and name=@nameItem";
            List<Acount> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@tid", tid);
                cmd.Parameters.AddWithValue("@max", score);
                cmd.Parameters.AddWithValue("@min", score);
                cmd.Parameters.AddWithValue("@xb", xb);
                cmd.Parameters.AddWithValue("@nameItem", nameItem);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<Acount>();

                        int no = Convert.ToInt32(dr["no"]);
                        int hmid = tid;
                        string name = Convert.ToString(dr["name"]);
                        double min = Convert.ToDouble(dr["min"]);
                        double max = Convert.ToDouble(dr["max"]);
                        string explain = Convert.ToString(dr["explain"]);

                        Acount acount = Factory.CreateAcount(no, hmid, name, min, max, explain);
                        list.Add(acount);
                    }
                }
            }
            con.Close();
            return list;
        }

        //增加年龄条件，获取测试结果
        public List<Acount> GetAccountAddAge(int tid, double score, int age, string nameItem)
        {
            string sql = "Select * from tbl_acount where hmid=@tid and @max<max and @min>=min and agemin>=@age and agemax>@age and name=@nameItem";
            List<Acount> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@tid", tid);
                cmd.Parameters.AddWithValue("@max", score);
                cmd.Parameters.AddWithValue("@min", score);
                cmd.Parameters.AddWithValue("@agemin", age);
                cmd.Parameters.AddWithValue("@agemax", age);
                cmd.Parameters.AddWithValue("@nameItem", nameItem);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<Acount>();

                        int no = Convert.ToInt32(dr["no"]);
                        int hmid = tid;
                        string name = Convert.ToString(dr["name"]);
                        double min = Convert.ToDouble(dr["min"]);
                        double max = Convert.ToDouble(dr["max"]);
                        string explain = Convert.ToString(dr["explain"]);

                        Acount acount = Factory.CreateAcount(no, hmid, name, min, max, explain);
                        list.Add(acount);
                    }
                }
            }
            con.Close();
            return list;
        }

        //获取对应量表在tbl_account的量表项目数量，只有量表id和分数score作为条件
        public int GetNum(int tid)
        {
            string sql = "select count(*) as num from (Select name  from tbl_acount where hmid=@tid group by name)";
            int num = 0;
            con.Open();

            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@tid", tid);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                      num = Convert.ToInt32(dr["num"]);
                    }
                }
            }
            con.Close();
            return num;
        }
        /*
        //获取对应量表在tbl_account的量表项目数量，量表tid、分数score和量表项目name作为条件
        public int GetNum(int tid, double score, string nameItem)
        {
            string sql = "Select count(*) as num from tbl_acount where hmid=@tid and @max<max and @min>=min and name=@nameItem";
            int num = 0;
            con.Open();

            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@tid", tid);
                cmd.Parameters.AddWithValue("@max", score);
                cmd.Parameters.AddWithValue("@min", score);
                cmd.Parameters.AddWithValue("@nameItem", nameItem);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {


                        num = Convert.ToInt32(dr["num"]);
                    }
                }
            }
            con.Close();
            return num;
        }

        //获取对应量表在tbl_account的量表项目数量，量表tid、分数score、量表项目name和性别xb作为条件
        public int GetNum(int tid, double score, string xb, string nameItem)
        {
            string sql = "Select count(*) as num from tbl_acount where hmid=@tid and @max<max and @min>=min and xb=@xb and name=@nameItem";
            int num = 0;
            con.Open();

            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@tid", tid);
                cmd.Parameters.AddWithValue("@max", score);
                cmd.Parameters.AddWithValue("@min", score);
                cmd.Parameters.AddWithValue("@xb", xb);
                cmd.Parameters.AddWithValue("@nameItem", nameItem);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {


                        num = Convert.ToInt32(dr["num"]);
                    }
                }
            }
            con.Close();
            return num;
        }
        */
        //获取对应量表在tbl_account的所有name
        public List<string> GetName(int tid)
        {
            string sql = "Select name from tbl_acount where hmid=@tid group by name";
            List<string> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@tid", tid);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<string>();
                        string name = Convert.ToString(dr["name"]);

                        list.Add(name);
                    }
                }
            }
            con.Close();
            return list;
        }

       
    }
}
