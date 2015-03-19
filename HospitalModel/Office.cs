//**********************************************
//
//文件名：Office.cs
//
//描  述：科室信息管理-Model
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
    public class Office
    {
        private int oId;
        private string oName;
        private int cId;

        public Office(int _oId, string _oName, int _cId)
        {
            this.oId = _oId;
            this.OName = _oName;
            this.CId = _cId;
        }

        public Office(string _oName, int _cId)
            : this(0, _oName, _cId) { }

        public int OId
        {
            get { return oId; }           
        }

        public string OName
        {
            get { return oName; }
            set { oName = value; }
        }

        public int CId
        {
            get { return cId; }
            set { cId = value; }
        }       
    }
}
