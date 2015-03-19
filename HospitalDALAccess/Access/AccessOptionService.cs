//**********************************************
//
//文件名：AccessOptionService.cs
//
//描  述：问题的选项信息Access数据库实现
//
//作  者：罗家辉
//
//创建时间：2014-4-12
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
    class AccessOptionService : IOptionService
    {
        OleDbConnection con = null;
        public AccessOptionService()
        {
            String conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }

        //获取每条问题的答案数目
        public int CountAccount(int qId)
        {
            int account = 0;
            string sql = "select count(*) from tbl_options where qId = @qId";
            con.Open();
            using (OleDbCommand optionCmd = new OleDbCommand(sql, con))
            {
                optionCmd.Parameters.AddWithValue("@qId", qId);               
                account = (int)optionCmd.ExecuteScalar();
            }
            con.Close();
            return account;
        }

        //获取题目选项
        public Dictionary<char, Options> GetOptions(int qId)
        {
            Dictionary<char, Options> dictionary = null;
            try
            {
                string sql = "select oid, qid, option, title, score from tbl_options where tbl_options.qid = @qid";
                
                con.Open();
                using (OleDbCommand optionCmd = new OleDbCommand(sql, con))
                {
                    optionCmd.Parameters.AddWithValue("@qid", qId);
                    using (OleDbDataReader optionReader = optionCmd.ExecuteReader())
                    {
                        while (optionReader.Read())
                        {
                            if (dictionary == null)
                            {
                                dictionary = new Dictionary<char, Options>();
                            }
                            int oid = Convert.ToInt32(optionReader["oid"]);
                            int qid = Convert.ToInt32(optionReader["qid"]);
                            char option = Convert.ToChar(optionReader["option"]);
                            string title = Convert.ToString(optionReader["title"]);
                            double score = Convert.ToDouble(optionReader["score"]);
                            Options options = Factory.CreateOption(oid, qid, option, title, score);
                            dictionary.Add(option, options);
                        }
                    }
                }
                           
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                con.Close();
            }            
            return dictionary;
        }
    }
}
