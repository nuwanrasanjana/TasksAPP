using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.DTOs;
using Tasks.Application.Interfaces.Services;
using Tasks.Domain.Entities;
using Tasks.Domain.Interfaces.Repositories;

namespace Tasks.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }
        public async Task<User?> CreateAsync(RegisterRequest user)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                Email = user.Email,
                Password = _passwordHasher.HashPassword(null, user.Password)
            };
            await _userRepository.CreateAsync(newUser);
            return newUser;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public PasswordVerificationResult VerifyPasswordAsync(User user, string password)
        {
            return _passwordHasher.VerifyHashedPassword(user,user.Password,password);
         
        }
    }
}
