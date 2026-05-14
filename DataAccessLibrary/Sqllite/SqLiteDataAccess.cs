using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Data.Common;
using System.Text;
using Dapper;
using DataAccessLibrary.SqlStatements;

namespace DataAccessLibrary.Sqllite
{
    public class SqLiteDataAccess
    {
        private readonly string _connectionString;

        public SqLiteDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task InitializeDatabase()
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);
            await connection.ExecuteAsync(DatabaseSql.CreateTables);
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string sql, U parameters)
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);
            return await connection.QueryAsync<T>(sql, parameters);
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            using IDbConnection connection = new SqliteConnection(_connectionString);
            await connection.ExecuteAsync(sql, parameters);
        }
    }
}
