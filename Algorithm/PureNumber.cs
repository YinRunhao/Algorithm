using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class PureNumber : IAlgorithm
    {
        public void Execute()
        {
            int cnt = 100;
            for(int num = 1; num <= cnt; num++)
            {
                if (IsPureNum(num))
                {
                    Console.WriteLine($"{num} is pure number");
                }
                else
                {
                    //Console.WriteLine($"{num} is not pure number");
                }
            }
        }

        private bool IsPureNum(int num)
        {
            if (num < 2)
            {
                return false;
            }
            int sq = (int)Math.Sqrt(num);
            bool ret = true;

            for (int i = 2; i <= sq; i++)
            {
                if(num % i == 0)
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }
    }
}
