
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dziedziczenie
{
    
    // - uzupełnić klasę StockData i dodać pola przechowujące informacje na temat notowania
    //  - parsujemy dane z pliku CSV do listy
    //  - metoda ParseStockData() zwracać ma listę obiektów klasy StockData
    //  - napisać metodę zwracającą maksymalne i minimalne kursy akcji w ramach danego miesiąca

    class Program
    {
        static void Main(string[] args)
        {
                
            Console.Write("Podaj miesiąc 1-3: ");

            byte month = Convert.ToByte(Console.ReadLine());

            List<StockData> data = ParseStockData();

            StockData mBank = new StockData();
                                            
            Console.WriteLine($"Najwyższy kurs w miesiącu: {mBank.MonthHi(data, month)}");

            Console.WriteLine($"Najniższy kurs w miesiącu: {mBank.MonthLow(data, month)}");

        }

        public class StockData
        {
            public string Date { get; set; }
            public double RateAtOpen{ get; set; }
            public double RateAtHigh { get; set; }
            public double RateAtLow { get; set; }
            public double RateAtClose { get; set; }
            public int Volume { get; set; }


            // tu może jakieś metody
            public double MonthHi (List<StockData> data, byte month)
            {
                List<double> listOfHighestInMonth= new List<double>();
                
                foreach (var day in data)
                {
                    while (Convert.ToByte(day.Date.Substring(5, 2)) == month)
                    {
                    listOfHighestInMonth.Add(day.RateAtHigh);
                    }
                }

                return listOfHighestInMonth.Max();
            }
                       

            public double MonthLow (List<StockData> data, byte month)
            {
                List<double> listOfLowestInMonth = new List<double>();

                foreach (var day in data)
                {
                    while (Convert.ToByte(day.Date.Substring(5, 2)) == month)
                    {
                        listOfLowestInMonth.Add(day.RateAtLow);
                    }
                }

                return listOfLowestInMonth.Min();
            }

        }
        
        public static List<StockData> ParseStockData()
        {
            //bedzie zwracana lista obiektów klasy StockData
            List<StockData> result = new List<StockData>();

            // tu podajemy pełną ścieżkę do pliku CSV - jak nie bedzie tam pliku to dostaniecie wyjatek
            string path = @"C:\tmp\mbk.csv";

            // metoda ReadAllText() odczytuje wskazany plik tekstowy do stringa
            // musi być using System.Text; 
            string content = File.ReadAllText(path, Encoding.UTF8);
            /*
             * więcej o metodzie Split()
             * https://docs.microsoft.com/pl-pl/dotnet/csharp/how-to/parse-strings-using-split
             */
            foreach (String line in content.Split('\n'))
            {
                /*
                 * wiersz jest parsowany zwracany jest jako tablica zawierająca na indeksie:
                 * 0 - data notowania
                 * 1 - kurs otwarcia
                 * 2 - kurs najwyszy
                 * 3 - kurs najnizszy
                 * 4 - kurs zamkniecia
                 * 5 - wolumen akcji
                 */
                string[] items = line.Trim().Split(',');

                StockData sd = new StockData();

                // utworzyć obiekt przechowujący informacje na temat notowania w danym dniu
                sd.Date = items[0];
                sd.RateAtOpen = double.Parse(items[1].Replace('.',','));
                sd.RateAtHigh= double.Parse(items[2].Replace('.', ','));
                sd.RateAtLow = double.Parse(items[3].Replace('.', ','));
                sd.RateAtClose = double.Parse(items[4].Replace('.', ','));
                sd.Volume = Convert.ToInt32(items[5]);

                // trzeba coś jeszcze z tym StockData zrobić
                result.Add(sd);

            }

            return result;

        }
    }
}
