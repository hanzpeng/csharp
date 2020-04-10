using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace NUnitProject1
{
    class P025_ReverseLinkedList
    {
        
        [Test]
        public void test1()
        {
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            Node n7 = new Node(7);
            Node n8 = new Node(8);

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;
            n6.next = n7;
            n7.next = n8;

            Node cur = ReverseKGroup(n1,3);
            while(cur != null)
            {
                Console.WriteLine(cur.val);
                cur = cur.next;
            }

            Assert.AreEqual(4, 4);
        }

        public Node ReverseKGroup(Node head, int k)
        {
            if (head == null || head.next == null) return head;

            var res = ReverseK(head,  k);
            head = res[0];
            Node tail = res[1];
            Node nextHead = res[2];
            while(nextHead != null)
            {
                res = ReverseK(nextHead, k);
                tail.next = res[0];
                tail = res[1];
                nextHead = res[2];
            }

            return head;
        }

        public Node[] ReverseK(Node head, int k)
        {
            if (head == null || head.next == null) return new Node[] { head, null, null};
            Node pre = head;
            Node cur = head.next;
            int count = 1;
            while (cur != null && count < k)
            {
                count++;
                Node temp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = temp;
            }
            head.next = null;
            return new Node[] { pre, head, cur}; // head, tail, nextHead
        }














        public Node Reverse(Node head, Node nextHead, int k)
        {
            if (head == null || head.next == null) return head;
            Node pre = head;
            Node cur = head.next;
            int count = 1;
            while(cur != null && count < k)
            {
                count++;
                Node temp = cur.next;
                cur.next = pre;
                pre = cur;
                cur = temp;
            }
            head.next = nextHead;
            return pre;
        }

        public class Node
        {
            public int val;
            public Node next;
            public Node(int x) { val = x; }
        }
    }
}