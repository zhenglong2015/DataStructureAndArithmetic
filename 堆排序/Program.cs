using System;
using System.Collections.Generic;

namespace 堆排序
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> array = Common.Logarithm.CreateArray(true);

            Console.WriteLine("排序前");
            Common.ConsoleHelper.ConsoleWrite(array);

            Console.WriteLine("排序后");
            HeapSort(array);
            Common.ConsoleHelper.ConsoleWrite(array);

            Console.ReadKey();
        }


        /**
 * 下沉调整
 * @param array     待调整的堆
 * @param parentIndex    要下沉的父节点
 * @param parentIndex    堆的有效大小
 */
        public static void DownAdjust(List<int> array, int parentIndex, int length)
        {
            // temp保存父节点值，用于最后的赋值
            int temp = array[parentIndex];
            int childIndex = 2 * parentIndex + 1;

            while (childIndex < length)
            {
                // 如果有右孩子，且右孩子大于左孩子的值，则定位到右孩子
                if (childIndex + 1 < length && array[childIndex + 1] > array[childIndex])
                {
                    childIndex++;
                }

                // 如果父节点小于任何一个孩子的值，直接跳出
                if (temp >= array[childIndex])
                    break;

                //无需真正交换，单向赋值即可
                array[parentIndex] = array[childIndex];
                parentIndex = childIndex;
                childIndex = 2 * childIndex + 1;
            }
            array[parentIndex] = temp;
        }




        /**
         * 堆排序
         * @param array     待调整的堆
         */
        public static void HeapSort(List<int> array)
        {
            // 1.把无序数组构建成二叉堆。
            for (int i = (array.Count - 2) / 2; i >= 0; i--)
            {
                DownAdjust(array, i, array.Count);
            }
            // System.        out.println(Arrays.toString(array));
            //Common.ConsoleHelper.ConsoleWrite(array);

            // 2.循环删除堆顶元素，移到集合尾部，调节堆产生新的堆顶。
            for (int i = array.Count - 1; i > 0; i--)
            {
                // 最后一个元素和第一元素进行交换
                int temp = array[i];
                array[i] = array[0];
                array[0] = temp;

                // 下沉调整最大堆
                DownAdjust(array, 0, i);
            }
        }
    }
}
