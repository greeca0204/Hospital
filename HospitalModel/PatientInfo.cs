//**********************************************
//
//文件名：PatientInfo.cs
//
//描  述：患者基本信息管理-Model
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
    public class PatientInfo
    {
        private int uid;
        private string hospiNum;
        private string userName;
        private ESex sex;
        private DateTime brithday;
        private string tel;
        private string address;
        private int testGroup;
        private string aD;
        private string oNum;

        public PatientInfo(int _uid, string _hospiNum, string _userName, ESex _sex, DateTime _brithday, string _tel, string _address, int _testGroup,string _aD,string _oNum)
        {
            this.uid = _uid;
            this.hospiNum = _hospiNum;
            this.UserName = _userName;
            this.Sex = _sex;
            this.Brithday = _brithday;
            this.Tel = _tel;
            this.Address = _address;
            this.TestGroup = _testGroup;
            this.AD = _aD;
            this.ONum = _oNum;
        }

        public PatientInfo(string _hospiNum, string _userName, ESex _sex, DateTime _brithday, string _tel, string _address, int _testGroup, string _aD, string _oNum)
            :this(0, _hospiNum, _userName, _sex, _brithday, _tel, _address,_testGroup, _aD,_oNum){ }

        public int Uid
        {
            get { return uid; }     
        }

        public string HospiNum
        {
            get { return hospiNum; }
            set { hospiNum = value; }
        }
        
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        
        public ESex Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        
        public DateTime Brithday
        {
            get { return brithday; }
            set { brithday = value; }
        }
        
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
       
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public int TestGroup
        {
            get { return testGroup; }
            set { testGroup = value; }
        }
        
        public string AD
        {
            get { return aD; }
            set { aD = value; }
        }

        public string ONum
        {
            get { return oNum; }
            set { oNum = value; }
        }

        public int Age
        {
            get
            {
                int intDay = DateTime.Now.Year - this.Brithday.Year;
                if (intDay <= 1)
                    intDay = 0;
                 return intDay;
            }
        }
    }
}
