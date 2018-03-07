using System.Collections.Generic;

namespace CollectionsBasics
{
    class YieldExample
    {
        public IEnumerable<int> Sum(IEnumerable<int> list)
        {
            var myList = new List<int>();
            var currentSum = 0;
            foreach (int item in list)
            {
                currentSum += item;
                myList.Add(currentSum);
            }
            return myList;
        }

        public IEnumerable<int> YieldSum(IEnumerable<int> list)
        {
            var sum = 0;
            foreach (int item in list)
            {
                sum += item;
                yield return sum;
            }
        }
    }
}
