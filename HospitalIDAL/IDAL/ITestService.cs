//**********************************************
//
//文件名：ITestService.cs
//
//描  述：量表题目接口-DAL
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
    public interface ITestService
    {
        int updateTestByUsual(int tid, bool uflag);
        int updateTestByHUsual(int tid,bool hflag);
        int updateTestBySUsual(int tid, bool sflag);
        List<Test> GetTestByItem();
    }
}
