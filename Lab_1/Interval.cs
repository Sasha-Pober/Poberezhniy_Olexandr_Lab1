using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lab_1
{
    class Interval
    {
        private double left;
        private double right;

        public double LeftEdge
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
            }
        }
        public double RightEdge
        {
            get
            {
                return right;
            }
            set
            {
                right = value;
            }
        }

        public Interval() { }

        public double IntervalLength()
        {
            if (left < right)
                 return Math.Sqrt(Math.Pow((left - right),2));

            else
            {
                Console.WriteLine("Incorrect values");
                return 0;
            }
                

        }

        public void Offset (string answer, double x)
        { 
            if (answer == "left")
            {
                left -= x;
                right -= x;
            }
            else if (answer == "right")
            {
                left += x;
                right += x;
            }
            else
            {
                left += 0;
                right += 0;
            }

        }

        public void Distortion(double epsillon)
        {
            double av = IntervalLength() / 2 + left;
            double NewLength = IntervalLength() * epsillon;

            left = av - NewLength/2;
            right = av + NewLength / 2; 
        }

        public void Compairing(Interval y)
        {
            if (left == y.LeftEdge && right == y.RightEdge)
            {
                Console.WriteLine("Intervals are equal");
            }
            else
            {
                Console.WriteLine("Intervals are not equal");
            }
        }

        public void Sum(Interval y)
        {
            left += y.LeftEdge;
            right += y.RightEdge;
            Console.WriteLine($"The result is [{left},{right}]");
        }

        public void Substract(Interval y)
        {
            left -= y.LeftEdge;
            right -= y.RightEdge;
            Console.WriteLine($"The result is [{left},{right}]");
        }

    }
}
