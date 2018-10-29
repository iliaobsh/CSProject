using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSProject
{
    class PaySlip
    { 
        private int month;
        private int year;

        enum MonthsOfYear {JAN=1,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC }

        public PaySlip(int payMonth,int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (var f in myStaff)
            {
                path = f.NameofStaff + ".txt";
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("PAYSLIP FOR "+ (MonthsOfYear)month + " "+year);
                sw.WriteLine("====================");
                sw.WriteLine("Name of Staff: " + f.NameofStaff);
                sw.WriteLine("Hours worked: " + f.HoursWorked);
                sw.WriteLine();

                sw.WriteLine("Basic Pay: {0:C}" , f.BasicPay);
                if (f.GetType() == typeof(Manager))
                    sw.WriteLine("Allowance: {0:C}" , ((Manager)(f)).Allowance);
                else if(f.GetType() == typeof(Admin))
                    sw.WriteLine("Overtime Pay: {0:C}",((Admin)(f)).Overtime);

                sw.WriteLine();
                sw.WriteLine("====================");
                sw.WriteLine("Total Pay: {0:C}",f.TotalPay);
                sw.WriteLine("====================");
                sw.Close();
            }
        }

        public void GenerateSummary(List<Staff> mystaff)
        {
            var result =
                from person in mystaff
                where person.HoursWorked < 10
                orderby person.NameofStaff ascending
                select new { person.NameofStaff,person.HoursWorked};

            string path = "summary.txt";

            StreamWriter sws = new StreamWriter(path);
            sws.WriteLine("Staff with less than 10 working hours\n");
            foreach (var item in result)
            {
                sws.WriteLine("NAme of Staff: " + item.NameofStaff + ", Hours Worked: " + item.HoursWorked);
            }
            sws.Close();
        }

        public override string ToString()
        {
            return "month " + month + "\n" + "year: " + year + "\n";
        }
    }
}
