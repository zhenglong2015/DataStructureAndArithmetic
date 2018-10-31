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
        /// <param name="isDistinct">是否去重</param>
        /// <returns></returns>
        public static List<int> CreateArray(bool isDistinct = false)
        {
            Random random = new Random();

            int arrLength = random.Next(3, 10);

            List<int> array = new List<int>();

            for (int i = 0; i < arrLength; i++)
            {
                Thread.Sleep(20);
                int toAdd = random.Next(0, 10);

                if (isDistinct)
                {
                    if (array.Contains(toAdd))
                    {
                        while (true)
                        {
                            toAdd = random.Next(0, 10);
                            if (!array.Contains(toAdd))
                            {
                                array.Add(toAdd);
                                break;
                            }
                        }
                    }
                    else
                    {
                        array.Add(toAdd);
                    }
                }
                else
                {
                    array.Add(toAdd);
                }
            }
            return array;
        }
    }
}
