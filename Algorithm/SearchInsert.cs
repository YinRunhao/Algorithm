using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class SearchInsert : IAlgorithm
    {
        public void Execute()
        {
            int[] test = new int[] { 1, 3 };
            int target = 5;
            int ret = Run(test, target);
            Console.WriteLine($"Return {ret}");
        }

        private int Run(int[] nums, int target)
        {
            if(nums.Length > 0)
            {
                return Search(nums, 0, nums.Length - 1, target);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 二分法查找值位置
        /// </summary>
        /// <param name="nums">数组</param>
        /// <param name="begIdx">开始坐标</param>
        /// <param name="endIdx">结束坐标</param>
        /// <param name="target">目标值</param>
        /// <returns></returns>
        private int Search(int[] nums, int begIdx, int endIdx, int target)
        {
            int mid = (endIdx + begIdx) / 2;
            // 左右指针相遇
            if(begIdx == endIdx)
            {
                // 如果目标值比中间值还要大，说明在数组外
                if(target > nums[begIdx])
                {
                    return begIdx + 1;
                }
                return begIdx;
            }
            if (target == nums[mid])
            {
                // 刚好找到
                return mid;
            }
            else if (target < nums[mid])
            {
                // 找左边区域
                return Search(nums, begIdx, mid, target);
            }
            else
            {
                // 找右边区域
                return Search(nums, mid + 1, endIdx, target);
            }
        }
    }
}
