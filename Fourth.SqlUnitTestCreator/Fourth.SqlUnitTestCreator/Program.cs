using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Microsoft.SqlServer.Management.Trace;

namespace Fourth.SqlUnitTestCreator
{
    class Program
    {
        static void CreateUnitTest(UnitTestModel unitTest)
        {
            const string classTemplate = "sptemplate.cs";
            const string resxTemplate = "sptemplate.resx";

            var classText = File.ReadAllText(classTemplate);
            var resxText = File.ReadAllText(resxTemplate);


            string testString = HttpUtility.HtmlEncode(unitTest.SqlCommand);

            var executionTime = string.Format("{0}:{1}:{2}.{3}", unitTest.Duration.Hours, unitTest.Duration.Minutes,
                unitTest.Duration.Seconds, unitTest.Duration.Milliseconds);

            if (executionTime == "0:0:0.0")
            {
                executionTime = "0:0:1.0";
            }

            var newClassText = classText.Replace("{SpPlaceholder}", unitTest.UnitTestName).Replace("{ExecutionTime}", executionTime);
            var newResxText = resxText.Replace("{SqlCommandPlaceholder}", unitTest.SqlCommand);

            File.WriteAllText(string.Format(@"SqlUnitTests\{0}.cs", unitTest.UnitTestName), newClassText);
            File.WriteAllText(string.Format(@"SqlUnitTests\{0}.resx", unitTest.UnitTestName), newResxText);
        }

        static TimeSpan GetDuration(TraceFile reader)
        {
            DateTime startTime = reader.SafeValue("StartTime", DateTime.Now);
            DateTime endTime = reader.SafeValue("EndTime", DateTime.Now);
            TimeSpan duration = endTime - startTime;
            return duration;
        }

        static void Main()
        {
            const string traceFile = "trace.trc";        
            var reader = new TraceFile();
            reader.InitializeAsReader(traceFile);
            var unitTestModels = new List<UnitTestModel>();
            while (reader.Read())
            {
                var unitTest = new UnitTestModel()
                {
                    SqlCommand = HttpUtility.HtmlEncode(reader.SafeValue("TextData", "")),
                    UnitTestName = reader.SafeValue("ObjectName", ""),
                    Duration = GetDuration(reader)
                };
                if (!string.IsNullOrEmpty(unitTest.SqlCommand) && (unitTest.SqlCommand != "exec sp_reset_connection") && (unitTest.UnitTestName != "sp_executesql"))
                {
                    unitTestModels.Add(unitTest);
                }
            }
            foreach (var unitTestModel in unitTestModels)
            {
                if (unitTestModel.UnitTestName == "usp_CORE_GetRevenueStreamList")
                {
                    Console.WriteLine("Crap");
                }
                CreateUnitTest(unitTestModel);
            }
        }
    }
}
