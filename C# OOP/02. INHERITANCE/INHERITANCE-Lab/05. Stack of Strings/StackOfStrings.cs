
using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(IEnumerable<string> data)
        {
            foreach (var item in data)
            {
                this.Push(item);
            }

        }

    }
}
