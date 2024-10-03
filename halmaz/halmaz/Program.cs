using System.Threading.Channels;

namespace halmazok
{
    internal class Program
    {
        static Random R = new Random();
        static void Main(string[] args)
        {
            /*var H = HalmazEloallitas(ElemSzam());
            foreach (var x in H)
            {
                Console.Write($"{x} ");
            } 
            */
            Console.WriteLine( "1, 3, 3, 4, 5" );
            Console.WriteLine( "1, 2, 5, 6" );
            Console.WriteLine();

            Console.WriteLine("reszhalmaz: " + ReszhalmazVizsgalat());

            Console.Write("unio: ");
            foreach (int i in unio())
            {
                Console.Write(i + ", ");
            }

            Console.WriteLine();
            Console.Write("kulonbseg: ");
            foreach (int i in kulonbseg())
            {
                Console.Write(i + ", ");
            }

            Console.WriteLine();
            Console.Write("metszet: ");
            foreach (int i in metszet())
            {
                Console.Write(i + ", ");
            }
            Console.ReadKey();
        }
        static int ElemSzam()
        {
            int sz = 0;
            do
            {
                Console.WriteLine("Kérem az elemszámot, pozitív egész legyen!");
            } while (!int.TryParse(Console.ReadLine(), out sz) || sz < 1);
            return sz;
        }
        static int[] HalmazEloallitas(int N)
        {
            List<int> OsszesSzam = new List<int>();
            for (int i = 0; i <= N * 3; i++)
            {
                OsszesSzam.Add(i);
            }
            int[] T = new int[N];
            int index = 0;
            for (int i = 0; i < N; i++)
            {
                index = R.Next(OsszesSzam.Count);
                T[i] = OsszesSzam[index];
                OsszesSzam.RemoveAt(index);
            }
            return T;
        }
        
        static bool ReszhalmazVizsgalat()
        {   
            List<int> A = new List<int>() {1, 3, 3, 4, 5};
            List<int> B = new List<int>() { 1, 2, 6 };
            
            bool reszhalmaz = true;
            int i = 0;
            do
            {
                bool bennevan = false;
                for (int j = 0; j < B.Count; j++) { if (A[i] == B[j]) bennevan = true; }
                reszhalmaz = bennevan;
                i = i + 1;
            } while (i == A.Count || reszhalmaz == false);
            return reszhalmaz;

        }

        static List<int> unio()
        {
            List<int> A = new List<int>() { 1, 3, 3, 4, 5 };
            List<int> B = new List<int>() { 1, 2, 5, 6 };
            List<int> C = new List<int>();

            for (int i = 0; i < A.Count; i++)
            {
                if (!C.Contains(A[i])) C.Add(A[i]);
            }
            for (int i = 0; i < B.Count; i++)
            {
                if (!C.Contains(B[i])) C.Add(B[i]);
            }

            return C;
        }

        static List<int> kulonbseg()
        {
            List<int> A = new List<int>() { 1, 3, 3, 4, 5 };
            List<int> B = new List<int>() { 1, 2, 6, 5 };
            List<int> C = new List<int>();

            for (int i = 0; i < A.Count; i++)
            {
                if (!B.Contains(A[i])) C.Add(A[i]);
            }
            return C;
        }

        static List<int> metszet()
        {
            List<int> A = new List<int>() { 1, 3, 3, 4, 5 };
            List<int> B = new List<int>() { 1, 2, 5, 6 };
            List<int> C = new List<int>();

            for (int i = 0; i < A.Count; i++)
            {
                if (B.Contains(A[i]) && !C.Contains(A[i])) { C.Add(A[i]); }
            }
            return C;

            //uniót, különbséget, metszetet, descartes genyót befejezni
        }
    }
}