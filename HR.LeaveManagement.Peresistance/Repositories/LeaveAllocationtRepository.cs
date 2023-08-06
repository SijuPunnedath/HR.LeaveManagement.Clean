using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Peresistence.DatabaseContext;
using HR.LeaveveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Peresistence.Repositories
{
    public class LeaveAllocationtRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        public LeaveAllocationtRepository(HrDatabaseContext context) : base(context)
        {

        }
    }
}
