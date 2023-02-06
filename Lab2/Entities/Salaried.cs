using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    internal class Salaried : Employee
    {
        private double salary;

        private double Salary { get { return salary; } }

        public Salaried(string id, string name, string address, double salary)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.salary = salary;
        }

        public override double CalcWeeklyPay()
        {
            return this.salary;
        }
    }
}
