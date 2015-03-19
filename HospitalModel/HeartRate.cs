//**********************************************
//
//文件名：HeartRate.cs
//
//描  述：心率变异信息管理-Model
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
    public class HeartRate
    {
        private int id;
        private int uid;
        private double physPress;
        private double psycPress;
        private double eei;
        private double ddi;
        private double dei;
        private double si;
        private double sympathetic1;
        private double parasympathetic1;
        private double sympathetic2;
        private double parasympathetic2;
        private double sympathetic3;
        private double parasympathetic3;
        private double sympathetic4;
        private double parasympathetic4;
        private DateTime dates;
        private string diaResult;
        private string eeiRs;
        private string ddiRs;
        private string deiRs;
        private string psiRs;
        private string msiRs;
        private string restingRs;
        private string breathRs;
        private string valsalvaRs;
        private string standingRs;

        public HeartRate(int _id, int _uid, double _physPress, double _psycPress, double _eei, double _ddi, double _dei, double _si, double _sympathetic1, double _parasympathetic1, double _sympathetic2, double _parasympathetic2, double _sympathetic3, double _parasympathetic3, double _sympathetic4, double _parasympathetic4, DateTime _dates, string _diaResult, string _eeiRs, string _ddiRs, string _deiRs, string _psiRs, string _msiRs, string _restingRs, string _breathRs, string _valsalvaRs, string _standingRs)
        {
            this.id = _id;
            this.Uid = _uid;
            this.PhysPress = _physPress;
            this.PsycPress = _psycPress;
            this.Eei = _eei;
            this.Ddi = _ddi;
            this.Dei = _dei;
            this.Si = _si;
            this.Sympathetic1 = _sympathetic1;
            this.Parasympathetic1 = _parasympathetic1;
            this.Sympathetic2 = _sympathetic2;
            this.Parasympathetic2 = _parasympathetic2;
            this.Sympathetic3 = _sympathetic3;
            this.Parasympathetic3 = _parasympathetic3;
            this.Sympathetic4 = _sympathetic4;
            this.Parasympathetic4 = _parasympathetic4;
            this.Dates = _dates;
            this.DiaResult = _diaResult;

            this.EeiRs = _eeiRs;
            this.DdiRs = _ddiRs;
            this.DeiRs = _deiRs;
            this.PsiRs = _psiRs;
            this.MsiRs = _msiRs;
            this.RestingRs = _restingRs;
            this.BreathRs = _breathRs;
            this.ValsalvaRs = _valsalvaRs;
            this.StandingRs = _standingRs;
        }

        public HeartRate(int _uid, double _physPress, double _psycPress, double _eei, double _ddi, double _dei, double _si, double _sympathetic1, double _parasympathetic1, double _sympathetic2, double _parasympathetic2, double _sympathetic3, double _parasympathetic3, double _sympathetic4, double _parasympathetic4, DateTime _dates, string _diaResult, string _eeiRs, string _ddiRs, string _deiRs, string _psiRs, string _msiRs, string _restingRs, string _breathRs, string _valsalvaRs, string _standingRs)
            : this(0,_uid, _physPress, _psycPress, _eei, _ddi, _dei, _si,_sympathetic1,_parasympathetic1,_sympathetic2, _parasympathetic2, _sympathetic3,_parasympathetic3, _sympathetic4,_parasympathetic4, _dates,_diaResult, _eeiRs, _ddiRs, _deiRs, _psiRs, _msiRs, _restingRs, _breathRs, _valsalvaRs, _standingRs) { }

        public int Id
        {
            get { return id; }
        }

        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }

        public double PhysPress
        {
            get { return physPress; }
            set { physPress = value; }
        }

        public double PsycPress
        {
            get { return psycPress; }
            set { psycPress = value; }
        }

        public double Eei
        {
            get { return eei; }
            set { eei = value; }
        }

        public double Ddi
        {
            get { return ddi; }
            set { ddi = value; }
        }

        public double Dei
        {
            get { return dei; }
            set { dei = value; }
        }

        public double Si
        {
            get { return si; }
            set { si = value; }
        }

        public double Sympathetic1
        {
            get { return sympathetic1; }
            set { sympathetic1 = value; }
        }

        public double Parasympathetic1
        {
            get { return parasympathetic1; }
            set { parasympathetic1 = value; }
        }

        public double Sympathetic2
        {
            get { return sympathetic2; }
            set { sympathetic2 = value; }
        }

        public double Parasympathetic2
        {
            get { return parasympathetic2; }
            set { parasympathetic2 = value; }
        }

        public double Sympathetic3
        {
            get { return sympathetic3; }
            set { sympathetic3 = value; }
        }

        public double Parasympathetic3
        {
            get { return parasympathetic3; }
            set { parasympathetic3 = value; }
        }

        public double Sympathetic4
        {
            get { return sympathetic4; }
            set { sympathetic4 = value; }
        }

        public double Parasympathetic4
        {
            get { return parasympathetic4; }
            set { parasympathetic4 = value; }
        }

        public DateTime Dates
        {
            get { return dates; }
            set { dates = value; }
        }

        public string DiaResult
        {
            get { return diaResult; }
            set { diaResult = value; }
        }

        public string EeiRs
        {
            get { return eeiRs; }
            set { eeiRs = value; }
        }

        public string DdiRs
        {
            get { return ddiRs; }
            set { ddiRs = value; }
        }

        public string DeiRs
        {
            get { return deiRs; }
            set { deiRs = value; }
        }

        public string PsiRs
        {
            get { return psiRs; }
            set { psiRs = value; }
        }

        public string MsiRs
        {
            get { return msiRs; }
            set { msiRs = value; }
        }

        public string RestingRs
        {
            get { return restingRs; }
            set { restingRs = value; }
        }

        public string BreathRs
        {
            get { return breathRs; }
            set { breathRs = value; }
        }

        public string ValsalvaRs
        {
            get { return valsalvaRs; }
            set { valsalvaRs = value; }
        }

        public string StandingRs
        {
            get { return standingRs; }
            set { standingRs = value; }
        }
    }
}
