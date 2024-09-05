using Domain.Entities;
using Domain.IRepositories;
using Infra.Data.AppDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Ctor

        private readonly GymDbContext _context;

        public UserRepository(GymDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<bool> IsExistUserByMobile(string mobile)
        {
            return await _context.Users.AnyAsync(p => p.Mobile == mobile);
        }

        public async Task AddUserToDB(User user)
        {
            await _context.Users.AddAsync(user);
            await SaveChanges();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
