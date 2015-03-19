//**********************************************
//
//文件名：HospitalManager.cs
//
//描  述：医院信息管理操作-BLL
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
   public class OptionManager
    {
       IOptionService db = AbstractDALFactory.CreateDALService().GetIOptionService();
       public OptionManager()
       {
       }

       //获取每条问题的答案数目
       public int CountAccount(int qId)
       {
           return db.CountAccount(qId);
       }

       //获取题目选项
       public Dictionary<char, Options> GetOptions(int qId)
       {
           Dictionary<char, Options> list = db.GetOptions(qId);
           return list;
       }
    }
}
