using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ip11_0925
{
    internal class proba
    {
        string S = "0s";
        double D = 0;
        string F = "1f";
        string G = "B";
        
        /*A konstruktor egy metódus, ami az osztály példányosításakor kerül meghívásra.
         Static osztálynak nnincs szüksége konstruktorra, de van neki. Ez egy auto-konstruktor, paraméterek nélkül.
        A C#-ban annyi konstruktort írunk, amennyire szükségünk van!
        A konstruktor onnan ismerhető meg, hogy se nem void-os és nincs visszatérési értéke sem, valamint, a neve kötelezően az osztály neve.*/

        public proba(string duma)
        {
            S = duma;
        }

        public proba(double duma)
        {
            D = duma;
        }

        public proba(string duma, double szam)
        {
            S = duma; D = szam;
        }

        public proba(string duma, double szam = 0.12, string a = "alapértelmezett szöveg")
        {
            S = duma; F = a; D = szam;
        }
        //tulajdonság vissatérési és bemeneti értéke is ugyanaz. Arról lehet megismerni, hogy NEM paraméterezhető! (nincs zárójel a neve után)
        //Vagy a SET. vagy a GET parancs használata kötelező. A leggyakrabban mindkettőt használjuk.

        public string ElsoSzoveg { get { return S; } }
        public string MasodikSzoveg { get { return F; } }
        public double ElsoSzam { get { return D; } }
        public string HarmadikSzoveg { get{ return G; } }

        public int EgeszSzam { get; set; }

        int Egesz;
        public int MasikSzam
        {
            set { Egesz = value; }
            get { int A = Egesz * 100; return A; }
        }

        public int Negyzet() { return EgeszSzam * EgeszSzam; }

    }
}
