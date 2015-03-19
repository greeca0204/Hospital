//**********************************************
//
//文件名：Hospital.cs
//
//描  述：医院信息管理-Model
//
//作  者：罗家辉
//
//创建时间：2014-7-14
//
//修改历史：2014-7-14  罗家辉 修改
//**********************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Hospital
{
    public class Hospital
    {
        private int cid;
        private string cName;
        private string cIntro;
        private string cLogo;

        public Hospital(int _cid, string _cName, string _cIntro, string _cLogo)
        {
            this.cid = _cid;
            this.CName = _cName;
            this.CIntro = _cIntro;
            this.CLogo = _cLogo;
        }

        public Hospital(string _cName, string _cIntro, string _cLogo)
            : this(0, _cName, _cIntro, _cLogo) { }

        public int Cid
        {
            get { return cid; }
        }

        public string CName
        {
            get { return cName; }
            set { cName = value; }
        }

        public string CIntro
        {
            get { return cIntro; }
            set { cIntro = value; }
        }

        public string CLogo
        {
            get { return cLogo; }
            set { cLogo = value; }
        }
    }
}
