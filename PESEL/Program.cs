using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PESEL
{
    class Program
    {
        /*Proszę napisać metodę do weryfikacji numeru PESEL.
        Funkcja ma przyjmować parametr będący numerem PESEL.
        Funkcja ma sprawdzać poprawność numeru PESEL, zwracając odpowiednio:
        A) wartość null , gdy numer jest niepoprawny
        B) obiekt zawierający informację o dacie urodzenia z PESELu oraz płeć, gdy PESEL jest poprawny
        Oczywiście walidacja numeru pesel obejmuje obliczanie sumy kontrolnej :)*/


        static void Main(string[] args)
        {
            Console.Write("Podaj nr PESEL: ");
            string input = Console.ReadLine();
            string output = PESELCheck(input);
                        
            Console.WriteLine(output);
        }


        public static string PESELCheck (string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                Console.WriteLine("Nie wprowadzono numeru");
                return null;

            };

             
            if (number.Length != 11)
            {
                Console.WriteLine("Zła długość numeru");
                return null;

            }


            List<double> PESEL = new List<double>();

            foreach (var num in number)
            {
                PESEL.Add(char.GetNumericValue(num));
            }

            //suma kontrolna 
            double peselSum = PESEL[0] * 1 + PESEL[1] * 3 + PESEL[2] * 7 + PESEL[3] * 9 + PESEL[4] * 1 + PESEL[5] * 3 + PESEL[6] * 7 + PESEL[7] * 9 + PESEL[8] * 1 + PESEL[9] * 3;


            double controlNumber = (10 - (peselSum % 10)) % 10;

            if (controlNumber != PESEL[10])
            {
                Console.WriteLine("Zła suma kontrolna");
                return null;
            }

            //rok urodzenia
            string Y1 = "";
            string Y2 = PESEL[0].ToString() + PESEL[1].ToString();

            if (PESEL[2] == 0 || PESEL[2] == 1)
            {
                Y1 = "19";
            }

            if (PESEL[2] == 2 || PESEL[2] == 3)
            {
                Y1 = "20";
            }
            
            if (PESEL[2] == 4 || PESEL[2] == 5)
            {
                Y1 = "21";
            }

            if (PESEL[2] == 6 || PESEL[2] == 7)
            {
                Y1 = "22";
            }

            //miesiąc
            string M1 = "";
            string M2 = PESEL[3].ToString();

            if (PESEL[2] == 0 || PESEL[2] % 2 == 0)
            {
                M1 = "0";
            }

            else if (PESEL[2] % 2 != 0)
            {
                M1 = "1";
            }

            //dzień
            string DD = PESEL[4].ToString() + PESEL[5].ToString();

            //płeć
            string gender = (PESEL[9] % 2 != 0) ? "M" : "K";


            //string
            return $"Data urodzenia: {Y1 + Y2}-{M1 + M2}-{DD}\nPłeć: {gender}";


        }
    }
}
