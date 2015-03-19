using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    public class TestManager
    {
        ITestService db = AbstractDALFactory.CreateDALService().GetITestService();
        public TestManager()
        {
        }

        public int updateTestByUsual(int tid,bool uflag)
        {
            return db.updateTestByUsual(tid,uflag);
        }

        public int updateTestByHUsual(int tid, bool hflag)
        {
            return db.updateTestByHUsual(tid,hflag);
        }
        public int updateTestBySUsual(int tid, bool sflag)
        {
            return db.updateTestBySUsual(tid, sflag);
        }
        public List<Test> GetTestByItem()
        {
            return db.GetTestByItem();
        }
    }
}
