using DataAccessLibrary.Sqllite;
using DataAccessLibrary.SqlStatements;
using FitnessAppLibrary.Models;
using FitnessAppLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Services
{
    public class UserProfileServices : IUserProfileService
    {
        private readonly  IDataAccess _db;

        public UserProfileServices(IDataAccess db)
        {
            _db = db;
        }

        public async Task SaveUserAsync(UserModel user)
        {
            await _db.SaveDataAsync<UserModel>(UserSqlStatements.SaveUser, user);
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            var results = await _db.LoadDataAsync<UserModel, object>(UserSqlStatements.GetUserInfo, new { Id = id });
            return results.FirstOrDefault();
        }
    }
}
