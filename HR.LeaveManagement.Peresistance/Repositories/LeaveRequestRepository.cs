using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Peresistence.DatabaseContext;
using HR.LeaveveManagement.Application.Contracts.Persistance;

namespace HR.LeaveManagement.Peresistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context)
        {

        }
    }
}
