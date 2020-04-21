using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class QuickSort : IAlgorithm
    {
        public void Execute()
        {
            List<int> arr = new List<int> { 1, 5, 2, 3, 7, 9, 0 };
            Sort(arr);
            foreach (var num in arr)
            {
                Console.Write($"{num}, ");
            }
            Console.WriteLine();
        }

        private void Sort(List<int> arr)
        {
            int left = 0;
            int right = arr.Count - 1;
            QuitSort(arr, left, right);
        }

        private void QuitSort(List<int> arr, int left, int right)
        {
            // 递归结束条件
            if (left < right)
            {
                int i = left;
                int j = right;
                // 选最左边的数作为基准
                int val = arr[i];

                while (i < j)
                {
                    // 从右边开始找第一个比基准小的数
                    for (; j >= i; j--)
                    {
                        if (arr[j] < val)
                        {
                            // 左游标值被这个比基准小的数替换
                            arr[i] = arr[j];
                            break;
                        }
                    }
                    // 此时右游标[j]右边的值都比基准大


                    // 从左边开始找第一个比基准大的数
                    for (; i <= j; i++)
                    {
                        if (arr[i] >= val)
                        {
                            // 右右边值被这个比基准打的数替换
                            arr[j] = arr[i];
                            break;
                        }
                    }
                    // 此时左游标[i]左边的值都比基准小

                    //左右游标继续靠拢
                }
                // 此时左右游标重合(i == j)，说明该位置左边都比基准小，右边都比基准大
                // 该位置即基准数应该在的位置
                arr[i] = val;

                // 基准数位置已确定，此时用同样的方法对基准数左边的集合排序
                QuitSort(arr, left, i - 1);
                // 基准数位置已确定，此时用同样的方法对基准数右边的集合排序
                QuitSort(arr, i + 1, right);
            }
        }
    }
}
