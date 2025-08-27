using api_cinema_challenge.Models;
using api_cinema_challenge.Data;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Repository
{
    public class Repository : IRepository
    {
        private CinemaContext _db;
        public Repository(CinemaContext db)
        {
            _db = db;
        }

        // Customers
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _db.Customers.FindAsync(id);
        }

        public async Task<ICollection<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }
        
        public async Task<Customer> CreateCustomer(Customer model)
        {
            await _db.AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<Customer> UpdateCustomer(int id, Customer model)
        {
            var entity = await GetCustomerById(id);
            entity = model;
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var entity = await GetCustomerById(id);
            if (entity == null) return entity;
            _db.Customers.Remove(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
