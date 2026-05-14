using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.SqlStatements
{
    public abstract class DatabaseSql
    {
        public static string CreateTables =>
            @"Create Table if not Exists Users (
                Id Integer Primary Key AutoIncrement,
                Name Text,
                DateOfBirth Text,
                HeightInches Real,
                Gender Integer,
                ActivityLevel Integer);
            
            Create Table if not Exists Plans (
                Id Integer Primary Key AutoIncrement,
                UserId Integer,
                StartDate Text,
                DurationDays Integer,
                Goal Integer); 

            Create Table if not Exists DailyLog (
                Id Integer Primary Key AutoIncrement,
                PlanId Integer,
                StartDate Text,
                Fat Integer,
                Carbs Integer,
                Protien Integer,
                CurrentWeight Real,
                Waits Real,
                MetMacros Integer,
                WorkedOut Integer);";
    }
}
