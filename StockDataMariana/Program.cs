using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StockDataMariana
{
    class Program
    {
        static void Main(string[] args)
        {
            List<StockData> stockDataList = new List<StockData>(100);

            string path = @"mbk.csv";

            string content = File.ReadAllText(path, Encoding.UTF8);
            foreach (String line in content.Split("\n"))
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
                string[] items = line.Trim().Split(",");
                if (items.Length >= 6)
                {
                    StockData sd = new StockData
                        (items[0],
                        Convert.ToDouble(items[1], CultureInfo.InvariantCulture),
                        Convert.ToDouble(items[2], CultureInfo.InvariantCulture),
                        Convert.ToDouble(items[3], CultureInfo.InvariantCulture),
                        Convert.ToDouble(items[4], CultureInfo.InvariantCulture),
                        Convert.ToInt32(items[5], CultureInfo.InvariantCulture)
                        );
                    stockDataList.Add(sd);
                }
            }
            Console.WriteLine("Items in list {0}", stockDataList.Count());

            Hashtable htMax = new Hashtable();
            Hashtable htMin = new Hashtable();

            //parsowanie w poszukiwaniu maks. i min. miesięcznych 
            foreach (var stock in stockDataList)
            {

                String ym = stock.GetYearMonth();
                Double close = stock.GetClose();

                if (!htMax.ContainsKey(ym))
                {
                    htMax.Add(ym, close);
                }
                else
                {
                    if (close > (double)htMax[ym])
                        htMax[ym] = close;
                }


                if (!htMin.ContainsKey(ym))
                {
                    htMin.Add(ym, close);
                }
                else
                {
                    if (close < (double)htMin[ym])
                        htMin[ym] = close;
                }
            }

            Console.WriteLine("Maksima:");
            foreach (string k in htMax.Keys)
            {
                Console.WriteLine(k + ": " + htMax[k]);
            }

            Console.WriteLine("\nMinima:");
            foreach (string k in htMin.Keys)
            {
                Console.WriteLine(k + ": " + htMin[k]);
            }

        }
    }
}
    }
}
