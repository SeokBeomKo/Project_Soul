using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Tile;

namespace DataStruct
{
    public class PriorityQueue<T>
    {
        private List<T> elements = new List<T>();
        private IComparer<T> comparer;

        public PriorityQueue(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public void Enqueue(T item)
        {
            elements.Add(item);
            int ci = elements.Count - 1;
            while (ci > 0)
            {
                int pi = (ci - 1) / 2;
                if (comparer.Compare(elements[ci], elements[pi]) >= 0) break;

                T tmp = elements[ci];
                elements[ci] = elements[pi];
                elements[pi] = tmp;
                ci = pi;
            }
        }

        public T Dequeue()
        {
            var result = elements[0];
            int li = elements.Count - 1;
            elements[0] = elements[li];
            elements.RemoveAt(li--);
            int pi = 0;
            while (true)
            {
                int ci = pi * 2 + 1;
                if (ci > li) break;

                int rc = ci + 1;
                if (rc <= li && comparer.Compare(elements[rc], elements[ci]) < 0) ci = rc;
                if (comparer.Compare(elements[pi], elements[ci]) <= 0) break;

                T tmp = elements[ci];
                elements[ci] = elements[pi];
                elements[pi] = tmp;
                pi = ci;
            }

            return result;
        }

        public int Count
        {
            get { return elements.Count; }
        }

        public bool Contains(Vector2 position)
        {
            return elements.Any(e => (e as TileNode).Position.Equals(position));
        }
    }
}
