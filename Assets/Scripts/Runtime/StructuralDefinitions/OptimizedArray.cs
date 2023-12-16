using System;

namespace Runtime.StructuralDefinitions
{
    public class OptimizedList<T>
    {
        public T this[int i] => _array[i];
        
        public int Count => _array.Length;
        
        private T[] _array;
        
        public OptimizedList()
        {
            _array = Array.Empty<T>();
        }

        public OptimizedList(T t)
        {
            _array = new T[1];

            _array[0] = t;
        }
        
        public OptimizedList(T[] tArray)
        {
            _array = new T[tArray.Length];

            for (int index = 0; index < tArray.Length; index++)
            {
                _array[index] = tArray[index];
            }
        }

        public void Add(T t)
        {
            T[] tempArray = _array;
            _array = new T[_array.Length + 1];

            for (int index = 0; index < tempArray.Length; index++)
            {
                _array[index] = tempArray[index];
            }

            _array[^1] = t;
        }

        public void Remove(T t)
        {
            int removeIndex = 0;
            
            for (int index = 0; index < _array.Length; index++)
            {
                if (t.Equals(_array[index]))
                {
                    removeIndex = index;
                }
            }

            RemoveAt(removeIndex);
        }

        public void RemoveAt(int removeIndex)
        {
            for (int index = removeIndex; index < _array.Length - 1; index++)
            {
                _array[index] = _array[index + 1];
            }
            
            Array.Resize(ref _array, _array.Length - 1);
        }

        public bool Contains(T t)
        {
            for (int index = 0; index < _array.Length; index++)
            {
                if (_array[index].Equals(t))
                {
                    return true;
                }
            }

            return false;
        }
    }
}