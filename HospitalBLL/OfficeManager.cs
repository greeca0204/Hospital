//**********************************************
//
//文件名：OfficeManager.cs
//
//描  述：科室数据操作-BLL
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
    public class OfficeManager
    {
        IOfficeService db = AbstractDALFactory.CreateDALService().GetIOfficeService();
        public OfficeManager()
        {
        }

        //获取某个科室的记录
        public Office GetOfficeById(int id)
        {
            return db.GetOfficeById(id);
        }

        //获取所有科室信息
        public List<Office> GetAllOffice()
        {
            return db.GetAllOffice();
        }
        
        //添加科室信息
        public int InsertOffice(Office office)
        {
            return db.InsertOffice(office);
        }

        //修改科室信息
        public int UpdateOffice(Office office)
        {
            return db.UpdateOffice(office);
        }

        //获取科室总数
        public int GetOfficeCnt()
        {
            return db.GetOfficeCnt();
        }
    }
}
