using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Domain.Entities;
using Tasks.Domain.Interfaces.Repositories;
using Tasks.Infrastructure.Context;

namespace Tasks.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly AppDbContext _dbContext;
        public UserRepository(AppDbContext context) : base(context)
        {
            _dbContext = context;
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users
            .SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
