using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liczby
{

    /*
Przyjmujemy od użytkownika ciąg liczb całkowitych oddzielając je przecinkiem
Parsujemy taki ciąg znaków do tablicy/listy - wybór dowolny
Z tej tablicy/listy wartości liczymy takie rzeczy jak: wartość minimalna, wartość maks. , średnia arytmetyczna, mediana, odchylenie standardowe*/

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Podaj ciąg liczb całkowitych oddielonych przecinkiem: ");
            string input = Console.ReadLine();

            List<int> numbers = new List<int>();

            foreach (var number in input.Trim().Split(',') )
            {
                numbers.Add(Convert.ToInt32(number));
            }

            Console.WriteLine();


            //wartość minimalna

            Console.WriteLine( "Minimalna wartość: " + numbers.Min() + "\n");

            
            //wartość maks. 

            Console.WriteLine( "Maksymalna wartość: "+ numbers.Max() + "\n");

            
            //średnia arytmetyczna

            Console.WriteLine( "Średnia arytmetyczna: " + numbers.Average() + "\n");

            //mediana
            int medianNumber=0; 
            numbers.Sort();

            if (numbers.Count() % 2 != 0)
            {
                medianNumber = (numbers.Count() + 1) / 2;
                Console.WriteLine("Mediana: " + numbers[medianNumber - 1]);
            }
            else if (numbers.Count() % 2 == 0)
            {
                medianNumber = (numbers.Count() + 1) / 2;

                double median = ((double)numbers[medianNumber - 1] + (double)numbers[medianNumber]) / 2;

                Console.WriteLine("Mediana: " + median);
            }
            Console.WriteLine();


            //odchylenie standardowe
            double numerator = 0;

            for (int i = 0; i < numbers.Count(); i++)
            {
                numerator += Math.Pow((numbers[i] - numbers.Average()),2);
            }

            double standardDeviation = Math.Sqrt(numerator / numbers.Count());

            Console.WriteLine("Odchylenie standardowe: {0:#.00}", standardDeviation);
        }
    }
}
