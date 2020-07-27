using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 给出一个 32 位的有符号整数，你需要将这个整数中每位上的数字进行反转。
    /// </summary>
    class IntReverse : IAlgorithm
    {
        public void Execute()
        {
            int test = -12 % 10;
            Console.WriteLine(test);
        }

        private int Run(int x) 
        {
            long ret = 0;
            int tmp = 0;

            while (x != 0)
            {
                tmp = x % 10;
                x = x / 10;
                ret = ret * 10 + tmp;
            }
            if(ret > int.MaxValue || ret < int.MinValue)
            {
                ret = 0;
            }

            return (int)ret;
        }
    }
}
