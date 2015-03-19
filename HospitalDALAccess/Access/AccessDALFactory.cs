//**********************************************
//
//文件名：AccessDALFactory.cs
//
//描  述：抽象工厂Access数据库实现
//
//作  者：罗家辉
//
//创建时间：2014-2-17
//
//修改历史：2014-7-6  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.Text;
using Hospital.Access;

namespace Hospital
{
    public class AccessDALFactory:AbstractDALFactory
    {
        //医生信息管理
        public override IDoctorService GetIDoctorService()
        {
            return new AccessDoctorService();
        }
        
        //科室信息管理
        public override IOfficeService GetIOfficeService()
        {
            return new AccessOfficeService();
        }

        //心率变异信息管理
        public override IHeartRateService GetIHeartRateService()
        {
            return new AccessHeartRateService();
        }

        //医院信息管理
        public override IHospitalService GetIHospitalService()
        {
            return new AccessHospitalService();
        }

        //选项管理
        public override IOptionService GetIOptionService()
        {
            return new AccessOptionService();
        }

        //病历信息管理
        public override IPatientDetailService GetIPatientDetailService()
        {
            return new AccessPatientDetailService();
        }

        //病人信息管理
        public override IPatientInfoService GetIPatientInfoService()
        {
            return new AccessPatientInfoService();
        }

        //问题管理
        public override IQuestionService GetIQuestionService()
        {
            return new AccessQuestionService();
        }

        //量表信息管理
        public override ITestService GetITestService()
        {
            return new AccessTestService();
        }

        //量表结果管理
        public override IAcountService GetIAcountService()
        {
            return new AccessAcountService();
        }

        //测试组管理
        public override ITestGroupService GetITestGroupService()
        {
            return new AccessTestGroupService();
        }
    }
}
