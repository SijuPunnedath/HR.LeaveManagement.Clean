using HR.LeaveManagement.Domain;
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
    public class LeaveTypeRepository :GenericRepository<LeaveType>,ILeaveTypeRepository
    {
        public LeaveTypeRepository(HrDatabaseContext context) :base(context) 
        {
                
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            //-- Here _context is the base context of GenericRepository . Since we are passing as base(context) it is assesible here
           
            return await _context.LeaveTypes.AnyAsync(t => t.Name == name);
        }
    }
}
