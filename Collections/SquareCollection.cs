using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class SquareCollection : ICollection<Square>
    {
        public SquareCollection() => Squares = new List<Square>();

        public int Count => throw new System.NotImplementedException();

        public bool IsReadOnly => throw new System.NotImplementedException();

        List<Square> Squares { get; set; }

        public void Add(Square item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(Square item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(Square[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerator<Square> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(Square item)
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public Square this[int index]
        {
            get
            {
                return Squares[index];
            }

            set
            {
                Squares[index] = value;
            }
        }
    }
}
