using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liczby_pierwsze
{
    class Program
    {

        static void Main(string[] args)
        {
            while (true)
            {


                Console.Write("Podaj liczbę naturalną: ");

                long number = Convert.ToInt32(Console.ReadLine());
               
                string output = checkIfPrime(number) ? "" : "nie";
                
                Console.WriteLine("Liczba: {0} {1} jest liczbą pierwszą \n", number, output);
            }                     

        }



        static bool checkIfPrime(long number)
        {
                                                            //Zasada: Pierwiastek kw. z liczby pierwszej nie jest wymierny

            if (number <= 1)                                //0 i 1 nie są liczbami pierwszymi
            {
                return false;
            }
                                                            
            for (int i = 2; i <= Math.Sqrt(number); i++)    //dopóki jest <= pierwiastek kw. z liczby
            {
                if (number % i == 0)                        //wystarczy, że raz liczba będze podzielna przez "i" bez reszty 
                {
                    return false;
                }
            }

            return true;
           
        }
             
        
    }

    
}
