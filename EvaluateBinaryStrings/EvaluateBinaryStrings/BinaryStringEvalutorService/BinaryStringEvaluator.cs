using EvaluateBinaryStrings.Constants;

namespace EvaluateBinaryStrings.BinaryStringEvalutorService
{
    public class BinaryStringEvaluator
    {
        public static bool ValidateBinaryString(string binaryString)
        {
            int onesCount = 0, zerosCount = 0;
            try
            {
                // Return false for empty strings
                if (string.IsNullOrEmpty(binaryString))
                    return false;

                // Traverse the string and check the prefix condition
                foreach (char character in binaryString)
                {
                    switch (character)
                    {
                        case (char)Message.BinaryDigit.One:
                            onesCount++;
                            break;

                        case (char)Message.BinaryDigit.Zero:
                            zerosCount++;
                            break;

                        default:
                            // Invalid character detected; return false immediately
                            return false;
                    }

                    // Check prefix condition: zeros should not exceed ones                    
                    if (onesCount < zerosCount)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
            // Final check: equal number of '1's and '0's
            return onesCount == zerosCount;
        }

    }
}
