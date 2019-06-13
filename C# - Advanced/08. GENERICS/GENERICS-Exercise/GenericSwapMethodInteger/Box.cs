using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {
        private List<T> boxCollection;

        public Box()
        {
            this.boxCollection = new List<T>();
        }

        public void Add(T item)
        {
            boxCollection.Add(item);
        }

        public void Swap(int firsElementIndex, int secondElementIndex)
        {
            var temp = boxCollection[firsElementIndex];

            boxCollection[firsElementIndex] = boxCollection[secondElementIndex];
            boxCollection[secondElementIndex] = temp;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var text in this.boxCollection)
            {
                sb.AppendLine($"{text.GetType().FullName}: {text}");
            }

            return sb.ToString();
        }
    }
}
