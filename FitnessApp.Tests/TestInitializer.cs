using Dapper;
using DataAccessLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FitnessApp.Tests
{
    public abstract class TestInitializer
    {
        [ModuleInitializer]
        public static void Initialize()
        {
            SqlMapper.AddTypeHandler(new DateOnlyTypeHelper());
        }
    }
}
