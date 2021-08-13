using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 给定一个字符串 s，计算具有相同数量0和1的非空(连续)子字符串的数量，并且这些子字符串中的所有0和所有1都是组合
    /// 在一起的重复出现的子串要计算它们出现的次数。
    /// exp:"00110011"   6
    /// </summary>
    class CountBinarySubstrings : IAlgorithm
    {
        public void Execute()
        {
            string input = "000101100";
            int ret = Fun(input);
            Console.Write($"Output: {ret}");
        }

        /// <summary>
        /// 实际上是求连续相同的子串个数的最小值累加
        /// exp: 000101100 -> 3,1,1,2,2 -> 1,1,1,2 -> 5
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int Fun(string s)
        {
            int counter = 0;
            Stack<char> stack0 = new Stack<char>();
            Stack<char> stack1 = new Stack<char>();
            char tmp;
            char last = char.MinValue;
            foreach(char c in s)
            {
                // 切换操作栈时清空，避免遗留数据影响到后续
                if(c != last)
                {
                    if (c == '0')
                    {
                        stack0.Clear();
                    }
                    else
                    {
                        stack1.Clear();
                    }
                }

                if (c == '0')
                {
                    stack0.Push(c);
                    if (stack1.TryPop(out tmp))
                    {
                        counter++;
                    }
                }
                else
                {
                    stack1.Push(c);
                    if (stack0.TryPop(out tmp))
                    {
                        counter++;
                    }
                }

                last = c;
            }

            return counter;
        }
    }
}
