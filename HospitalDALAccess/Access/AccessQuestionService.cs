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
    public class AccessQuestionService:IQuestionService
    {
        OleDbConnection con = null;
        
        public AccessQuestionService()
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }

        //获取每张量表的题目数目
        public int CountAccount(int tId)
        {
            int account = 0;
            con.Open();
            string sql = "select count(*) from tbl_questions where tId = @tId";
            using (OleDbCommand optionCmd = new OleDbCommand(sql, con))
            {
                optionCmd.Parameters.AddWithValue("@tId", tId);              
                account = (int)optionCmd.ExecuteScalar();
            }
            con.Close();
            return account;
        }

        //获取指定量表的题目
        public Dictionary<int, Questions> GetQuestion(int tId)
        {
            String QuestionsSql = "select tid,nid, qid, question from tbl_questions where tbl_questions.tid = @tId;";
            Dictionary<int, Questions> dictionary = null;
            con.Open();
            // 操作表tbl_questions，获取应的数据
            try
            {
                using (OleDbCommand QuestionCmd = new OleDbCommand(QuestionsSql, con))
                {
                    QuestionCmd.Parameters.AddWithValue("@tId", tId);
                    using (OleDbDataReader QuestionReader = QuestionCmd.ExecuteReader())
                    {
                        while (QuestionReader.Read())
                        {
                            if (dictionary == null)
                                dictionary = new Dictionary<int, Questions>();
                            int tid = Convert.ToInt32(QuestionReader["tid"]);
                            int nid = Convert.ToInt32(QuestionReader["nid"]);
                            int qid = Convert.ToInt32(QuestionReader["qid"]);
                            String question = Convert.ToString(QuestionReader["question"]);
                            Questions questions = Factory.CreateQuestion(qid, tid, nid, question);
                            dictionary.Add(nid, questions);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                con.Close();
            }
            con.Close();
            return dictionary;
        }
    }
}
