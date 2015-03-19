//**********************************************
//
//文件名：AccessDoctorService.cs
//
//描  述：医生信息管理Access数据库实现
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
    public class AccessDoctorService:IDoctorService
    {
        OleDbConnection con = null;
        UserMd5 userMd5 = new UserMd5();
        public AccessDoctorService()
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }

        //医生登录
        public Doctor GetDoctor(string userName, string passWord)
        {
            Doctor doctor = null;
            try
            {
                string sql = "Select id,userName,[passWord],[rule],oid from tbl_doctor where userName=@name and passWord=@pwd";               
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@name", userName);
                    cmd.Parameters.AddWithValue("@pwd", userMd5.md5(passWord));
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            int id = Convert.ToInt32(dr["id"]);
                            EManage rule = (EManage)Convert.ToInt32(dr["rule"]);
                            int oid = Convert.ToInt32(dr["oid"]);

                            doctor = new Doctor(id, userName, passWord, rule, oid);
                        }
                    }
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
            return doctor;
        }

        //获取某个医生的记录
        public Doctor GetDoctorById(int id)
        {
            Doctor doctor = null;
            try
            {
                string sql = "Select id,userName,[passWord],[rule],oid from tbl_doctor where id=@id";                
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            string userName = (string)dr["userName"];
                            string passWord = (string)dr["passWord"];
                            EManage rule = (EManage)Convert.ToInt32(dr["rule"]);
                            int oid = Convert.ToInt32(dr["oid"]);

                            doctor = new Doctor(id, userName, passWord, rule, oid);
                        }
                    }
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
            return doctor;
        }

        //获取所有医生信息
        public List<Doctor> GetAllDoctor()
        {
            List<Doctor> list = null;
            try
            {
                string sql = "Select id,userName,[passWord],[rule],oid from tbl_doctor order by id desc";
                
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    using (OleDbDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (list == null)
                                list = new List<Doctor>();

                            int id = Convert.ToInt32(dr["id"]);
                            string userName = (string)dr["userName"];
                            string passWord = (string)dr["passWord"];
                            EManage rule = (EManage)Convert.ToInt32(dr["rule"]);
                            int oid = Convert.ToInt32(dr["oid"]);

                            Doctor doctor = new Doctor(id, userName, passWord, rule, oid);
                            list.Add(doctor);
                        }
                    }
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
            return list;
        }
    
        //添加医生信息
        public int InsertDoctorInfo(Doctor doctor)
        {
            int rs = 0;
            try
            {
                string sql = "insert into tbl_doctor(username,[passWord],[rule],oid) values (@userName,@passWord,@rule,@oid)";
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@userName", doctor.UserName);
                    cmd.Parameters.AddWithValue("@passWord", userMd5.md5(doctor.PassWord));
                    cmd.Parameters.AddWithValue("@rule", doctor.Rule);
                    cmd.Parameters.AddWithValue("@oid", Convert.ToInt32(doctor.Oid));
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

        //修改医生信息
        public int UpdateDoctorInfo(Doctor doctor)
        {
            int rs = 0;
            try
            {
                string sql = "update tbl_doctor set userName=@userName,[password]=@passWord,[rule]=@rule,oid=@oid where id=@id";
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@userName", doctor.UserName);
                    cmd.Parameters.AddWithValue("@passWord", userMd5.md5(doctor.PassWord));
                    cmd.Parameters.AddWithValue("@rule", doctor.Rule);
                    cmd.Parameters.AddWithValue("@oid", Convert.ToInt32(doctor.Oid));
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(doctor.Id));
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

        public int UpdateDoctorInfoExceptPsw(Doctor doctor)
        {
            int rs = 0;
            try
            {
                string sql = "update tbl_doctor set userName=@userName,[rule]=@rule,oid=@oid where id=@id";
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@userName", doctor.UserName);
                    cmd.Parameters.AddWithValue("@rule", doctor.Rule);
                    cmd.Parameters.AddWithValue("@oid", Convert.ToInt32(doctor.Oid));
                    cmd.Parameters.AddWithValue("@id", Convert.ToInt32(doctor.Id));
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

        //删除医生信息
        public int DeleteDoctorInfo(int id)
        {
            int rs = 0;
            try
            {
                string sql = "delete from tbl_doctor where id=@id";
                con.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
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
