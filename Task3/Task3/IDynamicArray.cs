using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3.Task3
{
    public interface IDynamicArray<T> : IEnumerable<T>, IEnumerable, ICloneable
    {
        void Add(T item);
        void AddRange(IEnumerable<T> collection);
        bool Remove(T item);
        bool RemoveAt(int index);
        bool Insert(T item, int index);
        void PrintArray();
        DynamicArray<T> CopyArrayAt(int startIndex, int endIndex, int capacity);
        T[] ToArray();
        void SetUserCapacity(int capacity);
    }
}
