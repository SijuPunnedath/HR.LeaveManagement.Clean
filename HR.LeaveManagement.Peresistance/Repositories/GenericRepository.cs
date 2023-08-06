using HR.LeaveManagement.Peresistence.DatabaseContext;
using HR.LeaveveManagement.Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Peresistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected HrDatabaseContext _context;

        public GenericRepository(HrDatabaseContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);    
            await _context.SaveChangesAsync();
          
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
          return await _context.Set<T>().FindAsync(Id);
        }

        public async Task UpdateAsync(T entity)
        {
           //_context.Update(entity);
           _context.Entry(entity).State = EntityState.Modified;
           await _context.SaveChangesAsync();
            
        }

       
    }
}
