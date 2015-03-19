//**********************************************
//
//文件名：Options.cs
//
//描  述：问题选项表-Model
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
    public class Options
    {
        private int oId;
        private int qId;
        private char option;
        private string title;
        private double score;

        public Options(int _oId, int _qId, char _option, string _title, double _score)
        {
            this.oId = _oId;
            this.QId = _qId;
            this.Option = _option;
            this.Title = _title;
            this.Score = _score;
        }

        public Options(int _qId, char _option, string _title, double _score)
            : this(0,_qId,_option,_title,_score) { }

        public int OId
        {
            get { return oId; }
        }

        public int QId
        {
            get { return qId; }
            set { qId = value; }
        }

        public char Option
        {
            get { return option; }
            set { option = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public double Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
