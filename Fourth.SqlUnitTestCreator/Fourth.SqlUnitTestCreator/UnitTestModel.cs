using System;

namespace Fourth.SqlUnitTestCreator
{
    public class UnitTestModel
    {
        public TimeSpan Duration { get; set; }
        public string SqlCommand { get; set; }
        public string UnitTestName { get; set; }
    }
}
