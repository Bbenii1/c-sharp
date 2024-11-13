using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vezérlési szerkezetek
            //elágazások
            Console.WriteLine("Kérek egy számot!");
            int szam = int.Parse(Console.ReadLine());
            //egyágú elágazás, nagyobb-e 0-nál?
            if (szam > 0) Console.WriteLine("Pozitív");

            //kétágú leágazás: páros vagy páratlan
            if (szam % 2 == 0) Console.WriteLine("Páros");
            else Console.WriteLine("Páratlan");

            //többágú elágazás: pozitív, vagy negatív
            if (szam > 0) Console.WriteLine("pozitív");
            else if (szam < 0) Console.WriteLine("negazív");
            else Console.WriteLine("nulla");

            //kapcsoló (többágú) elágazás
            switch (szam)
            {
                case 0: Console.WriteLine("Nulla"); break;
                case 1: Console.WriteLine("Hahó"); break;
                case 2:
                case 3: Console.WriteLine("ÉS kapcsolat"); break; //ilyenkor a kettőre és háromra is ez a sor fog lefutni
                default:
                    Console.WriteLine("Milyen csodás ez a nap!");
                    break;
            }


            //elöl tesztelő cuklus, FONTOS a kilépési feltétel programozása!
            Console.WriteLine();
            while (szam < 10)
            {
                Console.WriteLine(szam);
                szam++;
            }

            //végtelen elöl tesztelő ciklus
            Console.WriteLine();
            while (true)
            {
                szam--;
                Console.WriteLine(szam);
                if (szam == 0) break;
            }

            //hátul tesztelő ciklus: egyszer biztos lefut, aztán viszgáljuk
            Console.WriteLine();
            do
            {
                szam++;
                Console.WriteLine(szam);
            } while (szam % 5 != 0);

            //léptetéses ciklus, vagy fix lépésszámú ciklus
            //írjuk ki egymás mellé 0-100 közé eső 5-tel osztható számokat
            Console.WriteLine("\n");
            for(int i = 0; i < 101; i += 5) //lépésköz maipulálása
            {
                Console.Write(i + " ");
            }
            Console.WriteLine("\n");
            Console.ReadKey();
        }
    }
}