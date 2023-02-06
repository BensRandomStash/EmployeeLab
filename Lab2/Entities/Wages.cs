using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    internal class Wages : Employee
    {
        private double rate;
        private double hours;

        private double Rate { get { return rate; } }

        private double Hours { get { return hours; } }

        public Wages(string id, string name, string address, double rate, double hours)
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

            if (this.hours < 40)
            {
                weeklyPay = this.rate * this.hours;
            }
            else
            {
                double overtimeHours = this.hours - 40;
                
                weeklyPay = this.rate * 40;

                double overtimePay = overtimeHours * (this.rate * 1.5);

                weeklyPay += overtimePay;
            }

            return weeklyPay;
        }
    }
}
