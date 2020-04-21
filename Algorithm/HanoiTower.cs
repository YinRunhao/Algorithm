using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 汉诺塔问题
    /// </summary>
    class HanoiTower : IAlgorithm
    {
        public class NamedStack : Stack<int>
        {
            public string Name { get; set; }
        }

        public void Execute()
        {
            int cnt = 4;
            NamedStack a = new NamedStack { Name = "A" };
            NamedStack b = new NamedStack { Name = "B" };
            NamedStack c = new NamedStack { Name = "C" };

            for (int i = cnt; i > 0; i--)
            {
                a.Push(i);
            }

            Move(cnt, a, b, c);
        }

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="cnt">总数</param>
        /// <param name="src">源栈</param>
        /// <param name="temp">辅助栈</param>
        /// <param name="dst">终点栈</param>
        private void Move(int cnt, NamedStack src, NamedStack temp, NamedStack dst)
        {
            int val = 0;
            if (cnt <= 0)
            {
                return;
            }
            // 把n-1个圆盘以dst为辅助栈，从src移动到temp
            Move(cnt - 1, src, dst, temp);

            // 将第n个圆盘从src移动到dst，此时src应该只剩一个圆盘
            val = src.Pop();
            dst.Push(val);
            Console.WriteLine($"{val} {src.Name} -> {dst.Name}");

            // 将剩余圆盘以src为辅助栈，从temp移动到dst
            Move(cnt - 1, temp, src, dst);
        }
    }
}
