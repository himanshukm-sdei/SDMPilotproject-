using EvaluateBinaryStrings.BinaryStringEvalutorService;

namespace BinaryStringEvaluatorTestProject
{
    public class BinaryStringEvaluatorUnitTest
    {
        
        [Theory]
        [InlineData("1100", true)]      // Equal count with valid prefixes
        [InlineData("111000", true)]    // Equal count but invalid prefix
        [InlineData("1000", false)]      // More '0's than '1's
        [InlineData("11100", false)]     // More '1's than '0's
        [InlineData("101010", true)]     // Valid alternating pattern
        [InlineData("1001", false)]      // Invalid alternating pattern
        [InlineData("", false)]          // Edge case: Empty string
        [InlineData("1", false)]         // Single character: invalid input
        [InlineData("11110000", true)]   // Long valid string
        [InlineData("10", true)]         // Single valid pair
        
        public void TestIsGoodBinaryString(string input, bool expected)
        {
            // Act
            bool result = BinaryStringEvaluator.ValidateBinaryString(input);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}