using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Task3._3
{
    public class DynamicArray<T> : IDynamicArray<T>
    {
        private const int standardCapacity = 8;
        private T[] array;
        private int _length;
        private int _capacity;

        public T[] Array { get => array; private set => array = value; }

        public int Length
        {
            get
            {
                return _length;
            }
            private set
            {
                if (value > 0)
                {
                    _length = value;
                }
                else
                {
                    throw new ArgumentException("Length must be greater than zero", "value");
                }
            }
        }

        public int Capacity
        {
            get
            {
                return _capacity;
            }
            private set
            {
                if (value > 0)
                {
                    _capacity = value;
                }
                else
                {
                    throw new ArgumentException("Capacity must be greater than zero", "value");
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < Length)
                {
                    return array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
            set
            {
                if (index < Length)
                {
                    array[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index out of range");
                }
            }
        }

        public DynamicArray()
        {
            Capacity = standardCapacity;
            Array = new T[Capacity];
        }

        public DynamicArray(int capacity)
        {
            Capacity = capacity;
            Array = new T[Capacity];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            Length = GetCollectionLength(collection);
            Capacity = Length * 2;
            Array = new T[Capacity];
        }

        private int GetCollectionLength(IEnumerable<T> collection)
        {
            int length = 0;

            foreach (var item in collection)
            {
                length++;
            }

            return length;
        }

        public void Add(T item)
        {
            if (Length == Capacity)
            {
                Capacity = Capacity * 2;
                //ТАК, ПЕРЕНОС ДАННЫХ СДЕЛАЙ!
                Array = new T[Capacity];
            }

            int nextIndex = Length;

            Length++;

            array[nextIndex] = item;

        }

        public void AddRange(IEnumerable<T> collection)
        {
            
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public bool Insert(T item, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Array.Length; i++)
                yield return Array[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
