using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 给定字符串 s 和 t ，判断 s 是否为 t 的子序列
    /// 字符串的一个子序列是原始字符串删除一些（也可以不删除）字符而不改变剩余字符相对位置形成的新字符串。（例如，"ace"是"abcde"的一个子序列，而"aec"不是）。
    /// </summary>
    class SubSeqString : IAlgorithm
    {
        public void Execute()
        {
            string shortStr = "b";
            string targetStr = "aaa";
            bool b = Run(shortStr, targetStr);
            Console.WriteLine(b);
        }

        private bool Run(string s,string t)
        {
            bool ret = true;
            int lastIdx = 0;
            int idx = -1;
            int len = t.Length;

            foreach(var c in s)
            {
                if (lastIdx >= len)
                {
                    ret = false;
                    break;
                }
                idx = t.IndexOf(c, lastIdx);
                if(idx >= lastIdx)
                {
                    lastIdx = idx + 1;
                }
                else
                {
                    ret = false;
                    break;
                }
            }

            return ret;
        }
    }
}
