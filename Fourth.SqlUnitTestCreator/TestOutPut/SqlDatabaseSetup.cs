using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using Fourth.Sql.Test.Harness.DatabaseSetup;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestOutPut
{
    [TestClass()]
    public class SqlDatabaseSetup
    {

        [AssemblyInitialize]
        public static void InitializeAssembly(TestContext ctx)
        {
            var db = new TempDb();
            db.Create();
            db.EnableClr(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            var db = new TempDb();
            db.Delete();
        }

    }
}
