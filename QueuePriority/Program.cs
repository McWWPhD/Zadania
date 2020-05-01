using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace QueuePriorityZ

{
    class Program
    {
//        Zaimplementować klasę QueuePriority realizującą funkcjonalność kolejki z priorytetem.


        static void Main(string[] args)
        {

            Customer cust1 = new Customer("A","A", 1);
            Customer cust2 = new Customer("A", "B", 2);
            Customer cust3 = new Customer("A", "C", 3);
            Customer cust4 = new Customer("A", "D", 1);
            Customer cust5 = new Customer("A", "D", 4);
            Customer cust6 = new Customer("A", "D", 5);
            Customer cust7 = new Customer("A", "D", 5);

            QueuePriority kolejka = new QueuePriority();

            kolejka.Enqueqe(cust1);
            kolejka.Enqueqe(cust2);
            kolejka.Enqueqe(cust3);
            kolejka.Enqueqe(cust4);
            kolejka.Enqueqe(cust5);
            kolejka.Enqueqe(cust6);
            kolejka.Enqueqe(cust7);

            

            Hashtable infoQueue = kolejka.queueStat();

            
            Console.WriteLine("Ilość osób w kolejece: " + kolejka.queueCustomers()+"\n" );

            foreach (DictionaryEntry entry in infoQueue)
            {
                Console.WriteLine("Klientów z priorytetem {0} : {1}", entry.Key, entry.Value);
            }
            Console.WriteLine("--------------");


            Console.WriteLine("Ilość osób w kolejece po Dequeue: " + kolejka.Dequeue() + "\n");

            infoQueue = kolejka.queueStat();

            foreach (DictionaryEntry entry in infoQueue)
            {

                Console.WriteLine("Klientów z priorytetem {0} : {1}", entry.Key,  entry.Value);
            }
            Console.WriteLine("--------------");

            Console.ReadKey();
                        
        }
    }
    //- konstruktor QueuePriority inicjalizującą kolejkę
    public class QueuePriority 
    {
        List<Customer> queue;

        public QueuePriority()            
        {
          queue =  new List<Customer>();
        }


        //- metodę Enqueqe dodającą element(obiekt klasy Customer) do QueuePriority - dodawanie do kolejki
        public void Enqueqe(Customer customer)
        {
            queue.Add(customer);
        }


        //- metodę Dequeue pobierająca element(obiekt klasy Customer) o największej wartości pola priority dla listy obiektu klasy Customer przechowywanej przez QueuePriority, jeśli już nic nie ma w kolejce proszę zwracać null
        public object Dequeue()
        {
            int maxPriority = 0;

            foreach (var client in queue)
            {
                if (client.GetPriority() > maxPriority)
                {
                    maxPriority = client.GetPriority();
                }
                             
            }

            foreach (var client in queue.ToList())
            {
                if (client.GetPriority()==maxPriority)
                    
                {
                    queue.Remove(client);
                }
            }

            if (queue.Count() > 0)
            {
                return queue.Count();
            } else

                return null;
        }


        //- metodę pobierającą informację ile elementów jest w kolejce
        public int queueCustomers ()
        {
            return queue.Count();
        }


        //- metodę pobierającą statystykę kolejki - zwracana jest informacja w formie tablicy hashującej na temat liczby obiektów z danymi wartościami priorytetu
        public Hashtable queueStat ()
        {
            byte maxPriority = 0;
            Hashtable statInfo = new Hashtable();
            
            foreach (var priority in queue)
            {
                if (priority.GetPriority()>maxPriority)
                {
                    maxPriority = (byte)priority.GetPriority();
                }
            }

            for (int i = 1; i <= maxPriority; i++)
            {
            int numberOfClientsWithPriority = 0;

                foreach (var priority in queue)
                {
                    if (priority.GetPriority() == i)
                    {
                        numberOfClientsWithPriority++;
                    }
                }

                statInfo.Add(i, numberOfClientsWithPriority);
            }

            return statInfo;
        }

    }

    //- odnośnie klasy Customer: tu również przyda się pewnie jakiś konstruktor i metoda
    public class Customer
    {
        private string frame;
        private string lname;
        private int priority; //powiedzmy zakres wartości to 1-3, im wyższa wartość, tym priorytet wyższy ma customer

        public Customer(string frame, string lname, int priority)
        {
            this.frame = frame;
            this.lname = lname;
            this.priority= priority;
        }

        //metoda
        public string GetFname()
        {
            return frame;
        }

        public string GetLname()
        {
            return lname;
        }

        public int GetPriority()
        {
            return priority;
        }
    }

}
