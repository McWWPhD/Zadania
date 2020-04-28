
            using System;
            using System.Collections.Generic;
            using System.IO;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;


namespace Stock

    {

        class Program
        {
            static void Main(string[] args)
            {


                List<StockData> result = new List<StockData>();

                string path = @"C:\Users\ABBYS\Desktop\nowy.txt";

                string content = File.ReadAllText(path, Encoding.UTF8);

                foreach (String line in content.Split('\n'))
                {
                    string[] items = line.Trim().Split('\t');

                    StockData sd = new StockData();

                    sd.Date = items[0];
                    sd.RateAtOpen = items[1];
                    sd.RateAtLow = items[3];
                    sd.RateAtClose = items[4];

                    result.Add(sd);

                }

                foreach (var day in result)
                {
                    Console.WriteLine(day.Date + " " + day.RateAtOpen);
                }

            }

            public class StockData
            {
                public string Date { get; set; }
                public string RateAtOpen { get; set; }
                public string RateAtHigh { get; set; }
                public string RateAtLow { get; set; }
                public string RateAtClose { get; set; }

            }






        }
}

    