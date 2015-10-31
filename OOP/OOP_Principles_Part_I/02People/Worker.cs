using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02People
{
    class Worker : Human
    {
        public const int WorkDaysPerWeek = 5;

        private float weekSalary;
        private int workHoursPerDay;

        public float WeekSalary 
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value >= 0)
                {
                    this.weekSalary = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Salary can NOT be negative.");
                }
            }
        }
        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value >= 0)
                {
                    this.workHoursPerDay = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Hours can NOT be negative.");
                }
            }
        }

        public string SetFirstName
        {
            set
            {
                base.firstName = value;
            }
        }
        public string SetLastName
        {
            set
            {
                base.lastName = value;
            }
        }
        
        public Worker(string firstName, string lastName, float weekSalary = 0.0f, int workHoursPerDay = 0)
        {
            this.SetFirstName = firstName;
            this.SetLastName = lastName;
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public float MoneyPerHour()
        {
            return (float)(this.weekSalary / (WorkDaysPerWeek * workHoursPerDay));
        }
    }
}
