using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    /// <summary>
    /// 编写代码，移除未排序链表中的重复节点。保留最开始出现的节点。
    /// [1, 2, 3, 3, 2, 1]
    /// [1, 2, 3]
    /// </summary>
    class RemoveSameNode:IAlgorithm
    {
        public void Execute()
        {
            ListNode node = TestData();
            var ret = RemoveDuplicateNodes(node);
            
            while (ret!=null)
            {
                Console.Write($"{ret.val},");
                ret = ret.next;
            }
        }

        private ListNode TestData()
        {
            ListNode head = new ListNode(1);
            head.next = new ListNode(1);
            head.next.next = new ListNode(1);
            head.next.next.next = new ListNode(3);
            head.next.next.next.next = new ListNode(2);
            head.next.next.next.next.next = new ListNode(1);
            return head;
        }

        private ListNode RemoveDuplicateNodes(ListNode head)
        {
            Dictionary<int, byte> dic = new Dictionary<int, byte>();
            // 链表操作中要有首结点的概念
            ListNode first = new ListNode(0);
            first.next = head;

            while(first.next != null)
            {
                // 存在则跳过该结点
                if(dic.TryGetValue(first.next.val,out _))
                {
                    first.next = first.next.next;
                    continue;
                }
                else
                {
                    dic.Add(first.next.val, 0);
                }
                first = first.next;
            }

            return head;
        }
    }
}
