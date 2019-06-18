using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
      
        private const int defaultSize = 4;
        
        private T[] innerArr;

      
        public int Count { get; private set; } = 0;

        public Stack()
        {
            innerArr = new T[defaultSize];
        }

        public void Push(T element)
        {
            if (innerArr.Length == Count)
            {
                Grow();
            }

            innerArr[Count] = element;
            Count++;
        }

        public T Pop()
        {
            CheckIfEmpty();
            Count--;
            T tempElement = innerArr[Count];
            innerArr[Count] = default(T);

            return tempElement;
        }

        


        private void Grow()
        {
            T[] tempArr = new T[innerArr.Length * 2];

            innerArr.CopyTo(tempArr, 0);
            innerArr = tempArr;
        }


        private void CheckIfEmpty()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException
                    ("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return this.innerArr[i];
            }
            for (int i = Count - 1; i >= 0; i--)
            {
                yield return this.innerArr[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
