using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hospital
{
    public class Statistics
    {
        private int tid;
        private int count;
        private double max;
        private double min;
        private double avg;
        private Test test;

        public Statistics(int _tid, int _count, double _max, double _min, double _avg, Test _test)
        {
            this.Tid = _tid;
            this.Count = _count;
            this.Max = _max;
            this.Min = _min;
            this.Avg = _avg;
            this.Test = _test;
        }

        public int Tid
        {
            get { return tid; }
            set { tid = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public double Max
        {
            get { return max; }
            set { max = value; }
        }

        public double Min
        {
            get { return min; }
            set { min = value; }
        }

        public double Avg
        {
            get { return avg; }
            set { avg = value; }
        }

        public Test Test
        {
            get { return test; }
            set { test = value; }
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
