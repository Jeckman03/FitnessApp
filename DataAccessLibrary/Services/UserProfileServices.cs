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
        private readonly SqLiteDataAccess _db;

        public UserProfileServices(SqLiteDataAccess db)
        {
            _db = db;
        }

        public async Task SaveUserAsync(UserModel user)
        {
            await _db.SaveData<UserModel>(UserSqlStatements.SaveUser, user);
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            var results = await _db.LoadData<UserModel, object>(UserSqlStatements.GetUserInfo, new { Id = id });
            return results.FirstOrDefault();
        }
    }
}
