//**********************************************
//
//�ļ�����Office.cs
//
//��  ����������Ϣ����-Model
//
//��  �ߣ��޼һ�
//
//����ʱ�䣺2014-7-14
//
//�޸���ʷ��2014-7-14  �޼һ� �޸�
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
