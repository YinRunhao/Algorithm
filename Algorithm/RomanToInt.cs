using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class RomanToInt : IAlgorithm
    {
        public void Execute()
        {
            string test = "IXVII";
            int ret = exec(test);
            Console.WriteLine(ret);
        }
        private int exec(string input)
        {
            Dictionary<char, int> romanTxt = new Dictionary<char, int>
            {
                { 'I',1},
                { 'V',5},
                { 'X',10},
                { 'L',50},
                { 'C',100},
                { 'D',500},
                { 'M',1000}
            };
            int ret = 0;
            int tmp;
            for(int i = 0;i < input.Length; i++)
            {
                if((i < input.Length - 1)&& romanTxt[input[i]] < romanTxt[input[i + 1]])
                {
                    tmp = romanTxt[input[i + 1]] - romanTxt[input[i]];
                    i += 1;
                }
                else
                {
                    tmp = romanTxt[input[i]];
                }

                ret += tmp;
            }

            return ret;
        }
    }
}
