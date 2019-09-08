using System;
using System.Collections;
using System.Collections.Generic;

namespace Task3.Task3
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
                if (index < 0)
                {
                    int negativeIndex = Length + index;
                    try
                    {
                        return array[negativeIndex];
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        throw new IndexOutOfRangeException(e.Message);
                    }
                }
                if (index < Length)
                {
                    return array[index];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Argument out of range");
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
                    throw new ArgumentOutOfRangeException("Argument out of range");
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
            Capacity = standardCapacity;
            OnSetCapacityHandler(collection);
            Array = new T[Capacity];
            AddRange(collection);
        }

        public void Add(T item)
        {
            if (Length >= Capacity)
            {
                Capacity = Capacity * 2;
                ReCreateArray(Capacity);
            }

            int nextIndex = Length;

            Length++;

            Array[nextIndex] = item;

        }

        public void AddRange(IEnumerable<T> collection)
        {
            OnSetCapacityHandler(collection);

            foreach (var item in collection)
            {
                Add(item);
            }
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < Length; i++)
            {
                if (Array[i].Equals(item))
                {
                    NormalizationAfterRemove(i);
                    return true;
                }
            }
            return false;
        }

        private void NormalizationAfterRemove(int index)
        {
            for (int i = index; i < Length; i++)
            {
                Array[i] = Array[i + 1];
            }
            Length--;
        }

        public bool RemoveAt(int index)
        {
            NormalizationAfterRemove(index);
            return true;
        }

        public bool Insert(T item, int index)
        {
            if (index >= Length)
            {
                throw new ArgumentOutOfRangeException("Argument out of range");
            }
            Length++;
            for (int i = Length; i > index; i--)
            {
                Array[i] = Array[i - 1];
            }
            Array[index] = item;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return Array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void PrintArray()
        {
            for (int i = 0; i < Length; i++)
            {
                Console.WriteLine(Array[i]);
            }
        }

        /// <summary>
        /// Возвращает массив из элементов изначального массива
        /// </summary>
        /// <param name="startIndex">индекс, с которого берутся элементы</param>
        /// <param name="endIndex">необязательный параметр. Индекс, на котором заканчиваются браться элементы</param>
        /// <param name="capacity">необязательный параметр. Ёмкость массива</param>
        /// <returns></returns>
        public DynamicArray<T> CopyArrayAt(int startIndex, int endIndex = 0, int capacity = 0)
        {
            if (endIndex == 0)
            {
                endIndex = Length;
            }

            if (capacity == 0)
            {
                capacity = Capacity;
            }

            var temp = Array;
            DynamicArray<T> result = new DynamicArray<T>(capacity);
            for (int i = startIndex; i < endIndex; i++)
            {
                result.Add(temp[i]);
            }

            return result;
        }

        public T[] ToArray()
        {
            T[] result = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                result[i] = Array[i];
            }

            return result;
        }

        /// <summary>
        /// Устанавливает пользовательскую ёмкость
        /// </summary>
        /// <param name="capacity">новая ёмкость</param>
        public void SetUserCapacity(int capacity)
        {
            ReCreateArray(capacity);
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

        /// <summary>
        /// Устанавливает размер коллекции в виде степени двойки
        /// </summary>
        /// <param name="collection">добавляемая коллекция</param>
        private void OnSetCapacityHandler(IEnumerable<T> collection)
        {
            int collectionLength = GetCollectionLength(collection);

            int futureCapacity = collectionLength * 2;

            if (futureCapacity > Capacity)
            {
                int pow = futureCapacity / Capacity;

                for (int i = 0; i < pow; i++)
                {
                    Capacity = Capacity * 2;
                }

                ReCreateArray(futureCapacity);
            }
        }

        /// <summary>
        /// Пересоздаёт массив с новой ёмкостью
        /// </summary>
        /// <param name="capacity">новая ёмкость</param>
        private void ReCreateArray(int capacity)
        {
            var temp = Array;
            Array = new T[capacity];
            //Я даже не знаю костыль это или фитча
            for (int i = 0; i < temp?.Length; i++)
            {
                Array[i] = temp[i];
            }
        }
    }
}
