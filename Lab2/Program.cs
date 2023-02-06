using Lab2.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            string path = "employees.txt";

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                string id = parts[0];
                string name = parts[1];
                string address = parts[2];

                string firstDigit = id.Substring(0, 1);

                int firstDigitint = int.Parse(firstDigit);

                if (firstDigitint >= 0 && firstDigitint <= 4)
                {
                    // salaried
                    string salary = parts[7];

                    double salaryDouble = double.Parse(salary);

                    Salaried salaried = new Salaried(id, name, address, salaryDouble);
                    employees.Add(salaried);
                }

                else if (firstDigitint >= 5 && firstDigitint <= 7)
                {
                    // waged
                    string rate = parts[7];
                    string hours = parts[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    Wages wages = new Wages(id, name, address, rateDouble, hoursDouble);

                    employees.Add(wages);
                }

                else if (firstDigitint >= 8 && firstDigitint <= 9)
                {
                    // parttime
                    string rate = parts[7];
                    string hours = parts[8];

                    double rateDouble = double.Parse(rate);
                    double hoursDouble = double.Parse(hours);

                    Parttime partTime = new Parttime(id, name, address, rateDouble, hoursDouble);

                    employees.Add(partTime);
                }
            }

            double weeklyPaySum = 0;

            foreach (Employee employee in employees)
            {
                double weeklyPay = employee.CalcWeeklyPay();

                weeklyPaySum += weeklyPay;
            }

            double averageWeeklyPay = weeklyPaySum / employees.Count;

            Console.WriteLine("The average weekly pay is: " + averageWeeklyPay);

            Wages highestPaidWaged = null;

            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    Wages wages = (Wages)employee;

                    if (highestPaidWaged == null || wages.CalcWeeklyPay() > highestPaidWaged.CalcWeeklyPay())
                    {
                        highestPaidWaged = wages;
                    }
                }
            }

            Console.WriteLine("Employee " + highestPaidWaged.Name + " is highest paid (" + highestPaidWaged.CalcWeeklyPay() + ")");

            Salaried lowestPaidSalaried = null;

            foreach (Employee employee in employees)
            {
                if (employee is Salaried)
                {
                    Salaried salaried = (Salaried)employee;

                    if (lowestPaidSalaried == null || salaried.CalcWeeklyPay() < lowestPaidSalaried.CalcWeeklyPay())
                    {
                        lowestPaidSalaried = salaried;
                    }
                }
            }

            Console.WriteLine("Employee " + lowestPaidSalaried.Name + " is highest paid (" + lowestPaidSalaried.CalcWeeklyPay() + ")");

            int waged = 0;
            int Salaried = 0;
            int parttimed = 0;

            foreach (Employee employee in employees)
            {
                if (employee is Wages)
                {
                    waged = waged + 1;
                }

                if (employee is Salaried)
                {
                    Salaried = Salaried + 1;
                }

                if (employee is Parttime)
                {
                    parttimed = parttimed + 1;
                }
            }

            Console.WriteLine("Amount of waged employees is: " + waged);
            Console.WriteLine("Amount of salaried employees is: " + Salaried);
            Console.WriteLine("Amnount of parttime employees is: " + parttimed);
        }
    }
}
