using System.Collections;
using System.Collections.Generic;

namespace CollectionsBasics
{
    class EnumerableExample : IEnumerable
    {
        List<int> _intList;

        public EnumerableExample(List<int> intList)
        {
            _intList = intList;
        }

        public IEnumerator GetEnumerator()
        {
            return _intList.GetEnumerator();
        }
    }
}
