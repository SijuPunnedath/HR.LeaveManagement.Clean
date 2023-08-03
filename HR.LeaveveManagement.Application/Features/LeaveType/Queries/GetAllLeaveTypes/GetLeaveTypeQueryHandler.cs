using AutoMapper;
using HR.LeaveveManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypeQueryHandler : IRequestHandler<GetLeaveTypeQuery, List<LeaveTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeQueryHandler(IMapper mapper ,ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;
            this._leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeQuery request, CancellationToken cancellationToken)
        {
            //Query the daatabase
            var leaveTypes = await _leaveTypeRepository.GetAsync();

            //Convert DataObject to DTO object
            var data = _mapper.Map<List<LeaveTypeDto>>(leaveTypes);

            //Return List Of Dto
            return data;
        }
    }
}
