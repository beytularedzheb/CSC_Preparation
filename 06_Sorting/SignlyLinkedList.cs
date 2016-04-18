namespace CSC_Preparation
{
    using System;
    using System.Collections.Generic;

    class SignlyLinkedList<T>
    {
        private SignlyLinkedList<T> head;
        private SignlyLinkedList<T> tail;

        // TODO: move 'next' and 'listItem' in an other structure and
        // use it like Node<T>
        private SignlyLinkedList<T> next;

        private T listItem;
        private int count;

        public int Count
        {
            get
            {
                return this.count;
            }
            private set
            {
                if (value >= 0)
                {
                    this.count = value;
                }
            }
        }

        public SignlyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.next = null;
        }

        private SignlyLinkedList(T item) : this()
        {
            this.listItem = item;
        }

        public void AddFirst(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            SignlyLinkedList<T> newItem = new SignlyLinkedList<T>(item);
            newItem.next = head;
            head = newItem;
            if (tail == null)
            {
                tail = head;
            }
            Count++;
        }

        public void AddLast(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            SignlyLinkedList<T> newItem = new SignlyLinkedList<T>(item);
            if (head == null)
            {
                head = newItem;
                tail = head;
            }
            else
            {
                tail.next = newItem;
            }
            tail = newItem;

            Count++;
        }

        public void Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException();
            }

            SignlyLinkedList<T> i = head;
            SignlyLinkedList<T> prev = null;
            bool removed = false;

            while (i != null)
            {
                if (i.listItem.Equals(item))
                {
                    if (prev == null)
                    {
                        if (head == tail)
                        {
                            tail = head.next;
                        }
                        head = head.next;
                    }
                    else
                    {
                        prev.next = i.next;
                        if (i == tail)
                        {
                            tail = prev;
                        }
                    }
                    removed = true;
                    Count--;
                    break;
                }
                prev = i;
                i = i.next;
            }

            if (!removed)
            {
                throw new ArgumentException(item + " does not exist in the queue.");
            }
        }

        public bool Contains(T item)
        {
            foreach (var i in this)
            {
                if (i.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            SignlyLinkedList<T> i = head;

            while(i != null)
            {
                yield return i.listItem;
                i = i.next;
            }
        }
    }
}
