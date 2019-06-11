using System;
using System.Collections.Generic;
using System.Text;

namespace Custom_Doubly_Linked_List
{
    public class DoublyLinkedList
    {
        private class LinkNode
        {

            public LinkNode(int value)
            {
                this.Value = value;
            }


            public int Value { get; }

            public LinkNode NextNode { get; set; }

            public LinkNode PreviousNode { get; set; }


        }

        private LinkNode head;
        private LinkNode tail;

        public int Count { get; private set; }

        public void AddFirst(int value)
        {
            LinkNode newHead = new LinkNode(value);

            if (this.Count == 0)
            {
                this.tail = this.head = newHead;
            }
            else
            {
                newHead.NextNode = this.head;
                this.head.PreviousNode = newHead;
                this.head = newHead;

            }
            this.Count++;
        }

        public void AddLast(int value)
        {
            LinkNode newTail = new LinkNode(value);

            if (this.Count == 0)
            {
                this.tail = this.head = newTail;
            }

            else
            {
                newTail.PreviousNode = this.tail;
                this.tail.NextNode = newTail;
                this.tail = newTail;
            }
            this.Count++;
        }

        public int RemoveFirst()
        {
            CheckIfEmptyThrowException();

            int firsElement = this.head.Value;
            this.head = this.head.NextNode;

            if (this.head == null)
            {
                this.tail = null;
            }
            else
            {
                this.head.PreviousNode = null;
            }

            this.Count--;

            return firsElement;
        }

        public int RemoveLast()
        {
            CheckIfEmptyThrowException();

            int lastElement = this.tail.Value;
            this.tail = this.tail.PreviousNode;

            if (this.tail == null)
            {
                this.head = null;
            }
            else
            {
                this.tail.NextNode = null;

            }
            this.Count--;

            return lastElement;
        }

        private void CheckIfEmptyThrowException()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("DoublyLinkedList is empty!");
            }
        }

        public bool Contains(int value)
        {
            LinkNode currentNode = this.head;

            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return true;
                }
                currentNode = currentNode.NextNode;
            }
            return false;
        }

        public int[] ToArray()
        {
            int[] array = new int[this.Count];
            var currentNode = this.head;
            int counter = 0;

            while (currentNode != null)
            {
                array[counter++] = currentNode.Value;

                currentNode = currentNode.NextNode;
            }

            return array;
        }

        public void Print(Action<int> action)
        {
            LinkNode currentNode = this.head;

            while (currentNode != null)
            {
                action(currentNode.Value);

                currentNode = currentNode.NextNode;
            }
        }
    }
}
