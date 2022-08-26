using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public class SoilIL
    {
        public double W { set; get; }
        public double Wp { set; get; }
        public double WL { set; get; }
        public double IL 
        {
            get 
            {
                return (this.W-this.Wp)/(this.WL-this.Wp) ;
            }
        }
        public SoilIL(double w, double wp, double wl)
        {
            this.W = w;
            this.Wp = wp;
            this.WL = wl;
        }
        public string JudgeSolid()
        {
            if (this.WL<=0)
            {
                return "坚硬";
            }
            else if (this.WL <= 0.25)
            {
                return "硬塑";
            }
            else if (this.WL <= 0.75)
            {
                return "软塑";
            }
            else
            {
                return "流塑";
            }

        }

    }
}
