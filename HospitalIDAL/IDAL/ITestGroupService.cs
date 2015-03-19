using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    public interface ITestGroupService
    {
        int InsertTestGroup(string gName);
        int GetTestGroupCnt(string gName);
        int GetAllTestGroupCnt();
        List<TestGroup> GetTestGroup();
        TestGroup GetTestGroupBygid(int gid);
    }
}