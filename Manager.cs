using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Manager:Staff
    { 
        private const float managerHOurlyRate=50;

        public int Allowance { get;private set; }

        public Manager(string name) : base(name, managerHOurlyRate)
        {

        }

        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked>160)
            TotalPay += Allowance;
        }

        public override string ToString()
        {
            return "Hourly rate: " + managerHOurlyRate + "\n" + "Hours Worked: " + HoursWorked + "\n" + "Total Pay: " + TotalPay + "\n";
        }

    }
}
