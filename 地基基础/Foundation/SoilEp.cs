using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public class SoilEp
    {
        public double E1{set;get;}
        public double E2{set;get;}
        public double A12
        {
            get
            {
                return (this.E1-this.E2)/(0.200-0.100);
            }
        }
        public SoilEp(double e1,double e2)
        {
            this.E1 = e1;
            this.E2 = e2;
        }
        public string GetA12()
        {
            if (this.A12<0.1)
            {
                return "低压缩性土";
            }
            else if (this.A12 < 0.5)
            {
                return "中压缩性土";
            }
            else
            {
                return "高压缩性土";
            }

        }
    }
}
