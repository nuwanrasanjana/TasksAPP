using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.DTOs;
using Tasks.Infrastructure.Context;

namespace Tasks.Application.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        private readonly AppDbContext _dbContext;
        public RegisterRequestValidator(AppDbContext dbContext) 
        {
            _dbContext = dbContext;

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Email is invalid.")
                .MustAsync(EmailIsUnique)
                .WithMessage("Email is already registered.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters.");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm password is required.")
                .Equal(x => x.Password).WithMessage("Password and ConfirmPassword must match.");

        }
        private async Task<bool> EmailIsUnique(string username, CancellationToken ct)
        {
            return !await _dbContext.Users.AnyAsync(u => u.Email == username, ct);
        }
    }
}
