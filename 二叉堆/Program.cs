using System;
using System.Collections.Generic;

namespace 二叉堆
{
    class Program
    {
        /// <summary>
        /// 二叉堆本质上是一种完全二叉树，
        /// 它分为两个类型：1.最大堆 2.最小堆
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<int> array = Common.Logarithm.CreateArray(true);
            Console.WriteLine("排序前");
            Common.ConsoleHelper.ConsoleWrite(array);

            Console.WriteLine("排序后");
            UpAdjust(array);
            Common.ConsoleHelper.ConsoleWrite(array);


            //Console.WriteLine("排序后");
            //BuildHeap(array);
            //Common.ConsoleHelper.ConsoleWrite(array);
            Console.ReadKey();
        }


        /// <summary>
        /// 上浮调整
        /// </summary>
        /// <param name="array">待调整的堆</param>
        public static void UpAdjust(List<int> array)
        {
            int childIndex = array.Count - 1;
            int parentIndex = (childIndex - 1) / 2;

            // temp保存插入的叶子节点值，用于最后的赋值
            int temp = array[childIndex];

            while (childIndex > 0 && temp < array[parentIndex])
            {
                //无需真正交换，单向赋值即可
                array[childIndex] = array[parentIndex];
                childIndex = parentIndex;
                parentIndex = (parentIndex - 1) / 2;
            }
            array[childIndex] = temp;
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
                // 如果有右孩子，且右孩子小于左孩子的值，则定位到右孩子
                if (childIndex + 1 < length && array[childIndex + 1] < array[childIndex])
                {
                    childIndex++;
                }
                // 如果父节点小于任何一个孩子的值，直接跳出
                if (temp <= array[childIndex])
                    break;

                //无需真正交换，单向赋值即可
                array[parentIndex] = array[childIndex];
                parentIndex = childIndex;
                childIndex = 2 * childIndex + 1;
            }
            array[parentIndex] = temp;
        }

        /**
         * 构建堆
         * @param array     待调整的堆
         */
        public static void BuildHeap(List<int> array)
        {
            // 从最后一个非叶子节点开始，依次下沉调整
            for (int i = array.Count / 2; i >= 0; i--)
            {
                DownAdjust(array, i, array.Count - 1);
            }
        }




        //堆排序算法（传递待排数组名，即：数组的地址。故形参数组的各种操作反应到实参数组上）
        private static void HeapSortFunction(List<int> array)
        {
            BuildMaxHeap(array);    //创建大顶推（初始状态看做：整体无序）
            for (int i = array.Count - 1; i > 0; i--)
            {
                int a = array[0];
                int b = array[i];
                Swap(ref a, ref b); //将堆顶元素依次与无序区的最后一位交换（使堆顶元素进入有序区）
                MaxHeapify(array, 0, i); //重新将无序区调整为大顶堆
            }
        }

        ///<summary>
        /// 创建大顶推（根节点大于左右子节点）
        ///</summary>
        ///<param name="array">待排数组</param>
        private static void BuildMaxHeap(List<int> array)
        {
            //根据大顶堆的性质可知：数组的前半段的元素为根节点，其余元素都为叶节点
            for (int i = array.Count / 2 - 1; i >= 0; i--) //从最底层的最后一个根节点开始进行大顶推的调整
            {
                MaxHeapify(array, i, array.Count); //调整大顶堆
            }
        }

        ///<summary>
        /// 大顶推的调整过程
        ///</summary>
        ///<param name="array">待调整的数组</param>
        ///<param name="currentIndex">待调整元素在数组中的位置（即：根节点）</param>
        ///<param name="heapSize">堆中所有元素的个数</param>
        private static void MaxHeapify(List<int> array, int currentIndex, int heapSize)
        {

            int left = 2 * currentIndex + 1;    //左子节点在数组中的位置
            int right = 2 * currentIndex + 2;   //右子节点在数组中的位置
            int large = currentIndex;   //记录此根节点、左子节点、右子节点 三者中最大值的位置

            if (left < heapSize && array[left] > array[large])  //与左子节点进行比较
            {
                large = left;
            }
            if (right < heapSize && array[right] > array[large])    //与右子节点进行比较
            {
                large = right;
            }
            if (currentIndex != large)  //如果 currentIndex != large 则表明 large 发生变化（即：左右子节点中有大于根节点的情况）
            {
                int a = array[currentIndex];
                int b = array[large];
                Swap(ref a, ref b);    //将左右节点中的大者与根节点进行交换（即：实现局部大顶堆）
                MaxHeapify(array, large, heapSize); //以上次调整动作的large位置（为此次调整的根节点位置），进行递归调整
            }

        }

        ///<summary>
        /// 交换函数
        ///</summary>
        ///<param name="a">元素a</param>
        ///<param name="b">元素b</param>
        private static void Swap(ref int a, ref int b)
        {
            int temp = 0;
            temp = a;
            a = b;
            b = temp;
        }
    }
}
