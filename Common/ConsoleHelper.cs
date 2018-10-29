using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class ConsoleHelper
    {
        public static void ConsoleWrite(List<int> array)
        {
            Console.WriteLine(string.Join(",", array));
        }
    }
}
