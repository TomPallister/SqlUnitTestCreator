using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fourth.Sql.Test.Harness.DatabaseSetup;

namespace UnitTestProject1
{
    [TestClass()]
    public class {SpPlaceholder} : SqlDatabaseTestClass
    {

        public {SpPlaceholder}()
        {
            InitializeComponent();
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            base.InitializeTest();
        }
        [TestCleanup()]
        public void TestCleanup()
        {
            base.CleanupTest();
        }

        [TestMethod()]
        public void SqlTest1()
        {
            SqlDatabaseTestActions testActions = this.SqlTest1Data;
            // Execute the pre-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PretestAction != null), "Executing pre-test script...");
            SqlExecutionResult[] pretestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PretestAction);
            // Execute the test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.TestAction != null), "Executing test script...");
            SqlExecutionResult[] testResults = TestService.Execute(this.ExecutionContext, this.PrivilegedContext, testActions.TestAction);
            // Execute the post-test script
            // 
            System.Diagnostics.Trace.WriteLineIf((testActions.PosttestAction != null), "Executing post-test script...");
            SqlExecutionResult[] posttestResults = TestService.Execute(this.PrivilegedContext, this.PrivilegedContext, testActions.PosttestAction);
        }

        #region Designer support code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction SqlTest1_TestAction;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof({SpPlaceholder}));
			 Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExecutionTimeCondition executionTimeCondition1;
            this.SqlTest1Data = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestActions();
            SqlTest1_TestAction = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.SqlDatabaseTestAction();
			executionTimeCondition1 = new Microsoft.Data.Tools.Schema.Sql.UnitTesting.Conditions.ExecutionTimeCondition(); 

			// 
            // SqlTest1_TestAction
            // 
			SqlTest1_TestAction.Conditions.Add(executionTimeCondition1);
            resources.ApplyResources(SqlTest1_TestAction, "SqlTest1_TestAction");
					
            //
            //Execution Time
            //
			executionTimeCondition1.Enabled = true; 
			executionTimeCondition1.Enabled = true; 
			executionTimeCondition1.ExecutionTime = System.TimeSpan.Parse("{ExecutionTime}");
            executionTimeCondition1.Name = "executionTimeCondition1";
            // 
            // SqlTest1Data
            // 
            this.SqlTest1Data.PosttestAction = null;
            this.SqlTest1Data.PretestAction = null;
            this.SqlTest1Data.TestAction = SqlTest1_TestAction;

        }

        #endregion


        #region Additional test attributes
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            TempDb tempDb = new TempDb();
            tempDb.CopyStoredProcedure("{SpPlaceholder}");
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
            TempDb tempDb = new TempDb();
            tempDb.DeleteStoredProcedure("{SpPlaceholder}");
        }
        #endregion

        private SqlDatabaseTestActions SqlTest1Data;
    }
}
