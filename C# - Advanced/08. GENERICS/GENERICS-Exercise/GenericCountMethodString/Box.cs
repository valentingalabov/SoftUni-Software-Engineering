using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodString
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
