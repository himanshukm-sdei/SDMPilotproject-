using EvaluateBinaryStrings.BinaryStringEvalutorService;
using EvaluateBinaryStrings.Constants;

class Program
{
    static void Main()
    {
        string? binaryString = InputBinaryString();       

        // Check if the input is valid and evaluate the binary string
        if (string.IsNullOrEmpty(binaryString))
        {
            Console.WriteLine(Message.InvalidMessage);
        }
        else
        {
            // Evaluate the binary string
            bool isValid = BinaryStringEvaluator.ValidateBinaryString(binaryString);
            if (isValid)
            {
                Console.WriteLine($"'{binaryString}' Is the good binary string ");
            }
            else
            {
                Console.WriteLine($"'{binaryString}' Is not good binary string ");
            }
           
        }
    }

    private static string? InputBinaryString()
    {
        string? input;
        while (true)
        {
            Console.WriteLine(Message.InputString);
            input = Console.ReadLine(); // Read user input

            // Check if the input is a valid binary string
            if (!string.IsNullOrEmpty(input) && input.All(c => c == '0' || c == '1'))
            {
                return input; // Return valid binary string
            }

            Console.WriteLine(Message.InvalidInput);
        }
    }
}
