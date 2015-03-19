//**********************************************
//
//文件名：IHospitalService.cs
//
//描  述：公司信息管理接口-DAL
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
    public interface IHospitalService
    {
        Hospital GetHospitalInfo();//获取医院信息
        int UpdateHospitalInfo(Hospital hospital);//更新医院信息
    }
}
