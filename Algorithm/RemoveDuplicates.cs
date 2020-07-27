using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithm
{
    class RemoveDuplicates : IAlgorithm
    {
        public void Execute()
        {
            string test = "abbaca";
            Console.WriteLine(Fun1(test));
        }

        private string Fun1(string S)
        {
            if(S.Length > 0)
            {
                Stack<char> stack = new Stack<char>();
                StringBuilder builder = new StringBuilder();
                var arr = S.ToCharArray();
                foreach(char c in arr)
                {
                    if(stack.TryPeek(out char top))
                    {
                        if(top == c)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(c);
                        }
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
                var test = stack.ToArray();
                for(int i = test.Length - 1;i >= 0; i--)
                {
                    builder.Append(test[i]);
                }
                return builder.ToString();
            }

            return "";
        }

        private string Fun(string input)
        {
            if(input.Length > 0)
            {
                StringBuilder builder = new StringBuilder();
                var arr = input.ToCharArray();
                char cur;
                char next;
                int idx = 0;
                int cnt = 0;
                while(idx < arr.Length -1)
                {
                    cur = arr[idx];
                    next = arr[idx + 1];
                    if(cur == next)
                    {
                        idx += 1;
                    }
                    else
                    {
                        builder.Append(cur);
                        cnt += 1;
                    }
                    idx += 1;
                }
                if(arr.Length == 1 || arr[arr.Length - 1] != arr[arr.Length - 2])
                {
                    builder.Append(arr[arr.Length - 1]);
                    cnt += 1;
                }
                if(cnt == input.Length)
                {
                    return input;
                }
                else
                {
                    return Fun(builder.ToString());
                }
            }

            return "";
        }
    }
}
