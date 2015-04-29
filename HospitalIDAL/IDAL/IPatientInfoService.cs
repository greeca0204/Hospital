//**********************************************
//
//文件名：IPatientInfoService.cs
//
//描  述：患者基本信息管理接口-DAL
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
    public interface IPatientInfoService
    {
        List<PatientInfo> GetPatientInfo();//获取患者基本信息
        PatientInfo GetPatientInfoById(int uid);//获取指定患者的基本信息
        int GetPatientInfoByHospiNum(string hNum);//查看同意医保卡号的记录
        List<PatientInfo> GetPatientInfoByUserDet(string hospiNum, string uName, ESex uSex, int uTestGroup, string bAge, string eAge);//条件查找患者基本信息，含模糊查找
        int InsertPatientInfo(PatientInfo patientInfo);//插入患者基本信息
        int UpdatePatientInfo(PatientInfo patientInfo);//修改患者基本信息
        int DeletePatientInfo(int uid);//删除患者基本信息
    }
}
