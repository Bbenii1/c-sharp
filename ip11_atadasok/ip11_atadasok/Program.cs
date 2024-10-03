using System;

namespace ip11_atadasok
{
    internal class Program
    {
        static Random R = new Random(); // véletlen szám generálás

        static void Main(string[] args)
        {
            /*int a = 10, b = 20;
            Console.WriteLine("Csere hívása előtt: a = " + a + ", b = " + b);
            Csere(ref a, ref b);
            Console.WriteLine("Csere hívása után: a = " + a + ", b = " + b);*/
            int[] t = new int[SzamBeolvas("Add meg az elemszámot, ami pozitív egész!")];
            TombFeltoltes(t);
            KiIr(t);
            //Csere(ref t[0], ref t[t.Length - 1]); //kell a ref, mivel csak az elemét adjuk át a tömbnek
            //KiIr(t);

            Console.Write("ECS: ");
            ECS(t);
            KiIr(t);

            Console.Write("BS:  ");
            BS(t);
            KiIr(t);

            Console.Write("MinR:");
            MinR(t);
            KiIr(t);

            Console.Write("MaxR:");
            MaxR(t);
            KiIr(t);
            Console.ReadKey();
        }
        
        static void TombFeltoltes(int[] tomb)
        {
            for (int i = 0; i < tomb.Length; i++)
                tomb[i] = R.Next(tomb.Length * 3); //ha cikluson belül egy parancssor van, akkor a {} elhanyagolható
        }
        static void ECS(int[] t) //egyszerű cserés rendezés
        #region Egyszerű cserés rendezés
        /*
        - Egyszerű cserés rendezés: előfeltétel egy N elemű feltöltött tömb, vagyis elemtípus: T[1..N], valamint egész N

        Növekvő, vagy csökkenő sorrendbe rendezzük a tömb elemeit. Ez minden olyan tömbnél működnie kell, ami egyszerű adattípusokat tárol. Műkködnie kell 
        azon tömbökre is, mely osztállyal vagy struktúrával létrehozott elemeket tárol, feltéve, hogy az o., vagy s. tartalmaz egyszerű adattípust.

        Alapelve: Felveszünk egy elemet (először tömb legelső elemét), összehasonlítjuk a mögötte levőkkel és ha szükséges cserét hajtunk létre.

        Eljárás EgyszerűCsRendezés(elemtípus: T[1..N], egész N)
        Változó i, j: egész
        Eljárás kezdete
            Ciklus i = 0-tól n-1-ig ismétel
                Ciklus j = i + 1-től N-ig ismétel
                    Ha t[i] nagyobb mint t[j] akkor
                        Csere(T[i] és T[j])
                    Elágazás vége
                ismétlés vége
            imsétlés vége
        Elágazás vége

         */
        #endregion
        {
            for (int i = 0; i < t.Length - 1; i++)
            {
                for (int j = i + 1; j < t.Length; j++)
                {
                    if (t[i] > t[j]) Csere(ref t[i], ref t[j]);
                }
            }
        }
        static void BS(int[] t) //buborék rendezés
            #region Buborék rendezés
        /*
        - Buborékrendezés: előfeltétel u.a, mint az egyszerű cserés rendezésnél.
        
        Alapelv: végigmegyünk a szomszédos elemeken, és ha kell cseréljük őket! Hagyományosan a B.R. a külső ciklust csökkenőként, a belsőt növekvőként használja.

        Eljárás Bubi(elemtíous: t[0...N-1], egész N)
        változó i, j:egész
        Eljárás kezdete
            Ciklus i = N-1-től 1-ig ismétel, lépésköz = -1
                Ciklus j = 0-tól i - 1-ig ismétel
                    ha t[j] nagyobb mint t[j + 1] akkor
                        Csere(t[j] és t[j + 1]
                    elágazás vége
                ismétlés vége
            ismétlés vége
        eljárás vége
         */
        #endregion

        {
            for (int i = t.Length; i < 1; i--)
            {
                for (int j = 0; j < i - 1; j++)
                {
                    if (t[j] > t[j + 1]) Csere(ref t[j], ref t[j + 1]);
                }
            }
        }
        static void MinR(int[] t) //minimumkiválasztásos rendezés
        #region Min-Max rendezés
        /*
         Min-Max rendezés: előfeltétel u.a., mint az ecs-nél.
        
        Alapelv: ugyanaz, mint az ECS-nél, de itt csak egysezr cserélünk egy belső ciklus lefolyása alatt (után).

        Eljárás MinMax(elempítpus: t[0..N-1], egész: N)
        változó i, j: egész
        Eljárás kezdete
            Ciklus i = 0-tól N-1-ig ismétel
                min = i
                Ciklus j = i + 1-től N-ig ismétel
                    Ha t[min] > t[j] akkor
                        min = j
                    Elágazás vége
                Ismétlés vége
                Csere(t[min], t[i])
            Ismétlés vége
        Eljárás vége
         */
        #endregion
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

        static void MaxR(int[] t) //Maximum kiválasztásos rendezés
        {
            for (int i = t.Length; i < 1; i--)
            {
                int max = 0;
                for (int j = 1; j < i; j++)
                {
                    if (t[max] < t[j]) max = j;
                }
                Csere(ref t[max], ref t[i]);
            }
        }

        static void KiIr(int[] tomb)
        {
            foreach (int i in tomb)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        static int SzamBeolvas(string duma)
        {
            int szam = 0;
            do
            {
                Console.WriteLine(duma);

            } while (!int.TryParse(Console.ReadLine(), out szam) || szam < 1); //ha konvertálható a szám, akkor outolva lesz a szám :3
            return szam;
        }
        static void Csere(ref int a, ref int b) //ref -> referenciát csinál az a-nak és b-nek, így visszakerül a cserélt érték a és b-be
        {
            int seged = a;
            a = b;
            b = seged;
            //Console.WriteLine("Csere-n belül: a = " + a + ",  b = " + b);
        }
    }
}
