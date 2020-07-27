using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    /// <summary>
    ///  反转一个单链表
    /// </summary>
    class ReverseList
    {
        public ListNode ReverseByQueue(ListNode head)
        {
            Queue<ListNode> que = new Queue<ListNode>();
            ListNode item = null;
            ListNode node = null;
            while (head != null)
            {
                que.Enqueue(head);
                head = head.next;
                item = head;
            }

            while(que.TryDequeue(out node))
            {
                node.next = item;
                item = node;

            }

            return item;
        }

        public ListNode Reverse(ListNode head)
        {
            // 空值坑
            if(head == null)
            {
                return null;
            }
            ListNode tmp = null;
            ListNode cur = head;
            ListNode nextNode = head.next;
            head.next = null;
            while(nextNode != null)
            {
                tmp = cur;
                cur = nextNode;
                nextNode = nextNode.next;
                cur.next = tmp;
            }

            return cur;
        }
    }
}
