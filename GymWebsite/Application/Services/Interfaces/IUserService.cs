using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> IsExistUserByMobile(string mobile);
        Task<User> FillUserEntity(UserRegisterDTO userDTO);
        Task AddUserToDB(User user);
        Task<bool> RegisterUser(UserRegisterDTO userDTO);
    }
}
