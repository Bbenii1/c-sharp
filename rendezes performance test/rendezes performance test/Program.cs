using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rendezes_performance_test
{
    internal class Program
    {
        static Random R = new Random();
        static void Main(string[] args)
        {
            rendezesek Rend = new rendezesek();
            int[] tarolo = new int[SzamBeolvas("Elemszám?")];
            int[] Rtomb = new int[tarolo.Length]; //ezt adjuk meg rendezésre
            TombFeltes(tarolo);
            AtToltes(Rtomb, tarolo);
            var start = DateTime.Now; Rend.ECS(Rtomb); var stop = DateTime.Now;
            Console.WriteLine("ECS ideje: " + (stop - start));

            AtToltes(Rtomb, tarolo);
            start = DateTime.Now; Rend.BS(Rtomb); stop = DateTime.Now;
            Console.WriteLine("Bubi ideje: " + (stop - start));

            AtToltes(Rtomb, tarolo);
            start = DateTime.Now; Rend.MinR(Rtomb); stop = DateTime.Now;
            Console.WriteLine("MinR ideje: " + (stop - start));

            AtToltes(Rtomb, tarolo);
            start = DateTime.Now; Array.Sort(Rtomb); stop = DateTime.Now;
            Console.WriteLine("array sort ideje: " + (stop - start));

            Console.ReadKey();
        }
        static void AtToltes(int[] cel, int[] forras)
        {
            for (int i = 0; i < cel.Length; i++)
            {
                cel[i] = forras[i];
            }
        }

        static int SzamBeolvas(string duma)
        {
            int szam = 0;
            do
            {
                Console.WriteLine(duma);

            } while (!int.TryParse(Console.ReadLine(), out szam) || szam < 1);
            return szam;
        }

        static void TombFeltes(int[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
                tomb[i] = R.Next(tomb.Length * 3);
        }
    }
}
