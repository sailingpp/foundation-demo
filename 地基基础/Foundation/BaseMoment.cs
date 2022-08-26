using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public class BaseMoment
    {
        public double B { set; get; }
        public double L { set; get; }
        public double Bp { set; get; }
        public double Ap { set; get; }
        public double Pmax { set; get; }
        public double Pmin { set; get; }
        public double Gk { set; get; }
        public double Area 
        {
            get { return this.B * this.L; }
        }
        public double A1 { set; get; }
        public double P1 
        {
            get
            {
                return this.Pmax - (this.Pmax - this.Pmin) / B * this.A1;
            }
        }
        public BaseMoment(double a1,double b,double l,double bp,double ap,double pmax,double pmin,double gk)
        {
            this.A1 = a1;
            this.B = b;
            this.L = l;
            this.Bp = bp;
            this.Ap = ap;
            this.Pmax = pmax;
            this.Pmin = pmin;
            this.Gk = gk;
        }
        public double M1()
        {
            return this.A1 * this.A1 * ((2 * this.L + this.Ap) * (this.Pmax + this.P1 - 2 * this.Gk * 1.35 / this.Area)+(this.Pmax-this.P1)*this.L)/12.0;
        }
        public double M2()
        {
            return (this.L - this.Ap) * (this.L - this.Ap) * (this.B * 2 + this.Bp) * (this.Pmax + this.Pmin - 2 * this.Gk * 1.35 / this.Area) / 48.0;
        }

    }
}
