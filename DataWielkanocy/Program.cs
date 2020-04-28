using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWielkanocy
{
    class Program
    {
        //napisaniu metody przyjmującej jako parametr rok, a zwracająca datę Wielkanocy jako string w formacie RRRR-MM-DD np. 2020-04-12.
               
        static void Main(string[] args)
        {
            Console.Write("Podaj rok: ");

            int rok = Convert.ToInt32(Console.ReadLine());

            int MM = 0;
            int DD = 0;

            int a = rok % 19;
            int b = rok % 4;            
            int c = rok % 7;

            int A = 0;
            int B = 0;
                      
            
            if (rok < 1582)
            {
                A = 15;
                B = 6;
            }

            if (rok >= 1583 &&  rok <= 1699)
            {
                A = 22;
                B = 2;
            }
            
            if (rok >= 1700 && rok <= 1799)
            {
                A = 23;
                B = 3;
            }
            
            if (rok >= 1800 && rok <= 1899)
            {
                A = 23;
                B = 4;
            }
            
            if (rok >= 1900 && rok <= 2099)
            {
                A = 24;
                B = 5;
            }
            
            if (rok >= 2100 && rok <= 2199)
            {
                A = 24;
                B = 6;
            }
            
            if (rok >= 2200 && rok <= 2299)
            {
                A = 25;
                B = 0;
            }
            
            if (rok >= 2300 && rok <= 2399)
            {
                A = 26;
                B = 1;
            }


            if (rok >= 2400 && rok <= 2499)
            {
                A = 25;
                B = 1;
            }


            int d = (a * 19 + A) % 30;
            int e = (2 * b + 4 * c + 6 * d + B) % 7;
            int wielkanoc = 0;

            //wyjątki
            if (d == 29 && e == 6)
            {
                MM = 04;
                DD = 19;
                return;
            }

            else if (d == 28 && e == 6)
            {
                MM = 04;
                DD = 18;
                return;            
            }

            else { wielkanoc = 22 + d + e; 
                
                if (wielkanoc <= 31)
                {
                MM = 03;
                DD = wielkanoc;
                }

                else if (wielkanoc > 31)
                {
                    MM = 04;
                    DD = wielkanoc - 31;
                }
                
            }
            
            string miesiac = MM.ToString("D2");
            string dzien = DD.ToString("D2");


            Console.WriteLine("Wielkanoc: {0}-{1}-{2}", rok, miesiac, dzien );

          
        }
    }
}
