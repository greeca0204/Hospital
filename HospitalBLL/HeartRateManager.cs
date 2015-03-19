//**********************************************
//
//文件名：HeartRateManager.cs
//
//描  述：心率变异信息管理操作-BLL
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
    public class HeartRateManager
    {
        IHeartRateService db = AbstractDALFactory.CreateDALService().GetIHeartRateService();

        public HeartRateManager()
        {
        }

        //获取某条心率变异信息
        public HeartRate GetOneHeartRate(int id)
        {
            HeartRate heartRate = db.GetOneHeartRate(id);
            return heartRate;
        }

        //获取某人心率变异信息
        public List<HeartRate> GetOneHeartRateByUid(int uid)
        {
            List<HeartRate> list = db.GetOneHeartRateByUid(uid);
            return list;
        }

        //插入心率变异信息
        public int InsertHeartRate(HeartRate heartRate)
        {
            return db.InsertHeartRate(heartRate);
        }

        //修改心率变异信息
        public int UpdateHeartRate(HeartRate heartRate)
        {
            return db.UpdateHeartRate(heartRate);
        }

        //删除心率变异信息
        public int DeleteHeartRate(int id)
        {
            return db.DeleteHeartRate(id);
        }
    }
}
