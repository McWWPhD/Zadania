using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            Kalkulator();
            Console.ReadKey();

        }

        static void Kalkulator()
        {
            while (true)
            {


                Console.Write("Podaj argument #1: ");
                double pierwszaLiczba = Convert.ToDouble(Console.ReadLine());

                Console.Write("Podaj operator: ");
                char dzialanie = Convert.ToChar(Console.ReadLine());

                Console.Write("Podaj argument #2: ");
                double drugaLiczba = Convert.ToDouble(Console.ReadLine());

                double wynik;


                switch (dzialanie)
                {
                    case '+':
                        wynik = pierwszaLiczba + drugaLiczba;
                        Console.WriteLine("Wynik to: " + wynik);
                        Console.WriteLine();
                        break;

                    case '-':
                        wynik = pierwszaLiczba - drugaLiczba;
                        Console.WriteLine("Wynik to: " + wynik);
                        Console.WriteLine();
                        break;

                    case '*':
                        wynik = pierwszaLiczba * drugaLiczba;
                        Console.WriteLine("Wynik to: " + wynik);
                        Console.WriteLine();
                        break;

                    case '/':
                        wynik = pierwszaLiczba / drugaLiczba;

                        if (drugaLiczba == 0)
                        {
                            Console.WriteLine("Dzielenie przez zero");
                            Console.WriteLine();
                        }
                        else

                            Console.WriteLine("Wynik to: " + wynik);
                        Console.WriteLine();

                        break;

                    default:
                        break;
                }

            }



        }
    }
}
