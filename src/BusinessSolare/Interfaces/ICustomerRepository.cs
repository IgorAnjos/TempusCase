using BusinessTempus.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessTempus.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerById(Guid id);
        Task<Customer> GetCustomerByCpf(string cpf);
        Task<Customer> GetCustomerByName(string name);
        Task<IEnumerable<Customer>> GetAllCustomer();
        Task<int> GetCount();
        Task<int> GetCountClassA();
        Task<int> GetCountClassB();
        Task<int> GetCountClassC();
    }
}
