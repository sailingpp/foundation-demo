using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public class BasePk
    {
        public double B { set; get; }
        public double L { set; get; }
        public double D { set; get; }
        public double Fk { set; get; }
        public double Vk { set; get; }
        public double Mk { set; get; }
        public double Rm { set; get; }
        public double E0
        {
            get
            {
                return (this.Mk + this.Vk * this.D) / (this.Fk + this.Gk);
            }
        }
        public double Area
        {
            get { return this.B * this.L; }
        }
        public double Wx
        {
            get { return this.B*this.L*this.L/6.0;}
        }
   
        public double Gk 
        {
            get { return this.Rm*this.B * this.L*this.D; }
        }
        public BasePk(double b,double l,double d,double fk,double vk,double mk,double rm)
        {
            this.B = b;
            this.L = l;
            this.D = d;
            this.Fk = fk;
            this.Vk = vk;
            this.Mk = mk;
            this.Rm = rm;
        }

        public double CalPmaxk()
        {
            if (this.E0 <= this.L / 6.0)
            {
                return (this.Fk + this.Gk) / this.Area + (this.Vk * this.D + this.Mk) / this.Wx;
            }
            else
            {
                return 2*(this.Fk + this.Gk) / (3 * this.L * (this.L / 2.0 - this.E0));
            }
        }
        public double CalPmink()
        {
            if (this.E0 <= this.L / 6.0)
            {
                return (this.Fk + this.Gk) / this.Area - (this.Vk * this.D + this.Mk) / this.Wx;
            }
            else
            {
                return 0;
            }
        }
    }
}
