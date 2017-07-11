using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListApp
{
    class AxArrayList<T> : IEnumerable, IEnumerable<T>
    {
        //Fields
        T[] items;


        //Constructor
        public AxArrayList() : this(0)
        {

        }
        public AxArrayList(int length)
        {
            if (length < 0)
            {
                throw new ArgumentException($"Длина массива не может быть отрицательной [{length} < 0]");
            }

            items = new T[length];
        }
        public AxArrayList(ICollection<T> list)
        {
            int index = 0;
            items = new T[list.Count];
            foreach (var e in list)
            {
                Count++;
                items[index++] = e;
            }
        }

        public int Count
        {
            get;
            internal set;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return items[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        //Methods
        public void Add(T item)
        {

            if (items.Length == Count)
            {
                GrowthArray();
            }
            items[Count++] = item;
        }

        public void GrowthArray()
        {
            int newLength = items.Length == 0 ? 4 : items.Length << 1;
            T[] newItems = new T[newLength];
            items.CopyTo(newItems, 0);
            items = newItems;
        }

        public bool Insert(T item, int pos)
        {
            if (pos < 0)
            {
                throw new ArgumentException("Индекс не модет быть меньше нуля");
            }

            T[] newItems = new T[this.items.Length + 1];
            for (int i = 0; i < pos; i++)
            {
                newItems[i] = this.items[i];
            }

            newItems[pos] = item;

            for (int i = pos + 1; i < newItems.Length; i++)
            {
                newItems[i] = this.items[i - 1];
            }

            this.items = newItems;

            return true;
        }

        public bool InsertAfter(T item, T prevItem)
        {
            int pos = -1;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(prevItem))
                {
                    pos = i;
                }
            }


            if (pos == -1)
            {
                return false;
            }
            else
            {
                this.Insert(item, pos + 1);
                return true;
            }
        }

        public T this[int i]
        {
            get { return items[i]; }
            set { items[i] = value; }
        }

        public int Finder(T t)
        {
            int pos = -1;
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].Equals(t))
                {
                    pos = i;
                    return pos;
                }
            }
            return pos;
        }

    }
}
