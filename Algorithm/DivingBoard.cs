using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 你正在使用一堆木板建造跳水板。有两种类型的木板，其中长度较短的木板长度为shorter，长度较长的木板长度为longer。你必须正好使用k块木板。编写一个方法，生成跳水板所有可能的长度。返回的长度需要从小到大排列。
    /// </summary>
    class DivingBoard : IAlgorithm
    {
        public void Execute()
        {
            var arr = Run(1, 2, 3);
            foreach(var item in arr)
            {
                Console.Write(item);
                Console.Write(',');
            }
        }

        private int[] Run(int shorter, int longer, int k)
        {
            List<int> ret = new List<int>();
            
            if (k != 0)
            {
                if (shorter == longer)
                {
                    ret.Add(shorter * k);
                }
                else
                {
                    Fun(shorter, longer, k, 1, true, shorter, ret);
                    Fun(shorter, longer, k, 1, false, longer, ret);
                }                    
            }
            return ret.ToArray();
        }

        private void Fun(int s, int l, int k, int idx, bool isShort, int val, List<int> arr)
        {
            if (idx >= k)
            {
                arr.Add(val);
                return;
            }
            else
            {
                // 不走回头路，上一个选了长板，这次不能选短板
                if (isShort)
                {
                    Fun(s, l, k, idx + 1, true, val + s, arr);
                }

                // 所以选长板是一个固定的值
                //Fun(s, l, k, idx + 1, false, val + l, arr);
                arr.Add(val + (l * (k - idx)));
            }
        }
    }
}
