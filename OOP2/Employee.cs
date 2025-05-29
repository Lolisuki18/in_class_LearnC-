using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class Employee
    {
        public int id { get; set; }

        public string idCard { get; set; }

        public string name { get; set; }
        public DateTime birthday { get; set; }

        public virtual double calSalary() // các lớp con có thể định nghĩa lại hoặc ko định nghĩa lại (virtual)
        {
            return 4000000;
        }

        public override string ToString()
        {
            //return id + "\t" + idCard + "\t" + name + "\t" + birthday.ToString("dd/MM/yyyy") + "\t" + calSalary();
            return id + "\t" + idCard + "\t" + name + "\t" + birthday.ToString("dd/MM/yyyy") + "\t" + calSalary();
        }

    }
}
