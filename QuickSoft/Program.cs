using System;
using System.Collections.Generic;

namespace QuickSoft
{
    /// <summary>
    /// 快速排序
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = Common.Logarithm.CreateArray();

            Console.WriteLine("排序前");
            Common.ConsoleHelper.ConsoleWrite(array);

            //Console.WriteLine("填坑法排序后");
            //QuickSort1(array, 0, array.Count - 1);
            //Common.ConsoleHelper.ConsoleWrite(array);


            //Console.WriteLine("指针交换法排序后");
            //QuickSort2(array, 0, array.Count - 1);
            //Common.ConsoleHelper.ConsoleWrite(array);



            Console.WriteLine("非递归方式排序后");
            QuickSort2(array, 0, array.Count - 1);
            Common.ConsoleHelper.ConsoleWrite(array);


            Console.ReadKey();
        }


        #region 填坑法

        private static void QuickSort1(List<int> arr, int startIndex, int endIndex)
        {
            // 递归结束条件：startIndex大等于endIndex的时候
            if (startIndex >= endIndex)
            {
                return;
            }

            // 得到基准元素位置
            int pivotIndex = Partition1(arr, startIndex, endIndex);
            // 用分治法递归数列的两部分
            QuickSort1(arr, startIndex, pivotIndex - 1);

            QuickSort1(arr, pivotIndex + 1, endIndex);

        }
        /// <summary>
        /// 填坑法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>

        private static int Partition1(List<int> arr, int startIndex, int endIndex)
        {
            // 取第一个位置的元素作为基准元素
            int pivot = arr[startIndex];
            int left = startIndex;
            int right = endIndex;

            // 坑的位置，初始等于pivot的位置
            int index = startIndex;

            //大循环在左右指针重合或者交错时结束
            while (right >= left)
            {
                //right指针从右向左进行比较
                while (right >= left)
                {
                    if (arr[right] < pivot)
                    {
                        arr[left] = arr[right];
                        index = right;
                        left++;
                        break;
                    }
                    right--;
                }

                //left指针从左向右进行比较
                while (right >= left)
                {
                    if (arr[left] > pivot)
                    {
                        arr[right] = arr[left];
                        index = left;
                        right--;
                        break;
                    }
                    left++;
                }
            }

            arr[index] = pivot;
            return index;

        }
        #endregion

        #region 指针交换法
        private static void QuickSort2(List<int> arr, int startIndex, int endIndex)
        {
            // 递归结束条件：startIndex大等于endIndex的时候
            if (startIndex >= endIndex)
            {
                return;
            }

            // 得到基准元素位置
            int pivotIndex = Partition2(arr, startIndex, endIndex);
            // 用分治法递归数列的两部分
            QuickSort2(arr, startIndex, pivotIndex - 1);

            QuickSort2(arr, pivotIndex + 1, endIndex);

        }

        /// <summary>
        /// 指针交换法
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        private static int Partition2(List<int> arr, int startIndex, int endIndex)
        {
            // 取第一个位置的元素作为基准元素
            int pivot = arr[startIndex];
            int left = startIndex;
            int right = endIndex;
            while (left != right)
            {
                //控制right指针比较并左移
                while (left < right && arr[right] > pivot)
                {
                    right--;
                }

                //控制right指针比较并右移
                while (left < right && arr[left] <= pivot)
                {
                    left++;
                }

                //交换left和right指向的元素

                if (left < right)
                {
                    int p1 = arr[left];
                    arr[left] = arr[right];
                    arr[right] = p1;
                }
            }

            //pivot和指针重合点交换
            int p = arr[left];
            arr[left] = arr[startIndex];
            arr[startIndex] = p;
            return left;
        }

        #endregion

        #region 非递归

        public static void QuickSort3(int[] arr, int startIndex, int endIndex)
        {
            // 用一个集合栈来代替递归的函数栈
            Stack<Dictionary<String, int>> quickSortStack = new Stack<Dictionary<String, int>>();

            // 整个数列的起止下标，以哈希的形式入栈
            Dictionary<String, int> rootParam = new Dictionary<String, int>();
            rootParam.Add("startIndex", startIndex);
            rootParam.Add("endIndex", endIndex);
            quickSortStack.Push(rootParam);

            // 循环结束条件：栈为空时结束
            while (quickSortStack.Count != 0)
            {
                // 栈顶元素出栈，得到起止下标
                Dictionary<String, int> param = quickSortStack.Pop();

                // 得到基准元素位置
                int pivotIndex = Partition3(arr, param["startIndex"], param["endIndex"]);

                // 根据基准元素分成两部分, 把每一部分的起止下标入栈
                if (param["startIndex"] < pivotIndex - 1)
                {
                    Dictionary<String, int> leftParam = new Dictionary<String, int>();
                    leftParam.Add("startIndex", param["startIndex"]);
                    leftParam.Add("endIndex", pivotIndex - 1);
                    quickSortStack.Push(leftParam);
                }

                if (pivotIndex + 1 < param["endIndex"])
                {
                    Dictionary<String, int> rightParam = new Dictionary<String, int>();
                    rightParam.Add("startIndex", pivotIndex + 1);
                    rightParam.Add("endIndex", param["endIndex"]);
                    quickSortStack.Push(rightParam);
                }
            }

        }

        private static int Partition3(int[] arr, int startIndex, int endIndex)
        {
            // 取第一个位置的元素作为基准元素
            int pivot = arr[startIndex];
            int left = startIndex;
            int right = endIndex;

            while (left != right)
            {
                //控制right指针比较并左移
                while (left < right && arr[right] > pivot)
                {
                    right--;
                }

                //控制right指针比较并右移
                while (left < right && arr[left] <= pivot)
                {
                    left++;
                }

                //交换left和right指向的元素
                if (left < right)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                }
            }



            //pivot和指针重合点交换
            int p = arr[left];
            arr[left] = arr[startIndex];
            arr[startIndex] = p;
            return left;
        }

        #endregion
    }
}
