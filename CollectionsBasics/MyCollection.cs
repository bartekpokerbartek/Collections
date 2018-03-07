using System.Collections.Generic;
using System.Collections;

namespace CollectionsBasics
{
    class MyCollection : IEnumerable
    {
        private List<int> _list;

        public int Length
        {
            get
            {
                return _list.Count;
            }
        }

        public MyCollection(List<int> list)
        {
            _list = list;
        }

        public int GetElementById(int id)
        {
            return _list[id];
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(this);
        }
    }
}
