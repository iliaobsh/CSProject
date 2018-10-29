using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSProject
{
    class FileReader
    {  

        public List<Staff> ReadFile()
        {
            string r;
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            int index;
            string path = "staff.txt";
            string[] separator = { ", " };
            Staff s;
            using (StreamReader sr = new StreamReader(path))
            {
                if (File.Exists(path))
                {
                    while (sr.EndOfStream != true)
                    {
                        r = sr.ReadLine();
                        // result = r.Split(separator,StringSplitOptions.None);
                        index = r.IndexOf(",");
                        result[0] = r.Substring(0, index);
                        result[1] = r.Substring(index+2);
                        if (result[1] == "Manager")
                        {
                            s = new Manager(result[0]);
                            // myStaff.Add(new Manager(result[0]));
                            myStaff.Add(s);
                        }
                       else if (result[1] == "Admin")
                        {
                            s = new Manager(result[0]);
                            //  myStaff.Add(new Admin(result[0]));
                            myStaff.Add(s);
                        }
                        
                        
                    }
                }
            }
            return myStaff;
        }
    }
}
