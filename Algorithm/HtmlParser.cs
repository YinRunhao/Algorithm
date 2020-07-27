using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class HtmlParser : IAlgorithm
    {
        public void Execute()
        {
            string input = "leetcode.com&frasl;problemset&frasl;all";
            Console.WriteLine("In:");
            Console.WriteLine(input);
            string output = HtmlParse(input);
            Console.WriteLine("Out:");
            Console.WriteLine(output);
        }

        private string HtmlParse(string text)
        {
            Dictionary<string, char> dic = new Dictionary<string, char>();
            dic.Add("&quot;", '\"');
            dic.Add("&apos;", '\'');
            dic.Add("&amp;", '&');
            dic.Add("&gt;", '>');
            dic.Add("&lt;", '<');
            dic.Add("&frasl;", '/');
            StringBuilder builder = new StringBuilder();
            int len = text.Length;
            char item;
            for (int i = 0; i < len; i++)
            {
                item = text[i];
                if(item == '&')
                {
                    var ret = CheckChar(text, i, dic, len);
                    if (ret.Item1 > 0)
                    {
                        i += ret.Item1;
                        builder.Append(ret.Item2);
                        continue;
                    }
                }

                builder.Append(item);
                
            }
            return builder.ToString();
        }

        private (int, char) CheckChar(string text, int begIdx, Dictionary<string, char> dic, int len)
        {
            int adv = 0;
            char c = '?';
            string s = "";

            int end = (begIdx + 7 >= len) ? len : begIdx + 7;
            for(int i = begIdx;i < end; i++)
            {
                s += text[i];
                if(dic.TryGetValue(s,out c))
                {
                    adv = i - begIdx;
                    break;
                }
            }

            return (adv, c);
        }
    }
}
