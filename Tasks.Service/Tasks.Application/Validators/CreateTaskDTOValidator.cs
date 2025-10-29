using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.DTOs;

namespace Tasks.Application.Validators
{
    public class CreateTaskDTOValidator : AbstractValidator<CreateTaskItemDTO>
    {
        public CreateTaskDTOValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description should not be empty").WithErrorCode("400");
            RuleFor(x => x.IsCompleted)
                .NotNull().WithMessage("IsCompleted Should not be empty").WithErrorCode("400");
        }
    }
}
