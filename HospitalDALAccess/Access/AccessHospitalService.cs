//**********************************************
//
//文件名：AccessHospitalService.cs
//
//描  述：医院信息管理Access数据库实现
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
using System.Data.OleDb;

namespace Hospital.Access
{
    public class AccessHospitalService:IHospitalService
    {
        OleDbConnection con = null;
        public AccessHospitalService()
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }

        //获取医院信息
        public Hospital GetHospitalInfo()
        {           
            string sql = "Select cid,cName,cIntro,cLogo from tbl_hospital where cid=1";
            Hospital hospital = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {               
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int cid = dr.GetInt32(0);
                        string cName = dr.GetString(1);
                        string cIntro = dr.GetString(2);
                        string cLogo = dr.GetString(3);
                        hospital = new Hospital(cid, cName, cIntro, cLogo);
                    }
                }               
            }
            con.Close();
            return hospital;
        }
        
        //更新医院信息
        public int UpdateHospitalInfo(Hospital hospital)
        {
            int rs = 0;
            string sql = "update tbl_hospital set cName=@cName,cIntro=@cIntro,cLogo=@cLogo where cid=1";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cName", hospital.CName);
                cmd.Parameters.AddWithValue("@cIntro", hospital.CIntro);
                cmd.Parameters.AddWithValue("@cLogo", hospital.CLogo);             
                rs = cmd.ExecuteNonQuery();               
            }
            con.Close();
            return rs;
        }
    }
}
