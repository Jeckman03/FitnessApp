using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.SqlStatements
{
    public static class UserSqlStatements
    {
        public static string GetUserInfo => "Select * From Users limit 1";

        public static string SaveUser => "Insert into Users (Name, DateOfBirth, HeightInches, Gender, ActivityLevel) Values (@Name, @DateOfBirth, @HeightInches, @Gender, @ActivityLevel)";
    }
}
