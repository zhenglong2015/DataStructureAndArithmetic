using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Common
{
    public class Logarithm
    {

        /// <summary>
        /// 对数器
        /// </summary>
        /// <returns></returns>
        public static List<int> CreateArray()
        {
            Random random = new Random();

            int arrLength = random.Next(3, 10);

            List<int> array = new List<int>();

            for (int i = 0; i < arrLength; i++)
            {
                Thread.Sleep(20);
                array.Add(random.Next(0, 10));
            }

            return array;
        }
    }
}
