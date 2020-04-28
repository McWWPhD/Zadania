using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CzasPracy
{
//    Zaimplementuj klasę `Employee` umożliwiającą rejestrowanie czasu pracy oraz
//wypłacanie pensji na podstawie zadanej stawki godzinowej.Jeżeli pracownik
//będzie pracował więcej niż 8 godzin (podczas pojedynczej rejestracji czasu) to
//kolejne godziny policz jako nadgodziny(z podwójną stawką godzinową).
//Konstruktor klasy niech przyjmuje imię, nazwisko i stawkę godzinową.
//Przykład użycia:
//Employee emp1 = new Employee("Jan", "Nowak", 100.0);
//    emp1.RegisterTime(5);   //za to naliczy mu się 5*100
//emp1.RegisterTime(10);  //za to naliczy mu się 8*100 + 2*200
//emp1.RegisterTime(7.5); //za to naliczy mu się 7.5*100
//emp1.PaySalary(); //wyplacanie = stan należności po stronie pracodawcy = 0
//emp1.RegisterTime(11);  //za to naliczy mu się 8*100 + 3*200
//emp1.PaySalary();

    }

    class Program
    {
        static void Main(string[] args)
        {



        Employee employee = new Employee("Jan", "Nowak", 100.00);

        double empSalary = employee.RegisterTime(10);

        employee.PaySalary(empSalary);


        }
    }


public class Employee
{
    private string firstName;
    private string lastName;
    private double salaryPerHour = 0;

    public Employee(string firstName, string lastName, double salaryPerHour)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.salaryPerHour = salaryPerHour;
    }

    public double RegisterTime(double hours)
    {
        double salary = 0;

        if (hours <= 8)
        {
            salary = hours * salaryPerHour;
        }

        if (hours > 8)
        {
            salary = 8 * salaryPerHour + (hours - 8) * (2 * salaryPerHour);
        }
        return salary;
    }

    public void PaySalary(double salary)
    {
        Console.WriteLine("Pracownik: {0} {1} \nDo wypłaty: {2}", firstName, lastName, salary );
    }
}
