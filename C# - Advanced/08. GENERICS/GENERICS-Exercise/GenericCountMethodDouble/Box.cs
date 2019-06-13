using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box<T> where T : IComparable<T>
    {
        private List<T> boxCollection;

        public Box()
        {
            this.boxCollection = new List<T>();
        }

        public int CountGreater { get; private set; }


        public void Add(T item)
        {
            boxCollection.Add(item);
        }

        public void Compare(T item)
        {
            foreach (var currentItem in this.boxCollection)
            {

                if (currentItem.CompareTo(item) > 0)
                {
                    CountGreater++;
                }
            }

            Console.WriteLine(CountGreater);

        }
    }
}
