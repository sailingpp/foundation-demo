using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public static class MathTools
    {
        public static double Deg{set;get;}


        public static double Rad { set; get; }

        public static double RadToDeg(double d)
        {
            return d * 180 / Math.PI;
        }
        public static double DegToRad(double r)
        {
            return r / 180 * Math.PI;
        }
    }
}
