using System;
using System.Collections.Generic;
using System.Text;

namespace FitnessAppLibrary.Services.Interfaces
{
    public interface IDataAccess
    {
        public Task<IEnumerable<T>> LoadDataAsync<T, U>(string sql, U parameters);

        public Task SaveDataAsync<T>(string sql, T parameters);
    }
}
