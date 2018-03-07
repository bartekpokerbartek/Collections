using System;
using System.Collections;

namespace CollectionsBasics
{
    class MyEnumerator : IEnumerator
    {
        private MyCollection _myCollection;
        private int index = -1;

        public MyEnumerator(MyCollection myCollection)
        {
            _myCollection = myCollection;
        }

        public object Current
        {
            get
            {
                if (index == -1)
                    throw new InvalidOperationException();

                return _myCollection.GetElementById(index);
            }
        }

        public bool MoveNext()
        {
            index++;
            if (index < _myCollection.Length)
                return true;

            index = -1;
            return false;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
