using System;
using System.Collections.Generic;

namespace Custom_Doubly_Linked_List
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            
                
            var doublyLinkedList = new DoublyLinkedList<string>();

            

            doublyLinkedList.AddLast("asad");
            doublyLinkedList.AddLast("123124asd");
            doublyLinkedList.AddLast("are1241");

            foreach (var item in doublyLinkedList)
            {
                Console.WriteLine(item);
            }


            
        }
    }
}
