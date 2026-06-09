using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces.DataAccess
{
    public interface IUserDataAccess
    {
        public Task<int> CreateUserAndGetId(UserModel user);

        public Task SaveUserAsync(UserModel user);

        public Task<UserModel> GetUserAsync(int id);
    }
}
