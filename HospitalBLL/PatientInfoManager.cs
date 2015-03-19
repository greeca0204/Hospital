//**********************************************
//
//文件名：PatientInfoManager.cs
//
//描  述：患者基本信息管理操作-BLL
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
    public class PatientInfoManager
    {
        IPatientInfoService db = AbstractDALFactory.CreateDALService().GetIPatientInfoService();

        public PatientInfoManager()
        {
        }

        //获取患者基本信息
        public List<PatientInfo> GetPatientInfo()
        {
            List<PatientInfo> list = db.GetPatientInfo();
            return list;
        }

        //获取指定患者的基本信息
        public PatientInfo GetPatientInfoById(int uid)
        {
            PatientInfo patientInfo = db.GetPatientInfoById(uid);
            return patientInfo;
        }

        //查看同意医保卡号的记录
        public int GetPatientInfoByHospiNum(string hNum)
        {
            int result = db.GetPatientInfoByHospiNum(hNum);
            return result;
        }

        //条件查找患者基本信息，含模糊查找
        public List<PatientInfo> GetPatientInfoByUserDet(string hospiNum, string uName, ESex uSex, int uTestGroup,string bAge,string eAge)
        {
            List<PatientInfo> list = db.GetPatientInfoByUserDet(hospiNum, uName, uSex, uTestGroup,bAge,eAge);
            return list;
        }

        //插入患者基本信息
        public int InsertPatientInfo(PatientInfo patientInfo)
        {
            return db.InsertPatientInfo(patientInfo);
        }

        //修改患者基本信息
        public int UpdatePatientInfo(PatientInfo patientInfo)
        {
            return db.UpdatePatientInfo(patientInfo);
        }
    }
}
