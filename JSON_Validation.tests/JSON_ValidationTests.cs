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

        [Fact]
        public void ValidateJsonStringWithInvalidStringReturnFalse()
        {
            string jsonString = "TEST\"";
            Assert.False(Program.ValidateJsonString(jsonString));
        }

        [Fact]
        public void ValidateJsonStringWithValidStringReturnTrue()
        {
            string jsonString = "\"TEST\"";
            Assert.True(Program.ValidateJsonString(jsonString));
        }

        [Fact]
        public void ValidateJsonStringWithCharsSmallerThan32ReturnTrue()
        {
            string jsonString = "\"TE\\u0001ST\"";
            Assert.True(Program.ValidateJsonString(jsonString));
        }

        [Fact]
        public void ValidateJsonStringWithQuotationMarkInsideTheStringReturnFalse()
        {
            string jsonString = "\"TE\"ST\"";
            Assert.False(Program.ValidateJsonString(jsonString));
        }

        [Fact]
        public void ValidateJsonStringWithReversSolidusInsideTheStringReturnFalse()
        {
            string jsonString = "\"TE\\ST\"";
            Assert.False(Program.ValidateJsonString(jsonString));
        }

        [Fact]
        public void ValidateJsonStringWithValidReversSolidusInsideTheStringReturnTrue()
        {
            string jsonString = "\"TE\\nST\"";
            Assert.True(Program.ValidateJsonString(jsonString));
        }

        [Fact]
        public void ValidateJsonStringWithOnliOneQuotationMarckReturnFalse()
        {
            string jsonString = "\"";
            Assert.False(Program.ValidateJsonString(jsonString));
        }

        [Fact]
        public void ValidateJsonStringUsingHexaDigitsWithNumbersReturnFalse()
        {
            string jsonString = "\u0097";
            Assert.False(Program.ValidateJsonString(jsonString));
        }

        [Fact]
        public void ValidateJsonStringUsingHexaDigitsWithNumbersAndUpperLettersReturnFalse()
        {
            string jsonString = "\u009F";
            Assert.False(Program.ValidateJsonString(jsonString));
        }
    }
}
