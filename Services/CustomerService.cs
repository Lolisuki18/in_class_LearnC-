using BusinessObject;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository icustomerRepository;
        public CustomerService()
        {
           icustomerRepository = new CustomerRepository();
        }
        public void GenerateSampleDataset()
        {
            icustomerRepository.GenerateSampleDataset();
        }

        public List<Customer> GetAllCustomers()
        {
            return icustomerRepository.GetAllCustomers();
        }
    }
}
