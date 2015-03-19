//**********************************************
//
//文件名：IPatientDetailService.cs
//
//描  述：病历信息管理接口-DAL
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
    public interface IPatientDetailService
    {
        int InsertPatientDetail(PatientDetail patientDetail);
        List<PatientItem> GetPatientItemByUid(int uid);
        PatientItem GetPatientItemByUdid(int udid);
        int DeletePatientDetail(int udid);
        List<Statistics> GetStatisticsInfoByUid(int uid);        
        int UpdateAdvice(int udid, string advice);
        double GetScore(int tid, int nid, string option);
        List<ExtendStatistics> GetStatisticsInfo(int fsex, int fgroup, int fage);
       
    }
}
