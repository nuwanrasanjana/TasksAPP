using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.DTOs;
using Tasks.Domain.Entities;

namespace Tasks.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> CreateAsync(RegisterRequest user);
        PasswordVerificationResult VerifyPasswordAsync(User user, string password);

    }
}
