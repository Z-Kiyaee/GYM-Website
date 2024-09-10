using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUserRepository
    {
        Task<bool> IsExistUserByMobile(string mobile);
        Task AddUserToDB(User user);
        Task SaveChanges();
        Task<User?> GetUserByMobile(string mobile);

    }
}
