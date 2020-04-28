using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiczbyRzymskieArabskie
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



            Console.WriteLine(RzymskieNaArabskie("MM"));

        }




        public static int RzymskieNaArabskie(string rzymskie)
        {

            Dictionary<char, int> slownik = new Dictionary<char, int>()

                {

                    { 'I', 1},
                    { 'V', 5 },
                    { 'X', 10 },
                    { 'L', 50 },
                    { 'C', 100 },
                    { 'D', 500 },
                    { 'M', 1000 }

                };

            //slownik['D']

            int arabskie = 0;

            for (int i = 0; i < rzymskie.Length; i++)
            {

                if (i != rzymskie.Length - 1 && slownik[rzymskie[i]] < slownik[rzymskie[i + 1]])
                {
                    arabskie += slownik[rzymskie[i + 1]] - slownik[rzymskie[i]];
                    i++;
                    continue;
                }
                else
                {                    
                    arabskie += slownik[rzymskie[i]];
                }
            }

            return arabskie;

        } 
    }






    }





