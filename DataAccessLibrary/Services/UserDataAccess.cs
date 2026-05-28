using DataAccessLibrary.Sqllite;
using DataAccessLibrary.SqlStatements;
using FitnessAppLibrary.Models;
using FitnessAppLibrary.Services.Interfaces.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Services
{
    public class UserDataAccess : IUserDataAccess
    {
        private readonly  IDataAccess _db;

        public UserDataAccess(IDataAccess db)
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
