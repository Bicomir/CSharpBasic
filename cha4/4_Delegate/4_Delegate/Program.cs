using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Delegate
{
    public class Program
    {
        delegate double Fun(double x);

       
        static void Main(string[] args)
        {
            Fun fun = new Fun(Math.Sin);
            double d = Internal(fun,0,Math.PI/2,1e-6);
            // 6 1.00000059933648
            // 5 1.0000080913555
            // 4 1.00010549323516
            Console.WriteLine(d);

            Fun fun2 = new Fun(Linear);
            double d2 = Internal(fun2,0,2,1e-6);
            Console.WriteLine(d2);

            Rnd rnd = new Rnd();
            double d3 = Internal(new Fun(rnd.Num),0,1,0.01);
            Console.WriteLine(d3);

            Console.ReadLine();
        }

        static double Linear(double a)
        {
            return a * 2 + 1;
        }

        class Rnd
        {
            Random r = new Random();
            public double Num(double x)
            {
                return r.NextDouble();
            }
        }

        static double Internal(Fun f, double a,double b,double eps)  // 积分运算
        {
            int n, k;
            double fa, fb, h, t1, p, s, x, t = 0;
            fa = f(a);
            fb = f(b);

            // 迭代初值
            n = 1;
            h = b - a;
            t1 = h * (fa + fb) / 2.0;
            p = double.MaxValue;

            // 迭代计算
            while(p >= eps)
            {
                s = 0.0;
                for (k = 0; k <= n; k++)
                {
                    x = a + (k + 0.5) * h;
                    s = s + f(x);
                }
                t = (t1 + h * s) / 2.0;
                p = Math.Abs(t1-t);
                t1 = t;
                n = n + n;
                h = h / 2.0;
            }
            return t;
        }
    }
}
