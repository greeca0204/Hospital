//**********************************************
//
//文件名：IOfficeService.cs
//
//描  述：科室信息管理接口-DAL
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
    public interface IOfficeService
    {
        Office GetOfficeById(int oid);//获取某个科室的记录
        List<Office> GetAllOffice();//获取科室信息
        int InsertOffice(Office office);//添加科室信息
        int UpdateOffice(Office office);//修改科室信息
        int GetOfficeCnt();//获取科室总数
    }
}
