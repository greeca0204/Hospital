//**********************************************
//
//文件名：Account.cs
//
//描  述：量表测试结果管理-Model
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
    public class Acount
    {
        private int no;
        private int hmid;
        private string name;
        private double min;
        private double max;
        private string explain;

        public Acount(int _no, int _hmid, string _name, double _min, double _max, string _explain)
        {
            this.no = _no;
            this.Hmid = _hmid;
            this.Name = _name;
            this.Min = _min;
            this.Max = _max;
            this.Explain = _explain;
        }

        public Acount(int _hmid, string _name, double _min, double _max, string _explain)
            : this(0, _hmid, _name, _min, _max, _explain) { }

        public int No
        {
            get { return no; }
        }     

        public int Hmid
        {
            get { return hmid; }
            set { hmid = value; }
        }
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public double Min
        {
            get { return min; }
            set { min = value; }
        }

        public double Max
        {
            get { return max; }
            set { max = value; }
        }
        
        public string Explain
        {
            get { return explain; }
            set { explain = value; }
        }      
    }
}
