using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveveManagement.Application.Contracts.Persistance;

public interface IGenericRepository<T> where T : class
{
    Task<T> GetAsync(T entity);

    Task<T> GetByIdAsync(T entity);

    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(T entity);

    Task<T> DeleteAsync(T entity);

}
