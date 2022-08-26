using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public class RockCompletity
    {
        public double Vt { set; get; }
        public double Vk { set; get; }
        public RockCompletity(double vt, double vk)
        {
            this.Vk = vk;
            this.Vt = vt;
        }
        public string JudgeCompletity()
        {
            double v = (this.Vt / this.Vk) * (this.Vt / this.Vk);
            if (v<0.15)
            {
                return "极破碎";
            }
            else if (v<=0.35)
            {
                 return "破碎";
            }
            else if (v <= 0.55)
            {
                return "较破碎";
            }
            else if (v <= 0.75)
            {
                return "轻完整";
            }
            else
            {
                return "完整";
            }
        }
    }
}
