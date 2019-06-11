using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private List<T> boxItems;

        public int Count
        {
            get
            {
                return boxItems.Count;
            }
        }

        public Box()
        {
            boxItems = new List<T>();
        }

        public void Add(T element)
        {
            boxItems.Add(element);
        }

        public T Remove()
        {

            if (Count > 0)
            {
                T lastElement = boxItems.Last();
                boxItems.RemoveAt(Count - 1);

                return lastElement;
            }

            throw new InvalidOperationException("Can not remove element form empty collection.");

            
        }


    }
}
