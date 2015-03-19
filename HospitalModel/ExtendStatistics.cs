using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    public class ExtendStatistics
    {
        private int tid;
        private string tName;
        private string ageGroup;   
        private int cnt;
        private double avgv;
        private double maxv;
        private double minv;
        private ESex sex;
        private int testGroup;

        public ExtendStatistics(int _tid, string _tName, string _ageGroup, int _cnt, double _avgv, double _maxv, double _minv, ESex _sex, int _testGroup)
        {
            this.Tid = _tid;
            this.TName = _tName;
            this.AgeGroup = _ageGroup;
            this.Cnt = _cnt;
            this.Avgv = _avgv;
            this.Maxv = _maxv;
            this.Minv = _minv;
            this.Sex = _sex;
            this.TestGroup = _testGroup;
        }

        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }

        public string TName
        {
            get { return tName; }
            set { tName = value; }
        }

        public string AgeGroup
        {
            get { return ageGroup; }
            set { ageGroup = value; }
        }

        public int Cnt
        {
            get { return cnt; }
            set { cnt = value; }
        }

        public double Avgv
        {
            get { return avgv; }
            set { avgv = value; }
        }

        public double Maxv
        {
            get { return maxv; }
            set { maxv = value; }
        }

        public double Minv
        {
            get { return minv; }
            set { minv = value; }
        }

        public ESex Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        public int TestGroup
        {
            get { return testGroup; }
            set { testGroup = value; }
        }
    }
}
