using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    //copy từ iCustomerRepository.cs vào đây, vì nó là interface của service, không phải repository
    public interface ICustomerService
    {
        public void GenerateSampleDataset();
        public List<Customer> GetAllCustomers();
    }
}
