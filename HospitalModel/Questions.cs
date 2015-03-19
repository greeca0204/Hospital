//**********************************************
//
//文件名：Questions.cs
//
//描  述：问题表-Model
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
    public class Questions
    {
        private int qId;
        private int tId;
        private int nId;
        private string question;

        public Questions(int _qId, int _tId, int _nId, string _question)
        {
            this.qId = _qId;
            this.TId = _tId;
            this.NId = _nId;
            this.Question = _question;
        }

        public Questions(int _tId, int _nId, string _question)
            : this(0, _tId, _nId, _question) { }       

        public int QId
        {
            get { return qId;  }
        }

        public int TId
        {
            get { return tId; }
            set { tId = value; }
        }

        public int NId
        {
            get { return nId; }
            set { nId = value; }
        }

        public string Question
        {
            get { return question; }
            set { question = value; }
        }         
    }
}
