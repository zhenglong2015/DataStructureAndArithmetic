using System;
using System.Collections.Generic;

namespace CocktailSoft
{
    /// <summary>
    /// 鸡尾酒排序
    /// 快乐小时排序
    /// 双向冒泡排序
    /// 
    /// 像钟摆一样的逻辑
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = Common.Logarithm.CreateArray();

            Console.WriteLine("排序前");
            Common.ConsoleHelper.ConsoleWrite(array);


            //Console.WriteLine("第一版排序后");
            //CockTailSort1(array);
            //Common.ConsoleHelper.ConsoleWrite(array);


            //Console.WriteLine("第二版排序后");
            //CockTailSort2(array);
            //Common.ConsoleHelper.ConsoleWrite(array);

            Console.ReadKey();
        }



        /// <summary>
        /// 鸡尾酒排序1
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<int> CockTailSort1(List<int> array)
        {
            int tmp = 0;
            for (int i = 0; i <= array.Count / 2 - 1; i++)
            {
                //有序标记，每一轮的初始是true
                bool isSorted = true;
                //从前到后的排序 (升序)
                for (int j = i; j < array.Count - i; j++)
                {
                    if (j + 1 < array.Count && array[j] > array[j + 1])
                    {
                        tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                        //有元素交换，所以不是有序，标记变为false
                        isSorted = false;
                    }
                }
                if (isSorted)
                {
                    break;
                }

                Console.WriteLine("左排序：" + string.Join(",", array));

                //从后到前的排序（降序）
                for (int j = array.Count - i - 1; j >= i; j--)
                {
                    if (j > 0 && array[j] < array[j - 1])
                    {
                        tmp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = tmp;
                        //有元素交换，所以不是有序，标记变为false
                        isSorted = false;
                    }
                }
                Console.WriteLine("右排序：" + string.Join(",", array));
                if (isSorted)
                {
                    break;
                }
            }
            return array;
        }



        /// <summary>
        /// 鸡尾酒排序2
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static List<int> CockTailSort2(List<int> array)
        {
            int tmp = 0;
            //记录右侧最后一次交换的位置
            int lastRightExchangeIndex = 0;
            //记录左侧最后一次交换的位置
            int lastLeftExchangeIndex = 0;
            //无序数列的右边界，每次比较只需要比到这里为止
            int rightSortBorder = array.Count - 1;
            //无序数列的左边界，每次比较只需要比到这里为止
            int leftSortBorder = 0;
            for (int i = 0; i <= array.Count / 2 - 1; i++)
            {
                //有序标记，每一轮的初始是true
                bool isSorted = true;
                //奇数轮，从左向右比较和交换
                for (int j = leftSortBorder; j < rightSortBorder; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                        //有元素交换，所以不是有序，标记变为false
                        isSorted = false;
                        lastRightExchangeIndex = j;
                    }
                }
                rightSortBorder = lastRightExchangeIndex;
                if (isSorted)
                {
                    break;
                }
                //偶数轮，从右向左比较和交换
                for (int j = rightSortBorder; j > leftSortBorder; j--)
                {
                    if (array[j] < array[j - 1])
                    {
                        tmp = array[j];
                        array[j] = array[j - 1];
                        array[j - 1] = tmp;
                        //有元素交换，所以不是有序，标记变为false
                        isSorted = false;
                        lastLeftExchangeIndex = j;
                    }
                }
                leftSortBorder = lastLeftExchangeIndex;
                if (isSorted)
                {
                    break;
                }
            }
            return array;
        }
    }
}
