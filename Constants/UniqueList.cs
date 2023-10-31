using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFwiz.Constants
{
    public class UniqueList<T> : List<T>
    {
        private int maxSize;

        public UniqueList(int maxSize)
        {
            this.maxSize = maxSize;
        }
        public UniqueList(List<T> list, int maxSize) : this(maxSize)
        {
            foreach (T item in list)
            {
                this.Add(item);
            }
        }
        public List<T> ToList()
        {
            return this;
        }

        public new bool Add(T item)
        {
            if (item == null)
            {
                return false;
            }

            bool added = false;
            for (int i = 0; i < this.Count; i++)
            {
                T existingItem = this[i];
                if (IsDuplicate(item, existingItem))
                {
                    added = true;
                    this.RemoveAt(i);
                    break;
                }
            }

            if (this.Count >= maxSize)
            {
                this.RemoveAt(0);
            }
            base.Add(item);

            return added;
        }

        private bool IsDuplicate(T item, T existingItem)
        {
            if (item == null || existingItem == null)
            {
                return false;
            }

            if (item.Equals(existingItem))
            {
                return true;
            }
            return false;
        }
    }
 }
