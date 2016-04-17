namespace CSC_Preparation
{
    using System.Collections.Generic;

    class HashedSet<T>
    {
        private HashTable<T, bool> data;
        
        public int Count
        {
            get
            {
                return data.Count;
            }
        }
        
        public HashedSet()
        {
            data = new HashTable<T, bool>();
        }
         
        public void Add(T item)
        {
            data.Add(item, false);
        }

        public bool Contains(T item)
        {
            return data.ContainsKey(item);
        }

        public void Remove(T item)
        {
            data.Remove(item);
        }

        public void Clear()
        {
            data.Clear();
        }

        public void Union(HashedSet<T> hashedSet)
        {
            foreach (var item in hashedSet)
            {
                if (!Contains(item))
                {
                    Add(item);
                }
            }
        }

        public void Intersect(HashedSet<T> hashedSet)
        {
            foreach (var item in data.Keys)
            {
                if (!hashedSet.Contains(item))
                {
                    Remove(item);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in data.Keys)
            {
                yield return item;
            }
        }
    }
}
