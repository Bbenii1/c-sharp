using System;
using System.Security.Cryptography.X509Certificates;

namespace ip11_0925
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region aha
            proba P = new proba("hahó");
            Console.WriteLine(P.ElsoSzoveg + " " + P.MasodikSzoveg + " " + P.ElsoSzam);
            Console.ReadKey();

            proba P2 = new proba(12.23);
            Console.WriteLine(P2.ElsoSzoveg + " " + P2.MasodikSzoveg + " " + P2.ElsoSzam);
            Console.ReadKey();

            proba P3 = new proba("akármii", 3.24);
            Console.WriteLine(P3.ElsoSzoveg + " " + P3.MasodikSzoveg + " " + P3.ElsoSzam);
            Console.ReadKey();

            proba P4 = new proba("a", a:"bbb");
            Console.WriteLine(P4.ElsoSzoveg + " " + P4.MasodikSzoveg + " " + P4.ElsoSzam);
            Console.ReadKey();
            #endregion

            proba p = new proba("kkk");
            /*p.EgeszSzam = 2;
            Console.WriteLine(p.Negyzet());*/
            p.MasikSzam = 30;
            /*Console.WriteLine(p.MasikSzam);
            Console.ReadKey();*/


            #region másodfokú genyó
            /*Console.WriteLine("Első fokú egyenlet? i/n");
            string valasz = Console.ReadLine();
            switch (valasz)
            {
                case "i":
                case "I": megoldas M = new megoldas(11, 23);
                    Console.WriteLine("gyök: " + M.Gyok1); break;
                default: megoldas m = new megoldas(1, 2, 1);
                    Console.WriteLine("gyokok: " + m.Gyok1 + ", " + m.Gyok2); break;
            }*/
            #endregion

            #region háromszög szerkeszthető-e és ha igen akk terület kiszámítása
            Console.WriteLine("Adja meg a háromszög 3 oldalát:");
            Console.Write("a: "); int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("b: "); int b = Convert.ToInt32(Console.ReadLine());
            Console.Write("c: "); int c = Convert.ToInt32(Console.ReadLine());
            #endregion
            megoldas H = new megoldas(a, b, c);
            Console.WriteLine(H.lehet);
            if (H.lehet) { Console.WriteLine(H.terulet); }
            
            
        }
    }
}
