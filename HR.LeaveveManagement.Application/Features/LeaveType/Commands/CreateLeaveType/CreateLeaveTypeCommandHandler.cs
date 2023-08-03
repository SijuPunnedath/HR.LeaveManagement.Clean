using AutoMapper;
using HR.LeaveveManagement.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement;


namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private IMapper _mapper;
        private ILeaveTypeRepository _leaveTypeRepository;   

        public CreateLeaveTypeCommandHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            this._mapper = mapper;   
            this._leaveTypeRepository = leaveTypeRepository;
             
        }
      

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            //Validate INcoming Data

            //Convert to domain entity object
            var leaveTypeTocreate = _mapper.Map<Domain.LeaveType>(request);
            //Add to Database
           await _leaveTypeRepository.CreateAsync(leaveTypeTocreate);
            //return recoed Id

            return leaveTypeTocreate.Id;
        }
    }
}
