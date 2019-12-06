using System;
using System.Collections.Generic;

namespace MotionSimulation
{
    public class Traces<T>
    {
        private readonly List<T> _items;

        public Traces(int maxQuantity)
        {
            _items = new List<T>();
            MaxQuantity = maxQuantity > 0 ? maxQuantity : throw new ArgumentOutOfRangeException(nameof(maxQuantity));
        }

        public int Quantity => _items.Count;

        private int _maxQuantity;
        public int MaxQuantity
        {
            get => _maxQuantity;
            set
            {
                if (value < Quantity)
                    _items.RemoveRange(value, Quantity - value);
                _maxQuantity = value;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Quantity)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return _items[index];
            }
        }

        public void Add(T item)
        {
            if (item != null)
            {
                _items.Insert(0, item);
                if (_items.Count >= MaxQuantity)
                    _items.RemoveAt(_items.Count - 1);
            }
        }

        public void Clear() => _items.Clear();

        public T[] GetAll() => _items.ToArray();
    }
}
