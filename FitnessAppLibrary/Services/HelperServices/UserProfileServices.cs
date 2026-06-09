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
        private readonly IUnitConversionSerivce _unitConversionSerivce;

        public UserProfileServices(IUserDataAccess userDataAccess, IUnitConversionSerivce unitConversionSerivce)
        {
            _userDataAccess = userDataAccess;
            _unitConversionSerivce = unitConversionSerivce;
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            return await _userDataAccess.GetUserAsync(id);
        }

        public async Task SaveUserAsync(UserModel user)
        {
            if (user == null) throw new Exception("User parameter is null");
            if (user.Age < 1) throw new Exception("Age is less than one");



            await _userDataAccess.SaveUserAsync(user);
        }
    }
}
