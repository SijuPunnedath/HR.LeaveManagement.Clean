using HR.LeaveManagement.Domain;

namespace HR.LeaveveManagement.Application.Contracts.Persistance;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<bool> IsLeaveTypeUnique(string name);  
}
