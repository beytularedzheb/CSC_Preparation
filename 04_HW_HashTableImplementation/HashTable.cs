/*
4. Implement the data structure `hash table` in a class `HashTable<K,T>`. Keep the data in
array of lists of key‐value pairs (`LinkedList<KeyValuePair<K,T>>[]`) with initial capacity
of 16. When the hash table load runs over 75%, perform resizing to 2 times larger capacity.
Implement the following methods and properties:
* `Add(key, value)`
* `Find(key)‐>value`
* `Remove(key)`
* `Count`
* `Clear()`
* `this[]`
* `Keys`
Try to make the hash table to support iterating over its elements with `foreach`.
Write unit tests for your class.
*/

namespace CSC_Preparation
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The class implements the data structure 'hash table'.
    /// </summary>
    /// <typeparam name="TKey">The key of element.</typeparam>
    /// <typeparam name="TValue">The value of element.</typeparam>
    class HashTable<TKey, TValue>
    {
        #region Constants
        private const float ResizeWhenReach = 0.75f;
        private const int StartCapacity = 16;
        #endregion

        #region Private Fields
        private int count;
        private LinkedList<KeyValuePair<TKey, TValue>>[] data;
        #endregion

        #region Public Fields
        public int Count
        {
            get
            {
                return count;
            }
            private set
            {
                count = (value >= 0) ? value : 0;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                ICollection<TKey> keys = new List<TKey>();
                for (int i = 0; i < data.Length; i++)
                {
                    foreach (var pair in data[i])
                    {
                        keys.Add(pair.Key);
                    }
                }

                return keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                ICollection<TValue> values = new List<TValue>();
                for (int i = 0; i < data.Length; i++)
                {
                    foreach (var pair in data[i])
                    {
                        values.Add(pair.Value);
                    }
                }

                return values;
            }
        }

        public int Capacity
        {
            get
            {
                return data.Length;
            }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the class that is empty, has the default initial capacity.
        /// </summary>
        public HashTable()
        {
            InitializeWith(StartCapacity);
        }

        #region Private Methods
        private int GetHashIndex(TKey key)
        {
            if (key == null)
            {
                throw new ArgumentNullException("Key cannot be null.");
            }
            return Math.Abs(key.GetHashCode()) % data.Length;
        }

        private void Resize()
        {
            LinkedList<KeyValuePair<TKey, TValue>>[] oldData = data;
            InitializeWith(data.Length * 2);

            for (int i = 0; i < oldData.Length; i++)
            {
                foreach (var pair in oldData[i])
                {
                    Add(pair.Key, pair.Value);
                }
            }
        }

        private void InitializeWith(int capacity)
        {
            Count = 0;
            data = new LinkedList<KeyValuePair<TKey, TValue>>[capacity];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
        }

        private bool ShouldBeResized()
        {
            return ((double)Count / data.Length >= 0.75);
        }
        #endregion

        /// <summary>
        /// Adds the specified key and value to the hash table.
        /// </summary>
        /// <param name="key">The key of element to add.</param>
        /// <param name="value">The value of element to add.</param>
        /// <exception cref="ArgumentException">When the key of element already exists.</exception>
        public void Add(TKey key, TValue value)
        {
            if (!ContainsKey(key))
            {
                int index = GetHashIndex(key);
                data[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
                count++;

                if (ShouldBeResized())
                {
                    Resize();
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Gets the value of associated with the specified key
        /// </summary>
        /// <param name="key">The key of element to get.</param>
        /// <returns>The value of element.</returns>
        /// <exception cref="KeyNotFoundException">When the key of element does not exist.</exception>
        public TValue Find(TKey key)
        {
            int index = GetHashIndex(key);
            foreach (var pair in data[index])
            {
                if (pair.Key.Equals(key))
                {
                    return pair.Value;
                }
            }

            throw new KeyNotFoundException();
        }

        /// <summary>
        /// Removes the element with the specified key.
        /// </summary>
        /// <param name="key">The key of element to remove.</param>
        /// <exception cref="KeyNotFoundException">When the key of element does not exist.</exception>
        public void Remove(TKey key)
        {
            if (!ContainsKey(key))
            {
                throw new KeyNotFoundException();
            }

            int index = GetHashIndex(key);
            foreach (var pair in data[index])
            {
                if (pair.Key.Equals(key))
                {
                    data[index].Remove(pair);
                    break;
                }
            }
            count--;
        }

        /// <summary>
        /// Removes all keys and values.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i].Clear();
            }
            count = 0;
        }

        /// <summary>
        /// Indexer for get / add / replace of element by key.
        /// </summary>
        /// <param name="key">The key of element you want to get / replace or to add new element with the specified key and value.</param>
        /// <returns>The value of element.</returns>
        public TValue this[TKey key]
        {
            get
            {
                return Find(key);
            }
            set
            {
                bool exists = false;
                int index = GetHashIndex(key);
                foreach (var pair in data[index])
                {
                    if (pair.Key.Equals(key))
                    {
                        KeyValuePair<TKey, TValue> newPair = new KeyValuePair<TKey, TValue>(pair.Key, value);
                        data[index].AddLast(newPair);
                        data[index].Remove(pair);
                        exists = true;
                        break;
                    }
                }

                if (!exists)
                {
                    Add(key, value);
                }
            }
        }

        /// <summary>
        /// Checks if element with the specified key exists.
        /// </summary>
        /// <param name="key">The key of element for check.</param>
        /// <returns>True: when it exists. False: when it does not.</returns>
        public bool ContainsKey(TKey key)
        {
            foreach (var itemKey in Keys)
            {
                if (itemKey.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if element with the specified value exists.
        /// </summary>
        /// <param name="value">The value of element for check.</param>
        /// <returns>True: when it exists. False: when it does not.</returns>
        public bool ContainsValue(TValue value)
        {
            foreach (var itemValue in Values)
            {
                if (itemValue.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Makes the hash table able to be used with foreach loop.
        /// </summary>
        /// <returns>Yields the current element.</returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < data.Length; i++)
            {
                foreach (var pair in data[i])
                {
                    yield return pair;
                }
            }
        }
    }
}
