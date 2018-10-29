using System;
using System.Collections.Generic;
using System.Threading;

namespace BubbleSort
{
    /// <summary>
    /// 冒泡排序
    /// 
    /// 每一趟确定一个数
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            List<int> array = Common.Logarithm.CreateArray();

            Console.WriteLine("排序前");
            Common.ConsoleHelper.ConsoleWrite(array);


            //Console.WriteLine("第一版排序后");
            //Sort1(array);
            //Common.ConsoleHelper.ConsoleWrite(array);


            //Console.WriteLine("第二版排序后");
            //Sort2(array);
            //Common.ConsoleHelper.ConsoleWrite(array);

            //Console.WriteLine("第三版排序后");
            //Sort3(array);
            //Common.ConsoleHelper.ConsoleWrite(array);

            Console.ReadKey();

        }


        /// <summary>
        /// 第一版
        /// </summary>
        /// <param name="array"></param>
        private static void Sort1(List<int> array)
        {
            int tmp = 0;

            for (int i = 0; i < array.Count; i++)
            {
                for (int j = 0; j < array.Count - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                    }
                }
            }
        }



        /// <summary>
        /// 第二版
        /// </summary>
        /// <param name="array"></param>
        private static void Sort2(List<int> array)
        {
            int tmp = 0;

            for (int i = 0; i < array.Count; i++)
            {
                //有序标记，每一轮的初始是true
                bool isSorted = true;

                for (int j = 0; j < array.Count - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;

                        //有元素交换，设置为false
                        isSorted = false;
                    }
                }
                //没有元素交换说明已经是有序列表则终止
                if (isSorted)
                    break;
            }
        }



        /// <summary>
        /// 第三版
        /// </summary>
        /// <param name="array"></param>
        private static void Sort3(List<int> array)
        {
            int tmp = 0;
            //记录最后一次交换的位置
            int lastExchangeIndex = 0;

            //无序数列的边界，每次比较只需要比到这里为止
            int sortBorder = array.Count - 1;

            for (int i = 0; i < array.Count; i++)
            {
                //有序标记，每一轮的初始是true
                bool isSorted = true;

                for (int j = 0; j < sortBorder; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                        //有元素交换，所以不是有序，标记变为false
                        isSorted = false;

                        //把无序数列的边界更新为最后一次交换元素的位置
                        lastExchangeIndex = j;
                    }
                }
                sortBorder = lastExchangeIndex;

                if (isSorted)
                {
                    break;
                }
            }
        }

    }
}
