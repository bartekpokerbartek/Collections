using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    class SquareEnumerable : IEnumerable<Square>
    {

        public IEnumerator<Square> GetEnumerator()
        {
            return new SquareEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
