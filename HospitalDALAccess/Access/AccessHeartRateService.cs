//**********************************************
//
//文件名：AccessHeartRateService.cs
//
//描  述：心率变异信息管理Access数据库实现
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
    public class AccessHeartRateService : IHeartRateService
    {
        OleDbConnection con = null;
        public AccessHeartRateService()
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }

        //获取某条心率变异信息
        public HeartRate GetOneHeartRate(int id)
        {           
            string sql = "Select * from tbl_HeartRate where id=@id";
            HeartRate heartRate = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);                
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        int hid = Convert.ToInt32(dr["id"]);
                        int uid = Convert.ToInt32(dr["uid"]);
                        double physPress = Convert.ToDouble(dr["physPress"]);
                        double psycPress = Convert.ToDouble(dr["psycPress"]);
                        double eei = Convert.ToDouble(dr["eei"]);
                        double ddi = Convert.ToDouble(dr["ddi"]);
                        double dei = Convert.ToDouble(dr["dei"]);
                        double si = Convert.ToDouble(dr["si"]);
                        double sympathetic1 = Convert.ToDouble(dr["sympathetic1"]);
                        double parasympathetic1 = Convert.ToDouble(dr["parasympathetic1"]);
                        double sympathetic2 = Convert.ToDouble(dr["sympathetic2"]);
                        double parasympathetic2 = Convert.ToDouble(dr["parasympathetic2"]);
                        double sympathetic3 = Convert.ToDouble(dr["sympathetic3"]);
                        double parasympathetic3 = Convert.ToDouble(dr["parasympathetic3"]);
                        double sympathetic4 = Convert.ToDouble(dr["sympathetic4"]);
                        double parasympathetic4 = Convert.ToDouble(dr["parasympathetic4"]);
                        DateTime dates = Convert.ToDateTime(dr["dates"]);
                        string diaResult = Convert.ToString(dr["diaResult"]);
                        string eeiRs = Convert.ToString(dr["eeiRs"]);
                        string ddiRs = Convert.ToString(dr["ddiRs"]);
                        string deiRs = Convert.ToString(dr["deiRs"]);
                        string psiRs = Convert.ToString(dr["psiRs"]);
                        string msiRs = Convert.ToString(dr["msiRs"]);
                        string restingRs = Convert.ToString(dr["restingRs"]);
                        string breathRs = Convert.ToString(dr["breathRs"]);
                        string valsalvaRs = Convert.ToString(dr["valsalvaRs"]);
                        string standingRs = Convert.ToString(dr["standingRs"]);

                        heartRate = new HeartRate(id, uid, physPress, psycPress, eei, ddi, dei, si, sympathetic1, parasympathetic1,
                sympathetic2, parasympathetic2, sympathetic3, parasympathetic3, sympathetic4, parasympathetic4, dates, diaResult, eeiRs, ddiRs, deiRs, psiRs, msiRs, restingRs, breathRs, valsalvaRs, standingRs);
                    }
                }             
            }
            con.Close();
            return heartRate;
        }

        //获取某人心率变异信息
        public List<HeartRate> GetOneHeartRateByUid(int userid)
        {
            string sql = "Select * from tbl_HeartRate where uid=@uid order by dates desc";
            List<HeartRate> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@uid", userid);               
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<HeartRate>();

                        int id = Convert.ToInt32(dr["id"]);
                        int uid = Convert.ToInt32(dr["uid"]);
                        double physPress = Convert.ToDouble(dr["physPress"]);
                        double psycPress = Convert.ToDouble(dr["psycPress"]);
                        double eei = Convert.ToDouble(dr["eei"]);
                        double ddi = Convert.ToDouble(dr["ddi"]);
                        double dei = Convert.ToDouble(dr["dei"]);
                        double si = Convert.ToDouble(dr["si"]);
                        double sympathetic1 = Convert.ToDouble(dr["sympathetic1"]);
                        double parasympathetic1 = Convert.ToDouble(dr["parasympathetic1"]);
                        double sympathetic2 = Convert.ToDouble(dr["sympathetic2"]);
                        double parasympathetic2 = Convert.ToDouble(dr["parasympathetic2"]);
                        double sympathetic3 = Convert.ToDouble(dr["sympathetic3"]);
                        double parasympathetic3 = Convert.ToDouble(dr["parasympathetic3"]);
                        double sympathetic4 = Convert.ToDouble(dr["sympathetic4"]);
                        double parasympathetic4 = Convert.ToDouble(dr["parasympathetic4"]);
                        DateTime dates = Convert.ToDateTime(dr["dates"]);
                        string diaResult = Convert.ToString(dr["diaResult"]);
                        string eeiRs = Convert.ToString(dr["eeiRs"]);
                        string ddiRs = Convert.ToString(dr["ddiRs"]);
                        string deiRs = Convert.ToString(dr["deiRs"]);
                        string psiRs = Convert.ToString(dr["psiRs"]);
                        string msiRs = Convert.ToString(dr["msiRs"]);
                        string restingRs = Convert.ToString(dr["restingRs"]);
                        string breathRs = Convert.ToString(dr["breathRs"]);
                        string valsalvaRs = Convert.ToString(dr["valsalvaRs"]);
                        string standingRs = Convert.ToString(dr["standingRs"]);

                        HeartRate heartRate = Factory.CreateHeartRate(id, uid, physPress, psycPress, eei, ddi, dei, si, sympathetic1, parasympathetic1,
                sympathetic2, parasympathetic2, sympathetic3, parasympathetic3, sympathetic4, parasympathetic4, dates, diaResult, eeiRs, ddiRs, deiRs, psiRs, msiRs, restingRs, breathRs, valsalvaRs, standingRs);
                        list.Add(heartRate);
                    }
                }               
            }
            con.Close();
            return list;
        }

        //插入心率变异信息
        public int InsertHeartRate(HeartRate heartRate)
        {
            int rs = 0;
            string sql = "insert into tbl_HeartRate(uid,PhysPress,PsycPress,EEI,DDI,DEI,SI,Sympathetic1,Parasympathetic1,Sympathetic2,Parasympathetic2,Sympathetic3,Parasympathetic3,Sympathetic4,Parasympathetic4,dates,diaResult,eeiRs,ddiRs,deiRs,psiRs,msiRs,restingRs,breathRs,valsalvaRs,standingRs) values (@uid,@physPress,@psycPress,@eei,@ddi,@dei,@si,@sympathetic1,@parasympathetic1,@sympathetic2,@parasympathetic2,@sympathetic3,@parasympathetic3,@sympathetic4,@parasympathetic4,@dates,@diaResult,@eeiRs,@ddiRs,@deiRs,@psiRs,@msiRs,@restingRs,@breathRs,@valsalvaRs,@standingRs)";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@uid", heartRate.Uid);
                cmd.Parameters.AddWithValue("@physPress", heartRate.PhysPress);
                cmd.Parameters.AddWithValue("@psycPress", heartRate.PsycPress);
                cmd.Parameters.AddWithValue("@eei", heartRate.Eei);
                cmd.Parameters.AddWithValue("@ddi", heartRate.Ddi);
                cmd.Parameters.AddWithValue("@dei", heartRate.Dei);
                cmd.Parameters.AddWithValue("@si", heartRate.Si);
                cmd.Parameters.AddWithValue("@sympathetic1", heartRate.Sympathetic1);
                cmd.Parameters.AddWithValue("@parasympathetic1", heartRate.Parasympathetic1);
                cmd.Parameters.AddWithValue("@sympathetic2", heartRate.Sympathetic2);
                cmd.Parameters.AddWithValue("@parasympathetic2", heartRate.Parasympathetic2);
                cmd.Parameters.AddWithValue("@sympathetic3", heartRate.Sympathetic3);
                cmd.Parameters.AddWithValue("@parasympathetic3", heartRate.Parasympathetic3);
                cmd.Parameters.AddWithValue("@sympathetic4", heartRate.Sympathetic4);
                cmd.Parameters.AddWithValue("@parasympathetic4", heartRate.Parasympathetic4);
                cmd.Parameters.AddWithValue("@dates", heartRate.Dates);
                cmd.Parameters.AddWithValue("@diaResult", heartRate.DiaResult);
                cmd.Parameters.AddWithValue("@eeiRs", heartRate.EeiRs);
                cmd.Parameters.AddWithValue("@ddiRs", heartRate.DdiRs);
                cmd.Parameters.AddWithValue("@deiRs", heartRate.DeiRs);
                cmd.Parameters.AddWithValue("@psiRs", heartRate.PsiRs);
                cmd.Parameters.AddWithValue("@msiRs", heartRate.MsiRs);
                cmd.Parameters.AddWithValue("@restingRs", heartRate.RestingRs);
                cmd.Parameters.AddWithValue("@breathRs", heartRate.BreathRs);
                cmd.Parameters.AddWithValue("@valsalvaRs", heartRate.ValsalvaRs);
                cmd.Parameters.AddWithValue("@standingRs", heartRate.StandingRs);
                rs = cmd.ExecuteNonQuery();                
            }
            con.Close();
            return rs;
        }

        //修改心率变异信息
        public int UpdateHeartRate(HeartRate heartRate)
        {
            int rs = 0;
            string sql = "update tbl_HeartRate set PhysPress=@physPress,PsycPress=@psycPress,EEI=@eei,DDI=@ddi,DEI=@dei,SI=@si,Sympathetic1=@sympathetic1,Parasympathetic1=@parasympathetic1,Sympathetic2=@sympathetic2,Parasympathetic2=@parasympathetic2,Sympathetic3=@sympathetic3,Parasympathetic3=@parasympathetic3,Sympathetic4=@sympathetic4,Parasympathetic4=@parasympathetic4,diaResult=@diaResult,eeiRs=@eeiRs,ddiRs=@ddiRs,deiRs=@deiRs,psiRs=@psiRs,msiRs=@msiRs,restingRs=@restingRs,breathRs=@breathRs,valsalvaRs=@valsalvaRs,standingRs=@standingRs where id=@id";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@physPress", heartRate.PhysPress);
                cmd.Parameters.AddWithValue("@psycPress", heartRate.PsycPress);
                cmd.Parameters.AddWithValue("@eei", heartRate.Eei);
                cmd.Parameters.AddWithValue("@ddi", heartRate.Ddi);
                cmd.Parameters.AddWithValue("@dei", heartRate.Dei);
                cmd.Parameters.AddWithValue("@si", heartRate.Si);
                cmd.Parameters.AddWithValue("@sympathetic1", heartRate.Sympathetic1);
                cmd.Parameters.AddWithValue("@parasympathetic1", heartRate.Parasympathetic1);
                cmd.Parameters.AddWithValue("@sympathetic2", heartRate.Sympathetic2);
                cmd.Parameters.AddWithValue("@parasympathetic2", heartRate.Parasympathetic2);
                cmd.Parameters.AddWithValue("@sympathetic3", heartRate.Sympathetic3);
                cmd.Parameters.AddWithValue("@parasympathetic3", heartRate.Parasympathetic3);
                cmd.Parameters.AddWithValue("@sympathetic4", heartRate.Sympathetic4);
                cmd.Parameters.AddWithValue("@parasympathetic4", heartRate.Parasympathetic4);
                cmd.Parameters.AddWithValue("@diaResult", heartRate.DiaResult);
                cmd.Parameters.AddWithValue("@eeiRs", heartRate.EeiRs);
                cmd.Parameters.AddWithValue("@ddiRs", heartRate.DdiRs);
                cmd.Parameters.AddWithValue("@deiRs", heartRate.DeiRs);
                cmd.Parameters.AddWithValue("@psiRs", heartRate.PsiRs);
                cmd.Parameters.AddWithValue("@msiRs", heartRate.MsiRs);
                cmd.Parameters.AddWithValue("@restingRs", heartRate.RestingRs);
                cmd.Parameters.AddWithValue("@breathRs", heartRate.BreathRs);
                cmd.Parameters.AddWithValue("@valsalvaRs", heartRate.ValsalvaRs);
                cmd.Parameters.AddWithValue("@standingRs", heartRate.StandingRs);
                cmd.Parameters.AddWithValue("@id", heartRate.Id);                
                rs = cmd.ExecuteNonQuery();              
            }
            con.Close();
            return rs;
        }
        
        //删除心率变异信息
        public int DeleteHeartRate(int id)
        {
            int rs = 0;
            string sql = "delete from tbl_HeartRate where id=@id";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);              
                rs = cmd.ExecuteNonQuery();               
            }
            con.Close();
            return rs;
        }       
    }
}
