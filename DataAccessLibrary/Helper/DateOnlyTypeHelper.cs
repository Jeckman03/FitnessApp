using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLibrary.Helper
{
    public class DateOnlyTypeHelper : SqlMapper.TypeHandler<DateOnly>
    {
        public override void SetValue(IDbDataParameter parameter, DateOnly value)
        {
            parameter.Value = value.ToString("yyyy-MM-dd");
        }

        public override DateOnly Parse(object value)
        {
            return DateOnly.Parse((string)value);
        }
    }
}
