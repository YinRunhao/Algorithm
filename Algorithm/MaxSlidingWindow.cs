using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 给定一个数组 nums 和滑动窗口的大小 k，请找出所有滑动窗口里的最大值。
    /// 输入: nums = [1,3,-1,-3,5,3,6,7], 和 k = 3
    /// 输出: [3,3,5,5,6,7]
    /// </summary>
    class MaxSlidingWindow : IAlgorithm
    {
        public void Execute()
        {
            int[] nums = new int[] { 1, 3, -1, -3, 5, 3, 6, 7 };
            int k = 3;
            var ret = Run(nums, k);
            foreach(var item in ret)
            {
                Console.Write($" {item}");
            }
        }

        public int[] Run(int[] nums, int k)
        {
            int len = nums.Length;
            if(len == 0)
            {
                return new int[0];
            }

            int cnt = len - k + 1;
            int[] ret = new int[cnt];
            int max;
            for(int i = 0;i < cnt; i++)
            {
                max = nums[i];
                for(int j = 1;j < k; j++)
                {
                    if(nums[j+i] > max)
                    {
                        max = nums[j + i];
                    }
                }
                ret[i] = max;
            }

            return ret;
        }
    }
}
