using System;
using System.Collections.Generic;

namespace Custom_Doubly_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            
                
            var doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.AddLast(1);
            doublyLinkedList.AddLast(2);
            doublyLinkedList.AddLast(3);



            Console.WriteLine(doublyLinkedList.Contains(2));
        }
    }
}
