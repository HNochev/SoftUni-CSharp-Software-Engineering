using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _02.CollectionFullImplementation
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index;

        public ListyIterator(List<T> items)
        {
            this.items = items;
            this.index = 0;
        }

        public bool Move()
        {
            bool hasNext = HasNext();
            if (hasNext)
            {
                this.index++;
            }
            return hasNext;
        }

        public bool HasNext()
        {
            return this.index < this.items.Count - 1;
        }

        public void Print()
        {
            if (this.index < this.items.Count)
            {
                Console.WriteLine(items[index]);
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            //foreach (var item in items)
            //{
            //    yield return item;
            //}

            return new Enumerator(this.items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class Enumerator : IEnumerator<T>
        {
            private List<T> elements;
            private int index;

            public Enumerator(List<T> elements)
            {
                this.elements = elements;
                this.index = -1;
            }

            public T Current
            {
                get
                {
                    if (this.index >= this.elements.Count)
                    {
                        throw new InvalidOperationException("Invalid operation!");
                    }
                    return this.elements[this.index];
                }
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                bool hasNext = this.index < this.elements.Count - 1;
                if (hasNext)
                {
                    this.index++;
                }
                return hasNext;
            }

            public void Reset()
            {
                this.index = -1;
            }
        }
    }
}
