using System.Collections.Generic;

namespace Dodge.Library.Game
{
    public class LimitedStack<T>
    {
        private readonly Stack<T> _bufferStack;

        private readonly int _size;
        
        public LimitedStack(int size)
        {
            _size = size;
            _bufferStack = new Stack<T>(_size);
        }

        public bool Contains(T value)
        {
            return _bufferStack.Contains(value);
        }

        public void Push(T value)
        {
            if (_bufferStack.Count > _size - 1)
                _bufferStack.Pop();
                
            _bufferStack.Push(value);
        }
    }
}
