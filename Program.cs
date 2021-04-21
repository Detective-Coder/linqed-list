using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }

    public class Bank
    {
      public string BankName;
      public int NumberOfCustomers;
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

            IEnumerable<string> LFruits = from fruit in fruits 
            where fruit.StartsWith("L") 
            select fruit;

            foreach (string f in LFruits)
            {
              Console.WriteLine($"{f}");
            }

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0);

            foreach (int n in fourSixMultiples)
            {
              Console.WriteLine($"{n}");
            }

            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                "Francisco", "Tre"
            };

            var descend = names.OrderByDescending(n => n);  
            
            foreach (string n in descend)
            {
              Console.WriteLine($"{n}");
            }

            // // Build a collection of these numbers sorted in ascending order
            // List<int> numbers = new List<int>()
            // {
            //     15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            // };

            var ascendingNumbers = numbers.OrderBy(n => n);

            foreach (int n in ascendingNumbers)
            {
              Console.WriteLine($"{n}");
            }

            // Output how many numbers are in this list
            // List<int> numbers = new List<int>()
            // {
            //     15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            // };
            Console.WriteLine();
            Console.WriteLine("There are " + numbers.Count + " numbers in the numbers list.");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
            Console.WriteLine();
            Console.WriteLine("The sum of purchases is " + purchases.Sum());

            // What is our most expensive product?
            List<double> prices = new List<double>()
            {
                879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
            };
            Console.WriteLine();
            Console.WriteLine("The most expensive product in prices is " + prices.Max());
            Console.WriteLine();
            // Build a collection of customers who are millionaires


            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            IEnumerable<Customer> millionairesClub = customers.Where(customer => customer.Balance > 999999);
            Console.WriteLine("Millionaires Club:");
            foreach (Customer m in millionairesClub)
            {
              Console.WriteLine($"{m.Name}");
            }
            Console.WriteLine();
            Console.WriteLine("Banks and # of Customers");

            List<Bank> countOfMillionairesAtEachBank = (from customer in millionairesClub
              group customer by customer.Bank into millionaires
              select new Bank {
                BankName = millionaires.Key,
                NumberOfCustomers = millionaires.Count()
              }).OrderByDescending(b => b.NumberOfCustomers).ToList();

              
            foreach (Bank c in countOfMillionairesAtEachBank)
            {
              Console.WriteLine($"{c.BankName} {c.NumberOfCustomers}");
            }

        }
    }
}
