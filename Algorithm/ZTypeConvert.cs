using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class ZTypeConvert : IAlgorithm
    {
        public void Execute()
        {
            string input = "LEETCODEISHIRING";
            string output = Convert(input, 3);
            Console.WriteLine(output);
        }

        private string Convert(string s, int numRows)
        {
            if(numRows == 1)
            {
                return s;
            }
            StringBuilder sb = new StringBuilder();
            List<List<char>> rct = new List<List<char>>();
            for(int i = 0; i < numRows; i++)
            {
                rct.Add(new List<char>());
            }
            int tmp = 0;
            int per = 2 * (numRows - 1);
            for(int i = 0; i < s.Length; i++)
            {
                tmp = i % per;
                if (tmp >= numRows)
                {
                    rct[per - tmp].Add(s[i]);
                }
                else
                {
                    rct[tmp].Add(s[i]);
                }
            }


            foreach(var lst in rct)
            {
                foreach(var c in lst)
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
