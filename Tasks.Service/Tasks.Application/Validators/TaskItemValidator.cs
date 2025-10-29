using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.DTOs;
using Tasks.Domain.Entities;

namespace Tasks.Application.Validators
{
    public class TaskItemValidator : AbstractValidator<TaskItem>
    {
        public TaskItemValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Id should not be empty......").WithMessage("400");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description should not be empty.....").WithErrorCode("400");
            RuleFor(x => x.IsCompleted)
                .NotNull().WithMessage("IsCompleted Should not be empty......").WithErrorCode("400");
        }
    }
}
