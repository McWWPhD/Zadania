using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;


namespace Titanic
{
    class Program
    {
        /*Celem Waszego programu jest znaleźć TOP 10 najstarszych ocalałych osób z Titanica, chciałbym aby informacja na temat tych osób zawierała dane z kolumn Name, Age, Pclass.*/


        static void Main(string[] args)
        {

            Console.WriteLine("Dziesięciu najstarszych ocalałych Tytanika to: ");
            
            List<Person> passengers = new List<Person>();

            string path = @"C:\titanic.tsv";

            List<string> fileData = File.ReadAllLines(path).Skip(1).ToList();

            foreach (String line in fileData)
            {
                string[] data = line.Trim().Split('\t');
                                
                Person person = new Person();

                        
                person.Survived = byte.Parse(data[1]);
                person.Pclass = byte.Parse(data[2]);
                person.Name = data[3];

                if (byte.TryParse(data[5].Replace('.', ','), out byte result) )
                {
                    person.Age = result;
                }                      

                passengers.Add(person);
                
            };

            List<Person> OldestSurvivers = new List<Person>();

            foreach (var passenger in passengers.OrderByDescending(passenger => passenger.Age))
            {
                if (passenger.Survived == 1 )
                {
                        OldestSurvivers.Add(passenger);
                }

            }

            foreach (var survivor in OldestSurvivers.GetRange(0,10) )
            {
                Console.WriteLine($"{survivor.Name}   |Wiek: {survivor.Age} |Klasa: {survivor.Pclass}" );

            }
          
        }

    }

    public class Person
    
    {
        //PassengerId	Survived	Pclass	Name    Sex	Age	SibSp	Parch	Ticket	Fare	Cabin	Embarked

        public byte Survived { get; set; }
        public byte Pclass { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }                          
    }
}
