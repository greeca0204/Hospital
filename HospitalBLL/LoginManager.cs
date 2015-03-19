//**********************************************
//
//文件名：LoginManager.cs
//
//描  述：医生登录操作-BLL
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
    public class LoginManager
    {
        IDoctorService db = AbstractDALFactory.CreateDALService().GetIDoctorService();

        public LoginManager()
        {
        }

        //医生登录
        public Doctor GeDoctor(string userName, string passWord)
        {
            return db.GetDoctor(userName, passWord);
        }

        //获取某个医生的记录
        public Doctor GetDoctorById(int id)
        {
            return db.GetDoctorById(id);
        }

        //获取所有医生信息
        public List<Doctor> GetAllDoctor()
        {
            return db.GetAllDoctor();
        }
        
        //添加医生信息
        public int InsertDoctorInfo(Doctor doctor)
        {
            return db.InsertDoctorInfo(doctor);
        }

        //修改医生信息
        public int UpdateDoctorInfo(Doctor doctor)
        {
            return db.UpdateDoctorInfo(doctor);
        }

        public int UpdateDoctorInfoExceptPsw(Doctor doctor)
        {
            return db.UpdateDoctorInfoExceptPsw(doctor);
        }

        //删除医生信息
        public int DeleteDoctorInfo(int id)
        {
            return db.DeleteDoctorInfo(id);
        }
    }
}
