using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Password
{

    class ProgramGenerator
    {
        static void Main(string[] args)
        {

            Console.Write("Podaj długość hasła:  ");
            int passwordLenght = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj stopień skomplikowania \n 1-tylko cyfry \n 2-cyfry i znaki alfabetu \n 3-cyfry,znaki alfabetu i znaki specjalne\n");
            byte passwordLevel = Convert.ToByte(Console.ReadLine());

            StringBuilder password = new StringBuilder();

            
            if (passwordLevel == 1)
            {
                for (int i = 0; i < passwordLenght; i++)
                {
                    password.Append(RandomGen(0, 10));
                }
                
                Console.WriteLine("\n"+ "Proponowane hasło: " + password);
            }
            
            else if (passwordLevel==2)
            {

                for (int i = 0; i < passwordLenght; i++)
                {
                    byte threeRandom = (byte)RandomGen(1, 4);

                    switch (threeRandom)
                    {
                        case 1:
                        password.Append(RandomGen(0, 10));
                        break;

                        case 2:
                        password.Append((char)RandomGen(65, 91));
                        break;

                        case 3:
                        password.Append((char)RandomGen(97, 123));
                        break;
                    }


                }

                Console.WriteLine("\n" + "Proponowane hasło: " + password);


            }


            else if (passwordLevel == 3)
            {
                
                for (int i = 0; i < passwordLenght; i++)
                {
                    password.Append((char)RandomGen(33, 127));

                }

                Console.WriteLine("\n" + "Proponowane hasło: " + password);


            }
            else
                Console.WriteLine("Podano niewłaściwą liczbę");

        }

        static Random random = new Random((int)DateTime.Now.Ticks);

        static int RandomGen(int min, int max)
        {

            int n = random.Next(min, max);
            return n;
        }

    }


}
