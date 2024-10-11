using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluateBinaryStrings.Constants
{
    public static class Message
    {
        public const string InvalidInput = "Invalid input. Please enter a binary string consisting of only 0s and 1s.";
        public const string InputString = "Enter a binary string (only 0s and 1s):";
        public const string InvalidMessage = "Please enter a valid binary string.";

        public  enum BinaryDigit
        {
            Zero='0',
            One='1'  
        }

    }
}
