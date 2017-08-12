using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm.Quicksort
{
	/// <summary>
	/// 快速排序(英语: Quicksort), 又称划分交换排序(partition-exchange sort)
	/// </summary>
	class Quicksort
	{
		#region 算法
		/// <summary>
		/// 一次排序单元，完成此方法，key左边都比key小，key右边都比key大。
		/// </summary>
		/// <param name="array">排序数组 </param>
		/// <param name="low">排序起始位置 </param>
		/// <param name="high">排序结束位置</param>
		/// <returns>单元排序后的数组</returns>
        private static int SortUnit(int[] array, int low, int high)
        {
            int key = array[low];
            while (low < high)
            {
                //从后向前搜索比key小的值
                while (array[high] >= key && high > low)
                    --high; 
                //比key小的放左边
                array[low] = array[high];


                //从前向后搜索比key大的值，比key大的放右边
                while (array[low] <= key && high > low)
                    ++low; 
                //比key大的放右边
                array[high] = array[low];
            }

            //左边都比key小, 右边都比key大
			//将key放在游标当前位置
			//此时low等于high
            array[low] = key;
            foreach (int i in array)
                Console.Write("{0}\t", i);
            Console.WriteLine();

            return high;
        }

		/// <summary>
		/// 快速排序 
		/// </summary>
		/// <param name="array"></param>
		/// <param name="low"></param>
		/// <param name="high"></param>
        public static void SortRecursive(int[] array, int low, int high)
        {
            if (low >= high)
                return; 

            //完成一次单元排序
            int index = SortUnit(array, low, high); 

            //对左边单元进行排序
            SortRecursive(array, low, index - 1);

            //对右边单元进行排序
            SortRecursive(array, index + 1, high);
		}
		#endregion

		#region TestCode
		public static void Test()
		{
			int[] array = { 49, 38, 65, 97, 76, 13, 27, 1, 2, 8, 7 };
			SortRecursive(array, 0, array.Length - 1);
			Console.ReadLine();
		}
		#endregion
	}
}
