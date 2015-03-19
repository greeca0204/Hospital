//**********************************************
//
//文件名：Test.cs
//
//描  述：量表表-Model
//
//作  者：罗家辉
//
//创建时间：2014-7-14
//
//修改历史：2014-7-14  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    public class Test
    {
        private int tId;
        private string tName;
        private int pId;
        private bool uflag;
        private bool hflag;
        private bool sflag;

        public Test(int _tId, string _tName, int _pId, bool _uflag, bool _hflag, bool _sflag)
        {
            this.tId = _tId;
            this.tName = _tName;
            this.pId = _pId;
            this.uflag = _uflag;
            this.hflag = _hflag;
            this.sflag = _sflag;
        }

        public Test(int _tId, string _tName, int _pId)
        {
            this.tId = _tId;
            this.tName = _tName;
            this.pId = _pId;
        }

        /*
        public Test(string _tName, int _pId)
            : this(0, _tName, _pId) { }
        */
        public int TId
        {
            get { return tId; }
        }

        public string TName
        {
            get { return tName; }
            set { tName = value;}
        }

        public int PId
        {
          get { return pId; }
          set { pId = value; }
        }

        public bool Uflag
        {
            get { return uflag; }
            set { uflag = value; }
        }

        public bool Hflag
        {
            get { return hflag; }
            set { hflag = value; }
        }

        public bool Sflag
        {
            get { return sflag; }
            set { sflag = value; }
        }
    }
}
