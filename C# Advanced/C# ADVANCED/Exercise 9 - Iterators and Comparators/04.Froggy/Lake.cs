using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    class Lake<T> : IEnumerable<T>
    {
        private List<T> items;

        public Lake(List<T> list)
        {
            this.items = list;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.items.Count; i += 2)
            {
                yield return this.items[i];
            }
            if (items.Count % 2 == 0)
            {
                for (int i = this.items.Count - 1; i >= 0; i = i - 2)
                {
                    yield return this.items[i];
                }
            }
            else
            {
                for (int i = this.items.Count - 2; i >= 0; i = i - 2)
                {
                    yield return this.items[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
