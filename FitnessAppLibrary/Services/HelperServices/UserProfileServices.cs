using FitnessAppLibrary.Models;
using FitnessAppLibrary.Services.Interfaces;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.HelperServices
{
    public class UserProfileServices : IUserProfileService
    {
        private readonly IUserDataAccess _userDataAccess;

        public UserProfileServices(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            return await _userDataAccess.GetUserAsync(id);
        }

        public async Task SaveUserAsync(UserModel user)
        {
            await _userDataAccess.SaveUserAsync(user);
        }
    }
}
