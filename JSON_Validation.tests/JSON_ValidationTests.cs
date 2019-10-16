using System;
using Xunit;
using JSON_Validation;

namespace JSON_Validation.tests
{
    public class JSON_ValidationTests
    {
        [Fact]
        public void ValidateJsonStringWithEmptyStringReturnTrue()
        {
            string jsonString = string.Empty;
            Assert.True(Program.ValidateJsonString(jsonString));
        }
    }
}
