//**********************************************
//
//文件名：AccessOfficeService.cs
//
//描  述：科室信息管理Access数据库实现
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
    public class AccessOfficeService:IOfficeService
    {
        OleDbConnection con = null;
        public AccessOfficeService()
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }

        //获取某个科室的记录
        public Office GetOfficeById(int oId)
        {
            string sql = "Select oId,oName,cid from tbl_office where oId=@oId";
            Office office = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@oId", oId);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        string oName = (string)dr["oName"];
                        int cid = Convert.ToInt32(dr["cid"]);

                        office = new Office(oId, oName, cid);
                    }
                }
            }
            con.Close();
            return office;
        }

        //获取所有科室信息
        public List<Office> GetAllOffice()
        {
            string sql = "Select oId,oName,cid from tbl_office";
            List<Office> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<Office>();

                        int oId = Convert.ToInt32(dr["oId"]);
                        string oName = (string)dr["oName"];
                        int cid = Convert.ToInt32(dr["cid"]);

                        Office office = new Office(oId, oName, cid);
                        list.Add(office);
                    }
                }
            }
            con.Close();
            return list;
        }
    
        //添加科室信息
        public int InsertOffice(Office office)
        {
            int rs = 0;
            string sql = "insert into tbl_office(oName,cid) values (@oName,1)";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@oName", office.OName);
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            return rs;
        }

        //修改科室信息
        public int UpdateOffice(Office office)
        {
            int rs = 0;
            string sql = "update tbl_office set oName=@oName where oId=@oId";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@oName", office.OName);
                cmd.Parameters.AddWithValue("@oId", Convert.ToInt32(office.OId));
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            return rs;
        }

        //获取科室总数
        public int GetOfficeCnt()
        {
            int chNum = 0;
            string sql = "Select count(*) as chNum from tbl_office";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        chNum = Convert.ToInt32(dr["chNum"]);
                    }
                }
            }
            con.Close();
            return chNum;
        }

        public int DeleteOffice(int oId)
        {
            int rs = 0;
            try
            {
                string sql = "delete from tbl_office where oId=@oId";
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@oId", oId);
                    rs = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                con.Close();
            }
            return rs;
        }
    }
}
