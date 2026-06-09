using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.SqlStatements
{
    public static class PlanSqlStatements
    {
        public static string SavePlan => "Insert into Plans (UserId, StartDate, DurationDays, Goal, CurrentCalorieTarget) Values (@UserId, @StartDate, @DurationDays, @Goal, @CurrentCalorieTarget)";

        public static string GetPlan => "Select * From Plans limit 1";
    }
}
