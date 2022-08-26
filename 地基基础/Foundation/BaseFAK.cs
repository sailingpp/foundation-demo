using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public class BaseFAK
    {
        public double Fak { set; get; }
        public double Nb { set; get; }
        public double Nd { set; get; }
        private double b;
        public double B 
        {
            set
            {
                if (value<3)
                {
                    b = 3;
                }
                else if (value > 6)
                {
                    b = 6;
                }
                else
                {
                    b = value;
                }

            }
            get 
            {
                return b;
            }
        }
        public double R{set;get;}
        public double Rm{set;get;}
        private double d;
        public double D 
        {
            set 
            {
                if (value < 0.5)
                {
                    d = 0.5;
                }
                else
                {
                    d = value;
                }

            }
            get { return d; }
        }
        public BaseFAK(double fak,double nb,double nd, double b,double r,double rm,double d)
        {
            this.B = b;
            this.D = d;
            this.Fak=fak;
            this.Nb = nb;
            this.Nd = nd;
            this.R = r;
            this.Rm = rm;
        }
        public double CalFa1()
        {
            return this.Fak + this.Nb * this.R * (this.B - 3) + this.Nd * this.Rm * (this.D - 0.5);
        }

        public double Mb { set; get; }
        public double Md { set; get; }
        public double Mc { set; get; }
        public double Ck { set; get; }
        public double Faik { set; get; }
        public BaseFAK(double mb, double md, double mc, double b, double r, double rm, double d,double ck,double faik)
        {
            this.B = b;
            this.D = d;
            this.R = r;
            this.Rm = rm;
            this.Mb = mb;
            this.Md = md;
            this.Mc = mc;
            this.Ck = ck;
            this.Faik = faik;
        }
        public double CalFa2(double b)
        {
            return this.Mb * this.R * b+ this.Md * this.Rm * this.D + this.Mc * this.Ck;
        }
        public double PsiR { set; get; }
        public double Frk { set; get; }
        public BaseFAK(double psir,double frk)
        {
            this.PsiR = psir;
            this.Frk = frk;
        }
        public double CalFa3()
        {
            return this.PsiR*this.Frk;
        }


    }

}
