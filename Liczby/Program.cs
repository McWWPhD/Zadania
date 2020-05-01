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

            //foreach (var number in numbers)
            //{

            //    Console.WriteLine(number);
            //}

            Console.WriteLine();


            //wartość minimalna

            Console.WriteLine( "Minimalna wartość to: " + numbers.Min() + "\n");

            
            //wartość maks. 

            Console.WriteLine( "Maksymalna wartość to: "+ numbers.Max() + "\n");

            
            //średnia arytmetyczna

            Console.WriteLine( "Średnia arytmetyczna to: " + numbers.Average() + "\n");

            //mediana
            int medianaNumber=0; 
            numbers.Sort();

            if (numbers.Count() % 2 != 0)
            {
                medianaNumber = (numbers.Count() + 1) / 2;
                Console.WriteLine("Mediana wynosi: " + numbers[medianaNumber - 1]);
            }
            else if (numbers.Count() % 2 == 0)
            {
                medianaNumber = (numbers.Count() + 1) / 2;

                double mediana = ((double)numbers[medianaNumber - 1] + (double)numbers[medianaNumber]) / 2;

                Console.WriteLine("Mediana wynosi: " + mediana);
            }


            //odchylenie standardowe
            double licznik = 0;

            for (int i = 0; i < numbers.Count(); i++)
            {

                licznik += (numbers[i] + numbers.Average()) * (numbers[i] + numbers.Average());
            }

            double odchylenieStandardowe = Math.Sqrt(licznik / numbers.Count());

            Console.WriteLine("Odchylenie standardowe wynosi: {0:5}",+ odchylenieStandardowe);
        }
    }
}
