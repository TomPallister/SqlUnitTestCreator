using Fourth.Sql.Test.Harness.DatabaseSetup;
using Microsoft.Data.Tools.Schema.Sql.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestOutPut.SqlUnitTests
{
    [TestClass()]
    public class sp_SomeSp : SqlDatabaseTestClass
    {

        public sp_SomeSp()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sp_SomeSp));
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
            // executionTimeCondition1
            // 
            executionTimeCondition1.Enabled = true;
            executionTimeCondition1.ExecutionTime = System.TimeSpan.Parse("00:00:00.3000000");
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
            tempDb.CopyStoredProcedure("sp_SomeSp");
        }

        [ClassCleanup]
        public static void MyClassCleanup()
        {
            TempDb tempDb = new TempDb();
            tempDb.DeleteStoredProcedure("sp_SomeSp");
        }
        #endregion

        private SqlDatabaseTestActions SqlTest1Data;
    }
}
