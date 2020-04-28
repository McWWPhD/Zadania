using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiczbyRzyskieArabskie
{
    class Program
    {
        //        Napisać program realizujący konwersję liczb arabskich na rzymskie i liczb rzymskich na liczby arabskie.
        //- zdefiniować dwie metody: ArabskieNaRzymskie() , RzymskieNaArabskie()
        //- metody mają zwracać przekonwertowane wartości
        //- parametrem wywołania ww.metod jest liczba: odpowiednio arabska (np. 1988) lub rzymska(np.MMII)
        //- zweryfikować poprawność wprowadzanych danych z konsoli od użytkownika
        //- ograniczyć zakres wprowadzonej wartości w przypadku funkcji ArabskieNaRzymskie() do zakresu od 1 do 3999 (włącznie)

        static void Main(string[] args)
        {
            Console.Write("Podaj liczbę w zapisie rzymskim albo arabskim i zakresie 1-3999: ");
            string dane = Convert.ToString(Console.ReadLine());

        

                try
                {
                    if (dane.Contains('I') || dane.Contains('V') || dane.Contains('X') || dane.Contains('L') || dane.Contains('C') || dane.Contains('D') || dane.Contains('M'))
                    
                    {
                        Console.WriteLine();
                        Console.WriteLine("W zapisie arabskim jest to: " + RzymskieNaArabskie(dane));
                    }            
                                      

                    else if (Convert.ToInt32(dane) >= 1 && Convert.ToInt32(dane) <= 3999)
                    {
                        Console.WriteLine();
                        Console.WriteLine("W zapisie rzymskim jest to: " + ArabskieNaRzymskie(Convert.ToInt32(dane)));
                    }

                    else if (Convert.ToInt32(dane) < 1 || Convert.ToInt32(dane) > 3999)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Niewłaściwy zakres");
                    }

                }

                catch (Exception)
                {
                    Console.WriteLine("Niewłaściwy format");
                }
            
        }




        public static int RzymskieNaArabskie(string rzymskie)
        {

            Dictionary<char, int> slownikAra = new Dictionary<char, int>()

                {
                    { 'I', 1},
                    { 'V', 5 },
                    { 'X', 10 },
                    { 'L', 50 },
                    { 'C', 100 },
                    { 'D', 500 },
                    { 'M', 1000 }
                };
            
            int arabskie = 0;

            for (int i = 0; i < rzymskie.Length; i++)
            {

                if (i != rzymskie.Length - 1 && slownikAra[rzymskie[i]] < slownikAra[rzymskie[i + 1]])
                {
                    arabskie += slownikAra[rzymskie[i + 1]] - slownikAra[rzymskie[i]];
                    i++;
                }
                else
                {
                    arabskie += slownikAra[rzymskie[i]];
                }
            }
            return arabskie;

        }
        
        public static string ArabskieNaRzymskie(int arabska)
        {
          Dictionary<int, string> slownikRom = new Dictionary<int, string>()

                {
                    { 1000, "M" },
                    { 900, "CM" },
                    { 500, "D" },
                    { 400, "CD" },
                    { 100, "C" },
                    { 90, "XC" },
                    { 50, "L" },
                    { 40, "XL" },
                    { 10, "X" },
                    { 9, "IX" },
                    { 5, "V" },
                    { 4, "IV" },
                    { 1, "I" },
                };

            var rzymskie = new StringBuilder();
            
            foreach (var liczbaSlownika in slownikRom)
            {
                while (arabska >= liczbaSlownika.Key)
                {
                    rzymskie.Append(liczbaSlownika.Value);
                    arabska -= liczbaSlownika.Key;
                }
            }

            return rzymskie.ToString();
        }
    }
}
