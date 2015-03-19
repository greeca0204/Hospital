//**********************************************
//
//文件名：IQuestion.cs
//
//描  述：量表问题题目接口-DAL
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

namespace Hospital
{
    public interface IQuestionService
    {
        int CountAccount(int tId);//获取每张量表的题目数目
        Dictionary<int, Questions> GetQuestion(int tId);//获取指定量表的题目
    }
}
