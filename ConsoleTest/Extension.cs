using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTest
{
    static class Extension
    {
        public static bool CheckSpaceAndUScore(this string input)
        {
            return input.Contains(" ") || input.Contains("_");
        }
    }
}
