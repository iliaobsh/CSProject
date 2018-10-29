using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    class Program
    { 
        static void Main(string[] args)
        {
            List<Staff> myStaff =  new List<Staff>();
            FileReader fr=new FileReader();
           myStaff= fr.ReadFile();
            int month=0;
            int year=0;

            while (year == 0)
            {
                Console.Write("Please enter the year: ");

                try
                {
                   year=Convert.ToInt32( Console.ReadLine());
                }
                catch
                {
                    Console.Write("An error number was entered");
                }
            }


            while (month == 0)
            {
                Console.Write("Please enter the month: ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Write("An error number was entered");
                }
            }


            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.Write("Enter number of hours worked for " + myStaff[i].NameofStaff+": ");
                  myStaff[i].HoursWorked= Convert.ToInt32( Console.ReadLine());
                    myStaff[i].CalculatePay();
                }
                catch (Exception e){
                    Console.WriteLine(e);
                    --i;
                }
            }

            PaySlip ps=new PaySlip(month,year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
        }
    }
}
