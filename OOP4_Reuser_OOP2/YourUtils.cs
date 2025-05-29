using OOP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4_Reuser_OOP2
{
    public static class YourUtils
    {
        public static int Tuoi(this Employee emp)
        {
            return DateTime.Now.Year - emp.birthday.Year;
        }

        public static bool LaThangSinhNhat(this Employee emp)
        {
            return emp.birthday.Month == DateTime.Now.Month;
        }
    }

}
