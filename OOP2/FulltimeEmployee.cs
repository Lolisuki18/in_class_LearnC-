using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class FulltimeEmployee : Employee //kế thừa: inheritance
    {
        public override double calSalary()
        {
            return base.calSalary() + 5000000;//base là gọi thằng cha 
        }
    }
}
