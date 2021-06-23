using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankExercises
{
    class Person
    {
        protected int d;
    }

    class S : Person
    {

    }
        
    //}
    [TestClass]
    public class LinkedList
    {
        //[TestMethod]
        //public void MergeListsTest()
        //{
        //    Utils s = new Utils();
        //    s.GetS();
        //    List<string> names = new List<string>();
        //    names.Add("Dave");
        //    names.Add("Dave2");
        //    names.Add("Dave3");
        //    string john = names.Find(name => name.Equals("john"));
        //}
        //LinkedList<int> MergeLists(LinkedListNode<int> head1, LinkedListNode<int> head2)
        //{
        //    throw new NotImplementedException();
        //}

        //[TestMethod]
        //public void InsertNodeAtPositionTest()
        //{
        //    SinglyLinkedListNode linkedList1 = new LinkedList<int>();
        //    linkedList1.AddLast(1);
        //    linkedList1.AddLast(2);
        //    linkedList1.AddLast(3);
        //    InsertNodeAtPosition(linkedList1.First, 4, 2);

        //    //LinkedList<int> linkedListOutput1 = new LinkedList<int>();
        //    //linkedList1.AddLast(1);
        //    //linkedList1.AddLast(2);
        //    //linkedList1.AddLast(4);
        //    //linkedList1.AddLast(3);

        //    //CollectionAssert.AreEquivalent(linkedListOutput1, );
        //}

        SinglyLinkedListNode InsertNodeAtPosition(SinglyLinkedListNode head, int data, int position)
        {
            SinglyLinkedListNode result = head;
            SinglyLinkedListNode nodeToBeInsert = new SinglyLinkedListNode() { Data = data };

            if (head == null)
            {
                return nodeToBeInsert;
            }

            if (position == 0)
            {
                nodeToBeInsert.Next = head;
                return nodeToBeInsert;
            }

            int currentPosition = 0;

            while (currentPosition < position - 1 && head.Next != null)
            {
                head = head.Next;
                currentPosition++;
            }

            SinglyLinkedListNode nodeAtPosition = head.Next;
            head.Next = nodeToBeInsert;
            head = head.Next;
            head.Next = nodeAtPosition;

            return result;
        }
    }

    public class SinglyLinkedListNode
    {
        public int Data { get; set; }
        public SinglyLinkedListNode Next { get; set; }
    }
}
