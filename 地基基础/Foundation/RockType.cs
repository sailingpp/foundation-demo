using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public class RockType
    {
        private double frk;

        public double Frk
        {
            get { return frk; }
            set
            {
                frk = value;
            }
        }
        public RockType(double frk)
        {
            this.Frk = frk;
        }
        public string GetRockType()
        {
            if (this.Frk <= 5)
            {
                return "极软岩";
            }
            else if (this.Frk <= 15)
            {
                return "软岩";
            }
            else if (this.Frk <= 30)
            {
                return "较软岩";
            }
            else if (this.Frk <= 60)
            {
                return "较硬岩";
            }
            else
            {
                return "坚硬岩";
            }

        }

    }
}
