using AutoMapper;
using HR.LeaveManagement.Domain;
using HR.LeaveveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveveManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile :Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto,LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDto>();
        }
    }
}
