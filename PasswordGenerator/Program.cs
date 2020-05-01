using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Password
{

    class ProgramGenerator
    {
        static void Main(string[] args)
        {

            Console.Write("Podaj długość hasła:  ");
            int passwordLenght = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Podaj stopień skomplikowania \n 1-tylko cyfry \n 2-cyfry i znaki alfabetu \n 3-cyfry,znaki alfabetu i znaki specjalne");
            byte passwordLevel = Convert.ToByte(Console.ReadLine());

            StringBuilder password = new StringBuilder();
            
            

            if (passwordLevel==1)
            {
                for (int i = 0; i <= passwordLenght; i++)
			{
                    password.Append(RandomGen(1,9));
			}
            
            
            }


            Console.WriteLine(password);

        }

        static int RandomGen (int min, int max)
            {    
            Random random = new Random(min, max);
            }

    }


}
