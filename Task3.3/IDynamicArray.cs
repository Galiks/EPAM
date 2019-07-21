using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3._3
{
    public interface IDynamicArray<T>: IEnumerable<T>, IEnumerable, ICloneable
    {
        void Add(T item);
        void AddRange(IEnumerable<T> collection);
        bool Remove(T item);
        bool Insert(T item, int index);
    }
}
