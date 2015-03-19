//**********************************************
//
//文件名：IHeartRateService.cs
//
//描  述：心率变异信息管理接口-DAL
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
    public interface IHeartRateService
    {
        HeartRate GetOneHeartRate(int id);//获取某条心率变异信息
        List<HeartRate> GetOneHeartRateByUid(int uid);//获取某人心率变异信息
        int InsertHeartRate(HeartRate heartRate);//插入心率变异信息
        int UpdateHeartRate(HeartRate heartRate);//修改心率变异信息
        int DeleteHeartRate(int id);//删除心率变异信息
    }
}
