using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Fibonacci
{
    class Program
    {
        /*
Waszym zadaniem jest:
- napisać program do obliczania N-tego wyrazu ciągu Fibonacciego w sposób iteracyjny i rekurencyjny. 
- optymalizacja kodu - wszak w przypadku ciągu Fibonacciego jak liczę element 3-ci, a potem 4-ty, to czy muszę na pewno znów liczyć wszystko od początku? Czekam na Wasze wnioski racjonalizatorskie :)*/


        static void Main(string[] args)
        {

            Console.Write("Podaj n liczbę ciągu Fibonacciego: ");

            int n = Convert.ToInt32(Console.ReadLine());

            //metoda rekurencyjna
            ulong numberR = FibRecursive(n);

            Console.WriteLine("Liczba {0} (metoda rekurencyjna) to: {1}", n, numberR);


            //metoda rekurencyjna z memoizacją            
            ulong numberRM = FibMemo(n);         
            
            Console.WriteLine("Liczba {0} (rekurencyjna z memoizacją) to: {1}", n, numberRM);


            //metoda iteracyjna
            ulong numberI = FibIterative(n);

            Console.WriteLine("Liczba {0} (metoda iteracyjna) to: {1}", n, numberI);




        }
        ////metoda rekurencyjna 
        public static ulong FibRecursive(int n)

        {
            if (n <= 1)
            {
                return Convert.ToUInt64(n);
            }
            else return FibRecursive(n - 2) + FibRecursive(n - 1);


        }

        //rekurencyjna z memoizacją
        public static ulong FibMemo(int n)
        {
            ulong[] FibNumbers = new ulong[n + 1];

            if (n <=1 )
            {
                return Convert.ToUInt64(n);
            }

            if (FibNumbers[n] != 0)
            {
                return FibNumbers[n];
            }
            else 
            {
                FibNumbers[n] = FibMemo(n - 2) + FibMemo(n - 1);
            }

            return FibNumbers[n];
        }


        //metoda iteracyjna
        public static ulong FibIterative(int n)
        {
            ulong[] FibNumbers = new ulong[n + 1];

            FibNumbers[0] = 0;
            FibNumbers[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                FibNumbers[i] = FibNumbers[i - 2] + FibNumbers[i - 1];
            }

            return FibNumbers[n];

        }

       
    }
}
