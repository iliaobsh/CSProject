using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace CSProject
{
    class Staff
    {
        //a
        private float hourlyRate;
        private int hWorked;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameofStaff { get; private set; }
        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                if (value > 0)
                    hWorked = value;
                else
                    hWorked = 0;
                    
            }
        }

        public Staff(string name,float rate)
        {
            NameofStaff = name;
            hourlyRate = rate;
        }


        virtual public void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "Hourly rate: " + hourlyRate + "\n" + "Hours Worked: " + hWorked + "\n" + "Total Pay: " + TotalPay + "\n";
        }

    }
}
