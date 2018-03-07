using System;
using System.Collections;
using System.Collections.Generic;

namespace CollectionsBasics
{
    class GenericEnumerableExample : IEnumerable<string>
    {
        private List<string> _stringList = new List<string> { "A", "B", "C" };

        public IEnumerator<string> GetEnumerator()
        {
            Console.WriteLine("Generic enumerator");
            return _stringList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Console.WriteLine("Non-generic enumerator");
            return _stringList.GetEnumerator();
        }
    }
}
