//**********************************************
//
//文件名：IOptionService.cs
//
//描  述：问题的选项接口-DAL
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
    public interface IOptionService
    {
        int CountAccount(int qId);//获取每条问题的答案数目
        Dictionary<char, Options> GetOptions(int qId);//获取题目选项
    }
}
