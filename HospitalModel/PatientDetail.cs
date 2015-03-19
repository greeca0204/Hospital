//**********************************************
//
//文件名：PatientDetail.cs
//
//描  述：病人心理测试信息表-Model
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
    public class PatientDetail
    {
        private int udid;
        private int uid;
        private int tid;
        private int did;
        private string answer;
        private double score;
        private string advice;
        private DateTime testtime;
        private string tname;

        public PatientDetail(int _udid, int _uid, int _tid, int _did, string _answer, double _score, string _advice, DateTime _testtime, string _tname)
        {
            this.udid = _udid;
            this.Uid = _uid;
            this.Tid = _tid;
            this.Did = _did;
            this.Answer = _answer;
            this.Score = _score;
            this.Advice = _advice;
            this.Testtime = _testtime;
            this.tname = _tname;
            
        }

        public PatientDetail(int _uid, int _tid, int _did, string _answer, double _score, string _advice, DateTime _testtime,string tname)
            : this(0, _uid, _tid, _did, _answer, _score, _advice, _testtime,tname) { }

        public int Udid
        {
            get { return udid; }
        }       

        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        
        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }

        public int Did
        {
            get { return did; }
            set { did = value; }
        }
        
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }

        public double Score
        {
            get { return score; }
            set { score = value; }
        }      

        public string Advice
        {
            get { return advice; }
            set { advice = value; }
        }

        public DateTime Testtime
        {
            get { return testtime; }
            set { testtime = value; }
        }

        public string TNameItem
        {
            get { return tname; }
            set { tname = value; }
        }
    }
}
