//**********************************************
//
//文件名：Factory.cs
//
//描  述：模板工厂
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
    //简单工厂方法
    public class Factory
    {
        //患者信息工厂
        public static PatientInfo CreatePatientInfo(int _uid, string _hospiNum, string _userName, ESex _sex, DateTime _brithday, string _tel, string _address, int _testGroup, string _aD, string _oNum)
        {
            PatientInfo patientInfo = new PatientInfo(_uid, _hospiNum, _userName, _sex, _brithday, _tel, _address, _testGroup, _aD, _oNum);
            return patientInfo;
        }

        //心率变异信息工厂
        public static HeartRate CreateHeartRate(int _id, int _uid, double _physPress, double _psycPress, double _eei, double _ddi, double _dei, double _si, double _sympathetic1, double _parasympathetic1, double _sympathetic2, double _parasympathetic2, double _sympathetic3, double _parasympathetic3, double _sympathetic4, double _parasympathetic4, DateTime _dates, string _diaResult, string _eeiRs, string _ddiRs, string _deiRs, string _psiRs, string _msiRs, string _restingRs, string _breathRs, string _valsalvaRs, string _standingRs)
        {
            HeartRate heartrate = new HeartRate(_id, _uid, _physPress, _psycPress, _eei, _ddi, _dei, _si, _sympathetic1, _parasympathetic1, _sympathetic2, _parasympathetic2, _sympathetic3, _parasympathetic3, _sympathetic4, _parasympathetic4, _dates, _diaResult, _eeiRs, _ddiRs, _deiRs, _psiRs, _msiRs, _restingRs, _breathRs, _valsalvaRs, _standingRs);
            return heartrate;
        }

        //心理测试量表工厂
        public static Test CreateTest(int _tid, string _tName, int _pid)
        {
            Test test = new Test(_tid, _tName, _pid);
            return test;
        }

        //心理测试题目工厂
        public static Questions CreateQuestion(int _qid, int _tid, int _nid, string _question)
        {
            Questions questions = new Questions(_qid, _tid, _nid, _question);
            return questions;
        }

        //心理测试选项工厂
        public static Options CreateOption(int _oid, int _qid, char _option, string _title, double _score)
        {
            Options options = new Options(_oid, _qid, _option, _title, _score);
            return options;
        }

        //病历信息工厂
        public static PatientDetail CreatePatientDetail(int _udid,int _uid,int _tid,int _did,string _answer,double _score,string _advice,DateTime _testtime,string _tname)
        {
            PatientDetail patientDetail = new PatientDetail(_udid,_uid, _tid, _did, _answer, _score, _advice, _testtime,_tname);
            return patientDetail;
        }

        //测试结果工厂
        public static Acount CreateAcount(int _no, int _hmid, string _name, double _min, double _max, string _explain)
        {
            Acount acount = new Acount(_no, _hmid,_name, _min, _max, _explain);
            return acount;
        }

        //详细病历信息工厂
        public static PatientItem CreatePatientItem(PatientDetail _patientDetail, Test _test)
        {
            PatientItem patientItem = new PatientItem(_patientDetail, _test);
            return patientItem;
        }

        //测试组工厂
        public static TestGroup CreateTestGroup(int _gid,string _gName)
        {
            TestGroup testGroup = new TestGroup(_gid,_gName);
            return testGroup;
        }
    }
}
