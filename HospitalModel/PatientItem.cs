//**********************************************
//
//文件名：PatientItem.cs
//
//描  述：病人心理测试详细信息表-Model
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
    public class PatientItem
    {
        private PatientDetail patientDetail;
        private Test test;     
       
        public PatientItem(PatientDetail _patientDetail,Test _test)
        {
            this.PatientDetail = _patientDetail;
            this.Test = _test;
        }

        public PatientDetail PatientDetail
        {
            get { return patientDetail; }
            set { patientDetail = value; }
        }

        public Test Test
        {
            get { return test; }
            set { test = value; }
        }

        public int Udid
        {
            get { return this.PatientDetail.Udid; }
        }

        public int Uid
        {
            get { return this.PatientDetail.Uid; }
        }

        public int Tid
        {
            get { return this.PatientDetail.Tid; }
        }

        public int Did
        {
            get { return this.PatientDetail.Did; }
        }

        public string Answer
        {
            get { return this.PatientDetail.Answer; }
        }

        public double Score
        {
            get { return this.PatientDetail.Score; }
        }

        public string Advice
        {
            get { return this.PatientDetail.Advice; }
        }

        public DateTime Testtime
        {
            get { return this.PatientDetail.Testtime; }
        }

        public string TNameItem
        {
            get { return this.PatientDetail.TNameItem; }
        }

        public int Tid2
        {
            get { return this.Test.TId; }
        }

        public string TName
        {
            get { return this.Test.TName; }
        }

        public int PId
        {
            get { return this.Test.PId; }
        }
    }
}
