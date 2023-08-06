using FluentValidation;
using FluentValidation.Validators;
using HR.LeaveveManagement.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator : AbstractValidator<CreateLeaveTypeCommand>   
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository; 
        
        public CreateLeaveTypeCommandValidator( ILeaveTypeRepository leaveTypeRepository)
        {
            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("{PropertyName} is required")
               .NotNull()
               .MaximumLength(70).WithMessage("{PropertyName} must be fewer than {MaxLength} characters")
               .MinimumLength(3).WithMessage("{PropertyName} must be at least {MinLength} characters");

            
            RuleFor(p => p.DefaultDays)
                .LessThan(100).WithMessage("{PropertyName} cannot exceed 100")
                .GreaterThan(1).WithMessage("{PropertyName} cannot be less than 1");

            RuleFor(q => q)
                .MustAsync(LeaveTypeNameUnique)
                .WithMessage("{PropertyName} already exists");

            this._leaveTypeRepository = leaveTypeRepository;    
        }

        private Task<bool> LeaveTypeNameUnique(CreateLeaveTypeCommand command, CancellationToken token)
        {
            return _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
        }

    }
}
