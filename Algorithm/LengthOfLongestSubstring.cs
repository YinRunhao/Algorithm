using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 查找最长不重复的子串长度
    /// </summary>
    class LengthOfLongestSubstring : IAlgorithm
    {
        public void Execute()
        {
            string s = "";
            int ret = Fun(s);
            Console.WriteLine(ret);
        }

        public int Fun(string s)
        {
            int len = s.Length;
            char c = char.MinValue;
            int max = 0;
            int temp = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            for (int i = 0; i < len; i++)
            {
                c = s[i];
                if (dic.ContainsKey(c))
                {
                    i = dic[c];
                    if(temp > max)
                    {
                        max = temp;
                    }
                    dic.Clear();
                    temp = 0;
                }
                else
                {
                    dic.Add(c, i);
                    temp++;
                }
            }
            if(temp > max)
            {
                max = temp;
            }
            return max;
        }
    }
}
