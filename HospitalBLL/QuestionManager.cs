//**********************************************
//
//文件名：QuestionManager.cs
//
//描  述：量表问题操作-BLL
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

namespace Hospital
{
    public class QuestionManager
    {
        IQuestionService db = AbstractDALFactory.CreateDALService().GetIQuestionService();

        public QuestionManager()
        { 
        }

        //获取每张量表的题目数目
        public int CountAccount(int tId)
        {
            return db.CountAccount(tId);
        }

        //获取指定量表的题目
        public Dictionary<int, Questions> GetQuestion(int tId)
        {
            Dictionary<int, Questions> dictionary = db.GetQuestion(tId);
            return dictionary;
        }
    }
}
