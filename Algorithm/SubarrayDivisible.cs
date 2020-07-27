using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 和可被K整除的子数组
    /// </summary>
    class SubarrayDivisible : IAlgorithm
    {
        public void Execute()
        {
            int[] input = new int[] { 1, 2, 3, 4,5 };
            Run(input, 3);
        }

        static int k = 0;
        static int cnt = 0;
        static int test = 0;
        private void Run(int[] arr, int sum)
        {
            int len = arr.Length;
            k = sum;
            for (int i = 0; i < len; i++)
            {
                Test(i, arr, len, arr[i]);
            }
            Console.WriteLine(test);
        }

        private void Test(int idx, int[] input, int len, int d)
        {
            test++;
            if (d % k == 0)
            {
                cnt++;
            }
            idx = idx + 1;
            for (; idx < len; idx++)
            {
                Test(idx, input, len, d + input[idx]);
            }
        }
    }
}
