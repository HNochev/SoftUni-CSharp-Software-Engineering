using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _01.CustomList
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }

        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                copy[i] = this.items[i];
            }

            this.items = copy;
        }

        private void ShiftToLeft(int index)
        {
            if (index < this.Count - 1)
            {
                for (int i = index; i < this.Count - 1; i++)
                {
                    this.items[i] = this.items[i + 1];
                }
            }

            this.items[index] = default;
        }

        private void ShiftToRight(int index)
        {
            if (this.items.Length == this.Count)
            {
                Resize();
            }

            for (int i = this.Count - 1; i >= index; i--)
            {
                this.items[i + 1] = this.items[i];
            }

            this.items[index] = default;
        }

        public void Add(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int item = this.items[index];
            this.items[index] = default;
            this.Shift(index);

            this.Count--;

            if (this.Count <= this.items.Length / 4)
            {
                this.Shrink();
            }

            return item;
        }

        public void InsertAt(int index, int element)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftToRight(index);

            this.items[index] = element;
            this.Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (secondIndex >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int tempItem = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = tempItem;
        }

        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }
    }
}
