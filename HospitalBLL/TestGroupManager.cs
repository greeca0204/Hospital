using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    public class TestGroupManager
    {
        ITestGroupService db = AbstractDALFactory.CreateDALService().GetITestGroupService();
        public TestGroupManager()
        {         
        }

        public int InsertTestGroup(string gName)
        {
            return db.InsertTestGroup(gName);
        }

        public int GetTestGroupCnt(string gName)
        {
            return db.GetTestGroupCnt(gName);
        }

        public int GetAllTestGroupCnt()
        {
            return db.GetAllTestGroupCnt();
        }

        public List<TestGroup> GetTestGroup()
        {
            return db.GetTestGroup();
        }

        public TestGroup GetTestGroupBygid(int gid)
        {
            return db.GetTestGroupBygid(gid);
        }
    }
}
