using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
   public  class Steel
    {
       public string Name { set; get; }
        public double Fy { set; get; }
        public double Fyk { set; get; }
        public double Fyp { set; get; }
        public double Fstk { set; get; }
        public double Es { set; get; }
        public double Vc { set; get; }
        public int N { set; get; }
        public int D { set; get; }
        public double singleArea 
        {
            get
            {
                return Math.PI * this.D * this.D / 4;
            }
        }
        public double AllArea
        {
            get
            {
                return this.N*Math.PI * this.D * this.D / 4;
            }
        }
        public Steel(string name,double fy,double fyk,double fyp,double fstk,double es,double vc)
        {
            this.Name = name;
            this.Fy = fy;
            this.Fyk = fyk;
            this.Fyp = fyp;
            this.Fstk = fstk;
            this.Es = es;
            this.Vc = vc;
        }

        public Steel()
        { }
    }
}
