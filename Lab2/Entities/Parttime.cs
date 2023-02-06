using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    internal class Parttime : Employee
    {
        private double rate;
        private double hours;

        private double Rate { get { return rate; } }

        private double Hours { get { return hours; } }

        public Parttime(string id, string name, string address, double rate, double hours)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hours = hours;
        }

        public override double CalcWeeklyPay()
        {
            double weeklyPay = 0;

            weeklyPay = this.rate * this.hours;

            return weeklyPay;
        }
    }
}
