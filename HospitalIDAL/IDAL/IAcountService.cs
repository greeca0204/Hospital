//**********************************************
//
//文件名：IAcountService.cs
//
//描  述：量表测试管理接口-DAL
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

namespace Hospital
{
    public interface IAcountService
    {
        List<Acount> GetAccount(int tid, double score);//获取测试结果
        List<Acount> GetAccountAddSex(int tid, double score, string xb,string nameItem);//婚姻心理控制源量表(MLCS)获取测试结果
        List<Acount> GetAccountAddName(int tid, double score, string name);//家庭环境量表（FES-CV）获取测试结果
        List<string> GetName(int tid);//获取对应量表在tbl_account的所有name
        List<Acount> GetAccountAddAge(int tid, double score, int age, string nameItem);
        int GetNum(int tid);//获取对应量表在tbl_account的量表项目数量，只有量表id和分数score作为条件
       /*
        int GetNum(int tid, double score, string nameItem);//获取对应量表在tbl_account的量表项目数量，量表tid、分数score和量表项目name作为条件
        int GetNum(int tid, double score, string xb, string nameItem);//获取对应量表在tbl_account的量表项目数量，量表tid、分数score、量表项目name和性别xb作为条件
    */
    }
}
