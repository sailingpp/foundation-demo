using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foundation
{
    public class Shape
    {
        public double A;
        public double B;
        public double H;
        public double Area
        {
            get { return (this.A + this.B) / 2.0 * this.H; }
        }
        public double Cx
        {
            get
            { 
                return 1.0/3.0*(this.A*this.A+this.B*this.B+this.A*this.B)/(this.A+this.B); 
            }
        }

        public double Cy
        {
            get 
            {
                return 1.0 / 3.0 * (this.A * 2 + this.B) / (this.A + this.B) * this.H;
            }
        }
        public Shape(double a, double b, double h)
        {
            this.A = a;
            this.B = b;
            this.H = h;
        }

    }
}
