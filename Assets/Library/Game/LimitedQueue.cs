using System.Collections.Generic;

namespace Library.Game
{
    public class LimitedQueue<T>
    {
        private readonly Queue<T> _bufferStack;
        private readonly int _size;

        public LimitedQueue(int size)
        {
            _size = size;
            _bufferStack = new Queue<T>(_size);
        }

        public int Count => _bufferStack.Count;

        public bool Contains(T value)
        {
            return _bufferStack.Contains(value);
        }

        public void Push(T value)
        {
            if (_bufferStack.Count > _size - 1)
                _bufferStack.Dequeue();

            _bufferStack.Enqueue(value);
        }
    }
}