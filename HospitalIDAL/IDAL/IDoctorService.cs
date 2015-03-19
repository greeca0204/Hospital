//**********************************************
//
//文件名：IDoctorService.cs
//
//描  述：医生信息管理接口-DAL
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
    public  interface IDoctorService
    {
        Doctor GetDoctor(string userName, string passWord);//医生登录
        Doctor GetDoctorById(int id);//获取某个医生的记录
        List<Doctor> GetAllDoctor();//获取所有医生信息
        int InsertDoctorInfo(Doctor doctor);//添加医生信息
        int UpdateDoctorInfo(Doctor doctor);//修改医生信息
        int UpdateDoctorInfoExceptPsw(Doctor doctor);//修改医生信息(无密码)
        int DeleteDoctorInfo(int id);//删除医生信息
    }
}
