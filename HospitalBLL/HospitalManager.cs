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
    public class HospitalManager
    {
        IHospitalService db = AbstractDALFactory.CreateDALService().GetIHospitalService();
        public HospitalManager()
        {
        }

        //获取医院信息
        public Hospital GetHospitalInfo()
        {
            return db.GetHospitalInfo();
        }

        //更新医院信息
        public int UpdateHospitalInfo(Hospital hospital)
        {
            return db.UpdateHospitalInfo(hospital);
        }
    }
}
