using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public class Pile
    {
        
        public double Diameter { set; get; }
        public double Fc { set; get; }
        public double Cover { set; get; }
        public double Area
        {
            get
            {
                return Math.PI * this.Diameter * this.Diameter / 4;
            }
        }
        public double Fai { set; get; }
        public double Fy { set; get; }
        public double SteelAs;
        public Pile(double d, double fc, double fy, double SteelAs, double fai)
        {
            this.Diameter = d;
            this.Fc = fc;
            this.Fy = fy;
            this.SteelAs = SteelAs;
            this.Fai = fai;
        }
        public Pile(double d)
        {
            this.Diameter = d;
        }
        public double GetDemandPv()
        {
            return Math.Round(0.65 + (0.2 - 0.65) / (2000 - 300) * (this.Diameter - 300), 3);
        }
        public double GetSn(int n, int d)
        {
            return Math.Round((3.14 * (this.Diameter - this.Cover * 2) - n * d) / n, 3);
        }

        public double GetP()
        {
            return this.Fc*this.Area*this.Fai+0.9*this.Fy*this.SteelAs;
        }
    }
}

