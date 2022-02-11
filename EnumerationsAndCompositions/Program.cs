using System;
using System.Globalization;
using EnumerationsAndCompositions.Entities;
using EnumerationsAndCompositions.Entities.Enumerations;

namespace EnumerationsAndCompositions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to Worker-Contracts Manager...");
            Console.WriteLine("-----------------------------------------------");
            Console.Write("\tTo initiate, enter Department's name: ");
            Department deptName = new Department(Console.ReadLine());

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Now we're starting to fill Worker's data...");
            Console.Write("\tWorker Name: ");
            string wrkName = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write("Worker Professional Level:\n\t1 for Junior\n\t2 for MidLevel\n\t3 for Senior: ");
            WorkerLevel wrkLevel = (WorkerLevel)int.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            Console.Write("\tWorker Base Salary (only numbers): ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("\n");

            Worker worker = new Worker(wrkName, wrkLevel, baseSalary, deptName);

            Console.WriteLine("-----------------------------------------------");
            Console.Write("How many Contract does this Worker has? Type only numbers: ");
            int numOfContracts = int.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------------------------");

            for (int i = 0; i < numOfContracts; i++)
            {
                Console.WriteLine($"Enter #{i+1} Contract Data: ");
                Console.Write("\tDate (dd/MM/yyyy): ");
                DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine("\n");
                Console.Write("\tValue per Hour (only numbers): ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("\n");
                Console.Write("\tDuration of the Contract (in hours): ");
                int duration = int.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                HourContract contract = new HourContract(contractDate, valuePerHour, duration);
                worker.AddContract(contract);

            }

            Console.WriteLine("-----------------------------------------------");
            Console.Write("Enter month and year to calculate Worker's income (MM/yyyy): ");
            DateTime incomeDate = DateTime.ParseExact(Console.ReadLine(), "MM/yyyy", CultureInfo.InvariantCulture);

            double income = worker.Income(incomeDate.Month, incomeDate.Year);

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Worker Income: \n");
            Console.WriteLine($"\tName: {worker.Name}");
            Console.WriteLine($"\tDepartment: {worker.Department.Name}");
            Console.WriteLine($"\tIncome for {incomeDate.Month}/{incomeDate.Year}: {income}");

            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine("Bye!!!\n"); 
            Console.WriteLine("-----------------------------------------------");
            
        }
    }
}
