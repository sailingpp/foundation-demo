using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public partial class SoilPress
    {

        public double C { set; get; }
        public double Fai { set; get; }
        public double K0
        {
            get
            {
                return 1 - Math.Sin(MathTools.RadToDeg(this.Fai));
            }
        }
        public double Ka
        {
            get
            {
                double temp = 45 - this.Fai / 2;
                return Math.Tan(temp) * Math.Tan(temp);
            }
        }
        public double Kp
        {
            get
            {
                double temp = 45 + this.Fai / 2;
                return Math.Tan(temp) * Math.Tan(temp);
            }
        }
        public SoilPress(double c, double fai)
        {
            this.C = c;
            this.Fai = fai;
        }
    }

    public partial class SoilPress
    {
        private double alfa;
        public double Alfa
        {
            set
            {
                alfa = MathTools.DegToRad(value); ;
            }
            get
            {
                return alfa;
            }
        }
        private double beta;
        public double Beta
        {
            set
            {
                beta = MathTools.DegToRad(value); ;
            }
            get
            {
                return beta;
            }
        }
        private double psi;
        public double Psi
        {
            set
            {
                psi = MathTools.DegToRad(value); ;
            }
            get
            {
                return psi;
            }
        }
        private double sita;
        public double Sita
        {
            set
            {
                sita = MathTools.DegToRad(value); ;
            }
            get
            {
                return sita;
            }
        }
        public double Q { set; get; }
        public double R { set; get; }
        public double H { set; get; }
        public double Yita
        {
            get { return 2 * this.C / this.R * this.H; }
        }
        public double AB
        {
            get { return Math.Sin(this.Alfa + this.Beta); }
        }
        public double AS
        {
            get
            {
                return Math.Sin(this.Alfa - this.Beta);
            }
        }
        public double PB
        {
            get
            {
                return Math.Sin(this.Psi - this.Beta);
            }
        }
        public double ABPS
        {
            get
            {
                return Math.Sin(this.Alfa + this.Beta - this.Psi - this.Beta);
            }
        }
        public double PS
        {
            get { return Math.Sin(this.Psi + this.Sita); }
        }
        public double Kq
        {
            get { return 1 + 2 * this.Q * Math.Sin(this.Alfa)*Math.Cos(this.Beta)/(this.R*this.H*Math.Sin(this.Alfa+this.Beta)); }
        }
        public double T1
        {
            get
            {
                return this.AB/(Math.Sin(this.Alfa))/(Math.Sin(this.Alfa)/this.ABPS/this.ABPS);
            }
        }
        public double T2
        {
            get
            {
                return this.Kq * (this.AB * this.AS + this.PS * this.PB);
            }
        }
        public double T3
        {
            get 
            {
                return 2 * this.Yita * Math.Sin(this.Alfa) * Math.Cos(this.Psi) * Math.Cos(this.Alfa + this.Beta - this.Psi - this.Beta);
            }
        }
        public double T4 
        {
            get
            {
                return this.Kq*this.AS*this.PS+this.Yita*Math.Sin(this.Alfa)*Math.Cos(this.Psi);
            }
        }
        public double T5
        {
            get
            {
                return this.Kq * this.AB * this.PB + this.Yita * Math.Sin(this.Alfa) * Math.Cos(this.Psi);
            }
        }
        
        public SoilPress(double alfa,double beta,double psi,double sita,double r,double h,double c,double q)
        {
            this.Alfa = alfa;
            this.Beta = beta;
            this.Psi = psi;
            this.Sita = sita;
            this.R = r;
            this.H = h;
            this.C = c;
            this.Q = q;
        }

        public double CalSoilKa()
        {
            return this.T1 * (this.T2 + this.T3 - 2 * (this.T4 * Math.Sqrt(this.T5)));
        }
    }
}
