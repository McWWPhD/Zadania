using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Program
    {
        //        Użytkownik podaje swój wiek i ile nocy spędzi w hotelu, a program wylicza, ile trzeba zapłacić.Zasady są takie:
        //- nieletni (poniżej 18 roku życia) płacą 100 zł za noc
        //- dorośli(ci, którzy mają przynajmniej 18 lat ale mniej niż 65 lat) płacą:
        //  - 200 zł za noc, jeśli nocują jedną noc
        //  - 180 zł za noc, jeśli nocują przynajmniej dwie ale mniej niż pięć nocy
        //  - 150 zł za noc, jeśli nocują pięć lub więcej nocy
        //- emeryci(ci, którzy mają przynajmniej 65 lat), płacą jak dorośli, ale z 10% zniżki
        //Przykładowo: jeśli użytkownik ma 70 lat i spędzi w hotelu dziesięć nocy, zapłaci 150 zł za noc z 10% zniżki, czyli 150-15 zł za noc, czyli 135 zł za noc, czyli 1350 zł.


        static void Main(string[] args)
        {
            while (true)
            {
                
                Console.Write("Podaj swój wiek: ");
                byte age = Convert.ToByte(Console.ReadLine());

                Console.Write("Podaj ilość nocy pobytu: ");
                int nights = Convert.ToInt32(Console.ReadLine());

                double pricePerNight = 0;

                double dis = 1;

                if (age < 18)
                {
                    Console.WriteLine("Jesteś osobą niepełnoletnią \nPoproś swojego opiekuna");
                    double pricePerNightKid = 100.00;

                    double totalPriceKid = pricePerNightKid * nights * dis;
                    Console.WriteLine("(Całkowita cena za pobyt dziecka: " + totalPriceKid + ")");
                    Console.WriteLine("***********\n \n");
                    break;
                   
                }

                else
                {
                    if (nights == 1)
                    {
                        pricePerNight = 200.00;
                    }
                    else if (nights >= 2 && nights < 5)
                    {
                        pricePerNight = 180.00;
                    }
                    else if (nights >= 5)
                    {
                        pricePerNight = 150.00;
                    }
                }

                if (age >= 65)
                {
                    dis = 0.9;
                }

                double totalPrice = pricePerNight * nights * dis;
                Console.WriteLine("\nCałkowita cena za pobyt: " + totalPrice );
                Console.WriteLine("**********WITAMY***********\n \n");

            }
        }



    }
}
