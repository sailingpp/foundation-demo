using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    /// <summary>
    /// 计算筏板
    /// </summary>
    public class Plate
    {
        public double Fl { set; get; }
        public double Um { set; get; }
        public double H0 { set; get; }
        public double Aflas { set; get; }
        public double Munb { set; get; }
        public double Cab { set; get; }
        public double Is { set; get; }
        public Plate(double fl,double um,double h0,double aflas,double cab,double Is,double munb)
        {
            this.Fl = fl;
            this.Um = um;
            this.H0 = h0;
            this.Aflas = aflas;
            this.Cab = cab;
            this.Is = Is;
            this.Munb = munb;
        }
        public double GetTaoMax()
        {
            return this.Fl / this.Um / this.H0 + this.Aflas * this.Munb * this.Cab / this.Is;
        }
    }
}
