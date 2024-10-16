
# Binary String Evaluator

The **Binary String Evaluator** project provides a tool to validate binary strings based on specific rules. This utility ensures that the binary string contains only `'1's` and `'0's` and that, at any point, the `'0's` do not outnumber the `'1's`, making it valid according to predefined conditions.

## Features

- **Binary String Validation**: Checks if the binary string follows prefix conditions and contains only valid binary digits.
- **Constants for Readability**: Defines constants and enums for messages and binary digits.
- **Comprehensive Unit Tests**: Includes unit tests to verify the validity of binary strings across multiple scenarios.

## Project Structure

The project is organized as follows:

```
EvaluateBinaryStrings/
├── BinaryStringEvalutorService/
│   └── BinaryStringEvaluator.cs          # Main validation logic for binary strings
├── Constants/
│   └── Message.cs                        # Constants for messages and binary digits
├── BinaryStringEvaluatorTestProject/
│   └── BinaryStringEvaluatorUnitTest.cs  # Unit tests for validation logic
└── README.md                             # Project documentation
```

## Installation

Clone this repository and open the solution file (`EvaluateBinaryStrings.sln`) in your preferred C# IDE (e.g., Visual Studio).

```bash
git clone https://github.com/himanshukm-sdei/SDMPilotproject-.git

## Usage

### Binary String Validation

The primary function of the `BinaryStringEvaluator` class is to validate binary strings based on the following rules:

1. **Binary Characters**: The string must only contain `'1's` and `'0's`.
2. **Prefix Condition**: The count of `'0's` should not exceed the count of `'1's` at any position in the string.
3. **Equal Counts**: The string must contain an equal number of `'1's` and `'0's` for it to be considered valid.

### Example Code

```csharp
using EvaluateBinaryStrings.BinaryStringEvalutorService;

bool isValid = BinaryStringEvaluator.ValidateBinaryString("1100");
Console.WriteLine($"Is the binary string valid? {isValid}");
```

## Constants

The `Message` class holds constants and an enum for binary digits to simplify validation:

```csharp
public static class Message
{
    public enum BinaryDigit { Zero = '0', One = '1' }
    public const string InvalidInput = "Invalid input. Please enter a binary string consisting of only 0s and 1s.";
}
```

## Unit Testing

The `BinaryStringEvaluatorUnitTest` class contains tests for various binary string scenarios:

```csharp
[Theory]
[InlineData("1100", true)]
[InlineData("111000", true)]
[InlineData("1000", false)]
[InlineData("11100", false)]
public void TestIsGoodBinaryString(string input, bool expected)
{
    bool result = BinaryStringEvaluator.ValidateBinaryString(input);
    Assert.Equal(expected, result);
}
```

To run the tests, use the test runner in your IDE or the .NET CLI:

```bash
dotnet test
```

---

This README provides details on the setup, usage, and structure of the **Binary String Evaluator** project. Happy coding!
