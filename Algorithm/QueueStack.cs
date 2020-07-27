using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public class MyStack
    {
        int top = 0;
        Queue<int> queA;
        Queue<int> queB;
        Queue<int> cur;
        bool usingA = false;
        /** Initialize your data structure here. */
        public MyStack()
        {
            queA = new Queue<int>();
            queB = new Queue<int>();
            cur = queA;
            usingA = true;
        }

        /** Push element x onto stack. */
        public void Push(int x)
        {
            top = x;
            cur.Enqueue(x);
        }

        /** Removes the element on top of the stack and returns that element. */
        public int Pop()
        {
            int tmp = 0;
            int ret = 0;
            Queue<int> dst = usingA ? queB : queA;
            while(cur.TryDequeue(out tmp))
            {
                if(cur.TryPeek(out ret))
                {
                    dst.Enqueue(tmp);
                    top = tmp;
                }
                else
                {
                    ret = tmp;
                }
            }
            cur = dst;
            usingA = !usingA;

            return ret;
        }

        /** Get the top element. */
        public int Top()
        {
            return top;
        }

        /** Returns whether the stack is empty. */
        public bool Empty()
        {
            return cur.Count == 0;
        }
    }

    /// <summary>
    /// 用队列实现栈
    /// </summary>
    class QueueStack : IAlgorithm
    {
        public void Execute()
        {
            int test = 123;
            MyStack stack = new MyStack();
            stack.Push(test);
            stack.Push(test + 1);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Empty());
        }
    }
}
