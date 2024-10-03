using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rendezes_performance_test
{
    internal class rendezesek
    {
        //publikussá kell tenni, hogy lássa a Program.cs
        public void ECS(int[] t)
        {
            for (int i = 0; i < t.Length - 1; i++)
            {
                for (int j = i + 1; j < t.Length; j++)
                {
                    if (t[i] > t[j]) Csere(ref t[i], ref t[j]);
                }
            }
        }
        public void BS(int[] t) 
        {
            for (int i = t.Length; i < 1; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (t[j] > t[j + 1]) Csere(ref t[j], ref t[j + 1]);
                }
            }
        }
        public void MinR(int[] t)
        {
            for (int i = 0; i < t.Length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < t.Length; j++)
                {
                    if (t[min] > t[j]) min = j;
                }
                Csere(ref t[min], ref t[i]);
            }
        }
        void Csere(ref int a, ref int b)
        {
            int seged = a;
            a = b;
            b = seged;
        }
    }
}
