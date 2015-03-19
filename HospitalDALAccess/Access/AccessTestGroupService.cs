using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace Hospital.Access
{
    class AccessTestGroupService : ITestGroupService
    {
        OleDbConnection con = null;
        public AccessTestGroupService()
        {
            string conStr = System.Configuration.ConfigurationManager.ConnectionStrings["accessStr"].ConnectionString;
            con = new OleDbConnection(conStr);
        }

        public int InsertTestGroup(string gName)
        {
            int rs = 0;
            string sql = "insert into tbl_group(gName) values(@gName)";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@gName", gName);
                rs = cmd.ExecuteNonQuery();
            }
            con.Close();
            return rs;
        }

        public int GetTestGroupCnt(string gName)
        {
            int chNum = 0;
            string sql = "Select count(gName) as chNum from tbl_group where gName=@gName";
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@gName", gName);  
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

        public int GetAllTestGroupCnt()
        {
            int chNum = 0;
            string sql = "Select count(*) as chNum from tbl_group";
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

        public List<TestGroup> GetTestGroup()
        {
            string sql = "Select gid,gName from tbl_group";
            List<TestGroup> list = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (list == null)
                            list = new List<TestGroup>();

                        int gid = Convert.ToInt32(dr["gid"]);
                        string gName = Convert.ToString(dr["gName"]);

                        TestGroup testGroup = Factory.CreateTestGroup(gid,gName);
                        list.Add(testGroup);
                    }
                }
            }
            con.Close();
            return list;
        }

        public TestGroup GetTestGroupBygid(int gid)
        {
            string sql = "Select gid,gName from tbl_group where gid=@gid";
            TestGroup testGroup = null;
            con.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@gid", gid);
                using (OleDbDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        string gName = Convert.ToString(dr["gName"]);
                        testGroup = new TestGroup(gid, gName);
                    }
                }
            }
            con.Close();
            return testGroup;
        }
    }
}
