//**********************************************
//
//文件名：AbstractDALFactory.cs
//
//描  述：抽象工厂，反射器
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
using System.Configuration;
using System.Reflection;

namespace Hospital
{
   public abstract class AbstractDALFactory
   {
       public abstract IHospitalService GetIHospitalService();//医院信息管理
       public abstract IOfficeService GetIOfficeService();//科室信息管理
       public abstract IDoctorService GetIDoctorService();//医生信息管理
       public abstract ITestService GetITestService();//量表信息管理
       public abstract IQuestionService GetIQuestionService();//问题管理 
       public abstract IOptionService GetIOptionService();//选项管理
       public abstract IAcountService GetIAcountService();//量表结果信息管理
       public abstract ITestGroupService GetITestGroupService();//测试组管理
       public abstract IPatientInfoService GetIPatientInfoService();//病人信息管理   
       public abstract IHeartRateService GetIHeartRateService();//心率变异信息管理    
       public abstract IPatientDetailService GetIPatientDetailService();//病人心理测试信息管理

       public static AbstractDALFactory CreateDALService()
       {
           Assembly asm= Assembly.Load(ConfigurationManager.AppSettings["dbdll"]);
           AbstractDALFactory rar = (AbstractDALFactory)asm.CreateInstance(ConfigurationManager.AppSettings["dbftyclass"]);
           return rar;
       }
    }
}
