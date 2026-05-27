using FitnessAppLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{
    public interface IUserProfileService
    {
        public Task SaveUserAsync(UserModel user);

        public Task<UserModel> GetUserAsync(int id);
    }
}
