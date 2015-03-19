using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    public class TestGroup
    {
        private int gid;
        private string gName;

        public TestGroup(int _gid, string _gName)
        {
            this.Gid = _gid;
            this.GName = _gName;
        }

        public TestGroup(string _gName)
            : this(0, _gName) { }

        public int Gid
        {
            get { return gid; }
            set { gid = value; }
        }
        
        public string GName
        {
            get { return gName; }
            set { gName = value; }
        }
    }
}
