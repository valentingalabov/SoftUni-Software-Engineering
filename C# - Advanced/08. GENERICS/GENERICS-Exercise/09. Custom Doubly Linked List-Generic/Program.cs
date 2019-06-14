using System;
using System.Collections.Generic;

namespace Custom_Doubly_Linked_List
{
    class Program
    {
        static void Main(string[] args)
        {
            
                
            var doublyLinkedList = new DoublyLinkedList<string>();

            doublyLinkedList.AddLast("asad");
            doublyLinkedList.AddLast("123124asd");
            doublyLinkedList.AddLast("are1241");



            Console.WriteLine(doublyLinkedList.Contains("asad"));
        }
    }
}
