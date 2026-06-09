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

        public async Task<int> CreateUserAndGetId(UserModel user)
        {
            string sql = "Insert into Users (Name, DateOfBirth, HeightInches, Gender, ActivityLevel) Values (@Name, @DateOfBirth, @HeightInches, @Gender, @ActivityLevel); Select last_insert_rowid();";

            int newUserId = await _db.SaveDataAndGetIdAsync(sql, user);

            return newUserId;
        }

        public async Task SaveUserAsync(UserModel user)
        {
            var sql = "Insert into Users (Name, DateOfBirth, HeightInches, Gender, ActivityLevel) Values (@Name, @DateOfBirth, @HeightInches, @Gender, @ActivityLevel)";

            await _db.SaveDataAsync<UserModel>(sql, user);
        }

        public async Task<UserModel> GetUserAsync(int id)
        {
            var sql = "Select * From Users limit 1";

            var results = await _db.LoadDataAsync<UserModel, object>(sql, new { Id = id });
            return results.FirstOrDefault();
        }
    }
}
