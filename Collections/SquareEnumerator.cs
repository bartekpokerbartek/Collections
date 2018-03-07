using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class SquareEnumerator : IEnumerator<Square>
    {
        //private SquareCollection _squareCollection;
        private List<Square> _squareCollection;

        private int _currentIndex;

        private Square _currentSquare;

        public SquareEnumerator(List<Square> squareCollection)
        {
            //when created current position is before first element and current element is undefined
            _squareCollection = squareCollection;
            _currentIndex = -1;
            _currentSquare = null;
        }

        public Square Current => _currentSquare;

        object IEnumerator.Current => Current;

        void IDisposable.Dispose()
        {
        }

        bool IEnumerator.MoveNext()
        {
            if (++_currentIndex >= _squareCollection.Count)
            {
                _currentSquare = null;
                return false;
            }
            else
            {
                _currentSquare = _squareCollection[_currentIndex];
            }
            return true;
        }

        void IEnumerator.Reset()
        {
            _currentIndex = -1;
            _currentSquare = null;
        }
    }
}
