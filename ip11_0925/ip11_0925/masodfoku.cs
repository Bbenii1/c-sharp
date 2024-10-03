using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace ip11_0925
{
    internal class megoldas
    {
        double A, B;
        double? C;
        double x1, x2;
        public megoldas(double a, double b, double? c = null)
        {

            A = a; B = b; C = c;
        }

        public double Gyok1
        {
            get
            {
                if (C == null) { return -B / A; }
                else { return (-B + Math.Sqrt(B * B - 4 * A * (double)C)) / (2 * A); }
            }
        }
        public double Gyok2
        {
            get
            {
                if (C == null) { return -B / A; }
                else { return (-B - Math.Sqrt(B * B - 4 * A * (double)C)) / (2 * A); }
            }

        }
        public double[] Gyokok
        {
            get
            {
                double[] t;
                if (C == null)
                {
                    t = new double[1];
                    t[0] = -B / A;
                }
                else
                {
                    if (B * B - 4 * A * (double)C > 0)
                    {
                        t = new double[2];
                        t[0] = (-B - Math.Sqrt(B * B - 4 * A * (double)C)) / (2 * A);
                        t[1] = (-B + Math.Sqrt(B * B - 4 * A * (double)C)) / (2 * A);
                    }
                    else if (B * B + 4 * A * (double)C == 0)
                    {
                        t = new double[] { (-B + Math.Sqrt(B * B - 4 * A * (double)C)) / (2 * A) };
                    }
                    else
                    {
                        t = new double[0];
                    }
                }
                return t;
            }
        }

        int hA, hB, hC;

        public megoldas(int a, int b, int c)
        {
            hA = a; hB = b; hC = c;
        }

        public bool lehet
        {
            get
            {
                if (hA + hB > hC && hA + hC > hB && hC + hB > hA) { return true; }
                else { return false; }
            }
        }
        public double terulet
        {
            get
            {
                double S = (double)(hA + hB + hC) / 2;
                Console.WriteLine(S);
                return Math.Sqrt(S * (S - hA) * (S - hB) * (S - hC));
            }
        }
    }
}
