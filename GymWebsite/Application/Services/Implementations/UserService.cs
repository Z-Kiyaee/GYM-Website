using Application.DTOs;
using Application.Services.Interfaces;
using DaneshkarShop.Application.Utilities;
using Domain.Entities;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementations
{
    public class UserService : IUserService
    {
        #region Ctor

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        public async Task<bool> IsExistUserByMobile(string mobile)
        {
            return await _userRepository.IsExistUserByMobile(mobile.Trim());
        }

        public async Task<User> FillUserEntity(UserRegisterDTO userDTO)
        {
            User user = new User()
            {
                Name = userDTO.Name,
                Mobile = userDTO.Mobile.Trim(),
                Password = PasswordHelper.EncodePasswordMd5(userDTO.Password),
                CreateDate = DateTime.Now,
            };

            return user;
        }

        public async Task AddUserToDB(User user)
        {
            await _userRepository.AddUserToDB(user);
        }

        public async Task<bool> RegisterUser(UserRegisterDTO userDTO)
        {
            if (await IsExistUserByMobile(userDTO.Mobile))
            {
                return false;
            }

            var user = await FillUserEntity(userDTO);
            await AddUserToDB(user);

            return true;
        }

        public async Task<User?> GetUserByMobile(string mobile)
        {
            return await _userRepository.GetUserByMobile(mobile.Trim());
        }
    }
}
