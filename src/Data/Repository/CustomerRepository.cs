using BusinessTempus.Interfaces;
using BusinessTempus.Models;
using DataTempus.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTempus.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataDbContext context) : base(context) { }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await Db.Customers.AsNoTracking()
                .OrderBy(cst => cst.FullName).ToListAsync();
        }

        public async Task<int> GetCountClassA()
        {
            return await Db.Customers.Where(w => w.FamilyIncome <= 980).CountAsync();
        }

        public async Task<int> GetCountClassB()
        {
            return await Db.Customers.Where(w => w.FamilyIncome <= 2500 && w.FamilyIncome > 980).CountAsync();
        }

        public async Task<int> GetCountClassC()
        {
            return await Db.Customers.Where(w => w.FamilyIncome >= 2500).CountAsync();
        }

        public async Task<int> GetCount() => await Db.Customers.CountAsync();

        public async Task<Customer> GetCustomerByCpf(string cpf)
        {
            return await Db.Customers.AsNoTracking()
                .FirstOrDefaultAsync(cst => cst.Cpf.Equals(cpf));
        }

        public async Task<Customer> GetCustomerById(Guid id)
        {
            return await Db.Customers.AsNoTracking()
                .FirstOrDefaultAsync(cst => cst.Id == id);
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            return await Db.Customers.AsNoTracking()
                .FirstOrDefaultAsync(cst => cst.FullName.Equals(name));
        }
    }
}