using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> data;

        

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
            Counter = 0;
        }
        public int Counter { get; set; }
        public int Count => data.Count;

        public void Add(Person person)
        {
            data.Add(Counter,person);
            Counter++;
        }

        public Person Get(int id)
        {
            return data[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (data.ContainsKey(id))
            {
                data[id] = newPerson;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            if (data.ContainsKey(id))
            {
                data.Remove(id);
                Counter--;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
