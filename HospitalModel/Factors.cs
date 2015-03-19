//**********************************************
//
//文件名：Factors.cs
//
//描  述：因子表-Model
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
    public class Factors
    {
        private int fId;
        private int qId;
        private int factorNO;
        private int factorNum;

        public Factors(int _fId, int _qId, int _factorNo, int _factorNum)
        {
            this.fId = _fId;
            this.QId = _qId;
            this.FactorNo= _factorNo;
            this.FactorNum = _factorNum;
        }

        public Factors(int _qid, int _factorNo, int _factorNum)
            : this(0, _qid, _factorNo, _factorNum) { }

        public int FId
        {
            get { return fId; }
        }

        public int QId
        {
            get { return qId; }
            set { qId = value; }
        }

        public int FactorNo
        {
            get { return factorNO; }
            set { factorNO = value; }
        }

        public int FactorNum
        {
            get { return factorNum; }
            set { factorNum = value; }
        }
    }
}
