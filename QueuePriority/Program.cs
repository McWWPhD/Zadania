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

            Customer cust1 = new Customer("W","W", 1);
            Customer cust2 = new Customer("A", "W", 3);
            Customer cust3 = new Customer("E", "W", 3);

            QueuePriority queue = new QueuePriority(List<Customer> queue);



        }
    }
    //- konstruktor QueuePriority inicjalizującą kolejkę
    public class QueuePriority
    {
        private List<Customer> queue = new List<Customer>();

        public QueuePriority(List<Customer> queue)            
        {
            this.queue = queue;
        }


        //- metodę Enqueqe dodającą element(obiekt klasy Customer) do QueuePriority - dodawanie do kolejki
        public void Enqueqe(Customer customer)
        {
            queue.Add(customer);
        }

        //- metodę Dequeue pobierająca element(obiekt klasy Customer) o największej wartości pola priority dla listy obiektu klasy Customer przechowywanej przez QueuePriority, jeśli już nic nie ma w kolejce proszę zwracać null
        public void Dequeue(Customer customer)
        {                              
            queue.Remove(customer);
        }


        //- metodę pobierającą informację ile elementów jest w kolejce
        public int queueCustomers (Customer customer)
        {
            return queue.Count();
        }


        //- metodę pobierającą statystykę kolejki - zwracana jest informacja w formie tablicy hashującej na temat liczby obiektów z danymi wartościami priorytetu
        public Hashtable queueStat (List<Customer> queue)
        {
            int numberOfP1= 0, numberOfP2=0, numberOfP3=0;

            Hashtable statInfo = new Hashtable();
            
            statInfo.Add("Klientów z Priorytetem 1: ", numberOfP1);
            statInfo.Add("Klientów z Priorytetem 2: ", numberOfP2);
            statInfo.Add("Klientów z Priorytetem 3: ", numberOfP3);
            
            foreach (var item in queue)
            {
                if (item.GetPriority() == 1)
                {
                    numberOfP1++;
                }
                
                if (item.GetPriority() == 2)
                {
                    numberOfP2++;
                }

                if (item.GetPriority() == 3)
                {
                    numberOfP3++;
                }
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
